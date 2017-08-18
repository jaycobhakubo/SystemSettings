using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Business;


namespace GTI.Modules.SystemSettings.UI
{
    public partial class MoneyCenterSettings : SettingsControl
    {
        // Members
        bool m_bModified = false;
        int m_feeType = 0;
        private int initialWidth;
        private TreeNode m_TreeNodeParent;
        private MainForm m_mainForm;

        public MoneyCenterSettings()
        {
            m_TreeNodeParent = null;
            InitializeComponent();
            initialWidth = textBoxFeeAmount.Width;
        }

        public void SetTreeNode(TreeNode parent)
        {
            m_TreeNodeParent = parent;
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

            bool bResult = LoadMoneyCenterSettings();


            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveMoneySettings();

            Common.EndWait();

            return bResult;
        }
        #endregion  // Public Methods

        // Private Routines
        #region Private Routines

        
        internal void SetForm(MainForm mainForm)
        {
            m_mainForm = mainForm;
        }

        private bool LoadMoneyCenterSettings()
        {
            // Fill in the operator global settings
            SettingValue tempSettingValue;
            bool saveFlag = false;
            Common.GetOpSettingValue(Setting.BankUsePreviousClose, out tempSettingValue);
            chkUsePreviousBankClosingAmount.Checked = Common.ParseBool(tempSettingValue.Value);   //RALLY DE9427
            
            Common.GetOpSettingValue(Setting.MasterBankUsePreviousClose, out tempSettingValue);
            chkMasterBankUsePreviousClose.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            
            //START RALLY US1570 Force players on payouts
            Common.GetOpSettingValue(Setting.ForcePlayerOnPayout, out tempSettingValue);
            chkForcePlayerOnPayouts.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            chkForcePlayerOnPayouts.Enabled = Common.GetSettingEnabled(Setting.ForcePlayerOnPayout);

            //END RALLY US1570

            // start Rally US2723 Print winners address
            Common.GetOpSettingValue(Setting.PrintWinnersAddress, out tempSettingValue);
            chkPrintWinnersAddress.Checked = Common.ParseBool(tempSettingValue.Value);
            // end rally US2723

            //START RALLY US1562 Accrual Transactions
            Common.GetOpSettingValue(Setting.PrintAccrualTransferReceipt, out tempSettingValue);
            chkPrintAccrualTransfer.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            
            Common.GetOpSettingValue(Setting.PrintAccrualIncreaseReceipt, out tempSettingValue);
            chkPrintAccrualIncrease.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            Common.GetOpSettingValue(Setting.PrintAccrualReseedReceipt, out tempSettingValue);
            chkPrintAccrualReseed.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            
            Common.GetOpSettingValue(Setting.PrintAccrualResetReceipt, out tempSettingValue);
            chkPrintAccrualReset.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            //END RALLY US1562

            //US4725
            Common.GetOpSettingValue(Setting.PrintPayoutText, out tempSettingValue);
            chkPrintWordValue.Checked = Common.ParseBool(tempSettingValue.Value);

            //US5107: System Settings: Set number of payout signature lines on the payout receipt
            Common.GetOpSettingValue(Setting.PayoutReceiptSignatureLineCount, out tempSettingValue);
            numPayoutSignatureLines.Text = tempSettingValue.Value;

            //DE13632
            Common.GetOpSettingValue(Setting.BankCloseReceiptSignatureLineCount, out tempSettingValue);
            numBankCloseSignatureLines.Value = Convert.ToDecimal(tempSettingValue.Value);

            //START RALLY US1906
            try
            {
                Common.GetOpSettingValue(Setting.NumberOfBankIssueReceipts, out tempSettingValue);
                numBankIssueCopies.Value = Convert.ToDecimal(tempSettingValue.Value);
            }
            catch (Exception /*ex*/)
            {
                numBankIssueCopies.Value = 1;
                saveFlag = true;
            }

            try
            {
                Common.GetOpSettingValue(Setting.NumberOfBankDropReceipts, out tempSettingValue);
                numBankDropCopies.Value = Convert.ToDecimal(tempSettingValue.Value);
            }
            catch (Exception /*ex*/)
            {
                numBankDropCopies.Value = 1;
                saveFlag = true;
            }

            try
            {
                Common.GetOpSettingValue(Setting.NumberOfBankCloseReceipts, out tempSettingValue);
                numBankCloseCopies.Value = Convert.ToDecimal(tempSettingValue.Value);
            }
            catch
            {
                numBankCloseCopies.Value = 1;
                saveFlag = true;
            }
            //END RALLY US1906

            //START RALLY US1930
            try
            {
                Common.GetOpSettingValue(Setting.PrintZeroAmountBankReciept, out tempSettingValue);
                chkPrintZeroAmount.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            }
            catch
            {
                chkPrintZeroAmount.Checked = false;
                saveFlag = true;
            }
            //END RALLY US1930

            //START RALLY US1572
            string tempString = Common.GetSystemSetting(Setting.PrizeFeeAmount);
            textBoxFeeAmount.Text = tempString;

            tempString = Common.GetSystemSetting(Setting.PrizeFeeMinAmount);
            textBoxMinimumPrizeAmount.Text = tempString;

            m_feeType = Common.ParseInt(Common.GetSystemSetting(Setting.PrizeFeeAmountType));   //RALLY DE9427

            if (m_feeType == 1)
            {
                radioButtonFeeFixed.Checked = true;
            }
            else if (m_feeType == 2)
            {
                radioButtonFeePercent.Checked = true;
            }
            

            //END RALLY US1572

            //US4609
            tempString = Common.GetSystemSetting(Setting.TaxFormMinWinAmount);
            textBoxMinPrizeWinAmount.Text = tempString;


            DisplayPanelSettings();
            

            //START RALLY US1571
            Common.GetOpSettingValue(Setting.PrintAllPayoutWinners, out tempSettingValue);
            chkPrintAllPayoutWinners.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            //END RALLY US1571

            // Set the flag
            m_bModified = false;

            if (saveFlag == true)
            {
                SaveMoneySettings();
            }
            return true;
        }

        /**
         * Checks the current operator's CashMethodID, if accruals are enabled, and if payouts are enabled.
         *     It then enables/disables the panels and their contents based on whether or not they should be
         *     accessed based on those settings.
         */ 
        private void DisplayPanelSettings()
        {
            //Start Rally DE8593 System Settings->Cash Method->Money Center (& DE8840, DE8846)
            OperatorManagement operatorManagement1 = m_mainForm.getOperatorManagement();
            BingoOperator currentOperator = operatorManagement1.GetCurrentOperator(Common.OperatorId);

            //---------Money Center Settings---------
            if (currentOperator.OperatorCashMethodId != 3)
            {
                groupBox3.Visible = false;
                chkMasterBankUsePreviousClose.Visible = false;
                chkUsePreviousBankClosingAmount.Visible = false;
            }
            else
            {
                groupBox3.Visible = true;
                chkMasterBankUsePreviousClose.Visible = true;
                chkUsePreviousBankClosingAmount.Visible = true;
            }
            string accrualString = Common.GetLicenseSettingValue(LicenseSetting.AccrualEnabled);
            string payoutString = Common.GetLicenseSettingValue(LicenseSetting.PayoutsEnabled);
            //START RALLY DE8991
            bool accrualEnabled = false;
            bool payoutEnabled = false;
            bool.TryParse(accrualString, out accrualEnabled);
            bool.TryParse(payoutString, out payoutEnabled);

            //---------Accrual reciept settings---------
            if (accrualEnabled == false)
            {
                accrualGroupBox.Visible = false;
                chkPrintAccrualIncrease.Visible = false;
                chkPrintAccrualTransfer.Visible = false;
                chkPrintAccrualReset.Visible = false;
                chkPrintAccrualReseed.Visible = false;
            }
            else
            {
                accrualGroupBox.Visible = true;
                chkPrintAccrualIncrease.Visible = true;
                chkPrintAccrualTransfer.Visible = true;
                chkPrintAccrualReset.Visible = true;
                chkPrintAccrualReseed.Visible = true;
            }
            //---------Prize Fees settings---------
            if (payoutEnabled == false)
            {
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox6.Visible = false;
                textBoxMinimumPrizeAmount.Visible = false;
                textBoxFeeAmount.Visible = false;
                textBoxMinPrizeWinAmount.Visible = false;
                radioButtonFeePercent.Visible = false;
                radioButtonFeeFixed.Visible = false;
                chkPrintAllPayoutWinners.Visible = false;
                chkForcePlayerOnPayouts.Visible = false;
                chkPrintWinnersAddress.Visible = false;
            }
            else
            {
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox6.Visible = true;
                textBoxMinimumPrizeAmount.Visible = true;
                textBoxFeeAmount.Visible = true;
                textBoxMinPrizeWinAmount.Visible = true;
                radioButtonFeePercent.Visible = true;
                radioButtonFeeFixed.Visible = true;
                chkPrintAllPayoutWinners.Visible = true;
                chkForcePlayerOnPayouts.Enabled = Common.GetSettingEnabled(Setting.ForcePlayerOnPayout);//RALLY DE8673
                chkPrintWinnersAddress.Visible = true;
            }

            //if all three panels are disabled, disable the whole containing panel
            if (payoutEnabled == false && accrualEnabled == false && currentOperator.OperatorCashMethodId != 3)
            {
                groupBox1.Enabled = false; 
            }
            else
            {
                groupBox1.Enabled = true;
            }
            //End Rally DE8593 System Settings->Cash Method->Money Center (& DE8840, DE8846)
            //End RALLY DE8991
        }

        private bool SaveMoneySettings()
        {
            // Update the operator global settings
            Common.SetOpSettingValue(Setting.MasterBankUsePreviousClose, chkMasterBankUsePreviousClose.Checked.ToString());
            Common.SetOpSettingValue(Setting.BankUsePreviousClose, chkUsePreviousBankClosingAmount.Checked.ToString());

            //START RALLY US1570
            if (chkForcePlayerOnPayouts.Enabled)
            {
                Common.SetOpSettingValue(Setting.ForcePlayerOnPayout, chkForcePlayerOnPayouts.Checked.ToString());
            }//END RALLY US1570

            //US2723
            Common.SetOpSettingValue(Setting.PrintWinnersAddress, chkPrintWinnersAddress.Checked.ToString());

            //START RALLY US1562
            Common.SetOpSettingValue(Setting.PrintAccrualIncreaseReceipt, chkPrintAccrualIncrease.Checked.ToString());
            Common.SetOpSettingValue(Setting.PrintAccrualTransferReceipt, chkPrintAccrualTransfer.Checked.ToString());
            Common.SetOpSettingValue(Setting.PrintAccrualReseedReceipt, chkPrintAccrualReseed.Checked.ToString());
            Common.SetOpSettingValue(Setting.PrintAccrualResetReceipt, chkPrintAccrualReset.Checked.ToString());
            //END RALLY US1562
            //START RALLY US1906
            Common.SetOpSettingValue(Setting.NumberOfBankIssueReceipts, numBankIssueCopies.Value.ToString());
            Common.SetOpSettingValue(Setting.NumberOfBankDropReceipts, numBankDropCopies.Value.ToString());
            Common.SetOpSettingValue(Setting.NumberOfBankCloseReceipts, numBankCloseCopies.Value.ToString());
            //END RALLY US1906
            //START RALLY US1930
            Common.SetOpSettingValue(Setting.PrintZeroAmountBankReciept, chkPrintZeroAmount.Checked.ToString());
            //END RALLY US1930
            Common.SetOpSettingValue(Setting.PrintAllPayoutWinners, chkPrintAllPayoutWinners.Checked.ToString()); //RALLY US1571

            Common.SetOpSettingValue(Setting.PrintPayoutText, chkPrintWordValue.Checked.ToString());//US4725

            //US5107: Operator Settings: Set number of payout signature lines on the payout receipt
            Common.SetOpSettingValue(Setting.PayoutReceiptSignatureLineCount, numPayoutSignatureLines.Value.ToString(CultureInfo.InvariantCulture));

            //DE13632: Operator Settings: Set number of bank close signature lines on the receipt
            Common.SetOpSettingValue(Setting.BankCloseReceiptSignatureLineCount, numBankCloseSignatureLines.Value.ToString(CultureInfo.InvariantCulture));

            //START RALLY US1572
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            if (radioButtonFeeFixed.Checked)
            {
                s.Id = (int)Setting.PrizeFeeAmountType;
                s.Value = "1";
                arrSettings.Add(s);
            }
            else if (radioButtonFeePercent.Checked)
            {
                s.Id = (int)Setting.PrizeFeeAmountType;
                s.Value = "2";
                arrSettings.Add(s);
            }

            s.Id = (int)Setting.PrizeFeeAmount;
           
            //DE8583
            if (!(string.IsNullOrEmpty(textBoxFeeAmount.Text)) && textBoxFeeAmount.Text != "." && textBoxFeeAmount.Text!="-")
            {
                //DE12916 Refuse negative prize fee amount values to be saved
                m_errorProvider.Clear();

                if (radioButtonFeeFixed.Checked)
                {
                    if (Convert.ToDecimal(textBoxFeeAmount.Text) < 0)
                    {
                        //Add error notification on screen
                        m_errorProvider.SetError(textBoxFeeAmount, Resources.ErrorNumber);
                        return false;
                    }

                    else
                        textBoxFeeAmount.Text = Convert.ToDecimal(textBoxFeeAmount.Text).ToString("F2");
                }

                else if (radioButtonFeePercent.Checked)
                {
                    if (Convert.ToDecimal(textBoxFeeAmount.Text) < 0 || Convert.ToDecimal(textBoxFeeAmount.Text) > 100)
                    {
                        //Add error notification on screen
                        m_errorProvider.SetError(textBoxFeeAmount, Resources.ErrorNumber);
                        return false;
                    }

                    else
                        textBoxFeeAmount.Text = Convert.ToDecimal(textBoxFeeAmount.Text).ToString("F2");
                }
            }

            else if (string.IsNullOrEmpty(textBoxFeeAmount.Text))
            {
                //DE12939 Refuse save if box is empty
                m_errorProvider.Clear();
                m_errorProvider.SetError(textBoxFeeAmount, "Value must be filled in to save");
                return false;
            }

            else
                textBoxFeeAmount.Text = "0.00";
           
            s.Value = textBoxFeeAmount.Text;
            arrSettings.Add(s);

            s.Id = (int)Setting.PrizeFeeMinAmount;

            //DE8583 
            if (!(string.IsNullOrEmpty(textBoxMinimumPrizeAmount.Text)) && textBoxMinimumPrizeAmount.Text != "." &&textBoxMinimumPrizeAmount.Text!="-")
            {
                //DE12916 Refuse negative min prize win amount values to be saved
                m_errorProvider.Clear();
                if (Convert.ToDecimal(textBoxMinimumPrizeAmount.Text) < 0)
                {
                    //Add error notification on screen
                    m_errorProvider.SetError(textBoxMinimumPrizeAmount, "Negative values not allowed; returning to default value.");
                    textBoxMinimumPrizeAmount.Text = "0.00";
                    return false;
                }

                else
                    textBoxMinimumPrizeAmount.Text = Convert.ToDecimal(textBoxMinimumPrizeAmount.Text).ToString("F2");
            }

            else if (string.IsNullOrEmpty(textBoxMinimumPrizeAmount.Text))
            {
                //DE12939 Refuse save if box is empty
                m_errorProvider.Clear();
                m_errorProvider.SetError(textBoxMinimumPrizeAmount, "Value must be filled in to save");
                return false;
            }

            else
                textBoxMinimumPrizeAmount.Text = "0.00";

            s.Value = textBoxMinimumPrizeAmount.Text;
            arrSettings.Add(s);

            //END RALLY US1572

            //US4609
            s.Id = (int)Setting.TaxFormMinWinAmount;

            if (!(string.IsNullOrEmpty(textBoxMinPrizeWinAmount.Text)) && textBoxMinPrizeWinAmount.Text != "." && textBoxMinPrizeWinAmount.Text != "-")
            {
                //DE12916 Refuse negative min prize win amount values to be saved
                m_errorProvider.Clear();
                if (Convert.ToDecimal(textBoxMinPrizeWinAmount.Text) <= 0)
                {
                    //Add error notification on screen
                    m_errorProvider.SetError(textBoxMinPrizeWinAmount, "Negative values not allowed; returning to last saved value.");
                    //Revert to last saved
                    string tempString = Common.GetSystemSetting(Setting.TaxFormMinWinAmount);
                    textBoxMinPrizeWinAmount.Text = tempString;
                    return false;
                }
                else
                    textBoxMinPrizeWinAmount.Text = Convert.ToDecimal(textBoxMinPrizeWinAmount.Text).ToString("F2");
            }
            else if (string.IsNullOrEmpty(textBoxMinPrizeWinAmount.Text))
            {
                //DE12939 Refuse save if box is empty
                m_errorProvider.Clear();
                m_errorProvider.SetError(textBoxMinPrizeWinAmount, "Value must be filled in to save");
                return false;
            }
            //else
                //textBoxMinPrizeWinAmount.Text = "1199.99";

            s.Value = textBoxMinPrizeWinAmount.Text;
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }
            //Update local copy

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

        #endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkMasterBankUsePreviousClose.Focus();
        }

        //START RALLY US1572
        private void radioButtonFeePercent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFeePercent.Checked) //was doing both every time it changed
            {
                m_errorProvider.Clear();
                labelFeePercent.Visible = true;
                textBoxFeeAmount.Width = initialWidth;
                 m_feeType = 2;
                //DE8583
                 textBoxFeeAmount.MaxLength = 6;
                 float FeePercent;
                 if (float.TryParse(textBoxFeeAmount.Text, out FeePercent))
                 {
                     if (FeePercent < 0.0 || FeePercent > 100.0)
                     {

                         m_errorProvider.SetError(labelFeePercent, Resources.ErrorNumber);
                         btnSave.Enabled = false;
                     }

                 }
            }
        }

        private void radioButtonFeeFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFeeFixed.Checked) //was doing both every time it changed
            {
                m_errorProvider.Clear();
                labelFeePercent.Visible = false;
                textBoxFeeAmount.Width = textBoxMinimumPrizeAmount.Width;
                m_feeType = 1;
                //DE8583
                textBoxFeeAmount.MaxLength = 16;
            }
        }


        private void textBoxMinimumPrizeAmount_TextChanged(object sender, EventArgs e)
        {
            bool result = true;
            m_errorProvider.Clear();
            btnSave.Enabled = true;           
            result = ValidateFields();
            btnSave.Enabled = result;
            if (result)
            {
                m_bModified = true; //RALLY DE9055
            }
        }       

        //DE8583
        private void textBoxFeeAmount_TextChanged(object sender, EventArgs e)
        {
            bool result = true;
            m_errorProvider.Clear();
            btnSave.Enabled = true;
            if (m_feeType == 1)
            {                
                result=ValidateFields();
            }
            else if (m_feeType == 2)
            {               
                if (Validator.ValidatePercent(textBoxFeeAmount.Text))
                {
                    result = true;
                }
                else
                {
                    m_errorProvider.SetError(labelFeePercent, Resources.ErrorNumber);
                    result = false;
                }

            }
            btnSave.Enabled = result;
            if (result)
            {
                m_bModified = true; //RALLY DE9055
            }
        }

        //US4609
        private void textBoxMinPrizeWinAmount_TextChanged(object sender, EventArgs e)
        {
            bool result = true;
            m_errorProvider.Clear();
            btnSave.Enabled = true;
            result = ValidateFields();
            btnSave.Enabled = result;
            if (result)
            {
                m_bModified = true;
            }
        }

        //Start Rally DE9805
        /// <summary>
        /// Validates PrizeFee and PrizeMinAmount TextBoxes
        /// </summary>
        /// <returns></returns>
        private bool ValidateFields()
        {
            bool result=true;
            decimal prizeAmount;
            decimal.TryParse(textBoxMinimumPrizeAmount.Text, out prizeAmount);
            decimal feeAmount;
            decimal.TryParse(textBoxFeeAmount.Text, out feeAmount);
            decimal minPrize;
            decimal.TryParse(textBoxMinPrizeWinAmount.Text, out minPrize);

            if (prizeAmount < 0 || feeAmount < 0 || minPrize < 0)
            {
                if (prizeAmount < 0)
                {
                    m_errorProvider.SetError(textBoxMinimumPrizeAmount, Resources.ErrorNumber);
                    result = false;
                }
                if (minPrize < 0)
                {
                    m_errorProvider.SetError(textBoxMinPrizeWinAmount, Resources.ErrorNumber);
                    result = false;
                }
                if (feeAmount < 0)
                {
                    m_errorProvider.SetError(textBoxFeeAmount, Resources.ErrorNumber);
                    result = false;
                }

            }
            else
            {
                result = true;
            }
            return result;
        }
        //End Rally DE 9805


        //END RALLY US1572

    } // end class
} // end namespace
