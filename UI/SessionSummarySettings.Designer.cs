namespace GTI.Modules.SystemSettings.UI
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
            this.chkbxSetEndingBankToActualCash = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUIDisplayMode = new System.Windows.Forms.ComboBox();
            this.chkbxSetBankToEndBank = new System.Windows.Forms.CheckBox();
            this.btnSave = new GTI.Controls.ImageButton();
            this.btnReset = new GTI.Controls.ImageButton();
            this.lblSessionSummaryType = new System.Windows.Forms.Label();
            this.cmbxSessionSummaryType = new System.Windows.Forms.ComboBox();
            this.grpbxSessionSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxSessionSettings
            // 
            this.grpbxSessionSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.grpbxSessionSettings.BackColor = System.Drawing.Color.Transparent;
            this.grpbxSessionSettings.Controls.Add(this.cmbxSessionSummaryType);
            this.grpbxSessionSettings.Controls.Add(this.lblSessionSummaryType);
            this.grpbxSessionSettings.Controls.Add(this.chkbxSetEndingBankToActualCash);
            this.grpbxSessionSettings.Controls.Add(this.label7);
            this.grpbxSessionSettings.Controls.Add(this.cboUIDisplayMode);
            this.grpbxSessionSettings.Controls.Add(this.chkbxSetBankToEndBank);
            resources.ApplyResources(this.grpbxSessionSettings, "grpbxSessionSettings");
            this.grpbxSessionSettings.Name = "grpbxSessionSettings";
            this.grpbxSessionSettings.TabStop = false;
            // 
            // chkbxSetEndingBankToActualCash
            // 
            resources.ApplyResources(this.chkbxSetEndingBankToActualCash, "chkbxSetEndingBankToActualCash");
            this.chkbxSetEndingBankToActualCash.Name = "chkbxSetEndingBankToActualCash";
            this.chkbxSetEndingBankToActualCash.Tag = "209";
            this.chkbxSetEndingBankToActualCash.UseVisualStyleBackColor = true;
            this.chkbxSetEndingBankToActualCash.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cboUIDisplayMode
            // 
            this.cboUIDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboUIDisplayMode, "cboUIDisplayMode");
            this.cboUIDisplayMode.FormattingEnabled = true;
            this.cboUIDisplayMode.Name = "cboUIDisplayMode";
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
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
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
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // lblSessionSummaryType
            // 
            resources.ApplyResources(this.lblSessionSummaryType, "lblSessionSummaryType");
            this.lblSessionSummaryType.Name = "lblSessionSummaryType";
            // 
            // cmbxSessionSummaryType
            // 
            this.cmbxSessionSummaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbxSessionSummaryType, "cmbxSessionSummaryType");
            this.cmbxSessionSummaryType.FormattingEnabled = true;
            this.cmbxSessionSummaryType.Name = "cmbxSessionSummaryType";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUIDisplayMode;
        private System.Windows.Forms.CheckBox chkbxSetEndingBankToActualCash;
        private System.Windows.Forms.ComboBox cmbxSessionSummaryType;
        private System.Windows.Forms.Label lblSessionSummaryType;

    }
}
