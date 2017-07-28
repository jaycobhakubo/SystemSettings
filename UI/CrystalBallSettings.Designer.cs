namespace GTI.Modules.SystemSettings.UI
{
    partial class CrystalBallSettings
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
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrystalBallSettings));
            System.Windows.Forms.Label label4;
            this.grpCBB = new System.Windows.Forms.GroupBox();
            this.cboCbbScannerType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableCBBFavorites = new System.Windows.Forms.CheckBox();
            this.cboPrintCBBCardsToPlayitSheet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPlayItSheet = new System.Windows.Forms.ComboBox();
            this.txtCBBDefFile = new System.Windows.Forms.TextBox();
            this.numCBBScannerPort = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.grpCBB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCBBScannerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // grpCBB
            // 
            this.grpCBB.Controls.Add(this.cboCbbScannerType);
            this.grpCBB.Controls.Add(this.label1);
            this.grpCBB.Controls.Add(this.chkEnableCBBFavorites);
            this.grpCBB.Controls.Add(this.cboPrintCBBCardsToPlayitSheet);
            this.grpCBB.Controls.Add(this.label6);
            this.grpCBB.Controls.Add(this.label5);
            this.grpCBB.Controls.Add(this.cboPlayItSheet);
            this.grpCBB.Controls.Add(this.txtCBBDefFile);
            this.grpCBB.Controls.Add(this.numCBBScannerPort);
            this.grpCBB.Controls.Add(label3);
            this.grpCBB.Controls.Add(label4);
            resources.ApplyResources(this.grpCBB, "grpCBB");
            this.grpCBB.Name = "grpCBB";
            this.grpCBB.TabStop = false;
            // 
            // cboCbbScannerType
            // 
            this.cboCbbScannerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboCbbScannerType, "cboCbbScannerType");
            this.cboCbbScannerType.FormattingEnabled = true;
            this.cboCbbScannerType.Items.AddRange(new object[] {
            resources.GetString("cboCbbScannerType.Items"),
            resources.GetString("cboCbbScannerType.Items1"),
            resources.GetString("cboCbbScannerType.Items2")});
            this.cboCbbScannerType.Name = "cboCbbScannerType";
            this.cboCbbScannerType.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkEnableCBBFavorites
            // 
            resources.ApplyResources(this.chkEnableCBBFavorites, "chkEnableCBBFavorites");
            this.chkEnableCBBFavorites.Name = "chkEnableCBBFavorites";
            this.chkEnableCBBFavorites.UseVisualStyleBackColor = true;
            this.chkEnableCBBFavorites.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cboPrintCBBCardsToPlayitSheet
            // 
            this.cboPrintCBBCardsToPlayitSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboPrintCBBCardsToPlayitSheet, "cboPrintCBBCardsToPlayitSheet");
            this.cboPrintCBBCardsToPlayitSheet.FormattingEnabled = true;
            this.cboPrintCBBCardsToPlayitSheet.Items.AddRange(new object[] {
            resources.GetString("cboPrintCBBCardsToPlayitSheet.Items"),
            resources.GetString("cboPrintCBBCardsToPlayitSheet.Items1"),
            resources.GetString("cboPrintCBBCardsToPlayitSheet.Items2"),
            resources.GetString("cboPrintCBBCardsToPlayitSheet.Items3")});
            this.cboPrintCBBCardsToPlayitSheet.Name = "cboPrintCBBCardsToPlayitSheet";
            this.cboPrintCBBCardsToPlayitSheet.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cboPlayItSheet
            // 
            this.cboPlayItSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboPlayItSheet, "cboPlayItSheet");
            this.cboPlayItSheet.FormattingEnabled = true;
            this.cboPlayItSheet.Items.AddRange(new object[] {
            resources.GetString("cboPlayItSheet.Items"),
            resources.GetString("cboPlayItSheet.Items1"),
            resources.GetString("cboPlayItSheet.Items2"),
            resources.GetString("cboPlayItSheet.Items3"),
            resources.GetString("cboPlayItSheet.Items4")});
            this.cboPlayItSheet.Name = "cboPlayItSheet";
            this.cboPlayItSheet.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // txtCBBDefFile
            // 
            resources.ApplyResources(this.txtCBBDefFile, "txtCBBDefFile");
            this.txtCBBDefFile.Name = "txtCBBDefFile";
            this.txtCBBDefFile.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // numCBBScannerPort
            // 
            resources.ApplyResources(this.numCBBScannerPort, "numCBBScannerPort");
            this.numCBBScannerPort.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numCBBScannerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCBBScannerPort.Name = "numCBBScannerPort";
            this.numCBBScannerPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCBBScannerPort.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
            this.btnReset.Name = "btnReset";
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CrystalBallSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpCBB);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CrystalBallSettings";
            this.grpCBB.ResumeLayout(false);
            this.grpCBB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCBBScannerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox grpCBB;
        private System.Windows.Forms.ComboBox cboPrintCBBCardsToPlayitSheet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPlayItSheet;
        private System.Windows.Forms.TextBox txtCBBDefFile;
        private System.Windows.Forms.NumericUpDown numCBBScannerPort;
        private System.Windows.Forms.CheckBox chkEnableCBBFavorites;
        private System.Windows.Forms.ComboBox cboCbbScannerType;
        private System.Windows.Forms.Label label1;
    }
}
