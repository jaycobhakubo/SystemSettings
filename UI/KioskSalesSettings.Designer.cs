namespace GTI.Modules.SystemSettings.UI
{
    partial class KioskSalesSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KioskSalesSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.lblTicketPrinterName = new System.Windows.Forms.Label();
            this.chkbxAutomaticApplyCouponToSales = new System.Windows.Forms.CheckBox();
            this.chkbxAllowUseOfSimpleKiosk = new System.Windows.Forms.CheckBox();
            this.chkbxIncludeCouponsButton = new System.Windows.Forms.CheckBox();
            this.chkbxAutomaticBarcodedPaperSold = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboKioskBillAcceptorComPort = new System.Windows.Forms.ComboBox();
            this.grpBxKioskSales = new System.Windows.Forms.GroupBox();
            this.txtbxKioskTicketPrinterName = new System.Windows.Forms.TextBox();
            this.grpBxKioskSales.SuspendLayout();
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
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
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
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblTicketPrinterName
            // 
            resources.ApplyResources(this.lblTicketPrinterName, "lblTicketPrinterName");
            this.lblTicketPrinterName.Name = "lblTicketPrinterName";
            // 
            // chkbxAutomaticApplyCouponToSales
            // 
            resources.ApplyResources(this.chkbxAutomaticApplyCouponToSales, "chkbxAutomaticApplyCouponToSales");
            this.chkbxAutomaticApplyCouponToSales.Name = "chkbxAutomaticApplyCouponToSales";
            this.chkbxAutomaticApplyCouponToSales.UseVisualStyleBackColor = true;
            // 
            // chkbxAllowUseOfSimpleKiosk
            // 
            resources.ApplyResources(this.chkbxAllowUseOfSimpleKiosk, "chkbxAllowUseOfSimpleKiosk");
            this.chkbxAllowUseOfSimpleKiosk.Name = "chkbxAllowUseOfSimpleKiosk";
            this.chkbxAllowUseOfSimpleKiosk.UseVisualStyleBackColor = true;
            // 
            // chkbxIncludeCouponsButton
            // 
            resources.ApplyResources(this.chkbxIncludeCouponsButton, "chkbxIncludeCouponsButton");
            this.chkbxIncludeCouponsButton.Name = "chkbxIncludeCouponsButton";
            this.chkbxIncludeCouponsButton.UseVisualStyleBackColor = true;
            // 
            // chkbxAutomaticBarcodedPaperSold
            // 
            resources.ApplyResources(this.chkbxAutomaticBarcodedPaperSold, "chkbxAutomaticBarcodedPaperSold");
            this.chkbxAutomaticBarcodedPaperSold.Name = "chkbxAutomaticBarcodedPaperSold";
            this.chkbxAutomaticBarcodedPaperSold.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cboKioskBillAcceptorComPort
            // 
            this.cboKioskBillAcceptorComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboKioskBillAcceptorComPort, "cboKioskBillAcceptorComPort");
            this.cboKioskBillAcceptorComPort.FormattingEnabled = true;
            this.cboKioskBillAcceptorComPort.Items.AddRange(new object[] {
            resources.GetString("cboKioskBillAcceptorComPort.Items"),
            resources.GetString("cboKioskBillAcceptorComPort.Items1"),
            resources.GetString("cboKioskBillAcceptorComPort.Items2"),
            resources.GetString("cboKioskBillAcceptorComPort.Items3")});
            this.cboKioskBillAcceptorComPort.Name = "cboKioskBillAcceptorComPort";
            // 
            // grpBxKioskSales
            // 
            this.grpBxKioskSales.Controls.Add(this.txtbxKioskTicketPrinterName);
            this.grpBxKioskSales.Controls.Add(this.cboKioskBillAcceptorComPort);
            this.grpBxKioskSales.Controls.Add(this.label6);
            this.grpBxKioskSales.Controls.Add(this.chkbxAutomaticBarcodedPaperSold);
            this.grpBxKioskSales.Controls.Add(this.chkbxIncludeCouponsButton);
            this.grpBxKioskSales.Controls.Add(this.chkbxAllowUseOfSimpleKiosk);
            this.grpBxKioskSales.Controls.Add(this.chkbxAutomaticApplyCouponToSales);
            this.grpBxKioskSales.Controls.Add(this.lblTicketPrinterName);
            resources.ApplyResources(this.grpBxKioskSales, "grpBxKioskSales");
            this.grpBxKioskSales.Name = "grpBxKioskSales";
            this.grpBxKioskSales.TabStop = false;
            // 
            // txtbxKioskTicketPrinterName
            // 
            resources.ApplyResources(this.txtbxKioskTicketPrinterName, "txtbxKioskTicketPrinterName");
            this.txtbxKioskTicketPrinterName.Name = "txtbxKioskTicketPrinterName";
            // 
            // KioskSalesSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpBxKioskSales);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            resources.ApplyResources(this, "$this");
            this.Name = "KioskSalesSettings";
            this.grpBxKioskSales.ResumeLayout(false);
            this.grpBxKioskSales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.Label lblTicketPrinterName;
        private System.Windows.Forms.CheckBox chkbxAutomaticApplyCouponToSales;
        private System.Windows.Forms.CheckBox chkbxAllowUseOfSimpleKiosk;
        private System.Windows.Forms.CheckBox chkbxIncludeCouponsButton;
        private System.Windows.Forms.CheckBox chkbxAutomaticBarcodedPaperSold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboKioskBillAcceptorComPort;
        private System.Windows.Forms.GroupBox grpBxKioskSales;
        private System.Windows.Forms.TextBox txtbxKioskTicketPrinterName;
    }
}
