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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            
        private static readonly Font RegularFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        private static readonly Font BoldFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

        private EventsPanel eventsP;
        private FtpPanel ftpP;
        private ServicePanel serviceP;
        private SqlPanel sqlP;

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
             * Store settings
             */
            //this.settings.Save();

            InitializeComponent();
            InitializeMyComponent();
            this.Closing += new CancelEventHandler(this.FormMain_Closing);
        }

        private void InitializeMyComponent()
        {
            this.eventsP = new ITSharp.ScheDEX.EventsPanel(this);
            this.sqlP = new ITSharp.ScheDEX.SqlPanel(this);
            this.ftpP = new ITSharp.ScheDEX.FtpPanel(this);
            this.serviceP = new ITSharp.ScheDEX.ServicePanel(this);

            // 
            // eventsP
            // 
            this.eventsP.BackColor = System.Drawing.Color.White;
            this.eventsP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eventsP.Location = new System.Drawing.Point(0, 0);
            this.eventsP.Name = "eventsP";
            this.eventsP.Size = new System.Drawing.Size(485, 519);
            this.eventsP.TabIndex = 3;
            // 
            // sqlP
            // 
            this.sqlP.BackColor = System.Drawing.Color.White;
            this.sqlP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sqlP.Location = new System.Drawing.Point(0, 0);
            this.sqlP.Name = "sqlP";
            this.sqlP.Size = new System.Drawing.Size(485, 519);
            this.sqlP.TabIndex = 6;
            // 
            // ftpP
            // 
            this.ftpP.BackColor = System.Drawing.Color.White;
            this.ftpP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftpP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ftpP.Location = new System.Drawing.Point(0, 0);
            this.ftpP.Name = "ftpP";
            this.ftpP.Size = new System.Drawing.Size(485, 519);
            this.ftpP.TabIndex = 4;
            // 
            // serviceP
            // 
            this.serviceP.BackColor = System.Drawing.Color.White;
            this.serviceP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serviceP.Location = new System.Drawing.Point(0, 0);
            this.serviceP.Name = "serviceP";
            this.serviceP.Size = new System.Drawing.Size(485, 519);
            this.serviceP.TabIndex = 5;

            this.splitContainer.Panel2.Controls.Add(this.eventsP);
            this.splitContainer.Panel2.Controls.Add(this.sqlP);
            this.splitContainer.Panel2.Controls.Add(this.ftpP);
            this.splitContainer.Panel2.Controls.Add(this.serviceP);

            /*
             * Initialize events related issues
             */


            /*
             * Initialize SQL connection related issues
             */
            //this.sql.ConnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_ConnectionEvent);
            //this.sql.DisconnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_DisconnectionEvent);
            //this.sql.ServerNamesHasBeenFetched += new EventHandler(sql_ServerNamesHasBeenFetched);

            /*
             * Initialize FTP related issues
             */


            /*
             * Service controler related issues
             */
            this.service.ServiceStatusChangedEvent += new EventHandler<ServiceStatusEventArgs>(service_ServiceStatusEventArgs);

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
            //this.statusBarLabel.Text = "Szukam instancji MSSQL...";

            this.sqlP.ProcessScan();
        }

        private void service_ServiceStatusEventArgs(object sender, ServiceStatusEventArgs args)
        {
            if (args.IsWorking)
            {
                this.notifyIcon1.Text = "ScheDEX\nUsługa pracuje prawidłowo.";
                //this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("28461-ico-alarm-clock-icon.ico")));
            }
            else
            {
                this.notifyIcon1.Text = "ScheDEX\nUsługa nie pracuje.";
                //this.notifyIcon1.Icon = global::ScheDEX.Properties.Resources.
            }
        }

        //private void sql_ServerNamesHasBeenFetched(object sender, EventArgs args)
        //{
        //    //this.statusBarLabel.InvokeIfRequired(() =>
        //    //{
        //        this.statusBarLabel.Text = "";
        //    //});
        //}

        //private void sql_ConnectionEvent(object sender, SQLConnectionEventArgs args)
        //{
        //    //this.statusBarLabel.InvokeIfRequired(() =>
        //    //{
        //        this.statusBarLabel.Text = "";
        //    //});
        //}

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

        //private void buttonSave_Click(object sender, EventArgs e)
        //{
        //    this.settings.Save();
        //    Console.WriteLine("Serialzuje obiekt do pliku");

        //    //this.notifyIcon1.BalloonTipText = "hello";
        //    this.notifyIcon1.ShowBalloonTip(3000, "Title1", "Text", ToolTipIcon.Info);

        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        //    this.notifyIcon1.Icon = ((System.Drawing.Icon)resources.GetObject("alarmClock.Icon"));

        //    //this.pictureBox1.Hide();
        //}

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String key = ((LinkLabel)sender).Name;

            foreach (var pair in this.userPanels)
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
