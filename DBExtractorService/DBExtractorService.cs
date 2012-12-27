using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading;

namespace DBExtractor
{
    public class DBExtractorService : ServiceBase
    {
        public const string MyServiceName = "DBExtractorService";

        private Thread serviceThread;
        private TimeSpan delay;

        public DBExtractorService()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ServiceName = DBExtractorService.MyServiceName;
            this.serviceThread = new Thread(new ThreadStart(ServiceMain));
            this.delay = new TimeSpan(0, 0, 1, 0, 0); // one minute
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
            this.serviceThread.Start();
            base.OnStart(args);
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            this.Stop();
            base.OnStop();
        }

        protected void ServiceMain()
        {
            while (true)
            {
                //TODO: get the data from base, convert to XML and send to FTP

                Thread.Sleep(this.delay);
            }
        }
    }
}
