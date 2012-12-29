namespace DBExtractor
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
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbServerNames = new System.Windows.Forms.ComboBox();
            this.gbDBConnection = new System.Windows.Forms.GroupBox();
            this.pbConnecting = new System.Windows.Forms.PictureBox();
            this.tbSQLUserPass = new System.Windows.Forms.TextBox();
            this.tbSQLUserName = new System.Windows.Forms.TextBox();
            this.lUserPass = new System.Windows.Forms.Label();
            this.lUserName = new System.Windows.Forms.Label();
            this.bSQLConnect = new System.Windows.Forms.Button();
            this.lAuth = new System.Windows.Forms.Label();
            this.lServerName = new System.Windows.Forms.Label();
            this.pbServerNamesLoader = new System.Windows.Forms.PictureBox();
            this.rbAuthSQLServer = new System.Windows.Forms.RadioButton();
            this.rbAuthWindows = new System.Windows.Forms.RadioButton();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.pbDatabasesLoader = new System.Windows.Forms.PictureBox();
            this.gbDatabasesAndTables = new System.Windows.Forms.GroupBox();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbFTPUserPass = new System.Windows.Forms.TextBox();
            this.tbFTPUserName = new System.Windows.Forms.TextBox();
            this.tbFTPAdress = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.chDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFTP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbDBConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).BeginInit();
            this.gbDatabasesAndTables.SuspendLayout();
            this.gbFTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).BeginInit();
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
            this.statusBar.Size = new System.Drawing.Size(676, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
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
            this.buttonSaveAndRun.Name = "buttonSaveAndRun";
            this.buttonSaveAndRun.Size = new System.Drawing.Size(129, 24);
            this.buttonSaveAndRun.TabIndex = 5;
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
            this.cbServerNames.Name = "cbServerNames";
            this.cbServerNames.Size = new System.Drawing.Size(187, 21);
            this.cbServerNames.TabIndex = 6;
            this.cbServerNames.SelectedIndexChanged += new System.EventHandler(this.cbServerNames_SelectedIndexChanged);
            // 
            // gbDBConnection
            // 
            this.gbDBConnection.Controls.Add(this.pbConnecting);
            this.gbDBConnection.Controls.Add(this.tbSQLUserPass);
            this.gbDBConnection.Controls.Add(this.tbSQLUserName);
            this.gbDBConnection.Controls.Add(this.lUserPass);
            this.gbDBConnection.Controls.Add(this.lUserName);
            this.gbDBConnection.Controls.Add(this.bSQLConnect);
            this.gbDBConnection.Controls.Add(this.lAuth);
            this.gbDBConnection.Controls.Add(this.lServerName);
            this.gbDBConnection.Controls.Add(this.pbServerNamesLoader);
            this.gbDBConnection.Controls.Add(this.rbAuthSQLServer);
            this.gbDBConnection.Controls.Add(this.rbAuthWindows);
            this.gbDBConnection.Controls.Add(this.cbServerNames);
            this.gbDBConnection.Location = new System.Drawing.Point(12, 27);
            this.gbDBConnection.Name = "gbDBConnection";
            this.gbDBConnection.Size = new System.Drawing.Size(311, 171);
            this.gbDBConnection.TabIndex = 7;
            this.gbDBConnection.TabStop = false;
            this.gbDBConnection.Text = "Parametry połączenia z bazą";
            // 
            // pbConnecting
            // 
            this.pbConnecting.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbConnecting.Location = new System.Drawing.Point(120, 145);
            this.pbConnecting.Name = "pbConnecting";
            this.pbConnecting.Size = new System.Drawing.Size(16, 16);
            this.pbConnecting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConnecting.TabIndex = 8;
            this.pbConnecting.TabStop = false;
            this.pbConnecting.Visible = false;
            // 
            // tbSQLUserPass
            // 
            this.tbSQLUserPass.Enabled = false;
            this.tbSQLUserPass.Location = new System.Drawing.Point(116, 115);
            this.tbSQLUserPass.Name = "tbSQLUserPass";
            this.tbSQLUserPass.PasswordChar = '•';
            this.tbSQLUserPass.Size = new System.Drawing.Size(187, 20);
            this.tbSQLUserPass.TabIndex = 16;
            // 
            // tbSQLUserName
            // 
            this.tbSQLUserName.Enabled = false;
            this.tbSQLUserName.Location = new System.Drawing.Point(116, 87);
            this.tbSQLUserName.Name = "tbSQLUserName";
            this.tbSQLUserName.Size = new System.Drawing.Size(187, 20);
            this.tbSQLUserName.TabIndex = 16;
            // 
            // lUserPass
            // 
            this.lUserPass.AutoSize = true;
            this.lUserPass.Enabled = false;
            this.lUserPass.Location = new System.Drawing.Point(6, 118);
            this.lUserPass.Name = "lUserPass";
            this.lUserPass.Size = new System.Drawing.Size(101, 13);
            this.lUserPass.TabIndex = 15;
            this.lUserPass.Text = "Hasło użytkownika:";
            // 
            // lUserName
            // 
            this.lUserName.AutoSize = true;
            this.lUserName.Enabled = false;
            this.lUserName.Location = new System.Drawing.Point(6, 90);
            this.lUserName.Name = "lUserName";
            this.lUserName.Size = new System.Drawing.Size(105, 13);
            this.lUserName.TabIndex = 14;
            this.lUserName.Text = "Nazwa użytkownika:";
            // 
            // bSQLConnect
            // 
            this.bSQLConnect.Enabled = false;
            this.bSQLConnect.Location = new System.Drawing.Point(116, 141);
            this.bSQLConnect.Name = "bSQLConnect";
            this.bSQLConnect.Size = new System.Drawing.Size(187, 24);
            this.bSQLConnect.TabIndex = 13;
            this.bSQLConnect.Text = "Połącz i pobierz dane o bazie";
            this.bSQLConnect.UseVisualStyleBackColor = true;
            this.bSQLConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // lAuth
            // 
            this.lAuth.AutoSize = true;
            this.lAuth.Enabled = false;
            this.lAuth.Location = new System.Drawing.Point(6, 62);
            this.lAuth.Name = "lAuth";
            this.lAuth.Size = new System.Drawing.Size(65, 13);
            this.lAuth.TabIndex = 12;
            this.lAuth.Text = "Autoryzacja:";
            // 
            // lServerName
            // 
            this.lServerName.AutoSize = true;
            this.lServerName.Location = new System.Drawing.Point(6, 34);
            this.lServerName.Name = "lServerName";
            this.lServerName.Size = new System.Drawing.Size(83, 13);
            this.lServerName.TabIndex = 11;
            this.lServerName.Text = "Nazwa serwera:";
            // 
            // pbServerNamesLoader
            // 
            this.pbServerNamesLoader.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbServerNamesLoader.Location = new System.Drawing.Point(119, 33);
            this.pbServerNamesLoader.Name = "pbServerNamesLoader";
            this.pbServerNamesLoader.Size = new System.Drawing.Size(16, 16);
            this.pbServerNamesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbServerNamesLoader.TabIndex = 8;
            this.pbServerNamesLoader.TabStop = false;
            this.pbServerNamesLoader.Visible = false;
            // 
            // rbAuthSQLServer
            // 
            this.rbAuthSQLServer.AutoSize = true;
            this.rbAuthSQLServer.Enabled = false;
            this.rbAuthSQLServer.Location = new System.Drawing.Point(205, 58);
            this.rbAuthSQLServer.Name = "rbAuthSQLServer";
            this.rbAuthSQLServer.Size = new System.Drawing.Size(82, 17);
            this.rbAuthSQLServer.TabIndex = 10;
            this.rbAuthSQLServer.Text = "SQL Serwer";
            this.rbAuthSQLServer.UseVisualStyleBackColor = true;
            this.rbAuthSQLServer.CheckedChanged += new System.EventHandler(this.rbAuthSQLServer_CheckedChanged);
            // 
            // rbAuthWindows
            // 
            this.rbAuthWindows.AutoSize = true;
            this.rbAuthWindows.Checked = true;
            this.rbAuthWindows.Enabled = false;
            this.rbAuthWindows.Location = new System.Drawing.Point(116, 58);
            this.rbAuthWindows.Name = "rbAuthWindows";
            this.rbAuthWindows.Size = new System.Drawing.Size(69, 17);
            this.rbAuthWindows.TabIndex = 9;
            this.rbAuthWindows.TabStop = true;
            this.rbAuthWindows.Text = "Windows";
            this.rbAuthWindows.UseVisualStyleBackColor = true;
            this.rbAuthWindows.CheckedChanged += new System.EventHandler(this.rbAuthWindows_CheckedChanged);
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.Enabled = false;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(116, 24);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(187, 21);
            this.cbDatabases.TabIndex = 6;
            this.cbDatabases.SelectedIndexChanged += new System.EventHandler(this.cbDatabases_SelectedIndexChanged);
            // 
            // pbDatabasesLoader
            // 
            this.pbDatabasesLoader.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbDatabasesLoader.Location = new System.Drawing.Point(119, 26);
            this.pbDatabasesLoader.Name = "pbDatabasesLoader";
            this.pbDatabasesLoader.Size = new System.Drawing.Size(16, 16);
            this.pbDatabasesLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDatabasesLoader.TabIndex = 8;
            this.pbDatabasesLoader.TabStop = false;
            this.pbDatabasesLoader.Visible = false;
            // 
            // gbDatabasesAndTables
            // 
            this.gbDatabasesAndTables.Controls.Add(this.lTables);
            this.gbDatabasesAndTables.Controls.Add(this.lDatabase);
            this.gbDatabasesAndTables.Controls.Add(this.lbTables);
            this.gbDatabasesAndTables.Controls.Add(this.pbDatabasesLoader);
            this.gbDatabasesAndTables.Controls.Add(this.cbDatabases);
            this.gbDatabasesAndTables.Location = new System.Drawing.Point(12, 204);
            this.gbDatabasesAndTables.Name = "gbDatabasesAndTables";
            this.gbDatabasesAndTables.Size = new System.Drawing.Size(311, 200);
            this.gbDatabasesAndTables.TabIndex = 9;
            this.gbDatabasesAndTables.TabStop = false;
            this.gbDatabasesAndTables.Text = "Bazy danych i tabele";
            // 
            // lTables
            // 
            this.lTables.AutoSize = true;
            this.lTables.Location = new System.Drawing.Point(6, 63);
            this.lTables.Name = "lTables";
            this.lTables.Size = new System.Drawing.Size(80, 13);
            this.lTables.TabIndex = 11;
            this.lTables.Text = "Wybierz tabele:";
            // 
            // lDatabase
            // 
            this.lDatabase.AutoSize = true;
            this.lDatabase.Location = new System.Drawing.Point(6, 27);
            this.lDatabase.Name = "lDatabase";
            this.lDatabase.Size = new System.Drawing.Size(72, 13);
            this.lDatabase.TabIndex = 10;
            this.lDatabase.Text = "Baza danych:";
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(9, 79);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(294, 108);
            this.lbTables.TabIndex = 9;
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
            this.gbFTP.Controls.Add(this.textBox1);
            this.gbFTP.Controls.Add(this.tbFTPUserPass);
            this.gbFTP.Controls.Add(this.tbFTPUserName);
            this.gbFTP.Controls.Add(this.tbFTPAdress);
            this.gbFTP.Location = new System.Drawing.Point(334, 27);
            this.gbFTP.Name = "gbFTP";
            this.gbFTP.Size = new System.Drawing.Size(337, 171);
            this.gbFTP.TabIndex = 10;
            this.gbFTP.TabStop = false;
            this.gbFTP.Text = "Konfiguracja FTP";
            // 
            // pbFTPConnectTest
            // 
            this.pbFTPConnectTest.Image = global::DBExtractor.Properties.Resources.loader1;
            this.pbFTPConnectTest.Location = new System.Drawing.Point(116, 145);
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
            this.lFTPRemotePath.Name = "lFTPRemotePath";
            this.lFTPRemotePath.Size = new System.Drawing.Size(108, 13);
            this.lFTPRemotePath.TabIndex = 2;
            this.lFTPRemotePath.Text = "Ścieżka na serwerze:";
            // 
            // lFTPUserPass
            // 
            this.lFTPUserPass.AutoSize = true;
            this.lFTPUserPass.Location = new System.Drawing.Point(6, 90);
            this.lFTPUserPass.Name = "lFTPUserPass";
            this.lFTPUserPass.Size = new System.Drawing.Size(101, 13);
            this.lFTPUserPass.TabIndex = 2;
            this.lFTPUserPass.Text = "Hasło użytkownika:";
            // 
            // lFTPUserName
            // 
            this.lFTPUserName.AutoSize = true;
            this.lFTPUserName.Location = new System.Drawing.Point(6, 62);
            this.lFTPUserName.Name = "lFTPUserName";
            this.lFTPUserName.Size = new System.Drawing.Size(105, 13);
            this.lFTPUserName.TabIndex = 2;
            this.lFTPUserName.Text = "Nazwa użytkownika:";
            // 
            // lFTPAddress
            // 
            this.lFTPAddress.AutoSize = true;
            this.lFTPAddress.Location = new System.Drawing.Point(6, 34);
            this.lFTPAddress.Name = "lFTPAddress";
            this.lFTPAddress.Size = new System.Drawing.Size(77, 13);
            this.lFTPAddress.TabIndex = 2;
            this.lFTPAddress.Text = "Adres serwera:";
            // 
            // bFTPConnectTest
            // 
            this.bFTPConnectTest.Location = new System.Drawing.Point(112, 141);
            this.bFTPConnectTest.Name = "bFTPConnectTest";
            this.bFTPConnectTest.Size = new System.Drawing.Size(218, 24);
            this.bFTPConnectTest.TabIndex = 1;
            this.bFTPConnectTest.Text = "Przetestuj połączenie FTP";
            this.bFTPConnectTest.UseVisualStyleBackColor = true;
            this.bFTPConnectTest.Click += new System.EventHandler(this.bFTPConnect_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(218, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tbFTPUserPass
            // 
            this.tbFTPUserPass.Location = new System.Drawing.Point(112, 87);
            this.tbFTPUserPass.Name = "tbFTPUserPass";
            this.tbFTPUserPass.PasswordChar = '•';
            this.tbFTPUserPass.Size = new System.Drawing.Size(218, 20);
            this.tbFTPUserPass.TabIndex = 0;
            // 
            // tbFTPUserName
            // 
            this.tbFTPUserName.Location = new System.Drawing.Point(112, 59);
            this.tbFTPUserName.Name = "tbFTPUserName";
            this.tbFTPUserName.Size = new System.Drawing.Size(218, 20);
            this.tbFTPUserName.TabIndex = 0;
            // 
            // tbFTPAdress
            // 
            this.tbFTPAdress.Location = new System.Drawing.Point(112, 31);
            this.tbFTPAdress.Name = "tbFTPAdress";
            this.tbFTPAdress.Size = new System.Drawing.Size(218, 20);
            this.tbFTPAdress.TabIndex = 0;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDatabase,
            this.chFTP,
            this.chFileName,
            this.chPeriod});
            this.listView2.Location = new System.Drawing.Point(12, 437);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(659, 203);
            this.listView2.TabIndex = 13;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // chDatabase
            // 
            this.chDatabase.Text = "Baza danych";
            this.chDatabase.Width = 229;
            // 
            // chFTP
            // 
            this.chFTP.Text = "Dane FTP";
            this.chFTP.Width = 128;
            // 
            // chFileName
            // 
            this.chFileName.Text = "Nazwa pliku";
            this.chFileName.Width = 146;
            // 
            // chPeriod
            // 
            this.chPeriod.Text = "Okres aktualizacji";
            this.chPeriod.Width = 118;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bAdd.Location = new System.Drawing.Point(12, 408);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(659, 23);
            this.bAdd.TabIndex = 14;
            this.bAdd.Text = "Dodaj zdarzenie";
            this.bAdd.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(334, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 200);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 698);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.gbFTP);
            this.Controls.Add(this.gbDatabasesAndTables);
            this.Controls.Add(this.gbDBConnection);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.buttonSaveAndRun);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
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
            ((System.ComponentModel.ISupportInitialize)(this.pbConnecting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerNamesLoader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatabasesLoader)).EndInit();
            this.gbDatabasesAndTables.ResumeLayout(false);
            this.gbDatabasesAndTables.PerformLayout();
            this.gbFTP.ResumeLayout(false);
            this.gbFTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFTPConnectTest)).EndInit();
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
        private System.ServiceProcess.ServiceController serviceController1;
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
        private System.Windows.Forms.GroupBox gbDatabasesAndTables;
        private System.Windows.Forms.PictureBox pbConnecting;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.Label lTables;
        private System.Windows.Forms.Label lDatabase;
        private System.Windows.Forms.GroupBox gbFTP;
        private System.Windows.Forms.TextBox tbFTPUserPass;
        private System.Windows.Forms.TextBox tbFTPUserName;
        private System.Windows.Forms.TextBox tbFTPAdress;
        private System.Windows.Forms.Button bFTPConnectTest;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader chDatabase;
        private System.Windows.Forms.ColumnHeader chFTP;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ColumnHeader chPeriod;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.PictureBox pbFTPConnectTest;
        private System.Windows.Forms.Label lFTPUserPass;
        private System.Windows.Forms.Label lFTPUserName;
        private System.Windows.Forms.Label lFTPAddress;
        private System.Windows.Forms.Label lFTPRemotePath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

