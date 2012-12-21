using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Form1_Closing);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Checking...";
                ServiceHelper sh = new ServiceHelper("AFBAgent");
                label1.Text = "Service found";
            }
            catch(ServiceNotFoundException) 
            {
                label1.Text = "Service not found";
            }
        }
    }
}
