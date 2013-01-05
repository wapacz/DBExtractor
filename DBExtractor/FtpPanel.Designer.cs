namespace ITSharp.ScheDEX
{
    partial class FtpPanel
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
            this.pbFTPConnectTest = new System.Windows.Forms.PictureBox();
            this.lFTPRemotePath = new System.Windows.Forms.Label();
            this.lFTPUserPass = new System.Windows.Forms.Label();
            this.lFTPUserName = new System.Windows.Forms.Label();
            this.lFTPAddress = new System.Windows.Forms.Label();
            this.bFTPConnectTest = new System.Windows.Forms.Button();
            this.tbFTPRemotePath = new System.Windows.Forms.TextBox();
            this.tbFTPUserPass = new System.Windows.Forms.TextBox();
            this.tbFTPUserName = new System.Windows.Forms.TextBox();
            this.tbFTPAdress = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFTPConnectTest
            // 
            this.pbFTPConnectTest.Image = global::ScheDEX.Properties.Resources.loader1;
            this.pbFTPConnectTest.Location = new System.Drawing.Point(75, 134);
            this.pbFTPConnectTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbFTPConnectTest.Name = "pbFTPConnectTest";
            this.pbFTPConnectTest.Size = new System.Drawing.Size(19, 18);
            this.pbFTPConnectTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFTPConnectTest.TabIndex = 8;
            this.pbFTPConnectTest.TabStop = false;
            this.pbFTPConnectTest.Visible = false;
            // 
            // lFTPRemotePath
            // 
            this.lFTPRemotePath.AutoSize = true;
            this.lFTPRemotePath.Location = new System.Drawing.Point(23, 170);
            this.lFTPRemotePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPRemotePath.Name = "lFTPRemotePath";
            this.lFTPRemotePath.Size = new System.Drawing.Size(123, 15);
            this.lFTPRemotePath.TabIndex = 2;
            this.lFTPRemotePath.Text = "Ścieżka na serwerze:";
            // 
            // lFTPUserPass
            // 
            this.lFTPUserPass.AutoSize = true;
            this.lFTPUserPass.Location = new System.Drawing.Point(23, 138);
            this.lFTPUserPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPUserPass.Name = "lFTPUserPass";
            this.lFTPUserPass.Size = new System.Drawing.Size(111, 15);
            this.lFTPUserPass.TabIndex = 2;
            this.lFTPUserPass.Text = "Hasło użytkownika:";
            // 
            // lFTPUserName
            // 
            this.lFTPUserName.AutoSize = true;
            this.lFTPUserName.Location = new System.Drawing.Point(23, 106);
            this.lFTPUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPUserName.Name = "lFTPUserName";
            this.lFTPUserName.Size = new System.Drawing.Size(117, 15);
            this.lFTPUserName.TabIndex = 2;
            this.lFTPUserName.Text = "Nazwa użytkownika:";
            // 
            // lFTPAddress
            // 
            this.lFTPAddress.AutoSize = true;
            this.lFTPAddress.Location = new System.Drawing.Point(23, 73);
            this.lFTPAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPAddress.Name = "lFTPAddress";
            this.lFTPAddress.Size = new System.Drawing.Size(88, 15);
            this.lFTPAddress.TabIndex = 2;
            this.lFTPAddress.Text = "Adres serwera:";
            // 
            // bFTPConnectTest
            // 
            this.bFTPConnectTest.Location = new System.Drawing.Point(71, 128);
            this.bFTPConnectTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bFTPConnectTest.Name = "bFTPConnectTest";
            this.bFTPConnectTest.Size = new System.Drawing.Size(250, 28);
            this.bFTPConnectTest.TabIndex = 12;
            this.bFTPConnectTest.Text = "Przetestuj połączenie FTP i zapisz";
            this.bFTPConnectTest.UseVisualStyleBackColor = true;
            this.bFTPConnectTest.Click += new System.EventHandler(this.bFTPConnectTest_Click);
            // 
            // tbFTPRemotePath
            // 
            this.tbFTPRemotePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFTPRemotePath.Location = new System.Drawing.Point(160, 168);
            this.tbFTPRemotePath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPRemotePath.Name = "tbFTPRemotePath";
            this.tbFTPRemotePath.Size = new System.Drawing.Size(295, 21);
            this.tbFTPRemotePath.TabIndex = 11;
            // 
            // tbFTPUserPass
            // 
            this.tbFTPUserPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFTPUserPass.Location = new System.Drawing.Point(160, 136);
            this.tbFTPUserPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPUserPass.Name = "tbFTPUserPass";
            this.tbFTPUserPass.PasswordChar = '•';
            this.tbFTPUserPass.Size = new System.Drawing.Size(295, 21);
            this.tbFTPUserPass.TabIndex = 10;
            // 
            // tbFTPUserName
            // 
            this.tbFTPUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFTPUserName.Location = new System.Drawing.Point(160, 104);
            this.tbFTPUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPUserName.Name = "tbFTPUserName";
            this.tbFTPUserName.Size = new System.Drawing.Size(295, 21);
            this.tbFTPUserName.TabIndex = 9;
            // 
            // tbFTPAdress
            // 
            this.tbFTPAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFTPAdress.Location = new System.Drawing.Point(160, 71);
            this.tbFTPAdress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPAdress.Name = "tbFTPAdress";
            this.tbFTPAdress.Size = new System.Drawing.Size(295, 21);
            this.tbFTPAdress.TabIndex = 8;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(22, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(251, 24);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = "Konfiguracja serwera FTP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 159);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbFTPConnectTest);
            this.panel2.Controls.Add(this.bFTPConnectTest);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(209, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 159);
            this.panel2.TabIndex = 0;
            // 
            // FtpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.lFTPRemotePath);
            this.Controls.Add(this.lFTPUserPass);
            this.Controls.Add(this.lFTPUserName);
            this.Controls.Add(this.tbFTPAdress);
            this.Controls.Add(this.lFTPAddress);
            this.Controls.Add(this.tbFTPUserName);
            this.Controls.Add(this.tbFTPUserPass);
            this.Controls.Add(this.tbFTPRemotePath);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "FtpPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(542, 494);
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFTPConnectTest;
        private System.Windows.Forms.Label lFTPRemotePath;
        private System.Windows.Forms.Label lFTPUserPass;
        private System.Windows.Forms.Label lFTPUserName;
        private System.Windows.Forms.Label lFTPAddress;
        private System.Windows.Forms.Button bFTPConnectTest;
        private System.Windows.Forms.TextBox tbFTPRemotePath;
        private System.Windows.Forms.TextBox tbFTPUserPass;
        private System.Windows.Forms.TextBox tbFTPUserName;
        private System.Windows.Forms.TextBox tbFTPAdress;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
