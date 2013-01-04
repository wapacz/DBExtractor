using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITSharp.ScheDEX.Common;

namespace ITSharp.ScheDEX
{
    public partial class EventsPanel : UserControl
    {
        private FormMain container;
        private ScheDEXSettings settings;
        
        public EventsPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void buttonSaveAndRun_Click(object sender, EventArgs e)
        {
            this.container.service.ExecuteCommand(250); // refresh events 
        }

        public FormMain ContainerForm
        {
            set
            {
                this.container = value;
                this.settings = value.settings;
            }
        }
    }
}
