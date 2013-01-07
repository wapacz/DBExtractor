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
using System.Data.SqlClient;

namespace ITSharp.ScheDEX
{
    public partial class SqlPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;
        private SQLConnectionHelper sql;

        public SqlPanel(FormMain container)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.container = container;
            this.settings = container.settings;
            
            /*
             * Initialize SQL helper
             */
            this.sql = new SQLConnectionHelper();
            this.sql.ConnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_ConnectionEvent);
            //this.sql.DisconnectionEvent += new EventHandler<SQLConnectionEventArgs>(sql_DisconnectionEvent);
            this.sql.ServerNamesHasBeenFetched += new EventHandler(sql_ServerNamesHasBeenFetched);
            this.sql.DatabasesHasBeenFetched += new EventHandler(sql_DatabasesHasBeenFetched);

            container.sql = this.sql;
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
                this.sql.StartScanDatabases();
            }
            else
            {
                MessageBox.Show("Wystapił błąd podczas połączenia z bazą.", "Problem podczas połączenia z bazą", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void sql_DisconnectionEvent(object sender, SQLConnectionEventArgs args)
        //{
        //    this.cbDatabases.InvokeIfRequired(() =>
        //        {
        //            this.cbDatabases.Items.Clear();
        //            this.cbDatabases.Text = "";
        //            //TODO: ...
        //        });
        //}

        private void sql_DatabasesHasBeenFetched(object sender, EventArgs args)
        {
            this.cbDatabases.InvokeIfRequired(() =>
                {
                    this.pbDatabasesLoader.Hide();
                    this.lDatabase.Enabled = true;
                    this.bSaveConnection.Enabled = true;
                    this.cbDatabases.Enabled = true;
                    this.cbDatabases.Items.AddRange(((SQLConnectionHelper)sender).Databases.ToArray());
                    this.cbDatabases.Text = ((SQLConnectionHelper)sender).DefaultDatabase;
                });

            this.sql.Disconnect();
        }

        private void cbServerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String sqlConnString;

            if (this.sql.IsConnected)
                this.sql.Disconnect();


            //if (this.settings.SqlConnectionStrings.TryGetValue(this.cbServerNames.Text, out sqlConnString))
            //{
            //    /*
            //     * If settings for this connetion string are known then try to make shortcut
            //     */
            //    this.sql.ConnectionString.ConnectionString = sqlConnString;

            //    this.bSQLConnect.Enabled = false;
            //    this.pbConnecting.Show();

            //    this.sql.StartConnect();
            //}
            //else
            //{
                /*
                 * If settings for this connection string are not know then go in the normal way
                 */
                this.sql.ConnectionString.Server = this.cbServerNames.Text;
                //this.settings.Save();
            //}

                this.cbDatabases.Items.Clear();
                this.cbDatabases.Enabled = false;
                this.lDatabase.Enabled = false;
                this.bSaveConnection.Enabled = false;
        }

        private void rbAuthSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            this.lUserName.Enabled = true;
            this.lUserPass.Enabled = true;
            this.tbSQLUserName.Enabled = true;
            this.tbSQLUserPass.Enabled = true;

            this.sql.ConnectionString.Authentication = false;
            //this.settings.Save();
        }

        private void rbAuthWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.lUserName.Enabled = false;
            this.lUserPass.Enabled = false;
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserPass.Enabled = false;

            this.sql.ConnectionString.Authentication = true;
            //this.settings.Save();
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
                        
            this.cbDatabases.Items.Clear();
            this.cbDatabases.Enabled = false;
            this.lDatabase.Enabled = false;
            this.bSQLConnect.Enabled = false;
            this.pbConnecting.Show();

            this.sql.StartConnect();
            
        }

        private void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.sql.Connection.ChangeDatabase(this.cbDatabases.Text);
            this.sql.ConnectionString.Database = this.cbDatabases.Text;
        }

        public SQLConnectionHelper Sql
        {
            get
            {
                return this.sql;
            }
        }

        private void bSaveConnection_Click(object sender, EventArgs e)
        {
            this.sql.Connect();
                        
            foreach (var pair in this.sql.Queries)
            {
                SqlCommand SqlCom = new SqlCommand();
                SqlCom.Connection = this.sql.Connection;
                SqlCom.CommandType = CommandType.Text;

                SqlCom.CommandText = pair.Value;

                SqlDataReader SqlDR = null;
                try
                {
                    SqlDR = SqlCom.ExecuteReader();
                }
                catch (Exception ex)
                {
                    //this.sql.Connection.Close();
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Wybrana baza danych nie pozwala na odczyt wymaganych danych", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                finally
                {
                    SqlCom.Dispose();
                    if(SqlDR != null)
                        SqlDR.Dispose();
                }
            }

            this.sql.Disconnect();

            string sqlConnKey = String.Format(
                "{0} - {1}", 
                this.sql.ConnectionString.Server, 
                this.sql.ConnectionString.Database
                );

            /*
             * Check if key is already in connection strings dicionary...
             */
            if (this.settings.SqlConnectionStrings.ContainsKey(sqlConnKey))
            {
                /*
                 * ... if so, then update it
                 */
                this.settings.SqlConnectionStrings[sqlConnKey] =
                    this.sql.ConnectionString.ConnectionString;
            }
            else
            {
                /*
                 * ... if not, then create it
                 */
                this.settings.SqlConnectionStrings.Add(
                    sqlConnKey,
                    this.sql.ConnectionString.ConnectionString
                    );

                this.cbAvailableDBs.Items.Add(sqlConnKey);
            }

            this.cbAvailableDBs.Text = sqlConnKey;

            MessageBox.Show("Połączenie zostało zapisane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.settings.Save();
        }

        private void bRemoveDBConn_Click(object sender, EventArgs e)
        {
            if (this.cbAvailableDBs.Text.Equals(""))
            {
                MessageBox.Show("Trzeba wybrać połącznie, aby je skasować.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.settings.SqlConnectionStrings.Remove(this.cbAvailableDBs.Text);
            this.settings.Save();
            this.cbAvailableDBs.Items.Remove(this.cbAvailableDBs.Text);
        }

        private void SqlPanel_Load(object sender, EventArgs e)
        {
            foreach(var pair in this.settings.SqlConnectionStrings)
                this.cbAvailableDBs.Items.Add(pair.Key);
        }
    }
}
