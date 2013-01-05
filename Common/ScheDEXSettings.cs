using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ITSharp.ScheDEX.Common
{
    [Serializable()]
    public class ScheDEXSettings
    {
        private String fileName;
        
        public ScheDEXSettings(String fileName)
        {
            this.fileName = fileName;

            // Set sefault SQL available connection strings
            this.sqlConnectionStrings = new Dictionary<string, String>();

            // Set default values for FTP settings
            this.ftp_Address = "";
            this.ftp_UserName = "";
            this.ftp_UserPassword = "";
            this.ftp_RemotePath = "";

            // Set default interval settings
            this.interval = 60;
        }

        public void Save()
        {
            Stream fileStream = File.Create(this.fileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, this);
            fileStream.Close();
        }

        public static ScheDEXSettings Load(string fileName)
        {
            ScheDEXSettings settings;

            if (File.Exists(fileName))
            {
                Stream fileStream = File.OpenRead(fileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                settings = (ScheDEXSettings)deserializer.Deserialize(fileStream);
                settings.fileName = fileName;
                fileStream.Close();
            }
            else
            {
                settings = new ScheDEXSettings(fileName);
            }

            return settings;
        }

        //public String FileName
        //{
        //    get { return this.fileName; }
        //    set { this.fileName = value; }
        //}

        private Dictionary<String, String> sqlConnectionStrings;
        public Dictionary<String, String> SqlConnectionStrings
        {
            get { return this.sqlConnectionStrings; }
            set { this.sqlConnectionStrings = value; }
        }

        private String sql_ConnectionKey;
        public String SqlConnectionKey
        {
            get { return this.sql_ConnectionKey; }
            set { this.sql_ConnectionKey = value; }
        }

        private String sql_QueryName;
        public String SqlQueryName
        {
            get { return this.sql_QueryName; }
            set { this.sql_QueryName = value; }
        }

        private String ftp_Address;
        public String FtpAddress
        {
            get { return this.ftp_Address; }
            set { this.ftp_Address = value; }
        }

        private String ftp_UserName;
        public String FtpUserName
        {
            get { return this.ftp_UserName; }
            set { this.ftp_UserName = value; }
        }

        private String ftp_UserPassword;
        public String FtpUserPassword
        {
            get { return this.ftp_UserPassword; }
            set { this.ftp_UserPassword = value; }
        }

        private String ftp_RemotePath;
        public String FtpRemotePath
        {
            get { return this.ftp_RemotePath; }
            set { this.ftp_RemotePath = value; }
        }

        private uint interval;
        public uint Interval
        {
            get { return this.interval; }
            set { this.interval = value; }
        }

        private String xml_FileName;
        public String XmlFileName
        {
            get { return this.xml_FileName; }
            set { this.xml_FileName = value; }
        }
    }
}
