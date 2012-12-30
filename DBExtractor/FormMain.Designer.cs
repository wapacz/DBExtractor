namespace ITSharp.DBExtractor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveAndRun = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbServerNames = new System.Windows.Forms.ComboBox();
            this.gbDBConnection = new System.Windows.Forms.GroupBox();
            this.pDBConnection = new System.Windows.Forms.Panel();
            this.pbConnecting = new System.Windows.Forms.PictureBox();
            this.bSQLConnect = new System.Windows.Forms.Button();
            this.rbAuthWindows = new System.Windows.Forms.RadioButton();
            this.tbSQLUserPass = new System.Windows.Forms.TextBox();
            this.rbAuthSQLServer = new System.Windows.Forms.RadioButton();
            this.tbSQLUserName = new System.Windows.Forms.TextBox();
            this.lAuth = new System.Windows.Forms.Label();
            this.lUserPass = new System.Windows.Forms.Label();
            this.lUserName = new System.Windows.Forms.Label();
            this.lServerName = new System.Windows.Forms.Label();
            this.pbServerNamesLoader = new System.Windows.Forms.PictureBox();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.pbDatabasesLoader = new System.Windows.Forms.PictureBox();
            this.lTables = new System.Windows.Forms.Label();
            this.lDatabase = new System.Windows.Forms.Label();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.gbFTP = new System.Windows.Forms.GroupBox();
            this.pbFTPConnectTest = new System.Windows.Forms.PictureBox();
            this.lFTPRemotePath = new System.Windows.Forms.Label();
            this.lFTPUserPass = new System.Windows.Forms.Label();
            this.lFTPUserName = new System.Windows.Forms.Label();
            this.lFTPAddress = new System.Windows.Forms.Label();
            this.bFTPConnectTest = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbFTPRemotePath = new System.Windows.Forms.TextBox();
            this.tbFTPUserPass = new System.Windows.Forms.TextBox();
            this.tbFTPUserName = new System.Windows.Forms.TextBox();
            this.tbFTPAdress = new System.Windows.Forms.TextBox();
            this.bSaveScheduleEvent = new System.Windows.Forms.Button();
            this.gbInterval = new System.Windows.Forms.GroupBox();
            this.lInterval = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.gbServiceManagement = new System.Windows.Forms.GroupBox();
            this.lServiceStatus = new System.Windows.Forms.Label();
            this.tbXMLFileName = new System.Windows.Forms.TextBox();
            this.lFileName = new System.Windows.Forms.Label();
            this.pDBData = new System.Windows.Forms.Panel();
            this.lbScheduleEvents = new System.Windows.Forms.ListBox();
            this.bRemoveScheduleEvent = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbDBConnection.SuspendLayout();
            this.pDBConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).BeginInit();
            this.gbFTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).BeginInit();
            this.gbInterval.SuspendLayout();
            this.gbServiceManagement.SuspendLayout();
            this.pDBData.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Hello";
            this.notifyIcon1.BalloonTipTitle = "Title";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DB Extractor";
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 54);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 676);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(1080, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1080, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // buttonSaveAndRun
            // 
            this.buttonSaveAndRun.Location = new System.Drawing.Point(542, 646);
            this.buttonSaveAndRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSaveAndRun.Name = "buttonSaveAndRun";
            this.buttonSaveAndRun.Size = new System.Drawing.Size(128, 24);
            this.buttonSaveAndRun.TabIndex = 30;
            this.buttonSaveAndRun.Text = "Zapisz i uruchom";
            this.buttonSaveAndRun.UseVisualStyleBackColor = true;
            this.buttonSaveAndRun.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbServerNames
            // 
            this.cbServerNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServerNames.Enabled = false;
            this.cbServerNames.FormattingEnabled = true;
            this.cbServerNames.Location = new System.Drawing.Point(116, 31);
            this.cbServerNames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbServerNames.Name = "cbServerNames";
            this.cbServerNames.Size = new System.Drawing.Size(186, 21);
            this.cbServerNames.TabIndex = 0;
            this.cbServerNames.SelectedIndexChanged += new System.EventHandler(this.cbServerNames_SelectedIndexChanged);
            // 
            // gbDBConnection
            // 
            this.gbDBConnection.Controls.Add(this.pDBConnection);
            this.gbDBConnection.Controls.Add(this.lServerName);
            this.gbDBConnection.Controls.Add(this.pbServerNamesLoader);
            this.gbDBConnection.Controls.Add(this.cbServerNames);
            this.gbDBConnection.Location = new System.Drawing.Point(12, 27);
            this.gbDBConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbDBConnection.Name = "gbDBConnection";
            this.gbDBConnection.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbDBConnection.Size = new System.Drawing.Size(311, 238);
            this.gbDBConnection.TabIndex = 70;
            this.gbDBConnection.TabStop = false;
            this.gbDBConnection.Text = "Konfiguracja MSSQL";
            // 
            // pDBConnection
            // 
            this.pDBConnection.Controls.Add(this.pbConnecting);
            this.pDBConnection.Controls.Add(this.bSQLConnect);
            this.pDBConnection.Controls.Add(this.rbAuthWindows);
            this.pDBConnection.Controls.Add(this.tbSQLUserPass);
            this.pDBConnection.Controls.Add(this.rbAuthSQLServer);
            this.pDBConnection.Controls.Add(this.tbSQLUserName);
            this.pDBConnection.Controls.Add(this.lAuth);
            this.pDBConnection.Controls.Add(this.lUserPass);
            this.pDBConnection.Controls.Add(this.lUserName);
            this.pDBConnection.Location = new System.Drawing.Point(7, 55);
            this.pDBConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pDBConnection.Name = "pDBConnection";
            this.pDBConnection.Size = new System.Drawing.Size(296, 138);
            this.pDBConnection.TabIndex = 16;
            // 
            // pbConnecting
            // 
            this.pbConnecting.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbConnecting.Location = new System.Drawing.Point(113, 93);
            this.pbConnecting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbConnecting.Name = "pbConnecting";
            this.pbConnecting.Size = new System.Drawing.Size(16, 16);
            this.pbConnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConnecting.TabIndex = 8;
            this.pbConnecting.TabStop = false;
            this.pbConnecting.Visible = false;
            // 
            // bSQLConnect
            // 
            this.bSQLConnect.Enabled = false;
            this.bSQLConnect.Location = new System.Drawing.Point(109, 89);
            this.bSQLConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bSQLConnect.Name = "bSQLConnect";
            this.bSQLConnect.Size = new System.Drawing.Size(187, 24);
            this.bSQLConnect.TabIndex = 5;
            this.bSQLConnect.Text = "Połącz i pobierz dane o bazie";
            this.bSQLConnect.UseVisualStyleBackColor = true;
            this.bSQLConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // rbAuthWindows
            // 
            this.rbAuthWindows.AutoSize = true;
            this.rbAuthWindows.Checked = true;
            this.rbAuthWindows.Enabled = false;
            this.rbAuthWindows.Location = new System.Drawing.Point(109, 6);
            this.rbAuthWindows.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbAuthWindows.Name = "rbAuthWindows";
            this.rbAuthWindows.Size = new System.Drawing.Size(69, 17);
            this.rbAuthWindows.TabIndex = 1;
            this.rbAuthWindows.TabStop = true;
            this.rbAuthWindows.Text = "Windows";
            this.rbAuthWindows.UseVisualStyleBackColor = true;
            this.rbAuthWindows.CheckedChanged += new System.EventHandler(this.rbAuthWindows_CheckedChanged);
            // 
            // tbSQLUserPass
            // 
            this.tbSQLUserPass.Enabled = false;
            this.tbSQLUserPass.Location = new System.Drawing.Point(109, 63);
            this.tbSQLUserPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSQLUserPass.Name = "tbSQLUserPass";
            this.tbSQLUserPass.PasswordChar = '•';
            this.tbSQLUserPass.Size = new System.Drawing.Size(186, 20);
            this.tbSQLUserPass.TabIndex = 4;
            // 
            // rbAuthSQLServer
            // 
            this.rbAuthSQLServer.AutoSize = true;
            this.rbAuthSQLServer.Enabled = false;
            this.rbAuthSQLServer.Location = new System.Drawing.Point(198, 6);
            this.rbAuthSQLServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbAuthSQLServer.Name = "rbAuthSQLServer";
            this.rbAuthSQLServer.Size = new System.Drawing.Size(82, 17);
            this.rbAuthSQLServer.TabIndex = 2;
            this.rbAuthSQLServer.Text = "SQL Serwer";
            this.rbAuthSQLServer.UseVisualStyleBackColor = true;
            this.rbAuthSQLServer.CheckedChanged += new System.EventHandler(this.rbAuthSQLServer_CheckedChanged);
            // 
            // tbSQLUserName
            // 
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserName.Location = new System.Drawing.Point(109, 35);
            this.tbSQLUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSQLUserName.Name = "tbSQLUserName";
            this.tbSQLUserName.Size = new System.Drawing.Size(186, 20);
            this.tbSQLUserName.TabIndex = 3;
            // 
            // lAuth
            // 
            this.lAuth.AutoSize = true;
            this.lAuth.Enabled = false;
            this.lAuth.Location = new System.Drawing.Point(-1, 10);
            this.lAuth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAuth.Name = "lAuth";
            this.lAuth.Size = new System.Drawing.Size(65, 13);
            this.lAuth.TabIndex = 12;
            this.lAuth.Text = "Autoryzacja:";
            // 
            // lUserPass
            // 
            this.lUserPass.AutoSize = true;
            this.lUserPass.Enabled = false;
            this.lUserPass.Location = new System.Drawing.Point(-1, 66);
            this.lUserPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lUserPass.Name = "lUserPass";
            this.lUserPass.Size = new System.Drawing.Size(101, 13);
            this.lUserPass.TabIndex = 15;
            this.lUserPass.Text = "Hasło użytkownika:";
            // 
            // lUserName
            // 
            this.lUserName.AutoSize = true;
            this.lUserName.Enabled = false;
            this.lUserName.Location = new System.Drawing.Point(-1, 38);
            this.lUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lUserName.Name = "lUserName";
            this.lUserName.Size = new System.Drawing.Size(105, 13);
            this.lUserName.TabIndex = 14;
            this.lUserName.Text = "Nazwa użytkownika:";
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(6, 34);
            this.lServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(83, 13);
            this.lServerName.TabIndex = 11;
            this.lServerName.Text = "Nazwa serwera:";
            // 
            // pbServerNamesLoader
            // 
            this.pbServerNamesLoader.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbServerNamesLoader.Location = new System.Drawing.Point(119, 33);
            this.pbServerNamesLoader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbServerNamesLoader.Name = "pbServerNamesLoader";
            this.pbServerNamesLoader.Size = new System.Drawing.Size(16, 16);
            this.pbServerNamesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbServerNamesLoader.TabIndex = 8;
            this.pbServerNamesLoader.TabStop = false;
            this.pbServerNamesLoader.Visible = false;
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.Enabled = false;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(110, 5);
            this.cbDatabases.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(186, 21);
            this.cbDatabases.TabIndex = 6;
            this.cbDatabases.SelectedIndexChanged += new System.EventHandler(this.cbDatabases_SelectedIndexChanged);
            // 
            // pbDatabasesLoader
            // 
            this.pbDatabasesLoader.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbDatabasesLoader.Location = new System.Drawing.Point(113, 7);
            this.pbDatabasesLoader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbDatabasesLoader.Name = "pbDatabasesLoader";
            this.pbDatabasesLoader.Size = new System.Drawing.Size(16, 16);
            this.pbDatabasesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDatabasesLoader.TabIndex = 8;
            this.pbDatabasesLoader.TabStop = false;
            this.pbDatabasesLoader.Visible = false;
            // 
            // lTables
            // 
            this.lTables.AutoSize = true;
            this.lTables.Location = new System.Drawing.Point(0, 33);
            this.lTables.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTables.Name = "lTables";
            this.lTables.Size = new System.Drawing.Size(80, 13);
            this.lTables.TabIndex = 11;
            this.lTables.Text = "Wybierz tabele:";
            // 
            // lDatabase
            // 
            this.lDatabase.AutoSize = true;
            this.lDatabase.Location = new System.Drawing.Point(0, 7);
            this.lDatabase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lDatabase.Name = "lDatabase";
            this.lDatabase.Size = new System.Drawing.Size(72, 13);
            this.lDatabase.TabIndex = 10;
            this.lDatabase.Text = "Baza danych:";
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(2, 50);
            this.lbTables.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(294, 108);
            this.lbTables.TabIndex = 7;
            // 
            // gbFTP
            // 
            this.gbFTP.Controls.Add(this.pbFTPConnectTest);
            this.gbFTP.Controls.Add(this.lFTPRemotePath);
            this.gbFTP.Controls.Add(this.lFTPUserPass);
            this.gbFTP.Controls.Add(this.lFTPUserName);
            this.gbFTP.Controls.Add(this.lFTPAddress);
            this.gbFTP.Controls.Add(this.bFTPConnectTest);
            this.gbFTP.Controls.Add(this.textBox2);
            this.gbFTP.Controls.Add(this.tbFTPRemotePath);
            this.gbFTP.Controls.Add(this.tbFTPUserPass);
            this.gbFTP.Controls.Add(this.tbFTPUserName);
            this.gbFTP.Controls.Add(this.tbFTPAdress);
            this.gbFTP.Location = new System.Drawing.Point(334, 27);
            this.gbFTP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFTP.Name = "gbFTP";
            this.gbFTP.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFTP.Size = new System.Drawing.Size(337, 171);
            this.gbFTP.TabIndex = 10;
            this.gbFTP.TabStop = false;
            this.gbFTP.Text = "Konfiguracja FTP";
            // 
            // pbFTPConnectTest
            // 
            this.pbFTPConnectTest.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbFTPConnectTest.Location = new System.Drawing.Point(116, 145);
            this.pbFTPConnectTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbFTPConnectTest.Name = "pbFTPConnectTest";
            this.pbFTPConnectTest.Size = new System.Drawing.Size(16, 16);
            this.pbFTPConnectTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFTPConnectTest.TabIndex = 8;
            this.pbFTPConnectTest.TabStop = false;
            this.pbFTPConnectTest.Visible = false;
            // 
            // lFTPRemotePath
            // 
            this.lFTPRemotePath.AutoSize = true;
            this.lFTPRemotePath.Location = new System.Drawing.Point(5, 118);
            this.lFTPRemotePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPRemotePath.Name = "lFTPRemotePath";
            this.lFTPRemotePath.Size = new System.Drawing.Size(108, 13);
            this.lFTPRemotePath.TabIndex = 2;
            this.lFTPRemotePath.Text = "Ścieżka na serwerze:";
            // 
            // lFTPUserPass
            // 
            this.lFTPUserPass.AutoSize = true;
            this.lFTPUserPass.Location = new System.Drawing.Point(6, 90);
            this.lFTPUserPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPUserPass.Name = "lFTPUserPass";
            this.lFTPUserPass.Size = new System.Drawing.Size(101, 13);
            this.lFTPUserPass.TabIndex = 2;
            this.lFTPUserPass.Text = "Hasło użytkownika:";
            // 
            // lFTPUserName
            // 
            this.lFTPUserName.AutoSize = true;
            this.lFTPUserName.Location = new System.Drawing.Point(6, 62);
            this.lFTPUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPUserName.Name = "lFTPUserName";
            this.lFTPUserName.Size = new System.Drawing.Size(105, 13);
            this.lFTPUserName.TabIndex = 2;
            this.lFTPUserName.Text = "Nazwa użytkownika:";
            // 
            // lFTPAddress
            // 
            this.lFTPAddress.AutoSize = true;
            this.lFTPAddress.Location = new System.Drawing.Point(6, 34);
            this.lFTPAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFTPAddress.Name = "lFTPAddress";
            this.lFTPAddress.Size = new System.Drawing.Size(77, 13);
            this.lFTPAddress.TabIndex = 2;
            this.lFTPAddress.Text = "Adres serwera:";
            // 
            // bFTPConnectTest
            // 
            this.bFTPConnectTest.Location = new System.Drawing.Point(112, 141);
            this.bFTPConnectTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bFTPConnectTest.Name = "bFTPConnectTest";
            this.bFTPConnectTest.Size = new System.Drawing.Size(218, 24);
            this.bFTPConnectTest.TabIndex = 12;
            this.bFTPConnectTest.Text = "Przetestuj połączenie FTP";
            this.bFTPConnectTest.UseVisualStyleBackColor = true;
            this.bFTPConnectTest.Click += new System.EventHandler(this.bFTPConnect_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 141);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(218, 20);
            this.textBox2.TabIndex = 0;
            // 
            // tbFTPRemotePath
            // 
            this.tbFTPRemotePath.Location = new System.Drawing.Point(112, 115);
            this.tbFTPRemotePath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPRemotePath.Name = "tbFTPRemotePath";
            this.tbFTPRemotePath.Size = new System.Drawing.Size(218, 20);
            this.tbFTPRemotePath.TabIndex = 11;
            // 
            // tbFTPUserPass
            // 
            this.tbFTPUserPass.Location = new System.Drawing.Point(112, 87);
            this.tbFTPUserPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPUserPass.Name = "tbFTPUserPass";
            this.tbFTPUserPass.PasswordChar = '•';
            this.tbFTPUserPass.Size = new System.Drawing.Size(218, 20);
            this.tbFTPUserPass.TabIndex = 10;
            // 
            // tbFTPUserName
            // 
            this.tbFTPUserName.Location = new System.Drawing.Point(112, 59);
            this.tbFTPUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPUserName.Name = "tbFTPUserName";
            this.tbFTPUserName.Size = new System.Drawing.Size(218, 20);
            this.tbFTPUserName.TabIndex = 9;
            // 
            // tbFTPAdress
            // 
            this.tbFTPAdress.Location = new System.Drawing.Point(112, 31);
            this.tbFTPAdress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbFTPAdress.Name = "tbFTPAdress";
            this.tbFTPAdress.Size = new System.Drawing.Size(218, 20);
            this.tbFTPAdress.TabIndex = 8;
            // 
            // bSaveScheduleEvent
            // 
            this.bSaveScheduleEvent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bSaveScheduleEvent.Location = new System.Drawing.Point(12, 306);
            this.bSaveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bSaveScheduleEvent.Name = "bSaveScheduleEvent";
            this.bSaveScheduleEvent.Size = new System.Drawing.Size(338, 23);
            this.bSaveScheduleEvent.TabIndex = 14;
            this.bSaveScheduleEvent.Text = "Zapisz zdarzenie";
            this.bSaveScheduleEvent.UseVisualStyleBackColor = false;
            this.bSaveScheduleEvent.Click += new System.EventHandler(this.bSaveScheduleEvent_Click);
            // 
            // gbInterval
            // 
            this.gbInterval.Controls.Add(this.lInterval);
            this.gbInterval.Controls.Add(this.tbInterval);
            this.gbInterval.Location = new System.Drawing.Point(334, 204);
            this.gbInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbInterval.Name = "gbInterval";
            this.gbInterval.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbInterval.Size = new System.Drawing.Size(337, 61);
            this.gbInterval.TabIndex = 15;
            this.gbInterval.TabStop = false;
            this.gbInterval.Text = "Interwał";
            // 
            // lInterval
            // 
            this.lInterval.AutoSize = true;
            this.lInterval.Location = new System.Drawing.Point(6, 27);
            this.lInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInterval.Name = "lInterval";
            this.lInterval.Size = new System.Drawing.Size(119, 13);
            this.lInterval.TabIndex = 1;
            this.lInterval.Text = "Podaj czas w minutach:";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(131, 24);
            this.tbInterval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(198, 20);
            this.tbInterval.TabIndex = 13;
            this.tbInterval.Text = "60";
            this.tbInterval.TextChanged += new System.EventHandler(this.tbInterval_TextChanged);
            // 
            // gbServiceManagement
            // 
            this.gbServiceManagement.Controls.Add(this.lServiceStatus);
            this.gbServiceManagement.Location = new System.Drawing.Point(675, 27);
            this.gbServiceManagement.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbServiceManagement.Name = "gbServiceManagement";
            this.gbServiceManagement.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbServiceManagement.Size = new System.Drawing.Size(145, 238);
            this.gbServiceManagement.TabIndex = 160;
            this.gbServiceManagement.TabStop = false;
            this.gbServiceManagement.Text = "Kontrola usługi";
            // 
            // lServiceStatus
            // 
            this.lServiceStatus.AutoSize = true;
            this.lServiceStatus.Location = new System.Drawing.Point(26, 21);
            this.lServiceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lServiceStatus.Name = "lServiceStatus";
            this.lServiceStatus.Size = new System.Drawing.Size(0, 13);
            this.lServiceStatus.TabIndex = 0;
            // 
            // tbXMLFileName
            // 
            this.tbXMLFileName.Location = new System.Drawing.Point(464, 280);
            this.tbXMLFileName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbXMLFileName.Name = "tbXMLFileName";
            this.tbXMLFileName.Size = new System.Drawing.Size(198, 20);
            this.tbXMLFileName.TabIndex = 161;
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(340, 283);
            this.lFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(68, 13);
            this.lFileName.TabIndex = 162;
            this.lFileName.Text = "Nazwa pliku:";
            // 
            // pDBData
            // 
            this.pDBData.Controls.Add(this.pbDatabasesLoader);
            this.pDBData.Controls.Add(this.lTables);
            this.pDBData.Controls.Add(this.lbTables);
            this.pDBData.Controls.Add(this.lDatabase);
            this.pDBData.Controls.Add(this.cbDatabases);
            this.pDBData.Location = new System.Drawing.Point(18, 83);
            this.pDBData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pDBData.Name = "pDBData";
            this.pDBData.Size = new System.Drawing.Size(300, 168);
            this.pDBData.TabIndex = 163;
            this.pDBData.Visible = false;
            // 
            // lbScheduleEvents
            // 
            this.lbScheduleEvents.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScheduleEvents.FormattingEnabled = true;
            this.lbScheduleEvents.ItemHeight = 14;
            this.lbScheduleEvents.Location = new System.Drawing.Point(12, 335);
            this.lbScheduleEvents.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbScheduleEvents.Name = "lbScheduleEvents";
            this.lbScheduleEvents.Size = new System.Drawing.Size(808, 256);
            this.lbScheduleEvents.TabIndex = 164;
            this.lbScheduleEvents.SelectedIndexChanged += new System.EventHandler(this.lbScheduleEvents_SelectedIndexChanged);
            this.lbScheduleEvents.Leave += new System.EventHandler(this.lbScheduleEvents_Leave);
            // 
            // bRemoveScheduleEvent
            // 
            this.bRemoveScheduleEvent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bRemoveScheduleEvent.Location = new System.Drawing.Point(354, 306);
            this.bRemoveScheduleEvent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bRemoveScheduleEvent.Name = "bRemoveScheduleEvent";
            this.bRemoveScheduleEvent.Size = new System.Drawing.Size(338, 23);
            this.bRemoveScheduleEvent.TabIndex = 14;
            this.bRemoveScheduleEvent.Text = "Usuń zdarzenie";
            this.bRemoveScheduleEvent.UseVisualStyleBackColor = false;
            this.bRemoveScheduleEvent.Click += new System.EventHandler(this.bRemoveScheduleEvent_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 698);
            this.Controls.Add(this.pDBData);
            this.Controls.Add(this.lbScheduleEvents);
            this.Controls.Add(this.lFileName);
            this.Controls.Add(this.tbXMLFileName);
            this.Controls.Add(this.gbInterval);
            this.Controls.Add(this.gbServiceManagement);
            this.Controls.Add(this.gbFTP);
            this.Controls.Add(this.gbDBConnection);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.bSaveScheduleEvent);
            this.Controls.Add(this.bRemoveScheduleEvent);
            this.Controls.Add(this.buttonSaveAndRun);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "DB Extractor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDBConnection.ResumeLayout(false);
            this.gbDBConnection.PerformLayout();
            this.pDBConnection.ResumeLayout(false);
            this.pDBConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).EndInit();
            this.gbFTP.ResumeLayout(false);
            this.gbFTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).EndInit();
            this.gbInterval.ResumeLayout(false);
            this.gbInterval.PerformLayout();
            this.gbServiceManagement.ResumeLayout(false);
            this.gbServiceManagement.PerformLayout();
            this.pDBData.ResumeLayout(false);
            this.pDBData.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveAndRun;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbServerNames;
        private System.Windows.Forms.GroupBox gbDBConnection;
        private System.Windows.Forms.PictureBox pbServerNamesLoader;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.PictureBox pbDatabasesLoader;
        private System.Windows.Forms.RadioButton rbAuthSQLServer;
        private System.Windows.Forms.RadioButton rbAuthWindows;
        private System.Windows.Forms.Label lServerName;
        private System.Windows.Forms.Label lAuth;
        private System.Windows.Forms.Label lUserPass;
        private System.Windows.Forms.Label lUserName;
        private System.Windows.Forms.Button bSQLConnect;
        private System.Windows.Forms.TextBox tbSQLUserPass;
        private System.Windows.Forms.TextBox tbSQLUserName;
        private System.Windows.Forms.PictureBox pbConnecting;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.Label lTables;
        private System.Windows.Forms.Label lDatabase;
        private System.Windows.Forms.GroupBox gbFTP;
        private System.Windows.Forms.TextBox tbFTPUserPass;
        private System.Windows.Forms.TextBox tbFTPUserName;
        private System.Windows.Forms.TextBox tbFTPAdress;
        private System.Windows.Forms.Button bFTPConnectTest;
        private System.Windows.Forms.Button bSaveScheduleEvent;
        private System.Windows.Forms.PictureBox pbFTPConnectTest;
        private System.Windows.Forms.Label lFTPUserPass;
        private System.Windows.Forms.Label lFTPUserName;
        private System.Windows.Forms.Label lFTPAddress;
        private System.Windows.Forms.Label lFTPRemotePath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbFTPRemotePath;
        private System.Windows.Forms.GroupBox gbInterval;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.Label lInterval;
        private System.Windows.Forms.GroupBox gbServiceManagement;
        private System.Windows.Forms.Label lServiceStatus;
        private System.Windows.Forms.Panel pDBConnection;
        private System.Windows.Forms.TextBox tbXMLFileName;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.Panel pDBData;
        private System.Windows.Forms.ListBox lbScheduleEvents;
        private System.Windows.Forms.Button bRemoveScheduleEvent;
    }
}

