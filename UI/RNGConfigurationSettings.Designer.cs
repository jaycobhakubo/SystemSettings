namespace GTI.Modules.SystemSettings.UI
{
    partial class RNGConfigurationSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGConfigurationSettings));
            this.grpBxRNGConfigurationSettings = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckForDuplicates = new System.Windows.Forms.CheckBox();
            this.chkPrintReconcileReceipt = new System.Windows.Forms.CheckBox();
            this.m_chkAutoRetire = new System.Windows.Forms.CheckBox();
            this.m_chkAllowIssuesToExceed = new System.Windows.Forms.CheckBox();
            this.btnSave = new GTI.Controls.ImageButton();
            this.btnReset = new GTI.Controls.ImageButton();
            this.grpBxRNGConfigurationSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxRNGConfigurationSettings
            // 
            this.grpBxRNGConfigurationSettings.Controls.Add(this.checkBox1);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.m_chkCheckForDuplicates);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.chkPrintReconcileReceipt);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.m_chkAutoRetire);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.m_chkAllowIssuesToExceed);
            resources.ApplyResources(this.grpBxRNGConfigurationSettings, "grpBxRNGConfigurationSettings");
            this.grpBxRNGConfigurationSettings.Name = "grpBxRNGConfigurationSettings";
            this.grpBxRNGConfigurationSettings.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_chkCheckForDuplicates
            // 
            resources.ApplyResources(this.m_chkCheckForDuplicates, "m_chkCheckForDuplicates");
            this.m_chkCheckForDuplicates.Name = "m_chkCheckForDuplicates";
            this.m_chkCheckForDuplicates.UseVisualStyleBackColor = true;
            // 
            // chkPrintReconcileReceipt
            // 
            resources.ApplyResources(this.chkPrintReconcileReceipt, "chkPrintReconcileReceipt");
            this.chkPrintReconcileReceipt.Name = "chkPrintReconcileReceipt";
            this.chkPrintReconcileReceipt.UseVisualStyleBackColor = true;
            // 
            // m_chkAutoRetire
            // 
            resources.ApplyResources(this.m_chkAutoRetire, "m_chkAutoRetire");
            this.m_chkAutoRetire.Name = "m_chkAutoRetire";
            this.m_chkAutoRetire.UseVisualStyleBackColor = true;
            // 
            // m_chkAllowIssuesToExceed
            // 
            resources.ApplyResources(this.m_chkAllowIssuesToExceed, "m_chkAllowIssuesToExceed");
            this.m_chkAllowIssuesToExceed.Name = "m_chkAllowIssuesToExceed";
            this.m_chkAllowIssuesToExceed.UseVisualStyleBackColor = true;
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
            // 
            // RNGConfigurationSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBxRNGConfigurationSettings);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "RNGConfigurationSettings";
            this.grpBxRNGConfigurationSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxRNGConfigurationSettings;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox m_chkCheckForDuplicates;
        private System.Windows.Forms.CheckBox chkPrintReconcileReceipt;
        private System.Windows.Forms.CheckBox m_chkAutoRetire;
        private System.Windows.Forms.CheckBox m_chkAllowIssuesToExceed;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;

    }
}
