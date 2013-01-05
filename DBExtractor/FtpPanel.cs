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
    public partial class FtpPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;
        internal FTPHelper ftp;

        public FtpPanel(FormMain container)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.container = container;
            this.settings = container.settings;
            
            /*
             * Initialize FTP helper
             */
            this.ftp = new FTPHelper();
            this.ftp.ConnectionEvent += new EventHandler<FTPConnectionEventArgs>(ftp_ConnectionEvent);
            container.ftp = this.ftp;
            this.ftp.Address = this.settings.FtpAddress;
            this.ftp.Login = this.settings.FtpUserName;
            this.ftp.Password = this.settings.FtpUserPassword;
            
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
             * Lock controls
             */
            this.tbFTPAdress.Enabled = false;
            this.tbFTPUserName.Enabled = false;
            this.tbFTPUserPass.Enabled = false;
            this.tbFTPRemotePath.Enabled = false;

            this.bFTPConnectTest.Enabled = false;
            this.pbFTPConnectTest.Show();

            /*
             * Copy date from forms and put them into FTP helper
             */
            this.ftp.Address = this.tbFTPAdress.Text;
            this.ftp.Login = this.tbFTPUserName.Text;
            this.ftp.Password = this.tbFTPUserPass.Text;
            //this.ftp.RemotePath = this.tbFTPRemotePath.Text;

            this.ftp.StartCheckConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ftp_ConnectionEvent(object sender, FTPConnectionEventArgs args)
        {
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

            if (args.IsSuccess)
            {
                this.settings.FtpAddress = this.ftp.Address;
                this.settings.FtpUserName = this.ftp.Login;
                this.settings.FtpUserPassword = this.ftp.Password;
                this.settings.FtpRemotePath = this.tbFTPRemotePath.Text; //this.ftp.RemotePath;
                this.settings.Save();

                MessageBox.Show("Połączenie z serwerem FTP działa poprawnie.\nPołączenie zostało zapisane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nie udało połączyć się z serwerem FTP.\nSzczegóły: " + sender.ToString(), "Problem z serwerem FTP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
