using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace DBExtractor
{
    public class DBExtractorService : ServiceBase
    {
        public const string MyServiceName = "DBExtractorService";

        public DBExtractorService()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ServiceName = MyServiceName;
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
            // TODO: Add start code here (if required) to start your service.
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Add tear-down code here (if required) to stop your service.
        }
    }
}
