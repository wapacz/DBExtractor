using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using ITSharp.ScheDEX.Common;
using ITSharp.ScheDEX.GUI;

namespace ITSharp.ScheDEX
{
    public partial class FtpPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;
        //private FTPHelper ftp;

        private FTPClient ftpClinet;

        public FtpPanel(FormMain container)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.container = container;
            this.settings = container.settings;
            
            // Set values in forms from settings
            this.tbFTPAdress.Text = this.settings.FtpAddress;
            this.tbFTPUserName.Text = this.settings.FtpUserName;
            this.tbFTPUserPass.Text = this.settings.FtpUserPassword;
            this.tbFTPRemotePath.Text = this.settings.FtpRemotePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bFTPConnectTest_Click(object sender, EventArgs e)
        {
            /*
             * Correct FTP address
             */
            if(this.tbFTPAdress.Text.StartsWith("ftp://"))
                this.tbFTPAdress.Text = this.tbFTPAdress.Text.Substring(6);

            if (   this.tbFTPRemotePath.Text.StartsWith(" ")
                || this.tbFTPRemotePath.Text.StartsWith(".")
                || this.tbFTPRemotePath.Text.StartsWith("/"))
            {
                MessageBox.Show("Ścieżna na serwerze FTP nie może zaczynać się od ' ', '.' ani od '/'", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            /*
             * Lock controls
             */
            this.tbFTPAdress.Enabled = false;
            this.tbFTPUserName.Enabled = false;
            this.tbFTPUserPass.Enabled = false;
            this.tbFTPRemotePath.Enabled = false;

            this.bFTPConnectTest.Enabled = false;
            this.pbFTPConnectTest.Show();
            
            /*
             * Initialize FTP client
             */
            this.ftpClinet = new FTPClient(
                "ftp://" + this.tbFTPAdress.Text,
                this.tbFTPUserName.Text,
                this.tbFTPUserPass.Text
                );
            this.ftpClinet.ConnectionEvent += new EventHandler<FTPConnectionEventArgs>(ftp_ConnectionEvent);

            // start verifiying connection
            new Thread(new ThreadStart(() =>
            {
                this.ftpClinet.VerifyConnection(this.tbFTPRemotePath.Text);
            })).Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ftp_ConnectionEvent(object sender, FTPConnectionEventArgs args)
        {
            if (args.IsSuccess)
            {
                if (args.IsDirectoryExists)
                {
                    this.settings.FtpAddress = this.tbFTPAdress.Text;
                    this.settings.FtpUserName = this.tbFTPUserName.Text;
                    this.settings.FtpUserPassword = this.tbFTPUserPass.Text;
                    this.settings.FtpRemotePath = this.tbFTPRemotePath.Text;
                    this.settings.Save();

                    MessageBox.Show("Połączenie z serwerem FTP działa poprawnie.\nPołączenie zostało zapisane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Połączenie działa poprawnie, ale podany katalog nie istnieje na serwerze.", "Problem ze zdalnym katalogiem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Nie udało połączyć się z serwerem FTP.\nSzczegóły: " + sender.ToString(), "Problem z serwerem FTP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            /*
             * Unlock controls
             */
            this.bFTPConnectTest.InvokeIfRequired(() =>
            {
                this.tbFTPAdress.Enabled = true;
                this.tbFTPUserName.Enabled = true;
                this.tbFTPUserPass.Enabled = true;
                this.tbFTPRemotePath.Enabled = true;

                this.bFTPConnectTest.Enabled = true;
                this.pbFTPConnectTest.Hide();
            });

            //this.ftp.Disconnect();
        }
    }
}
