namespace GTI.Modules.SystemSettings.UI
{
    partial class PointOfSalePrinterSettings
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
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfSalePrinterSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.grpPrinters = new System.Windows.Forms.GroupBox();
            this.txtGlobalPrinter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReceiptPrinter = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            this.grpPrinters.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
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
            // grpPrinters
            // 
            this.grpPrinters.Controls.Add(this.txtGlobalPrinter);
            this.grpPrinters.Controls.Add(this.label7);
            this.grpPrinters.Controls.Add(this.txtReceiptPrinter);
            this.grpPrinters.Controls.Add(label4);
            resources.ApplyResources(this.grpPrinters, "grpPrinters");
            this.grpPrinters.Name = "grpPrinters";
            this.grpPrinters.TabStop = false;
            // 
            // txtGlobalPrinter
            // 
            this.txtGlobalPrinter.AcceptsReturn = true;
            resources.ApplyResources(this.txtGlobalPrinter, "txtGlobalPrinter");
            this.txtGlobalPrinter.Name = "txtGlobalPrinter";
            this.txtGlobalPrinter.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtReceiptPrinter
            // 
            resources.ApplyResources(this.txtReceiptPrinter, "txtReceiptPrinter");
            this.txtReceiptPrinter.Name = "txtReceiptPrinter";
            this.txtReceiptPrinter.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // PointOfSalePrinterSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpPrinters);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "PointOfSalePrinterSettings";
            this.grpPrinters.ResumeLayout(false);
            this.grpPrinters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox grpPrinters;
        private System.Windows.Forms.TextBox txtGlobalPrinter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReceiptPrinter;
    }
}
