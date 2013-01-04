namespace ITSharp.ScheDEX
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pLeftSideImage = new System.Windows.Forms.Panel();
            this.panelLinks = new System.Windows.Forms.Panel();
            this.llEventsConfig = new System.Windows.Forms.LinkLabel();
            this.llSqlConfig = new System.Windows.Forms.LinkLabel();
            this.llServiceConfig = new System.Windows.Forms.LinkLabel();
            this.llFtpConfig = new System.Windows.Forms.LinkLabel();
            this.eventsP = new ITSharp.ScheDEX.EventsPanel();
            this.sqlP = new ITSharp.ScheDEX.SqlPanel();
            this.ftpP = new ITSharp.ScheDEX.FtpPanel();
            this.serviceP = new ITSharp.ScheDEX.ServicePanel();
            this.contextMenuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Hello";
            this.notifyIcon1.BalloonTipTitle = "Title";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScheDEX";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 54);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "O programie...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeToolStripMenuItem.Text = "Zamknij";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new System.Drawing.Point(5, 526);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(692, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(5, 5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer.Panel1.Controls.Add(this.pLeftSideImage);
            this.splitContainer.Panel1.Controls.Add(this.panelLinks);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.eventsP);
            this.splitContainer.Panel2.Controls.Add(this.sqlP);
            this.splitContainer.Panel2.Controls.Add(this.ftpP);
            this.splitContainer.Panel2.Controls.Add(this.serviceP);
            this.splitContainer.Size = new System.Drawing.Size(692, 521);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 2;
            // 
            // pLeftSideImage
            // 
            this.pLeftSideImage.BackgroundImage = global::ScheDEX.Properties.Resources.scheduled_tasks_3_128x128;
            this.pLeftSideImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pLeftSideImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pLeftSideImage.Location = new System.Drawing.Point(0, 345);
            this.pLeftSideImage.Name = "pLeftSideImage";
            this.pLeftSideImage.Size = new System.Drawing.Size(198, 174);
            this.pLeftSideImage.TabIndex = 3;
            // 
            // panelLinks
            // 
            this.panelLinks.Controls.Add(this.llEventsConfig);
            this.panelLinks.Controls.Add(this.llSqlConfig);
            this.panelLinks.Controls.Add(this.llServiceConfig);
            this.panelLinks.Controls.Add(this.llFtpConfig);
            this.panelLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinks.Location = new System.Drawing.Point(0, 0);
            this.panelLinks.Name = "panelLinks";
            this.panelLinks.Size = new System.Drawing.Size(198, 177);
            this.panelLinks.TabIndex = 4;
            // 
            // llEventsConfig
            // 
            this.llEventsConfig.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.llEventsConfig.AutoSize = true;
            this.llEventsConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.llEventsConfig.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llEventsConfig.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llEventsConfig.Location = new System.Drawing.Point(13, 17);
            this.llEventsConfig.Name = "llEventsConfig";
            this.llEventsConfig.Size = new System.Drawing.Size(143, 15);
            this.llEventsConfig.TabIndex = 3;
            this.llEventsConfig.TabStop = true;
            this.llEventsConfig.Text = "Konfiguracja zdarzeń";
            this.llEventsConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // llSqlConfig
            // 
            this.llSqlConfig.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.llSqlConfig.AutoSize = true;
            this.llSqlConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.llSqlConfig.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llSqlConfig.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llSqlConfig.Location = new System.Drawing.Point(13, 43);
            this.llSqlConfig.Name = "llSqlConfig";
            this.llSqlConfig.Size = new System.Drawing.Size(141, 15);
            this.llSqlConfig.TabIndex = 3;
            this.llSqlConfig.TabStop = true;
            this.llSqlConfig.Text = "Konfiguracja baz danych";
            this.llSqlConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // llServiceConfig
            // 
            this.llServiceConfig.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.llServiceConfig.AutoSize = true;
            this.llServiceConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.llServiceConfig.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llServiceConfig.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llServiceConfig.Location = new System.Drawing.Point(13, 96);
            this.llServiceConfig.Name = "llServiceConfig";
            this.llServiceConfig.Size = new System.Drawing.Size(115, 15);
            this.llServiceConfig.TabIndex = 3;
            this.llServiceConfig.TabStop = true;
            this.llServiceConfig.Text = "Zarządzanie usługą";
            this.llServiceConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // llFtpConfig
            // 
            this.llFtpConfig.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.llFtpConfig.AutoSize = true;
            this.llFtpConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.llFtpConfig.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llFtpConfig.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llFtpConfig.Location = new System.Drawing.Point(13, 70);
            this.llFtpConfig.Name = "llFtpConfig";
            this.llFtpConfig.Size = new System.Drawing.Size(148, 15);
            this.llFtpConfig.TabIndex = 3;
            this.llFtpConfig.TabStop = true;
            this.llFtpConfig.Text = "Konfiguracja serwera FTP";
            this.llFtpConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // eventsP
            // 
            this.eventsP.BackColor = System.Drawing.Color.White;
            this.eventsP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eventsP.Location = new System.Drawing.Point(0, 0);
            this.eventsP.Name = "eventsP";
            this.eventsP.Size = new System.Drawing.Size(485, 519);
            this.eventsP.TabIndex = 3;
            // 
            // sqlP
            // 
            this.sqlP.BackColor = System.Drawing.Color.White;
            this.sqlP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sqlP.Location = new System.Drawing.Point(0, 0);
            this.sqlP.Name = "sqlP";
            this.sqlP.Size = new System.Drawing.Size(485, 519);
            this.sqlP.TabIndex = 6;
            // 
            // ftpP
            // 
            this.ftpP.BackColor = System.Drawing.Color.White;
            this.ftpP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftpP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ftpP.Location = new System.Drawing.Point(0, 0);
            this.ftpP.Name = "ftpP";
            this.ftpP.Size = new System.Drawing.Size(485, 519);
            this.ftpP.TabIndex = 4;
            // 
            // serviceP
            // 
            this.serviceP.BackColor = System.Drawing.Color.White;
            this.serviceP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serviceP.Location = new System.Drawing.Point(0, 0);
            this.serviceP.Name = "serviceP";
            this.serviceP.Size = new System.Drawing.Size(485, 519);
            this.serviceP.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 553);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "ScheDEX";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelLinks.ResumeLayout(false);
            this.panelLinks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private EventsPanel eventsP;
        private FtpPanel ftpP;
        private ServicePanel serviceP;
        private SqlPanel sqlP;
        private System.Windows.Forms.Panel pLeftSideImage;
        private System.Windows.Forms.Panel panelLinks;
        private System.Windows.Forms.LinkLabel llEventsConfig;
        private System.Windows.Forms.LinkLabel llSqlConfig;
        private System.Windows.Forms.LinkLabel llServiceConfig;
        private System.Windows.Forms.LinkLabel llFtpConfig;
    }
}

