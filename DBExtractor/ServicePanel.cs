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
        private FormMain container;
        private ScheDEXSettings settings;
        internal ServiceHelper service;

        public ServicePanel(FormMain container)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.container = container;
            this.settings = container.settings;

            /*
             * Initialize FTP helper
             */
            this.service = new ServiceHelper();
            this.service.ServiceStatusChangedEvent += new EventHandler<ServiceStatusEventArgs>(service_StatusChangedEvent);
            container.service = this.service;
        }

        private void ServicePanel_Load(object sender, EventArgs e)
        {
            try
            {
                /*
                 * Fetching related service handler
                 */
                this.service.Find("ScheDEX");
                this.service.StartServiceWatcher();
            }
            catch (ServiceNotFoundException)
            {
                this.lServiceStatus.Text = "Usługa nie pracuje prawidłowo.";
                this.lServiceStatus2.Text = "Status: nie znaleziono usługi w systemie";
            }
        }

        private void service_StatusChangedEvent(object sender, ServiceStatusEventArgs args)
        {
            if (args.IsWorking)
            {
                this.lServiceStatus.InvokeIfRequired(() =>
                {
                    this.lServiceStatus.Text = "Usługa pracuje prawidłowo";
                    this.lServiceStatus2.Text = "Status: " + args.Status.ToString();
                });
            }
            else
            {
                this.lServiceStatus.InvokeIfRequired(() =>
                {
                    this.lServiceStatus.Text = "Usługa nie pracuje prawidłowo.";
                    this.lServiceStatus2.Text = "Status: " + args.Status.ToString();
                });
            }
        }

        private void bRefreshtService_Click(object sender, EventArgs e)
        {
            this.service.ExecuteCommand(250); // refresh data
        }
    }
}
