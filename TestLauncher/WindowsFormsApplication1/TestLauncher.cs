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
    public partial class TestLauncher : Form
    {
        public TestLauncher()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void TestLauncher_Load(object sender, EventArgs e)
        {
            //When the form loads start running the batchfiles that we will mark progress from.
        }
    }
}
