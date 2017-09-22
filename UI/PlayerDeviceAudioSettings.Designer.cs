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
            this.SuspendLayout();
            // 
            // tabCtrl_AudioDevice
            // 
            resources.ApplyResources(this.tabCtrl_AudioDevice, "tabCtrl_AudioDevice");
            this.tabCtrl_AudioDevice.Name = "tabCtrl_AudioDevice";
            this.tabCtrl_AudioDevice.SelectedIndex = 0;
            this.tabCtrl_AudioDevice.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_AudioDevice_SelectedIndexChanged);
            // 
            // PlayerDeviceAudioSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl_AudioDevice);
            this.DoubleBuffered = true;
            this.Name = "PlayerDeviceAudioSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_AudioDevice;
    }
}
