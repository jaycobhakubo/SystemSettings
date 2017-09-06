namespace GTI.Modules.SystemSettings.UI
{
    partial class POSKioskSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSKioskSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.lblTicketPrinterName = new System.Windows.Forms.Label();
            this.chkbxAutomaticApplyCouponToSales = new System.Windows.Forms.CheckBox();
            this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard = new System.Windows.Forms.CheckBox();
            this.chkbxIncludeCouponsButton = new System.Windows.Forms.CheckBox();
            this.chkbxAllowBarcodedPaperSold = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboKioskBillAcceptorComPort = new System.Windows.Forms.ComboBox();
            this.grpBxKioskSales = new System.Windows.Forms.GroupBox();
            this.chkbxAllowCreditDebitOnKiosk = new System.Windows.Forms.CheckBox();
            this.chkbxIncludeUseLastPurchaseButton = new System.Windows.Forms.CheckBox();
            this.chkbxUseSimplePaymentForAdvancedKiosk = new System.Windows.Forms.CheckBox();
            this.m_grpTimeouts = new System.Windows.Forms.GroupBox();
            this.m_lblTimeout = new System.Windows.Forms.Label();
            this.m_nudMessageTimeout = new System.Windows.Forms.NumericUpDown();
            this.m_nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.m_messageTimeout = new System.Windows.Forms.Label();
            this.m_nudShortTimeout = new System.Windows.Forms.NumericUpDown();
            this.m_lblShortInactivityTimeout = new System.Windows.Forms.Label();
            this.m_closedText = new System.Windows.Forms.TextBox();
            this.m_IdleText = new System.Windows.Forms.TextBox();
            this.m_lblClosedText = new System.Windows.Forms.Label();
            this.m_lblAttractText = new System.Windows.Forms.Label();
            this.txtbxKioskTicketPrinterName = new System.Windows.Forms.TextBox();
            this.grpBxKioskSales.SuspendLayout();
            this.m_grpTimeouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMessageTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudShortTimeout)).BeginInit();
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
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
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
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.chkbxAutomaticApplyCouponToSales.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxAllowUseOfSimpleKioskWithoutPlayerCard
            // 
            resources.ApplyResources(this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard, "chkbxAllowUseOfSimpleKioskWithoutPlayerCard");
            this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard.Name = "chkbxAllowUseOfSimpleKioskWithoutPlayerCard";
            this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard.UseVisualStyleBackColor = true;
            this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxIncludeCouponsButton
            // 
            resources.ApplyResources(this.chkbxIncludeCouponsButton, "chkbxIncludeCouponsButton");
            this.chkbxIncludeCouponsButton.Name = "chkbxIncludeCouponsButton";
            this.chkbxIncludeCouponsButton.UseVisualStyleBackColor = true;
            this.chkbxIncludeCouponsButton.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxAllowBarcodedPaperSold
            // 
            resources.ApplyResources(this.chkbxAllowBarcodedPaperSold, "chkbxAllowBarcodedPaperSold");
            this.chkbxAllowBarcodedPaperSold.Name = "chkbxAllowBarcodedPaperSold";
            this.chkbxAllowBarcodedPaperSold.UseVisualStyleBackColor = true;
            this.chkbxAllowBarcodedPaperSold.CheckedChanged += new System.EventHandler(this.OnModified);
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
            this.cboKioskBillAcceptorComPort.Name = "cboKioskBillAcceptorComPort";
            this.cboKioskBillAcceptorComPort.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // grpBxKioskSales
            // 
            this.grpBxKioskSales.Controls.Add(this.chkbxAllowCreditDebitOnKiosk);
            this.grpBxKioskSales.Controls.Add(this.chkbxIncludeUseLastPurchaseButton);
            this.grpBxKioskSales.Controls.Add(this.chkbxUseSimplePaymentForAdvancedKiosk);
            this.grpBxKioskSales.Controls.Add(this.m_grpTimeouts);
            this.grpBxKioskSales.Controls.Add(this.m_closedText);
            this.grpBxKioskSales.Controls.Add(this.m_IdleText);
            this.grpBxKioskSales.Controls.Add(this.m_lblClosedText);
            this.grpBxKioskSales.Controls.Add(this.m_lblAttractText);
            this.grpBxKioskSales.Controls.Add(this.txtbxKioskTicketPrinterName);
            this.grpBxKioskSales.Controls.Add(this.cboKioskBillAcceptorComPort);
            this.grpBxKioskSales.Controls.Add(this.label6);
            this.grpBxKioskSales.Controls.Add(this.chkbxAllowBarcodedPaperSold);
            this.grpBxKioskSales.Controls.Add(this.chkbxIncludeCouponsButton);
            this.grpBxKioskSales.Controls.Add(this.chkbxAllowUseOfSimpleKioskWithoutPlayerCard);
            this.grpBxKioskSales.Controls.Add(this.chkbxAutomaticApplyCouponToSales);
            this.grpBxKioskSales.Controls.Add(this.lblTicketPrinterName);
            resources.ApplyResources(this.grpBxKioskSales, "grpBxKioskSales");
            this.grpBxKioskSales.Name = "grpBxKioskSales";
            this.grpBxKioskSales.TabStop = false;
            // 
            // chkbxAllowCreditDebitOnKiosk
            // 
            resources.ApplyResources(this.chkbxAllowCreditDebitOnKiosk, "chkbxAllowCreditDebitOnKiosk");
            this.chkbxAllowCreditDebitOnKiosk.Name = "chkbxAllowCreditDebitOnKiosk";
            this.chkbxAllowCreditDebitOnKiosk.UseVisualStyleBackColor = true;
            this.chkbxAllowCreditDebitOnKiosk.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxIncludeUseLastPurchaseButton
            // 
            resources.ApplyResources(this.chkbxIncludeUseLastPurchaseButton, "chkbxIncludeUseLastPurchaseButton");
            this.chkbxIncludeUseLastPurchaseButton.Name = "chkbxIncludeUseLastPurchaseButton";
            this.chkbxIncludeUseLastPurchaseButton.UseVisualStyleBackColor = true;
            this.chkbxIncludeUseLastPurchaseButton.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxUseSimplePaymentForAdvancedKiosk
            // 
            resources.ApplyResources(this.chkbxUseSimplePaymentForAdvancedKiosk, "chkbxUseSimplePaymentForAdvancedKiosk");
            this.chkbxUseSimplePaymentForAdvancedKiosk.Name = "chkbxUseSimplePaymentForAdvancedKiosk";
            this.chkbxUseSimplePaymentForAdvancedKiosk.UseVisualStyleBackColor = true;
            this.chkbxUseSimplePaymentForAdvancedKiosk.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // m_grpTimeouts
            // 
            this.m_grpTimeouts.Controls.Add(this.m_lblTimeout);
            this.m_grpTimeouts.Controls.Add(this.m_nudMessageTimeout);
            this.m_grpTimeouts.Controls.Add(this.m_nudTimeout);
            this.m_grpTimeouts.Controls.Add(this.m_messageTimeout);
            this.m_grpTimeouts.Controls.Add(this.m_nudShortTimeout);
            this.m_grpTimeouts.Controls.Add(this.m_lblShortInactivityTimeout);
            resources.ApplyResources(this.m_grpTimeouts, "m_grpTimeouts");
            this.m_grpTimeouts.Name = "m_grpTimeouts";
            this.m_grpTimeouts.TabStop = false;
            // 
            // m_lblTimeout
            // 
            resources.ApplyResources(this.m_lblTimeout, "m_lblTimeout");
            this.m_lblTimeout.Name = "m_lblTimeout";
            // 
            // m_nudMessageTimeout
            // 
            this.m_nudMessageTimeout.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.m_nudMessageTimeout, "m_nudMessageTimeout");
            this.m_nudMessageTimeout.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.m_nudMessageTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudMessageTimeout.Name = "m_nudMessageTimeout";
            this.m_nudMessageTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nudMessageTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // m_nudTimeout
            // 
            this.m_nudTimeout.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.m_nudTimeout, "m_nudTimeout");
            this.m_nudTimeout.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.m_nudTimeout.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m_nudTimeout.Name = "m_nudTimeout";
            this.m_nudTimeout.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.m_nudTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // m_messageTimeout
            // 
            resources.ApplyResources(this.m_messageTimeout, "m_messageTimeout");
            this.m_messageTimeout.Name = "m_messageTimeout";
            // 
            // m_nudShortTimeout
            // 
            this.m_nudShortTimeout.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.m_nudShortTimeout, "m_nudShortTimeout");
            this.m_nudShortTimeout.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.m_nudShortTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudShortTimeout.Name = "m_nudShortTimeout";
            this.m_nudShortTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudShortTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // m_lblShortInactivityTimeout
            // 
            resources.ApplyResources(this.m_lblShortInactivityTimeout, "m_lblShortInactivityTimeout");
            this.m_lblShortInactivityTimeout.Name = "m_lblShortInactivityTimeout";
            // 
            // m_closedText
            // 
            resources.ApplyResources(this.m_closedText, "m_closedText");
            this.m_closedText.Name = "m_closedText";
            this.m_closedText.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // m_IdleText
            // 
            resources.ApplyResources(this.m_IdleText, "m_IdleText");
            this.m_IdleText.Name = "m_IdleText";
            this.m_IdleText.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // m_lblClosedText
            // 
            resources.ApplyResources(this.m_lblClosedText, "m_lblClosedText");
            this.m_lblClosedText.Name = "m_lblClosedText";
            // 
            // m_lblAttractText
            // 
            resources.ApplyResources(this.m_lblAttractText, "m_lblAttractText");
            this.m_lblAttractText.Name = "m_lblAttractText";
            // 
            // txtbxKioskTicketPrinterName
            // 
            resources.ApplyResources(this.txtbxKioskTicketPrinterName, "txtbxKioskTicketPrinterName");
            this.txtbxKioskTicketPrinterName.Name = "txtbxKioskTicketPrinterName";
            this.txtbxKioskTicketPrinterName.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // POSKioskSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpBxKioskSales);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            resources.ApplyResources(this, "$this");
            this.Name = "POSKioskSettings";
            this.grpBxKioskSales.ResumeLayout(false);
            this.grpBxKioskSales.PerformLayout();
            this.m_grpTimeouts.ResumeLayout(false);
            this.m_grpTimeouts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudMessageTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudShortTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.Label lblTicketPrinterName;
        private System.Windows.Forms.CheckBox chkbxAutomaticApplyCouponToSales;
        private System.Windows.Forms.CheckBox chkbxAllowUseOfSimpleKioskWithoutPlayerCard;
        private System.Windows.Forms.CheckBox chkbxIncludeCouponsButton;
        private System.Windows.Forms.CheckBox chkbxAllowBarcodedPaperSold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboKioskBillAcceptorComPort;
        private System.Windows.Forms.GroupBox grpBxKioskSales;
        private System.Windows.Forms.TextBox txtbxKioskTicketPrinterName;
        private System.Windows.Forms.GroupBox m_grpTimeouts;
        private System.Windows.Forms.Label m_lblTimeout;
        private System.Windows.Forms.NumericUpDown m_nudMessageTimeout;
        private System.Windows.Forms.NumericUpDown m_nudTimeout;
        private System.Windows.Forms.Label m_messageTimeout;
        private System.Windows.Forms.NumericUpDown m_nudShortTimeout;
        private System.Windows.Forms.Label m_lblShortInactivityTimeout;
        private System.Windows.Forms.TextBox m_closedText;
        private System.Windows.Forms.TextBox m_IdleText;
        private System.Windows.Forms.Label m_lblClosedText;
        private System.Windows.Forms.Label m_lblAttractText;
        private System.Windows.Forms.CheckBox chkbxUseSimplePaymentForAdvancedKiosk;
        private System.Windows.Forms.CheckBox chkbxIncludeUseLastPurchaseButton;
        private System.Windows.Forms.CheckBox chkbxAllowCreditDebitOnKiosk;
    }
}
