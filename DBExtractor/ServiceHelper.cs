using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace DBExtractor
{
    class ServiceHelper
    {
        private string serviceName;
        private ServiceController service;
        private bool isFound;

        public ServiceHelper(string serviceName)
        {
            this.serviceName = serviceName;
            this.service = this.Find(serviceName);
            this.isFound = false;
        }

        private enum Commands 
        { 
            StopWorker = 128, 
            RestartWorker, 
            CheckWorker 
        };

        private ServiceController Find(string serviceName)
        {
            foreach (ServiceController service in ServiceController.GetServices())
                if (service.ServiceName == serviceName)
                {
                    this.isFound = true;
                    return service;
                }

            throw new ServiceNotFoundException();
        }

        public bool IsFound
        {
            get
            {
                return this.isFound;
            }
        }
    }
}
