using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading;

using ITSharp.DBExtractor.Common;
using System.IO;

namespace ITSharp.DBExtractor
{
    public class DBExtractorService : ServiceBase
    {
        private Thread serviceThread;
        private Boolean forever;
        private TimeSpan delay;

        private ScheduleEventList events;
        private ScheduleEventList events2;

        public DBExtractorService()
        {
            this.events = ScheduleEventList.Load(AppDomain.CurrentDomain.BaseDirectory + @"\events.bin");
            this.events2 = ScheduleEventList.Load(@"c:\events.bin");

            InitializeComponent();

            this.delay = new TimeSpan(0, 0, 1); // every second

            this.serviceThread = new Thread(new ThreadStart(ServiceMain));
            this.serviceThread.Priority = ThreadPriority.BelowNormal;
            this.serviceThread.Name = "ServiceMain";

            this.forever = true;
        }

        private void InitializeComponent()
        {
            // 
            // DBExtractorService
            // 
            this.ServiceName = "DBExtractorService";

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
            base.OnStart(args);
            this.serviceThread.Start();
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            this.forever = false;
            this.Stop();
            base.OnStop();
        }

        protected void ServiceMain()
        {
            foreach (ScheduleEvent schedEvent in this.events)
            {
                System.IO.File.WriteAllText(@"c:\connectionString.txt", schedEvent.SQLConnectionString);
            }
            foreach (ScheduleEvent schedEvent in this.events2)
            {
                System.IO.File.WriteAllText(@"c:\connectionString2.txt", schedEvent.SQLConnectionString);
            }
            while (this.forever)
            {
                //TODO: get the data from base, convert to XML and send to FTP



                //DBExtractor.Common.

                Thread.Sleep(this.delay);
            }
        }
    }
}
