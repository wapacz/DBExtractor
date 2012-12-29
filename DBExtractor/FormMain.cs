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
using System.Collections;
using System.Data.Sql;
using System.Threading;

using ITSharp.Helpers;

namespace DBExtractor
{
    public partial class FormMain : Form
    {
        const string FileName = @"settings.bin";
        DBExtractorSettings settings;

        MSSQLHelper mssql;
        FTPHelper ftp;

        public FormMain()
        {
            this.mssql = new MSSQLHelper();
            this.mssql.ConnectionEvent += new EventHandler(mssql_ConnectionEvent);
            this.mssql.DisconnectionEvent += new EventHandler(mssql_DisconnectionEvent);
            this.mssql.ServerNamesHasBeenFetched += new EventHandler(mssql_ServerNamesHasBeenFetched);
            this.mssql.DatabasesHasBeenFetched += new EventHandler(mssql_DatabasesHasBeenFetched);
            this.mssql.TablesHasBeenFetched += new EventHandler(mssql_TablesHasBeenFetched);

            this.ftp = new FTPHelper();
            this.ftp.ConnectionSuccessful += new EventHandler(ftp_ConnectionSuccessful);
            this.ftp.ConnectionUnsuccessful += new EventHandler(ftp_ConnectionUnsuccessful);

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

        private void mssql_ServerNamesHasBeenFetched(object sender, EventArgs args)
        {
            this.cbServerNames.InvokeIfRequired(() =>
            {
                this.pbServerNamesLoader.Hide();
            
                this.cbServerNames.Enabled = true;
                this.cbServerNames.Items.AddRange(((MSSQLHelper)sender).ServerNames.ToArray());
                this.cbServerNames.Text = ((MSSQLHelper)sender).DefaultServerName;

                this.lAuth.Enabled = true;
                this.rbAuthWindows.Enabled = true;
                this.rbAuthSQLServer.Enabled = true;

                this.bSQLConnect.Enabled = true;

                this.statusBarLabel.Text = "";
            });
        }

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

            this.mssql.StartScanServerNames();
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
                //label1.Text = "Checking...";
                ServiceHelper sh = new ServiceHelper("DBExtractorService");
                this.notifyIcon1.Text += "\nService found";
            }
            catch (ServiceNotFoundException)
            {
                Console.WriteLine("blad");
                this.notifyIcon1.Text += "\nService not found";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Stream fileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, this.settings);
            fileStream.Close();
            Console.WriteLine("Serialzuje obiekt do pliku");

            //this.notifyIcon1.BalloonTipText = "hello";
            this.notifyIcon1.ShowBalloonTip(3000, "Title1", "Text", ToolTipIcon.Info);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1.Icon = ((System.Drawing.Icon)resources.GetObject("alarmClock.Icon"));

            //this.pictureBox1.Hide();
        }

        private void cbServerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mssql.IsConnected)
                this.mssql.Dissconnect();

            this.mssql.ConnectionString.Server = this.cbServerNames.Text;
        }

        private void rbAuthSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            this.mssql.ConnectionString.Authentication = false;

            this.lUserName.Enabled = true;
            this.lUserPass.Enabled = true;
            this.tbSQLUserName.Enabled = true;
            this.tbSQLUserPass.Enabled = true;
        }

        private void rbAuthWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.mssql.ConnectionString.Authentication = true;

            this.lUserName.Enabled = false;
            this.lUserPass.Enabled = false;
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserPass.Enabled = false;
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            //if (this.rbAuthSQLServer.Checked)
            if(!this.mssql.ConnectionString.Authentication)
            {
                if (this.tbSQLUserName.Text.Equals("") || this.tbSQLUserPass.Text.Equals(""))
                {
                    MessageBox.Show("Ta metoda uwieżytelniania wymaga podania nazwy użytkownika i hasła", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.mssql.ConnectionString.UserID = this.tbSQLUserName.Text;
                this.mssql.ConnectionString.Password = this.tbSQLUserPass.Text;
            }

            this.statusBarLabel.Text = "Próba połączenia z bazą...";
            //this.pbDatabasesLoader.Show();
            //this.cbDatabases.Items.Clear();
            //this.cbDatabases.Enabled = false;

            //this.mssql.StartScanDatabases();

            this.bSQLConnect.Enabled = false;
            this.pbConnecting.Show();

            this.mssql.StartConnect();
        }


        private void mssql_ConnectionEvent(object sender, EventArgs args)
        {
            this.bSQLConnect.InvokeIfRequired(() =>
            {
                this.bSQLConnect.Enabled = true;
                this.pbConnecting.Hide();
                this.statusBarLabel.Text = "";
            }); 
            
            if (((MSSQLHelper)sender).IsConnected)
            {
                this.statusBarLabel.Text = "Szukam baz danych...";
                this.mssql.StartScanDatabases();
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas połączenia z bazą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mssql_DisconnectionEvent(object sender, EventArgs args)
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

        private void mssql_DatabasesHasBeenFetched(object sender, EventArgs args)
        {
            this.cbDatabases.InvokeIfRequired(() =>
            {
                this.pbDatabasesLoader.Hide();
                this.cbDatabases.Enabled = true;
                this.cbDatabases.Items.AddRange(((MSSQLHelper)sender).Databases.ToArray());
                this.cbDatabases.Text = ((MSSQLHelper)sender).DefaultDatabase;

                this.statusBarLabel.Text = "";
            });
        }

        private void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbTables.Items.Clear();
            this.mssql.Connection.ChangeDatabase(this.cbDatabases.Text);
            this.mssql.StartScanTables();
        }

        private void mssql_TablesHasBeenFetched(object sender, EventArgs args)
        {
            this.lbTables.InvokeIfRequired(() =>
            {
                this.lbTables.Items.AddRange(((MSSQLHelper)sender).Tables.ToArray());
            });
        }

        private void bFTPConnect_Click(object sender, EventArgs e)
        {
            this.ftp.Address = this.tbFTPAdress.Text;
            this.ftp.Login = this.tbFTPUserName.Text;
            this.ftp.Password = this.tbFTPUserPass.Text;

            this.bFTPConnectTest.Enabled = false;
            this.pbFTPConnectTest.Show();

            this.ftp.StartConnect();

            //ITSharp.Helpers.FTP.Client ftp = new ITSharp.Helpers.FTP.Client(@"ftp://itsharp.pl", @"bartoszulman@itsharp.pl", @"bUl!b2012");
            
            //FTPHelper ftp = new FTPHelper();
            //ftp.Address = @"ftp://itsharp.pl";
            //ftp.Login = @"bartoszulman@itsharp.pl";
            //ftp.Password = @"bUl!b2012";
            //label1.Text = "";

            //foreach(String file in ftp.ListDirectory())
            //{
                //label1.Text += ">>>"+file;

            //}
        }

        private void ftp_ConnectionSuccessful(object sender, EventArgs args)
        {
            this.bFTPConnectTest.InvokeIfRequired(() =>
                {
                    this.bFTPConnectTest.Enabled = true;
                    this.pbFTPConnectTest.Hide();
                });

            MessageBox.Show("Udało się połączyć z FTPem");
        }

        private void ftp_ConnectionUnsuccessful(object sender, EventArgs args)
        {
            this.bFTPConnectTest.InvokeIfRequired(() =>
                {
                    this.bFTPConnectTest.Enabled = true;
                    this.pbFTPConnectTest.Hide();
                });

            MessageBox.Show("Nie udało się połączyć z FTPem\n\n" +sender.ToString());
        }
    }
}
