using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Microsoft.Win32;
using ITSharp.ScheDEX.Common;

namespace ITSharp.ScheDEX
{
    public class ScheDEXService : ServiceBase
    {
        private static readonly string WorkingDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ScheDEX");
        private static readonly string EventsFilePath = Path.Combine(WorkingDir, "events.bin");

        private Thread mainThread, workerThread;
        private Boolean forever;
        private ScheduleEventList events, todoEvents;

        private static string PREFIX = @"xls";
        private static string NS = @"urn:schemas-microsoft-com:office:spreadsheet";

        public ScheDEXService()
        {
            InitializeComponent();
        }

#if DEBUG
        private void LOG(String msg)
        {
            System.IO.File.AppendAllText(
                @"c:\service.log",
                String.Format("[{0}] {1}\n", DateTime.Now.ToString(), msg)
                );
        }
#endif

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
#if DEBUG
            LOG("Starting service");
            LOG("Working dir: " + WorkingDir);
            LOG("Events file: " + EventsFilePath);
#endif

            base.OnStart(args);

            this.events = ScheduleEventList.Load(EventsFilePath);
            this.todoEvents = new ScheduleEventList();

            this.mainThread = new Thread(new ThreadStart(MainThread));
            this.mainThread.Name = "MainThread";

            this.workerThread = new Thread(new ThreadStart(WorkerThread));
            this.workerThread.Name = "WorkerThread";

            this.forever = true;
            this.mainThread.Start();
            this.workerThread.Start();

#if DEBUG
            LOG("Reading events");
            foreach (ScheduleEvent schedEvent in this.events)
                LOG(" - ScheduleEvent: " + schedEvent.XMLFileName + "(every " + schedEvent.Interval + " minute(s)");
#endif

            /*
             * Start all events on the begining
             */
            foreach (ScheduleEvent schedEvent in this.events)
            {
                this.todoEvents.Add(new ScheduleEventWrapper(schedEvent));
            }


            //LOG("Service started");
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
#if DEBUG
            LOG("Stoping service");
#endif

            this.forever = false;

            base.OnStop();

#if DEBUG
            LOG("Service stoped");
#endif
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
#if DEBUG
                LOG("New events loaded...");
#endif
            }
        }


        protected void MainThread()
        {
#if DEBUG
            LOG("Begin of MainThread");
#endif

            int currentMinutes = 0;

            while (this.forever)
            {
                currentMinutes = DateTime.Now.Hour * 60 + DateTime.Now.Minute;

                foreach (ScheduleEvent schedEvent in this.events)
                {
                    if (currentMinutes % schedEvent.Interval == 0 && DateTime.Now.Second == 0)
                    {
                        this.todoEvents.Add(new ScheduleEventWrapper(schedEvent));

#if DEBUG
                        LOG("ScheduleEvent added to queue: " + schedEvent.XMLFileName);
#endif
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        protected void WorkerThread()
        {
            // setup DOTs instead of COMMAs for this thread
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            string workingFile;

#if DEBUG
            LOG("Begin of WorkerThread");
#endif

            while (this.forever)
            {
                foreach (ScheduleEventWrapper schedEvent in new ArrayList(this.todoEvents))
                {
                    schedEvent.IncreaseAttemptCounter();

#if DEBUG
                    LOG("Working with ScheduleEvent: " + schedEvent.XMLFileName);
#endif

                    using (SqlConnection sqlConnection = new SqlConnection(schedEvent.SQLConnectionString))
                    {
                        try
                        {
                            workingFile = Path.Combine(WorkingDir, schedEvent.XMLFileName);
                            /*
                             * Connect with MSSQL server and use database from event
                             * and get the data for XML file
                             */
                            sqlConnection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(schedEvent.SQLQuery, sqlConnection);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            XmlWriterSettings xmlWS = new XmlWriterSettings();

                            /*
                             * Start creating XML file
                             */
                            if (schedEvent.SQLQueryName == "Kartoteki")
                            {
                                xmlWS.Encoding = new ASCIIEncoding(); //Encoding.UTF8;

                                using (XmlWriter writer = XmlWriter.Create(workingFile, xmlWS))
                                {
                                    PREFIX = @"xls";
                                    NS = @"urn:schemas-microsoft-com:office:spreadsheet";

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
                                }
                            }
                            else  // simpler XML version for rest of queries
                            {
                                xmlWS.Encoding = Encoding.UTF8;

                                using (XmlWriter writer = XmlWriter.Create(workingFile, xmlWS))
                                {
                                    PREFIX = null;
                                    NS = null;
                                    /*
                                     * Fill header of XML file
                                     */
                                    writer.WriteStartDocument();
                                    writer.WriteStartElement(PREFIX, "Table", NS);

                                    /*
                                     * Fill column names to XML
                                     */
                                    writer.WriteStartElement(PREFIX, "Header", NS);
                                    foreach (DataColumn col in dataTable.Columns)
                                    {
                                        writer.WriteStartElement(PREFIX, "Cell", NS);
                                        writer.WriteAttributeString(PREFIX, "DataType", NS, XMLHelper.ConvertType(Type.GetTypeCode(col.DataType)));
                                        writer.WriteString(col.ColumnName);
                                        writer.WriteEndElement(); // Cell
                                    }
                                    writer.WriteEndElement(); // Header

                                    /*
                                     * Fill data from DB to XML
                                     */
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        writer.WriteStartElement(PREFIX, "Row", NS);

                                        foreach (DataColumn col in dataTable.Columns)
                                        {
                                            writer.WriteStartElement(PREFIX, "Cell", NS);
                                            writer.WriteString(row[col].ToString());
                                            writer.WriteEndElement(); // Data
                                        }

                                        writer.WriteEndElement(); // Row
                                    }

                                    writer.WriteEndElement(); // Table

                                }
                            }

                            FTPClient ftpClient = new FTPClient(
                                "ftp://" + schedEvent.FTPAddress,
                                schedEvent.FTPLogin,
                                schedEvent.FTPPassword
                                );

                            ftpClient.ChangeWorkingDirectory(schedEvent.FTPRemotePath);
                            ftpClient.UploadFile(workingFile, schedEvent.XMLFileName + ".part");
                            ftpClient.Rename(schedEvent.XMLFileName + ".part", schedEvent.XMLFileName);

                            /*
                             * Clean up worker array with events
                             */
                            this.todoEvents.Remove(schedEvent);
                        }
#if DEBUG
                        catch (Exception ex)
#else
                        catch (Exception)
#endif
                        {
#if DEBUG
                            LOG("ERROR: " + ex.Message);
#endif

                            /* 
                             * If we have more attempts then try again, so do not remove this event from working array
                             */
                            if (schedEvent.TryAgain)
                            {
#if DEBUG
                                LOG("Taking another attempt");
#endif
                            }
                            else
                            {
                                /*
                                 * Clean up worker array with events
                                 */
                                this.todoEvents.Remove(schedEvent);

#if DEBUG
                                LOG("Give up");
#endif
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
