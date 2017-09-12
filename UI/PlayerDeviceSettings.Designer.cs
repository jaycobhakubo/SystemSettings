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
            this.playerSettings1 = new GTI.Modules.SystemSettings.UI.PlayerSettings();
            this.tabPg_Traveler = new System.Windows.Forms.TabPage();
            this.playerSettings2 = new GTI.Modules.SystemSettings.UI.PlayerSettings();
            this.tabPg_TedE = new System.Windows.Forms.TabPage();
            this.playerSettings3 = new GTI.Modules.SystemSettings.UI.PlayerSettings();
            this.tabCtrl_PlayerSettingDevice.SuspendLayout();
            this.tabPg_FixedBased.SuspendLayout();
            this.tabPg_Traveler.SuspendLayout();
            this.tabPg_TedE.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl_PlayerSettingDevice
            // 
            this.tabCtrl_PlayerSettingDevice.Controls.Add(this.tabPg_FixedBased);
            this.tabCtrl_PlayerSettingDevice.Controls.Add(this.tabPg_Traveler);
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
            // playerSettings1
            // 
            this.playerSettings1.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            resources.ApplyResources(this.playerSettings1, "playerSettings1");
            this.playerSettings1.Name = "playerSettings1";
            // 
            // tabPg_Traveler
            // 
            this.tabPg_Traveler.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_Traveler.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            this.tabPg_Traveler.Controls.Add(this.playerSettings2);
            resources.ApplyResources(this.tabPg_Traveler, "tabPg_Traveler");
            this.tabPg_Traveler.Name = "tabPg_Traveler";
            // 
            // playerSettings2
            // 
            this.playerSettings2.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            resources.ApplyResources(this.playerSettings2, "playerSettings2");
            this.playerSettings2.Name = "playerSettings2";
            // 
            // tabPg_TedE
            // 
            this.tabPg_TedE.BackColor = System.Drawing.SystemColors.Control;
            this.tabPg_TedE.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            this.tabPg_TedE.Controls.Add(this.playerSettings3);
            resources.ApplyResources(this.tabPg_TedE, "tabPg_TedE");
            this.tabPg_TedE.Name = "tabPg_TedE";
            // 
            // playerSettings3
            // 
            this.playerSettings3.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            resources.ApplyResources(this.playerSettings3, "playerSettings3");
            this.playerSettings3.Name = "playerSettings3";
            // 
            // PlayerDeviceSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientFull;
            this.Controls.Add(this.tabCtrl_PlayerSettingDevice);
            this.Name = "PlayerDeviceSettings";
            this.tabCtrl_PlayerSettingDevice.ResumeLayout(false);
            this.tabPg_FixedBased.ResumeLayout(false);
            this.tabPg_Traveler.ResumeLayout(false);
            this.tabPg_TedE.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl_PlayerSettingDevice;
        private System.Windows.Forms.TabPage tabPg_FixedBased;
        private System.Windows.Forms.TabPage tabPg_TedE;
        private PlayerSettings playerSettings1;
        private System.Windows.Forms.TabPage tabPg_Traveler;
        private PlayerSettings playerSettings2;
        private PlayerSettings playerSettings3;
    }
}