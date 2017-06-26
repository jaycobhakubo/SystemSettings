//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

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
        bool m_bModified = false;
        private TreeNode m_TreeNodeParent;
        private List<Business.GenericCBOItem> lstComPortKioskBillAcceptor = new List<Business.GenericCBOItem>();
      //  private const int RF_DISABLED_INDEX = 0;

        public KioskSalesSettings()
        {
            m_TreeNodeParent = null;
            InitializeComponent();
            SetComboboxComPort();
        }

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


        //public override bool SaveSettings()
        //{
        //    Common.BeginWait();

        //    bool bResult = SaveKioskSalesSettings();

        //    Common.EndWait();

        //    return bResult;
        //}

        private bool LoadKioskSalesSettings()
        {
            int result = 0;
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
                saveFlag = true;
            }

            //360
            tempString = Common.GetSystemSetting(Setting.AllowBarcodedPaperToBeSoldAtSimpleKiosk);
            if (bool.TryParse(tempString, out boolResult))
            {
                 chkbxAutomaticBarcodedPaperSold.Checked = boolResult;
            }
            else
            {
                chkbxAutomaticBarcodedPaperSold.Checked = false;
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

            tempString = Common.GetSystemSetting(Setting.KioskPeripheralsTicketPrinterName);
            txtbxKioskTicketPrinterName.Text = tempString;
    


            //tempString = Common.GetSystemSetting(Setting.KioskPeripheralsTicketPrinterName);
            //if (bool.TryParse(tempString, out boolResult))
            //{
            //    chkbxIncludeCouponsButton.Checked = boolResult;
            //}
            //else
            //{
            //    chkbxIncludeCouponsButton.Checked = false;
            //    saveFlag = true;
            //}

            return boolResult;
        }

    }
}
