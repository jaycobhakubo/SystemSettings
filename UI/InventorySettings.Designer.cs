namespace GTI.Modules.SystemSettings.UI
{
    partial class InventorySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventorySettings));
            this.m_rdoTrackBySerial = new System.Windows.Forms.RadioButton();
            this.m_rdoTrackByProduct = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkCheckForDuplicates = new System.Windows.Forms.CheckBox();
            this.chkPrintReconcileReceipt = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_rdoAuditNumbers = new System.Windows.Forms.RadioButton();
            this.m_rdoQuantity = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rdoReduceAtRegisterFalse = new System.Windows.Forms.RadioButton();
            this.m_rdoReduceAtRegisterTrue = new System.Windows.Forms.RadioButton();
            this.m_chkAutoRetire = new System.Windows.Forms.CheckBox();
            this.m_chkAllowIssuesToExceed = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_rdoTrackBySerial
            // 
            resources.ApplyResources(this.m_rdoTrackBySerial, "m_rdoTrackBySerial");
            this.m_rdoTrackBySerial.Name = "m_rdoTrackBySerial";
            this.m_rdoTrackBySerial.TabStop = true;
            this.m_rdoTrackBySerial.UseVisualStyleBackColor = true;
            this.m_rdoTrackBySerial.Click += new System.EventHandler(this.OnModified);
            // 
            // m_rdoTrackByProduct
            // 
            resources.ApplyResources(this.m_rdoTrackByProduct, "m_rdoTrackByProduct");
            this.m_rdoTrackByProduct.Name = "m_rdoTrackByProduct";
            this.m_rdoTrackByProduct.TabStop = true;
            this.m_rdoTrackByProduct.UseVisualStyleBackColor = true;
            this.m_rdoTrackByProduct.Click += new System.EventHandler(this.OnModified);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkCheckForDuplicates);
            this.groupBox1.Controls.Add(this.chkPrintReconcileReceipt);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.m_chkAutoRetire);
            this.groupBox1.Controls.Add(this.m_chkAllowIssuesToExceed);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_chkCheckForDuplicates
            // 
            resources.ApplyResources(this.m_chkCheckForDuplicates, "m_chkCheckForDuplicates");
            this.m_chkCheckForDuplicates.Name = "m_chkCheckForDuplicates";
            this.m_chkCheckForDuplicates.UseVisualStyleBackColor = true;
            this.m_chkCheckForDuplicates.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPrintReconcileReceipt
            // 
            resources.ApplyResources(this.chkPrintReconcileReceipt, "chkPrintReconcileReceipt");
            this.chkPrintReconcileReceipt.Name = "chkPrintReconcileReceipt";
            this.chkPrintReconcileReceipt.UseVisualStyleBackColor = true;
            this.chkPrintReconcileReceipt.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_rdoTrackByProduct);
            this.groupBox4.Controls.Add(this.m_rdoTrackBySerial);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_rdoAuditNumbers);
            this.groupBox3.Controls.Add(this.m_rdoQuantity);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // m_rdoAuditNumbers
            // 
            resources.ApplyResources(this.m_rdoAuditNumbers, "m_rdoAuditNumbers");
            this.m_rdoAuditNumbers.Name = "m_rdoAuditNumbers";
            this.m_rdoAuditNumbers.TabStop = true;
            this.m_rdoAuditNumbers.UseVisualStyleBackColor = true;
            this.m_rdoAuditNumbers.Click += new System.EventHandler(this.OnModified);
            // 
            // m_rdoQuantity
            // 
            resources.ApplyResources(this.m_rdoQuantity, "m_rdoQuantity");
            this.m_rdoQuantity.Name = "m_rdoQuantity";
            this.m_rdoQuantity.TabStop = true;
            this.m_rdoQuantity.UseVisualStyleBackColor = true;
            this.m_rdoQuantity.Click += new System.EventHandler(this.OnModified);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rdoReduceAtRegisterFalse);
            this.groupBox2.Controls.Add(this.m_rdoReduceAtRegisterTrue);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_rdoReduceAtRegisterFalse
            // 
            resources.ApplyResources(this.m_rdoReduceAtRegisterFalse, "m_rdoReduceAtRegisterFalse");
            this.m_rdoReduceAtRegisterFalse.Name = "m_rdoReduceAtRegisterFalse";
            this.m_rdoReduceAtRegisterFalse.TabStop = true;
            this.m_rdoReduceAtRegisterFalse.UseVisualStyleBackColor = true;
            this.m_rdoReduceAtRegisterFalse.Click += new System.EventHandler(this.OnModified);
            // 
            // m_rdoReduceAtRegisterTrue
            // 
            resources.ApplyResources(this.m_rdoReduceAtRegisterTrue, "m_rdoReduceAtRegisterTrue");
            this.m_rdoReduceAtRegisterTrue.Name = "m_rdoReduceAtRegisterTrue";
            this.m_rdoReduceAtRegisterTrue.TabStop = true;
            this.m_rdoReduceAtRegisterTrue.UseVisualStyleBackColor = true;
            this.m_rdoReduceAtRegisterTrue.Click += new System.EventHandler(this.OnModified);
            // 
            // m_chkAutoRetire
            // 
            resources.ApplyResources(this.m_chkAutoRetire, "m_chkAutoRetire");
            this.m_chkAutoRetire.Name = "m_chkAutoRetire";
            this.m_chkAutoRetire.UseVisualStyleBackColor = true;
            this.m_chkAutoRetire.Click += new System.EventHandler(this.OnModified);
            // 
            // m_chkAllowIssuesToExceed
            // 
            resources.ApplyResources(this.m_chkAllowIssuesToExceed, "m_chkAllowIssuesToExceed");
            this.m_chkAllowIssuesToExceed.Name = "m_chkAllowIssuesToExceed";
            this.m_chkAllowIssuesToExceed.UseVisualStyleBackColor = true;
            this.m_chkAllowIssuesToExceed.Click += new System.EventHandler(this.OnModified);
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
            // InventorySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventorySettings";
            resources.ApplyResources(this, "$this");
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton m_rdoTrackBySerial;
        private System.Windows.Forms.RadioButton m_rdoTrackByProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private GTI.Controls.ImageButton btnReset;
        private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.CheckBox m_chkAllowIssuesToExceed;
        private System.Windows.Forms.CheckBox m_chkAutoRetire;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton m_rdoReduceAtRegisterFalse;
        private System.Windows.Forms.RadioButton m_rdoReduceAtRegisterTrue;
        private System.Windows.Forms.RadioButton m_rdoQuantity;
        private System.Windows.Forms.RadioButton m_rdoAuditNumbers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPrintReconcileReceipt;
        private System.Windows.Forms.CheckBox m_chkCheckForDuplicates;
    }
}
