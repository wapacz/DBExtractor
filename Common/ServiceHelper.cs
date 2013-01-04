using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Threading;

namespace ITSharp.ScheDEX.Common
{
    public class ServiceHelper
    {
        public event EventHandler<ServiceStatusEventArgs> ServiceStatusChangedEvent;
        public event EventHandler<ServiceEventArgs> FindingEvent;

        private string serviceName;
        private ServiceController service;
        private bool isFound;
        private ServiceControllerStatus previousStatus;

        public ServiceHelper()
        {
            this.isFound = false;
        }

        public ServiceHelper(string serviceName)
        {
            this.serviceName = serviceName;
            this.isFound = false;
            this.service = this.Find(serviceName);
        }

        private enum Commands 
        { 
            StopWorker = 128, 
            RestartWorker, 
            CheckWorker 
        };

        public void StartFind(string serviceName)
        {
            Thread thread = new Thread(new ThreadStart(() => Find(serviceName)));
            thread.Name = "FindService";
            thread.Start();
        }

        public ServiceController Find(string serviceName)
        {
            foreach (ServiceController service in ServiceController.GetServices())
                if (service.ServiceName == serviceName)
                {
                    this.isFound = true;
                    this.serviceName = serviceName;
                    this.service = service;
                    this.previousStatus = this.service.Status;
                    if (FindingEvent != null)
                        FindingEvent(service, ServiceEventArgs.Success);
                    return service;
                }

            if (FindingEvent != null)
                FindingEvent(this, ServiceEventArgs.Fail);

            throw new ServiceNotFoundException();
        }

        public void StartServiceWatcher()
        {
            Thread thread = new Thread(new ThreadStart(ServiceWatcher));
            thread.Name = "ServiceWatcher";
            thread.Start();
        }

        private void ServiceWatcher()
        {
            ServiceStatusEventArgs args = new ServiceStatusEventArgs();

            if (ServiceStatusChangedEvent != null)
            {
                args.Status = this.service.Status;
                ServiceStatusChangedEvent(this.service, args);
            }
            this.previousStatus = this.service.Status;

            while (true)
            {
                this.service.Refresh();
                if (this.service.Status != this.previousStatus)
                {
                    if (ServiceStatusChangedEvent != null)
                    {
                        args.Status = this.service.Status;
                        ServiceStatusChangedEvent(this.service, args);
                    }
                    this.previousStatus = this.service.Status;
                }
                Thread.Sleep(1000);
            }
        }

        public void ExecuteCommand(int command)
        {
            this.service.ExecuteCommand(command);
        }

        public bool IsFound
        {
            get
            {
                return this.isFound;
            }
        }
    }

    public class ServiceNotFoundException : Exception
    {
    }

    public class ServiceStatusEventArgs : EventArgs
    {
        private ServiceControllerStatus status;
        public ServiceControllerStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }

    public class ServiceEventArgs : EventArgs
    {
        private Boolean isSuccess;
        public Boolean IsSuccess
        {
            get { return this.isSuccess; }
            set { this.isSuccess = value; }
        }

        public static ServiceEventArgs Success
        {
            get
            {
                ServiceEventArgs args = new ServiceEventArgs();
                args.IsSuccess = true;
                return args;
            }
        }

        public static ServiceEventArgs Fail
        {
            get
            {
                ServiceEventArgs args = new ServiceEventArgs();
                args.IsSuccess = false;
                return args;
            }
        }
    }
}
