namespace GTI.Modules.SystemSettings.UI
{
	partial class HallDisplaySettings
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
            System.Windows.Forms.Label winnerPollIntervalLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HallDisplaySettings));
            System.Windows.Forms.Label prevWinnerDisplayIntervalLabel;
            System.Windows.Forms.Label prevWinnerDisplayTimeLabel;
            this.winnerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.chkShowPayoutAmount = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCameraChannel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numScreenSaverTimeout = new System.Windows.Forms.NumericUpDown();
            this.chkFlashboardCamera = new System.Windows.Forms.CheckBox();
            this.chkShowWinnersOnly = new System.Windows.Forms.CheckBox();
            this.numPreviousWinnerDisplayTime = new System.Windows.Forms.NumericUpDown();
            this.numPreviousWinnerDisplayInterval = new System.Windows.Forms.NumericUpDown();
            this.numWinnerPollInterval = new System.Windows.Forms.NumericUpDown();
            this.chkShowWinnerInfo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numMinBallCallTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdChangeBallColor = new System.Windows.Forms.RadioButton();
            this.rdNextBallOnly = new System.Windows.Forms.RadioButton();
            this.rdChangeBGColor = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.grpSceneInfo = new System.Windows.Forms.GroupBox();
            this.cboDefaultScene = new System.Windows.Forms.ComboBox();
            this.lvAllowableScenes = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            winnerPollIntervalLabel = new System.Windows.Forms.Label();
            prevWinnerDisplayIntervalLabel = new System.Windows.Forms.Label();
            prevWinnerDisplayTimeLabel = new System.Windows.Forms.Label();
            this.winnerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenSaverTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousWinnerDisplayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousWinnerDisplayInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWinnerPollInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinBallCallTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpSceneInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // winnerPollIntervalLabel
            // 
            resources.ApplyResources(winnerPollIntervalLabel, "winnerPollIntervalLabel");
            winnerPollIntervalLabel.BackColor = System.Drawing.Color.Transparent;
            winnerPollIntervalLabel.Name = "winnerPollIntervalLabel";
            // 
            // prevWinnerDisplayIntervalLabel
            // 
            resources.ApplyResources(prevWinnerDisplayIntervalLabel, "prevWinnerDisplayIntervalLabel");
            prevWinnerDisplayIntervalLabel.BackColor = System.Drawing.Color.Transparent;
            prevWinnerDisplayIntervalLabel.Name = "prevWinnerDisplayIntervalLabel";
            // 
            // prevWinnerDisplayTimeLabel
            // 
            resources.ApplyResources(prevWinnerDisplayTimeLabel, "prevWinnerDisplayTimeLabel");
            prevWinnerDisplayTimeLabel.BackColor = System.Drawing.Color.Transparent;
            prevWinnerDisplayTimeLabel.Name = "prevWinnerDisplayTimeLabel";
            // 
            // winnerSettingsGroupBox
            // 
            this.winnerSettingsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.winnerSettingsGroupBox.Controls.Add(this.chkShowPayoutAmount);
            this.winnerSettingsGroupBox.Controls.Add(this.label5);
            this.winnerSettingsGroupBox.Controls.Add(this.cboCameraChannel);
            this.winnerSettingsGroupBox.Controls.Add(this.label4);
            this.winnerSettingsGroupBox.Controls.Add(this.label3);
            this.winnerSettingsGroupBox.Controls.Add(this.numScreenSaverTimeout);
            this.winnerSettingsGroupBox.Controls.Add(this.chkFlashboardCamera);
            this.winnerSettingsGroupBox.Controls.Add(this.chkShowWinnersOnly);
            this.winnerSettingsGroupBox.Controls.Add(this.numPreviousWinnerDisplayTime);
            this.winnerSettingsGroupBox.Controls.Add(this.numPreviousWinnerDisplayInterval);
            this.winnerSettingsGroupBox.Controls.Add(this.numWinnerPollInterval);
            this.winnerSettingsGroupBox.Controls.Add(this.chkShowWinnerInfo);
            this.winnerSettingsGroupBox.Controls.Add(winnerPollIntervalLabel);
            this.winnerSettingsGroupBox.Controls.Add(prevWinnerDisplayIntervalLabel);
            this.winnerSettingsGroupBox.Controls.Add(prevWinnerDisplayTimeLabel);
            this.winnerSettingsGroupBox.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.winnerSettingsGroupBox, "winnerSettingsGroupBox");
            this.winnerSettingsGroupBox.Name = "winnerSettingsGroupBox";
            this.winnerSettingsGroupBox.TabStop = false;
            // 
            // chkShowPayoutAmount
            // 
            this.chkShowPayoutAmount.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkShowPayoutAmount, "chkShowPayoutAmount");
            this.chkShowPayoutAmount.Name = "chkShowPayoutAmount";
            this.chkShowPayoutAmount.UseVisualStyleBackColor = false;
            this.chkShowPayoutAmount.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cboCameraChannel
            // 
            resources.ApplyResources(this.cboCameraChannel, "cboCameraChannel");
            this.cboCameraChannel.FormattingEnabled = true;
            this.cboCameraChannel.Items.AddRange(new object[] {
            resources.GetString("cboCameraChannel.Items"),
            resources.GetString("cboCameraChannel.Items1"),
            resources.GetString("cboCameraChannel.Items2")});
            this.cboCameraChannel.Name = "cboCameraChannel";
            this.cboCameraChannel.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            this.cboCameraChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCameraChannel_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numScreenSaverTimeout
            // 
            resources.ApplyResources(this.numScreenSaverTimeout, "numScreenSaverTimeout");
            this.numScreenSaverTimeout.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numScreenSaverTimeout.Name = "numScreenSaverTimeout";
            this.numScreenSaverTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkFlashboardCamera
            // 
            resources.ApplyResources(this.chkFlashboardCamera, "chkFlashboardCamera");
            this.chkFlashboardCamera.Name = "chkFlashboardCamera";
            this.chkFlashboardCamera.UseVisualStyleBackColor = true;
            this.chkFlashboardCamera.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShowWinnersOnly
            // 
            resources.ApplyResources(this.chkShowWinnersOnly, "chkShowWinnersOnly");
            this.chkShowWinnersOnly.Name = "chkShowWinnersOnly";
            this.chkShowWinnersOnly.UseVisualStyleBackColor = true;
            this.chkShowWinnersOnly.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // numPreviousWinnerDisplayTime
            // 
            resources.ApplyResources(this.numPreviousWinnerDisplayTime, "numPreviousWinnerDisplayTime");
            this.numPreviousWinnerDisplayTime.Name = "numPreviousWinnerDisplayTime";
            this.numPreviousWinnerDisplayTime.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numPreviousWinnerDisplayInterval
            // 
            resources.ApplyResources(this.numPreviousWinnerDisplayInterval, "numPreviousWinnerDisplayInterval");
            this.numPreviousWinnerDisplayInterval.Name = "numPreviousWinnerDisplayInterval";
            this.numPreviousWinnerDisplayInterval.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numWinnerPollInterval
            // 
            resources.ApplyResources(this.numWinnerPollInterval, "numWinnerPollInterval");
            this.numWinnerPollInterval.Name = "numWinnerPollInterval";
            this.numWinnerPollInterval.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShowWinnerInfo
            // 
            this.chkShowWinnerInfo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkShowWinnerInfo, "chkShowWinnerInfo");
            this.chkShowWinnerInfo.Name = "chkShowWinnerInfo";
            this.chkShowWinnerInfo.UseVisualStyleBackColor = false;
            this.chkShowWinnerInfo.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numMinBallCallTime);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numMinBallCallTime
            // 
            resources.ApplyResources(this.numMinBallCallTime, "numMinBallCallTime");
            this.numMinBallCallTime.Name = "numMinBallCallTime";
            this.numMinBallCallTime.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdChangeBallColor);
            this.groupBox1.Controls.Add(this.rdNextBallOnly);
            this.groupBox1.Controls.Add(this.rdChangeBGColor);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdChangeBallColor
            // 
            resources.ApplyResources(this.rdChangeBallColor, "rdChangeBallColor");
            this.rdChangeBallColor.Name = "rdChangeBallColor";
            this.rdChangeBallColor.TabStop = true;
            this.rdChangeBallColor.UseVisualStyleBackColor = true;
            this.rdChangeBallColor.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // rdNextBallOnly
            // 
            resources.ApplyResources(this.rdNextBallOnly, "rdNextBallOnly");
            this.rdNextBallOnly.Name = "rdNextBallOnly";
            this.rdNextBallOnly.TabStop = true;
            this.rdNextBallOnly.UseVisualStyleBackColor = true;
            this.rdNextBallOnly.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // rdChangeBGColor
            // 
            resources.ApplyResources(this.rdChangeBGColor, "rdChangeBGColor");
            this.rdChangeBGColor.Name = "rdChangeBGColor";
            this.rdChangeBGColor.TabStop = true;
            this.rdChangeBGColor.UseVisualStyleBackColor = true;
            this.rdChangeBGColor.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
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
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpSceneInfo
            // 
            this.grpSceneInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grpSceneInfo.Controls.Add(this.cboDefaultScene);
            this.grpSceneInfo.Controls.Add(this.lvAllowableScenes);
            this.grpSceneInfo.Controls.Add(this.label2);
            this.grpSceneInfo.Controls.Add(this.label1);
            resources.ApplyResources(this.grpSceneInfo, "grpSceneInfo");
            this.grpSceneInfo.Name = "grpSceneInfo";
            this.grpSceneInfo.TabStop = false;
            // 
            // cboDefaultScene
            // 
            this.cboDefaultScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboDefaultScene, "cboDefaultScene");
            this.cboDefaultScene.FormattingEnabled = true;
            this.cboDefaultScene.Name = "cboDefaultScene";
            // 
            // lvAllowableScenes
            // 
            this.lvAllowableScenes.CheckBoxes = true;
            resources.ApplyResources(this.lvAllowableScenes, "lvAllowableScenes");
            this.lvAllowableScenes.FullRowSelect = true;
            this.lvAllowableScenes.MultiSelect = false;
            this.lvAllowableScenes.Name = "lvAllowableScenes";
            this.lvAllowableScenes.UseCompatibleStateImageBehavior = false;
            this.lvAllowableScenes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAllowableScenes_ColumnClick);
            this.lvAllowableScenes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvAllowableScenes_ItemChecked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // HallDisplaySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpSceneInfo);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.winnerSettingsGroupBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "HallDisplaySettings";
            this.Load += new System.EventHandler(this.HallDisplaySettings_Load);
            this.winnerSettingsGroupBox.ResumeLayout(false);
            this.winnerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenSaverTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousWinnerDisplayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreviousWinnerDisplayInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWinnerPollInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinBallCallTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSceneInfo.ResumeLayout(false);
            this.grpSceneInfo.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox winnerSettingsGroupBox;
		private System.Windows.Forms.NumericUpDown numPreviousWinnerDisplayTime;
		private System.Windows.Forms.NumericUpDown numPreviousWinnerDisplayInterval;
		private System.Windows.Forms.NumericUpDown numWinnerPollInterval;
		private System.Windows.Forms.CheckBox chkShowWinnerInfo;
		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.CheckBox chkShowWinnersOnly;
		private System.Windows.Forms.GroupBox grpSceneInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFlashboardCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numScreenSaverTimeout;
        private System.Windows.Forms.ComboBox cboCameraChannel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDefaultScene;
        private System.Windows.Forms.ListView lvAllowableScenes;
        private System.Windows.Forms.CheckBox chkShowPayoutAmount;
        private System.Windows.Forms.NumericUpDown numMinBallCallTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdNextBallOnly;
        private System.Windows.Forms.RadioButton rdChangeBGColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdChangeBallColor;
	}
}
