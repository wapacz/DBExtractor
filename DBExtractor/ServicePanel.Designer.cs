namespace ITSharp.ScheDEX
{
    partial class ServicePanel
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
            this.lServiceStatus = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.bRefreshService = new System.Windows.Forms.Button();
            this.lServiceStatus2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lServiceStatus
            // 
            this.lServiceStatus.AutoSize = true;
            this.lServiceStatus.Location = new System.Drawing.Point(23, 68);
            this.lServiceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lServiceStatus.Name = "lServiceStatus";
            this.lServiceStatus.Size = new System.Drawing.Size(153, 15);
            this.lServiceStatus.TabIndex = 0;
            this.lServiceStatus.Text = "Wystąpił problem z usługą.";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(22, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(208, 24);
            this.labelTitle.TabIndex = 13;
            this.labelTitle.Text = "Informacje o usłudze";
            // 
            // bRefreshService
            // 
            this.bRefreshService.Location = new System.Drawing.Point(26, 129);
            this.bRefreshService.Name = "bRefreshService";
            this.bRefreshService.Size = new System.Drawing.Size(192, 23);
            this.bRefreshService.TabIndex = 14;
            this.bRefreshService.Text = "Odśwież dane w usłudze";
            this.bRefreshService.UseVisualStyleBackColor = true;
            this.bRefreshService.Click += new System.EventHandler(this.bRefreshtService_Click);
            // 
            // lServiceStatus2
            // 
            this.lServiceStatus2.AutoSize = true;
            this.lServiceStatus2.Location = new System.Drawing.Point(23, 92);
            this.lServiceStatus2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lServiceStatus2.Name = "lServiceStatus2";
            this.lServiceStatus2.Size = new System.Drawing.Size(16, 15);
            this.lServiceStatus2.TabIndex = 0;
            this.lServiceStatus2.Text = "...";
            // 
            // ServicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bRefreshService);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.lServiceStatus2);
            this.Controls.Add(this.lServiceStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "ServicePanel";
            this.Size = new System.Drawing.Size(465, 428);
            this.Load += new System.EventHandler(this.ServicePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lServiceStatus;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button bRefreshService;
        internal System.Windows.Forms.Label lServiceStatus2;
    }
}
