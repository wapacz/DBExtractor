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
using System.Collections;
using System.Data.Sql;
using System.Threading;

using ITSharp.ScheDEX.Common;
using ITSharp.ScheDEX.GUI;
using System.Security.AccessControl;

namespace ITSharp.ScheDEX
{
    public partial class FormMain : Form
    {
        private static readonly Font RegularFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        private static readonly Font BoldFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

        private static readonly string WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ScheDEX");
        private static readonly string SettingsFilePath = Path.Combine(WorkingDirectory, "settings.bin");
        private static readonly string EventsFilePath = Path.Combine(WorkingDirectory, "events.bin");
        internal ScheDEXSettings settings;
        internal ScheduleEventList events;
        private Dictionary<String, UserControl> userPanels;
        private Dictionary<String, Bitmap> leftSideImages;

        internal SQLConnectionHelper sql;
        internal FTPHelper ftp;
        internal ServiceHelper service;

        public FormMain()
        {
            InitializeComponent();
            InitializeMyComponent();
            this.Closing += new CancelEventHandler(this.FormMain_Closing);
        }

        private void InitializeMyComponent()
        {
            /*
             * Create working directory if not exists
             */
            if (!Directory.Exists(WorkingDirectory))
                Directory.CreateDirectory(WorkingDirectory);
            
            /*
             * Loading settings from file if available
             */
            this.settings = ScheDEXSettings.Load(SettingsFilePath);
            this.events = ScheduleEventList.Load(EventsFilePath);

            /*
             * Initialize events related issues
             */
            this.eventsP.ContainerForm = this;
            
            /*
             * Initialize SQL connection related issues
             */
            this.sqlP.ContainerForm = this;
            this.sql.ConnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_ConnectionEvent);
            this.sql.DisconnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_DisconnectionEvent);
            this.sql.ServerNamesHasBeenFetched += new EventHandler(sql_ServerNamesHasBeenFetched);
            
            /*
             * Initialize FTP related issues
             */
            this.ftpP.ContainerForm = this;
            
            /*
             * Service controler related issues
             */
            this.serviceP.ContainerForm = this;
            this.service.FindingEvent += new EventHandler<ServiceEventArgs>(service_FindingEvent);
            /*
             * Store settings
             */
            //this.settings.Save();

            /*
             * Handle switching of UserControls
             */
            this.userPanels = new Dictionary<String, UserControl>();
            this.leftSideImages = new Dictionary<String, Bitmap>();
            // events panel
            this.userPanels[this.llEventsConfig.Name] = this.eventsP;
            this.leftSideImages[this.llEventsConfig.Name] = global::ScheDEX.Properties.Resources.scheduled_tasks_3_128x128;
            // sql panel
            this.userPanels[this.llSqlConfig.Name] = this.sqlP;
            this.leftSideImages[this.llSqlConfig.Name] = global::ScheDEX.Properties.Resources.new_database_128x128;
            // ftp panel
            this.userPanels[this.llFtpConfig.Name] = this.ftpP;
            this.leftSideImages[this.llFtpConfig.Name] = global::ScheDEX.Properties.Resources.location_ftp_128x128;
            // service panel
            this.userPanels[this.llServiceConfig.Name] = this.serviceP;
            this.leftSideImages[this.llServiceConfig.Name] = global::ScheDEX.Properties.Resources.kservices_128x128;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {



            // Interval
            //UNDO//this.tbInterval.Text = this.settings.Interval.ToString();

            // Events
            //UNDO//this.lbScheduleEvents.Items.AddRange(this.events.ToArray());
        }
        
        public void ProcessScan()
        {
            this.statusBarLabel.Text = "Szukam instancji MSSQL...";
            
            this.sqlP.ProcessScan();
        }

        private void service_FindingEvent(object sender, ServiceEventArgs args)
        {
            if (args.IsSuccess)
            {
                //this.notifyIcon1.InvokeIfRequired(() =>
                //{
                    this.notifyIcon1.Text += "\nUsługa pracuje prawidłowo.";
                //});
            }
            else
            {
                //this.notifyIcon1.InvokeIfRequired(() =>
                //{
                    this.notifyIcon1.Text += "\nUsługa nie pracuje.";
                //});
            }
        }

        private void sql_ServerNamesHasBeenFetched(object sender, EventArgs args)
        {
            //this.statusBarLabel.InvokeIfRequired(() =>
            //{
                this.statusBarLabel.Text = "";
            //});
        }

        private void sql_ConnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            //this.statusBarLabel.InvokeIfRequired(() =>
            //{
                this.statusBarLabel.Text = "";
            //});
        }

        private void sql_DisconnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            //this.statusBarLabel.InvokeIfRequired(() =>
            //{
                this.statusBarLabel.Text = "";
            //});
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



        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.settings.Save();
            Console.WriteLine("Serialzuje obiekt do pliku");

            //this.notifyIcon1.BalloonTipText = "hello";
            this.notifyIcon1.ShowBalloonTip(3000, "Title1", "Text", ToolTipIcon.Info);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1.Icon = ((System.Drawing.Icon)resources.GetObject("alarmClock.Icon"));

            //this.pictureBox1.Hide();
        }





        private void tbInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //UNDO//this.settings.Interval = uint.Parse(this.tbInterval.Text);
                this.settings.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Należy podać cyfry.\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void bSaveScheduleEvent_Click(object sender, EventArgs e)
        {
            // TODO: check if all data are available and valid
            ScheduleEvent schEv = new ScheduleEvent();

            // SQL
            if (!this.sql.ConnectionString.ConnectionString.Equals("")) // check if is connected ???
                schEv.SQLConnectionString = this.sql.ConnectionString.ConnectionString;

            //UNDO//if (this.lbTables.SelectedIndex >= 0)
            //UNDO//    schEv.SQLTable = this.lbTables.SelectedItem.ToString();

            // FTP
            //UNDO//if (!this.tbFTPAdress.Text.Equals(""))
            //UNDO//    schEv.FTPAddress = this.tbFTPAdress.Text;

            //UNDO//if (!this.tbFTPUserName.Text.Equals(""))
            //UNDO//    schEv.FTPLogin = this.tbFTPUserName.Text;

            //UNDO//if (!this.tbFTPUserPass.Text.Equals(""))
            //UNDO//    schEv.FTPPassword = this.tbFTPUserPass.Text;

            //UNDO//if (!this.tbFTPRemotePath.Text.Equals(""))
            //UNDO//    schEv.FTPRemotePath = this.tbFTPRemotePath.Text;

            //if(this.ftp.IsValid)

            //UNDO//schEv.Interval = uint.Parse(this.tbInterval.Text);

            //UNDO//schEv.XMLFileName = this.tbXMLFileName.Text;

            /*
             * Check if any schedule event is ...
             */
            //UNDO//if (this.lbScheduleEvents.SelectedIndex < 0)
            //UNDO//{
                /*
                 * ... not selected, then create new one
                 */
            //UNDO//    lbScheduleEvents.Items.Add(schEv);
            //UNDO//    this.events.Add(schEv);
            //UNDO//    this.events.Save();
            //UNDO//}
            //UNDO//else
            //UNDO//{
                /*
                 * ... slected then, update it
                 */
            //UNDO//    int index = lbScheduleEvents.SelectedIndex;
            //UNDO//    lbScheduleEvents.Items[index] = schEv;
            //UNDO//    this.events[index] = schEv;
            //UNDO//    this.events.Save();
            //UNDO//}

            
            Console.WriteLine(schEv.ToString());
        }

        private void lbScheduleEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UNDO//if (this.lbScheduleEvents.SelectedIndex < 0)
            //UNDO//    return;

            //UNDO//ScheduleEvent schedEvent = (ScheduleEvent)this.lbScheduleEvents.SelectedItem;
            //UNDO//SQLConnectionString sqlConnString = new SQLConnectionString();
            //UNDO//sqlConnString.ConnectionString = schedEvent.SQLConnectionString;
            //UNDO//if (this.cbServerNames.Items.Contains(sqlConnString.Server))
            //UNDO//{
            //UNDO//    this.cbServerNames.Text = sqlConnString.Server;
            //UNDO//}
            //UNDO//else
            //UNDO//{
                DialogResult result = MessageBox.Show(
                    "Nie ma takiej bazy na liście.\n\nCzy chcesz usnąć to zdarzenie z listy?",
                    "Ostrzeżenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    //UNDO//object toDelete = lbScheduleEvents.SelectedItem;
                    //UNDO//lbScheduleEvents.Items.Remove(toDelete);
                    //UNDO//this.events.Remove(toDelete);
                    this.events.Save();
                }
            //UNDO//}
        }

        private void lbScheduleEvents_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Leaved");
        }

        private void bRemoveScheduleEvent_Click(object sender, EventArgs e)
        {
            //UNDO//object toDelete = lbScheduleEvents.SelectedItem;
            //UNDO//this.events.Remove(toDelete);
            //UNDO//lbScheduleEvents.Items.Remove(toDelete);
            this.events.Save();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String key = ((LinkLabel)sender).Name;
            
            foreach(var pair in this.userPanels)
            {
                ((LinkLabel)this.panelLinks.Controls[pair.Key]).Font = RegularFont;

                pair.Value.Hide();
                pair.Value.Enabled = false;
            }

            ((LinkLabel)this.panelLinks.Controls[key]).Font = BoldFont;

            this.userPanels[key].Show();
            this.userPanels[key].Enabled = true;

            this.pLeftSideImage.BackgroundImage = this.leftSideImages[key];
        }
    }
}
