﻿namespace GTI.Modules.SystemSettings.UI
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
            this.tabPg_FixedBased = new System.Windows.Forms.TabPage();
            this.tabPg_TedE = new System.Windows.Forms.TabPage();
            this.playerSettings1 = new GTI.Modules.SystemSettings.UI.PlayerSettings();
            this.tabCtrl_PlayerSettingDevice.SuspendLayout();
            this.tabPg_FixedBased.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl_PlayerSettingDevice
            // 
            this.tabCtrl_PlayerSettingDevice.Controls.Add(this.tabPg_FixedBased);
            this.tabCtrl_PlayerSettingDevice.Controls.Add(this.tabPg_TedE);
            resources.ApplyResources(this.tabCtrl_PlayerSettingDevice, "tabCtrl_PlayerSettingDevice");
            this.tabCtrl_PlayerSettingDevice.Name = "tabCtrl_PlayerSettingDevice";
            this.tabCtrl_PlayerSettingDevice.SelectedIndex = 0;
            // 
            // tabPg_FixedBased
            // 
            this.tabPg_FixedBased.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_FixedBased.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            this.tabPg_FixedBased.Controls.Add(this.playerSettings1);
            resources.ApplyResources(this.tabPg_FixedBased, "tabPg_FixedBased");
            this.tabPg_FixedBased.Name = "tabPg_FixedBased";
            // 
            // tabPg_TedE
            // 
            this.tabPg_TedE.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_TedE.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            resources.ApplyResources(this.tabPg_TedE, "tabPg_TedE");
            this.tabPg_TedE.Name = "tabPg_TedE";
            // 
            // playerSettings1
            // 
            resources.ApplyResources(this.playerSettings1, "playerSettings1");
            this.playerSettings1.Name = "playerSettings1";
            // 
            // PlayerDeviceSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl_PlayerSettingDevice);
            this.Name = "PlayerDeviceSettings";
            this.tabCtrl_PlayerSettingDevice.ResumeLayout(false);
            this.tabPg_FixedBased.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_PlayerSettingDevice;
        private System.Windows.Forms.TabPage tabPg_FixedBased;
        private System.Windows.Forms.TabPage tabPg_TedE;
        private PlayerSettings playerSettings1;
    }
}
