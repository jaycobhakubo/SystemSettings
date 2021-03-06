﻿namespace GTI.Modules.SystemSettings.UI
{
    partial class SessionSummarySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionSummarySettings));
            this.grpbxSessionSettings = new System.Windows.Forms.GroupBox();
            this.chkbxSetBankToEndBank = new System.Windows.Forms.CheckBox();
            this.btnSave = new GTI.Controls.ImageButton();
            this.btnReset = new GTI.Controls.ImageButton();
            this.grpbxSessionSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxSessionSettings
            // 
            this.grpbxSessionSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.grpbxSessionSettings.BackColor = System.Drawing.Color.Transparent;
            this.grpbxSessionSettings.Controls.Add(this.chkbxSetBankToEndBank);
            resources.ApplyResources(this.grpbxSessionSettings, "grpbxSessionSettings");
            this.grpbxSessionSettings.Name = "grpbxSessionSettings";
            this.grpbxSessionSettings.TabStop = false;
            // 
            // chkbxSetBankToEndBank
            // 
            resources.ApplyResources(this.chkbxSetBankToEndBank, "chkbxSetBankToEndBank");
            this.chkbxSetBankToEndBank.Name = "chkbxSetBankToEndBank";
            this.chkbxSetBankToEndBank.Tag = "209";
            this.chkbxSetBankToEndBank.UseVisualStyleBackColor = true;
            this.chkbxSetBankToEndBank.CheckedChanged += new System.EventHandler(this.OnModified);
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
            // 
            // SessionSummarySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpbxSessionSettings);
            this.DoubleBuffered = true;
            this.Name = "SessionSummarySettings";
            resources.ApplyResources(this, "$this");
            this.grpbxSessionSettings.ResumeLayout(false);
            this.grpbxSessionSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxSessionSettings;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.CheckBox chkbxSetBankToEndBank;

    }
}
