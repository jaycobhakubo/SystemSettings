namespace GTI.Modules.SystemSettings.UI
{
    partial class ValidationSettings
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
            System.Windows.Forms.Label maxLoginLimitLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationSettings));
            System.Windows.Forms.Label label2;
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxValidationMaxPerTransaction = new GTI.Controls.TextBoxNumeric2();
            this.cmbxCardCount = new System.Windows.Forms.ComboBox();
            this.chkbxEnableValidation = new System.Windows.Forms.CheckBox();
            maxLoginLimitLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maxLoginLimitLabel
            // 
            resources.ApplyResources(maxLoginLimitLabel, "maxLoginLimitLabel");
            maxLoginLimitLabel.Name = "maxLoginLimitLabel";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxValidationMaxPerTransaction);
            this.groupBox1.Controls.Add(this.cmbxCardCount);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(maxLoginLimitLabel);
            this.groupBox1.Controls.Add(this.chkbxEnableValidation);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "grpbxValidationSettings";
            // 
            // txtbxValidationMaxPerTransaction
            // 
            resources.ApplyResources(this.txtbxValidationMaxPerTransaction, "txtbxValidationMaxPerTransaction");
            this.txtbxValidationMaxPerTransaction.Mask = GTI.Controls.TextBoxNumeric2.TextBoxType.Decimal;
            this.txtbxValidationMaxPerTransaction.Name = "txtbxValidationMaxPerTransaction";
            this.txtbxValidationMaxPerTransaction.Precision = 2;
            this.txtbxValidationMaxPerTransaction.TextChanged += new System.EventHandler(this.OnModified);
            this.txtbxValidationMaxPerTransaction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxValidationMaxPerTransaction_KeyPress);
            // 
            // cmbxCardCount
            // 
            this.cmbxCardCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbxCardCount, "cmbxCardCount");
            this.cmbxCardCount.FormattingEnabled = true;
            this.cmbxCardCount.Items.AddRange(new object[] {
            resources.GetString("cmbxCardCount.Items"),
            resources.GetString("cmbxCardCount.Items1"),
            resources.GetString("cmbxCardCount.Items2"),
            resources.GetString("cmbxCardCount.Items3"),
            resources.GetString("cmbxCardCount.Items4"),
            resources.GetString("cmbxCardCount.Items5"),
            resources.GetString("cmbxCardCount.Items6"),
            resources.GetString("cmbxCardCount.Items7")});
            this.cmbxCardCount.Name = "cmbxCardCount";
            this.cmbxCardCount.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxEnableValidation
            // 
            resources.ApplyResources(this.chkbxEnableValidation, "chkbxEnableValidation");
            this.chkbxEnableValidation.Name = "chkbxEnableValidation";
            this.chkbxEnableValidation.Tag = "chkbxEnableValidation";
            this.chkbxEnableValidation.UseVisualStyleBackColor = true;
            this.chkbxEnableValidation.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // ValidationSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "ValidationSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbxCardCount;
        private Controls.TextBoxNumeric2 txtbxValidationMaxPerTransaction;
        private System.Windows.Forms.CheckBox chkbxEnableValidation;
    }
}
