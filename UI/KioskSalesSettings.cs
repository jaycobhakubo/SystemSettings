using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class KioskSalesSettings : SettingsControl
    {

        #region Member
        private bool m_bModified = false;
        private TreeNode m_TreeNodeParent;
        private List<Business.GenericCBOItem> lstComPortKioskBillAcceptor = new List<Business.GenericCBOItem>();
        #endregion

        #region Constructor
        public KioskSalesSettings()
        {
            m_TreeNodeParent = null;
            InitializeComponent();
            SetComboboxComPort();
        }
        #endregion

        #region Methos

        private void SetComboboxComPort()
        {
            for (int i = 0; i < 14; i++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = i;
                switch (i)
                {
                    case 0:
                        cboItem.CBODisplayMember = "Disabled";
                        break;
                    default:
                        cboItem.CBODisplayMember = "COM" + i.ToString();
                        break;
                }

                lstComPortKioskBillAcceptor.Add(cboItem);
            }
            cboKioskBillAcceptorComPort.Items.Clear();
            cboKioskBillAcceptorComPort.DataSource = lstComPortKioskBillAcceptor;
            cboKioskBillAcceptorComPort.DisplayMember = "CBODisplayMember";
            cboKioskBillAcceptorComPort.ValueMember = "CBOValueMember";
        }

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

            bool bResult = LoadKioskSalesSettings();
            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }


        private bool LoadKioskSalesSettings()
        {
            //int result = 0;
            bool boolResult = false;
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
                //saveFlag = true;
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
                //saveFlag = true;
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
                //saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.KioskPeripheralsTicketPrinterName);
            txtbxKioskTicketPrinterName.Text = tempString;
        
            tempString = Common.GetSystemSetting(Setting.KioskPeripheralsAcceptorComPort);
            try//If theres any issue just set to 0
            {
                
                int tempSelectedIndex = 0;
                bool tempResult = int.TryParse(tempString, out tempSelectedIndex);

                if (tempResult)//If the setting is not numeric set it  as  disable
                {
                    cboKioskBillAcceptorComPort.SelectedIndex = tempSelectedIndex;               
                }
                else
                {
                    cboKioskBillAcceptorComPort.SelectedIndex = 0;
                    saveFlag = true;
                }          
            }
            catch
            {
                cboKioskBillAcceptorComPort.SelectedIndex = 0;
                saveFlag = true;
            }

            m_bModified = false;

            if (saveFlag == true)
            {
                SaveKioskSalesSettings();//Fixed it now
            }           
                return true;
        }
        #endregion

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveKioskSalesSettings();

            Common.EndWait();

            return bResult;
        }

        private bool SaveKioskSalesSettings()
        {
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue setting = new SettingValue();
            
            setting.Id = (int)Setting.AutomaticallyApplyCouponsToSalesOnSimpleKiosks;
            setting.Value = chkbxAutomaticApplyCouponToSales.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowBarcodedPaperToBeSoldAtSimpleKiosk;
            setting.Value = chkbxAllowBarcodedPaperSold.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.IncludeTheCouponsButtonOnTheHybridKiosk;
            setting.Value = chkbxIncludeCouponsButton.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.AllowUseOfSimpleKioskWithoutPlayerCard;
            setting.Value = chkbxAllowUseOfSimpleKiosk.Checked.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskPeripheralsAcceptorComPort;
            setting.Value = cboKioskBillAcceptorComPort.SelectedValue.ToString();
            arrSettings.Add(setting);

            setting.Id = (int)Setting.KioskPeripheralsTicketPrinterName;
            setting.Value = txtbxKioskTicketPrinterName.Text;
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

    }
}
