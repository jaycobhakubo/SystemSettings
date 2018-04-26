using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class TenderSettings : SettingsControl
    {
                //Members
        bool m_bModified = false;

        private class TenderType
        {
            public string name = string.Empty;
            public int ID = 0;

            public TenderType(string name, int ID)
            {
                this.name = name;
                this.ID = ID;
            }

            public override string ToString()
            {
                return name;
            }
        }

        //Public Methods
        #region Public Methods
        public TenderSettings()
        {
            InitializeComponent();

/*            //cboCheckVoidType.Items.Clear();
            cboCheckVoidType.Items.Add(Resources.DisallowVoid);
            cboCheckVoidType.Items.Add(Resources.ReturnCheck);
            cboCheckVoidType.Items.Add(Resources.RefundInCash);
            cboCheckVoidType.SelectedIndex = 0;
 */
            m_bModified = false;
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

            bool bResult = LoadTenderSettings();

            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveTenderSettings();

            Common.EndWait();

            return bResult;
        }

        #endregion // Public Methods

        #region Private Routines

        private bool LoadTenderSettings()
        {
            SettingValue tempSettingValue;

            GTI.Modules.Shared.Data.GetTenderTypesMessage getTenders = new Shared.Data.GetTenderTypesMessage();

            getTenders.Send();

            clbActiveTenders.Items.Clear();

            foreach (TenderTypeValue ttv in getTenders.TenderTypes)
            {
                clbActiveTenders.SetItemChecked(clbActiveTenders.Items.Add(new TenderType(ttv.TenderName, ttv.TenderTypeID)), ttv.IsActive != 0);
            }

            clbActiveTenders.Sorted = true;

            if (Common.GetSystemSettings() == false)
            {
                return false;
            }

            Common.GetOpSettingValue(Setting.EnableFlexTendering, out tempSettingValue);
            flexTendering.Checked = Common.ParseBool(tempSettingValue.Value);
           
            panelFlexTendering.Visible = flexTendering.Checked;

            Common.GetOpSettingValue(Setting.AllowSplitTendering, out tempSettingValue);
            splitTendering.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.Use00ForCurrencyEntry, out tempSettingValue);
            chkUse00.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PrintCustomerAndHallReceiptsForNonCashSales, out tempSettingValue);
            printDualReceipts.Checked = Common.ParseBool(tempSettingValue.Value);

            //load allowed tenders box
            clbAllowedTenders.Items.Clear();

            Common.GetOpSettingValue(Setting.AllowCreditCards, out tempSettingValue);
            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(new TenderType("Credit Cards", (int)Setting.AllowCreditCards)), Common.ParseBool(tempSettingValue.Value));

            Common.GetOpSettingValue(Setting.AllowDebitCards, out tempSettingValue);
            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(new TenderType("Debit Cards", (int)Setting.AllowDebitCards)), Common.ParseBool(tempSettingValue.Value));

            Common.GetOpSettingValue(Setting.AllowGiftCards, out tempSettingValue);
            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(new TenderType("Gift Cards", (int)Setting.AllowGiftCards)), Common.ParseBool(tempSettingValue.Value));

            Common.GetOpSettingValue(Setting.AllowCash, out tempSettingValue);
            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(new TenderType("Cash", (int)Setting.AllowCash)), Common.ParseBool(tempSettingValue.Value));

            Common.GetOpSettingValue(Setting.AllowChecks, out tempSettingValue);
            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(new TenderType("Checks", (int)Setting.AllowChecks)), Common.ParseBool(tempSettingValue.Value));

            clbAllowedTenders.Sorted = true;

            m_bModified = false;
            return true;
        }

        private bool SaveTenderSettings()
        {
            GTI.Modules.Shared.Data.SetTenderTypesStatusMessage setTenders = new Shared.Data.SetTenderTypesStatusMessage();
            List<TenderTypeValue> ttvList = new List<TenderTypeValue>();
            TenderTypeValue ttv = new TenderTypeValue();

            for(int x = 0; x < clbActiveTenders.Items.Count; x++)
            {
                ttv.TenderTypeID = ((TenderType)clbActiveTenders.Items[x]).ID;
                ttv.IsActive = (clbActiveTenders.GetItemChecked(x)?(byte)1:(byte)0);
                ttvList.Add(ttv);
            }

            setTenders.TenderTypes = ttvList;

            setTenders.Send();

            List<SettingValue> tSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.EnableFlexTendering;
            s.Value = flexTendering.Checked.ToString();
            tSettings.Add(s);

            s = new SettingValue();
            s.Id = (int)Setting.AllowSplitTendering;
            s.Value = splitTendering.Checked.ToString();
            tSettings.Add(s);

            s = new SettingValue();
            s.Id = (int)Setting.Use00ForCurrencyEntry;
            s.Value = chkUse00.Checked.ToString();
            tSettings.Add(s);

            for (int x = 0; x < clbAllowedTenders.Items.Count; x++)
            {
                s = new SettingValue();
                s.Id = ((TenderType)clbAllowedTenders.Items[x]).ID;
                s.Value = clbAllowedTenders.GetItemChecked(x).ToString();
                tSettings.Add(s);
            }
            
            s = new SettingValue();
            s.Id = (int)Setting.PrintCustomerAndHallReceiptsForNonCashSales;
            s.Value = printDualReceipts.Checked.ToString();
            tSettings.Add(s);

            if (!Common.SaveSystemSettings(tSettings.ToArray()))
                return false;

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

        private void OnFlexTenderingChanged(object sender, EventArgs e)
        {
            panelFlexTendering.Visible = flexTendering.Checked;
            m_bModified = true;
        }

        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        #endregion 

        private void OnModified(object sender, ItemCheckEventArgs e)
        {
            m_bModified = true;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }
    }
}
