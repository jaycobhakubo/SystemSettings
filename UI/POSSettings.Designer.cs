namespace GTI.Modules.SystemSettings.UI
{
	partial class POSSettings
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.Label salesTaxLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkForceVoidAuth = new System.Windows.Forms.CheckBox();
            this.chkShowFree = new System.Windows.Forms.CheckBox();
            this.chkScanningStartsNewSale = new System.Windows.Forms.CheckBox();
            this.chkShowQuantityOnButtons = new System.Windows.Forms.CheckBox();
            this.chkTwoMenuPagesPerPOSPage = new System.Windows.Forms.CheckBox();
            this.chkWidescreen = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbResellAuditedItem = new System.Windows.Forms.ComboBox();
            this.chkPrintRegisterClosingOnCloseBank = new System.Windows.Forms.CheckBox();
            this.chkEnableRegisterClosingReport = new System.Windows.Forms.CheckBox();
            this.chkPromptForPlayerCreation = new System.Windows.Forms.CheckBox();
            this.chkPrintCloseBankReceipt = new System.Windows.Forms.CheckBox();
            this.chkAllowPrintQuantitySales = new System.Windows.Forms.CheckBox();
            this.chkUseToggleButtonForUnitSelection = new System.Windows.Forms.CheckBox();
            this.m_playWithPaperEnabled = new System.Windows.Forms.Label();
            this.chkRemoveDiscountsFromRepeatSales = new System.Windows.Forms.CheckBox();
            this.chkRemovePaperFromRepeatSale = new System.Windows.Forms.CheckBox();
            this.chkRemoveCouponsPackageOnRepeatSale = new System.Windows.Forms.CheckBox();
            this.chkReturnToPageOne = new System.Windows.Forms.CheckBox();
            this.chkShowPaperUsageAtLogin = new System.Windows.Forms.CheckBox();
            this.chkEnablePaperUsage = new System.Windows.Forms.CheckBox();
            this.chkbxEnableValidation = new System.Windows.Forms.CheckBox();
            this.chkProductCardCount = new System.Windows.Forms.CheckBox();
            this.txtCashDrawerEjectCode = new System.Windows.Forms.TextBox();
            this.numSalesTax = new System.Windows.Forms.NumericUpDown();
            this.chkEnableActiveSession = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableRegisterSalesReport = new System.Windows.Forms.CheckBox();
            this.lstRegisterReceipt = new System.Windows.Forms.ComboBox();
            this.chkUseExchangeRateOnSale = new System.Windows.Forms.CheckBox();
            this.minSaleLabel = new System.Windows.Forms.Label();
            this.numCBBQuantitySales = new System.Windows.Forms.NumericUpDown();
            this.m_lblMaximumQuantitySales = new System.Windows.Forms.Label();
            this.cboMinumSales = new System.Windows.Forms.ComboBox();
            this.lstTenderModes = new System.Windows.Forms.ComboBox();
            this.chkAllowQuantitySales = new System.Windows.Forms.CheckBox();
            this.tenderModeLabel = new System.Windows.Forms.Label();
            this.chkSellFixedUnits = new System.Windows.Forms.CheckBox();
            this.chkAllowNoSale = new System.Windows.Forms.CheckBox();
            this.chkAllowReturns = new System.Windows.Forms.CheckBox();
            this.chkbxAutoIssue = new System.Windows.Forms.CheckBox();
            this.chkLongDescriptions = new System.Windows.Forms.CheckBox();
            this.btnSave = new GTI.Controls.ImageButton();
            salesTaxLabel = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBBQuantitySales)).BeginInit();
            this.SuspendLayout();
            // 
            // salesTaxLabel
            // 
            resources.ApplyResources(salesTaxLabel, "salesTaxLabel");
            salesTaxLabel.Name = "salesTaxLabel";
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
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.panel1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.chkForceVoidAuth);
            this.panel1.Controls.Add(this.chkShowFree);
            this.panel1.Controls.Add(this.chkScanningStartsNewSale);
            this.panel1.Controls.Add(this.chkShowQuantityOnButtons);
            this.panel1.Controls.Add(this.chkTwoMenuPagesPerPOSPage);
            this.panel1.Controls.Add(this.chkWidescreen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbResellAuditedItem);
            this.panel1.Controls.Add(this.chkPrintRegisterClosingOnCloseBank);
            this.panel1.Controls.Add(this.chkEnableRegisterClosingReport);
            this.panel1.Controls.Add(this.chkPromptForPlayerCreation);
            this.panel1.Controls.Add(this.chkPrintCloseBankReceipt);
            this.panel1.Controls.Add(this.chkAllowPrintQuantitySales);
            this.panel1.Controls.Add(this.chkUseToggleButtonForUnitSelection);
            this.panel1.Controls.Add(this.m_playWithPaperEnabled);
            this.panel1.Controls.Add(this.chkRemoveDiscountsFromRepeatSales);
            this.panel1.Controls.Add(this.chkRemovePaperFromRepeatSale);
            this.panel1.Controls.Add(this.chkRemoveCouponsPackageOnRepeatSale);
            this.panel1.Controls.Add(this.chkReturnToPageOne);
            this.panel1.Controls.Add(this.chkShowPaperUsageAtLogin);
            this.panel1.Controls.Add(this.chkEnablePaperUsage);
            this.panel1.Controls.Add(this.chkbxEnableValidation);
            this.panel1.Controls.Add(this.chkProductCardCount);
            this.panel1.Controls.Add(salesTaxLabel);
            this.panel1.Controls.Add(this.txtCashDrawerEjectCode);
            this.panel1.Controls.Add(this.numSalesTax);
            this.panel1.Controls.Add(this.chkEnableActiveSession);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkEnableRegisterSalesReport);
            this.panel1.Controls.Add(this.lstRegisterReceipt);
            this.panel1.Controls.Add(this.chkUseExchangeRateOnSale);
            this.panel1.Controls.Add(this.minSaleLabel);
            this.panel1.Controls.Add(this.numCBBQuantitySales);
            this.panel1.Controls.Add(this.m_lblMaximumQuantitySales);
            this.panel1.Controls.Add(this.cboMinumSales);
            this.panel1.Controls.Add(this.lstTenderModes);
            this.panel1.Controls.Add(this.chkAllowQuantitySales);
            this.panel1.Controls.Add(this.tenderModeLabel);
            this.panel1.Controls.Add(this.chkSellFixedUnits);
            this.panel1.Controls.Add(this.chkAllowNoSale);
            this.panel1.Controls.Add(this.chkAllowReturns);
            this.panel1.Controls.Add(this.chkbxAutoIssue);
            this.panel1.Controls.Add(this.chkLongDescriptions);
            this.panel1.Name = "panel1";
            // 
            // chkForceVoidAuth
            // 
            resources.ApplyResources(this.chkForceVoidAuth, "chkForceVoidAuth");
            this.chkForceVoidAuth.Name = "chkForceVoidAuth";
            this.chkForceVoidAuth.UseVisualStyleBackColor = true;
            this.chkForceVoidAuth.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShowFree
            // 
            resources.ApplyResources(this.chkShowFree, "chkShowFree");
            this.chkShowFree.Name = "chkShowFree";
            this.chkShowFree.UseVisualStyleBackColor = true;
            this.chkShowFree.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkScanningStartsNewSale
            // 
            resources.ApplyResources(this.chkScanningStartsNewSale, "chkScanningStartsNewSale");
            this.chkScanningStartsNewSale.Name = "chkScanningStartsNewSale";
            this.chkScanningStartsNewSale.UseVisualStyleBackColor = true;
            this.chkScanningStartsNewSale.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShowQuantityOnButtons
            // 
            resources.ApplyResources(this.chkShowQuantityOnButtons, "chkShowQuantityOnButtons");
            this.chkShowQuantityOnButtons.Name = "chkShowQuantityOnButtons";
            this.chkShowQuantityOnButtons.UseVisualStyleBackColor = true;
            this.chkShowQuantityOnButtons.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkTwoMenuPagesPerPOSPage
            // 
            resources.ApplyResources(this.chkTwoMenuPagesPerPOSPage, "chkTwoMenuPagesPerPOSPage");
            this.chkTwoMenuPagesPerPOSPage.Name = "chkTwoMenuPagesPerPOSPage";
            this.chkTwoMenuPagesPerPOSPage.UseVisualStyleBackColor = true;
            this.chkTwoMenuPagesPerPOSPage.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkWidescreen
            // 
            resources.ApplyResources(this.chkWidescreen, "chkWidescreen");
            this.chkWidescreen.Name = "chkWidescreen";
            this.chkWidescreen.UseVisualStyleBackColor = true;
            this.chkWidescreen.CheckedChanged += new System.EventHandler(this.chkWidescreen_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbResellAuditedItem
            // 
            this.cmbResellAuditedItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResellAuditedItem.FormattingEnabled = true;
            this.cmbResellAuditedItem.Items.AddRange(new object[] {
            resources.GetString("cmbResellAuditedItem.Items"),
            resources.GetString("cmbResellAuditedItem.Items1"),
            resources.GetString("cmbResellAuditedItem.Items2")});
            resources.ApplyResources(this.cmbResellAuditedItem, "cmbResellAuditedItem");
            this.cmbResellAuditedItem.Name = "cmbResellAuditedItem";
            this.cmbResellAuditedItem.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPrintRegisterClosingOnCloseBank
            // 
            resources.ApplyResources(this.chkPrintRegisterClosingOnCloseBank, "chkPrintRegisterClosingOnCloseBank");
            this.chkPrintRegisterClosingOnCloseBank.Name = "chkPrintRegisterClosingOnCloseBank";
            this.chkPrintRegisterClosingOnCloseBank.UseVisualStyleBackColor = true;
            this.chkPrintRegisterClosingOnCloseBank.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableRegisterClosingReport
            // 
            resources.ApplyResources(this.chkEnableRegisterClosingReport, "chkEnableRegisterClosingReport");
            this.chkEnableRegisterClosingReport.Name = "chkEnableRegisterClosingReport";
            this.chkEnableRegisterClosingReport.UseVisualStyleBackColor = true;
            this.chkEnableRegisterClosingReport.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPromptForPlayerCreation
            // 
            this.chkPromptForPlayerCreation.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkPromptForPlayerCreation, "chkPromptForPlayerCreation");
            this.chkPromptForPlayerCreation.Name = "chkPromptForPlayerCreation";
            this.chkPromptForPlayerCreation.UseVisualStyleBackColor = false;
            this.chkPromptForPlayerCreation.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPrintCloseBankReceipt
            // 
            resources.ApplyResources(this.chkPrintCloseBankReceipt, "chkPrintCloseBankReceipt");
            this.chkPrintCloseBankReceipt.Name = "chkPrintCloseBankReceipt";
            this.chkPrintCloseBankReceipt.UseVisualStyleBackColor = true;
            this.chkPrintCloseBankReceipt.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAllowPrintQuantitySales
            // 
            resources.ApplyResources(this.chkAllowPrintQuantitySales, "chkAllowPrintQuantitySales");
            this.chkAllowPrintQuantitySales.Name = "chkAllowPrintQuantitySales";
            this.chkAllowPrintQuantitySales.UseVisualStyleBackColor = true;
            this.chkAllowPrintQuantitySales.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkUseToggleButtonForUnitSelection
            // 
            resources.ApplyResources(this.chkUseToggleButtonForUnitSelection, "chkUseToggleButtonForUnitSelection");
            this.chkUseToggleButtonForUnitSelection.Name = "chkUseToggleButtonForUnitSelection";
            this.chkUseToggleButtonForUnitSelection.UseVisualStyleBackColor = true;
            this.chkUseToggleButtonForUnitSelection.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // m_playWithPaperEnabled
            // 
            resources.ApplyResources(this.m_playWithPaperEnabled, "m_playWithPaperEnabled");
            this.m_playWithPaperEnabled.Name = "m_playWithPaperEnabled";
            // 
            // chkRemoveDiscountsFromRepeatSales
            // 
            resources.ApplyResources(this.chkRemoveDiscountsFromRepeatSales, "chkRemoveDiscountsFromRepeatSales");
            this.chkRemoveDiscountsFromRepeatSales.Name = "chkRemoveDiscountsFromRepeatSales";
            this.chkRemoveDiscountsFromRepeatSales.UseVisualStyleBackColor = true;
            this.chkRemoveDiscountsFromRepeatSales.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkRemovePaperFromRepeatSale
            // 
            resources.ApplyResources(this.chkRemovePaperFromRepeatSale, "chkRemovePaperFromRepeatSale");
            this.chkRemovePaperFromRepeatSale.Name = "chkRemovePaperFromRepeatSale";
            this.chkRemovePaperFromRepeatSale.UseVisualStyleBackColor = true;
            this.chkRemovePaperFromRepeatSale.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkRemoveCouponsPackageOnRepeatSale
            // 
            resources.ApplyResources(this.chkRemoveCouponsPackageOnRepeatSale, "chkRemoveCouponsPackageOnRepeatSale");
            this.chkRemoveCouponsPackageOnRepeatSale.Name = "chkRemoveCouponsPackageOnRepeatSale";
            this.chkRemoveCouponsPackageOnRepeatSale.UseVisualStyleBackColor = true;
            this.chkRemoveCouponsPackageOnRepeatSale.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkReturnToPageOne
            // 
            resources.ApplyResources(this.chkReturnToPageOne, "chkReturnToPageOne");
            this.chkReturnToPageOne.Name = "chkReturnToPageOne";
            this.chkReturnToPageOne.UseVisualStyleBackColor = true;
            this.chkReturnToPageOne.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkShowPaperUsageAtLogin
            // 
            resources.ApplyResources(this.chkShowPaperUsageAtLogin, "chkShowPaperUsageAtLogin");
            this.chkShowPaperUsageAtLogin.Name = "chkShowPaperUsageAtLogin";
            this.chkShowPaperUsageAtLogin.Tag = "chkbxEnableValidation";
            this.chkShowPaperUsageAtLogin.UseVisualStyleBackColor = true;
            this.chkShowPaperUsageAtLogin.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnablePaperUsage
            // 
            resources.ApplyResources(this.chkEnablePaperUsage, "chkEnablePaperUsage");
            this.chkEnablePaperUsage.Name = "chkEnablePaperUsage";
            this.chkEnablePaperUsage.Tag = "chkbxEnableValidation";
            this.chkEnablePaperUsage.UseVisualStyleBackColor = true;
            this.chkEnablePaperUsage.CheckedChanged += new System.EventHandler(this.chkEnablePaperUsage_CheckedChanged);
            // 
            // chkbxEnableValidation
            // 
            resources.ApplyResources(this.chkbxEnableValidation, "chkbxEnableValidation");
            this.chkbxEnableValidation.Name = "chkbxEnableValidation";
            this.chkbxEnableValidation.Tag = "chkbxEnableValidation";
            this.chkbxEnableValidation.UseVisualStyleBackColor = true;
            this.chkbxEnableValidation.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkProductCardCount
            // 
            resources.ApplyResources(this.chkProductCardCount, "chkProductCardCount");
            this.chkProductCardCount.Name = "chkProductCardCount";
            this.chkProductCardCount.UseVisualStyleBackColor = true;
            this.chkProductCardCount.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // txtCashDrawerEjectCode
            // 
            resources.ApplyResources(this.txtCashDrawerEjectCode, "txtCashDrawerEjectCode");
            this.txtCashDrawerEjectCode.Name = "txtCashDrawerEjectCode";
            this.txtCashDrawerEjectCode.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // numSalesTax
            // 
            this.numSalesTax.DecimalPlaces = 2;
            resources.ApplyResources(this.numSalesTax, "numSalesTax");
            this.numSalesTax.Name = "numSalesTax";
            this.numSalesTax.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkEnableActiveSession
            // 
            resources.ApplyResources(this.chkEnableActiveSession, "chkEnableActiveSession");
            this.chkEnableActiveSession.Name = "chkEnableActiveSession";
            this.chkEnableActiveSession.UseVisualStyleBackColor = true;
            this.chkEnableActiveSession.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkEnableRegisterSalesReport
            // 
            resources.ApplyResources(this.chkEnableRegisterSalesReport, "chkEnableRegisterSalesReport");
            this.chkEnableRegisterSalesReport.Name = "chkEnableRegisterSalesReport";
            this.chkEnableRegisterSalesReport.UseVisualStyleBackColor = true;
            this.chkEnableRegisterSalesReport.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // lstRegisterReceipt
            // 
            this.lstRegisterReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.lstRegisterReceipt, "lstRegisterReceipt");
            this.lstRegisterReceipt.FormattingEnabled = true;
            this.lstRegisterReceipt.Items.AddRange(new object[] {
            resources.GetString("lstRegisterReceipt.Items"),
            resources.GetString("lstRegisterReceipt.Items1")});
            this.lstRegisterReceipt.Name = "lstRegisterReceipt";
            this.lstRegisterReceipt.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // chkUseExchangeRateOnSale
            // 
            resources.ApplyResources(this.chkUseExchangeRateOnSale, "chkUseExchangeRateOnSale");
            this.chkUseExchangeRateOnSale.Name = "chkUseExchangeRateOnSale";
            this.chkUseExchangeRateOnSale.UseVisualStyleBackColor = true;
            this.chkUseExchangeRateOnSale.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // minSaleLabel
            // 
            resources.ApplyResources(this.minSaleLabel, "minSaleLabel");
            this.minSaleLabel.Name = "minSaleLabel";
            // 
            // numCBBQuantitySales
            // 
            resources.ApplyResources(this.numCBBQuantitySales, "numCBBQuantitySales");
            this.numCBBQuantitySales.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numCBBQuantitySales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCBBQuantitySales.Name = "numCBBQuantitySales";
            this.numCBBQuantitySales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCBBQuantitySales.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // m_lblMaximumQuantitySales
            // 
            resources.ApplyResources(this.m_lblMaximumQuantitySales, "m_lblMaximumQuantitySales");
            this.m_lblMaximumQuantitySales.Name = "m_lblMaximumQuantitySales";
            // 
            // cboMinumSales
            // 
            this.cboMinumSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboMinumSales, "cboMinumSales");
            this.cboMinumSales.FormattingEnabled = true;
            this.cboMinumSales.Name = "cboMinumSales";
            this.cboMinumSales.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // lstTenderModes
            // 
            this.lstTenderModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.lstTenderModes, "lstTenderModes");
            this.lstTenderModes.FormattingEnabled = true;
            this.lstTenderModes.Name = "lstTenderModes";
            this.lstTenderModes.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAllowQuantitySales
            // 
            resources.ApplyResources(this.chkAllowQuantitySales, "chkAllowQuantitySales");
            this.chkAllowQuantitySales.Name = "chkAllowQuantitySales";
            this.chkAllowQuantitySales.UseVisualStyleBackColor = true;
            this.chkAllowQuantitySales.CheckedChanged += new System.EventHandler(this.chkAllowQuantitySales_CheckedChanged);
            // 
            // tenderModeLabel
            // 
            resources.ApplyResources(this.tenderModeLabel, "tenderModeLabel");
            this.tenderModeLabel.Name = "tenderModeLabel";
            // 
            // chkSellFixedUnits
            // 
            resources.ApplyResources(this.chkSellFixedUnits, "chkSellFixedUnits");
            this.chkSellFixedUnits.Name = "chkSellFixedUnits";
            // 
            // chkAllowNoSale
            // 
            this.chkAllowNoSale.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkAllowNoSale, "chkAllowNoSale");
            this.chkAllowNoSale.Name = "chkAllowNoSale";
            this.chkAllowNoSale.UseVisualStyleBackColor = false;
            // 
            // chkAllowReturns
            // 
            this.chkAllowReturns.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkAllowReturns, "chkAllowReturns");
            this.chkAllowReturns.Name = "chkAllowReturns";
            this.chkAllowReturns.UseVisualStyleBackColor = false;
            this.chkAllowReturns.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkbxAutoIssue
            // 
            this.chkbxAutoIssue.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkbxAutoIssue, "chkbxAutoIssue");
            this.chkbxAutoIssue.Name = "chkbxAutoIssue";
            this.chkbxAutoIssue.UseVisualStyleBackColor = false;
            this.chkbxAutoIssue.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkLongDescriptions
            // 
            resources.ApplyResources(this.chkLongDescriptions, "chkLongDescriptions");
            this.chkLongDescriptions.Name = "chkLongDescriptions";
            this.chkLongDescriptions.UseVisualStyleBackColor = true;
            this.chkLongDescriptions.CheckedChanged += new System.EventHandler(this.OnModified);
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
            // POSSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Name = "POSSettings";
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCBBQuantitySales)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox4;
		private GTI.Controls.ImageButton btnReset;
        private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkPrintRegisterClosingOnCloseBank;
        private System.Windows.Forms.CheckBox chkEnableRegisterClosingReport;
        private System.Windows.Forms.CheckBox chkPromptForPlayerCreation;
        private System.Windows.Forms.CheckBox chkPrintCloseBankReceipt;
        private System.Windows.Forms.CheckBox chkAllowPrintQuantitySales;
        private System.Windows.Forms.CheckBox chkUseToggleButtonForUnitSelection;
        private System.Windows.Forms.Label m_playWithPaperEnabled;
        private System.Windows.Forms.CheckBox chkRemoveDiscountsFromRepeatSales;
        private System.Windows.Forms.CheckBox chkRemovePaperFromRepeatSale;
        private System.Windows.Forms.CheckBox chkRemoveCouponsPackageOnRepeatSale;
        private System.Windows.Forms.CheckBox chkReturnToPageOne;
        private System.Windows.Forms.CheckBox chkShowPaperUsageAtLogin;
        private System.Windows.Forms.CheckBox chkEnablePaperUsage;
        private System.Windows.Forms.CheckBox chkbxEnableValidation;
        private System.Windows.Forms.CheckBox chkProductCardCount;
        private System.Windows.Forms.TextBox txtCashDrawerEjectCode;
        private System.Windows.Forms.NumericUpDown numSalesTax;
        private System.Windows.Forms.CheckBox chkEnableActiveSession;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnableRegisterSalesReport;
        private System.Windows.Forms.ComboBox lstRegisterReceipt;
        private System.Windows.Forms.CheckBox chkUseExchangeRateOnSale;
        private System.Windows.Forms.Label minSaleLabel;
        private System.Windows.Forms.NumericUpDown numCBBQuantitySales;
        private System.Windows.Forms.Label m_lblMaximumQuantitySales;
        private System.Windows.Forms.ComboBox cboMinumSales;
        private System.Windows.Forms.ComboBox lstTenderModes;
        private System.Windows.Forms.CheckBox chkAllowQuantitySales;
        private System.Windows.Forms.Label tenderModeLabel;
        private System.Windows.Forms.CheckBox chkSellFixedUnits;
        private System.Windows.Forms.CheckBox chkAllowNoSale;
        private System.Windows.Forms.CheckBox chkAllowReturns;
        private System.Windows.Forms.CheckBox chkbxAutoIssue;
        private System.Windows.Forms.CheckBox chkLongDescriptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResellAuditedItem;
        private System.Windows.Forms.CheckBox chkTwoMenuPagesPerPOSPage;
        private System.Windows.Forms.CheckBox chkWidescreen;
        private System.Windows.Forms.CheckBox chkShowQuantityOnButtons;
        private System.Windows.Forms.CheckBox chkScanningStartsNewSale;
        private System.Windows.Forms.CheckBox chkForceVoidAuth;
        private System.Windows.Forms.CheckBox chkShowFree;
	}
}
