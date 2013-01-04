namespace ITSharp.ScheDEX
{
    partial class SqlPanel
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
            this.pbDatabasesLoader = new System.Windows.Forms.PictureBox();
            this.lDatabase = new System.Windows.Forms.Label();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.lServerName = new System.Windows.Forms.Label();
            this.pbServerNamesLoader = new System.Windows.Forms.PictureBox();
            this.cbServerNames = new System.Windows.Forms.ComboBox();
            this.pbConnecting = new System.Windows.Forms.PictureBox();
            this.bSQLConnect = new System.Windows.Forms.Button();
            this.rbAuthWindows = new System.Windows.Forms.RadioButton();
            this.tbSQLUserPass = new System.Windows.Forms.TextBox();
            this.rbAuthSQLServer = new System.Windows.Forms.RadioButton();
            this.tbSQLUserName = new System.Windows.Forms.TextBox();
            this.lAuth = new System.Windows.Forms.Label();
            this.lUserPass = new System.Windows.Forms.Label();
            this.lUserName = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDatabasesLoader
            // 
            this.pbDatabasesLoader.Enabled = false;
            this.pbDatabasesLoader.Image = global::ScheDEX.Properties.Resources.loader1;
            this.pbDatabasesLoader.Location = new System.Drawing.Point(155, 262);
            this.pbDatabasesLoader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbDatabasesLoader.Name = "pbDatabasesLoader";
            this.pbDatabasesLoader.Size = new System.Drawing.Size(19, 18);
            this.pbDatabasesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDatabasesLoader.TabIndex = 8;
            this.pbDatabasesLoader.TabStop = false;
            this.pbDatabasesLoader.Visible = false;
            // 
            // lDatabase
            // 
            this.lDatabase.AutoSize = true;
            this.lDatabase.Enabled = false;
            this.lDatabase.Location = new System.Drawing.Point(28, 266);
            this.lDatabase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lDatabase.Name = "lDatabase";
            this.lDatabase.Size = new System.Drawing.Size(80, 15);
            this.lDatabase.TabIndex = 10;
            this.lDatabase.Text = "Baza danych:";
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.Enabled = false;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(151, 259);
            this.cbDatabases.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(254, 23);
            this.cbDatabases.TabIndex = 6;
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(28, 73);
            this.lServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(95, 15);
            this.lServerName.TabIndex = 11;
            this.lServerName.Text = "Nazwa serwera:";
            // 
            // pbServerNamesLoader
            // 
            this.pbServerNamesLoader.Image = global::ScheDEX.Properties.Resources.loader1;
            this.pbServerNamesLoader.Location = new System.Drawing.Point(155, 67);
            this.pbServerNamesLoader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbServerNamesLoader.Name = "pbServerNamesLoader";
            this.pbServerNamesLoader.Size = new System.Drawing.Size(19, 18);
            this.pbServerNamesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbServerNamesLoader.TabIndex = 8;
            this.pbServerNamesLoader.TabStop = false;
            this.pbServerNamesLoader.Visible = false;
            // 
            // cbServerNames
            // 
            this.cbServerNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServerNames.Enabled = false;
            this.cbServerNames.FormattingEnabled = true;
            this.cbServerNames.Location = new System.Drawing.Point(151, 64);
            this.cbServerNames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbServerNames.Name = "cbServerNames";
            this.cbServerNames.Size = new System.Drawing.Size(195, 23);
            this.cbServerNames.TabIndex = 0;
            // 
            // pbConnecting
            // 
            this.pbConnecting.Image = global::ScheDEX.Properties.Resources.loader1;
            this.pbConnecting.Location = new System.Drawing.Point(156, 194);
            this.pbConnecting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbConnecting.Name = "pbConnecting";
            this.pbConnecting.Size = new System.Drawing.Size(19, 18);
            this.pbConnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConnecting.TabIndex = 8;
            this.pbConnecting.TabStop = false;
            this.pbConnecting.Visible = false;
            // 
            // bSQLConnect
            // 
            this.bSQLConnect.Enabled = false;
            this.bSQLConnect.Location = new System.Drawing.Point(151, 189);
            this.bSQLConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bSQLConnect.Name = "bSQLConnect";
            this.bSQLConnect.Size = new System.Drawing.Size(254, 28);
            this.bSQLConnect.TabIndex = 5;
            this.bSQLConnect.Text = "Połącz i pobierz dane o bazie";
            this.bSQLConnect.UseVisualStyleBackColor = true;
            this.bSQLConnect.Click += new System.EventHandler(this.bSQLConnect_Click);
            // 
            // rbAuthWindows
            // 
            this.rbAuthWindows.AutoSize = true;
            this.rbAuthWindows.Checked = true;
            this.rbAuthWindows.Enabled = false;
            this.rbAuthWindows.Location = new System.Drawing.Point(161, 101);
            this.rbAuthWindows.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbAuthWindows.Name = "rbAuthWindows";
            this.rbAuthWindows.Size = new System.Drawing.Size(75, 19);
            this.rbAuthWindows.TabIndex = 1;
            this.rbAuthWindows.TabStop = true;
            this.rbAuthWindows.Text = "Windows";
            this.rbAuthWindows.UseVisualStyleBackColor = true;
            this.rbAuthWindows.CheckedChanged += new System.EventHandler(this.rbAuthWindows_CheckedChanged);
            // 
            // tbSQLUserPass
            // 
            this.tbSQLUserPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSQLUserPass.Enabled = false;
            this.tbSQLUserPass.Location = new System.Drawing.Point(151, 159);
            this.tbSQLUserPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSQLUserPass.Name = "tbSQLUserPass";
            this.tbSQLUserPass.PasswordChar = '•';
            this.tbSQLUserPass.Size = new System.Drawing.Size(252, 21);
            this.tbSQLUserPass.TabIndex = 4;
            // 
            // rbAuthSQLServer
            // 
            this.rbAuthSQLServer.AutoSize = true;
            this.rbAuthSQLServer.Enabled = false;
            this.rbAuthSQLServer.Location = new System.Drawing.Point(260, 101);
            this.rbAuthSQLServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbAuthSQLServer.Name = "rbAuthSQLServer";
            this.rbAuthSQLServer.Size = new System.Drawing.Size(91, 19);
            this.rbAuthSQLServer.TabIndex = 2;
            this.rbAuthSQLServer.Text = "SQL Serwer";
            this.rbAuthSQLServer.UseVisualStyleBackColor = true;
            this.rbAuthSQLServer.CheckedChanged += new System.EventHandler(this.rbAuthSQLServer_CheckedChanged);
            // 
            // tbSQLUserName
            // 
            this.tbSQLUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserName.Location = new System.Drawing.Point(151, 126);
            this.tbSQLUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSQLUserName.Name = "tbSQLUserName";
            this.tbSQLUserName.Size = new System.Drawing.Size(252, 21);
            this.tbSQLUserName.TabIndex = 3;
            // 
            // lAuth
            // 
            this.lAuth.AutoSize = true;
            this.lAuth.Enabled = false;
            this.lAuth.Location = new System.Drawing.Point(28, 103);
            this.lAuth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAuth.Name = "lAuth";
            this.lAuth.Size = new System.Drawing.Size(72, 15);
            this.lAuth.TabIndex = 12;
            this.lAuth.Text = "Autoryzacja:";
            // 
            // lUserPass
            // 
            this.lUserPass.AutoSize = true;
            this.lUserPass.Enabled = false;
            this.lUserPass.Location = new System.Drawing.Point(28, 167);
            this.lUserPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lUserPass.Name = "lUserPass";
            this.lUserPass.Size = new System.Drawing.Size(111, 15);
            this.lUserPass.TabIndex = 15;
            this.lUserPass.Text = "Hasło użytkownika:";
            // 
            // lUserName
            // 
            this.lUserName.AutoSize = true;
            this.lUserName.Enabled = false;
            this.lUserName.Location = new System.Drawing.Point(28, 135);
            this.lUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lUserName.Name = "lUserName";
            this.lUserName.Size = new System.Drawing.Size(117, 15);
            this.lUserName.TabIndex = 14;
            this.lUserName.Text = "Nazwa użytkownika:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(22, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(239, 24);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Konfiguracja baz danych";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Odświerz";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 72);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(241, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 72);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "Zapisz połączenie";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SqlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbServerNamesLoader);
            this.Controls.Add(this.pbConnecting);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pbDatabasesLoader);
            this.Controls.Add(this.bSQLConnect);
            this.Controls.Add(this.cbServerNames);
            this.Controls.Add(this.lDatabase);
            this.Controls.Add(this.lUserName);
            this.Controls.Add(this.rbAuthWindows);
            this.Controls.Add(this.lUserPass);
            this.Controls.Add(this.lServerName);
            this.Controls.Add(this.lAuth);
            this.Controls.Add(this.tbSQLUserPass);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.tbSQLUserName);
            this.Controls.Add(this.rbAuthSQLServer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SqlPanel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(451, 441);
            this.Load += new System.EventHandler(this.SqlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbConnecting;
        private System.Windows.Forms.Button bSQLConnect;
        private System.Windows.Forms.RadioButton rbAuthWindows;
        private System.Windows.Forms.TextBox tbSQLUserPass;
        private System.Windows.Forms.RadioButton rbAuthSQLServer;
        private System.Windows.Forms.TextBox tbSQLUserName;
        private System.Windows.Forms.Label lAuth;
        private System.Windows.Forms.Label lUserPass;
        private System.Windows.Forms.Label lUserName;
        private System.Windows.Forms.PictureBox pbDatabasesLoader;
        private System.Windows.Forms.Label lDatabase;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.Label lServerName;
        private System.Windows.Forms.PictureBox pbServerNamesLoader;
        private System.Windows.Forms.ComboBox cbServerNames;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
    }
}
