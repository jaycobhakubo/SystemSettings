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
            this.numUDRngPort = new System.Windows.Forms.NumericUpDown();
            this.lblRNGPort = new System.Windows.Forms.Label();
            this.txtbxRNGIpAddress = new System.Windows.Forms.TextBox();
            this.lblRngIPAddress = new System.Windows.Forms.Label();
            this.lblRngTypes = new System.Windows.Forms.Label();
            this.cbxRNGTypes = new System.Windows.Forms.ComboBox();
            this.chkbxSecureConnection = new System.Windows.Forms.CheckBox();
            this.chkbxUseInternalRNG = new System.Windows.Forms.CheckBox();
            this.grpBxRNGConfigurationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDRngPort)).BeginInit();
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
            this.grpBxRNGConfigurationSettings.Controls.Add(this.numUDRngPort);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.lblRNGPort);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.txtbxRNGIpAddress);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.lblRngIPAddress);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.lblRngTypes);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.cbxRNGTypes);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.chkbxSecureConnection);
            this.grpBxRNGConfigurationSettings.Controls.Add(this.chkbxUseInternalRNG);
            resources.ApplyResources(this.grpBxRNGConfigurationSettings, "grpBxRNGConfigurationSettings");
            this.grpBxRNGConfigurationSettings.Name = "grpBxRNGConfigurationSettings";
            this.grpBxRNGConfigurationSettings.TabStop = false;
            // 
            // numUDRngPort
            // 
            resources.ApplyResources(this.numUDRngPort, "numUDRngPort");
            this.numUDRngPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUDRngPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDRngPort.Name = "numUDRngPort";
            this.numUDRngPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRNGPort
            // 
            resources.ApplyResources(this.lblRNGPort, "lblRNGPort");
            this.lblRNGPort.Name = "lblRNGPort";
            // 
            // txtbxRNGIpAddress
            // 
            resources.ApplyResources(this.txtbxRNGIpAddress, "txtbxRNGIpAddress");
            this.txtbxRNGIpAddress.Name = "txtbxRNGIpAddress";
            // 
            // lblRngIPAddress
            // 
            resources.ApplyResources(this.lblRngIPAddress, "lblRngIPAddress");
            this.lblRngIPAddress.Name = "lblRngIPAddress";
            // 
            // lblRngTypes
            // 
            resources.ApplyResources(this.lblRngTypes, "lblRngTypes");
            this.lblRngTypes.Name = "lblRngTypes";
            // 
            // cbxRNGTypes
            // 
            this.cbxRNGTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbxRNGTypes, "cbxRNGTypes");
            this.cbxRNGTypes.FormattingEnabled = true;
            this.cbxRNGTypes.Name = "cbxRNGTypes";
            // 
            // chkbxSecureConnection
            // 
            resources.ApplyResources(this.chkbxSecureConnection, "chkbxSecureConnection");
            this.chkbxSecureConnection.Name = "chkbxSecureConnection";
            this.chkbxSecureConnection.UseVisualStyleBackColor = true;
            // 
            // chkbxUseInternalRNG
            // 
            resources.ApplyResources(this.chkbxUseInternalRNG, "chkbxUseInternalRNG");
            this.chkbxUseInternalRNG.Name = "chkbxUseInternalRNG";
            this.chkbxUseInternalRNG.UseVisualStyleBackColor = true;
            this.chkbxUseInternalRNG.CheckedChanged += new System.EventHandler(this.chkbxUseInternalRNG_CheckedChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.numUDRngPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxRNGConfigurationSettings;
        private System.Windows.Forms.CheckBox chkbxSecureConnection;
        private System.Windows.Forms.CheckBox chkbxUseInternalRNG;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.ComboBox cbxRNGTypes;
        private System.Windows.Forms.Label lblRngTypes;
        private System.Windows.Forms.TextBox txtbxRNGIpAddress;
        private System.Windows.Forms.Label lblRngIPAddress;
        private System.Windows.Forms.Label lblRNGPort;
        private System.Windows.Forms.NumericUpDown numUDRngPort;

    }
}
