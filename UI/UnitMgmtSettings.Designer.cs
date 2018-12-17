namespace GTI.Modules.SystemSettings.UI
{
	partial class UnitMgmtSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitMgmtSettings));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbPackInUseRip = new System.Windows.Forms.RadioButton();
            this.rbPackInUseNotify = new System.Windows.Forms.RadioButton();
            this.grpWiFiRange = new System.Windows.Forms.GroupBox();
            this.chkWiFiRange = new System.Windows.Forms.CheckBox();
            this.grpUnitAssignment = new System.Windows.Forms.GroupBox();
            this.numMaxUnits = new System.Windows.Forms.NumericUpDown();
            this.lblMaxUnits = new System.Windows.Forms.Label();
            this.chkConfirmUnitAssignment = new System.Windows.Forms.CheckBox();
            this.chkEnableUnitAssignment = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkAllowCrossTransfers = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_tbCrateServerPortNumber = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IP_addressLabel = new System.Windows.Forms.Label();
            this.txtCrateServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkForceUnitSelectionWhenNoFees = new System.Windows.Forms.CheckBox();
            this.gridDeviceFees = new System.Windows.Forms.DataGridView();
            this.deviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSDefaultDevice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpDeviceRanges = new System.Windows.Forms.GroupBox();
            this.gridDeviceRanges = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new GTI.Controls.ImageButton();
            this.chkDeviceFeesQualifyForPoints = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.grpWiFiRange.SuspendLayout();
            this.grpUnitAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUnits)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceFees)).BeginInit();
            this.grpDeviceRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceRanges)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbPackInUseRip);
            this.groupBox3.Controls.Add(this.rbPackInUseNotify);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rbPackInUseRip
            // 
            resources.ApplyResources(this.rbPackInUseRip, "rbPackInUseRip");
            this.rbPackInUseRip.Name = "rbPackInUseRip";
            this.rbPackInUseRip.TabStop = true;
            this.rbPackInUseRip.UseVisualStyleBackColor = true;
            this.rbPackInUseRip.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // rbPackInUseNotify
            // 
            resources.ApplyResources(this.rbPackInUseNotify, "rbPackInUseNotify");
            this.rbPackInUseNotify.Name = "rbPackInUseNotify";
            this.rbPackInUseNotify.TabStop = true;
            this.rbPackInUseNotify.UseVisualStyleBackColor = true;
            this.rbPackInUseNotify.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // grpWiFiRange
            // 
            this.grpWiFiRange.BackColor = System.Drawing.Color.Transparent;
            this.grpWiFiRange.Controls.Add(this.chkWiFiRange);
            resources.ApplyResources(this.grpWiFiRange, "grpWiFiRange");
            this.grpWiFiRange.Name = "grpWiFiRange";
            this.grpWiFiRange.TabStop = false;
            // 
            // chkWiFiRange
            // 
            resources.ApplyResources(this.chkWiFiRange, "chkWiFiRange");
            this.chkWiFiRange.Name = "chkWiFiRange";
            this.chkWiFiRange.UseVisualStyleBackColor = true;
            this.chkWiFiRange.Click += new System.EventHandler(this.OnModified);
            // 
            // grpUnitAssignment
            // 
            this.grpUnitAssignment.Controls.Add(this.numMaxUnits);
            this.grpUnitAssignment.Controls.Add(this.lblMaxUnits);
            this.grpUnitAssignment.Controls.Add(this.chkConfirmUnitAssignment);
            this.grpUnitAssignment.Controls.Add(this.chkEnableUnitAssignment);
            resources.ApplyResources(this.grpUnitAssignment, "grpUnitAssignment");
            this.grpUnitAssignment.Name = "grpUnitAssignment";
            this.grpUnitAssignment.TabStop = false;
            // 
            // numMaxUnits
            // 
            resources.ApplyResources(this.numMaxUnits, "numMaxUnits");
            this.numMaxUnits.Name = "numMaxUnits";
            this.numMaxUnits.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblMaxUnits
            // 
            resources.ApplyResources(this.lblMaxUnits, "lblMaxUnits");
            this.lblMaxUnits.Name = "lblMaxUnits";
            // 
            // chkConfirmUnitAssignment
            // 
            resources.ApplyResources(this.chkConfirmUnitAssignment, "chkConfirmUnitAssignment");
            this.chkConfirmUnitAssignment.Name = "chkConfirmUnitAssignment";
            this.chkConfirmUnitAssignment.UseVisualStyleBackColor = true;
            this.chkConfirmUnitAssignment.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableUnitAssignment
            // 
            resources.ApplyResources(this.chkEnableUnitAssignment, "chkEnableUnitAssignment");
            this.chkEnableUnitAssignment.Name = "chkEnableUnitAssignment";
            this.chkEnableUnitAssignment.UseVisualStyleBackColor = true;
            this.chkEnableUnitAssignment.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
            this.btnReset.Name = "btnReset";
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.chkAllowCrossTransfers);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // chkAllowCrossTransfers
            // 
            resources.ApplyResources(this.chkAllowCrossTransfers, "chkAllowCrossTransfers");
            this.chkAllowCrossTransfers.Name = "chkAllowCrossTransfers";
            this.chkAllowCrossTransfers.UseVisualStyleBackColor = true;
            this.chkAllowCrossTransfers.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.m_tbCrateServerPortNumber);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.IP_addressLabel);
            this.groupBox2.Controls.Add(this.txtCrateServer);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_tbCrateServerPortNumber
            // 
            resources.ApplyResources(this.m_tbCrateServerPortNumber, "m_tbCrateServerPortNumber");
            this.m_tbCrateServerPortNumber.Name = "m_tbCrateServerPortNumber";
            this.m_tbCrateServerPortNumber.ValidatingType = typeof(int);
            this.m_tbCrateServerPortNumber.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // IP_addressLabel
            // 
            resources.ApplyResources(this.IP_addressLabel, "IP_addressLabel");
            this.IP_addressLabel.Name = "IP_addressLabel";
            // 
            // txtCrateServer
            // 
            resources.ApplyResources(this.txtCrateServer, "txtCrateServer");
            this.txtCrateServer.Name = "txtCrateServer";
            this.txtCrateServer.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkDeviceFeesQualifyForPoints);
            this.groupBox1.Controls.Add(this.chkForceUnitSelectionWhenNoFees);
            this.groupBox1.Controls.Add(this.gridDeviceFees);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkForceUnitSelectionWhenNoFees
            // 
            resources.ApplyResources(this.chkForceUnitSelectionWhenNoFees, "chkForceUnitSelectionWhenNoFees");
            this.chkForceUnitSelectionWhenNoFees.Name = "chkForceUnitSelectionWhenNoFees";
            this.chkForceUnitSelectionWhenNoFees.UseVisualStyleBackColor = true;
            this.chkForceUnitSelectionWhenNoFees.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // gridDeviceFees
            // 
            this.gridDeviceFees.AllowUserToAddRows = false;
            this.gridDeviceFees.AllowUserToDeleteRows = false;
            this.gridDeviceFees.AllowUserToResizeColumns = false;
            this.gridDeviceFees.AllowUserToResizeRows = false;
            this.gridDeviceFees.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridDeviceFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDeviceFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceType,
            this.DeviceFee,
            this.POSDefaultDevice});
            resources.ApplyResources(this.gridDeviceFees, "gridDeviceFees");
            this.gridDeviceFees.MultiSelect = false;
            this.gridDeviceFees.Name = "gridDeviceFees";
            this.gridDeviceFees.RowHeadersVisible = false;
            this.gridDeviceFees.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDeviceFees_CellMouseUp);
            this.gridDeviceFees.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnModified);
            // 
            // deviceType
            // 
            this.deviceType.FillWeight = 300F;
            resources.ApplyResources(this.deviceType, "deviceType");
            this.deviceType.Name = "deviceType";
            this.deviceType.ReadOnly = true;
            // 
            // DeviceFee
            // 
            this.DeviceFee.FillWeight = 200F;
            resources.ApplyResources(this.DeviceFee, "DeviceFee");
            this.DeviceFee.MaxInputLength = 8;
            this.DeviceFee.Name = "DeviceFee";
            // 
            // POSDefaultDevice
            // 
            this.POSDefaultDevice.FalseValue = "0";
            resources.ApplyResources(this.POSDefaultDevice, "POSDefaultDevice");
            this.POSDefaultDevice.Name = "POSDefaultDevice";
            this.POSDefaultDevice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.POSDefaultDevice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.POSDefaultDevice.TrueValue = "1";
            // 
            // grpDeviceRanges
            // 
            this.grpDeviceRanges.BackColor = System.Drawing.Color.Transparent;
            this.grpDeviceRanges.Controls.Add(this.gridDeviceRanges);
            resources.ApplyResources(this.grpDeviceRanges, "grpDeviceRanges");
            this.grpDeviceRanges.Name = "grpDeviceRanges";
            this.grpDeviceRanges.TabStop = false;
            // 
            // gridDeviceRanges
            // 
            this.gridDeviceRanges.AllowUserToAddRows = false;
            this.gridDeviceRanges.AllowUserToDeleteRows = false;
            this.gridDeviceRanges.AllowUserToResizeColumns = false;
            this.gridDeviceRanges.AllowUserToResizeRows = false;
            this.gridDeviceRanges.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridDeviceRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDeviceRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1});
            resources.ApplyResources(this.gridDeviceRanges, "gridDeviceRanges");
            this.gridDeviceRanges.Name = "gridDeviceRanges";
            this.gridDeviceRanges.RowHeadersVisible = false;
            this.gridDeviceRanges.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnModified);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 300F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.MaxInputLength = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkcxDeviceFeesQualifyForPoints
            // 
            resources.ApplyResources(this.chkDeviceFeesQualifyForPoints, "chkcxDeviceFeesQualifyForPoints");
            this.chkDeviceFeesQualifyForPoints.Name = "chkcxDeviceFeesQualifyForPoints";
            this.chkDeviceFeesQualifyForPoints.UseVisualStyleBackColor = true;
            this.chkDeviceFeesQualifyForPoints.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // UnitMgmtSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpWiFiRange);
            this.Controls.Add(this.grpUnitAssignment);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpDeviceRanges);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "UnitMgmtSettings";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpWiFiRange.ResumeLayout(false);
            this.grpWiFiRange.PerformLayout();
            this.grpUnitAssignment.ResumeLayout(false);
            this.grpUnitAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxUnits)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceFees)).EndInit();
            this.grpDeviceRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceRanges)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox chkAllowCrossTransfers;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCrateServer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView gridDeviceFees;
		private System.Windows.Forms.GroupBox grpDeviceRanges;
		private System.Windows.Forms.DataGridView gridDeviceRanges;
		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox grpUnitAssignment;
		private System.Windows.Forms.CheckBox chkEnableUnitAssignment;
		private System.Windows.Forms.CheckBox chkConfirmUnitAssignment;
		private System.Windows.Forms.NumericUpDown numMaxUnits;
        private System.Windows.Forms.Label lblMaxUnits;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox grpWiFiRange;
        private System.Windows.Forms.CheckBox chkWiFiRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IP_addressLabel;
        private System.Windows.Forms.MaskedTextBox m_tbCrateServerPortNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbPackInUseRip;
        private System.Windows.Forms.RadioButton rbPackInUseNotify;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceFee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn POSDefaultDevice;
        private System.Windows.Forms.CheckBox chkForceUnitSelectionWhenNoFees;
        private System.Windows.Forms.CheckBox chkDeviceFeesQualifyForPoints;
	}
}
