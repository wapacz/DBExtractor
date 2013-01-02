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

using ITSharp.DBExtractor.Common;
using ITSharp.DBExtractor.GUI;
using System.Security.AccessControl;

namespace ITSharp.DBExtractor
{
    public partial class FormMain : Form
    {
        private static readonly string WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "DBExtractor");
        private static readonly string SettingsFilePath = Path.Combine(WorkingDirectory, "settings.bin");
        private static readonly string EventsFilePath = Path.Combine(WorkingDirectory, "events.bin");
        private DBExtractorSettings settings;
        private ScheduleEventList events;

        private SQLConnectionHelper sql;
        private FTPHelper ftp;

        public FormMain()
        {
            InitializeComponent();
            InitializeMyComponent();
            this.Closing += new CancelEventHandler(this.FormMain_Closing);
        }

        private void InitializeMyComponent()
        {
            /*
             * Loading settings from file if available
             */
            if (!Directory.Exists(WorkingDirectory))
                Directory.CreateDirectory(WorkingDirectory);
            this.settings = DBExtractorSettings.Load(SettingsFilePath);
            this.events = ScheduleEventList.Load(EventsFilePath);
            //else
            //    this.settings = new DBExtractorSettings(FileName);

            /*
             * Initialize SQL connection helper
             */
            this.sql = new SQLConnectionHelper();
            this.sql.ConnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_ConnectionEvent);
            this.sql.DisconnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_DisconnectionEvent);
            this.sql.ServerNamesHasBeenFetched += new EventHandler(sql_ServerNamesHasBeenFetched);
            this.sql.DatabasesHasBeenFetched += new EventHandler(sql_DatabasesHasBeenFetched);
            this.sql.TablesHasBeenFetched += new EventHandler(sql_TablesHasBeenFetched);

            /*
             * Initialize FTP helper
             */
            this.ftp = new FTPHelper();
            this.ftp.ConnectionEvent += new EventHandler<FTPConnectionEventArgs>(ftp_ConnectionEvent);

            /*
             * Service controler handler
             */
            // TODO: Service handler goes here

            /*
             * Store settings
             */
            //this.settings.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            /*
             * Fetching related service handler
             */
            try
            {
                ServiceHelper sh = new ServiceHelper("DBExtractorService");
                this.notifyIcon1.Text += "\nService found";
                this.lServiceStatus.Text = "Usługa pracuje prawidłowo.";
            }
            catch (ServiceNotFoundException)
            {
                Console.WriteLine("blad");
                this.notifyIcon1.Text += "\nService not found";
                this.lServiceStatus.Text = "Usługa nie pracuje.";
            }


            // FTP
            this.tbFTPAdress.Text = this.settings.FtpAddress;
            this.tbFTPUserName.Text = this.settings.FtpUserName;
            this.tbFTPUserPass.Text = this.settings.FtpUserPassword;
            this.tbFTPRemotePath.Text = this.settings.FtpRemotePath;

            // Interval
            this.tbInterval.Text = this.settings.Interval.ToString();

            // Events
            this.lbScheduleEvents.Items.AddRange(this.events.ToArray());
        }

        #region SQL helper methods
        /*
         * SQL helper event methods
         */
        private void sql_ServerNamesHasBeenFetched(object sender, EventArgs args)
        {
            this.cbServerNames.InvokeIfRequired(() =>
            {
                this.pbServerNamesLoader.Hide();

                this.cbServerNames.Enabled = true;
                this.cbServerNames.Items.AddRange(((SQLConnectionHelper)sender).ServerNames.ToArray());
                this.cbServerNames.Text = ((SQLConnectionHelper)sender).DefaultServerName;

                this.lAuth.Enabled = true;
                this.rbAuthWindows.Enabled = true;
                this.rbAuthSQLServer.Enabled = true;

                this.bSQLConnect.Enabled = true;

                this.statusBarLabel.Text = "";
            });
        }

        private void sql_ConnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            Console.WriteLine("Poszło3");


            this.bSQLConnect.InvokeIfRequired(() =>
                {
                    this.bSQLConnect.Enabled = true;
                    this.pbConnecting.Hide();
                    this.statusBarLabel.Text = "";
                });

            if (args.IsSuccess)
            {
                Console.WriteLine("Poszło4");

                this.pDBData.InvokeIfRequired(() =>
                    {
                        this.pDBData.Show();
                        this.pDBConnection.Hide();
                    });

                /*
                 * Check if key is alrady in connection strings dicionary...
                 */
                if (this.settings.SqlConnectionStrings.ContainsKey(this.sql.ConnectionString.Server))
                {
                    /*
                     * ... if so, then update it
                     */
                    this.settings.SqlConnectionStrings[this.sql.ConnectionString.Server] =
                        this.sql.ConnectionString.ConnectionString;
                }
                else
                {
                    /*
                     * ... if not, then create it
                     */
                    this.settings.SqlConnectionStrings.Add(
                        this.sql.ConnectionString.Server,
                        this.sql.ConnectionString.ConnectionString
                        );
                }
                this.settings.Save();

                this.statusBarLabel.Text = "Szukam baz danych...";
                this.sql.StartScanDatabases();
            }
            else
            {
                this.pDBData.InvokeIfRequired(() =>
                {
                    this.pDBConnection.Show();
                    this.pDBData.Hide();
                });

                /*
                 * Check if key is alrady in connection strings dicionary...
                 */
                if (this.settings.SqlConnectionStrings.ContainsKey(this.sql.ConnectionString.Server))
                {
                    /*
                     * ... if so, then remove it, because it is not working correctly
                     */
                    this.settings.SqlConnectionStrings.Remove(this.sql.ConnectionString.Server);
                }

                Console.WriteLine("Poszło5");
                MessageBox.Show("Wystapił błąd podczas połączenia z bazą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine("Poszło6");
            }
        }

        private void sql_DisconnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            this.cbDatabases.InvokeIfRequired(() =>
            {
                this.lbTables.Items.Clear();
                this.cbDatabases.Items.Clear();
                this.cbDatabases.Text = "";
                //TODO: ...
                this.statusBarLabel.Text = "";
            });
        }

        private void sql_DatabasesHasBeenFetched(object sender, EventArgs args)
        {
            this.cbDatabases.InvokeIfRequired(() =>
            {
                this.pbDatabasesLoader.Hide();
                this.cbDatabases.Enabled = true;
                this.cbDatabases.Items.AddRange(((SQLConnectionHelper)sender).Databases.ToArray());
                this.cbDatabases.Text = ((SQLConnectionHelper)sender).DefaultDatabase;

                this.statusBarLabel.Text = "";
            });
        }
        #endregion

        public void ProcessScan()
        {
            this.statusBarLabel.Text = "Szukam instancji MSSQL...";
            this.pbServerNamesLoader.Show();
            this.cbServerNames.Items.Clear();
            this.cbServerNames.Enabled = false;

            this.lAuth.Enabled = false;
            this.rbAuthWindows.Enabled = false;
            this.rbAuthSQLServer.Enabled = false;

            this.bSQLConnect.Enabled = false;

            this.sql.StartScanServerNames();
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

        private void cbServerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlConnString;

            if (this.sql.IsConnected)
                this.sql.Dissconnect();


            if (this.settings.SqlConnectionStrings.TryGetValue(this.cbServerNames.Text, out sqlConnString))
            {
                /*
                 * If settings for this connetion string are known then try to make shortcut
                 */
                this.pDBData.Show();
                this.pDBConnection.Hide();

                this.sql.ConnectionString.ConnectionString = sqlConnString;






                this.statusBarLabel.Text = "Próba połączenia z bazą...";
                //this.pbDatabasesLoader.Show();
                //this.cbDatabases.Items.Clear();
                //this.cbDatabases.Enabled = false;

                //this.mssql.StartScanDatabases();

                this.bSQLConnect.Enabled = false;
                this.pbConnecting.Show();

                this.sql.StartConnect();
            }
            else
            {
                /*
                 * If settings for this connection string are not know then go in the normal way
                 */
                this.pDBConnection.Show();
                this.pDBData.Hide();

                this.sql.ConnectionString.Server = this.cbServerNames.Text;
                //this.settings.Save();
            }
        }

        private void rbAuthSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            this.lUserName.Enabled = true;
            this.lUserPass.Enabled = true;
            this.tbSQLUserName.Enabled = true;
            this.tbSQLUserPass.Enabled = true;

            this.sql.ConnectionString.Authentication = false;
            this.settings.Save();
        }

        private void rbAuthWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.lUserName.Enabled = false;
            this.lUserPass.Enabled = false;
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserPass.Enabled = false;

            this.sql.ConnectionString.Authentication = true;
            this.settings.Save();
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if (this.rbAuthSQLServer.Checked)
            //if(!this.settings.sql.ConnectionString.Authentication)
            {
                if (this.tbSQLUserName.Text.Equals("") || this.tbSQLUserPass.Text.Equals(""))
                {
                    MessageBox.Show("Ta metoda uwieżytelniania wymaga podania nazwy użytkownika i hasła", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.sql.ConnectionString.UserID = this.tbSQLUserName.Text;
                this.sql.ConnectionString.Password = this.tbSQLUserPass.Text;
            }

            this.statusBarLabel.Text = "Próba połączenia z bazą...";
            //this.pbDatabasesLoader.Show();
            //this.cbDatabases.Items.Clear();
            //this.cbDatabases.Enabled = false;

            //this.mssql.StartScanDatabases();

            this.bSQLConnect.Enabled = false;
            this.pbConnecting.Show();

            this.sql.StartConnect();
        }


        private void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbTables.Items.Clear();
            this.sql.Connection.ChangeDatabase(this.cbDatabases.Text);
            this.sql.ConnectionString.Database = this.cbDatabases.Text;
            this.sql.StartScanTables();
        }

        private void sql_TablesHasBeenFetched(object sender, EventArgs args)
        {
            this.lbTables.InvokeIfRequired(() =>
            {
                ((SQLConnectionHelper)sender).Tables.Sort();
                this.lbTables.Items.AddRange(((SQLConnectionHelper)sender).Tables.ToArray());
            });
        }

        #region FTP helper methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bFTPConnect_Click(object sender, EventArgs e)
        {
            this.ftp.Address = this.tbFTPAdress.Text;
            this.ftp.Login = this.tbFTPUserName.Text;
            this.ftp.Password = this.tbFTPUserPass.Text;
            //this.ftp.RemotePath = this.tbFTPRemotePath.Text;

            this.bFTPConnectTest.Enabled = false;
            this.pbFTPConnectTest.Show();

            this.ftp.StartCheckConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ftp_ConnectionEvent(object sender, FTPConnectionEventArgs args)
        {
            this.bFTPConnectTest.InvokeIfRequired(() =>
                {
                    this.bFTPConnectTest.Enabled = true;
                    this.pbFTPConnectTest.Hide();
                });

            if (args.IsSuccess)
            {
                this.settings.FtpAddress = this.ftp.Address;
                this.settings.FtpUserName = this.ftp.Login;
                this.settings.FtpUserPassword = this.ftp.Password;
                this.settings.FtpRemotePath = this.tbFTPRemotePath.Text; //this.ftp.RemotePath;
                this.settings.Save();

                MessageBox.Show("Połączenie z serwerem FTP działa poprawnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie udało się połączyć z FTPem\n\nSzczegóły: " + sender.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void tbInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.settings.Interval = uint.Parse(this.tbInterval.Text);
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

            if (this.lbTables.SelectedIndex >= 0)
                schEv.SQLTable = this.lbTables.SelectedItem.ToString();

            // FTP
            if (!this.tbFTPAdress.Text.Equals(""))
                schEv.FTPAddress = this.tbFTPAdress.Text;

            if (!this.tbFTPUserName.Text.Equals(""))
                schEv.FTPLogin = this.tbFTPUserName.Text;

            if (!this.tbFTPUserPass.Text.Equals(""))
                schEv.FTPPassword = this.tbFTPUserPass.Text;

            if (!this.tbFTPRemotePath.Text.Equals(""))
                schEv.FTPRemotePath = this.tbFTPRemotePath.Text;

            //if(this.ftp.IsValid)

            schEv.Interval = uint.Parse(this.tbInterval.Text);

            schEv.XMLFileName = this.tbXMLFileName.Text;

            /*
             * Check if any schedule event is ...
             */
            if (this.lbScheduleEvents.SelectedIndex < 0)
            {
                /*
                 * ... not selected, then create new one
                 */
                lbScheduleEvents.Items.Add(schEv);
                this.events.Add(schEv);
                this.events.Save();
            }
            else
            {
                /*
                 * ... slected then, update it
                 */
                int index = lbScheduleEvents.SelectedIndex;
                lbScheduleEvents.Items[index] = schEv;
                this.events[index] = schEv;
                this.events.Save();
            }

            
            Console.WriteLine(schEv.ToString());
        }

        private void lbScheduleEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbScheduleEvents.SelectedIndex < 0)
                return;

            ScheduleEvent schedEvent = (ScheduleEvent)this.lbScheduleEvents.SelectedItem;
            SQLConnectionString sqlConnString = new SQLConnectionString();
            sqlConnString.ConnectionString = schedEvent.SQLConnectionString;
            if (this.cbServerNames.Items.Contains(sqlConnString.Server))
            {
                this.cbServerNames.Text = sqlConnString.Server;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Nie ma takiej bazy na liście.\n\nCzy chcesz usnąć to zdarzenie z listy?",
                    "Ostrzeżenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    object toDelete = lbScheduleEvents.SelectedItem;
                    lbScheduleEvents.Items.Remove(toDelete);
                    this.events.Remove(toDelete);
                    this.events.Save();
                }
            }
        }

        private void lbScheduleEvents_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Leaved");
        }

        private void bRemoveScheduleEvent_Click(object sender, EventArgs e)
        {
            object toDelete = lbScheduleEvents.SelectedItem;
            this.events.Remove(toDelete);
            lbScheduleEvents.Items.Remove(toDelete);
            this.events.Save();
        }
    }
}
