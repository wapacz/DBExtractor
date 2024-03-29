﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

using ITSharp.DBExtractor.Common;
using System.IO;
using Microsoft.Win32;

namespace DBExtractorSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * XML
             * /
            DBExtractor.XMLHelper xml = new DBExtractor.XMLHelper();
            xml.GenerateXML_0();
            xml.GenerateXML_1();
            xml.GenerateXML_2();
            xml.GenerateXML_3();
            xml.GenerateXML_4();
            xml.GenerateXML_5();
            */

            /*
             * DB
             * /
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
            SqlDataReader rdr = null;
            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from Customers", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            */

            //// Retrieve the enumerator instance and then the data.
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //System.Data.DataTable table = instance.GetDataSources();

            //// Display the contents of the table.
            //DisplayData(table);


            //FTPHelper.UploadFile(
            //    @"C:\Program Files (x86)\DBExtractor\Kontrahenci.xml",
            //    @"ftp://itsharp.pl/Kontrahenci.xml.part",
            //    "bartoszulman@itsharp.pl",
            //    "bUl!b2012"
            //    );

            //FTPHelper.RenameFile(
            //    "Kontrahenci.xml",
            //    @"ftp://itsharp.pl/Kontrahenci.xml.part",
            //    "bartoszulman@itsharp.pl",
            //    "bUl!b2012"
            //    );


            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "DateLinks.xml");
            Console.WriteLine(fileName);


            RegistryKey register = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ITSharp.pl\DBExtractor");
            string workingDir = ".aaa.";
            if (register != null)
                workingDir = Path.Combine(register.GetValue("UserWorkingDirectory").ToString(), "DBExtractor");

            string eventsFilePath = Path.Combine(workingDir, @"events.bin");

            Console.WriteLine(eventsFilePath);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();



        }

        private static void DisplayData(System.Data.DataTable table)
        {
            String srvName = "";

            foreach (System.Data.DataRow row in table.Rows)
            {
                if (srvName.Equals(""))
                {
                    srvName = row["ServerName"] + "\\" + row["InstanceName"];
                }
                else
                {
                    if (!row["InstanceName"].Equals("SQLEXPRESS"))
                    {
                        srvName = row["ServerName"] + "\\" + row["InstanceName"];
                    }

                }
                Console.WriteLine(row["ServerName"] + "\\" + row["InstanceName"]);


                SQLConnectionString sqlConnStr = new SQLConnectionString();

                sqlConnStr.Server = srvName;
                sqlConnStr.Authentication = true;
                /*
                if (!rbAuthWindows.Checked)
                {
                    sqlConnStr.UserID = txtUser.Text;
                    sqlConnStr.Password = txtPassword.Text;
                }
                */

                using (SqlConnection sqlConn = new SqlConnection(sqlConnStr.ConnectionString))
                {
                    try
                    {
                        sqlConn.Open();

                        DataTable tblDatabases = sqlConn.GetSchema("Databases");


                        foreach (DataRow rowDBs in tblDatabases.Rows)
                        {
                            Console.WriteLine(rowDBs["database_name"]);

                            if (rowDBs["database_name"].Equals("MagresNET"))
                            {
                                sqlConn.ChangeDatabase("MagresNET");
                                Console.WriteLine("Found and selected");

                                DataTable dt = sqlConn.GetSchema("Tables");
                                foreach (DataRow rowTables in dt.Rows)
                                {
                                    Console.WriteLine(rowTables["table_name"]);
                                }
                            }

                        }


                        

                        sqlConn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EX: " + ex.Message);
                        Console.WriteLine("EX: " + sqlConnStr.ConnectionString);
                    }
                }
            }
            /*
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
                Console.WriteLine("============================");
            }
            */
        }
    }
}
