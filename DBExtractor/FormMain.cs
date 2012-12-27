using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DBExtractorExchange;

namespace DBExtractor
{
    public partial class FormMain : Form
    {
        const string FileName = @"settings.bin";
        DBExtractorSettings settings;

        public FormMain()
        {
            if (File.Exists(FileName))
            {
                Stream fileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                settings = (DBExtractorSettings)deserializer.Deserialize(fileStream);
                fileStream.Close();
                Console.WriteLine("Deserializacja udnana");
            }
            else
            {
                this.settings = new DBExtractorSettings();
                Console.WriteLine("Brak pliku - tworze nowy obiekt");
            }

            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormMain_Closing);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Checking...";
                ServiceHelper sh = new ServiceHelper("DBExtractorService");
                label1.Text = "Service found";
            }
            catch (ServiceNotFoundException)
            {
                Console.WriteLine("blad");
                label1.Text = "Service not found";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Stream fileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, this.settings);
            fileStream.Close();
            Console.WriteLine("Serialzuje obiekt do pliku");

            this.pictureBox1.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
