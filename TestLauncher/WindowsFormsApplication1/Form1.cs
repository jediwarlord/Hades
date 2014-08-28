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
            System.IO.File.WriteAllText(CommandLine["file"], string.Empty);

            //We want to save the contents of the testfile list.
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(CommandLine["file"]))
            {
                foreach (Object o in TestList.Items)
                {
                        file.WriteLine(o.ToString());   
                }
            }
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
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\Shutdown", "-s -r 50");
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
            string 

            System.IO.StreamReader file =
                new System.IO.StreamReader(File);
            while ((line = file.ReadLine()) != null)
            {
               
            }

            file.Close();


        }
    }
}
