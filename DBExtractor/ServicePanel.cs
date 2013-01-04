using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITSharp.ScheDEX.Common;
using ITSharp.ScheDEX.GUI;

namespace ITSharp.ScheDEX
{
    public partial class ServicePanel : UserControl
    {
        internal FormMain container;
        private ScheDEXSettings settings;
        internal ServiceHelper service;

        public ServicePanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            /*
             * Initialize FTP helper
             */
            this.service = new ServiceHelper();
            this.service.ServiceStatusChangedEvent += new EventHandler<ServiceStatusEventArgs>(service_StatusChangedEvent);
            this.service.FindingEvent += new EventHandler<ServiceEventArgs>(service_FindingEvent);

        }

        private void ServicePanel_Load(object sender, EventArgs e)
        {
            /*
             * Fetching related service handler
             */
            this.service.Find("ScheDEX");
            this.service.StartServiceWatcher();
        }

        private void service_StatusChangedEvent(object sender, ServiceStatusEventArgs args)
        {
            this.lServiceStatus2.InvokeIfRequired(() =>
            {
                this.lServiceStatus2.Text = "Status: " + args.Status.ToString();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void service_FindingEvent(object sender, ServiceEventArgs args)
        {
            if (args.IsSuccess)
            {
                this.lServiceStatus.InvokeIfRequired(() =>
                {
                    this.lServiceStatus.Text = "Usługa pracuje prawidłowo.";
                });
            }
            else
            {
                this.lServiceStatus.InvokeIfRequired(() =>
                {
                    this.lServiceStatus.Text = "Usługa nie pracuje.";
                });
            }
        }

        private void bRestartService_Click(object sender, EventArgs e)
        {
            this.service.ExecuteCommand(250); // refresh data
        }

        public FormMain ContainerForm
        {
            set
            {
                this.container = value;
                this.settings = value.settings; 
                value.service = this.service;
            }
        }
    }
}
