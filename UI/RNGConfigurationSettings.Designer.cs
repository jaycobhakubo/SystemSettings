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
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.grpBxRNGConfigurationSettings = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRNGTypes = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_chkCheckForDuplicates = new System.Windows.Forms.CheckBox();
            this.chkPrintReconcileReceipt = new System.Windows.Forms.CheckBox();
            this.grpBxRNGConfigurationSettings.SuspendLayout();
            this.SuspendLayout();
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
            // grpBxRNGConfigurationSettings
            // 
            this.grpBxRNGConfigurationSettings.Controls.Add(this.textBox1);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.label1);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.label7);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.cbxRNGTypes);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.checkBox1);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.m_chkCheckForDuplicates);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.chkPrintReconcileReceipt);
            resources.ApplyResources(this.grpBxRNGConfigurationSettings, "grpBxRNGConfigurationSettings");
            this.grpBxRNGConfigurationSettings.Name = "grpBxRNGConfigurationSettings";
            this.grpBxRNGConfigurationSettings.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cbxRNGTypes
            // 
            this.cbxRNGTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbxRNGTypes, "cbxRNGTypes");
            this.cbxRNGTypes.FormattingEnabled = true;
            this.cbxRNGTypes.Name = "cbxRNGTypes";
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
            this.grpBxRNGConfigurationSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxRNGConfigurationSettings;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox m_chkCheckForDuplicates;
        private System.Windows.Forms.CheckBox chkPrintReconcileReceipt;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.ComboBox cbxRNGTypes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;

    }
}
