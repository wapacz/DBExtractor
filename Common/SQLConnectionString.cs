﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ITSharp.ScheDEX.Common
{
    /// <summary>
    /// Manages Sql Connection String
    /// </summary>
    public class SQLConnectionString : ICloneable
    {
        static Regex parseServer = new Regex(
            @"(?i:((Data\sSource)|(Server)|(Address)|(Addr)|(Network Address))=(?<server>[^;]+))"
            , RegexOptions.Compiled);

        static Regex parseAuth = new Regex(
            @"(?i:((Integrated\sSecurity)|(Trusted_Connection))=(?<auth>(true)|(yes)|(sspi)))"
            , RegexOptions.Compiled);

        static Regex parseDatabase = new Regex(
            @"(?i:((Initial\sCatalog)|(Database))=(?<database>[^;]+))"
            , RegexOptions.Compiled);

        static Regex parsePassword = new Regex(
            @"(?i:((Password)|(Pwd))=(?<password>[^;]+))"
            , RegexOptions.Compiled);

        static Regex parseUser = new Regex(
            @"(?i:(User\sID=(?<user>[^;]+)))"
            , RegexOptions.Compiled);

        public SQLConnectionString()
        {

        }

        //string connectionString = "";
        public string ConnectionString
        {
            get
            {
                if (server.Length == 0 && database.Length == 0)
                    return "";

                StringBuilder sb = new StringBuilder();
                if (server.Length > 0)
                    sb.Append("Server=").Append(server).Append(";");

                if (database.Length > 0)
                    sb.Append("Database=").Append(database).Append(";");

                if (auth)
                    sb.Append("Integrated Security=true;");

                if (user.Length > 0)
                    sb.Append("User ID=").Append(user).Append(";");

                if (password.Length > 0)
                    sb.Append("Pwd=").Append(password).Append(";");

                return sb.ToString();
            }
            set
            {
                server = parseServer.Match(value).Groups["server"].Value;
                database = parseDatabase.Match(value).Groups["database"].Value;
                auth = database.Length == 0 || parseAuth.Match(value).Groups["auth"].Value.Length > 0;
                user = parseUser.Match(value).Groups["user"].Value;
                password = parsePassword.Match(value).Groups["password"].Value;

            }
        }

        string server = "";
        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }

        string database = "";
        public string Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }

        string user = "";
        public string UserID
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        string password = "";
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        bool auth = true;
        public bool Authentication
        {
            get
            {
                return auth;
            }
            set
            {
                auth = value;
            }
        }
        #region ICloneable Members

        public object Clone()
        {
            SQLConnectionString scs = new SQLConnectionString();
            scs.auth = auth;
            scs.database = database;
            scs.password = password;
            scs.server = server;
            scs.user = user;
            return scs;
        }

        #endregion
    }

}
