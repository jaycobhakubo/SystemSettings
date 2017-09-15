namespace GTI.Modules.SystemSettings.UI
{
    partial class PlayerDevicePlayModeSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerDevicePlayModeSettings));
            this.tabCtrl_PlayMode = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabCtrl_PlayMode
            // 
            resources.ApplyResources(this.tabCtrl_PlayMode, "tabCtrl_PlayMode");
            this.tabCtrl_PlayMode.Name = "tabCtrl_PlayMode";
            this.tabCtrl_PlayMode.SelectedIndex = 0;
            // 
            // PlayerDevicePlayModeSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl_PlayMode);
            this.DoubleBuffered = true;
            this.Name = "PlayerDevicePlayModeSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_PlayMode;
    }
}
