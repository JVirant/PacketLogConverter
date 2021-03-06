using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using PacketLogConverter.LogReaders;
using PacketLogConverter.LogWriters;
using PacketLogConverter.Utils;

namespace PacketLogConverter
{
	public class MainForm : Form, IExecutionContext
	{
		private MainMenu mainMenu1;
		private TabPage logInfoTab;
		private RichTextBox logDataText;
		private MenuItem menuOpenFile;
		private MenuItem menuSaveFile;
		private OpenFileDialog openLogDialog;
		private IContainer components;

		private Label label1;
		private TextBox li_clientVersion;
		private TabPage logDataTab;
		private TabControl mainFormTabs;
		private TabPage instantParseTab;
		private Label label2;
		private GroupBox inputDataGroupBox;
		private GroupBox instantResultGroupBox1;
		private RichTextBox instantParseOut;
		private Label label4;
		private Label label5;
		private TextBox instantVersion;
		private TextBox instantCode;
		private Label label6;
		private RadioButton instantClientToServer;
		private RadioButton instantServerToClient;
		private SaveFileDialog saveLogDialog;
		private Label label7;
		private Label label8;
		private TextBox li_packetsCount;
		private TextBox instantParseInput;
		private TextBox logDataFindTextBox;
		private Button logDataFindButton;
		private Button button1;
		private CheckBox logDataDisableUpdatesCheckBox;
		private Button applyButton;
		private Label li_changesLabel;
		private MenuItem menuItem1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox li_unknownPacketsCount;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox li_ignoreVersionChanges;
		private System.Windows.Forms.MenuItem menuOpenAnother;
		private System.Windows.Forms.OpenFileDialog openAnotherLogDialog;
		private System.Windows.Forms.MenuItem menuOpenFolder;
		private System.Windows.Forms.FolderBrowserDialog openFolderLogDialog;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem packetTimeDiffMenuItem;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuRecentFiles;
		private System.Windows.Forms.MenuItem menuExitApp;
		private System.Windows.Forms.MenuItem mnuPacketFlags;
		private System.Windows.Forms.MenuItem mnuPacketSequence;
		private OpenFileDialog openFilterDialog;
		private SaveFileDialog saveFilterDialog;
		private BindingSource openLogsBindingSource;
		private DataGridView openLogsDataGridView;
		private GroupBox li_totalGroupBox;
		private GroupBox li_initialValuesGroupBox;
		private GroupBox li_openLogsGroupBox;
		private CheckBox logDataCountLogDataSizeheckBox;
		private DataGridViewCheckBoxColumn selectedLogDataGridViewCheckBoxColumn;
		private DataGridViewTextBoxColumn streamNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn unknownPacketsCountDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
		private DataGridViewCheckBoxColumn IgnoreVersionChanges;
		private Button removeButton;
		private Label label3;

		public MainForm()
		{
			m_progress = new Progress(this);
			InitializeComponent();

			m_currentLogs.OnPacketLogsChanged += OnPacketLogsChanged;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.openLogsDataGridView = new System.Windows.Forms.DataGridView();
			this.selectedLogDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.streamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unknownPacketsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IgnoreVersionChanges = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.openLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuOpenFile = new System.Windows.Forms.MenuItem();
			this.menuOpenAnother = new System.Windows.Forms.MenuItem();
			this.menuOpenFolder = new System.Windows.Forms.MenuItem();
			this.menuSaveFile = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuRecentFiles = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuExitApp = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.packetTimeDiffMenuItem = new System.Windows.Forms.MenuItem();
			this.mnuPacketSequence = new System.Windows.Forms.MenuItem();
			this.mnuPacketFlags = new System.Windows.Forms.MenuItem();
			this.openLogDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
			this.mainFormTabs = new System.Windows.Forms.TabControl();
			this.instantParseTab = new System.Windows.Forms.TabPage();
			this.instantResultGroupBox1 = new System.Windows.Forms.GroupBox();
			this.instantParseOut = new System.Windows.Forms.RichTextBox();
			this.inputDataGroupBox = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.instantParseInput = new System.Windows.Forms.TextBox();
			this.instantServerToClient = new System.Windows.Forms.RadioButton();
			this.instantClientToServer = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.instantCode = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.instantVersion = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.logInfoTab = new System.Windows.Forms.TabPage();
			this.li_openLogsGroupBox = new System.Windows.Forms.GroupBox();
			this.li_changesLabel = new System.Windows.Forms.Label();
			this.applyButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.li_initialValuesGroupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.li_clientVersion = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.li_ignoreVersionChanges = new System.Windows.Forms.CheckBox();
			this.li_totalGroupBox = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.li_packetsCount = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.li_unknownPacketsCount = new System.Windows.Forms.TextBox();
			this.logDataTab = new System.Windows.Forms.TabPage();
			this.logDataCountLogDataSizeheckBox = new System.Windows.Forms.CheckBox();
			this.logDataDisableUpdatesCheckBox = new System.Windows.Forms.CheckBox();
			this.logDataFindButton = new System.Windows.Forms.Button();
			this.logDataFindTextBox = new System.Windows.Forms.TextBox();
			this.logDataText = new System.Windows.Forms.RichTextBox();
			this.openAnotherLogDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFolderLogDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.openFilterDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFilterDialog = new System.Windows.Forms.SaveFileDialog();
            this.removeButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.openLogsDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.openLogsBindingSource)).BeginInit();
			this.mainFormTabs.SuspendLayout();
			this.instantParseTab.SuspendLayout();
			this.instantResultGroupBox1.SuspendLayout();
			this.inputDataGroupBox.SuspendLayout();
			this.logInfoTab.SuspendLayout();
			this.li_openLogsGroupBox.SuspendLayout();
			this.li_initialValuesGroupBox.SuspendLayout();
			this.li_totalGroupBox.SuspendLayout();
			this.logDataTab.SuspendLayout();
			this.SuspendLayout();
			//
			// openLogsDataGridView
			//
			this.openLogsDataGridView.AllowUserToAddRows = false;
			this.openLogsDataGridView.AllowUserToDeleteRows = false;
			this.openLogsDataGridView.AllowUserToOrderColumns = true;
			this.openLogsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.openLogsDataGridView.AutoGenerateColumns = false;
			this.openLogsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.openLogsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.openLogsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.openLogsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.openLogsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.openLogsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedLogDataGridViewCheckBoxColumn,
            this.streamNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.unknownPacketsCountDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.IgnoreVersionChanges});
			this.openLogsDataGridView.DataSource = this.openLogsBindingSource;
			this.openLogsDataGridView.Location = new System.Drawing.Point(9, 46);
			this.openLogsDataGridView.MultiSelect = false;
			this.openLogsDataGridView.Name = "openLogsDataGridView";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.openLogsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.openLogsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.openLogsDataGridView.ShowEditingIcon = false;
			this.openLogsDataGridView.Size = new System.Drawing.Size(553, 132);
			this.openLogsDataGridView.TabIndex = 10;
			this.openLogsDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.openLogsDataGridView_CellBeginEdit);
			this.openLogsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.openLogsDataGridView_CellValueChanged);
			//
			// selectedLogDataGridViewCheckBoxColumn
			//
            this.selectedLogDataGridViewCheckBoxColumn.DataPropertyName = "LogSelected";
            this.selectedLogDataGridViewCheckBoxColumn.HeaderText = "Select";
			this.selectedLogDataGridViewCheckBoxColumn.Name = "selectedLogDataGridViewCheckBoxColumn";
            this.selectedLogDataGridViewCheckBoxColumn.Width = 49;
			//
			// streamNameDataGridViewTextBoxColumn
			//
			this.streamNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.streamNameDataGridViewTextBoxColumn.DataPropertyName = "StreamName";
			this.streamNameDataGridViewTextBoxColumn.HeaderText = "File";
			this.streamNameDataGridViewTextBoxColumn.Name = "streamNameDataGridViewTextBoxColumn";
			this.streamNameDataGridViewTextBoxColumn.ReadOnly = true;
			//
			// countDataGridViewTextBoxColumn
			//
			this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
			this.countDataGridViewTextBoxColumn.HeaderText = "Packets total";
			this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
			this.countDataGridViewTextBoxColumn.ReadOnly = true;
			this.countDataGridViewTextBoxColumn.Width = 87;
			//
			// unknownPacketsCountDataGridViewTextBoxColumn
			//
			this.unknownPacketsCountDataGridViewTextBoxColumn.DataPropertyName = "UnknownPacketsCount";
			this.unknownPacketsCountDataGridViewTextBoxColumn.HeaderText = "Packets unknown";
			this.unknownPacketsCountDataGridViewTextBoxColumn.Name = "unknownPacketsCountDataGridViewTextBoxColumn";
			this.unknownPacketsCountDataGridViewTextBoxColumn.ReadOnly = true;
			this.unknownPacketsCountDataGridViewTextBoxColumn.Width = 108;
			//
			// versionDataGridViewTextBoxColumn
			//
			this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
			this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
			this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
			this.versionDataGridViewTextBoxColumn.Width = 67;
			//
			// IgnoreVersionChanges
			//
			this.IgnoreVersionChanges.DataPropertyName = "IgnoreVersionChanges";
			this.IgnoreVersionChanges.HeaderText = "Ignore version changes";
			this.IgnoreVersionChanges.Name = "IgnoreVersionChanges";
			this.IgnoreVersionChanges.Width = 112;
			//
			// openLogsBindingSource
			//
			this.openLogsBindingSource.DataSource = typeof(PacketLogConverter.PacketLog);
			//
			// mainMenu1
			//
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
			//
			// menuItem1
			//
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpenFile,
            this.menuOpenAnother,
            this.menuOpenFolder,
            this.menuSaveFile,
            this.menuItem3,
            this.menuRecentFiles,
            this.menuItem5,
            this.menuExitApp});
			this.menuItem1.Text = "&File";
			//
			// menuOpenFile
			//
			this.menuOpenFile.Index = 0;
			this.menuOpenFile.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuOpenFile.Text = "&Open...";
			this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
			//
			// menuOpenAnother
			//
			this.menuOpenAnother.Index = 1;
			this.menuOpenAnother.Text = "Open another...";
			this.menuOpenAnother.Click += new System.EventHandler(this.menuOpenAnother_Click);
			//
			// menuOpenFolder
			//
			this.menuOpenFolder.Index = 2;
			this.menuOpenFolder.Text = "Open folder ...";
			this.menuOpenFolder.Click += new System.EventHandler(this.menuOpenFolder_Click);
			//
			// menuSaveFile
			//
			this.menuSaveFile.Enabled = false;
			this.menuSaveFile.Index = 3;
			this.menuSaveFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuSaveFile.Text = "&Save...";
			this.menuSaveFile.Click += new System.EventHandler(this.menuSaveFile_Click);
			//
			// menuItem3
			//
			this.menuItem3.Index = 4;
			this.menuItem3.Text = "-";
			//
			// menuRecentFiles
			//
			this.menuRecentFiles.Index = 5;
			this.menuRecentFiles.Text = "&Recent Files";
			//
			// menuItem5
			//
			this.menuItem5.Index = 6;
			this.menuItem5.Text = "-";
			//
			// menuExitApp
			//
			this.menuExitApp.Index = 7;
			this.menuExitApp.Text = "E&xit";
			this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
			//
			// menuItem2
			//
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.packetTimeDiffMenuItem,
            this.mnuPacketSequence,
            this.mnuPacketFlags});
			this.menuItem2.Text = "&View";
			//
			// packetTimeDiffMenuItem
			//
			this.packetTimeDiffMenuItem.Index = 0;
			this.packetTimeDiffMenuItem.Text = "Packet time difference";
			this.packetTimeDiffMenuItem.Click += new System.EventHandler(this.packetTimeDiffMenuItem_Click);
			//
			// mnuPacketSequence
			//
			this.mnuPacketSequence.Index = 1;
			this.mnuPacketSequence.Text = "Packet sequence ";
			this.mnuPacketSequence.Click += new System.EventHandler(this.mnuPacketSequence_Click);
			//
			// mnuPacketFlags
			//
			this.mnuPacketFlags.Index = 2;
			this.mnuPacketFlags.Text = "Packet flags";
			this.mnuPacketFlags.Click += new System.EventHandler(this.mnuPacketFlags_Click);
			//
			// openLogDialog
			//
			this.openLogDialog.Multiselect = true;
			//
			// saveLogDialog
			//
			this.saveLogDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveLogDialog_FileOk);
			//
			// mainFormTabs
			//
			this.mainFormTabs.Controls.Add(this.instantParseTab);
			this.mainFormTabs.Controls.Add(this.logInfoTab);
			this.mainFormTabs.Controls.Add(this.logDataTab);
			this.mainFormTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainFormTabs.Location = new System.Drawing.Point(0, 0);
			this.mainFormTabs.Name = "mainFormTabs";
			this.mainFormTabs.SelectedIndex = 0;
			this.mainFormTabs.Size = new System.Drawing.Size(592, 373);
			this.mainFormTabs.TabIndex = 0;
			//
			// instantParseTab
			//
			this.instantParseTab.Controls.Add(this.instantResultGroupBox1);
			this.instantParseTab.Controls.Add(this.inputDataGroupBox);
			this.instantParseTab.Location = new System.Drawing.Point(4, 22);
			this.instantParseTab.Name = "instantParseTab";
			this.instantParseTab.Size = new System.Drawing.Size(584, 347);
			this.instantParseTab.TabIndex = 2;
			this.instantParseTab.Text = "Instant parse";
			this.instantParseTab.UseVisualStyleBackColor = true;
			//
			// instantResultGroupBox1
			//
			this.instantResultGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.instantResultGroupBox1.Controls.Add(this.instantParseOut);
			this.instantResultGroupBox1.Location = new System.Drawing.Point(0, 176);
			this.instantResultGroupBox1.Name = "instantResultGroupBox1";
			this.instantResultGroupBox1.Size = new System.Drawing.Size(584, 172);
			this.instantResultGroupBox1.TabIndex = 2;
			this.instantResultGroupBox1.TabStop = false;
			this.instantResultGroupBox1.Text = "Instant result";
			//
			// instantParseOut
			//
			this.instantParseOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.instantParseOut.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.instantParseOut.Location = new System.Drawing.Point(8, 16);
			this.instantParseOut.Name = "instantParseOut";
			this.instantParseOut.ReadOnly = true;
			this.instantParseOut.Size = new System.Drawing.Size(568, 148);
			this.instantParseOut.TabIndex = 0;
			this.instantParseOut.Text = "";
			this.instantParseOut.WordWrap = false;
			//
			// inputDataGroupBox
			//
			this.inputDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.inputDataGroupBox.Controls.Add(this.button1);
			this.inputDataGroupBox.Controls.Add(this.instantParseInput);
			this.inputDataGroupBox.Controls.Add(this.instantServerToClient);
			this.inputDataGroupBox.Controls.Add(this.instantClientToServer);
			this.inputDataGroupBox.Controls.Add(this.label6);
			this.inputDataGroupBox.Controls.Add(this.instantCode);
			this.inputDataGroupBox.Controls.Add(this.label5);
			this.inputDataGroupBox.Controls.Add(this.instantVersion);
			this.inputDataGroupBox.Controls.Add(this.label4);
			this.inputDataGroupBox.Location = new System.Drawing.Point(0, 0);
			this.inputDataGroupBox.Name = "inputDataGroupBox";
			this.inputDataGroupBox.Size = new System.Drawing.Size(584, 168);
			this.inputDataGroupBox.TabIndex = 1;
			this.inputDataGroupBox.TabStop = false;
			this.inputDataGroupBox.Text = "Input data";
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(512, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Clear";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// instantParseInput
			//
			this.instantParseInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.instantParseInput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.instantParseInput.Location = new System.Drawing.Point(8, 48);
			this.instantParseInput.Multiline = true;
			this.instantParseInput.Name = "instantParseInput";
			this.instantParseInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.instantParseInput.Size = new System.Drawing.Size(568, 112);
			this.instantParseInput.TabIndex = 7;
			this.instantParseInput.WordWrap = false;
			this.instantParseInput.TextChanged += new System.EventHandler(this.InstantParseUpdateEvent);
			//
			// instantServerToClient
			//
			this.instantServerToClient.Checked = true;
			this.instantServerToClient.Location = new System.Drawing.Point(312, 24);
			this.instantServerToClient.Name = "instantServerToClient";
			this.instantServerToClient.Size = new System.Drawing.Size(104, 20);
			this.instantServerToClient.TabIndex = 6;
			this.instantServerToClient.TabStop = true;
			this.instantServerToClient.Text = "server to client";
			this.instantServerToClient.CheckedChanged += new System.EventHandler(this.InstantParseUpdateEvent);
			//
			// instantClientToServer
			//
			this.instantClientToServer.Location = new System.Drawing.Point(416, 24);
			this.instantClientToServer.Name = "instantClientToServer";
			this.instantClientToServer.Size = new System.Drawing.Size(96, 20);
			this.instantClientToServer.TabIndex = 5;
			this.instantClientToServer.Text = "client to server";
			this.instantClientToServer.CheckedChanged += new System.EventHandler(this.InstantParseUpdateEvent);
			//
			// label6
			//
			this.label6.Location = new System.Drawing.Point(248, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 20);
			this.label6.TabIndex = 4;
			this.label6.Text = "Direction:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// instantCode
			//
			this.instantCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.instantCode.Location = new System.Drawing.Point(176, 24);
			this.instantCode.MaxLength = 10;
			this.instantCode.Name = "instantCode";
			this.instantCode.Size = new System.Drawing.Size(64, 20);
			this.instantCode.TabIndex = 3;
			this.instantCode.TextChanged += new System.EventHandler(this.InstantParseUpdateEvent);
			//
			// label5
			//
			this.label5.Location = new System.Drawing.Point(128, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 20);
			this.label5.TabIndex = 2;
			this.label5.Text = "Code:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// instantVersion
			//
			this.instantVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.instantVersion.Location = new System.Drawing.Point(64, 24);
			this.instantVersion.MaxLength = 10;
			this.instantVersion.Name = "instantVersion";
			this.instantVersion.Size = new System.Drawing.Size(56, 20);
			this.instantVersion.TabIndex = 1;
			this.instantVersion.TextChanged += new System.EventHandler(this.InstantParseUpdateEvent);
			//
			// label4
			//
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Version:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// logInfoTab
			//
			this.logInfoTab.Controls.Add(this.li_openLogsGroupBox);
			this.logInfoTab.Controls.Add(this.li_initialValuesGroupBox);
			this.logInfoTab.Controls.Add(this.li_totalGroupBox);
			this.logInfoTab.Location = new System.Drawing.Point(4, 22);
			this.logInfoTab.Name = "logInfoTab";
			this.logInfoTab.Size = new System.Drawing.Size(584, 347);
			this.logInfoTab.TabIndex = 0;
			this.logInfoTab.Text = "Log info";
			this.logInfoTab.UseVisualStyleBackColor = true;
			//
			// li_openLogsGroupBox
			//
			this.li_openLogsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
            this.li_openLogsGroupBox.Controls.Add(this.removeButton);
			this.li_openLogsGroupBox.Controls.Add(this.li_changesLabel);
			this.li_openLogsGroupBox.Controls.Add(this.openLogsDataGridView);
			this.li_openLogsGroupBox.Controls.Add(this.applyButton);
			this.li_openLogsGroupBox.Controls.Add(this.label3);
			this.li_openLogsGroupBox.Location = new System.Drawing.Point(8, 151);
			this.li_openLogsGroupBox.Name = "li_openLogsGroupBox";
			this.li_openLogsGroupBox.Size = new System.Drawing.Size(568, 188);
			this.li_openLogsGroupBox.TabIndex = 13;
			this.li_openLogsGroupBox.TabStop = false;
			this.li_openLogsGroupBox.Text = "Open logs";
			//
			// li_changesLabel
			//
			this.li_changesLabel.Location = new System.Drawing.Point(6, 16);
			this.li_changesLabel.Name = "li_changesLabel";
			this.li_changesLabel.Size = new System.Drawing.Size(100, 23);
			this.li_changesLabel.TabIndex = 5;
			this.li_changesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// applyButton
			//
			this.applyButton.Location = new System.Drawing.Point(110, 16);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(100, 23);
			this.applyButton.TabIndex = 3;
			this.applyButton.Text = "Apply";
			this.applyButton.Click += new System.EventHandler(this.li_applyButton_Click);
			//
			// label3
			//
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(230, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(332, 32);
			this.label3.TabIndex = 4;
			this.label3.Text = "Parse only changed logs again using current values.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// li_initialValuesGroupBox
			//
			this.li_initialValuesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.li_initialValuesGroupBox.Controls.Add(this.label1);
			this.li_initialValuesGroupBox.Controls.Add(this.li_clientVersion);
			this.li_initialValuesGroupBox.Controls.Add(this.label2);
			this.li_initialValuesGroupBox.Controls.Add(this.li_ignoreVersionChanges);
			this.li_initialValuesGroupBox.Location = new System.Drawing.Point(8, 96);
			this.li_initialValuesGroupBox.Name = "li_initialValuesGroupBox";
			this.li_initialValuesGroupBox.Size = new System.Drawing.Size(568, 49);
			this.li_initialValuesGroupBox.TabIndex = 12;
			this.li_initialValuesGroupBox.TabStop = false;
			this.li_initialValuesGroupBox.Text = "Initial values";
			//
			// label1
			//
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Log version:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// li_clientVersion
			//
			this.li_clientVersion.Location = new System.Drawing.Point(110, 18);
			this.li_clientVersion.MaxLength = 10;
			this.li_clientVersion.Name = "li_clientVersion";
			this.li_clientVersion.Size = new System.Drawing.Size(100, 20);
			this.li_clientVersion.TabIndex = 1;
			//
			// label2
			//
			this.label2.Location = new System.Drawing.Point(230, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(208, 32);
			this.label2.TabIndex = 2;
			this.label2.Text = "Can be set explicitly if no version info is in the log else it will be overwriten" +
				".";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// li_ignoreVersionChanges
			//
			this.li_ignoreVersionChanges.Location = new System.Drawing.Point(446, 12);
			this.li_ignoreVersionChanges.Name = "li_ignoreVersionChanges";
			this.li_ignoreVersionChanges.Size = new System.Drawing.Size(116, 32);
			this.li_ignoreVersionChanges.TabIndex = 9;
			this.li_ignoreVersionChanges.Text = "Ignore version packets";
			//
			// li_totalGroupBox
			//
			this.li_totalGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.li_totalGroupBox.Controls.Add(this.label7);
			this.li_totalGroupBox.Controls.Add(this.label8);
			this.li_totalGroupBox.Controls.Add(this.li_packetsCount);
			this.li_totalGroupBox.Controls.Add(this.label9);
			this.li_totalGroupBox.Controls.Add(this.label10);
			this.li_totalGroupBox.Controls.Add(this.li_unknownPacketsCount);
			this.li_totalGroupBox.Location = new System.Drawing.Point(8, 6);
			this.li_totalGroupBox.Name = "li_totalGroupBox";
			this.li_totalGroupBox.Size = new System.Drawing.Size(568, 84);
			this.li_totalGroupBox.TabIndex = 11;
			this.li_totalGroupBox.TabStop = false;
			this.li_totalGroupBox.Text = "Total";
			//
			// label7
			//
			this.label7.Location = new System.Drawing.Point(230, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(332, 32);
			this.label7.TabIndex = 2;
			this.label7.Text = "The count of successfully parsed packets.";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// label8
			//
			this.label8.Location = new System.Drawing.Point(6, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 24);
			this.label8.TabIndex = 0;
			this.label8.Text = "Packets count:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// li_packetsCount
			//
			this.li_packetsCount.Location = new System.Drawing.Point(110, 18);
			this.li_packetsCount.MaxLength = 10;
			this.li_packetsCount.Name = "li_packetsCount";
			this.li_packetsCount.ReadOnly = true;
			this.li_packetsCount.Size = new System.Drawing.Size(100, 20);
			this.li_packetsCount.TabIndex = 1;
			//
			// label9
			//
			this.label9.Location = new System.Drawing.Point(230, 46);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(332, 32);
			this.label9.TabIndex = 8;
			this.label9.Text = "The count of unknown packets in logs.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// label10
			//
			this.label10.Location = new System.Drawing.Point(6, 50);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 24);
			this.label10.TabIndex = 6;
			this.label10.Text = "Unknown packets:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// li_unknownPacketsCount
			//
			this.li_unknownPacketsCount.Location = new System.Drawing.Point(110, 52);
			this.li_unknownPacketsCount.MaxLength = 10;
			this.li_unknownPacketsCount.Name = "li_unknownPacketsCount";
			this.li_unknownPacketsCount.ReadOnly = true;
			this.li_unknownPacketsCount.Size = new System.Drawing.Size(100, 20);
			this.li_unknownPacketsCount.TabIndex = 7;
			//
			// logDataTab
			//
			this.logDataTab.Controls.Add(this.logDataCountLogDataSizeheckBox);
			this.logDataTab.Controls.Add(this.logDataDisableUpdatesCheckBox);
			this.logDataTab.Controls.Add(this.logDataFindButton);
			this.logDataTab.Controls.Add(this.logDataFindTextBox);
			this.logDataTab.Controls.Add(this.logDataText);
			this.logDataTab.Location = new System.Drawing.Point(4, 22);
			this.logDataTab.Name = "logDataTab";
			this.logDataTab.Size = new System.Drawing.Size(584, 347);
			this.logDataTab.TabIndex = 1;
			this.logDataTab.Text = "Log data";
			this.logDataTab.UseVisualStyleBackColor = true;
			//
			// logDataCountLogDataSizeheckBox
			//
			this.logDataCountLogDataSizeheckBox.AutoSize = true;
			this.logDataCountLogDataSizeheckBox.Checked = true;
			this.logDataCountLogDataSizeheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.logDataCountLogDataSizeheckBox.Location = new System.Drawing.Point(126, 12);
			this.logDataCountLogDataSizeheckBox.Name = "logDataCountLogDataSizeheckBox";
			this.logDataCountLogDataSizeheckBox.Size = new System.Drawing.Size(227, 17);
			this.logDataCountLogDataSizeheckBox.TabIndex = 4;
			this.logDataCountLogDataSizeheckBox.Text = "Count log data size before buffer allocation";
			this.logDataCountLogDataSizeheckBox.UseVisualStyleBackColor = true;
			//
			// logDataDisableUpdatesCheckBox
			//
			this.logDataDisableUpdatesCheckBox.Location = new System.Drawing.Point(16, 8);
			this.logDataDisableUpdatesCheckBox.Name = "logDataDisableUpdatesCheckBox";
			this.logDataDisableUpdatesCheckBox.Size = new System.Drawing.Size(104, 24);
			this.logDataDisableUpdatesCheckBox.TabIndex = 3;
			this.logDataDisableUpdatesCheckBox.Text = "disable updates";
			this.logDataDisableUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.logDataDisableUpdatesCheckBox_CheckedChanged);
			//
			// logDataFindButton
			//
			this.logDataFindButton.Location = new System.Drawing.Point(8, 40);
			this.logDataFindButton.Name = "logDataFindButton";
			this.logDataFindButton.Size = new System.Drawing.Size(75, 23);
			this.logDataFindButton.TabIndex = 2;
			this.logDataFindButton.Text = "&Find";
			this.logDataFindButton.Click += new System.EventHandler(this.logDataFindButton_Click);
			//
			// logDataFindTextBox
			//
			this.logDataFindTextBox.Location = new System.Drawing.Point(88, 40);
			this.logDataFindTextBox.Name = "logDataFindTextBox";
			this.logDataFindTextBox.Size = new System.Drawing.Size(488, 20);
			this.logDataFindTextBox.TabIndex = 1;
			this.logDataFindTextBox.WordWrap = false;
			this.logDataFindTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logDataFindText_KeyPress);
			//
			// logDataText
			//
			this.logDataText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.logDataText.DetectUrls = false;
			this.logDataText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logDataText.Location = new System.Drawing.Point(0, 72);
			this.logDataText.Name = "logDataText";
			this.logDataText.ReadOnly = true;
			this.logDataText.Size = new System.Drawing.Size(584, 272);
			this.logDataText.TabIndex = 0;
			this.logDataText.Text = "";
			this.logDataText.WordWrap = false;
			this.logDataText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logDataText_KeyDown);
			this.logDataText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logDataFindText_KeyPress);
			//
			// openAnotherLogDialog
			//
			this.openAnotherLogDialog.Multiselect = true;
			//
			// openFilterDialog
			//
			this.openFilterDialog.Filter = "Filters (*.flt)|*.flt";
			this.openFilterDialog.RestoreDirectory = true;
			//
			// saveFilterDialog
			//
			this.saveFilterDialog.Filter = "Filters (*.flt)|*.flt";
			this.saveFilterDialog.RestoreDirectory = true;
			//
            // removeButton
            //
            this.removeButton.Location = new System.Drawing.Point(490, 16);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(65, 23);
            this.removeButton.TabIndex = 11;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            //
			// MainForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.mainFormTabs);
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.openLogsDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.openLogsBindingSource)).EndInit();
			this.mainFormTabs.ResumeLayout(false);
			this.instantParseTab.ResumeLayout(false);
			this.instantResultGroupBox1.ResumeLayout(false);
			this.inputDataGroupBox.ResumeLayout(false);
			this.inputDataGroupBox.PerformLayout();
			this.logInfoTab.ResumeLayout(false);
			this.li_openLogsGroupBox.ResumeLayout(false);
			this.li_initialValuesGroupBox.ResumeLayout(false);
			this.li_initialValuesGroupBox.PerformLayout();
			this.li_totalGroupBox.ResumeLayout(false);
			this.li_totalGroupBox.PerformLayout();
			this.logDataTab.ResumeLayout(false);
			this.logDataTab.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private static MainForm m_formInstance;

		/// <summary>
		/// Gets the form instance.
		/// </summary>
		/// <value>The form instance.</value>
		public static MainForm Instance
		{
			get { return m_formInstance; }
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Thread.CurrentThread.Name = "Main";
				AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionCallback;
				m_formInstance = new MainForm();
				Application.Run(m_formInstance);
				Application.Exit();

				Debug.Close();
			}
			catch (Exception e)
			{
				Log.Error("application loop", e);
			}
		}

		private static void UnhandledExceptionCallback(object sender, UnhandledExceptionEventArgs e)
		{
			if (e.ExceptionObject is Exception)
				Log.Error("unhandled exception", (Exception) e.ExceptionObject);
			else
				Log.Error(e.ExceptionObject.ToString());
		}

		#region Events

		public delegate void LogReaderDelegate(ILogReader reader);

		public event LogReaderDelegate FilesLoaded;

		#endregion

		#region Misc

		private readonly Progress m_progress;

		private readonly LogManager m_currentLogs = new LogManager();
		private readonly FilterManager	m_filterManager = new FilterManager();

		/// <summary>
		/// Gets or sets the current log.
		/// </summary>
		/// <value>The current log.</value>
		public LogManager LogManager
		{
			get { return m_currentLogs; }
		}

		/// <summary>
		/// Gets the filter manager.
		/// </summary>
		/// <value>The filter manager.</value>
		public FilterManager FilterManager
		{
			get { return m_filterManager; }
		}

		/// <summary>
		/// Called when packet logs change - updates UI.
		/// </summary>
		/// <param name="logManager">The log manager.</param>
		private void OnPacketLogsChanged(LogManager logManager)
		{
			UpdateLogDataTab();
			UpdateLogInfoTab();
			UpdateCaption();
			menuSaveFile.Enabled = (m_currentLogs.Logs.Count > 0);
			GC.Collect();
		}

		/// <summary>
		/// Shows the data tab.
		/// </summary>
		public void ShowDataTab()
		{
			mainFormTabs.SelectedTab = logDataTab;
		}

		private ArrayList m_logReaders = new ArrayList();
		private ArrayList m_logWriters = new ArrayList();
		private ArrayList m_logFilters = new ArrayList();
		private SortedList m_filterMenuItemsByPriority = new SortedList();
		private SortedList m_actionMenuItemsByPriority = new SortedList();
		private SortedList m_actionByPriority = new SortedList();
		private Hashtable m_actionByMenuItem = new Hashtable();

		/// <summary>
		/// Handles the Load event of the MainForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			// Create temp data storage
			SortedList readers = new SortedList();
			SortedList writers = new SortedList();
			SortedList filters = new SortedList();
			Hashtable readerFilterStrings = new Hashtable();
			Hashtable writerFilterStrings = new Hashtable();
			m_filterMenuItemsByPriority.Clear();
			m_actionMenuItemsByPriority.Clear();
			m_actionByMenuItem.Clear();
			m_actionByPriority.Clear();

			// Find handlers
			FindAllHandlers(m_actionMenuItemsByPriority, m_actionByMenuItem, m_actionByPriority, m_filterMenuItemsByPriority, filters, readerFilterStrings, readers, writerFilterStrings, writers);


			//
			// Initialize UI with found handlers
			//

			string openFilter = "";
			foreach (DictionaryEntry entry in readers)
			{
				int position = (int)entry.Key;
				ILogReader reader = (ILogReader)entry.Value;
				if (openFilter.Length > 0)
					openFilter += "|";
				openFilter += (string)readerFilterStrings[position];
				m_logReaders.Add(reader);
			}
			openLogDialog.Filter = openFilter;
			openAnotherLogDialog.Filter = openFilter;
        	openFolderLogDialog.Description = "Select the directory that you want to use as Open logs";
        	openFolderLogDialog.ShowNewFolderButton = false;

			string saveFilter = "";
			foreach (DictionaryEntry entry in writers)
			{
				int position = (int)entry.Key;
				ILogWriter writer = (ILogWriter)entry.Value;
				if (saveFilter.Length > 0)
					saveFilter += "|";
				saveFilter += (string)writerFilterStrings[position];
				m_logWriters.Add(writer);
			}
			saveLogDialog.Filter = saveFilter;

			// Filters menu
			if (filters.Count > 0)
			{
				CreateMenuFilters(m_filterMenuItemsByPriority, filters);

				// Add event handlers
				FilterManager.FilterAddedEvent		+= new FilterAction(OnFilterAdded);
				FilterManager.FilterRemovedEvent	+= new FilterAction(OnFilterRemoved);
			}

			// Actions menu
			if (m_actionByPriority.Count > 0)
			{
				logDataText.MouseDown += logDataText_MouseClickEvent;
			}

			// Updates
			UpdateRecentFilesMenu();
			UpdateCaption();

			// Settings
			LoadSettings();
		}

		/// <summary>
		/// Handles the FormClosing event of the MainForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Settings
			SaveSettings();
		}

		/// <summary>
		/// Finds all handlers.
		/// </summary>
		/// <param name="actionMenuItems">The action menu items.</param>
		/// <param name="actionsByMenuItem">The actions by menu item.</param>
		/// <param name="actions">The action names.</param>
		/// <param name="filterMenuItems">The filter menu items.</param>
		/// <param name="filters">The filter names.</param>
		/// <param name="readerFilterStrings">The reader filter strings.</param>
		/// <param name="readers">The reader names.</param>
		/// <param name="writerFilterStrings">The writer filter strings.</param>
		/// <param name="writers">The writer names.</param>
		private void FindAllHandlers(IDictionary actionMenuItems, IDictionary actionsByMenuItem, SortedList actions, IDictionary filterMenuItems, SortedList filters, Hashtable readerFilterStrings, SortedList readers, Hashtable writerFilterStrings, SortedList writers)
		{
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type type in asm.GetTypes())
				{
					if (!type.IsClass) continue;

					try
					{
						// is log reader
						if (typeof(ILogReader).IsAssignableFrom(type))
						{
							foreach (LogReaderAttribute attr in type.GetCustomAttributes(typeof(LogReaderAttribute), false))
							{
								int position = -attr.Priority;
								while (readers.ContainsKey(position))
									++position;
								readers.Add(position, Activator.CreateInstance(type));
								readerFilterStrings.Add(position, string.Format("{0} ({1})|{1}", attr.Description, attr.FileMask));
							}
						}

						// is log writer
						if (typeof(ILogWriter).IsAssignableFrom(type))
						{
							foreach (LogWriterAttribute attr in type.GetCustomAttributes(typeof(LogWriterAttribute), false))
							{
								int position = -attr.Priority;
								while (writers.ContainsKey(position))
									++position;
								writers.Add(position, Activator.CreateInstance(type));
								writerFilterStrings.Add(position, string.Format("{0} ({1})|{1}", attr.Description, attr.FileMask));
							}
						}

						// is log filter
						if (typeof(ILogFilter).IsAssignableFrom(type))
						{
							foreach (LogFilterAttribute attr in type.GetCustomAttributes(typeof(LogFilterAttribute), false))
							{
								string name = attr.FilterName;
								if (name == null || name.Length <= 0)
									name = type.Name;
								MenuItem filterMenuItem = new MenuItem(name, new EventHandler(FilterClick_Event));
								filterMenuItem.ShowShortcut = true;
								filterMenuItem.Shortcut = attr.ShortcutKey;

								int position = -attr.Priority;
								while (filters.ContainsKey(position))
									++position;
								filters.Add(position, Activator.CreateInstance(type, this));
								filterMenuItems.Add(position, filterMenuItem);
							}
						}

						// is log action
						if (typeof(ILogAction).IsAssignableFrom(type))
						{
							foreach (LogActionAttribute attr in type.GetCustomAttributes(typeof(LogActionAttribute), false))
							{
								string name = attr.Name;
								if (name == null || name.Length <= 0)
									name = type.Name;
								MenuItem actionMenuItem = new MenuItem(name, new EventHandler(LogActionClick_Event));

								int position = -attr.Priority;
								while (actions.ContainsKey(position))
									++position;
								object action = Activator.CreateInstance(type);
								actions.Add(position, action);
								actionMenuItems.Add(position, actionMenuItem);
								actionsByMenuItem.Add(actionMenuItem, action);
							}
						}
					}
					catch (Exception e1)
					{
						Log.Error("loading type: " + type.FullName, e1);
					}
				}
			}
		}

		/// <summary>
		/// Creates the actions menu.
		/// </summary>
		/// <param name="actionMenuItems">The action menu items.</param>
		/// <param name="actions">The actions.</param>
		/// <param name="selectedPacket">Location of selected packet.</param>
		/// <returns>Context menu with actions for specified packet if at least one eixsts, <c>null</c> otherwise.</returns>
		private ContextMenu CreateMenuActions(IDictionary actionMenuItems, SortedList actions, PacketLocation selectedPacket)
		{
			ArrayList actionsMenu = new ArrayList();
			foreach (DictionaryEntry entry in actions)
			{
				int position = (int)entry.Key;
				ILogAction action = (ILogAction)entry.Value;
				if (action.IsEnabled(this, selectedPacket))
				{
					actionsMenu.Add(actionMenuItems[position]);
				}
			}

			ContextMenu ret = null;
			if (actionsMenu.Count > 0)
			{
				ret = new ContextMenu((MenuItem[]) actionsMenu.ToArray(typeof (MenuItem)));
			}
			return ret;
		}

		/// <summary>
		/// Creates the filters menu.
		/// </summary>
		/// <param name="filterMenuItems">The filter menu items.</param>
		/// <param name="filters">The filters.</param>
		private void CreateMenuFilters(IDictionary filterMenuItems, SortedList filters)
		{
			ArrayList menu = new ArrayList();

			// "Load filters" option
			m_filterMenuFiltersLoad = new MenuItem("&Load filters...");
			m_filterMenuFiltersLoad.Click += delegate(object sender, EventArgs e)
			{
				if (DialogResult.OK == openFilterDialog.ShowDialog(this))
				{
					saveFilterDialog.FileName = openFilterDialog.FileName;
					FilterManager.LoadFilters(openFilterDialog.FileName, m_logFilters);
					if (!FilterManager.IgnoreFilters)// try fix update filters while ignore filter is ON
						UpdateLogDataTab();
				}
			};
			menu.Add(m_filterMenuFiltersLoad);

			// "Save filters" option
			m_filterMenuFiltersSave = new MenuItem("&Save filters...");
			m_filterMenuFiltersSave.Click += delegate(object sender, EventArgs e)
			{
				// "Save" menu item
				if (DialogResult.OK == saveFilterDialog.ShowDialog(this))
				{
					openFilterDialog.FileName = saveFilterDialog.FileName;
					FilterManager.SaveFilters(saveFilterDialog.FileName);
				}
			};
			menu.Add(m_filterMenuFiltersSave);

			menu.Add(new MenuItem("-"));

			// "Combine" option
			m_filterMenuCombineFilters = new MenuItem("Combine filters", new EventHandler(FilterClick_Event));
			m_filterMenuCombineFilters.Checked = FilterManager.CombineFilters;
			FilterManager.CombineFiltersChangedEvent += delegate(bool newValue)
			{
		   		m_filterMenuCombineFilters.Checked = newValue;
				if (!FilterManager.IgnoreFilters)// try fix update filters while ignore filter is ON
					UpdateLogDataTab();
		   	};
			menu.Add(m_filterMenuCombineFilters);

			// "Invert" option
			m_filterMenuInvertCheck = new MenuItem("Invert check", new EventHandler(FilterClick_Event));
			m_filterMenuInvertCheck.Checked = false;
			FilterManager.InvertCheckChangedEvent += delegate(bool newValue)
			{
				m_filterMenuInvertCheck.Checked = newValue;
				if (!FilterManager.IgnoreFilters)// try fix update filters while ignore filter is ON
					UpdateLogDataTab();
			};
			menu.Add(m_filterMenuInvertCheck);

			// "Ignore" option
			m_filterMenuIgnoreFilters = new MenuItem("Ignore filters", new EventHandler(FilterClick_Event));
			m_filterMenuIgnoreFilters.Checked = FilterManager.IgnoreFilters;
			m_filterMenuIgnoreFilters.ShowShortcut = true;
			m_filterMenuIgnoreFilters.Shortcut = System.Windows.Forms.Shortcut.AltBksp;
			FilterManager.IgnoreFiltersChangedEvent += delegate(bool newValue)
			{
				m_filterMenuIgnoreFilters.Checked = newValue;
				UpdateLogDataTab();
			};
			menu.Add(m_filterMenuIgnoreFilters);


			menu.Add(new MenuItem("-"));

			// Save count of static elements for proper index calculation
			m_filterMenuStaticElementsCount = menu.Count;

			// Add dynamically loaded handlers in proper order
			foreach (DictionaryEntry entry in filters)
			{
				int position = (int)entry.Key;
				ILogFilter filter = (ILogFilter)entry.Value;
				menu.Add(filterMenuItems[position]);
				m_logFilters.Add(filter);
			}

			mainMenu1.MenuItems.Add("F&ilters", (MenuItem[])menu.ToArray(typeof (MenuItem)));
		}

		/// <summary>
		/// Updates the caption.
		/// </summary>
		private void UpdateCaption()
		{
			string caption = "packet log converter v" + Assembly.GetExecutingAssembly().GetName().Version;
			string streamNames = LogManager.GetStreamNames();
			if (!string.IsNullOrEmpty(streamNames))
			{
				caption += ": " + streamNames;
			}
			Text = caption;
		}

		#region open files

		/// <summary>
		/// Loads the files.
		/// </summary>
		/// <param name="reader">The log reader.</param>
		/// <param name="logs">The list to add open logs to.</param>
		/// <param name="files">The files too open.</param>
		/// <param name="initialVersion">The initial log version.</param>
		/// <param name="ignoreVersionChanges">If set to <c>true</c> version information in the log is ignored.</param>
		/// <param name="progress">The progress.</param>
		private void LoadFiles(ILogReader reader,
								ICollection<PacketLog> logs,
								string[] files,
								float initialVersion,
								bool ignoreVersionChanges,
								ProgressCallback progress)
		{
			foreach (string fileName in files)
			{
				try
				{
					// Create new log for each file
					PacketLog log = new PacketLog();
					log.Version = initialVersion;
					log.IgnoreVersionChanges = ignoreVersionChanges;

					m_progress.SetDescription("Loading file: " + fileName + "...");

					// Check if file exists
					FileInfo fileInfo = new FileInfo(fileName);
					if (!fileInfo.Exists)
					{
						Log.Info("File \"" + fileInfo.FullName + "\" doesn't exist, ignored.");
						continue;
					}

					// Add all packets
					using(FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						log.AddRange(reader.ReadLog(new BufferedStream(stream, 64*1024), progress));
					}

					// Initialize log
					m_progress.SetDescription("Initializing log and packets...");
					log.Init(LogManager, 3, progress);

					// Set stream name
					log.StreamName = fileInfo.FullName;

					AddRecentFile(fileInfo.FullName);
					logs.Add(log);
				}
				catch (Exception e)
				{
					Log.Error("loading files", e);
				}
			}
		}

		private class OpenData
		{
			public string[] Files;
			public ILogReader Reader;
			public IList<PacketLog> Logs;
		}

		private void menuOpenFile_Click(object sender, EventArgs e)
		{
			if (m_logReaders.Count <= 0)
			{
				Log.Info("No log readers found.");
				return;
			}

			if (openLogDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					OpenData data = new OpenData();
					data.Files = openLogDialog.FileNames;
					data.Reader = (ILogReader) m_logReaders[openLogDialog.FilterIndex - 1];
					LogManager.ClearLogs();
					m_progress.SetDescription("Reading file(s)...");
					m_progress.WorkFinishedCallback = new StateObjectCallback(OpenFileFinishedCallback);
					m_progress.Start(new WorkCallback(OpenFilesWorkCallback), data);
				}
				catch (Exception e1)
				{
					Log.Error("opening file", e1);
				}
				finally
				{
					UpdateCaption();
				}
			}
		}

		private void OpenFilesWorkCallback(ProgressCallback progress, object state)
		{
			OpenData data = (OpenData) state;
			data.Logs = new List<PacketLog>();

			float version;
			Util.ParseFloat(li_clientVersion.Text, out version, -1);

			LoadFiles(data.Reader, data.Logs, data.Files, version, li_ignoreVersionChanges.Checked, progress);
		}

		private void OpenFileFinishedCallback(object state)
		{
			OpenData data = (OpenData)state;

			// Count packets
			LogManager tempManager = new LogManager();
			tempManager.AddLogRange(LogManager.Logs);
			tempManager.AddLogRange(data.Logs);

			if (tempManager.CountPackets() > 100000)
			{
				logDataDisableUpdatesCheckBox.Checked = true;
				mainFormTabs.SelectedTab = logInfoTab;
			}
			else
			{
				mainFormTabs.SelectedTab = logDataTab;
			}
			Refresh();

			// Add loaded logs to the current list
			LogManager.AddLogRange(data.Logs);

			// Update current version
			logDataText.Focus();

			LogReaderDelegate e = FilesLoaded;
			if (e != null)
				e(data.Reader);

			// Clear stored positions
			ClearLogPositions();
		}

		private void menuOpenAnother_Click(object sender, System.EventArgs e)
		{
			if (m_logReaders.Count > 0)
			{
				openAnotherLogDialog.FileName = openLogDialog.FileName;
				if (openAnotherLogDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						// Disable log text updates if log is too long
						if (LogManager.CountPackets() > 100000)
						{
							logDataDisableUpdatesCheckBox.Checked = true;
						}
						OpenData data = new OpenData();
						data.Files = openAnotherLogDialog.FileNames;
						data.Reader = (ILogReader) m_logReaders[openAnotherLogDialog.FilterIndex - 1];
//						LogManager = null;
						m_progress.SetDescription("Reading file(s)...");
						m_progress.WorkFinishedCallback = new StateObjectCallback(OpenFileFinishedCallback);
						m_progress.Start(new WorkCallback(OpenFilesWorkCallback), data);
					}
					catch (Exception e1)
					{
						Log.Error("opening another file", e1);
					}
					finally
					{
						UpdateCaption();
					}
				}
			}
			else
				Log.Info("No log readers found.");
		}

		/// <summary>
		/// Gets the directory files.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="deep">if set to <c>true</c> recursively retrives files from all sub-directories.</param>
		/// <returns>List with found file info</returns>
		private static List<FileInfo> GetDirectoryFiles(DirectoryInfo path, string filter, bool deep)
		{
			List<FileInfo> files = new List<FileInfo>();
    		if (!path.Exists)
				return files;
    		files.AddRange(path.GetFiles(filter));
			if (deep)
			{
				foreach (DirectoryInfo subdir in path.GetDirectories())
					files.AddRange(GetDirectoryFiles(subdir, filter, deep));
			}
			return files;
		}

		/// <summary>
		/// Handles the Click event of the menuOpenFolder control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		private void menuOpenFolder_Click(object sender, System.EventArgs e)
		{
			if (m_logReaders.Count > 0)
			{
				// Show the FolderBrowserDialog.
				openFolderLogDialog.SelectedPath = openLogDialog.InitialDirectory;
				if (openFolderLogDialog.ShowDialog() == DialogResult.OK)
				{
					openLogDialog.InitialDirectory = openFolderLogDialog.SelectedPath;
					// Start loads logs
					List<FileInfo> filesInDir = GetDirectoryFiles(new DirectoryInfo(openFolderLogDialog.SelectedPath), "*.log", true);
					if (filesInDir.Count > 0)
					{
						try
						{
							int i = 0;
							OpenData data = new OpenData();
//							data.Files = (string[])GetDirectoryFiles(new DirectoryInfo(openFolderLogDialog.SelectedPath), "*.log", true).ToArray(typeof(string));
							data.Files = new string[filesInDir.Count];
							foreach(FileInfo s in filesInDir)
								data.Files[i++] = s.FullName;
							data.Reader = (ILogReader) m_logReaders[openLogDialog.FilterIndex - 1];
							LogManager.ClearLogs();
							m_progress.SetDescription("Reading file(s)...");
							m_progress.WorkFinishedCallback = new StateObjectCallback(OpenFileFinishedCallback);
							m_progress.Start(new WorkCallback(OpenFilesWorkCallback), data);
						}
						catch (Exception e1)
						{
							Log.Error("opening file", e1);
						}
						finally
						{
							UpdateCaption();
						}
					}
					filesInDir = null;
				}
			}
			else
				Log.Info("No log readers found.");
		}

		#endregion

		/// <summary>
		/// Handles the Click event of the menuSaveFile control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		private void menuSaveFile_Click(object sender, EventArgs e)
		{
			if (LogManager == null)
			{
				Log.Info("Nothing to save.");
				return;
			}

			if (m_logWriters.Count > 0)
				saveLogDialog.ShowDialog();
			else
				Log.Info("No log writers found.");
		}

		/// <summary>
		/// Handles the FileOk event of the saveLogDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
		private void saveLogDialog_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				m_progress.SetDescription("Saving file...");
				m_progress.Start(new WorkCallback(SaveFileProc), saveLogDialog.FileName);
			}
			catch (Exception e1)
			{
				Log.Error("saving file", e1);
			}
		}

		/// <summary>
		/// Saves the file proc.
		/// </summary>
		/// <param name="callback">The callback.</param>
		/// <param name="state">The state.</param>
		private void SaveFileProc(ProgressCallback callback, object state)
		{
			// Notify filter manager
			FilterManager.LogFilteringStarted(this);

			try
			{
				ILogWriter writer = (ILogWriter)m_logWriters[saveLogDialog.FilterIndex - 1];
				using (FileStream stream = new FileStream(saveLogDialog.FileName, FileMode.Create))
				{
					writer.WriteLog(this, stream, callback);
				}
			}
			finally
			{
				// Notify filter manager
				FilterManager.LogFilteringStopped(this);
			}
		}

		/// <summary>
		/// Handles the Click event of the menuExitApp control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		private void menuExitApp_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region Registry

		const string RegKeysPath = @"Software\DawnOfLight\PacketLogConverter\";
		const string FilterFolder = "FilterFolder";
		const string LogsFolder = "LogsFolder";

		private void UpdateRecentFilesMenu()
		{
			ArrayList menu = new ArrayList();

			RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKeysPath);

			if (key != null)
			{
				using (key)
				{
					ArrayList keyNames = new ArrayList();
					foreach (string subvalue in key.GetValueNames())
					{
						if (subvalue.StartsWith("RecentFile"))
							keyNames.Add(subvalue);
					}
					keyNames.Sort();
					foreach (string subkey in keyNames)
					{
						string path = (string) key.GetValue(subkey);
						if (path.Length > 0)
						{
							MenuItem item = new MenuItem(path.Replace("&", "&&"));
							item.Click += new EventHandler(RecentFileMenuItem_Click);
							menu.Add(item);
						}
					}
				}
			}

			menuRecentFiles.MenuItems.Clear();

			if (menu.Count > 0)
			{
				menuRecentFiles.Enabled = true;
				menuRecentFiles.MenuItems.AddRange((MenuItem[]) menu.ToArray(typeof (MenuItem)));
			}
			else
			{
				menuRecentFiles.Enabled = false;
			}
		}

		private void AddRecentFile(string fileName)
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKeysPath);

			if (key != null)
			{
				using (key)
				{
					SortedList filesList = new SortedList();
					foreach (string subvalue in key.GetValueNames())
					{
						if (subvalue.StartsWith("RecentFile"))
						{
							string val = (string) key.GetValue(subvalue, "");
							if (val != fileName)
								filesList.Add(subvalue, val);
						}
					}
					key.SetValue("RecentFile00", fileName);
					int index = 1;
					foreach (DictionaryEntry entry in filesList)
					{
						string file = (string) entry.Value;
						string newKey = string.Format("RecentFile{0:D2}", index);
						key.SetValue(newKey, file);
						if (index++ > 8)
							break;
					}
				}

				UpdateRecentFilesMenu();
			}
		}

		/// <summary>
		/// Saves the settings to registry.
		/// </summary>
		private void SaveSettings()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKeysPath);

				if (key != null)
				{
					using (key)
					{
						// Filter folder
						SaveFileDialogFolder(key, FilterFolder, openFilterDialog);

						// Logs folder
						SaveFileDialogFolder(key, LogsFolder, openLogDialog);
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e.Message, e);
			}
		}

		/// <summary>
		/// Saves the file dialog folder.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="regKeyName">Name of the reg key.</param>
		/// <param name="dialog">The dialog.</param>
		private void SaveFileDialogFolder(RegistryKey key, string regKeyName, FileDialog dialog)
		{
			string fileName = dialog.FileName;
			if (fileName != null && fileName.Length > 0)
			{
				FileInfo fileInfo = new FileInfo(fileName);
				key.SetValue(regKeyName, fileInfo.DirectoryName);
			}
		}

		/// <summary>
		/// Loads the settings from registry.
		/// </summary>
		private void LoadSettings()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKeysPath);

				if (key != null)
				{
					using (key)
					{
						// Filters folder
						string filterFolder = key.GetValue(FilterFolder) as string;
						LoadFolderDialog(filterFolder, openFilterDialog);
						LoadFolderDialog(filterFolder, saveFilterDialog);

						// Logs folder
						string logsFolder = key.GetValue(LogsFolder) as string;
						LoadFolderDialog(logsFolder, openLogDialog);
						LoadFolderDialog(logsFolder, saveLogDialog);
						LoadFolderDialog(logsFolder, openAnotherLogDialog);
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e.Message, e);
			}
		}

		/// <summary>
		/// Loads the folder dialog.
		/// </summary>
		/// <param name="dialog">The dialog.</param>
		/// <param name="folder">The folder.</param>
		private void LoadFolderDialog(string folder, FileDialog dialog)
		{
			if (folder != null && folder.Length > 0)
			{
				dialog.InitialDirectory = folder;
			}
		}

		private void RecentFileMenuItem_Click(object sender, EventArgs e)
		{
//			if (m_logReaders.Count <= 0)
//				return;

			MenuItem item = (MenuItem) sender;

			LogManager.ClearLogs();
			OpenData data = new OpenData();
			data.Reader = new AutoDetectLogReader();
			data.Files = new string[] { item.Text.Replace("&&", "&") };
			m_progress.SetDescription("Opening recent file...");
			m_progress.WorkFinishedCallback = new StateObjectCallback(OpenFileFinishedCallback);
			m_progress.Start(new WorkCallback(OpenFilesWorkCallback), data);
		}

		#endregion

		#region Log data tab

		private void UpdateLogDataTab()
		{
			try
			{
				string newTabName = "Log data";
				if (FilterManager.FiltersCount > 0)
				{
					newTabName += " (filtered)";
				}
				logDataTab.Text = newTabName;

				if (logDataDisableUpdatesCheckBox.Checked)
					return;

				if (LogManager == null)
				{
					logDataText.Clear();
					return;
				}

				PacketLocation selectedPacket = PacketLocation.UNKNOWN;
				if (logDataText.TextLength > 0)
				{
					selectedPacket = LogManager.FindPacketInfoByTextIndex(logDataText.SelectionStart).PacketLocation;
				}

				// Clear current log data before new memory is allocated
				this.logDataText.SuspendLayout();
				logDataText.Clear();
				logDataText.Rtf = null;
				GC.Collect();

				bool timeDiff = packetTimeDiffMenuItem.Checked;
				bool showPacketSequence = mnuPacketSequence.Checked;
				TimeSpan baseTime = TimeSpan.Zero;
				LogDataStatistics stats = LogDataStatistics.Zero;

				//
				// Calculate the size of string buffer
				//
				IList<PacketLog> logs = LogManager.Logs;
				int visiblePacketsCount = 0;
 				int logSize = 0;
				const string NEW_LINE = "\n";
				FilterManager.LogFilteringStarted(this);
				try
				{
					MemoryStream ms = new MemoryStream();
					using (StreamWriter text = new CustomStreamWriter(ms))
					{
						// Use the same new line char as in rich text box
						text.NewLine = NEW_LINE;

						// Count text only if checkbox enabled, but need to count packets all the time
						StreamWriter textImpl = (logDataCountLogDataSizeheckBox.Checked ? text : null);

						foreach (PacketLog log in logs)
						{
							foreach (Packet pak in log)
							{
#warning TODO: Sum of bytes here is not equal to what is shown in text box?

								if (!FilterManager.IsPacketIgnored(pak))
								{
									visiblePacketsCount++;

									if (null != textImpl)
									{
										AppendPacketData(textImpl, pak, ref stats, showPacketSequence, ref baseTime, timeDiff);
										text.Flush();
										logSize += (int) ms.Position;
										ms.Position = 0;
									}
								}
							}
						}
					}
				}
				finally
				{
					FilterManager.LogFilteringStopped(this);
				}

				// Reset variables after log data size is counted
				stats = LogDataStatistics.Zero;
				baseTime = TimeSpan.Zero;

				// Notify filter manager that log filtering starts
				FilterManager.LogFilteringStarted(this);

				// Decide which initial buffer size is used
				int capacity = 0;
				if (logDataCountLogDataSizeheckBox.Checked)
				{
					capacity = logSize;
				}

				// Update count of visible packets
				LogManager.SetVisiblePacketsCount(visiblePacketsCount);

				try
				{
					MemoryStream ms = new MemoryStream(capacity);
					using (StreamWriter text = new CustomStreamWriter(ms))
					{
						// Use the same new line char as in rich text box
						text.NewLine = NEW_LINE;

						int packetIndex = 0;
						for (int logIndex = 0; logs.Count > logIndex; logIndex++)
						{
							PacketLog log = logs[logIndex];
							log.LogSelected = true;
							for (int logPacketIndex = 0; log.Count > logPacketIndex; logPacketIndex++)
							{
								Packet pak = log[logPacketIndex];
								if (!FilterManager.IsPacketIgnored(pak))
								{
									log.LogSelected = false;
									AppendPacketData(text, pak, ref stats, showPacketSequence, ref baseTime, timeDiff);

									text.Flush();
									int index = (int)ms.Position;

									// Store visible packet info
									PacketInfo packetInfo = new PacketInfo(pak, index, new PacketLocation(logIndex, logPacketIndex));
									LogManager.SetVisiblePacket(packetIndex++, packetInfo);
								}
							}
						}

						newTabName = string.Format("{0} ({1}{2:N0} packets)", newTabName, (timeDiff ? "time diff, " : ""), stats.PacketsCount);
						logDataTab.Text = newTabName;

						// Load text to richbox from the very beginning
						ms.Position = 0;
						logDataText.SelectionIndent = 4;
						logDataText.LoadFile(ms, RichTextBoxStreamType.PlainText);
					}
					ms = null;
					GC.Collect();
				}
				finally
				{
					// Notify filter manager that filtering is finished
					FilterManager.LogFilteringStopped(this); // need this really ?
//					this.logDataText.ResumeLayout(); // it need really ?
					this.openLogsDataGridView.Invalidate();
				}

				// Restore previously selected packet if it is visible
				int restoreIndex = -1;
				if (PacketLocation.UNKNOWN != selectedPacket && logs.Count > selectedPacket.LogIndex
					&& logs[selectedPacket.LogIndex].Count > selectedPacket.PacketIndex)
				{
					Packet restorePacket = LogManager.GetPacket(selectedPacket);
					if (null != restorePacket)
					{
						restoreIndex = LogManager.FindTextIndexByPacket(restorePacket);
					}
				}
				if (restoreIndex >= 0)
				{
					logDataText.SelectionStart = restoreIndex;
				}
			}
			catch (Exception e)
			{
				Log.Error("updating data tab", e);
			}
		}

		/// <summary>
		/// Appends the packet data.
		/// </summary>
		/// <param name="text">The text to append packet data to.</param>
		/// <param name="pak">The paket.</param>
		/// <param name="stats">The current stats.</param>
		/// <param name="showPacketSequence">If set to <c>true</c> shows packet sequences.</param>
		/// <param name="baseTime">The base time.</param>
		/// <param name="timeDiff">If set to <c>true</c> shows packet time delta.</param>
		private void AppendPacketData(TextWriter text, Packet pak, ref LogDataStatistics stats, bool showPacketSequence, ref TimeSpan baseTime, bool timeDiff)
		{
			int pakIndex = 0;
			if (showPacketSequence)
			{
				if (pak.Protocol == ePacketProtocol.TCP)
				{
					if (pak.Direction == ePacketDirection.ClientToServer)
					{
						pakIndex = ++stats.PacketsCountOutTCP;
					}
					else
					{
						pakIndex = ++stats.PacketsCountInTCP;
					}
				}
				else if (pak.Protocol == ePacketProtocol.UDP)
				{
					if (pak.Direction == ePacketDirection.ClientToServer)
					{
						pakIndex = ++stats.PacketsCountOutUDP;
					}
					else
					{
						pakIndex = ++stats.PacketsCountInUDP;
					}
				}
				else
				{
					throw new ArgumentException("Unknown packet protocol: " + (int) pak.Protocol);
				}
			}

			++stats.PacketsCount;

			if (showPacketSequence)
			{
				text.Write("{0}:{1,-5} ", pak.Protocol, pakIndex);
			}

			// main description
			pak.ToHumanReadableString(text, baseTime, mnuPacketFlags.Checked);
			// if use WriteLine as \r\n then packets will have not correctly index in stream.
			// because after stream will be loaded in RichTextBox it will have lines delemiter as set in RichTextBox
			// Maybe need to set stream.NewLine
			text.WriteLine();

			if (timeDiff)
			{
				baseTime = pak.Time;
			}
		}

		private void logDataFindButton_Click(object sender, EventArgs e)
		{
			LogDataFindText();
		}

		private void LogDataFindText()
		{
			int start = logDataText.SelectionStart + 1;
			if (start >= logDataText.TextLength || start < 0)
				start = 0;
			logDataText.Find(logDataFindTextBox.Text, start, RichTextBoxFinds.None);
			logDataText.Focus();
		}

		private void logDataFindText_KeyPress(object sender, KeyPressEventArgs e)
		{
//			MessageBox.Show("key pressed: 0x"+((int)e.KeyChar).ToString("X4"));
			if (e.KeyChar == '\x000D')
				LogDataFindText();
		}

		private void logDataDisableUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (logDataDisableUpdatesCheckBox.Checked)
				logDataText.Clear();
			else
				UpdateLogDataTab();
		}

		private PacketLocation m_logDataClickPacketLocation;

		private void logDataText_MouseClickEvent(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					Point clickPoint = new Point(e.X, e.Y);
					int logDataClickIndex = logDataText.GetCharIndexFromPosition(clickPoint);

					// Find log and packet indices
					m_logDataClickPacketLocation = LogManager.FindPacketInfoByTextIndex(logDataClickIndex).PacketLocation;

					ContextMenu actionsMenu =
						CreateMenuActions(m_actionMenuItemsByPriority, m_actionByPriority, m_logDataClickPacketLocation);
					if (actionsMenu != null)
					{
						actionsMenu.Show(logDataText, clickPoint);
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error("Right click in data text", ex);
			}
		}

		private void LogActionClick_Event(object sender, EventArgs e)
		{
//			this.logDataText.SuspendLayout();
//			logDataText.Invalidate();
			if (LogManager == null)
				return;
			MenuItem menu = sender as MenuItem;
			if (menu == null) return;
			ILogAction action = (ILogAction) m_actionByMenuItem[menu];
			if (action == null) return;

			try
			{
				if (action.Activate(this, m_logDataClickPacketLocation))
					UpdateLogDataTab();
			}
			catch (Exception e1)
			{
				Log.Error("activating log action", e1);
			}
		}

		private void packetTimeDiffMenuItem_Click(object sender, System.EventArgs e)
		{
			packetTimeDiffMenuItem.Checked = !packetTimeDiffMenuItem.Checked;
			UpdateLogDataTab();
		}

		private void mnuPacketFlags_Click(object sender, System.EventArgs e)
		{
			mnuPacketFlags.Checked = !mnuPacketFlags.Checked;
			UpdateLogDataTab();
		}

		private void mnuPacketSequence_Click(object sender, System.EventArgs e)
		{
			mnuPacketSequence.Checked = !mnuPacketSequence.Checked;
			UpdateLogDataTab();
		}

		#region Save/Load view position

		private readonly PacketLocation[] m_selectedLogPositions = new PacketLocation[10];

		/// <summary>
		/// Clears the log positions.
		/// </summary>
		private void ClearLogPositions()
		{
			// Clear LocationPosition
			for (int i = 0; i < m_selectedLogPositions.Length; i++)
			{
				m_selectedLogPositions[i] = PacketLocation.UNKNOWN;
			}
		}

		/// <summary>
		/// Saves the log position.
		/// </summary>
		/// <param name="index">The index.</param>
		public void SaveLogPosition(int index)
		{
			m_selectedLogPositions[index] = PacketLocation.UNKNOWN;
			if (logDataText.TextLength > 0)
			{
				m_selectedLogPositions[index] = LogManager.FindPacketInfoByTextIndex(logDataText.SelectionStart).PacketLocation;
			}
		}

		public void RestoreLogPositionByPacket(Packet restorePacket)
		{
			if (restorePacket != null)
			{
				int restoreIndex = -1;
				{
					restoreIndex = LogManager.FindTextIndexByPacket(restorePacket);
				}

				if (restoreIndex >= 0)
				{
					logDataText.SelectionLength = 0;
					logDataText.SelectionStart = restoreIndex;
					logDataText.Focus();
				}
			}
		}

		/// <summary>
		/// Restores the position in log.
		/// </summary>
		/// <param name="index">The index.</param>
		public void RestoreLogPosition(int index)
		{
			PacketLocation savedLoc = Util.GetObjectByIndexSafe(m_selectedLogPositions, index, PacketLocation.UNKNOWN);

			// Check that packet location is stored
			if (savedLoc != PacketLocation.UNKNOWN)
			{
				// Get selected packet
				Packet restorePacket = LogManager.GetPacket(savedLoc);

				int restoreIndex = -1;
				if (restorePacket != null)
				{
					restoreIndex = LogManager.FindTextIndexByPacket(restorePacket);
				}

				if (restoreIndex >= 0)
				{
					logDataText.SelectionLength = 0;
					logDataText.SelectionStart = restoreIndex;
				}
			}
		}

		/// <summary>
		/// Handles the KeyDown event of the logDataText control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		private void logDataText_KeyDown(object sender, KeyEventArgs e)
		{
			int numberEntered = -1;

			if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
				numberEntered = e.KeyCode - Keys.D0;
			else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
				numberEntered = e.KeyCode - Keys.NumPad0;
			if (numberEntered < 0 || numberEntered > 9)
				return;
			if (e.Control && !e.Alt && !e.Shift)
			{
				e.Handled = true;
				RestoreLogPosition(numberEntered);
			}
			else if (!e.Control && e.Alt && !e.Shift)
			{
				e.Handled = true;
				SaveLogPosition(numberEntered);
			}
		}
		#endregion

		#endregion

		#region Log info tab

		private void UpdateLogInfoTab()
		{
			li_packetsCount.Text = LogManager.CountPackets().ToString("N0");
			li_unknownPacketsCount.Text = LogManager.CountUnknownPackets().ToString("N0");
			li_changesLabel.Text = string.Empty;

			// Read-only collections cannot be modified, even properties of contained objects
			IList<PacketLog> source = new List<PacketLog>(m_currentLogs.Logs);
			openLogsBindingSource.DataSource = source;
		}

		private void li_applyButton_Click(object sender, EventArgs e)
		{
			if (LogManager == null)
			{
				Log.Info("Nothing loaded.");
				return;
			}

			// Reinitialize in another thread
			m_progress.SetDescription("Reinitializing log and packets...");
			m_progress.Start(new WorkCallback(InitLog), null);
		}

		private void InitLog(ProgressCallback callback, object state)
		{
			LogManager.InitLogs(3, callback);

			// Update log info
			Invoke((MethodInvoker)delegate()
			       	{
			       		UpdateLogInfoTab();
			       		UpdateLogDataTab();
			       	});
		}

		private void li_changes_Event(object sender, EventArgs e)
		{
			li_changesLabel.Text = "(changes)";
		}

		#region HACK: Version is being updated - penetrate "ignore version changes" flag

		private bool oldLogIgnoreVersionFlag;

		/// <summary>
		/// Handles the CellValueChanged event of the openLogsDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
		private void openLogsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			SaveIgnoreVersionFlag(e.ColumnIndex, e.RowIndex, false);
			if (e.ColumnIndex != selectedLogDataGridViewCheckBoxColumn.Index)
				li_changes_Event(null, null);
		}

		/// <summary>
		/// Handles the CellBeginEdit event of the openLogsDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellCancelEventArgs"/> instance containing the event data.</param>
		private void openLogsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			SaveIgnoreVersionFlag(e.ColumnIndex, e.RowIndex, true);
		}

		/// <summary>
		/// Saves and restores "ignore version changes" flag.
		/// </summary>
		/// <param name="columnIndex">Index of the log column.</param>
		/// <param name="rowIndex">Index of the log row.</param>
		/// <param name="getFlag">If set to <c>true</c> gets the current flag, restores saved value otherwise.</param>
		private void SaveIgnoreVersionFlag(int columnIndex, int rowIndex, bool getFlag)
		{
			if (rowIndex >= 0)
			{
				DataGridViewCell cell = openLogsDataGridView[columnIndex, rowIndex];
				if (cell.ColumnIndex == versionDataGridViewTextBoxColumn.Index)
				{
					PacketLog updatedLog = (PacketLog)openLogsBindingSource.List[rowIndex];

					if (getFlag)
					{
						oldLogIgnoreVersionFlag = updatedLog.IgnoreVersionChanges;
						updatedLog.IgnoreVersionChanges = false;
					}
					else
					{
						updatedLog.IgnoreVersionChanges = oldLogIgnoreVersionFlag;
					}
				}
			}
		}

		#endregion

		#endregion

		#region Instant parse tab

		private void InstantParseUpdateEvent(object sender, EventArgs e)
		{
			UpdateInstantParseTab();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			instantParseInput.Clear();
		}

		private void UpdateInstantParseTab()
		{
			float ver;
			Util.ParseFloat(instantVersion.Text, out ver, -1);

			Packet pak = new Packet(0);
			int code;
			if (!Util.ParseInt(instantCode.Text, out code))
				code = 0;
			pak.Code = (byte)code;
			bool daocLoggerPacket = false;
			try
			{
				if (instantParseInput.Text[0] == '<')
				{
					try
					{
						string[] lines = instantParseInput.Lines;

						ePacketDirection dir;
						ePacketProtocol prot;
						TimeSpan time;
						int dataLen = DaocLoggerV3TextLogReader.ParseHeader(lines[0], out code, out dir, out prot, out time);
						pak.Code = (byte)code;
						pak.Direction = dir;
						pak.Protocol = prot;
						pak.Time = time;

						for (int i = 1; i < lines.Length; i++)
						{
							DaocLoggerV3TextLogReader.ParseDataLine(lines[i], pak);
						}
						daocLoggerPacket = true;

						if (pak.Direction == ePacketDirection.ClientToServer)
						{
							instantClientToServer.Checked = true;
						}
						else
						{
							instantServerToClient.Checked = true;
						}
					}
					catch(Exception) {}
				}
				// failed to read daoc logger format
				if (!daocLoggerPacket)
				{
					pak.Position = 0;
					foreach (string line in instantParseInput.Text.Split('\n'))
					{
						foreach (string str in line.Split(' '))
						{
							try
							{
								if (str.Trim().Length != 2) continue;
								byte b = byte.Parse(str.Trim(), NumberStyles.HexNumber);
								pak.WriteByte(b);
							}
							catch(Exception)
							{
							}
						}
					}
				}
			}
			catch(Exception)
			{
			}

			if (instantServerToClient.Checked)
				pak.Direction = ePacketDirection.ServerToClient;
			else
				pak.Direction = ePacketDirection.ClientToServer;

			pak = PacketManager.CreatePacket(ver, pak.Code,  pak.Direction).CopyFrom(pak);

			StringBuilder result = new StringBuilder();
			result.AppendFormat("ver:{0}  code:0x{1:X2} (old:0x{2:X2})  dir:{3}  len:{4} (0x{4:X})  logger packet:{5}", ver, pak.Code, pak.Code^168, pak.Direction, pak.Length, daocLoggerPacket);
			result.Append("\npacket class: ").Append(pak.GetType().Name).Append("\n");
			result.AppendFormat("desc: \"{0}\"\n\n", pak.Description);
			try
			{
				pak.InitException = null;
				pak.Initialized = false;
				pak.Position = 0;
				pak.Init();
				pak.PositionAfterInit = pak.Position;
				pak.Initialized = true;
				result.Append(pak.GetPacketDataString(true));
			}
			catch (OutOfMemoryException e)
			{
				pak.Initialized = false;
				pak.InitException = e;
				result.Append(e.ToString());
			}
			catch (Exception e)
			{
				pak.InitException = e;
				result.AppendFormat("{0}: {1}", e.GetType().ToString(), e.Message);
//				result.Append("\n\n").Append(e.ToString());
			}

			if (pak.PositionAfterInit > pak.Length)
			{
				result.AppendFormat("\n(pak.PositionAfterInit > pak.Length !)");
			}

//			string notInitialized = pak.GetNotInitializedData();
//			if (notInitialized.Length > 0)
//			{
//				result.AppendFormat("\n\nnot initialized:\n{0}", notInitialized);
//			}
			using (StringWriter sw = new StringWriter())
			{
				pak.AppendNotInitializedData(sw);
				if (sw.ToString().Length > 0)
					result.AppendFormat("\n\nnot initialized:\n{0}", sw.ToString());
			}

			result.Append('\n');

			instantParseOut.Text = result.ToString();

			if (daocLoggerPacket)
			{
				instantCode.Text = "0x"+pak.Code.ToString("X2");
				instantClientToServer.Checked = pak.Direction == ePacketDirection.ClientToServer;
			}
		}

		#endregion

		#region Filters

		private MenuItem m_filterMenuCombineFilters;
		private MenuItem m_filterMenuInvertCheck;
		private MenuItem m_filterMenuIgnoreFilters;
		private MenuItem m_filterMenuFiltersLoad;
		private MenuItem m_filterMenuFiltersSave;
		private int m_filterMenuStaticElementsCount;

		/// <summary>
		/// Handles the Event event of the Filter menu.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		private void FilterClick_Event(object sender, EventArgs e)
		{
			MenuItem menu = sender as MenuItem;
			if (menu == null) return;

			try
			{
				//
				// Static elements handlers
				//

				// "Combine" menu item
				if (menu == m_filterMenuCombineFilters)
				{
					FilterManager.CombineFilters = !FilterManager.CombineFilters;
					return;
				}

				// "Invert" menu item
				if (menu == m_filterMenuInvertCheck)
				{
					FilterManager.InvertCheck = !FilterManager.InvertCheck;
					return;
				}

				// "Ignore" menu item
				if (menu == m_filterMenuIgnoreFilters)
				{
					FilterManager.IgnoreFilters = !FilterManager.IgnoreFilters;
					return;
				}


				//
				// Dynamic elements handlers
				//

				int index = menu.Index - m_filterMenuStaticElementsCount;
				if (index >= m_logFilters.Count || index < 0)
					return;

				bool update = false;
				int oldFilters = FilterManager.FiltersCount;

				ILogFilter filter = (ILogFilter)m_logFilters[index];
				update |= filter.ActivateFilter(); // changes to the filter

				update |= oldFilters != FilterManager.FiltersCount;

				if (update && !FilterManager.IgnoreFilters)// try fix update filters while ignore filter is ON
				{
					UpdateLogDataTab();
				}
			}
			catch (Exception e1)
			{
				Log.Error("activating filter", e1);
			}
		}

		/// <summary>
		/// Called when filter is added to filter manager.
		/// </summary>
		/// <param name="filter">The filter.</param>
		private void OnFilterAdded(ILogFilter filter)
		{
			ChangeFilterMenuCheckedState(filter, true);
		}

		/// <summary>
		/// Called when filter is removed from filter manager.
		/// </summary>
		/// <param name="filter">The filter.</param>
		private void OnFilterRemoved(ILogFilter filter)
		{
			ChangeFilterMenuCheckedState(filter, false);
		}

		/// <summary>
		/// Changes the state of the filter menu checked.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="newState">if set to <c>true</c> menu item is checked.</param>
		private void ChangeFilterMenuCheckedState(ILogFilter filter, bool newState)
		{
			// Get index of filter
			int index = m_logFilters.IndexOf(filter);

			if (index >= m_logFilters.Count || index < 0)
				return;

			// Get menu item, make it checked
			MenuItem menu = (MenuItem) m_filterMenuItemsByPriority.GetByIndex(index);
			if (null != menu)
			{
				menu.Checked = newState;
			}
		}

		#endregion

		private void removeButton_Click(object sender, EventArgs e)
		{
			if (LogManager == null)
			{
				Log.Info("Nothing loaded.");
				return;
			}

			List<PacketLog> selectedLogs = new List<PacketLog>();
			int logIndex = 0;
			foreach (PacketLog log in LogManager.Logs)
			{
				if (log.LogSelected)
				{
					selectedLogs.Add(log);
					// Clear/Change stored positions
					for (int i = 0; i < m_selectedLogPositions.Length; i++)
					{
						PacketLocation savedLoc = Util.GetObjectByIndexSafe(m_selectedLogPositions, i, PacketLocation.UNKNOWN);
						// Check that packet location is stored
						if (savedLoc != PacketLocation.UNKNOWN)
						{
							if (savedLoc.LogIndex == logIndex)
							{
								savedLoc = PacketLocation.UNKNOWN;
							}
							else if (savedLoc.LogIndex > logIndex)
							{
								if (--savedLoc.LogIndex < 0)
									savedLoc = PacketLocation.UNKNOWN;
							}
							m_selectedLogPositions[i] = savedLoc;
						}
					}
				}
				logIndex++;
			}
			if (selectedLogs.Count > 0)
			{
				LogManager.ClearLogRange(selectedLogs);
				// Clear stored positions
//				ClearLogPositions();
			}
		}
	}
}
