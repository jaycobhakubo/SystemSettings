namespace GTI.Modules.SystemSettings.UI
{
    partial class AudioSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioSettings));
            this.chkbxUseDefault = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.MaxTVVolumeLabel = new System.Windows.Forms.Label();
            this.numMaxTVVolume = new System.Windows.Forms.NumericUpDown();
            this.maxVolumeLabel = new System.Windows.Forms.Label();
            this.numMaxGameVolume = new System.Windows.Forms.NumericUpDown();
            this.chkPlayKeyClickEnabled = new System.Windows.Forms.CheckBox();
            this.chkPlayBallCallSoundEnabled = new System.Windows.Forms.CheckBox();
            this.chkPlayWinningSoundEnabled = new System.Windows.Forms.CheckBox();
            this.chkPlayModeOneAwaySound = new System.Windows.Forms.CheckBox();
            this.chkPlayAllSoundEnabled = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTVVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxGameVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // chkbxUseDefault
            // 
            resources.ApplyResources(this.chkbxUseDefault, "chkbxUseDefault");
            this.chkbxUseDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkbxUseDefault.Name = "chkbxUseDefault";
            this.chkbxUseDefault.UseVisualStyleBackColor = false;
            this.chkbxUseDefault.CheckedChanged += new System.EventHandler(this.chkbxUseDefault_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.MaxTVVolumeLabel);
            this.groupBox5.Controls.Add(this.numMaxTVVolume);
            this.groupBox5.Controls.Add(this.maxVolumeLabel);
            this.groupBox5.Controls.Add(this.numMaxGameVolume);
            this.groupBox5.Controls.Add(this.chkPlayKeyClickEnabled);
            this.groupBox5.Controls.Add(this.chkPlayBallCallSoundEnabled);
            this.groupBox5.Controls.Add(this.chkPlayWinningSoundEnabled);
            this.groupBox5.Controls.Add(this.chkPlayModeOneAwaySound);
            this.groupBox5.Controls.Add(this.chkPlayAllSoundEnabled);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // MaxTVVolumeLabel
            // 
            resources.ApplyResources(this.MaxTVVolumeLabel, "MaxTVVolumeLabel");
            this.MaxTVVolumeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MaxTVVolumeLabel.Name = "MaxTVVolumeLabel";
            // 
            // numMaxTVVolume
            // 
            resources.ApplyResources(this.numMaxTVVolume, "numMaxTVVolume");
            this.numMaxTVVolume.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.numMaxTVVolume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxTVVolume.Name = "numMaxTVVolume";
            this.numMaxTVVolume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxTVVolume.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // maxVolumeLabel
            // 
            resources.ApplyResources(this.maxVolumeLabel, "maxVolumeLabel");
            this.maxVolumeLabel.Name = "maxVolumeLabel";
            // 
            // numMaxGameVolume
            // 
            resources.ApplyResources(this.numMaxGameVolume, "numMaxGameVolume");
            this.numMaxGameVolume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxGameVolume.Name = "numMaxGameVolume";
            this.numMaxGameVolume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxGameVolume.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPlayKeyClickEnabled
            // 
            resources.ApplyResources(this.chkPlayKeyClickEnabled, "chkPlayKeyClickEnabled");
            this.chkPlayKeyClickEnabled.Name = "chkPlayKeyClickEnabled";
            this.chkPlayKeyClickEnabled.UseVisualStyleBackColor = true;
            this.chkPlayKeyClickEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPlayBallCallSoundEnabled
            // 
            resources.ApplyResources(this.chkPlayBallCallSoundEnabled, "chkPlayBallCallSoundEnabled");
            this.chkPlayBallCallSoundEnabled.Name = "chkPlayBallCallSoundEnabled";
            this.chkPlayBallCallSoundEnabled.UseVisualStyleBackColor = true;
            this.chkPlayBallCallSoundEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPlayWinningSoundEnabled
            // 
            resources.ApplyResources(this.chkPlayWinningSoundEnabled, "chkPlayWinningSoundEnabled");
            this.chkPlayWinningSoundEnabled.Name = "chkPlayWinningSoundEnabled";
            this.chkPlayWinningSoundEnabled.UseVisualStyleBackColor = true;
            this.chkPlayWinningSoundEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPlayModeOneAwaySound
            // 
            resources.ApplyResources(this.chkPlayModeOneAwaySound, "chkPlayModeOneAwaySound");
            this.chkPlayModeOneAwaySound.Name = "chkPlayModeOneAwaySound";
            this.chkPlayModeOneAwaySound.UseVisualStyleBackColor = true;
            this.chkPlayModeOneAwaySound.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPlayAllSoundEnabled
            // 
            resources.ApplyResources(this.chkPlayAllSoundEnabled, "chkPlayAllSoundEnabled");
            this.chkPlayAllSoundEnabled.Name = "chkPlayAllSoundEnabled";
            this.chkPlayAllSoundEnabled.UseVisualStyleBackColor = true;
            this.chkPlayAllSoundEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            this.chkPlayAllSoundEnabled.CheckStateChanged += new System.EventHandler(this.chkPlayAllSoundEnabled_CheckStateChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
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
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AudioSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkbxUseDefault);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "AudioSettings";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTVVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxGameVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.ImageButton btnReset;
        private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkPlayAllSoundEnabled;
        private System.Windows.Forms.CheckBox chkPlayModeOneAwaySound;
        private System.Windows.Forms.CheckBox chkPlayWinningSoundEnabled;
        private System.Windows.Forms.CheckBox chkPlayBallCallSoundEnabled;
        private System.Windows.Forms.CheckBox chkPlayKeyClickEnabled;
        private System.Windows.Forms.Label maxVolumeLabel;
        private System.Windows.Forms.NumericUpDown numMaxGameVolume;
        private System.Windows.Forms.Label MaxTVVolumeLabel;
        private System.Windows.Forms.NumericUpDown numMaxTVVolume;
        private System.Windows.Forms.CheckBox chkbxUseDefault;
    }
}
