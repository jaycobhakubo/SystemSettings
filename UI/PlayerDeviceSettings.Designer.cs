namespace GTI.Modules.SystemSettings.UI
{
    partial class PlayerDeviceSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerDeviceSettings));
            this.tabCtrl_PlayerSettingDevice = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabCtrl_PlayerSettingDevice
            // 
            resources.ApplyResources(this.tabCtrl_PlayerSettingDevice, "tabCtrl_PlayerSettingDevice");
            this.tabCtrl_PlayerSettingDevice.Name = "tabCtrl_PlayerSettingDevice";
            this.tabCtrl_PlayerSettingDevice.SelectedIndex = 0;
            this.tabCtrl_PlayerSettingDevice.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_PlayerSettingDevice_SelectedIndexChanged);
            // 
            // PlayerDeviceSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            this.Controls.Add(this.tabCtrl_PlayerSettingDevice);
            resources.ApplyResources(this, "$this");
            this.Name = "PlayerDeviceSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_PlayerSettingDevice;

    }
}
