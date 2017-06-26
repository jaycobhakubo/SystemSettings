namespace GTI.Modules.SystemSettings.UI
{
    partial class ChannelDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelDlg));
            this.channelInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsEnabled = new System.Windows.Forms.CheckBox();
            this.btnOK = new GTI.Controls.ImageButton();
            this.btnCancel = new GTI.Controls.ImageButton();
            this.channelInformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelInformationGroupBox
            // 
            this.channelInformationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.channelInformationGroupBox.Controls.Add(this.txtName);
            this.channelInformationGroupBox.Controls.Add(this.label1);
            this.channelInformationGroupBox.Controls.Add(this.chkIsEnabled);
            resources.ApplyResources(this.channelInformationGroupBox, "channelInformationGroupBox");
            this.channelInformationGroupBox.Name = "channelInformationGroupBox";
            this.channelInformationGroupBox.TabStop = false;
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkIsEnabled
            // 
            this.chkIsEnabled.Checked = true;
            this.chkIsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkIsEnabled, "chkIsEnabled");
            this.chkIsEnabled.Name = "chkIsEnabled";
            this.chkIsEnabled.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageNormal")));
            this.btnOK.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnOK.ImagePressed")));
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageNormal")));
            this.btnCancel.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImagePressed")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Leave += new System.EventHandler(this.btnCancel_Leave);
            // 
            // ChannelDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.channelInformationGroupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelDlg";
            this.ShowInTaskbar = false;
            this.channelInformationGroupBox.ResumeLayout(false);
            this.channelInformationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox channelInformationGroupBox;
        private System.Windows.Forms.CheckBox chkIsEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private Controls.ImageButton btnOK;
        private Controls.ImageButton btnCancel;
    }
}
