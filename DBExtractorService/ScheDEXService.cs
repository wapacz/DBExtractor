using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading;
using ITSharp.ScheDEX.Common;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Microsoft.Win32;

namespace ITSharp.ScheDEX
{
    public class ScheDEXService : ServiceBase
    {
        private static readonly string WorkingDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ScheDEX");
        private static readonly string EventsFilePath = Path.Combine(WorkingDir, "events.bin");
        //private string workingDir = ".";
        //private string eventsFilePath = ".";

        private Thread mainThread, workerThread;
        private Boolean forever;
        private ScheduleEventList events, todoEvents;
        //private string workingDir;

        private static readonly string PREFIX = @"xls";
        private static readonly string NS = @"urn:schemas-microsoft-com:office:spreadsheet";
        //private static readonly string PREFIX = null;
        //private static readonly string NS = null;

        public ScheDEXService()
        {
            InitializeComponent();


            //RegistryKey register = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ITSharp.pl\ScheDEX");
            //if(register != null)
            //    this.workingDir = Path.Combine(register.GetValue("UserWorkingDirectory").ToString(), "ScheDEX");

            //this.eventsFilePath = Path.Combine(this.workingDir, @"events.bin");

            //WorkingDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"ScheDEX");
            //EventsFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"ScheDEX\events.bin"); 

            //this.workingDir = AppDomain.CurrentDomain.BaseDirectory + @"\";
        }

        private void LOG(String msg)
        {
            System.IO.File.AppendAllText(
                @"c:\service.log",
                String.Format("[{0}] {1}\n", DateTime.Now.ToString(), msg)
                );
        }

        private void InitializeComponent()
        {
            // 
            // ScheDEXService
            // 
            this.ServiceName = "ScheDEX";

            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            // TODO: Add cleanup code here (if required)
            base.Dispose(disposing);
        }

        /// <summary>
        /// Start this service.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            LOG("Starting service");

            //LOG("CommonAppData: " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            LOG("Working dir: " + WorkingDir);
            LOG("Events file: " + EventsFilePath);

            base.OnStart(args);



            this.events = ScheduleEventList.Load(EventsFilePath);
            this.todoEvents = new ScheduleEventList();

            this.mainThread = new Thread(new ThreadStart(MainThread));
            //this.mainThread.Priority = ThreadPriority.BelowNormal;
            this.mainThread.Name = "MainThread";

            this.workerThread = new Thread(new ThreadStart(WorkerThread));
            //this.workerThread.Priority = ThreadPriority.BelowNormal;
            this.workerThread.Name = "WorkerThread";

            this.forever = true;
            this.mainThread.Start();
            this.workerThread.Start();





            LOG("Reading events");
            foreach (ScheduleEvent schedEvent in this.events)
                LOG(" - ScheduleEvent: " + schedEvent.XMLFileName + "(every " + schedEvent.Interval + " minute(s)");


            /*
             * Start all events on the begining
             */
            foreach (ScheduleEvent schedEvent in this.events)
            {
                this.todoEvents.Add(new ScheduleEventWrapper(schedEvent));
            }


            LOG("Service started");
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            LOG("Stoping service");

            this.forever = false;
            //this.Stop();
            base.OnStop();

            LOG("Service stoped");
        }




        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            if (command == 250)
            {
                this.events = ScheduleEventList.Load(EventsFilePath);
                /*
                 * Start all events on the begining
                 */
                foreach (ScheduleEvent schedEvent in this.events)
                {
                    this.todoEvents.Add(new ScheduleEventWrapper(schedEvent));
                }
                LOG("New events loaded...");
            }
        }


        protected void MainThread()
        {
            LOG("Begin of MainThread");

            int currentMinutes = 0;
            //foreach (ScheduleEvent schedEvent in this.events)
            //{
            //    System.IO.File.WriteAllText(@"c:\connectionString.txt", schedEvent.SQLConnectionString);
            //}

            while (this.forever)
            {
                //LOG("LOOP in MainThread");

                currentMinutes = DateTime.Now.Hour * 60 + DateTime.Now.Minute;

                foreach (ScheduleEvent schedEvent in this.events)
                {
                    if (currentMinutes % schedEvent.Interval == 0 && DateTime.Now.Second == 0)
                    {
                        this.todoEvents.Add(new ScheduleEventWrapper(schedEvent));
                        LOG("ScheduleEvent added to queue: " + schedEvent.XMLFileName);
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        protected void WorkerThread()
        {
            string workingFile;

            LOG("Begin of WorkerThread");

            while (this.forever)
            {
                //LOG("LOOP in WorkerThread");

                foreach (ScheduleEventWrapper schedEvent in new ArrayList(this.todoEvents))
                {
                    schedEvent.IncreaseAttemptCounter();

                    LOG("Working with ScheduleEvent: " + schedEvent.XMLFileName);

                    using (SqlConnection sqlConnection = new SqlConnection(schedEvent.SQLConnectionString))
                    {
                        try
                        {
                            workingFile = Path.Combine(WorkingDir + schedEvent.XMLFileName);
                            /*
                             * Connect with MSSQL server and use database from event
                             * and get the data for XML file
                             */
                            sqlConnection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(schedEvent.SQLQuery, sqlConnection);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            /*
                             * Start creating XML file
                             */
                            XmlWriterSettings xmlWS = new XmlWriterSettings();
                            xmlWS.Encoding = Encoding.UTF8;

                            using (XmlWriter writer = XmlWriter.Create(workingFile, xmlWS))
                            {
                                /*
                                 * Fill header of XML file
                                 */
                                writer.WriteStartDocument();
                                writer.WriteStartElement(PREFIX, "Workbook", NS);

                                /*
                                 * Fill specific header of table
                                 */
                                writer.WriteStartElement(PREFIX, "Styles", NS);
                                writer.WriteStartElement(PREFIX, "Style", NS);
                                writer.WriteAttributeString(PREFIX, "ID", NS, "1");
                                writer.WriteStartElement(PREFIX, "Font", NS);
                                writer.WriteAttributeString(PREFIX, "Bold", NS, "1");
                                writer.WriteEndElement(); //Font
                                writer.WriteEndElement(); //Style
                                writer.WriteEndElement(); //Styles

                                writer.WriteStartElement(PREFIX, "Worksheet", NS);
                                writer.WriteAttributeString(PREFIX, "Name", NS, "Arkusz");
                                writer.WriteStartElement(PREFIX, "Table", NS);

                                foreach (DataColumn col in dataTable.Columns)
                                {
                                    writer.WriteStartElement(PREFIX, "Column", NS);
                                    writer.WriteAttributeString(PREFIX, "Width", NS, "100");
                                    writer.WriteEndElement(); // Column
                                }

                                writer.WriteStartElement(PREFIX, "Row", NS);
                                writer.WriteAttributeString(PREFIX, "StyleID", NS, "1");

                                foreach (DataColumn col in dataTable.Columns)
                                {
                                    writer.WriteStartElement(PREFIX, "Cell", NS);
                                    writer.WriteStartElement(PREFIX, "Data", NS);
                                    writer.WriteAttributeString(PREFIX, "Type", NS, "String");
                                    writer.WriteString(col.ColumnName);
                                    writer.WriteEndElement(); // Data
                                    writer.WriteEndElement(); // Cell

                                }
                                writer.WriteEndElement(); // Row

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    writer.WriteStartElement(PREFIX, "Row", NS);

                                    foreach (DataColumn col in dataTable.Columns)
                                    {
                                        writer.WriteStartElement(PREFIX, "Cell", NS);

                                        writer.WriteStartElement(PREFIX, "Data", NS);
                                        writer.WriteAttributeString(PREFIX, "Type", NS, XMLHelper.ConvertType(Type.GetTypeCode(col.DataType)));
                                        writer.WriteString(row[col].ToString());
                                        writer.WriteEndElement(); // Data

                                        writer.WriteEndElement(); // Cell
                                    }

                                    writer.WriteEndElement(); // Row
                                }

                                writer.WriteEndElement(); // Table
                                writer.WriteEndElement(); // Worksheet

                                writer.WriteEndElement();
                                writer.WriteEndDocument();

                                #region HIDEN
                                ///*
                                // * Fill header of XML file
                                // */
                                //writer.WriteStartDocument();
                                //writer.WriteStartElement(PREFIX, "Table", NS);

                                ///*
                                // * Fill column names to XML
                                // */
                                //writer.WriteStartElement(PREFIX, "Header", NS);
                                //foreach (DataColumn col in dataTable.Columns)
                                //{
                                //    writer.WriteStartElement(PREFIX, "Cell", NS);
                                //    writer.WriteAttributeString(PREFIX, "DataType", NS, col.DataType.ToString());
                                //    writer.WriteString(col.ColumnName);
                                //    writer.WriteEndElement(); // Cell
                                //}
                                //writer.WriteEndElement(); // Header

                                ///*
                                // * Fill data from DB to XML
                                // */
                                //foreach (DataRow row in dataTable.Rows)
                                //{
                                //    writer.WriteStartElement(PREFIX, "Row", NS);

                                //    foreach (DataColumn col in dataTable.Columns)
                                //    {
                                //        writer.WriteStartElement(PREFIX, "Cell", NS);
                                //        writer.WriteString(row[col].ToString());
                                //        writer.WriteEndElement(); // Data
                                //    }

                                //    writer.WriteEndElement(); // Row
                                //}

                                //writer.WriteEndElement(); // Table

                                #endregion
                            }

                            /*
                             * Send file to FTP server
                             */
                            FTPHelper.UploadFile(
                                workingFile,
                                "ftp://" + schedEvent.FTPAddress + "/" + schedEvent.XMLFileName + ".part",
                                schedEvent.FTPLogin,
                                schedEvent.FTPPassword
                                );

                            /*
                             * and rename it
                             */
                            FTPHelper.RenameFile(
                                schedEvent.XMLFileName,
                                "ftp://" + schedEvent.FTPAddress + "/" + schedEvent.XMLFileName + ".part",
                                schedEvent.FTPLogin,
                                schedEvent.FTPPassword
                                );

                            /*
                             * Clean up worker array with events
                             */
                            this.todoEvents.Remove(schedEvent);
                        }
                        catch (Exception ex)
                        {
                            //TODO: .... LOG ???
                            //Console.WriteLine("Error: " + e);
                            LOG("ERROR: " + ex.Message);

                            /* 
                             * If we have more attempts then try again, so do not remove this event from working array
                             */
                            if (schedEvent.TryAgain)
                            {
                                LOG("Taking another attempt");
                            }
                            else
                            {
                                /*
                                 * Clean up worker array with events
                                 */
                                this.todoEvents.Remove(schedEvent);
                                LOG("Give up");
                            }
                        }
                        finally
                        {
                            sqlConnection.Close();
                        }
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }

    class ScheduleEventWrapper : ScheduleEvent
    {
        private const int MAX_ATTEMPTS = 2;
        private int attemptCounter;

        public ScheduleEventWrapper()
            : base()
        {
            this.attemptCounter = 0;
        }

        public ScheduleEventWrapper(ScheduleEvent schedEvent)
            : base()
        {
            this.attemptCounter = 0;

            this.sql_connectionString = schedEvent.SQLConnectionString;
            this.sql_query = schedEvent.SQLQuery;
            this.sql_query_name = schedEvent.SQLQueryName;
            this.ftp_address = schedEvent.FTPAddress;
            this.ftp_login = schedEvent.FTPLogin;
            this.ftp_password = schedEvent.FTPPassword;
            this.ftp_remotePath = schedEvent.FTPRemotePath;
            this.xml_fileName = schedEvent.XMLFileName;
            this.interval = schedEvent.Interval;
        }

        public void IncreaseAttemptCounter()
        {
            this.attemptCounter++;
        }

        public Boolean TryAgain
        {
            get { return this.attemptCounter < MAX_ATTEMPTS; }
        }
    }
}
