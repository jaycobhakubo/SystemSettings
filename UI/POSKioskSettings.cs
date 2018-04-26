using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class POSKioskSettings : SettingsControl
    {
        public enum OptionsForGivingChange
        {
            Normal = 0,
            B3Credit = 1,
            B3CreditOrNormal = 2,
            B3CreditWithAddOn = 3,
            B3CreditWithAddOnOrNormal = 4
        }

        #region Member Variables

        private bool m_bModified = false;
        private TreeNode m_TreeNodeParent;
        private List<Business.GenericCBOItem> lstComPortKioskBillAcceptor = new List<Business.GenericCBOItem>();
        
        #endregion

        #region Constructor

        public POSKioskSettings()
        {
            m_TreeNodeParent = null;
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void SetTreeNode(TreeNode parent)
        {
            m_TreeNodeParent = parent;
        }

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

            bool bResult = LoadPOSKioskSettings();
            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        private bool LoadPOSKioskSettings()
        {
            int result = 0;
            bool boolResult = false;
            decimal decimalResult = 0;
            bool saveFlag = false;

            //359
            string tempString = Common.GetSystemSetting(Setting.AutomaticallyApplyCouponsToSalesOnSimpleKiosks);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAutomaticApplyCouponToSales.Checked = boolResult;
            }
            else
            {
                chkbxAutomaticApplyCouponToSales.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.AllowKiosksToPrintCBBPlayItSheetsFromReceiptScan);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowCBBSheets.Checked = boolResult;
            }
            else
            {
                chkbxAllowCBBSheets.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.UseKeyClickSoundsOnKiosk);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxUseKeyClickSounds.Checked = boolResult;
            }
            else
            {
                chkbxUseKeyClickSounds.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.KioskChangeDispensingMethod);
            result = 0;
            int.TryParse(tempString, out result);
            comboChangeMethod.SelectedIndex = result;

            tempString = Common.GetSystemSetting(Setting.KiosksCanOnlySellFromTheirButtons);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxOnlySellFromButtons.Checked = boolResult;
            }
            else
            {
                chkbxOnlySellFromButtons.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.AllowB3SalesOnAPOSKiosk);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowB3.Checked = boolResult;
            }
            else
            {
                chkbxAllowB3.Checked = false;
                saveFlag = true;
            }

            //360
            tempString = Common.GetSystemSetting(Setting.AllowBarcodedPaperToBeSoldAtSimpleKiosk);

            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowBarcodedPaperSold.Checked = boolResult;
            }
            else
            {
                chkbxAllowBarcodedPaperSold.Checked = false;
                saveFlag = true;
            }

            //361
            tempString = Common.GetSystemSetting(Setting.IncludeTheCouponsButtonOnTheHybridKiosk);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxIncludeCouponsButton.Checked = boolResult;
            }
            else
            {
                chkbxIncludeCouponsButton.Checked = false;
                saveFlag = true;
            }

            //384
            tempString = Common.GetSystemSetting(Setting.AllowUseLastPurchaseButtonOnKiosk);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxIncludeUseLastPurchaseButton.Checked = boolResult;
            }
            else
            {
                chkbxIncludeUseLastPurchaseButton.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.AllowScanningProductsOnSimplePOSKiosk);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowScanningProducts.Checked = boolResult;
            }
            else
            {
                chkbxAllowScanningProducts.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.AllowUseOfSimpleKioskWithoutPlayerCard);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowUseOfSimpleKioskWithoutPlayerCard.Checked = boolResult;
            }
            else
            {
                chkbxAllowUseOfSimpleKioskWithoutPlayerCard.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.UseSimplePaymentFormForAdvancedKiosk);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxUseSimplePaymentForAdvancedKiosk.Checked = boolResult;
            }
            else
            {
                chkbxUseSimplePaymentForAdvancedKiosk.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.AllowCreditCardsOnKiosks);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkbxAllowCreditDebitOnKiosk.Checked = boolResult;
            }
            else
            {
                chkbxAllowCreditDebitOnKiosk.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.KioskPeripheralsTicketPrinterName);
            txtbxKioskTicketPrinterName.Text = tempString;
        
            tempString = Common.GetSystemSetting(Setting.KioskGuardianAddress);
            txtbxGuardianAddressAndPort.Text = tempString;

            m_IdleText.Text = Common.GetSystemSetting(Setting.KioskAttractText);

            m_closedText.Text = Common.GetSystemSetting(Setting.KioskClosedText);

            if (Decimal.TryParse(Common.GetSystemSetting(Setting.KioskIdleTimeout), out decimalResult))
            {
                if (decimalResult < m_nudTimeout.Minimum)
                {
                    decimalResult = m_nudTimeout.Minimum;
                    saveFlag = true;
                }

                if (decimalResult > m_nudTimeout.Maximum)
                {
                    decimalResult = m_nudTimeout.Maximum;
                    saveFlag = true;
                }

                m_nudTimeout.Value = decimalResult;
            }
            else
            {
                m_nudTimeout.Value = 30;
                saveFlag = true;
            }

            if (Decimal.TryParse(Common.GetSystemSetting(Setting.KioskShortIdleTimeout), out decimalResult))
            {
                if (decimalResult < m_nudShortTimeout.Minimum)
                {
                    decimalResult = m_nudShortTimeout.Minimum;
                    saveFlag = true;
                }

                if (decimalResult > m_nudShortTimeout.Maximum)
                {
                    decimalResult = m_nudShortTimeout.Maximum;
                    saveFlag = true;
                }

                m_nudShortTimeout.Value = decimalResult;
            }
            else
            {
                m_nudShortTimeout.Value = 15;
                saveFlag = true;
            }

            if (Decimal.TryParse(Common.GetSystemSetting(Setting.KioskMessageTimeout), out decimalResult))
            {
                if (decimalResult < m_nudMessageTimeout.Minimum)
                {
                    decimalResult = m_nudMessageTimeout.Minimum;
                    saveFlag = true;
                }

                if (decimalResult > m_nudMessageTimeout.Maximum)
                {
                    decimalResult = m_nudMessageTimeout.Maximum;
                    saveFlag = true;
                }

                m_nudMessageTimeout.Value = decimalResult;
            }
            else
            {
                m_nudMessageTimeout.Value = 10;
                saveFlag = true;
            }

            if (Decimal.TryParse(Common.GetSystemSetting(Setting.KioskVideoVolume), out decimalResult))
            {
                if (decimalResult < nudVideoVolume.Minimum)
                {
                    decimalResult = nudVideoVolume.Minimum;
                    saveFlag = true;
                }

                if (decimalResult > nudVideoVolume.Maximum)
                {
                    decimalResult = nudVideoVolume.Maximum;
                    saveFlag = true;
                }

                nudVideoVolume.Value = decimalResult;
            }
            else
            {
                nudVideoVolume.Value = 100;
                saveFlag = true;
            }

            m_bModified = false;

            if (saveFlag)
                SavePOSKioskSettings();//Fixed it now

            return true;
        }

        #endregion

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SavePOSKioskSettings();

            Common.EndWait();

            return bResult;
        }

        private bool SavePOSKioskSettings()
        {
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue setting = new SettingValue();
            
            setting.Id = (int)Setting.AutomaticallyApplyCouponsToSalesOnSimpleKiosks;
            setting.Value = chkbxAutomaticApplyCouponToSales.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskChangeDispensingMethod;
            setting.Value = comboChangeMethod.SelectedIndex.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowKiosksToPrintCBBPlayItSheetsFromReceiptScan;
            setting.Value = chkbxAllowCBBSheets.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.UseKeyClickSoundsOnKiosk;
            setting.Value = chkbxUseKeyClickSounds.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskVideoVolume;
            setting.Value = nudVideoVolume.Value.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KiosksCanOnlySellFromTheirButtons;
            setting.Value = chkbxOnlySellFromButtons.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowB3SalesOnAPOSKiosk;
            setting.Value = chkbxAllowB3.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowCreditCardsOnKiosks;
            setting.Value = chkbxAllowCreditDebitOnKiosk.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowBarcodedPaperToBeSoldAtSimpleKiosk;
            setting.Value = chkbxAllowBarcodedPaperSold.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowScanningProductsOnSimplePOSKiosk;
            setting.Value = chkbxAllowScanningProducts.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.IncludeTheCouponsButtonOnTheHybridKiosk;
            setting.Value = chkbxIncludeCouponsButton.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowUseLastPurchaseButtonOnKiosk;
            setting.Value = chkbxIncludeUseLastPurchaseButton.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowUseOfSimpleKioskWithoutPlayerCard;
            setting.Value = chkbxAllowUseOfSimpleKioskWithoutPlayerCard.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.UseSimplePaymentFormForAdvancedKiosk;
            setting.Value = chkbxUseSimplePaymentForAdvancedKiosk.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskGuardianAddress;
            setting.Value = txtbxGuardianAddressAndPort.Text;
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskPeripheralsTicketPrinterName;
            setting.Value = txtbxKioskTicketPrinterName.Text;
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskAttractText;
            setting.Value = m_IdleText.Text;
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskClosedText;
            setting.Value = m_closedText.Text;
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskIdleTimeout;
            setting.Value = m_nudTimeout.Value.ToString();
            arrSettings.Add(setting);
            
            setting.Id = (int)Setting.KioskShortIdleTimeout;
            setting.Value = m_nudShortTimeout.Value.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskMessageTimeout;
            setting.Value = m_nudMessageTimeout.Value.ToString();
            arrSettings.Add(setting);

            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void txtbxGuardianAddressAndPort_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtbxGuardianAddressAndPort.Text == string.Empty)
            {
                e.Cancel = false;
                return;
            }

            //parse into nnn.nnn.nnn.nnn:ppppp  where nnn=0-255 and ppppp=1024-65535
            string[] address = txtbxGuardianAddressAndPort.Text.Split(new char[] { '.', ':' });
            int[] part = new int[5];
            bool failed = false;

            try
            {
                if (address.Length != 5)
                    failed = true;

                for (int x = 0; x < 5; x++)
                {
                    int test = 0;

                    if (!(int.TryParse(address[x], out test) && ((x < 4 && test >= 0 && test <= 255) || (x == 4 && test >= 1024 && test <= 65535))))
                    {
                        failed = true;
                        break;
                    }
                    else
                    {
                        part[x] = test;
                    }
                }
            }
            catch(Exception)
            {
                failed = true;
            }

            e.Cancel = failed;

            if (failed)
                MessageForm.Show("Invalid IP:Port.\r\n\r\nnnn.nnn.nnn.nnn:ppppp where nnn=0-255 and ppppp=1025-65535.");
            else
                txtbxGuardianAddressAndPort.Text = string.Format("{0:D}.{1:D}.{2:D}.{3:D}:{4:D}", part[0], part[1], part[2], part[3], part[4]);
        }
    }
}
