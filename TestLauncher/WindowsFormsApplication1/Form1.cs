using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HadesTestLauncher
{
    public partial class Form1 : Form
    {
        private static String FilePath = @"z:\TestCases.txt";
        private static String TestResults = @"z:\TestResults.txt";
        private static Dictionary<string, string> TestResultsHolder = new Dictionary<string, string>();
        Arguments CommandLine;
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        

        public Form1(string[] args)
        {
            InitializeComponent();
            CommandLine = new Arguments(args);
            // Check to see the current state (running at startup or not)
            if (rkApp.GetValue("TestEFI") == null)
            {
                //The value was set.
                rkApp.SetValue("TestEFI", Application.ExecutablePath.ToString());
                //Get test results from previous run..
            }
            else
            {
                // The value exists, the application is set to run at startup
                rkApp.DeleteValue("TestEFI", false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //check to see if dirve b is available.
            if (!UtitlityFunctions.CheckEfi())
            {
                //not found...
                MessageBox.Show("Efi Partition not found");
               // this.Close();
            }
           // Get File Name and launch file streamer.
            if (CommandLine["file"] == null)
            {
                //no file specified
                if (File.Exists(FilePath))
                {
                    //Let's use the hardcoded path instead then.
                    UtitlityFunctions.LoadTestFiles(FilePath);
                } else
                {
                    MessageBox.Show("File not found");
                    this.Close();
                }
               
            } else
            {
                UtitlityFunctions.LoadTestFiles(CommandLine["file"]);
                //PopulateList();
            }  
        }


        private void PopulateList()
        {
            if (UtitlityFunctions.TestList != null)
            {
                foreach (String s in UtitlityFunctions.TestList)
                {
                    TestList.Items.Add(s);

                }

            }else
            {
                MessageBox.Show("ArrayList is empty!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestInput Box = new TestInput();
            if (Application.OpenForms[Box.Name] == null)
            {
                Box.ShowDialog();
            }
            else
            {
                Application.OpenForms[Box.Name].Focus();
            }

            // Check for Data that is sent back.
            if ((Box.TestValue != null))
            {
                TestList.Items.Add(Box.TestValue);
            }
            else
            {
                MessageBox.Show("Nothing Was added!");
            }
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Clearing the file out.
            if (CommandLine["file"] == null)
            {
                System.IO.File.WriteAllText(FilePath, string.Empty);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath))
                {
                    foreach (Object o in TestList.Items)
                    {
                        file.WriteLine(o.ToString());
                    }
                }
            } else
            {
                System.IO.File.WriteAllText(CommandLine["file"], string.Empty);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(CommandLine["file"]))
                {
                    foreach (Object o in TestList.Items)
                    {
                        file.WriteLine(o.ToString());
                    }
                }
            }
            

            //We want to save the contents of the testfile list.
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            while (TestList.SelectedItems.Count > 0)
            {
                TestList.Items.Remove(TestList.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rkApp.SetValue("TestEFI", Application.ExecutablePath.ToString());

            UtitlityFunctions.LaunchUEFITool();

            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\Shutdown", "-s -r 50");

            //We will set the new bootnext variable to the new bootvalue.
           // UInt16 BootNext = 0; //This is hardcoded to the internal EFI Shell
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
             //Find the test cases and post results.
            
            if (File.Exists(CommandLine["TestResults"]))
            {
                GetResults(CommandLine["TestResults"]);
            }
            else if (File.Exists(TestResults))
            {
                GetResults(TestResults);
            }
            else
            {
                MessageBox.Show("File not found");
                this.Close();
            }
        }

        private void GetResults(string File)
        {
            string line = null;
            int i = 0;
            int found = 0;
            int indexEndName = 0;
            List<string> comments = new List<string>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(File);
            while ((line = file.ReadLine()) != null)
            {
                i = 0;

                

                found = line.IndexOf("case -> ", i);

                if (found >= 0)
                {
                    //Get Test Case Name and PASS or FAIL.
                    //Add node to tree.
                    

                    indexEndName = line.IndexOf(" -> ", (found + 8));
                    string CaseName = line.Substring((found + 8), (indexEndName - (found +8))); // +8 for getting the start of the name of the test case.
                    
                    
                    //Now lets get the PASS or FAIL
                    string PassOrFail = line.Substring((indexEndName + 4));

                    TreeNode treeNode = new TreeNode(CaseName);
                    this.treeView1.Nodes.Add(treeNode);

                    TestResultsHolder.Add(CaseName, PassOrFail);

                    //flush out comments and add them to tree.
                    //i = ++found;
                }
                else
                {
                    comments.Add(line);
                }

                

            }


            //populate the pane with the results.
            foreach (KeyValuePair<string, string> pair in TestResultsHolder)
            {
                Console.WriteLine("{0}, {1}",
                pair.Key,
                pair.Value);

                this.dataGridView1.Rows.Add(pair.Key, pair.Value);
            }
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            file.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
