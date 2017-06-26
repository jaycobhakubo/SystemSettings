namespace GTI.Modules.SystemSettings.UI
{
	partial class CrateModuleSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrateModuleSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numPingTimeout = new System.Windows.Forms.NumericUpDown();
            this.chkRestartNumbers = new System.Windows.Forms.CheckBox();
            this.chkBalanceSales = new System.Windows.Forms.CheckBox();
            this.numDTRDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numProgramPacketDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numSilentPollingInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPingTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTRDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProgramPacketDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSilentPollingInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnReset.Name = "btnReset";
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
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numPingTimeout);
            this.groupBox1.Controls.Add(this.chkRestartNumbers);
            this.groupBox1.Controls.Add(this.chkBalanceSales);
            this.groupBox1.Controls.Add(this.numDTRDelay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numProgramPacketDelay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numSilentPollingInterval);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numPingTimeout
            // 
            resources.ApplyResources(this.numPingTimeout, "numPingTimeout");
            this.numPingTimeout.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPingTimeout.Name = "numPingTimeout";
            this.numPingTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkRestartNumbers
            // 
            resources.ApplyResources(this.chkRestartNumbers, "chkRestartNumbers");
            this.chkRestartNumbers.Name = "chkRestartNumbers";
            this.chkRestartNumbers.UseVisualStyleBackColor = true;
            this.chkRestartNumbers.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkBalanceSales
            // 
            resources.ApplyResources(this.chkBalanceSales, "chkBalanceSales");
            this.chkBalanceSales.Name = "chkBalanceSales";
            this.chkBalanceSales.UseVisualStyleBackColor = true;
            this.chkBalanceSales.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // numDTRDelay
            // 
            resources.ApplyResources(this.numDTRDelay, "numDTRDelay");
            this.numDTRDelay.Name = "numDTRDelay";
            this.numDTRDelay.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numProgramPacketDelay
            // 
            resources.ApplyResources(this.numProgramPacketDelay, "numProgramPacketDelay");
            this.numProgramPacketDelay.Name = "numProgramPacketDelay";
            this.numProgramPacketDelay.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numSilentPollingInterval
            // 
            resources.ApplyResources(this.numSilentPollingInterval, "numSilentPollingInterval");
            this.numSilentPollingInterval.Name = "numSilentPollingInterval";
            this.numSilentPollingInterval.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CrateModuleSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CrateModuleSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPingTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTRDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProgramPacketDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSilentPollingInterval)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numSilentPollingInterval;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numProgramPacketDelay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numDTRDelay;
		private System.Windows.Forms.CheckBox chkBalanceSales;
		private System.Windows.Forms.CheckBox chkRestartNumbers;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numPingTimeout;
	}
}
