using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace ITSharp.ScheDEX.Common
{
    public class FTPHelper
    {
        public event EventHandler<FTPConnectionEventArgs> ConnectionEvent;
        //public event EventHandler ConnectionUnsuccessful;
        
        public FTPHelper()
        {
            this.address = "";
            this.login = "";
            this.password = "";
            //this.remotePath = "";
        }

        /// <summary>
        /// Starts thread which start CheckConnection method
        /// </summary>
        public void StartCheckConnection()
        {
            Thread thread = new Thread(new ThreadStart(CheckConnection));
            thread.Name = "CheckConnection";
            thread.Start();
        }

        /// <summary>
        /// Check connection to FTP 
        /// </summary>
        private void CheckConnection()
        {
            FtpWebRequest ftp;

            try
            {
                ftp = (FtpWebRequest)WebRequest.Create("ftp://"+this.address);
                ftp.Credentials = new NetworkCredential(this.login, this.password);
                ftp.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
                ftp.GetResponse();

                if (ConnectionEvent != null)
                    ConnectionEvent(this, FTPConnectionEventArgs.Success);
            }
            catch (Exception ex)
            {
                if(ConnectionEvent != null)
                    ConnectionEvent(ex.Message, FTPConnectionEventArgs.Fail);
            }
            finally
            {
                //ftp.Close();
            }
        }

        public String FetchRemoteFiles()
        {
            String response = "";

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(this.address);
            ftp.Credentials = new NetworkCredential(this.login, this.password);
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            ftp.KeepAlive = false;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftp.GetResponse();

            StreamReader sr = new StreamReader(ftpResponse.GetResponseStream());
            //StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create));

            response = sr.ReadToEnd();
            //sw.Close();

            ftpResponse.Close();
            sr.Close();

            return response;
        }

        public static void UploadFile(String localPath, String remotePath, String login, String password)
        {
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(remotePath);
            ftp.Credentials = new NetworkCredential(login, password);
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.UsePassive = true;
            ftp.Timeout = 10000000;
            ftp.ReadWriteTimeout = 10000000; 
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = File.OpenRead(localPath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
        }

        public static void RenameFile(String newName, String remotePath, String login, String password)
        {
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(remotePath);
            ftp.Credentials = new NetworkCredential(login, password);
            ftp.Method = WebRequestMethods.Ftp.Rename;
            ftp.RenameTo = newName;
            ftp.GetResponse();
        }

        private String address;
        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        private String login;
        public String Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        private String password;
        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        
        //private String remotePath;
        //public String RemotePath
        //{
        //    get { return this.remotePath; }
        //    set { this.remotePath = value; }
        //}
    }

    public class FTPConnectionEventArgs : EventArgs
    {
        private Boolean isSuccess;
        public Boolean IsSuccess
        {
            get { return this.isSuccess; }
            set { this.isSuccess = value; }
        }

        public static FTPConnectionEventArgs Success
        {
            get
            {
                FTPConnectionEventArgs args = new FTPConnectionEventArgs();
                args.IsSuccess = true;
                return args;
            }
        }

        public static FTPConnectionEventArgs Fail
        {
            get
            {
                FTPConnectionEventArgs args = new FTPConnectionEventArgs();
                args.IsSuccess = false;
                return args;
            }
        }
    }
}
