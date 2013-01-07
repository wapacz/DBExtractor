namespace ITSharp.ScheDEX
{
    partial class EventsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lFileName = new System.Windows.Forms.Label();
            this.tbXMLFileName = new System.Windows.Forms.TextBox();
            this.lInterval = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.lbScheduleEvents = new System.Windows.Forms.ListBox();
            this.bSaveScheduleEvent = new System.Windows.Forms.Button();
            this.bRemoveScheduleEvent = new System.Windows.Forms.Button();
            this.buttonSaveAndRun = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbQuery = new System.Windows.Forms.ComboBox();
            this.cbDBConnections = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFtp = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(13, 182);
            this.lFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(77, 15);
            this.lFileName.TabIndex = 165;
            this.lFileName.Text = "Nazwa pliku:";
            // 
            // tbXMLFileName
            // 
            this.tbXMLFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbXMLFileName.Location = new System.Drawing.Point(175, 180);
            this.tbXMLFileName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbXMLFileName.Name = "tbXMLFileName";
            this.tbXMLFileName.Size = new System.Drawing.Size(444, 21);
            this.tbXMLFileName.TabIndex = 164;
            // 
            // lInterval
            // 
            this.lInterval.AutoSize = true;
            this.lInterval.Location = new System.Drawing.Point(13, 151);
            this.lInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInterval.Name = "lInterval";
            this.lInterval.Size = new System.Drawing.Size(119, 15);
            this.lInterval.TabIndex = 1;
            this.lInterval.Text = "Interwał w minutach:";
            // 
            // tbInterval
            // 
            this.tbInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInterval.Location = new System.Drawing.Point(175, 149);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(444, 21);
            this.tbInterval.TabIndex = 13;
            this.tbInterval.Text = "60";
            // 
            // lbScheduleEvents
            // 
            this.lbScheduleEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbScheduleEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScheduleEvents.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScheduleEvents.FormattingEnabled = true;
            this.lbScheduleEvents.ItemHeight = 14;
            this.lbScheduleEvents.Location = new System.Drawing.Point(0, 0);
            this.lbScheduleEvents.Margin = new System.Windows.Forms.Padding(15);
            this.lbScheduleEvents.Name = "lbScheduleEvents";
            this.lbScheduleEvents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbScheduleEvents.Size = new System.Drawing.Size(630, 217);
            this.lbScheduleEvents.TabIndex = 169;
            // 
            // bSaveScheduleEvent
            // 
            this.bSaveScheduleEvent.Location = new System.Drawing.Point(358, 207);
            this.bSaveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bSaveScheduleEvent.Name = "bSaveScheduleEvent";
            this.bSaveScheduleEvent.Size = new System.Drawing.Size(130, 27);
            this.bSaveScheduleEvent.TabIndex = 167;
            this.bSaveScheduleEvent.Text = "Dodaj zdarzenie";
            this.bSaveScheduleEvent.UseVisualStyleBackColor = true;
            this.bSaveScheduleEvent.Click += new System.EventHandler(this.bSaveScheduleEvent_Click);
            // 
            // bRemoveScheduleEvent
            // 
            this.bRemoveScheduleEvent.Location = new System.Drawing.Point(490, 207);
            this.bRemoveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bRemoveScheduleEvent.Name = "bRemoveScheduleEvent";
            this.bRemoveScheduleEvent.Size = new System.Drawing.Size(129, 27);
            this.bRemoveScheduleEvent.TabIndex = 166;
            this.bRemoveScheduleEvent.Text = "Usuń zdarzenie";
            this.bRemoveScheduleEvent.UseVisualStyleBackColor = true;
            this.bRemoveScheduleEvent.Click += new System.EventHandler(this.bRemoveScheduleEvent_Click);
            // 
            // buttonSaveAndRun
            // 
            this.buttonSaveAndRun.Location = new System.Drawing.Point(78, 16);
            this.buttonSaveAndRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSaveAndRun.Name = "buttonSaveAndRun";
            this.buttonSaveAndRun.Size = new System.Drawing.Size(250, 28);
            this.buttonSaveAndRun.TabIndex = 168;
            this.buttonSaveAndRun.Text = "Zapisz i uruchom";
            this.buttonSaveAndRun.UseVisualStyleBackColor = true;
            this.buttonSaveAndRun.Click += new System.EventHandler(this.buttonSaveAndRun_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(206, 24);
            this.labelTitle.TabIndex = 170;
            this.labelTitle.Text = "Konfiguracja zdarzeń";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 44);
            this.panel1.TabIndex = 171;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSaveAndRun);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(305, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 44);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbQuery);
            this.panel3.Controls.Add(this.cbDBConnections);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lInterval);
            this.panel3.Controls.Add(this.tbInterval);
            this.panel3.Controls.Add(this.labelTitle);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.tbFtp);
            this.panel3.Controls.Add(this.tbXMLFileName);
            this.panel3.Controls.Add(this.lFileName);
            this.panel3.Controls.Add(this.bSaveScheduleEvent);
            this.panel3.Controls.Add(this.bRemoveScheduleEvent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(632, 247);
            this.panel3.TabIndex = 172;
            // 
            // cbQuery
            // 
            this.cbQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuery.FormattingEnabled = true;
            this.cbQuery.Location = new System.Drawing.Point(175, 86);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(444, 23);
            this.cbQuery.TabIndex = 171;
            // 
            // cbDBConnections
            // 
            this.cbDBConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDBConnections.FormattingEnabled = true;
            this.cbDBConnections.Location = new System.Drawing.Point(175, 55);
            this.cbDBConnections.Name = "cbDBConnections";
            this.cbDBConnections.Size = new System.Drawing.Size(444, 23);
            this.cbDBConnections.TabIndex = 171;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Połącznie z bazą danych:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 165;
            this.label3.Text = "Serwer FTP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 165;
            this.label1.Text = "Kwerenda:";
            // 
            // tbFtp
            // 
            this.tbFtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFtp.Enabled = false;
            this.tbFtp.Location = new System.Drawing.Point(175, 118);
            this.tbFtp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFtp.Name = "tbFtp";
            this.tbFtp.Size = new System.Drawing.Size(444, 21);
            this.tbFtp.TabIndex = 164;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbScheduleEvents);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 257);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(632, 219);
            this.panel4.TabIndex = 173;
            // 
            // EventsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "EventsPanel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(652, 530);
            this.Load += new System.EventHandler(this.EventsPanel_Load);
            this.VisibleChanged += new System.EventHandler(this.EventsPanel_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.TextBox tbXMLFileName;
        private System.Windows.Forms.Label lInterval;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.ListBox lbScheduleEvents;
        private System.Windows.Forms.Button bSaveScheduleEvent;
        private System.Windows.Forms.Button bRemoveScheduleEvent;
        private System.Windows.Forms.Button buttonSaveAndRun;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbQuery;
        private System.Windows.Forms.ComboBox cbDBConnections;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFtp;
        private System.Windows.Forms.Panel panel4;
    }
}
