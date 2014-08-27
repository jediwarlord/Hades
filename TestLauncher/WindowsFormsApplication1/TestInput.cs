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
    public partial class TestInput : Form
    {

        public string TestValue = null;
        public TestInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == null)
            {
                MessageBox.Show("Please Enter a Test Value");
            }
            else
            {
                TestValue = InputBox.Text;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
