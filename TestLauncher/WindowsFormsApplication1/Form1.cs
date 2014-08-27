using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HadesTestLauncher
{
    public partial class Form1 : Form
    {
        private String FilePath;
        Arguments CommandLine;
        

        public Form1(string[] args)
        {
            InitializeComponent();
            CommandLine = new Arguments(args);
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
                MessageBox.Show("File not found");
                this.Close();
            } else
            {
                ; UtitlityFunctions.LoadTestFiles(CommandLine["file"]);
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
    }
}
