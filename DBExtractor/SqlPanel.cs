using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITSharp.ScheDEX.Common;
using ITSharp.ScheDEX.GUI;

namespace ITSharp.ScheDEX
{
    public partial class SqlPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;
        private SQLConnectionHelper sql;

        public SqlPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            /*
             * Initialize SQL helper
             */
            this.sql = new SQLConnectionHelper();
            this.sql.ConnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_ConnectionEvent);
            this.sql.DisconnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_DisconnectionEvent);
            this.sql.ServerNamesHasBeenFetched += new EventHandler(sql_ServerNamesHasBeenFetched);
            this.sql.DatabasesHasBeenFetched += new EventHandler(sql_DatabasesHasBeenFetched);
        }

        private void SqlPanel_Load(object sender, EventArgs e)
        {

        }

        public void ProcessScan()
        {
            this.pbServerNamesLoader.Show();
            this.cbServerNames.Items.Clear();
            this.cbServerNames.Enabled = false;

            this.lAuth.Enabled = false;
            this.rbAuthWindows.Enabled = false;
            this.rbAuthSQLServer.Enabled = false;

            this.bSQLConnect.Enabled = false;

            this.sql.StartScanServerNames();
        }

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
            });
        }

        private void sql_ConnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            this.bSQLConnect.InvokeIfRequired(() =>
                {
                    this.bSQLConnect.Enabled = true;
                    this.pbConnecting.Hide();
                });

            if (args.IsSuccess)
            {
                //this.pDBData.InvokeIfRequired(() =>
                //    {
                //        this.pDBData.Show();
                //        this.pDBConnection.Hide();
                //    });

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

                this.sql.StartScanDatabases();
            }
            else
            {
                //this.pDBData.InvokeIfRequired(() =>
                //{
                //    this.pDBConnection.Show();
                //    this.pDBData.Hide();
                //});

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

                MessageBox.Show("Wystapił błąd podczas połączenia z bazą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sql_DisconnectionEvent(object sender, SQLConnectionEventArgs args)
        {
            this.cbDatabases.InvokeIfRequired(() =>
                {
                    this.cbDatabases.Items.Clear();
                    this.cbDatabases.Text = "";
                    //TODO: ...
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
                });
        }

        private void cbServerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlConnString;

            if (this.sql.IsConnected)
                this.sql.Dissconnect();


            //UNDO//if (this.settings.SqlConnectionStrings.TryGetValue(this.cbServerNames.Text, out sqlConnString))
            //UNDO//{
            //UNDO//    /*
            //UNDO//     * If settings for this connetion string are known then try to make shortcut
            //UNDO//     */
            //UNDO//    this.pDBData.Show();
            //UNDO//    this.pDBConnection.Hide();

            //UNDO//this.sql.ConnectionString.ConnectionString = sqlConnString;






            ///////////////this.statusBarLabel.Text = "Próba połączenia z bazą...";

            //this.pbDatabasesLoader.Show();
            //this.cbDatabases.Items.Clear();
            //this.cbDatabases.Enabled = false;

            //this.mssql.StartScanDatabases();

            //UNDO//this.bSQLConnect.Enabled = false;
            //UNDO//this.pbConnecting.Show();

            this.sql.StartConnect();
            //UNDO//}
            //UNDO//else
            //UNDO//{
            /*
             * If settings for this connection string are not know then go in the normal way
             */
            //UNDO//this.pDBConnection.Show();
            //UNDO//this.pDBData.Hide();

            //UNDO//this.sql.ConnectionString.Server = this.cbServerNames.Text;
            //this.settings.Save();
            //UNDO//}
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

        private void bSQLConnect_Click(object sender, EventArgs e)
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

            //////////////////////this.statusBarLabel.Text = "Próba połączenia z bazą...";
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
            //this.lbTables.Items.Clear();
            this.sql.Connection.ChangeDatabase(this.cbDatabases.Text);
            this.sql.ConnectionString.Database = this.cbDatabases.Text;
            //this.sql.StartScanTables();
        }

        public FormMain ContainerForm
        {
            set
            {
                this.container = value;
                this.settings = value.settings;
                value.sql = this.sql;
            }
        }

        public SQLConnectionHelper Sql
        {
            get
            {
                return this.sql;
            }
        }
    }
}
