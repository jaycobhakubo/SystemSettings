namespace GTI.Modules.SystemSettings.UI
{
	partial class MagCardSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagCardSettings));
            this.contextMenuStripForText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator = new System.Windows.Forms.ToolStripSeparator();
            this.Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripForReadOnlyText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.magneticCardGroupBox = new System.Windows.Forms.GroupBox();
            this.gbSources = new System.Windows.Forms.GroupBox();
            this.groupBoxTCPInput = new System.Windows.Forms.GroupBox();
            this.lblReaderAddress = new System.Windows.Forms.Label();
            this.txtReaderTrack = new System.Windows.Forms.TextBox();
            this.txtReaderIPAddress = new System.Windows.Forms.TextBox();
            this.lblCardTrack = new System.Windows.Forms.Label();
            this.lblReaderPort = new System.Windows.Forms.Label();
            this.txtReaderPort = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbStartCard = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEndCard = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMagCardReaderMode = new System.Windows.Forms.ComboBox();
            this.gbCardLab = new System.Windows.Forms.GroupBox();
            this.lblFilterResultInfo = new System.Windows.Forms.Label();
            this.btnAnalyze = new GTI.Controls.ImageButton();
            this.lblISOTracksFound = new System.Windows.Forms.Label();
            this.btnApplyFilter = new GTI.Controls.ImageButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new GTI.Controls.ImageButton();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSwipeCard = new GTI.Controls.ImageButton();
            this.txtCardDigits = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnCopyFilterToLab = new GTI.Controls.ImageButton();
            this.btnShiftFilterDown = new GTI.Controls.ImageButton();
            this.btnShiftFilterUp = new GTI.Controls.ImageButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lstFilters = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTest = new GTI.Controls.ImageButton();
            this.btnDelete = new GTI.Controls.ImageButton();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.contextMenuStripForText.SuspendLayout();
            this.contextMenuStripForReadOnlyText.SuspendLayout();
            this.magneticCardGroupBox.SuspendLayout();
            this.gbSources.SuspendLayout();
            this.groupBoxTCPInput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbCardLab.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripForText
            // 
            this.contextMenuStripForText.AllowMerge = false;
            resources.ApplyResources(this.contextMenuStripForText, "contextMenuStripForText");
            this.contextMenuStripForText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Undo,
            this.Separator,
            this.Cut,
            this.Copy,
            this.Paste,
            this.Delete});
            this.contextMenuStripForText.Name = "contextMenuStripForTextbox";
            this.contextMenuStripForText.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripForTextbox_Opening);
            this.contextMenuStripForText.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripForTextbox_ItemClicked);
            // 
            // Undo
            // 
            this.Undo.Name = "Undo";
            resources.ApplyResources(this.Undo, "Undo");
            // 
            // Separator
            // 
            this.Separator.Name = "Separator";
            resources.ApplyResources(this.Separator, "Separator");
            // 
            // Cut
            // 
            this.Cut.Name = "Cut";
            resources.ApplyResources(this.Cut, "Cut");
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            resources.ApplyResources(this.Copy, "Copy");
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            resources.ApplyResources(this.Paste, "Paste");
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            resources.ApplyResources(this.Delete, "Delete");
            // 
            // contextMenuStripForReadOnlyText
            // 
            this.contextMenuStripForReadOnlyText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuClear});
            this.contextMenuStripForReadOnlyText.Name = "contextMenuStripFilterResults";
            resources.ApplyResources(this.contextMenuStripForReadOnlyText, "contextMenuStripForReadOnlyText");
            this.contextMenuStripForReadOnlyText.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuClear
            // 
            this.toolStripMenuClear.Name = "toolStripMenuClear";
            resources.ApplyResources(this.toolStripMenuClear, "toolStripMenuClear");
            // 
            // magneticCardGroupBox
            // 
            this.magneticCardGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.magneticCardGroupBox.Controls.Add(this.gbSources);
            this.magneticCardGroupBox.Controls.Add(this.gbCardLab);
            this.magneticCardGroupBox.Controls.Add(this.gbFilters);
            resources.ApplyResources(this.magneticCardGroupBox, "magneticCardGroupBox");
            this.magneticCardGroupBox.Name = "magneticCardGroupBox";
            this.magneticCardGroupBox.TabStop = false;
            // 
            // gbSources
            // 
            this.gbSources.Controls.Add(this.groupBoxTCPInput);
            this.gbSources.Controls.Add(this.groupBox4);
            this.gbSources.Controls.Add(this.cboMagCardReaderMode);
            resources.ApplyResources(this.gbSources, "gbSources");
            this.gbSources.Name = "gbSources";
            this.gbSources.TabStop = false;
            // 
            // groupBoxTCPInput
            // 
            this.groupBoxTCPInput.Controls.Add(this.lblReaderAddress);
            this.groupBoxTCPInput.Controls.Add(this.txtReaderTrack);
            this.groupBoxTCPInput.Controls.Add(this.txtReaderIPAddress);
            this.groupBoxTCPInput.Controls.Add(this.lblCardTrack);
            this.groupBoxTCPInput.Controls.Add(this.lblReaderPort);
            this.groupBoxTCPInput.Controls.Add(this.txtReaderPort);
            resources.ApplyResources(this.groupBoxTCPInput, "groupBoxTCPInput");
            this.groupBoxTCPInput.Name = "groupBoxTCPInput";
            this.groupBoxTCPInput.TabStop = false;
            // 
            // lblReaderAddress
            // 
            resources.ApplyResources(this.lblReaderAddress, "lblReaderAddress");
            this.lblReaderAddress.Name = "lblReaderAddress";
            // 
            // txtReaderTrack
            // 
            this.txtReaderTrack.ContextMenuStrip = this.contextMenuStripForText;
            resources.ApplyResources(this.txtReaderTrack, "txtReaderTrack");
            this.txtReaderTrack.Name = "txtReaderTrack";
            this.txtReaderTrack.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtReaderIPAddress
            // 
            this.txtReaderIPAddress.ContextMenuStrip = this.contextMenuStripForText;
            resources.ApplyResources(this.txtReaderIPAddress, "txtReaderIPAddress");
            this.txtReaderIPAddress.HideSelection = false;
            this.txtReaderIPAddress.Name = "txtReaderIPAddress";
            this.txtReaderIPAddress.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // lblCardTrack
            // 
            resources.ApplyResources(this.lblCardTrack, "lblCardTrack");
            this.lblCardTrack.Name = "lblCardTrack";
            // 
            // lblReaderPort
            // 
            resources.ApplyResources(this.lblReaderPort, "lblReaderPort");
            this.lblReaderPort.Name = "lblReaderPort";
            // 
            // txtReaderPort
            // 
            this.txtReaderPort.ContextMenuStrip = this.contextMenuStripForText;
            resources.ApplyResources(this.txtReaderPort, "txtReaderPort");
            this.txtReaderPort.Name = "txtReaderPort";
            this.txtReaderPort.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.cbStartCard);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbEndCard);
            this.groupBox4.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cbStartCard
            // 
            this.cbStartCard.ContextMenuStrip = this.contextMenuStripForText;
            resources.ApplyResources(this.cbStartCard, "cbStartCard");
            this.cbStartCard.FormattingEnabled = true;
            this.cbStartCard.Items.AddRange(new object[] {
            resources.GetString("cbStartCard.Items")});
            this.cbStartCard.Name = "cbStartCard";
            this.cbStartCard.SelectedIndexChanged += new System.EventHandler(this.cbStartCard_SelectedIndexChanged);
            this.cbStartCard.TextChanged += new System.EventHandler(this.Validate);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbEndCard
            // 
            this.cbEndCard.ContextMenuStrip = this.contextMenuStripForText;
            resources.ApplyResources(this.cbEndCard, "cbEndCard");
            this.cbEndCard.FormattingEnabled = true;
            this.cbEndCard.Items.AddRange(new object[] {
            resources.GetString("cbEndCard.Items")});
            this.cbEndCard.Name = "cbEndCard";
            this.cbEndCard.SelectedIndexChanged += new System.EventHandler(this.cbEndCard_SelectedIndexChanged);
            this.cbEndCard.TextChanged += new System.EventHandler(this.Validate);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cboMagCardReaderMode
            // 
            this.cboMagCardReaderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboMagCardReaderMode, "cboMagCardReaderMode");
            this.cboMagCardReaderMode.FormattingEnabled = true;
            this.cboMagCardReaderMode.Name = "cboMagCardReaderMode";
            this.cboMagCardReaderMode.SelectedIndexChanged += new System.EventHandler(this.cboMagCardReaderMode_SelectedIndexChanged);
            // 
            // gbCardLab
            // 
            this.gbCardLab.Controls.Add(this.lblFilterResultInfo);
            this.gbCardLab.Controls.Add(this.btnAnalyze);
            this.gbCardLab.Controls.Add(this.lblISOTracksFound);
            this.gbCardLab.Controls.Add(this.btnApplyFilter);
            this.gbCardLab.Controls.Add(this.label9);
            this.gbCardLab.Controls.Add(this.label3);
            this.gbCardLab.Controls.Add(this.txtFilterResult);
            this.gbCardLab.Controls.Add(this.label1);
            this.gbCardLab.Controls.Add(this.btnAccept);
            this.gbCardLab.Controls.Add(this.cbFilter);
            this.gbCardLab.Controls.Add(this.label2);
            this.gbCardLab.Controls.Add(this.btnSwipeCard);
            this.gbCardLab.Controls.Add(this.txtCardDigits);
            this.gbCardLab.Controls.Add(this.label6);
            resources.ApplyResources(this.gbCardLab, "gbCardLab");
            this.gbCardLab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbCardLab.Name = "gbCardLab";
            this.gbCardLab.TabStop = false;
            // 
            // lblFilterResultInfo
            // 
            resources.ApplyResources(this.lblFilterResultInfo, "lblFilterResultInfo");
            this.lblFilterResultInfo.Name = "lblFilterResultInfo";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnAnalyze, "btnAnalyze");
            this.btnAnalyze.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnAnalyze.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.RepeatRate = 150;
            this.btnAnalyze.RepeatWhenHeldFor = 750;
            this.btnAnalyze.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblISOTracksFound
            // 
            resources.ApplyResources(this.lblISOTracksFound, "lblISOTracksFound");
            this.lblISOTracksFound.Name = "lblISOTracksFound";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnApplyFilter, "btnApplyFilter");
            this.btnApplyFilter.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnApplyFilter.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.RepeatRate = 150;
            this.btnApplyFilter.RepeatWhenHeldFor = 750;
            this.btnApplyFilter.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtFilterResult
            // 
            this.txtFilterResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFilterResult.ContextMenuStrip = this.contextMenuStripForReadOnlyText;
            resources.ApplyResources(this.txtFilterResult, "txtFilterResult");
            this.txtFilterResult.Name = "txtFilterResult";
            this.txtFilterResult.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.FocusColor = System.Drawing.Color.Black;
            this.btnAccept.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnAccept.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.RepeatRate = 150;
            this.btnAccept.RepeatWhenHeldFor = 750;
            this.btnAccept.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.ContextMenuStrip = this.contextMenuStripForText;
            this.cbFilter.DropDownWidth = 500;
            resources.ApplyResources(this.cbFilter, "cbFilter");
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            resources.GetString("cbFilter.Items"),
            resources.GetString("cbFilter.Items1"),
            resources.GetString("cbFilter.Items2"),
            resources.GetString("cbFilter.Items3"),
            resources.GetString("cbFilter.Items4"),
            resources.GetString("cbFilter.Items5"),
            resources.GetString("cbFilter.Items6"),
            resources.GetString("cbFilter.Items7"),
            resources.GetString("cbFilter.Items8"),
            resources.GetString("cbFilter.Items9")});
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbFilter.TextUpdate += new System.EventHandler(this.cbFilter_TextUpdate);
            this.cbFilter.TextChanged += new System.EventHandler(this.cbFilter_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnSwipeCard
            // 
            this.btnSwipeCard.BackColor = System.Drawing.Color.Transparent;
            this.btnSwipeCard.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSwipeCard, "btnSwipeCard");
            this.btnSwipeCard.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSwipeCard.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSwipeCard.Name = "btnSwipeCard";
            this.btnSwipeCard.RepeatRate = 150;
            this.btnSwipeCard.RepeatWhenHeldFor = 750;
            this.btnSwipeCard.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSwipeCard.UseVisualStyleBackColor = false;
            this.btnSwipeCard.Click += new System.EventHandler(this.btnSwipeCard_Click);
            // 
            // txtCardDigits
            // 
            this.txtCardDigits.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCardDigits.ContextMenuStrip = this.contextMenuStripForReadOnlyText;
            resources.ApplyResources(this.txtCardDigits, "txtCardDigits");
            this.txtCardDigits.Name = "txtCardDigits";
            this.txtCardDigits.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnCopyFilterToLab);
            this.gbFilters.Controls.Add(this.btnShiftFilterDown);
            this.gbFilters.Controls.Add(this.btnShiftFilterUp);
            this.gbFilters.Controls.Add(this.label8);
            this.gbFilters.Controls.Add(this.lstFilters);
            this.gbFilters.Controls.Add(this.btnTest);
            this.gbFilters.Controls.Add(this.btnDelete);
            resources.ApplyResources(this.gbFilters, "gbFilters");
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.TabStop = false;
            // 
            // btnCopyFilterToLab
            // 
            resources.ApplyResources(this.btnCopyFilterToLab, "btnCopyFilterToLab");
            this.btnCopyFilterToLab.FocusColor = System.Drawing.Color.Black;
            this.btnCopyFilterToLab.ForeColor = System.Drawing.Color.Black;
            this.btnCopyFilterToLab.ImageIcon = global::GTI.Modules.SystemSettings.Properties.Resources.ArrowRight;
            this.btnCopyFilterToLab.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnCopyFilterToLab.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnCopyFilterToLab.LineAlignment = System.Drawing.StringAlignment.Near;
            this.btnCopyFilterToLab.Name = "btnCopyFilterToLab";
            this.btnCopyFilterToLab.RepeatRate = 150;
            this.btnCopyFilterToLab.RepeatWhenHeldFor = 750;
            this.btnCopyFilterToLab.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnCopyFilterToLab.UseVisualStyleBackColor = false;
            this.btnCopyFilterToLab.Click += new System.EventHandler(this.btnCopyFilterToLab_Click);
            // 
            // btnShiftFilterDown
            // 
            resources.ApplyResources(this.btnShiftFilterDown, "btnShiftFilterDown");
            this.btnShiftFilterDown.FocusColor = System.Drawing.Color.Black;
            this.btnShiftFilterDown.ImageIcon = global::GTI.Modules.SystemSettings.Properties.Resources.ArrowDown;
            this.btnShiftFilterDown.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnShiftFilterDown.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnShiftFilterDown.Name = "btnShiftFilterDown";
            this.btnShiftFilterDown.RepeatRate = 150;
            this.btnShiftFilterDown.RepeatWhenHeldFor = 750;
            this.btnShiftFilterDown.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnShiftFilterDown.Click += new System.EventHandler(this.btnShiftFilterDown_Click);
            // 
            // btnShiftFilterUp
            // 
            resources.ApplyResources(this.btnShiftFilterUp, "btnShiftFilterUp");
            this.btnShiftFilterUp.FocusColor = System.Drawing.Color.Black;
            this.btnShiftFilterUp.ImageIcon = global::GTI.Modules.SystemSettings.Properties.Resources.ArrowUp;
            this.btnShiftFilterUp.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnShiftFilterUp.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnShiftFilterUp.Name = "btnShiftFilterUp";
            this.btnShiftFilterUp.RepeatRate = 150;
            this.btnShiftFilterUp.RepeatWhenHeldFor = 750;
            this.btnShiftFilterUp.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnShiftFilterUp.Click += new System.EventHandler(this.btnShiftFilterUp_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lstFilters
            // 
            this.lstFilters.AutoArrange = false;
            this.lstFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            resources.ApplyResources(this.lstFilters, "lstFilters");
            this.lstFilters.FullRowSelect = true;
            this.lstFilters.GridLines = true;
            this.lstFilters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFilters.HideSelection = false;
            this.lstFilters.MultiSelect = false;
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.ShowGroups = false;
            this.lstFilters.UseCompatibleStateImageBehavior = false;
            this.lstFilters.View = System.Windows.Forms.View.Details;
            this.lstFilters.SelectedIndexChanged += new System.EventHandler(this.lstFilters_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.FocusColor = System.Drawing.Color.Black;
            this.btnTest.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnTest.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnTest.Name = "btnTest";
            this.btnTest.RepeatRate = 150;
            this.btnTest.RepeatWhenHeldFor = 750;
            this.btnTest.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.FocusColor = System.Drawing.Color.Black;
            this.btnDelete.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnDelete.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RepeatRate = 150;
            this.btnDelete.RepeatWhenHeldFor = 750;
            this.btnDelete.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.Name = "btnReset";
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MagCardSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.magneticCardGroupBox);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "MagCardSettings";
            this.contextMenuStripForText.ResumeLayout(false);
            this.contextMenuStripForReadOnlyText.ResumeLayout(false);
            this.magneticCardGroupBox.ResumeLayout(false);
            this.gbSources.ResumeLayout(false);
            this.groupBoxTCPInput.ResumeLayout(false);
            this.groupBoxTCPInput.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbCardLab.ResumeLayout(false);
            this.gbCardLab.PerformLayout();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox magneticCardGroupBox;
        private System.Windows.Forms.GroupBox gbCardLab;
        private System.Windows.Forms.TextBox txtCardDigits;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.ListView lstFilters;
		private GTI.Controls.ImageButton btnDelete;
		private GTI.Controls.ImageButton btnTest;
		private GTI.Controls.ImageButton btnAccept;
		private GTI.Controls.ImageButton btnSwipeCard;
        private System.Windows.Forms.GroupBox gbSources;
        private System.Windows.Forms.ComboBox cboMagCardReaderMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private Controls.ImageButton btnCopyFilterToLab;
        private Controls.ImageButton btnShiftFilterDown;
        private Controls.ImageButton btnShiftFilterUp;
        private System.Windows.Forms.Label label8;
        private Controls.ImageButton btnApplyFilter;
        private System.Windows.Forms.GroupBox groupBoxTCPInput;
        private System.Windows.Forms.Label lblReaderAddress;
        private System.Windows.Forms.TextBox txtReaderTrack;
        private System.Windows.Forms.TextBox txtReaderIPAddress;
        private System.Windows.Forms.Label lblCardTrack;
        private System.Windows.Forms.Label lblReaderPort;
        private System.Windows.Forms.TextBox txtReaderPort;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbStartCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEndCard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForReadOnlyText;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuClear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForText;
        private System.Windows.Forms.ToolStripMenuItem Undo;
        private System.Windows.Forms.ToolStripSeparator Separator;
        private System.Windows.Forms.ToolStripMenuItem Cut;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.Label lblISOTracksFound;
        private Controls.ImageButton btnAnalyze;
        private System.Windows.Forms.Label lblFilterResultInfo;
	}
}
