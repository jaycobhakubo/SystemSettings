namespace GTI.Modules.SystemSettings.UI
{
    partial class TenderSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenderSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.paymentSettings = new System.Windows.Forms.GroupBox();
            this.panelFlexTendering = new System.Windows.Forms.Panel();
            this.clbAllowedTenders = new System.Windows.Forms.CheckedListBox();
            this.printDualReceipts = new System.Windows.Forms.CheckBox();
            this.splitTendering = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUse00 = new System.Windows.Forms.CheckBox();
            this.flexTendering = new System.Windows.Forms.CheckBox();
            this.clbActiveTenders = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new GTI.Controls.ImageButton();
            this.paymentSettings.SuspendLayout();
            this.panelFlexTendering.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
            this.btnReset.Name = "btnReset";
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // paymentSettings
            // 
            this.paymentSettings.Controls.Add(this.panelFlexTendering);
            this.paymentSettings.Controls.Add(this.chkUse00);
            this.paymentSettings.Controls.Add(this.flexTendering);
            this.paymentSettings.Controls.Add(this.clbActiveTenders);
            this.paymentSettings.Controls.Add(this.label2);
            resources.ApplyResources(this.paymentSettings, "paymentSettings");
            this.paymentSettings.Name = "paymentSettings";
            this.paymentSettings.TabStop = false;
            // 
            // panelFlexTendering
            // 
            this.panelFlexTendering.Controls.Add(this.clbAllowedTenders);
            this.panelFlexTendering.Controls.Add(this.printDualReceipts);
            this.panelFlexTendering.Controls.Add(this.splitTendering);
            this.panelFlexTendering.Controls.Add(this.label3);
            resources.ApplyResources(this.panelFlexTendering, "panelFlexTendering");
            this.panelFlexTendering.Name = "panelFlexTendering";
            // 
            // clbAllowedTenders
            // 
            this.clbAllowedTenders.FormattingEnabled = true;
            resources.ApplyResources(this.clbAllowedTenders, "clbAllowedTenders");
            this.clbAllowedTenders.Name = "clbAllowedTenders";
            this.clbAllowedTenders.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnModified);
            // 
            // printDualReceipts
            // 
            resources.ApplyResources(this.printDualReceipts, "printDualReceipts");
            this.printDualReceipts.Name = "printDualReceipts";
            this.printDualReceipts.UseVisualStyleBackColor = true;
            this.printDualReceipts.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // splitTendering
            // 
            resources.ApplyResources(this.splitTendering, "splitTendering");
            this.splitTendering.Name = "splitTendering";
            this.splitTendering.UseVisualStyleBackColor = true;
            this.splitTendering.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // chkUse00
            // 
            resources.ApplyResources(this.chkUse00, "chkUse00");
            this.chkUse00.Name = "chkUse00";
            this.chkUse00.UseVisualStyleBackColor = true;
            this.chkUse00.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // flexTendering
            // 
            resources.ApplyResources(this.flexTendering, "flexTendering");
            this.flexTendering.Name = "flexTendering";
            this.flexTendering.UseVisualStyleBackColor = true;
            this.flexTendering.CheckedChanged += new System.EventHandler(this.OnFlexTenderingChanged);
            // 
            // clbActiveTenders
            // 
            this.clbActiveTenders.FormattingEnabled = true;
            resources.ApplyResources(this.clbActiveTenders, "clbActiveTenders");
            this.clbActiveTenders.Name = "clbActiveTenders";
            this.clbActiveTenders.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnModified);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TenderSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.paymentSettings);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "TenderSettings";
            this.paymentSettings.ResumeLayout(false);
            this.paymentSettings.PerformLayout();
            this.panelFlexTendering.ResumeLayout(false);
            this.panelFlexTendering.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox paymentSettings;
        private System.Windows.Forms.CheckBox splitTendering;
        private System.Windows.Forms.CheckBox flexTendering;
        private System.Windows.Forms.CheckBox printDualReceipts;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.CheckedListBox clbAllowedTenders;
        private System.Windows.Forms.CheckedListBox clbActiveTenders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUse00;
        private System.Windows.Forms.Panel panelFlexTendering;
    }
}
