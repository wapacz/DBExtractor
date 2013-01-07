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
            this.service.Dispose();

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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pLeftSideImage = new System.Windows.Forms.Panel();
            this.panelLinks = new System.Windows.Forms.Panel();
            this.llEventsConfig = new System.Windows.Forms.LinkLabel();
            this.llSqlConfig = new System.Windows.Forms.LinkLabel();
            this.llServiceConfig = new System.Windows.Forms.LinkLabel();
            this.llFtpConfig = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
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
            this.splitContainer.Size = new System.Drawing.Size(846, 543);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 2;
            // 
            // pLeftSideImage
            // 
            this.pLeftSideImage.BackgroundImage = global::ScheDEX.Properties.Resources.scheduled_tasks_3_128x128;
            this.pLeftSideImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pLeftSideImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pLeftSideImage.Location = new System.Drawing.Point(0, 367);
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
            this.llSqlConfig.Size = new System.Drawing.Size(146, 15);
            this.llSqlConfig.TabIndex = 3;
            this.llSqlConfig.TabStop = true;
            this.llSqlConfig.Text = "Konfiguracja bazy danych";
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
            this.llServiceConfig.Size = new System.Drawing.Size(121, 15);
            this.llServiceConfig.TabIndex = 3;
            this.llServiceConfig.TabStop = true;
            this.llServiceConfig.Text = "Informacje o usłudze";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 553);
            this.Controls.Add(this.splitContainer);
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
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelLinks.ResumeLayout(false);
            this.panelLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pLeftSideImage;
        private System.Windows.Forms.Panel panelLinks;
        private System.Windows.Forms.LinkLabel llEventsConfig;
        private System.Windows.Forms.LinkLabel llSqlConfig;
        private System.Windows.Forms.LinkLabel llServiceConfig;
        private System.Windows.Forms.LinkLabel llFtpConfig;
    }
}

