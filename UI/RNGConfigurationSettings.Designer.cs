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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpBxRNGConfigurationSettings = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckForDuplicates = new System.Windows.Forms.CheckBox();
            this.chkPrintReconcileReceipt = new System.Windows.Forms.CheckBox();
            this.m_chkAutoRetire = new System.Windows.Forms.CheckBox();
            this.m_chkAllowIssuesToExceed = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new GTI.Controls.ImageButton();
            this.btnReset = new GTI.Controls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpBxRNGConfigurationSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSave);
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnReset);
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpBxRNGConfigurationSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.Name = "btnReset";
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // RNGConfigurationSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "RNGConfigurationSettings";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpBxRNGConfigurationSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpBxRNGConfigurationSettings;
        private System.Windows.Forms.CheckBox m_chkCheckForDuplicates;
        private System.Windows.Forms.CheckBox chkPrintReconcileReceipt;
        private System.Windows.Forms.CheckBox m_chkAutoRetire;
        private System.Windows.Forms.CheckBox m_chkAllowIssuesToExceed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
