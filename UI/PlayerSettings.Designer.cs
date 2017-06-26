namespace GTI.Modules.SystemSettings.UI
{
    partial class PlayerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkBoxResetRadioOnWifiInterruptions = new System.Windows.Forms.CheckBox();
            this.lblCrateRebootThresholdSeconds = new System.Windows.Forms.Label();
            this.lblCrateRebootThreshold = new System.Windows.Forms.Label();
            this.txtRebootTimeThreshold = new System.Windows.Forms.TextBox();
            this.chkCacheSettings = new System.Windows.Forms.CheckBox();
            this.chkRecoverOnReboot = new System.Windows.Forms.CheckBox();
            this.chkDisplayProgressives = new System.Windows.Forms.CheckBox();
            this.chkClearWinnersScreen = new System.Windows.Forms.CheckBox();
            this.chkTVwoPurchase = new System.Windows.Forms.CheckBox();
            this.chkEnableMultiplayerOnFunGames = new System.Windows.Forms.CheckBox();
            this.chkBingoPatternShading = new System.Windows.Forms.CheckBox();
            this.chkLogoutPackSessionClose = new System.Windows.Forms.CheckBox();
            this.chkDisplayFunGamesOnLogin = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlayerPINLength = new System.Windows.Forms.TextBox();
            this.chkDisplayVerifiedCard = new System.Windows.Forms.CheckBox();
            this.chkLockScreenOn = new System.Windows.Forms.CheckBox();
            this.chkAutoModeOn = new System.Windows.Forms.CheckBox();
            this.chkPeekMode = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWirelessNetworkConnectionLossThreshold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWiredNetworkConnectionLossThreshold = new System.Windows.Forms.TextBox();
            this.chkPlayerPIN = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayWinAnimationDuration = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.chkBoxResetRadioOnWifiInterruptions);
            this.groupBox5.Controls.Add(this.lblCrateRebootThresholdSeconds);
            this.groupBox5.Controls.Add(this.lblCrateRebootThreshold);
            this.groupBox5.Controls.Add(this.txtRebootTimeThreshold);
            this.groupBox5.Controls.Add(this.chkCacheSettings);
            this.groupBox5.Controls.Add(this.chkRecoverOnReboot);
            this.groupBox5.Controls.Add(this.chkDisplayProgressives);
            this.groupBox5.Controls.Add(this.chkClearWinnersScreen);
            this.groupBox5.Controls.Add(this.chkTVwoPurchase);
            this.groupBox5.Controls.Add(this.chkEnableMultiplayerOnFunGames);
            this.groupBox5.Controls.Add(this.chkBingoPatternShading);
            this.groupBox5.Controls.Add(this.chkLogoutPackSessionClose);
            this.groupBox5.Controls.Add(this.chkDisplayFunGamesOnLogin);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtPlayerPINLength);
            this.groupBox5.Controls.Add(this.chkDisplayVerifiedCard);
            this.groupBox5.Controls.Add(this.chkLockScreenOn);
            this.groupBox5.Controls.Add(this.chkAutoModeOn);
            this.groupBox5.Controls.Add(this.chkPeekMode);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtWirelessNetworkConnectionLossThreshold);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtWiredNetworkConnectionLossThreshold);
            this.groupBox5.Controls.Add(this.chkPlayerPIN);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtPlayWinAnimationDuration);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // chkBoxResetRadioOnWifiInterruptions
            // 
            resources.ApplyResources(this.chkBoxResetRadioOnWifiInterruptions, "chkBoxResetRadioOnWifiInterruptions");
            this.chkBoxResetRadioOnWifiInterruptions.Name = "chkBoxResetRadioOnWifiInterruptions";
            this.chkBoxResetRadioOnWifiInterruptions.UseVisualStyleBackColor = true;
            // 
            // lblCrateRebootThresholdSeconds
            // 
            resources.ApplyResources(this.lblCrateRebootThresholdSeconds, "lblCrateRebootThresholdSeconds");
            this.lblCrateRebootThresholdSeconds.Name = "lblCrateRebootThresholdSeconds";
            // 
            // lblCrateRebootThreshold
            // 
            resources.ApplyResources(this.lblCrateRebootThreshold, "lblCrateRebootThreshold");
            this.lblCrateRebootThreshold.Name = "lblCrateRebootThreshold";
            // 
            // txtRebootTimeThreshold
            // 
            resources.ApplyResources(this.txtRebootTimeThreshold, "txtRebootTimeThreshold");
            this.txtRebootTimeThreshold.Name = "txtRebootTimeThreshold";
            this.txtRebootTimeThreshold.TextChanged += new System.EventHandler(this.OnModified);
            this.txtRebootTimeThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // chkCacheSettings
            // 
            resources.ApplyResources(this.chkCacheSettings, "chkCacheSettings");
            this.chkCacheSettings.Name = "chkCacheSettings";
            this.chkCacheSettings.UseVisualStyleBackColor = true;
            // 
            // chkRecoverOnReboot
            // 
            resources.ApplyResources(this.chkRecoverOnReboot, "chkRecoverOnReboot");
            this.chkRecoverOnReboot.Name = "chkRecoverOnReboot";
            this.chkRecoverOnReboot.UseVisualStyleBackColor = true;
            // 
            // chkDisplayProgressives
            // 
            resources.ApplyResources(this.chkDisplayProgressives, "chkDisplayProgressives");
            this.chkDisplayProgressives.Name = "chkDisplayProgressives";
            this.chkDisplayProgressives.UseVisualStyleBackColor = true;
            // 
            // chkClearWinnersScreen
            // 
            resources.ApplyResources(this.chkClearWinnersScreen, "chkClearWinnersScreen");
            this.chkClearWinnersScreen.Name = "chkClearWinnersScreen";
            this.chkClearWinnersScreen.UseVisualStyleBackColor = true;
            this.chkClearWinnersScreen.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkTVwoPurchase
            // 
            resources.ApplyResources(this.chkTVwoPurchase, "chkTVwoPurchase");
            this.chkTVwoPurchase.Name = "chkTVwoPurchase";
            this.chkTVwoPurchase.UseVisualStyleBackColor = true;
            this.chkTVwoPurchase.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableMultiplayerOnFunGames
            // 
            resources.ApplyResources(this.chkEnableMultiplayerOnFunGames, "chkEnableMultiplayerOnFunGames");
            this.chkEnableMultiplayerOnFunGames.Name = "chkEnableMultiplayerOnFunGames";
            this.chkEnableMultiplayerOnFunGames.UseVisualStyleBackColor = true;
            this.chkEnableMultiplayerOnFunGames.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkBingoPatternShading
            // 
            resources.ApplyResources(this.chkBingoPatternShading, "chkBingoPatternShading");
            this.chkBingoPatternShading.Name = "chkBingoPatternShading";
            this.chkBingoPatternShading.UseVisualStyleBackColor = true;
            this.chkBingoPatternShading.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkLogoutPackSessionClose
            // 
            resources.ApplyResources(this.chkLogoutPackSessionClose, "chkLogoutPackSessionClose");
            this.chkLogoutPackSessionClose.Name = "chkLogoutPackSessionClose";
            this.chkLogoutPackSessionClose.UseVisualStyleBackColor = true;
            this.chkLogoutPackSessionClose.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkDisplayFunGamesOnLogin
            // 
            resources.ApplyResources(this.chkDisplayFunGamesOnLogin, "chkDisplayFunGamesOnLogin");
            this.chkDisplayFunGamesOnLogin.Name = "chkDisplayFunGamesOnLogin";
            this.chkDisplayFunGamesOnLogin.UseVisualStyleBackColor = true;
            this.chkDisplayFunGamesOnLogin.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtPlayerPINLength
            // 
            resources.ApplyResources(this.txtPlayerPINLength, "txtPlayerPINLength");
            this.txtPlayerPINLength.Name = "txtPlayerPINLength";
            this.txtPlayerPINLength.TextChanged += new System.EventHandler(this.OnModified);
            this.txtPlayerPINLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlayerPINLength_KeyPress);
            this.txtPlayerPINLength.Leave += new System.EventHandler(this.txtPlayerPINLength_Leave);
            // 
            // chkDisplayVerifiedCard
            // 
            resources.ApplyResources(this.chkDisplayVerifiedCard, "chkDisplayVerifiedCard");
            this.chkDisplayVerifiedCard.Name = "chkDisplayVerifiedCard";
            this.chkDisplayVerifiedCard.UseVisualStyleBackColor = true;
            this.chkDisplayVerifiedCard.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkLockScreenOn
            // 
            resources.ApplyResources(this.chkLockScreenOn, "chkLockScreenOn");
            this.chkLockScreenOn.Name = "chkLockScreenOn";
            this.chkLockScreenOn.UseVisualStyleBackColor = true;
            this.chkLockScreenOn.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAutoModeOn
            // 
            resources.ApplyResources(this.chkAutoModeOn, "chkAutoModeOn");
            this.chkAutoModeOn.Name = "chkAutoModeOn";
            this.chkAutoModeOn.UseVisualStyleBackColor = true;
            this.chkAutoModeOn.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPeekMode
            // 
            resources.ApplyResources(this.chkPeekMode, "chkPeekMode");
            this.chkPeekMode.Name = "chkPeekMode";
            this.chkPeekMode.UseVisualStyleBackColor = true;
            this.chkPeekMode.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtWirelessNetworkConnectionLossThreshold
            // 
            resources.ApplyResources(this.txtWirelessNetworkConnectionLossThreshold, "txtWirelessNetworkConnectionLossThreshold");
            this.txtWirelessNetworkConnectionLossThreshold.Name = "txtWirelessNetworkConnectionLossThreshold";
            this.txtWirelessNetworkConnectionLossThreshold.TextChanged += new System.EventHandler(this.OnModified);
            this.txtWirelessNetworkConnectionLossThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtWiredNetworkConnectionLossThreshold
            // 
            resources.ApplyResources(this.txtWiredNetworkConnectionLossThreshold, "txtWiredNetworkConnectionLossThreshold");
            this.txtWiredNetworkConnectionLossThreshold.Name = "txtWiredNetworkConnectionLossThreshold";
            this.txtWiredNetworkConnectionLossThreshold.TextChanged += new System.EventHandler(this.OnModified);
            this.txtWiredNetworkConnectionLossThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // chkPlayerPIN
            // 
            resources.ApplyResources(this.chkPlayerPIN, "chkPlayerPIN");
            this.chkPlayerPIN.Name = "chkPlayerPIN";
            this.chkPlayerPIN.UseVisualStyleBackColor = true;
            this.chkPlayerPIN.CheckedChanged += new System.EventHandler(this.OnModified);
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
            // txtPlayWinAnimationDuration
            // 
            resources.ApplyResources(this.txtPlayWinAnimationDuration, "txtPlayWinAnimationDuration");
            this.txtPlayWinAnimationDuration.Name = "txtPlayWinAnimationDuration";
            this.txtPlayWinAnimationDuration.TextChanged += new System.EventHandler(this.OnModified);
            this.txtPlayWinAnimationDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // PlayerSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "PlayerSettings";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtPlayWinAnimationDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPlayerPIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWirelessNetworkConnectionLossThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWiredNetworkConnectionLossThreshold;
        private System.Windows.Forms.CheckBox chkPeekMode;
        private System.Windows.Forms.CheckBox chkLockScreenOn;
        private System.Windows.Forms.CheckBox chkAutoModeOn;
        private System.Windows.Forms.CheckBox chkDisplayVerifiedCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlayerPINLength;
        private System.Windows.Forms.CheckBox chkDisplayFunGamesOnLogin;
        private System.Windows.Forms.CheckBox chkLogoutPackSessionClose;
        private System.Windows.Forms.CheckBox chkBingoPatternShading;
        private System.Windows.Forms.CheckBox chkEnableMultiplayerOnFunGames;
        private System.Windows.Forms.CheckBox chkTVwoPurchase;
        private System.Windows.Forms.CheckBox chkClearWinnersScreen;
        private System.Windows.Forms.CheckBox chkDisplayProgressives;
        private System.Windows.Forms.CheckBox chkRecoverOnReboot;
        private System.Windows.Forms.CheckBox chkCacheSettings;
        private System.Windows.Forms.Label lblCrateRebootThresholdSeconds;
        private System.Windows.Forms.Label lblCrateRebootThreshold;
        private System.Windows.Forms.TextBox txtRebootTimeThreshold;
        private System.Windows.Forms.CheckBox chkBoxResetRadioOnWifiInterruptions;
	}
}
