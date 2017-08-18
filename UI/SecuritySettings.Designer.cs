namespace GTI.Modules.SystemSettings.UI
{
	partial class SecuritySettings
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
            System.Windows.Forms.Label maxLoginLimitLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecuritySettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoLogout = new System.Windows.Forms.CheckBox();
            this.chkUseNumericKeypad = new System.Windows.Forms.CheckBox();
            this.numScreenSaverWait = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkScreenSaverEnabled = new System.Windows.Forms.CheckBox();
            this.numMaxLoginLimit = new System.Windows.Forms.NumericUpDown();
            this.chkUsePasswordComplexity = new System.Windows.Forms.CheckBox();
            this.numPinExpireDays = new System.Windows.Forms.NumericUpDown();
            this.pinExpireDaysLabel = new System.Windows.Forms.Label();
            this.numPasswordLockOutAttempts = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPreviousPasswordReuse = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numAutomaticUnlockTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMinimumPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            maxLoginLimitLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenSaverWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLoginLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPinExpireDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPasswordLockOutAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousPasswordReuse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutomaticUnlockTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumPasswordLength)).BeginInit();
            this.SuspendLayout();
            // 
            // maxLoginLimitLabel
            // 
            resources.ApplyResources(maxLoginLimitLabel, "maxLoginLimitLabel");
            maxLoginLimitLabel.Name = "maxLoginLimitLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoLogout);
            this.groupBox1.Controls.Add(this.chkUseNumericKeypad);
            this.groupBox1.Controls.Add(this.numScreenSaverWait);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkScreenSaverEnabled);
            this.groupBox1.Controls.Add(this.numMaxLoginLimit);
            this.groupBox1.Controls.Add(maxLoginLimitLabel);
            this.groupBox1.Controls.Add(this.chkUsePasswordComplexity);
            this.groupBox1.Controls.Add(this.numPinExpireDays);
            this.groupBox1.Controls.Add(this.pinExpireDaysLabel);
            this.groupBox1.Controls.Add(this.numPasswordLockOutAttempts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numPreviousPasswordReuse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numAutomaticUnlockTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numMinimumPasswordLength);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkAutoLogout
            // 
            resources.ApplyResources(this.chkAutoLogout, "chkAutoLogout");
            this.chkAutoLogout.Name = "chkAutoLogout";
            this.chkAutoLogout.UseVisualStyleBackColor = true;
            // 
            // chkUseNumericKeypad
            // 
            resources.ApplyResources(this.chkUseNumericKeypad, "chkUseNumericKeypad");
            this.chkUseNumericKeypad.Name = "chkUseNumericKeypad";
            this.chkUseNumericKeypad.UseVisualStyleBackColor = true;
            this.chkUseNumericKeypad.Click += new System.EventHandler(this.OnModified);
            // 
            // numScreenSaverWait
            // 
            resources.ApplyResources(this.numScreenSaverWait, "numScreenSaverWait");
            this.numScreenSaverWait.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numScreenSaverWait.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScreenSaverWait.Name = "numScreenSaverWait";
            this.numScreenSaverWait.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numScreenSaverWait.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // chkScreenSaverEnabled
            // 
            resources.ApplyResources(this.chkScreenSaverEnabled, "chkScreenSaverEnabled");
            this.chkScreenSaverEnabled.Name = "chkScreenSaverEnabled";
            this.chkScreenSaverEnabled.UseVisualStyleBackColor = true;
            this.chkScreenSaverEnabled.CheckedChanged += new System.EventHandler(this.chkScreenSaverEnabled_CheckedChanged);
            this.chkScreenSaverEnabled.Click += new System.EventHandler(this.OnModified);
            // 
            // numMaxLoginLimit
            // 
            resources.ApplyResources(this.numMaxLoginLimit, "numMaxLoginLimit");
            this.numMaxLoginLimit.Name = "numMaxLoginLimit";
            this.numMaxLoginLimit.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkUsePasswordComplexity
            // 
            resources.ApplyResources(this.chkUsePasswordComplexity, "chkUsePasswordComplexity");
            this.chkUsePasswordComplexity.Name = "chkUsePasswordComplexity";
            this.chkUsePasswordComplexity.UseVisualStyleBackColor = true;
            this.chkUsePasswordComplexity.CheckedChanged += new System.EventHandler(this.chkUsePasswordComplexity_CheckedChanged);
            this.chkUsePasswordComplexity.Click += new System.EventHandler(this.OnModified);
            // 
            // numPinExpireDays
            // 
            resources.ApplyResources(this.numPinExpireDays, "numPinExpireDays");
            this.numPinExpireDays.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPinExpireDays.Name = "numPinExpireDays";
            this.numPinExpireDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPinExpireDays.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // pinExpireDaysLabel
            // 
            resources.ApplyResources(this.pinExpireDaysLabel, "pinExpireDaysLabel");
            this.pinExpireDaysLabel.Name = "pinExpireDaysLabel";
            // 
            // numPasswordLockOutAttempts
            // 
            resources.ApplyResources(this.numPasswordLockOutAttempts, "numPasswordLockOutAttempts");
            this.numPasswordLockOutAttempts.Name = "numPasswordLockOutAttempts";
            this.numPasswordLockOutAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPasswordLockOutAttempts.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numPreviousPasswordReuse
            // 
            resources.ApplyResources(this.numPreviousPasswordReuse, "numPreviousPasswordReuse");
            this.numPreviousPasswordReuse.Name = "numPreviousPasswordReuse";
            this.numPreviousPasswordReuse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPreviousPasswordReuse.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numAutomaticUnlockTime
            // 
            resources.ApplyResources(this.numAutomaticUnlockTime, "numAutomaticUnlockTime");
            this.numAutomaticUnlockTime.Name = "numAutomaticUnlockTime";
            this.numAutomaticUnlockTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutomaticUnlockTime.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numMinimumPasswordLength
            // 
            resources.ApplyResources(this.numMinimumPasswordLength, "numMinimumPasswordLength");
            this.numMinimumPasswordLength.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMinimumPasswordLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinimumPasswordLength.Name = "numMinimumPasswordLength";
            this.numMinimumPasswordLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinimumPasswordLength.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SecuritySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SecuritySettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenSaverWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLoginLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPinExpireDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPasswordLockOutAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousPasswordReuse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutomaticUnlockTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumPasswordLength)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numMinimumPasswordLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPinExpireDays;
        private System.Windows.Forms.Label pinExpireDaysLabel;
        private System.Windows.Forms.NumericUpDown numPasswordLockOutAttempts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPreviousPasswordReuse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAutomaticUnlockTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUsePasswordComplexity;
        private System.Windows.Forms.NumericUpDown numMaxLoginLimit;
        private System.Windows.Forms.CheckBox chkScreenSaverEnabled;
        private System.Windows.Forms.NumericUpDown numScreenSaverWait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkUseNumericKeypad;
        private System.Windows.Forms.CheckBox chkAutoLogout;
	}
}
