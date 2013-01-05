using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITSharp.ScheDEX.Common;
using System.Collections;

namespace ITSharp.ScheDEX
{
    public partial class EventsPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;

        public EventsPanel(FormMain container)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.container = container;
            this.settings = container.settings;
        }

        private void buttonSaveAndRun_Click(object sender, EventArgs e)
        {
            this.container.events.Save();
            this.container.service.ExecuteCommand(250); // refresh events 
        }

        private void EventsPanel_Load(object sender, EventArgs e)
        {
            /*
             * SQL connections
             */
            this.cbDBConnections.Items.Clear();
            foreach (var pair in this.settings.SqlConnectionStrings)
            {
                this.cbDBConnections.Items.Add(pair.Key);
            }
            this.cbDBConnections.Text = this.settings.SqlConnectionKey;

            /*
             * Query
             */
            this.cbQuery.Items.Clear();
            foreach (var pair in this.container.sql.Queries)
            {
                this.cbQuery.Items.Add(pair.Key);
            }
            this.cbQuery.Text = this.settings.SqlQueryName;

            /*
             * FTP server
             */
            this.tbFtp.Text = this.settings.FtpAddress;

            /*
             * Interval
             */
            this.tbInterval.Text = this.settings.Interval.ToString();

            /*
             * File
             */
            this.tbXMLFileName.Text = this.settings.XmlFileName;

            /*
             * Events list
             */
            this.lbScheduleEvents.Items.Clear();
            foreach (ScheduleEvent schedEvent in this.container.events)
                this.lbScheduleEvents.Items.Add(schedEvent);
        }

        private void EventsPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.EventsPanel_Load(sender, e);
        }
        
        private void bSaveScheduleEvent_Click(object sender, EventArgs e)
        {
            ScheduleEvent schEv = new ScheduleEvent();

            // SQL
            if (this.cbDBConnections.Text.Equals(""))
            {
                MessageBox.Show("Należy wybrać połączenie z bazą danych.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            schEv.SQLConnectionString = this.settings.SqlConnectionStrings[this.cbDBConnections.Text];

            // Query
            if (this.cbQuery.Text.Equals(""))
            {
                MessageBox.Show("Należy wybrać kwerendę.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            schEv.SQLQuery = this.container.sql.Queries[this.cbQuery.Text];
            schEv.SQLQueryName = this.cbQuery.Text;

            // FTP
            if (this.tbFtp.Text.Equals(""))
            {
                MessageBox.Show("Należy skonfigurować połaczenie FTP.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            schEv.FTPAddress = this.tbFtp.Text;
            schEv.FTPLogin = this.settings.FtpUserName; //container.ftp.Login;
            schEv.FTPPassword = this.settings.FtpUserPassword; //this.container.ftp.Password;
            //schEv.FTPRemotePath = this.container.ftp.

            // Interval
            try
            {
                schEv.Interval = uint.Parse(this.tbInterval.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Interwał musi być liczbą.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // XML file name
            if (this.tbXMLFileName.Text.Equals("") || !this.tbXMLFileName.Text.EndsWith(".xml") || this.tbXMLFileName.Text.Length <= 4)
            {
                MessageBox.Show("Należy podać nazwę pliku z rozszerzeniem xml.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            schEv.XMLFileName = this.tbXMLFileName.Text;

            this.settings.SqlConnectionKey = this.cbDBConnections.Text;
            this.settings.SqlQueryName = this.cbQuery.Text;
            this.settings.Interval = uint.Parse(this.tbInterval.Text);
            this.settings.XmlFileName = this.tbXMLFileName.Text;
            this.settings.Save();

            this.lbScheduleEvents.Items.Add(schEv);
            this.container.events.Add(schEv);
            //this.container.events.Save();
        }

        private void bRemoveScheduleEvent_Click(object sender, EventArgs e)
        {
            //lbScheduleEvents.SelectedItems
            foreach (object toDelete in new ArrayList(lbScheduleEvents.SelectedItems))
            {
                this.container.events.Remove(toDelete);
                lbScheduleEvents.Items.Remove(toDelete);
            }
            //this.container.events.Save();
        }
    }
}
