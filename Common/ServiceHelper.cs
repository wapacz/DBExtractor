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
        
        private string serviceName;
        private ServiceController service;
        private bool isFound;
        private ServiceControllerStatus previousStatus;
        private Boolean forever;

        public ServiceHelper()
        {
            this.forever = true;
            this.isFound = false;
        }

        public ServiceHelper(string serviceName)
        {
            this.serviceName = serviceName;
            this.isFound = false;
            this.service = this.Find(serviceName);
        }

        public void Dispose()
        {
            this.forever = false;
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

                    return service;
                }

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
                args.IsWorking = this.ServiceStatusToBoolean;
                ServiceStatusChangedEvent(this.service, args);
            }
            this.previousStatus = this.service.Status;

            while (this.forever)
            {
                this.service.Refresh();
                if (this.service.Status != this.previousStatus)
                {
                    if (ServiceStatusChangedEvent != null)
                    {
                        args.Status = this.service.Status;
                        args.IsWorking = this.ServiceStatusToBoolean;
                        ServiceStatusChangedEvent(this.service, args);
                    }
                    this.previousStatus = this.service.Status;
                }
                Thread.Sleep(1000);
            }
        }

        private Boolean ServiceStatusToBoolean
        {
            get
            {
                switch (this.service.Status)
                {
                    case ServiceControllerStatus.Running:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public void ExecuteCommand(int command)
        {
            try
            {
                this.service.ExecuteCommand(command);
            }
            catch (Exception)
            {
                // skip fault
            }
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

        private Boolean is_working;
        public Boolean IsWorking
        {
            get { return this.is_working; }
            set { this.is_working = value; }
        }
    }
}
