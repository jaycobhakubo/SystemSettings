namespace GTI.Modules.SystemSettings.UI
{
	partial class GlobalSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalSettings));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkShowCursor = new System.Windows.Forms.CheckBox();
            this.chkForceEnglish = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExpireDayOrDays = new System.Windows.Forms.Label();
            this.nudExpireDays = new System.Windows.Forms.NumericUpDown();
            this.chkExpire = new System.Windows.Forms.CheckBox();
            this.chkCouponsTaxable = new System.Windows.Forms.CheckBox();
            this.chkEnableCouponManagement = new System.Windows.Forms.CheckBox();
            this.chkShareCreditSetting = new System.Windows.Forms.CheckBox();
            this.chkSharePointsSetting = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkEnableLogging = new System.Windows.Forms.CheckBox();
            this.cboLogLevel = new System.Windows.Forms.ComboBox();
            this.numLogRecycleDays = new System.Windows.Forms.NumericUpDown();
            this.lblLogRecycleDays = new System.Windows.Forms.Label();
            this.numDownloadRecycleDays = new System.Windows.Forms.NumericUpDown();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientRoot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClientInstallDrive = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpireDays)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogRecycleDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownloadRecycleDays)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.chkShowCursor);
            this.groupBox3.Controls.Add(this.chkForceEnglish);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkShowCursor
            // 
            resources.ApplyResources(this.chkShowCursor, "chkShowCursor");
            this.chkShowCursor.Name = "chkShowCursor";
            this.chkShowCursor.UseVisualStyleBackColor = true;
            this.chkShowCursor.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkForceEnglish
            // 
            resources.ApplyResources(this.chkForceEnglish, "chkForceEnglish");
            this.chkForceEnglish.Name = "chkForceEnglish";
            this.chkForceEnglish.UseVisualStyleBackColor = true;
            this.chkForceEnglish.CheckedChanged += new System.EventHandler(this.OnModified);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblExpireDayOrDays);
            this.groupBox1.Controls.Add(this.nudExpireDays);
            this.groupBox1.Controls.Add(this.chkExpire);
            this.groupBox1.Controls.Add(this.chkCouponsTaxable);
            this.groupBox1.Controls.Add(this.chkEnableCouponManagement);
            this.groupBox1.Controls.Add(this.chkShareCreditSetting);
            this.groupBox1.Controls.Add(this.chkSharePointsSetting);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.txtClientRoot);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtClientInstallDrive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblExpireDayOrDays
            // 
            resources.ApplyResources(this.lblExpireDayOrDays, "lblExpireDayOrDays");
            this.lblExpireDayOrDays.Name = "lblExpireDayOrDays";
            // 
            // nudExpireDays
            // 
            resources.ApplyResources(this.nudExpireDays, "nudExpireDays");
            this.nudExpireDays.Maximum = new decimal(new int[] {
            36500,
            0,
            0,
            0});
            this.nudExpireDays.Name = "nudExpireDays";
            this.nudExpireDays.Value = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudExpireDays.ValueChanged += new System.EventHandler(this.nudExpireDays_ValueChanged);
            this.nudExpireDays.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudExpireDays_KeyUp);
            this.nudExpireDays.Validating += new System.ComponentModel.CancelEventHandler(this.nudExpireDays_Validating);
            // 
            // chkExpire
            // 
            resources.ApplyResources(this.chkExpire, "chkExpire");
            this.chkExpire.Name = "chkExpire";
            this.chkExpire.UseVisualStyleBackColor = true;
            this.chkExpire.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkCouponsTaxable
            // 
            resources.ApplyResources(this.chkCouponsTaxable, "chkCouponsTaxable");
            this.chkCouponsTaxable.BackColor = System.Drawing.Color.Transparent;
            this.chkCouponsTaxable.Name = "chkCouponsTaxable";
            this.chkCouponsTaxable.UseVisualStyleBackColor = false;
            this.chkCouponsTaxable.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableCouponManagement
            // 
            resources.ApplyResources(this.chkEnableCouponManagement, "chkEnableCouponManagement");
            this.chkEnableCouponManagement.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableCouponManagement.Name = "chkEnableCouponManagement";
            this.chkEnableCouponManagement.UseVisualStyleBackColor = false;
            this.chkEnableCouponManagement.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShareCreditSetting
            // 
            resources.ApplyResources(this.chkShareCreditSetting, "chkShareCreditSetting");
            this.chkShareCreditSetting.BackColor = System.Drawing.Color.Transparent;
            this.chkShareCreditSetting.Name = "chkShareCreditSetting";
            this.chkShareCreditSetting.UseVisualStyleBackColor = false;
            this.chkShareCreditSetting.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkSharePointsSetting
            // 
            resources.ApplyResources(this.chkSharePointsSetting, "chkSharePointsSetting");
            this.chkSharePointsSetting.BackColor = System.Drawing.Color.Transparent;
            this.chkSharePointsSetting.Name = "chkSharePointsSetting";
            this.chkSharePointsSetting.UseVisualStyleBackColor = false;
            this.chkSharePointsSetting.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.chkEnableLogging);
            this.groupBox6.Controls.Add(this.cboLogLevel);
            this.groupBox6.Controls.Add(this.numLogRecycleDays);
            this.groupBox6.Controls.Add(this.lblLogRecycleDays);
            this.groupBox6.Controls.Add(this.numDownloadRecycleDays);
            this.groupBox6.Controls.Add(this.lblLogLevel);
            this.groupBox6.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // chkEnableLogging
            // 
            resources.ApplyResources(this.chkEnableLogging, "chkEnableLogging");
            this.chkEnableLogging.Name = "chkEnableLogging";
            this.chkEnableLogging.UseVisualStyleBackColor = true;
            this.chkEnableLogging.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cboLogLevel
            // 
            this.cboLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboLogLevel, "cboLogLevel");
            this.cboLogLevel.FormattingEnabled = true;
            this.cboLogLevel.Items.AddRange(new object[] {
            resources.GetString("cboLogLevel.Items"),
            resources.GetString("cboLogLevel.Items1"),
            resources.GetString("cboLogLevel.Items2"),
            resources.GetString("cboLogLevel.Items3"),
            resources.GetString("cboLogLevel.Items4"),
            resources.GetString("cboLogLevel.Items5"),
            resources.GetString("cboLogLevel.Items6"),
            resources.GetString("cboLogLevel.Items7")});
            this.cboLogLevel.Name = "cboLogLevel";
            this.cboLogLevel.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // numLogRecycleDays
            // 
            resources.ApplyResources(this.numLogRecycleDays, "numLogRecycleDays");
            this.numLogRecycleDays.Name = "numLogRecycleDays";
            this.numLogRecycleDays.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblLogRecycleDays
            // 
            resources.ApplyResources(this.lblLogRecycleDays, "lblLogRecycleDays");
            this.lblLogRecycleDays.Name = "lblLogRecycleDays";
            // 
            // numDownloadRecycleDays
            // 
            this.numDownloadRecycleDays.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.numDownloadRecycleDays, "numDownloadRecycleDays");
            this.numDownloadRecycleDays.Name = "numDownloadRecycleDays";
            this.numDownloadRecycleDays.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblLogLevel
            // 
            resources.ApplyResources(this.lblLogLevel, "lblLogLevel");
            this.lblLogLevel.Name = "lblLogLevel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // txtClientRoot
            // 
            resources.ApplyResources(this.txtClientRoot, "txtClientRoot");
            this.txtClientRoot.Name = "txtClientRoot";
            this.txtClientRoot.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // txtClientInstallDrive
            // 
            resources.ApplyResources(this.txtClientInstallDrive, "txtClientInstallDrive");
            this.txtClientInstallDrive.Name = "txtClientInstallDrive";
            this.txtClientInstallDrive.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // GlobalSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "GlobalSettings";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpireDays)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogRecycleDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownloadRecycleDays)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkForceEnglish;
		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtClientRoot;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtClientInstallDrive;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cboLogLevel;
		private System.Windows.Forms.NumericUpDown numLogRecycleDays;
		private System.Windows.Forms.Label lblLogRecycleDays;
		private System.Windows.Forms.Label lblLogLevel;
		private System.Windows.Forms.CheckBox chkShowCursor;
		private System.Windows.Forms.CheckBox chkEnableLogging;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDownloadRecycleDays;
        private System.Windows.Forms.CheckBox chkShareCreditSetting;
        private System.Windows.Forms.CheckBox chkSharePointsSetting;
        private System.Windows.Forms.CheckBox chkEnableCouponManagement;
        private System.Windows.Forms.CheckBox chkCouponsTaxable;
        private System.Windows.Forms.Label lblExpireDayOrDays;
        private System.Windows.Forms.NumericUpDown nudExpireDays;
        private System.Windows.Forms.CheckBox chkExpire;
	}
}
