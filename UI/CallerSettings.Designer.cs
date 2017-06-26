#region copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All Rights Reserved
#endregion

namespace GTI.Modules.SystemSettings.UI
{
	partial class CallerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallerSettings));
            this.grpExtraBalls = new System.Windows.Forms.GroupBox();
            this.chkExtraBonus5 = new System.Windows.Forms.CheckBox();
            this.chkExtraBonus4 = new System.Windows.Forms.CheckBox();
            this.chkExtraBonus3 = new System.Windows.Forms.CheckBox();
            this.chkExtraBonus2 = new System.Windows.Forms.CheckBox();
            this.chkExtraBonus1 = new System.Windows.Forms.CheckBox();
            this.grpBlower = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboScanner2Port = new System.Windows.Forms.ComboBox();
            this.tbBlowerAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableBlower = new System.Windows.Forms.CheckBox();
            this.cboScanner1Port = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numCoolDownTimer = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.grpCaller = new System.Windows.Forms.GroupBox();
            this.lblGameStateBroadcastDelayMs = new System.Windows.Forms.Label();
            this.numGameStateBroadcastDelay = new System.Windows.Forms.NumericUpDown();
            this.lblGameStateBroadcastDelay = new System.Windows.Forms.Label();
            this.grpFlashboard = new System.Windows.Forms.GroupBox();
            this.chkEnableLedFB = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFbNumDisplay = new System.Windows.Forms.ComboBox();
            this.grpRF = new System.Windows.Forms.GroupBox();
            this.rfDelayMsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRFSerialPort = new System.Windows.Forms.ComboBox();
            this.numRfPacketSleep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.rfDelayLabel = new System.Windows.Forms.Label();
            this.cboRFTransType = new System.Windows.Forms.ComboBox();
            this.grpFBI = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFBInterfacePort = new System.Windows.Forms.ComboBox();
            this.cboFBInterfaceType = new System.Windows.Forms.ComboBox();
            this.chkDisplayWinnerCount = new System.Windows.Forms.CheckBox();
            this.chkAllowManualWildCalls = new System.Windows.Forms.CheckBox();
            this.chkEnableOneTouchVerify = new System.Windows.Forms.CheckBox();
            this.chkPrintBallCalls = new System.Windows.Forms.CheckBox();
            this.chkCardStatusOverride = new System.Windows.Forms.CheckBox();
            this.chkAllowPlayTypeToggle = new System.Windows.Forms.CheckBox();
            this.chkPrintWinners = new System.Windows.Forms.CheckBox();
            this.chkAllowAutoGameAdvance = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.grpExtraBalls.SuspendLayout();
            this.grpBlower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoolDownTimer)).BeginInit();
            this.grpCaller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGameStateBroadcastDelay)).BeginInit();
            this.grpFlashboard.SuspendLayout();
            this.grpRF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRfPacketSleep)).BeginInit();
            this.grpFBI.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpExtraBalls
            // 
            this.grpExtraBalls.Controls.Add(this.chkExtraBonus5);
            this.grpExtraBalls.Controls.Add(this.chkExtraBonus4);
            this.grpExtraBalls.Controls.Add(this.chkExtraBonus3);
            this.grpExtraBalls.Controls.Add(this.chkExtraBonus2);
            this.grpExtraBalls.Controls.Add(this.chkExtraBonus1);
            resources.ApplyResources(this.grpExtraBalls, "grpExtraBalls");
            this.grpExtraBalls.Name = "grpExtraBalls";
            this.grpExtraBalls.TabStop = false;
            // 
            // chkExtraBonus5
            // 
            resources.ApplyResources(this.chkExtraBonus5, "chkExtraBonus5");
            this.chkExtraBonus5.Name = "chkExtraBonus5";
            this.chkExtraBonus5.UseVisualStyleBackColor = true;
            this.chkExtraBonus5.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkExtraBonus4
            // 
            resources.ApplyResources(this.chkExtraBonus4, "chkExtraBonus4");
            this.chkExtraBonus4.Name = "chkExtraBonus4";
            this.chkExtraBonus4.UseVisualStyleBackColor = true;
            this.chkExtraBonus4.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkExtraBonus3
            // 
            resources.ApplyResources(this.chkExtraBonus3, "chkExtraBonus3");
            this.chkExtraBonus3.Name = "chkExtraBonus3";
            this.chkExtraBonus3.UseVisualStyleBackColor = true;
            this.chkExtraBonus3.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkExtraBonus2
            // 
            resources.ApplyResources(this.chkExtraBonus2, "chkExtraBonus2");
            this.chkExtraBonus2.Name = "chkExtraBonus2";
            this.chkExtraBonus2.UseVisualStyleBackColor = true;
            this.chkExtraBonus2.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkExtraBonus1
            // 
            resources.ApplyResources(this.chkExtraBonus1, "chkExtraBonus1");
            this.chkExtraBonus1.Name = "chkExtraBonus1";
            this.chkExtraBonus1.UseVisualStyleBackColor = true;
            this.chkExtraBonus1.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // grpBlower
            // 
            this.grpBlower.Controls.Add(this.label11);
            this.grpBlower.Controls.Add(this.cboScanner2Port);
            this.grpBlower.Controls.Add(this.tbBlowerAddress);
            this.grpBlower.Controls.Add(this.label5);
            this.grpBlower.Controls.Add(this.chkEnableBlower);
            this.grpBlower.Controls.Add(this.cboScanner1Port);
            this.grpBlower.Controls.Add(this.label6);
            this.grpBlower.Controls.Add(this.numCoolDownTimer);
            this.grpBlower.Controls.Add(this.label4);
            resources.ApplyResources(this.grpBlower, "grpBlower");
            this.grpBlower.Name = "grpBlower";
            this.grpBlower.TabStop = false;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // cboScanner2Port
            // 
            this.cboScanner2Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboScanner2Port, "cboScanner2Port");
            this.cboScanner2Port.FormattingEnabled = true;
            this.cboScanner2Port.Name = "cboScanner2Port";
            this.cboScanner2Port.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // tbBlowerAddress
            // 
            resources.ApplyResources(this.tbBlowerAddress, "tbBlowerAddress");
            this.tbBlowerAddress.Name = "tbBlowerAddress";
            this.tbBlowerAddress.TextChanged += new System.EventHandler(this.OnModified);
            this.tbBlowerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBlowerAddress_OnKeyPress);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // chkEnableBlower
            // 
            resources.ApplyResources(this.chkEnableBlower, "chkEnableBlower");
            this.chkEnableBlower.Name = "chkEnableBlower";
            this.chkEnableBlower.UseVisualStyleBackColor = true;
            this.chkEnableBlower.CheckedChanged += new System.EventHandler(this.chkEnableBlower_CheckedChanged);
            // 
            // cboScanner1Port
            // 
            this.cboScanner1Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboScanner1Port, "cboScanner1Port");
            this.cboScanner1Port.FormattingEnabled = true;
            this.cboScanner1Port.Name = "cboScanner1Port";
            this.cboScanner1Port.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numCoolDownTimer
            // 
            resources.ApplyResources(this.numCoolDownTimer, "numCoolDownTimer");
            this.numCoolDownTimer.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numCoolDownTimer.Name = "numCoolDownTimer";
            this.numCoolDownTimer.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // grpCaller
            // 
            this.grpCaller.Controls.Add(this.lblGameStateBroadcastDelayMs);
            this.grpCaller.Controls.Add(this.numGameStateBroadcastDelay);
            this.grpCaller.Controls.Add(this.lblGameStateBroadcastDelay);
            this.grpCaller.Controls.Add(this.grpFlashboard);
            this.grpCaller.Controls.Add(this.grpRF);
            this.grpCaller.Controls.Add(this.grpFBI);
            this.grpCaller.Controls.Add(this.chkDisplayWinnerCount);
            this.grpCaller.Controls.Add(this.chkAllowManualWildCalls);
            this.grpCaller.Controls.Add(this.chkEnableOneTouchVerify);
            this.grpCaller.Controls.Add(this.chkPrintBallCalls);
            this.grpCaller.Controls.Add(this.chkCardStatusOverride);
            this.grpCaller.Controls.Add(this.chkAllowPlayTypeToggle);
            this.grpCaller.Controls.Add(this.chkPrintWinners);
            this.grpCaller.Controls.Add(this.chkAllowAutoGameAdvance);
            resources.ApplyResources(this.grpCaller, "grpCaller");
            this.grpCaller.Name = "grpCaller";
            this.grpCaller.TabStop = false;
            // 
            // lblGameStateBroadcastDelayMs
            // 
            resources.ApplyResources(this.lblGameStateBroadcastDelayMs, "lblGameStateBroadcastDelayMs");
            this.lblGameStateBroadcastDelayMs.Name = "lblGameStateBroadcastDelayMs";
            // 
            // numGameStateBroadcastDelay
            // 
            resources.ApplyResources(this.numGameStateBroadcastDelay, "numGameStateBroadcastDelay");
            this.numGameStateBroadcastDelay.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numGameStateBroadcastDelay.Name = "numGameStateBroadcastDelay";
            // 
            // lblGameStateBroadcastDelay
            // 
            resources.ApplyResources(this.lblGameStateBroadcastDelay, "lblGameStateBroadcastDelay");
            this.lblGameStateBroadcastDelay.Name = "lblGameStateBroadcastDelay";
            // 
            // grpFlashboard
            // 
            this.grpFlashboard.Controls.Add(this.chkEnableLedFB);
            this.grpFlashboard.Controls.Add(this.label7);
            this.grpFlashboard.Controls.Add(this.cboFbNumDisplay);
            resources.ApplyResources(this.grpFlashboard, "grpFlashboard");
            this.grpFlashboard.Name = "grpFlashboard";
            this.grpFlashboard.TabStop = false;
            // 
            // chkEnableLedFB
            // 
            resources.ApplyResources(this.chkEnableLedFB, "chkEnableLedFB");
            this.chkEnableLedFB.Name = "chkEnableLedFB";
            this.chkEnableLedFB.UseVisualStyleBackColor = true;
            this.chkEnableLedFB.CheckedChanged += new System.EventHandler(this.chkEnableLedFB_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cboFbNumDisplay
            // 
            this.cboFbNumDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboFbNumDisplay, "cboFbNumDisplay");
            this.cboFbNumDisplay.FormattingEnabled = true;
            this.cboFbNumDisplay.Name = "cboFbNumDisplay";
            this.cboFbNumDisplay.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // grpRF
            // 
            this.grpRF.Controls.Add(this.rfDelayMsLabel);
            this.grpRF.Controls.Add(this.label1);
            this.grpRF.Controls.Add(this.cboRFSerialPort);
            this.grpRF.Controls.Add(this.numRfPacketSleep);
            this.grpRF.Controls.Add(this.label8);
            this.grpRF.Controls.Add(this.rfDelayLabel);
            this.grpRF.Controls.Add(this.cboRFTransType);
            resources.ApplyResources(this.grpRF, "grpRF");
            this.grpRF.Name = "grpRF";
            this.grpRF.TabStop = false;
            // 
            // rfDelayMsLabel
            // 
            resources.ApplyResources(this.rfDelayMsLabel, "rfDelayMsLabel");
            this.rfDelayMsLabel.Name = "rfDelayMsLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cboRFSerialPort
            // 
            this.cboRFSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboRFSerialPort, "cboRFSerialPort");
            this.cboRFSerialPort.FormattingEnabled = true;
            this.cboRFSerialPort.Name = "cboRFSerialPort";
            this.cboRFSerialPort.SelectedIndexChanged += new System.EventHandler(this.cboRFSerialPort_SelectedIndexChanged);
            this.cboRFSerialPort.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numRfPacketSleep
            // 
            resources.ApplyResources(this.numRfPacketSleep, "numRfPacketSleep");
            this.numRfPacketSleep.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numRfPacketSleep.Name = "numRfPacketSleep";
            this.numRfPacketSleep.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // rfDelayLabel
            // 
            resources.ApplyResources(this.rfDelayLabel, "rfDelayLabel");
            this.rfDelayLabel.Name = "rfDelayLabel";
            // 
            // cboRFTransType
            // 
            this.cboRFTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboRFTransType, "cboRFTransType");
            this.cboRFTransType.FormattingEnabled = true;
            this.cboRFTransType.Name = "cboRFTransType";
            this.cboRFTransType.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // grpFBI
            // 
            this.grpFBI.Controls.Add(this.label2);
            this.grpFBI.Controls.Add(this.label3);
            this.grpFBI.Controls.Add(this.cboFBInterfacePort);
            this.grpFBI.Controls.Add(this.cboFBInterfaceType);
            resources.ApplyResources(this.grpFBI, "grpFBI");
            this.grpFBI.Name = "grpFBI";
            this.grpFBI.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboFBInterfacePort
            // 
            this.cboFBInterfacePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboFBInterfacePort, "cboFBInterfacePort");
            this.cboFBInterfacePort.FormattingEnabled = true;
            this.cboFBInterfacePort.Name = "cboFBInterfacePort";
            this.cboFBInterfacePort.SelectedIndexChanged += new System.EventHandler(this.cboFBInterfacePort_SelectedIndexChanged);
            this.cboFBInterfacePort.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // cboFBInterfaceType
            // 
            this.cboFBInterfaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboFBInterfaceType, "cboFBInterfaceType");
            this.cboFBInterfaceType.FormattingEnabled = true;
            this.cboFBInterfaceType.Name = "cboFBInterfaceType";
            this.cboFBInterfaceType.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkDisplayWinnerCount
            // 
            resources.ApplyResources(this.chkDisplayWinnerCount, "chkDisplayWinnerCount");
            this.chkDisplayWinnerCount.Name = "chkDisplayWinnerCount";
            this.chkDisplayWinnerCount.UseVisualStyleBackColor = true;
            this.chkDisplayWinnerCount.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAllowManualWildCalls
            // 
            resources.ApplyResources(this.chkAllowManualWildCalls, "chkAllowManualWildCalls");
            this.chkAllowManualWildCalls.Name = "chkAllowManualWildCalls";
            this.chkAllowManualWildCalls.UseVisualStyleBackColor = true;
            this.chkAllowManualWildCalls.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableOneTouchVerify
            // 
            resources.ApplyResources(this.chkEnableOneTouchVerify, "chkEnableOneTouchVerify");
            this.chkEnableOneTouchVerify.Name = "chkEnableOneTouchVerify";
            this.chkEnableOneTouchVerify.UseVisualStyleBackColor = true;
            this.chkEnableOneTouchVerify.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPrintBallCalls
            // 
            resources.ApplyResources(this.chkPrintBallCalls, "chkPrintBallCalls");
            this.chkPrintBallCalls.Name = "chkPrintBallCalls";
            this.chkPrintBallCalls.UseVisualStyleBackColor = true;
            this.chkPrintBallCalls.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkCardStatusOverride
            // 
            resources.ApplyResources(this.chkCardStatusOverride, "chkCardStatusOverride");
            this.chkCardStatusOverride.Name = "chkCardStatusOverride";
            this.chkCardStatusOverride.UseVisualStyleBackColor = true;
            this.chkCardStatusOverride.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAllowPlayTypeToggle
            // 
            resources.ApplyResources(this.chkAllowPlayTypeToggle, "chkAllowPlayTypeToggle");
            this.chkAllowPlayTypeToggle.Name = "chkAllowPlayTypeToggle";
            this.chkAllowPlayTypeToggle.UseVisualStyleBackColor = true;
            this.chkAllowPlayTypeToggle.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPrintWinners
            // 
            resources.ApplyResources(this.chkPrintWinners, "chkPrintWinners");
            this.chkPrintWinners.Name = "chkPrintWinners";
            this.chkPrintWinners.UseVisualStyleBackColor = true;
            this.chkPrintWinners.CheckedChanged += new System.EventHandler(this.chkPrintWinners_CheckedChanged);
            // 
            // chkAllowAutoGameAdvance
            // 
            resources.ApplyResources(this.chkAllowAutoGameAdvance, "chkAllowAutoGameAdvance");
            this.chkAllowAutoGameAdvance.Name = "chkAllowAutoGameAdvance";
            this.chkAllowAutoGameAdvance.UseVisualStyleBackColor = true;
            this.chkAllowAutoGameAdvance.CheckedChanged += new System.EventHandler(this.OnModified);
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
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CallerSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpExtraBalls);
            this.Controls.Add(this.grpBlower);
            this.Controls.Add(this.grpCaller);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CallerSettings";
            this.grpExtraBalls.ResumeLayout(false);
            this.grpExtraBalls.PerformLayout();
            this.grpBlower.ResumeLayout(false);
            this.grpBlower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoolDownTimer)).EndInit();
            this.grpCaller.ResumeLayout(false);
            this.grpCaller.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGameStateBroadcastDelay)).EndInit();
            this.grpFlashboard.ResumeLayout(false);
            this.grpFlashboard.PerformLayout();
            this.grpRF.ResumeLayout(false);
            this.grpRF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRfPacketSleep)).EndInit();
            this.grpFBI.ResumeLayout(false);
            this.grpFBI.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox grpCaller;
		private System.Windows.Forms.CheckBox chkAllowAutoGameAdvance;
        private System.Windows.Forms.CheckBox chkPrintWinners;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboRFSerialPort;
        private System.Windows.Forms.CheckBox chkAllowPlayTypeToggle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFBInterfaceType;
        private System.Windows.Forms.ComboBox cboFBInterfacePort;
        private System.Windows.Forms.CheckBox chkCardStatusOverride;
        private System.Windows.Forms.CheckBox chkPrintBallCalls;
        private System.Windows.Forms.CheckBox chkEnableOneTouchVerify;
        private System.Windows.Forms.NumericUpDown numCoolDownTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAllowManualWildCalls;
        private System.Windows.Forms.GroupBox grpBlower;
        private System.Windows.Forms.CheckBox chkEnableBlower;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboScanner1Port;
        private System.Windows.Forms.ComboBox cboScanner2Port;
        private System.Windows.Forms.TextBox tbBlowerAddress;
        private System.Windows.Forms.CheckBox chkDisplayWinnerCount;
        private System.Windows.Forms.ComboBox cboRFTransType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboFbNumDisplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkEnableLedFB;
        private System.Windows.Forms.NumericUpDown numRfPacketSleep;
        private System.Windows.Forms.Label rfDelayLabel;
        private System.Windows.Forms.GroupBox grpExtraBalls;
        private System.Windows.Forms.CheckBox chkExtraBonus5;
        private System.Windows.Forms.CheckBox chkExtraBonus4;
        private System.Windows.Forms.CheckBox chkExtraBonus3;
        private System.Windows.Forms.CheckBox chkExtraBonus2;
        private System.Windows.Forms.CheckBox chkExtraBonus1;
        private System.Windows.Forms.GroupBox grpRF;
        private System.Windows.Forms.GroupBox grpFBI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpFlashboard;
        private System.Windows.Forms.Label rfDelayMsLabel;
        private System.Windows.Forms.Label lblGameStateBroadcastDelayMs;
        private System.Windows.Forms.NumericUpDown numGameStateBroadcastDelay;
        private System.Windows.Forms.Label lblGameStateBroadcastDelay;
	}
}
