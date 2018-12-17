#region Copyright

// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All rights reserved

// US4028 Check card count when completing transaction
#endregion

//US4184: (US4183) Do not allow Enable Active Sales Session to be set in NDSalesMode
//US4238: Quantity Sales error prevention
//DE12934: Auto Issue Bank setting is being save to global settings vs operator setting
//US4698: POS Denomination receipt
//US5103: System Settings: Move CBB settings
//US5104: System Settings: Move Printer settings
 
using System;
using System.Collections.Generic;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using System.Windows.Forms;


namespace GTI.Modules.SystemSettings.UI
{
	public partial class POSSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public POSSettings()
		{
			InitializeComponent();

            // TTP 50359
            // Load the tender modes
            lstTenderModes.Items.Add(Resources.TenderModeOff);
            lstTenderModes.Items.Add(Resources.TenderModeAllow);
            lstTenderModes.Items.Add(Resources.TenderModeWarn);
            lstTenderModes.Items.Add(Resources.TenderModePrevent);
            lstTenderModes.Items.Add(Resources.TenderModeQuick);

            bool modified = m_bModified;
            lstTenderModes.SelectedIndex = 0;
            m_bModified = modified;
		}

		// Public Methods
		#region Public Methods
		public override bool IsModified()
		{
			return m_bModified;
		}

		public override void OnActivate(object o)
		{
		}

		public override bool LoadSettings()
		{
			Common.BeginWait();
			this.SuspendLayout();

			bool bResult = LoadPosSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			// Save the settings
			Common.BeginWait();

			bool bResult = SavePosSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private methods
		#region Private methods
		private bool LoadPosSettings()
		{
			// Fill in the operator settings
			SettingValue tempSettingValue;
		    Common.GetSystemSettings();
            bool SaveEnabled = false; //RALLY DE 4004 play with paper settings
            bool allowQuantitySales = false;
            bool usePrePrintedPacks = false;

            //START RALLY US1650 Disable register closing report
            chkExtraDamagedPaperConfirmation.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ConfirmDamagedPaperForPaperExchange));

            chkAllowSalesToBannedPlayers.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.AllowSalesToBannedPlayers));

            chkEnableRegisterSalesReport.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnableRegisterSalesReport));  //RALLY DE9427

            chkEnableRegisterClosingReport.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnableRegisterClosingReport));

            chkShowQuantityOnButtons.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowQuantitiesOnMenuButtons));

            chkScanningStartsNewSale.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ScannedReceiptsStartNewSale));

            chkForceVoidAuth.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ForceAuthorizationOnVoidsAtPOS));

            chkAutoDiscountTextOnReceipt.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.AutoDiscountInfoGoesOnBottomOfScreenReceipt));

            chkShowFree.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowFreeOnDeviceButtonsWithFeeOfZero));

            chkPrintRegisterClosingOnCloseBank.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.PrintRegisterClosingOnBankClose));

            chkWidescreen.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.AllowWidescreenPOS));

            chkTwoMenuPagesPerPOSPage.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.WidescreenPOSHasTwoMenuPagesPerPage));
            chkTwoMenuPagesPerPOSPage.Enabled = chkWidescreen.Checked;

            //END RALLY US1650
            //START RALLY US1658 Use Exchange rate on sale
            chkUseExchangeRateOnSale.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.UseExchangeRateOnSale));  //RALLY DE9427
            
            //enable paper usage
            chkEnablePaperUsage.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnablePaperUsage));

            //paper usage
            chkEnablePaperUsage.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnablePaperUsage));

            //US4698: POS Denomination receipt
            //print close bank denomination receipt from the POS
            chkPrintCloseBankReceipt.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.PrintDenominationReceipt));

            //show at login
            chkShowPaperUsageAtLogin.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowPaperUsageAtLogin));
		    chkShowPaperUsageAtLogin.Enabled = chkEnablePaperUsage.Checked;

            chkLongDescriptions.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.UseLongDescriptionsOnPOSScreen));

            chkRemoveCouponsPackageOnRepeatSale.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.RepeatSaleRemoveCouponPackages));
            chkRemovePaperFromRepeatSale.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.RepeatSaleRemovePaper));
            chkRemoveDiscountsFromRepeatSales.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.RepeatSaleRemoveDiscounts));

            chkReturnToPageOne.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ReturnToPageOneAfterSale));

            chkUseToggleButtonForUnitSelection.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.UseSystemMenuForDeviceSelection));

            //END RALLY US1658
            // TTP 50359
			Common.GetOpSettingValue(Setting.TenderSales, out tempSettingValue);
            int tenderMode = ParseInt(tempSettingValue.Value);

            if(tenderMode >= 0 && tenderMode <= lstTenderModes.Items.Count - 1)
                lstTenderModes.SelectedIndex = tenderMode;

            bool printRegisterReportByPackage;
            Common.GetOpSettingValue(Setting.PrintRegisterReportByPackage, out tempSettingValue);
            if(bool.TryParse(tempSettingValue.Value, out printRegisterReportByPackage))
            {
                if (printRegisterReportByPackage)
                    lstRegisterReceipt.SelectedIndex = 1;
                else
                    lstRegisterReceipt.SelectedIndex = 0;

            }
            //START RALLY US1854

            string settingValue;
            byte settingMinMax = Common.GetSettingMinMax(Setting.MinimumSaleAllowed, out settingValue);
            int minimumSetting = 0;
            if (settingMinMax == 1)
            {
              
                if (int.TryParse(settingValue, out minimumSetting))
                {
                    if (minimumSetting == 0)
                    {
                        //use all items in the cbo
                        cboMinumSales.Items.Clear();
                        //Load the minimum sales allowed
                        cboMinumSales.Items.Add(Resources.AllowAllSales);
                        cboMinumSales.Items.Add(Resources.AllowZeroSales);
                        cboMinumSales.Items.Add(Resources.AllowGreaterZero);

                    }
                    if (minimumSetting == 1)
                    {
                        cboMinumSales.Items.Clear();
                        cboMinumSales.Items.Add(Resources.AllowZeroSales);
                        cboMinumSales.Items.Add(Resources.AllowGreaterZero);
                    }

                    else if (minimumSetting == 2)
                    {
                        cboMinumSales.Items.Clear();
                        cboMinumSales.Items.Add(Resources.AllowGreaterZero);
                        cboMinumSales.Enabled = false;
                        minSaleLabel.Enabled = false;
                    }
                }
                else
                {
                    cboMinumSales.Items.Clear();
                    //Load the minimum sales allowed
                    cboMinumSales.Items.Add(Resources.AllowAllSales);
                    cboMinumSales.Items.Add(Resources.AllowZeroSales);
                    cboMinumSales.Items.Add(Resources.AllowGreaterZero);
                }
            }
            else
            {
                cboMinumSales.Items.Clear();
                //Load the minimum sales allowed
                cboMinumSales.Items.Add(Resources.AllowAllSales);
                cboMinumSales.Items.Add(Resources.AllowZeroSales);
                cboMinumSales.Items.Add(Resources.AllowGreaterZero);
            }

            settingValue = Common.GetSystemSetting(Setting.MinimumSaleAllowed);

            int minSale = ParseInt(settingValue);
            if (minSale >= minimumSetting)
            {
                if (minSale == 0)
                {
                    cboMinumSales.SelectedItem = Resources.AllowAllSales;
                }
                else if (minSale == 1)
                {
                    cboMinumSales.SelectedItem = Resources.AllowZeroSales;
                }
                else if (minSale == 2)
                {
                    cboMinumSales.SelectedItem = Resources.AllowGreaterZero;
                }
            }
            else
            {
                cboMinumSales.SelectedIndex = 0;
            }
            //END RALLY US1854

            Common.GetOpSettingValue(Setting.EnableValidation, out tempSettingValue);
            chkbxEnableValidation.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY US4697

			Common.GetOpSettingValue(Setting.OpAllowNoSale, out tempSettingValue);
            chkAllowNoSale.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
			
			Common.GetOpSettingValue(Setting.OpAllowReturns, out tempSettingValue);
            chkAllowReturns.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            //license file
		    chkAllowReturns.Enabled = Common.GetSettingEnabled(Setting.OpAllowReturns);

			Common.GetOpSettingValue(Setting.SellElectronics, out tempSettingValue);
            chkSellFixedUnits.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427

            //US4639
            //DE12934
		    Common.GetOpSettingValue(Setting.AutoIssueBank, out tempSettingValue);
            chkbxAutoIssue.Checked = Common.ParseBool(tempSettingValue.Value);
            
            // FIX : TA4750 Remove settings
            
            // FIX : RALLY DE3141 Un-remove settings

            //START RALLY DE 4004 start play with paper settings dependencies 
            m_playWithPaperEnabled.Visible = false; 
            string playWithPaperValue = Common.GetLicenseSettingValue(LicenseSetting.PlayWithPaper); //RALLY TA 7896 moved license file settings 
            bool playWithPaper;
            //START RALLY DE8991
            if(!bool.TryParse(playWithPaperValue, out playWithPaper))
            {
                playWithPaper = false;
            }
            //END RALLY DE8991
            //END RALLY DE 4004 end 

            usePrePrintedPacks = Common.ParseBool(Common.GetLicenseSettingValue(LicenseSetting.UsePrePrintedPacks));//RALLY DE9427  //RALLY TA 7896 moved license file settings 
           
            // PDTS 1044
            if (Common.GetLicenseSettingValue(LicenseSetting.EnableAnonymousMachineAccounts).Equals(bool.TrueString))//RALLY TA 7896 moved license file settings 
            {
                chkPromptForPlayerCreation.Checked = false;
                chkPromptForPlayerCreation.Visible = false;
            }
            else
            {
                Common.GetOpSettingValue(Setting.PromptForPlayerCreation, out tempSettingValue);
                chkPromptForPlayerCreation.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            }
            // END : TA4750 Remove settings
            // END : RALLY DE3141

            settingValue = Common.GetSystemSetting(Setting.AllowQuantitySale);

            chkAllowQuantitySales.Checked = ParseBool(settingValue);  //RALLY DE9427
            if (settingValue != null && Convert.ToBoolean(settingValue) && usePrePrintedPacks) //FIX RALLY DE 6617
            {
                chkAllowQuantitySales.Checked = false;
                chkAllowQuantitySales.Enabled = false;
            }
            else
            {
                chkAllowQuantitySales.Enabled = true;
            }
            
            //FIX START RALLY DE 2681 added print quantity sales receipts to POS

            chkAllowPrintQuantitySales.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.PrintQuantitySaleReceipts));  //RALLY DE9427

            //FIX START RALLY DE 2682 added print quantity sales receipts to POS
            Common.GetOpSettingValue(Setting.MaxPlayerQuantitySale, out tempSettingValue);

            numCBBQuantitySales.Value = ParseInt(tempSettingValue.Value);

            //FIX END RALLY DE 2682 added print quantity sales receipts to POS

            if(chkAllowQuantitySales.Checked == false)
            {
                chkAllowPrintQuantitySales.Checked = false;
                chkAllowPrintQuantitySales.Enabled = false;
            }
            else
            {
                chkAllowPrintQuantitySales.Enabled = true;
            }
            //START RALLY DE 4004
            if (playWithPaper)
            {
                
                chkAllowPrintQuantitySales.Enabled = false;
                chkAllowQuantitySales.Enabled = false;
                //START RALLY DE 4608 Added setting to be dependant on play with paper
                numCBBQuantitySales.Enabled = false;
                m_lblMaximumQuantitySales.Enabled = false;

                if ( chkAllowPrintQuantitySales.Checked ||
                   chkAllowQuantitySales.Checked || numCBBQuantitySales.Value != 1)
                {
                    SaveEnabled = true;
                }
                //END RALLY DE 4608

                chkAllowPrintQuantitySales.Checked = false;
                chkAllowQuantitySales.Checked = false;
                numCBBQuantitySales.Value = 1;//RALLY DE 4608 Added setting to be dependant on play with paper

                if (!chkAllowPrintQuantitySales.Text.EndsWith("*")) //RALLY DE 6226 text kept adding multiple receipts
                {
                    chkAllowPrintQuantitySales.Text += "*";
                    chkAllowQuantitySales.Text += "*";
                    m_lblMaximumQuantitySales.Text += "*"; //RALLY DE 4608 Added setting to be dependant on play with paper
                }
                m_playWithPaperEnabled.Visible = true;
            }
            //END RALLY DE 4004

            //FIX END RALLY DE 2681 added print quantity sales receipts to POS

            Common.GetOpSettingValue(Setting.CashDrawerEjectCode, out tempSettingValue);
			txtCashDrawerEjectCode.Text = tempSettingValue.Value;
            

            //END RALLY TA 6095 CBB enabled/disabled
		    // Get the stuff we need from the operator table
		    numSalesTax.Value = Common.m_GetHallSettingsMessage.SalesTax;

            //US4184: (US4183) Do not allow Enable Active Sales Session to be enabled in NDSalesMode. Always enabled
		    if (Common.ParseBool(Common.GetLicenseSettingValue(LicenseSetting.NDSalesMode)))
		    {
		        var isModified = false;
                
                //if not enabled then enable
                if (!chkEnableActiveSession.Checked)
                {
                    chkEnableActiveSession.Checked = true;
                    isModified = true;
                }

                //US4238
                //disable quantity sales
		        if (chkAllowQuantitySales.Checked)
		        {
                    chkAllowQuantitySales.Checked = false;
		            if (chkAllowPrintQuantitySales.Checked)
		            {
		                chkAllowPrintQuantitySales.Checked = false;
		            }

		            isModified = true;
		        }

                //do not allow user to modify
                chkAllowPrintQuantitySales.Enabled = false;
		        chkAllowQuantitySales.Enabled = false;
                chkEnableActiveSession.Enabled = false;
                m_lblMaximumQuantitySales.Enabled = false;
                numCBBQuantitySales.Enabled = false;

		        if (isModified)
		        {
		            SavePosSettings();
		        }
		    }
		    else
		    {
                chkEnableActiveSession.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnableActiveSalesSession)); //US2828    
		    }

            chkProductCardCount.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.CheckProductCardCount)); //US4028

            try
            {
                cmbResellAuditedItem.SelectedIndex = Common.ParseInt(Common.GetOpSetting(Setting.SellPreviouslySoldItemOption));
            }
            catch (Exception)
            {
                cmbResellAuditedItem.SelectedIndex = 2; //default to ASK
            }

			// Set the flag
			m_bModified = false;

			return true;
		}


        private bool SavePosSettings()
        {
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.ConfirmDamagedPaperForPaperExchange;
            s.Value = chkExtraDamagedPaperConfirmation.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.AllowSalesToBannedPlayers;
            s.Value = chkAllowSalesToBannedPlayers.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.SellPreviouslySoldItemOption;
            s.Value = cmbResellAuditedItem.SelectedIndex.ToString();
            arrSettings.Add(s);

            s.Id = (int) Setting.AllowQuantitySale;
            s.Value = chkAllowQuantitySales.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ShowQuantitiesOnMenuButtons;
            s.Value = chkShowQuantityOnButtons.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ScannedReceiptsStartNewSale;
            s.Value = chkScanningStartsNewSale.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ForceAuthorizationOnVoidsAtPOS;
            s.Value = chkForceVoidAuth.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ShowFreeOnDeviceButtonsWithFeeOfZero;
            s.Value = chkShowFree.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.AllowWidescreenPOS;
            s.Value = chkWidescreen.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.AutoDiscountInfoGoesOnBottomOfScreenReceipt;
            s.Value = chkAutoDiscountTextOnReceipt.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.WidescreenPOSHasTwoMenuPagesPerPage;
            s.Value = chkTwoMenuPagesPerPOSPage.Checked.ToString();
            arrSettings.Add(s);

            //US2828
            s.Id = (int)Setting.EnableActiveSalesSession;
            s.Value = chkEnableActiveSession.Checked.ToString();
            arrSettings.Add(s);
            
            s.Id = (int) Setting.PrintQuantitySaleReceipts;
            s.Value = chkAllowPrintQuantitySales.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.EnableValidation;
            s.Value = chkbxEnableValidation.Checked.ToString();
            arrSettings.Add(s); // US4697
            
            //START RALLY US1658
            s.Id = (int)Setting.UseExchangeRateOnSale;
            s.Value = chkUseExchangeRateOnSale.Checked.ToString();
            arrSettings.Add(s);

            //paper usage
            s.Id = (int)Setting.EnablePaperUsage;
            s.Value = chkEnablePaperUsage.Checked.ToString();
            arrSettings.Add(s);

            //paper usage
            s.Id = (int)Setting.ShowPaperUsageAtLogin;
            s.Value = chkShowPaperUsageAtLogin.Checked.ToString();
            arrSettings.Add(s);

            //long descriptions at POS
            s.Id = (int)Setting.UseLongDescriptionsOnPOSScreen;
            s.Value = chkLongDescriptions.Checked.ToString();
            arrSettings.Add(s);

            //remove coupon packages from repeat sales
            s.Id = (int)Setting.RepeatSaleRemoveCouponPackages;
            s.Value = chkRemoveCouponsPackageOnRepeatSale.Checked.ToString();
            arrSettings.Add(s);

            //remove barcoded paper from repeat sales
            s.Id = (int)Setting.RepeatSaleRemovePaper;
            s.Value = chkRemovePaperFromRepeatSale.Checked.ToString();
            arrSettings.Add(s);

            //remove discounts from repeat sales
            s.Id = (int)Setting.RepeatSaleRemoveDiscounts;
            s.Value = chkRemoveDiscountsFromRepeatSales.Checked.ToString();
            arrSettings.Add(s);

            //return to page one after a sale in POS
            s.Id = (int)Setting.ReturnToPageOneAfterSale;
            s.Value = chkReturnToPageOne.Checked.ToString();
            arrSettings.Add(s);

            ////US4698: POS Denomination receipt
            //Print Close Bank Denomination Receipt
            s.Id = (int)Setting.PrintDenominationReceipt;
            s.Value = chkPrintCloseBankReceipt.Checked.ToString();
            arrSettings.Add(s);

            //use toggle button to select unit
            s.Id = (int)Setting.UseSystemMenuForDeviceSelection;
            s.Value = chkUseToggleButtonForUnitSelection.Checked.ToString();
            arrSettings.Add(s);

            //END RALLY US1658
            //START RALLY US1854
            if (cboMinumSales.Enabled == true)
            {
                s.Id = (int)Setting.MinimumSaleAllowed;
                if (cboMinumSales.SelectedItem.ToString() == Resources.AllowAllSales)
                    s.Value = "0";
                else if (cboMinumSales.SelectedItem.ToString() == Resources.AllowZeroSales)
                    s.Value = "1";
                else if (cboMinumSales.SelectedItem.ToString() == Resources.AllowGreaterZero)
                    s.Value = "2";
                arrSettings.Add(s);
            }
            //END RALLY US1854
            //START RALLY US1650
            s.Id = (int)Setting.EnableRegisterSalesReport;
            s.Value = chkEnableRegisterSalesReport.Checked.ToString();
            arrSettings.Add(s);

            //US5115
            s.Id = (int)Setting.EnableRegisterClosingReport;
            s.Value = chkEnableRegisterClosingReport.Checked.ToString();
            arrSettings.Add(s);

            //US5108
            s.Id = (int)Setting.PrintRegisterClosingOnBankClose;
            s.Value = chkPrintRegisterClosingOnCloseBank.Checked.ToString();
            arrSettings.Add(s);

            // US4028
            s.Id = (int)Setting.CheckProductCardCount;
            s.Value = chkProductCardCount.Checked.ToString();
            arrSettings.Add(s);
            
            //END RALLY US1650
            // Update the server
            
            if ( !Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }
         
            // Update the operator global settings
            // TTP 50359
            Common.SetOpSettingValue(Setting.TenderSales, lstTenderModes.SelectedIndex.ToString());

            Common.SetOpSettingValue(Setting.OpAllowNoSale, chkAllowNoSale.Checked.ToString());

            if (lstRegisterReceipt.SelectedIndex == 0)
            {
                Common.SetOpSettingValue(Setting.PrintRegisterReportByPackage, bool.FalseString);
            }
            else if (lstRegisterReceipt.SelectedIndex == 1)
            {
                Common.SetOpSettingValue(Setting.PrintRegisterReportByPackage, bool.TrueString);
            }
            //license file
            if(chkAllowReturns.Enabled)
            {
                Common.SetOpSettingValue(Setting.OpAllowReturns, chkAllowReturns.Checked.ToString());
            }

            Common.SetOpSettingValue(Setting.SellElectronics, chkSellFixedUnits.Checked.ToString());

            // PDTS 1044
            Common.SetOpSettingValue(Setting.PromptForPlayerCreation, chkPromptForPlayerCreation.Checked.ToString());

            Common.SetOpSettingValue(Setting.AllowQuantitySale, chkAllowQuantitySales.Checked.ToString());
            
            Common.SetOpSettingValue(Setting.PrintQuantitySaleReceipts, chkAllowPrintQuantitySales.Checked.ToString());//RALLY DE 2681 set print quantity sales to database

            Common.SetOpSettingValue(Setting.MaxPlayerQuantitySale, numCBBQuantitySales.Value.ToString());//RALLY DE 2682 set global quantity sales amounts
            
            Common.SetOpSettingValue(Setting.CashDrawerEjectCode, txtCashDrawerEjectCode.Text.Trim()); // PDTS 584


            //US4639
            //DE12934
            Common.SetOpSettingValue(Setting.AutoIssueBank, chkbxAutoIssue.Checked.ToString());

            // Update the Hall table
            Common.m_GetHallSettingsMessage.SalesTax = numSalesTax.Value;

            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
	            return false;
            }

            //Save the Hall Settings
            if (!Common.SaveHallSettings())
            {
                return false;
            }

            // Set the flag
            m_bModified = false;

            return true;
		}



		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		#endregion // Private methods

        private void chkUsePrePrintedPacks_Click(object sender, EventArgs e)
        {
            //FIX RALLY DE 3141
            CheckBox pppCheckBox = sender as CheckBox;
            if(pppCheckBox!= null && pppCheckBox.Enabled)
            {
                if(pppCheckBox.Checked)
                {
                    chkAllowQuantitySales.Checked = false;
                    chkAllowQuantitySales.Enabled = false;
                }

                else
                {
                    chkAllowQuantitySales.Enabled = true;
                }
            }
            //END FIX RALLY DE 3141
        }

        private void chkAllowQuantitySales_CheckedChanged(object sender, EventArgs e)
        {
            //FIX RALLY DE 3141
            CheckBox allowQuantitySalesCheckBox = sender as CheckBox;
            if (allowQuantitySalesCheckBox.Enabled)
            {
                if (allowQuantitySalesCheckBox.Checked == false)
                {
                    chkAllowPrintQuantitySales.Checked = false;
                    chkAllowPrintQuantitySales.Enabled = false;
                }
                else
                {
                    chkAllowPrintQuantitySales.Enabled = true;
                }
            }

            OnModified(sender, e);
            //END FIX RALLY DE 3141
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void chkEnablePaperUsage_CheckedChanged(object sender, EventArgs e)
        {
            chkShowPaperUsageAtLogin.Enabled = chkEnablePaperUsage.Checked;

            if (!chkEnablePaperUsage.Checked)
                chkShowPaperUsageAtLogin.Checked = false;

            OnModified(sender, e);
        }

        private void chkWidescreen_CheckedChanged(object sender, EventArgs e)
        {
            chkTwoMenuPagesPerPOSPage.Enabled = chkWidescreen.Checked;

            if (!chkWidescreen.Checked)
                chkTwoMenuPagesPerPOSPage.Checked = false;

            OnModified(sender, e);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            Application.DoEvents();
        }
    } // end class
} // end namespace

