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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(22, 180);
            this.lFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(77, 15);
            this.lFileName.TabIndex = 165;
            this.lFileName.Text = "Nazwa pliku:";
            // 
            // tbXMLFileName
            // 
            this.tbXMLFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbXMLFileName.Location = new System.Drawing.Point(180, 178);
            this.tbXMLFileName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbXMLFileName.Name = "tbXMLFileName";
            this.tbXMLFileName.Size = new System.Drawing.Size(248, 21);
            this.tbXMLFileName.TabIndex = 164;
            // 
            // lInterval
            // 
            this.lInterval.AutoSize = true;
            this.lInterval.Location = new System.Drawing.Point(22, 149);
            this.lInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInterval.Name = "lInterval";
            this.lInterval.Size = new System.Drawing.Size(119, 15);
            this.lInterval.TabIndex = 1;
            this.lInterval.Text = "Interwał w minutach:";
            // 
            // tbInterval
            // 
            this.tbInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInterval.Location = new System.Drawing.Point(180, 147);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(248, 21);
            this.tbInterval.TabIndex = 13;
            this.tbInterval.Text = "60";
            // 
            // lbScheduleEvents
            // 
            this.lbScheduleEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbScheduleEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScheduleEvents.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScheduleEvents.FormattingEnabled = true;
            this.lbScheduleEvents.ItemHeight = 14;
            this.lbScheduleEvents.Location = new System.Drawing.Point(5, 283);
            this.lbScheduleEvents.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbScheduleEvents.Name = "lbScheduleEvents";
            this.lbScheduleEvents.Size = new System.Drawing.Size(463, 242);
            this.lbScheduleEvents.TabIndex = 169;
            // 
            // bSaveScheduleEvent
            // 
            this.bSaveScheduleEvent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bSaveScheduleEvent.Location = new System.Drawing.Point(179, 228);
            this.bSaveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bSaveScheduleEvent.Name = "bSaveScheduleEvent";
            this.bSaveScheduleEvent.Size = new System.Drawing.Size(139, 27);
            this.bSaveScheduleEvent.TabIndex = 167;
            this.bSaveScheduleEvent.Text = "Zapisz zdarzenie";
            this.bSaveScheduleEvent.UseVisualStyleBackColor = false;
            // 
            // bRemoveScheduleEvent
            // 
            this.bRemoveScheduleEvent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bRemoveScheduleEvent.Location = new System.Drawing.Point(322, 228);
            this.bRemoveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bRemoveScheduleEvent.Name = "bRemoveScheduleEvent";
            this.bRemoveScheduleEvent.Size = new System.Drawing.Size(139, 27);
            this.bRemoveScheduleEvent.TabIndex = 166;
            this.bRemoveScheduleEvent.Text = "Usuń zdarzenie";
            this.bRemoveScheduleEvent.UseVisualStyleBackColor = false;
            // 
            // buttonSaveAndRun
            // 
            this.buttonSaveAndRun.Location = new System.Drawing.Point(71, 12);
            this.buttonSaveAndRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSaveAndRun.Name = "buttonSaveAndRun";
            this.buttonSaveAndRun.Size = new System.Drawing.Size(149, 28);
            this.buttonSaveAndRun.TabIndex = 168;
            this.buttonSaveAndRun.Text = "Zapisz i uruchom";
            this.buttonSaveAndRun.UseVisualStyleBackColor = true;
            this.buttonSaveAndRun.Click += new System.EventHandler(this.buttonSaveAndRun_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(15, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(206, 24);
            this.labelTitle.TabIndex = 170;
            this.labelTitle.Text = "Konfiguracja zdarzeń";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 44);
            this.panel1.TabIndex = 171;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSaveAndRun);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(241, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 44);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lInterval);
            this.panel3.Controls.Add(this.tbInterval);
            this.panel3.Controls.Add(this.labelTitle);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.tbXMLFileName);
            this.panel3.Controls.Add(this.lFileName);
            this.panel3.Controls.Add(this.bSaveScheduleEvent);
            this.panel3.Controls.Add(this.bRemoveScheduleEvent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 278);
            this.panel3.TabIndex = 172;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(180, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(248, 23);
            this.comboBox2.TabIndex = 171;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(180, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 23);
            this.comboBox1.TabIndex = 171;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Połącznie z bazą danych:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 165;
            this.label3.Text = "Serwer FTP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 165;
            this.label1.Text = "Kwerenda:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(180, 116);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 21);
            this.textBox1.TabIndex = 164;
            // 
            // EventsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbScheduleEvents);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "EventsPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(473, 530);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
