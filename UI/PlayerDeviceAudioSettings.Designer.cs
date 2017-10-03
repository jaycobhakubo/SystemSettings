namespace GTI.Modules.SystemSettings.UI
{
    partial class PlayerDeviceAudioSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerDeviceAudioSettings));
            this.tabCtrl_AudioDevice = new System.Windows.Forms.TabControl();
            this.tbpgDefault = new System.Windows.Forms.TabPage();
            this.audioSettingDefault = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgFixedBase = new System.Windows.Forms.TabPage();
            this.audioSettingsFixedBase = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgExplorer2 = new System.Windows.Forms.TabPage();
            this.audioSettingsExplorer2 = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgTedE = new System.Windows.Forms.TabPage();
            this.audioSettingsTedE = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgTracker = new System.Windows.Forms.TabPage();
            this.audioSettingsTracker = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgTraveler = new System.Windows.Forms.TabPage();
            this.audioSettingsTraveler = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tbpgTraveler2 = new System.Windows.Forms.TabPage();
            this.audioSettingsTraveler2 = new GTI.Modules.SystemSettings.UI.AudioSettings();
            this.tabCtrl_AudioDevice.SuspendLayout();
            this.tbpgDefault.SuspendLayout();
            this.tbpgFixedBase.SuspendLayout();
            this.tbpgExplorer2.SuspendLayout();
            this.tbpgTedE.SuspendLayout();
            this.tbpgTracker.SuspendLayout();
            this.tbpgTraveler.SuspendLayout();
            this.tbpgTraveler2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl_AudioDevice
            // 
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgDefault);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgFixedBase);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgExplorer2);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgTedE);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgTracker);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgTraveler);
            this.tabCtrl_AudioDevice.Controls.Add(this.tbpgTraveler2);
            resources.ApplyResources(this.tabCtrl_AudioDevice, "tabCtrl_AudioDevice");
            this.tabCtrl_AudioDevice.Name = "tabCtrl_AudioDevice";
            this.tabCtrl_AudioDevice.SelectedIndex = 0;
            this.tabCtrl_AudioDevice.Tag = "PlayerDevice";
            this.tabCtrl_AudioDevice.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_AudioDevice_SelectedIndexChanged);
            // 
            // tbpgDefault
            // 
            this.tbpgDefault.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgDefault.Controls.Add(this.audioSettingDefault);
            resources.ApplyResources(this.tbpgDefault, "tbpgDefault");
            this.tbpgDefault.Name = "tbpgDefault";
            // 
            // audioSettingDefault
            // 
            resources.ApplyResources(this.audioSettingDefault, "audioSettingDefault");
            this.audioSettingDefault.DeviceId = 0;
            this.audioSettingDefault.Name = "audioSettingDefault";
            // 
            // tbpgFixedBase
            // 
            this.tbpgFixedBase.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgFixedBase.Controls.Add(this.audioSettingsFixedBase);
            resources.ApplyResources(this.tbpgFixedBase, "tbpgFixedBase");
            this.tbpgFixedBase.Name = "tbpgFixedBase";
            // 
            // audioSettingsFixedBase
            // 
            resources.ApplyResources(this.audioSettingsFixedBase, "audioSettingsFixedBase");
            this.audioSettingsFixedBase.DeviceId = 0;
            this.audioSettingsFixedBase.Name = "audioSettingsFixedBase";
            // 
            // tbpgExplorer2
            // 
            this.tbpgExplorer2.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgExplorer2.Controls.Add(this.audioSettingsExplorer2);
            resources.ApplyResources(this.tbpgExplorer2, "tbpgExplorer2");
            this.tbpgExplorer2.Name = "tbpgExplorer2";
            // 
            // audioSettingsExplorer2
            // 
            resources.ApplyResources(this.audioSettingsExplorer2, "audioSettingsExplorer2");
            this.audioSettingsExplorer2.DeviceId = 0;
            this.audioSettingsExplorer2.Name = "audioSettingsExplorer2";
            // 
            // tbpgTedE
            // 
            this.tbpgTedE.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgTedE.Controls.Add(this.audioSettingsTedE);
            resources.ApplyResources(this.tbpgTedE, "tbpgTedE");
            this.tbpgTedE.Name = "tbpgTedE";
            // 
            // audioSettingsTedE
            // 
            resources.ApplyResources(this.audioSettingsTedE, "audioSettingsTedE");
            this.audioSettingsTedE.DeviceId = 0;
            this.audioSettingsTedE.Name = "audioSettingsTedE";
            // 
            // tbpgTracker
            // 
            this.tbpgTracker.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgTracker.Controls.Add(this.audioSettingsTracker);
            resources.ApplyResources(this.tbpgTracker, "tbpgTracker");
            this.tbpgTracker.Name = "tbpgTracker";
            // 
            // audioSettingsTracker
            // 
            resources.ApplyResources(this.audioSettingsTracker, "audioSettingsTracker");
            this.audioSettingsTracker.DeviceId = 0;
            this.audioSettingsTracker.Name = "audioSettingsTracker";
            // 
            // tbpgTraveler
            // 
            this.tbpgTraveler.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgTraveler.Controls.Add(this.audioSettingsTraveler);
            resources.ApplyResources(this.tbpgTraveler, "tbpgTraveler");
            this.tbpgTraveler.Name = "tbpgTraveler";
            // 
            // audioSettingsTraveler
            // 
            resources.ApplyResources(this.audioSettingsTraveler, "audioSettingsTraveler");
            this.audioSettingsTraveler.DeviceId = 0;
            this.audioSettingsTraveler.Name = "audioSettingsTraveler";
            // 
            // tbpgTraveler2
            // 
            this.tbpgTraveler2.BackColor = System.Drawing.SystemColors.Control;
            this.tbpgTraveler2.Controls.Add(this.audioSettingsTraveler2);
            resources.ApplyResources(this.tbpgTraveler2, "tbpgTraveler2");
            this.tbpgTraveler2.Name = "tbpgTraveler2";
            // 
            // audioSettingsTraveler2
            // 
            resources.ApplyResources(this.audioSettingsTraveler2, "audioSettingsTraveler2");
            this.audioSettingsTraveler2.DeviceId = 0;
            this.audioSettingsTraveler2.Name = "audioSettingsTraveler2";
            // 
            // PlayerDeviceAudioSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl_AudioDevice);
            this.DoubleBuffered = true;
            this.Name = "PlayerDeviceAudioSettings";
            this.Tag = "PlayerDevice";
            this.tabCtrl_AudioDevice.ResumeLayout(false);
            this.tbpgDefault.ResumeLayout(false);
            this.tbpgFixedBase.ResumeLayout(false);
            this.tbpgExplorer2.ResumeLayout(false);
            this.tbpgTedE.ResumeLayout(false);
            this.tbpgTracker.ResumeLayout(false);
            this.tbpgTraveler.ResumeLayout(false);
            this.tbpgTraveler2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_AudioDevice;
        private System.Windows.Forms.TabPage tbpgDefault;
        private AudioSettings audioSettingDefault;
        private System.Windows.Forms.TabPage tbpgFixedBase;
        private AudioSettings audioSettingsFixedBase;
        private System.Windows.Forms.TabPage tbpgExplorer2;
        private AudioSettings audioSettingsExplorer2;
        private System.Windows.Forms.TabPage tbpgTedE;
        private AudioSettings audioSettingsTedE;
        private System.Windows.Forms.TabPage tbpgTracker;
        private AudioSettings audioSettingsTracker;
        private System.Windows.Forms.TabPage tbpgTraveler;
        private AudioSettings audioSettingsTraveler;
        private System.Windows.Forms.TabPage tbpgTraveler2;
        private AudioSettings audioSettingsTraveler2;
    }
}
