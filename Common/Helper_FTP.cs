using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ITSharp.Helpers.FTP
{
    public class FTPClient
    {
        public event EventHandler<FTPConnectionEventArgs> ConnectionEvent;

        private string password;
        private string userName;
        private string uri;
        private int bufferSize = 1024;

        public bool Passive = true;
        public bool Binary = true;
        public bool EnableSsl = false;
        public bool Hash = false;
        public bool KeepAlive = false;
        public int Timeout = 10000000;
        public int ReadWriteTimeout = 10000000; 

        public FTPClient(string uri, string userName, string password)
        {
            this.uri = uri;
            this.userName = userName;
            this.password = password;
        }

        public void VerifyConnection(String path)
        {
            Boolean found;
            string[] dirList;
            try
            {
                var separator = new char[] { '\\', '/' };
                foreach (String directory in path.Split(separator))
                {
                    found = false;
                    dirList = this.ListDirectory();
                    foreach(string dir in dirList)
                    {
                        if (dir.Equals(directory))
                        {
                            found = true;
                            //break;
                        }
                    }
                    if (found)
                    {
                        this.ChangeWorkingDirectory(directory);
                    }
                    else
                    {
                        // dir not found
                        if (ConnectionEvent != null)
                            ConnectionEvent(this, FTPConnectionEventArgs.SuccessWithProblems);
                        return;
                    }
                }
                
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
                //ftp.Disconnect();
            }
        }

        public string AppendFile(string source, string destination)
        {
            var request = createRequest(combine(uri, destination), WebRequestMethods.Ftp.AppendFile);

            using (var stream = request.GetRequestStream())
            {
                using (var fileStream = System.IO.File.Open(source, FileMode.Open))
                {
                    int num;

                    byte[] buffer = new byte[bufferSize];

                    while ((num = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (Hash)
                            Console.Write("#");

                        stream.Write(buffer, 0, num);
                    }
                }
            }

            return getStatusDescription(request);
        }

        public string ChangeWorkingDirectory(string path)
        {
            uri = combine(uri, path);

            return PrintWorkingDirectory();
        }

        public string DeleteFile(string fileName)
        {
            var request = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.DeleteFile);

            return getStatusDescription(request);
        }

        public string DownloadFile(string source, string dest)
        {
            var request = createRequest(combine(uri, source), WebRequestMethods.Ftp.DownloadFile);

            byte[] buffer = new byte[bufferSize];

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var fs = new FileStream(dest, FileMode.OpenOrCreate))
                    {
                        int readCount = stream.Read(buffer, 0, bufferSize);

                        while (readCount > 0)
                        {
                            if (Hash)
                                Console.Write("#");

                            fs.Write(buffer, 0, readCount);
                            readCount = stream.Read(buffer, 0, bufferSize);
                        }
                    }
                }

                return response.StatusDescription;
            }
        }

        public DateTime GetDateTimestamp(string fileName)
        {
            var request = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.GetDateTimestamp);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return response.LastModified;
            }
        }

        public long GetFileSize(string fileName)
        {
            var request = createRequest(combine(uri, fileName), WebRequestMethods.Ftp.GetFileSize);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return response.ContentLength;
            }
        }

        public string[] ListDirectory()
        {
            var list = new List<string>();

            var request = createRequest(WebRequestMethods.Ftp.ListDirectory);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list.ToArray();
        }

        public string[] ListDirectoryDetails()
        {
            var list = new List<string>();

            var request = createRequest(WebRequestMethods.Ftp.ListDirectoryDetails);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list.ToArray();
        }

        public string MakeDirectory(string directoryName)
        {
            var request = createRequest(combine(uri, directoryName), WebRequestMethods.Ftp.MakeDirectory);

            return getStatusDescription(request);
        }

        public string[] PrintMyWorkingDirectory()
        {
            var list = new List<string>();

            var request = createRequest(WebRequestMethods.Ftp.PrintWorkingDirectory);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list.ToArray();
        }

        public string PrintWorkingDirectory()
        {
            var request = createRequest(WebRequestMethods.Ftp.PrintWorkingDirectory);

            return getStatusDescription(request);
        }

        public string RemoveDirectory(string directoryName)
        {
            var request = createRequest(combine(uri, directoryName), WebRequestMethods.Ftp.RemoveDirectory);

            return getStatusDescription(request);
        }

        public string Rename(string currentName, string newName)
        {
            var request = createRequest(combine(uri, currentName), WebRequestMethods.Ftp.Rename);

            request.RenameTo = newName;

            return getStatusDescription(request);
        }

        public string UploadFile(string source, string destination)
        {
            var request = createRequest(combine(uri, destination), WebRequestMethods.Ftp.UploadFile);

            using (var stream = request.GetRequestStream())
            {
                using (var fileStream = System.IO.File.Open(source, FileMode.Open))
                {
                    int num;

                    byte[] buffer = new byte[bufferSize];

                    while ((num = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (Hash)
                            Console.Write("#");

                        stream.Write(buffer, 0, num);
                    }
                }
            }

            return getStatusDescription(request);
        }

        public string UploadFileWithUniqueName(string source)
        {
            var request = createRequest(WebRequestMethods.Ftp.UploadFileWithUniqueName);

            using (var stream = request.GetRequestStream())
            {
                using (var fileStream = System.IO.File.Open(source, FileMode.Open))
                {
                    int num;

                    byte[] buffer = new byte[bufferSize];

                    while ((num = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (Hash)
                            Console.Write("#");

                        stream.Write(buffer, 0, num);
                    }
                }
            }

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return Path.GetFileName(response.ResponseUri.ToString());
            }
        }

        private FtpWebRequest createRequest(string method)
        {
            return createRequest(uri, method);
        }

        private FtpWebRequest createRequest(string uri, string method)
        {
            var r = (FtpWebRequest)WebRequest.Create(uri);

            r.Credentials = new NetworkCredential(userName, password);
            r.Method = method;
            r.UseBinary = Binary;
            r.EnableSsl = EnableSsl;
            r.UsePassive = Passive;
            r.KeepAlive = KeepAlive;
            r.Timeout = Timeout;
            r.ReadWriteTimeout = ReadWriteTimeout; 

            return r;
        }

        private string getStatusDescription(FtpWebRequest request)
        {
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }

        private string combine(string path1, string path2)
        {
            return Path.Combine(path1, path2).Replace("\\", "/");
        }
    }

    public class FTPConnectionEventArgs : EventArgs
    {
        private Boolean isSuccess;
        public Boolean IsSuccess
        {
            get { return this.isSuccess; }
            //set { this.isSuccess = value; }
        }

        private Boolean isDirectoryExists;
        public Boolean IsDirectoryExists
        {
            get { return this.isDirectoryExists; }
            //set { this.isSuccess = value; }
        }

        public static FTPConnectionEventArgs Success
        {
            get
            {
                FTPConnectionEventArgs args = new FTPConnectionEventArgs();
                args.isSuccess = true;
                args.isDirectoryExists = true;
                return args;
            }
        }

        public static FTPConnectionEventArgs SuccessWithProblems
        {
            get
            {
                FTPConnectionEventArgs args = new FTPConnectionEventArgs();
                args.isSuccess = true;
                args.isDirectoryExists = false;
                return args;
            }
        }

        public static FTPConnectionEventArgs Fail
        {
            get
            {
                FTPConnectionEventArgs args = new FTPConnectionEventArgs();
                args.isSuccess = false;
                args.isDirectoryExists = false;
                return args;
            }
        }
    }
}