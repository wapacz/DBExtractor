using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITSharp.DBExtractor.Common
{
    [Serializable()]
    public class ScheduleEvent
    {
        public ScheduleEvent()
        {
            this.sql_connectionString = "";
            this.sql_table = "";
            this.ftp_address = "";
            this.ftp_login = "";
            this.ftp_password = "";
            this.ftp_remotePath = "";
            this.xml_fileName = "";
            this.interval = 60;
        }

        protected String sql_connectionString;
        public String SQLConnectionString
        {
            get { return this.sql_connectionString; }
            set { this.sql_connectionString = value; }
        }

        protected String sql_table;
        public String SQLTable
        {
            get { return this.sql_table; }
            set { this.sql_table = value; }
        }

        protected String ftp_address;
        public String FTPAddress
        {
            get { return this.ftp_address; }
            set { this.ftp_address = value; }
        }

        protected String ftp_login;
        public String FTPLogin
        {
            get { return this.ftp_login; }
            set { this.ftp_login = value; }
        }

        protected String ftp_password;
        public String FTPPassword
        {
            get { return this.ftp_password; }
            set { this.ftp_password = value; }
        }

        protected String ftp_remotePath;
        public String FTPRemotePath
        {
            get { return this.ftp_remotePath; }
            set { this.ftp_remotePath = value; }
        }

        protected String xml_fileName;
        public String XMLFileName
        {
            get { return this.xml_fileName; }
            set { this.xml_fileName = value; }
        }

        protected uint interval;
        public uint Interval
        {
            get { return this.interval; }
            set { this.interval = value; }
        }

        public override string ToString()
        {
            Common.SQLConnectionString connString = new Common.SQLConnectionString();
            connString.ConnectionString = this.SQLConnectionString;

            String result = String.Format(
                "[{0} - {1}] {2}, co {3} min. do pliku {4} na serwer {5}",
                connString.Server,
                connString.Database,
                this.sql_table,
                this.interval,
                this.xml_fileName,
                this.ftp_address
            );

            return result;
        }
    }
}
