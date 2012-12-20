using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace DBExtractor
{
    class FTPHelper
    {
        public static void UploadFile(string localPath, string remotePath, string login, string password)
        {
            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(remotePath);
            ftp.Credentials = new NetworkCredential(login, password);
            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = File.OpenRead(localPath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
        }
    }
}
