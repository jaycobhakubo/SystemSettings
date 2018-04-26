namespace GTI.Modules.SystemSettings.UI
{
    partial class PlayModeSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayModeSettings));
            this.chkbxUseDefault = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_cboPlayDaubLocation = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkAllowGreenButtonDaub = new System.Windows.Forms.CheckBox();
            this.m_chkAllowDaubOnImage = new System.Windows.Forms.CheckBox();
            this.m_chkAllowPreCallErrors = new System.Windows.Forms.CheckBox();
            this.m_chkAllowPreDaubing = new System.Windows.Forms.CheckBox();
            this.m_chkAllowCatchUp = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdoButtonSemiAuto = new System.Windows.Forms.RadioButton();
            this.m_rdoButtonManual = new System.Windows.Forms.RadioButton();
            this.m_rdoButtonAuto = new System.Windows.Forms.RadioButton();
            this.m_daubLocationTextBox = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkbxUseDefault
            // 
            resources.ApplyResources(this.chkbxUseDefault, "chkbxUseDefault");
            this.chkbxUseDefault.BackColor = System.Drawing.Color.Transparent;
            this.chkbxUseDefault.Name = "chkbxUseDefault";
            this.chkbxUseDefault.UseVisualStyleBackColor = false;
            this.chkbxUseDefault.CheckedChanged += new System.EventHandler(this.chkbxUseDefault_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.m_cboPlayDaubLocation);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.m_daubLocationTextBox);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // m_cboPlayDaubLocation
            // 
            this.m_cboPlayDaubLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_cboPlayDaubLocation, "m_cboPlayDaubLocation");
            this.m_cboPlayDaubLocation.FormattingEnabled = true;
            this.m_cboPlayDaubLocation.Items.AddRange(new object[] {
            resources.GetString("m_cboPlayDaubLocation.Items"),
            resources.GetString("m_cboPlayDaubLocation.Items1"),
            resources.GetString("m_cboPlayDaubLocation.Items2"),
            resources.GetString("m_cboPlayDaubLocation.Items3")});
            this.m_cboPlayDaubLocation.Name = "m_cboPlayDaubLocation";
            this.m_cboPlayDaubLocation.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkAllowGreenButtonDaub);
            this.groupBox2.Controls.Add(this.m_chkAllowDaubOnImage);
            this.groupBox2.Controls.Add(this.m_chkAllowPreCallErrors);
            this.groupBox2.Controls.Add(this.m_chkAllowPreDaubing);
            this.groupBox2.Controls.Add(this.m_chkAllowCatchUp);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_chkAllowGreenButtonDaub
            // 
            resources.ApplyResources(this.m_chkAllowGreenButtonDaub, "m_chkAllowGreenButtonDaub");
            this.m_chkAllowGreenButtonDaub.Name = "m_chkAllowGreenButtonDaub";
            this.m_chkAllowGreenButtonDaub.UseVisualStyleBackColor = true;
            this.m_chkAllowGreenButtonDaub.CheckedChanged += new System.EventHandler(this.OnModified);
            this.m_chkAllowGreenButtonDaub.Click += new System.EventHandler(this.m_SettingCheckedBox_AfterSelect);
            // 
            // m_chkAllowDaubOnImage
            // 
            resources.ApplyResources(this.m_chkAllowDaubOnImage, "m_chkAllowDaubOnImage");
            this.m_chkAllowDaubOnImage.Name = "m_chkAllowDaubOnImage";
            this.m_chkAllowDaubOnImage.UseVisualStyleBackColor = true;
            this.m_chkAllowDaubOnImage.CheckedChanged += new System.EventHandler(this.OnModified);
            this.m_chkAllowDaubOnImage.Click += new System.EventHandler(this.m_SettingCheckedBox_AfterSelect);
            // 
            // m_chkAllowPreCallErrors
            // 
            resources.ApplyResources(this.m_chkAllowPreCallErrors, "m_chkAllowPreCallErrors");
            this.m_chkAllowPreCallErrors.Name = "m_chkAllowPreCallErrors";
            this.m_chkAllowPreCallErrors.UseVisualStyleBackColor = true;
            this.m_chkAllowPreCallErrors.CheckedChanged += new System.EventHandler(this.OnModified);
            this.m_chkAllowPreCallErrors.Click += new System.EventHandler(this.m_SettingCheckedBox_AfterSelect);
            // 
            // m_chkAllowPreDaubing
            // 
            resources.ApplyResources(this.m_chkAllowPreDaubing, "m_chkAllowPreDaubing");
            this.m_chkAllowPreDaubing.Name = "m_chkAllowPreDaubing";
            this.m_chkAllowPreDaubing.UseVisualStyleBackColor = true;
            this.m_chkAllowPreDaubing.CheckedChanged += new System.EventHandler(this.OnModified);
            this.m_chkAllowPreDaubing.Click += new System.EventHandler(this.m_SettingCheckedBox_AfterSelect);
            // 
            // m_chkAllowCatchUp
            // 
            resources.ApplyResources(this.m_chkAllowCatchUp, "m_chkAllowCatchUp");
            this.m_chkAllowCatchUp.Name = "m_chkAllowCatchUp";
            this.m_chkAllowCatchUp.UseVisualStyleBackColor = true;
            this.m_chkAllowCatchUp.CheckedChanged += new System.EventHandler(this.OnModified);
            this.m_chkAllowCatchUp.Click += new System.EventHandler(this.m_SettingCheckedBox_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdoButtonSemiAuto);
            this.groupBox1.Controls.Add(this.m_rdoButtonManual);
            this.groupBox1.Controls.Add(this.m_rdoButtonAuto);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_rdoButtonSemiAuto
            // 
            resources.ApplyResources(this.m_rdoButtonSemiAuto, "m_rdoButtonSemiAuto");
            this.m_rdoButtonSemiAuto.Name = "m_rdoButtonSemiAuto";
            this.m_rdoButtonSemiAuto.TabStop = true;
            this.m_rdoButtonSemiAuto.UseVisualStyleBackColor = true;
            this.m_rdoButtonSemiAuto.CheckedChanged += new System.EventHandler(this.OnRadioCheckButton);
            // 
            // m_rdoButtonManual
            // 
            resources.ApplyResources(this.m_rdoButtonManual, "m_rdoButtonManual");
            this.m_rdoButtonManual.Name = "m_rdoButtonManual";
            this.m_rdoButtonManual.TabStop = true;
            this.m_rdoButtonManual.UseVisualStyleBackColor = true;
            this.m_rdoButtonManual.CheckedChanged += new System.EventHandler(this.OnRadioCheckButton);
            // 
            // m_rdoButtonAuto
            // 
            resources.ApplyResources(this.m_rdoButtonAuto, "m_rdoButtonAuto");
            this.m_rdoButtonAuto.Name = "m_rdoButtonAuto";
            this.m_rdoButtonAuto.TabStop = true;
            this.m_rdoButtonAuto.UseVisualStyleBackColor = true;
            this.m_rdoButtonAuto.CheckedChanged += new System.EventHandler(this.OnRadioCheckButton);
            // 
            // m_daubLocationTextBox
            // 
            resources.ApplyResources(this.m_daubLocationTextBox, "m_daubLocationTextBox");
            this.m_daubLocationTextBox.Name = "m_daubLocationTextBox";
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
            // PlayModeSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.chkbxUseDefault);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "PlayModeSettings";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.ImageButton btnReset;
        private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_rdoButtonSemiAuto;
        private System.Windows.Forms.RadioButton m_rdoButtonManual;
        private System.Windows.Forms.RadioButton m_rdoButtonAuto;
        private System.Windows.Forms.Label m_daubLocationTextBox;
        private System.Windows.Forms.ComboBox m_cboPlayDaubLocation;
        private System.Windows.Forms.CheckBox m_chkAllowGreenButtonDaub;
        private System.Windows.Forms.CheckBox m_chkAllowDaubOnImage;
        private System.Windows.Forms.CheckBox m_chkAllowPreCallErrors;
        private System.Windows.Forms.CheckBox m_chkAllowPreDaubing;
        private System.Windows.Forms.CheckBox m_chkAllowCatchUp;
        private System.Windows.Forms.CheckBox chkbxUseDefault;
    }
}
