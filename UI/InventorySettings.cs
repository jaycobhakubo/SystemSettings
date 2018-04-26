#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All rights reserved.
//
// US4039 Adding improved support for checking for duplicates when issuing
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class InventorySettings : SettingsControl
    {
        //Members
        private bool m_bModified = false;
        public InventorySettings()
        {
            InitializeComponent();
        }
        
        //Public Methods
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

            bool bResult = LoadInventorySettings();
            
            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveInventorySettings();

            Common.EndWait();

            return bResult;
        }

        
        private bool LoadInventorySettings()
        {
            SettingValue tempSettingValue;
            int tempValue;
            bool saveFlag = false;
            m_rdoAuditNumbers.Enabled = true;
            m_rdoQuantity.Enabled = true;
           
            //track by product or serial number setting 57
            Common.GetOpSettingValue(Setting.OpPaperTrackingType, out tempSettingValue);
           
            if(int.TryParse( tempSettingValue.Value,out tempValue))
            {
                //track by product
                if(tempValue == 0)
                {
                    m_rdoTrackByProduct.Checked = true;
                }
                //track by serial number
                else if(tempValue == 1)
                {
                    m_rdoTrackBySerial.Checked = true;
                }
            }
            
            //track by audit number (Has to have serial number tracking enabled) setting number 61
            Common.GetOpSettingValue(Setting.OpIssueBySerial, out tempSettingValue);
            if(int.TryParse(tempSettingValue.Value,out tempValue))
            {
                if(tempValue == 0)
                {
                    m_rdoQuantity.Checked = true;
                }
                else if(tempValue == 1)
                {
                    m_rdoAuditNumbers.Checked = true;
                }
            }

            if (m_rdoTrackByProduct.Checked == true)
            {
                if ( m_rdoAuditNumbers.Checked == true)
                {
                    m_rdoQuantity.Checked = true;
                    saveFlag = true;
                }
                m_rdoAuditNumbers.Enabled = false;
                m_rdoQuantity.Enabled = false;
            }

            //Allow issue to exceed Quantity
            Common.GetOpSettingValue(Setting.AllowNegativeInventory, out tempSettingValue);
            m_chkAllowIssuesToExceed.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            bool result;
            
            //START RALLY TA 9264
            //auto retire on zero items
            Common.GetOpSettingValue(Setting.OpRetireOnZeroInv, out tempSettingValue);
            m_chkAutoRetire.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

            //START RALLY US1926
            Common.GetOpSettingValue(Setting.PrintReconcileRecipt, out tempSettingValue);
            chkPrintReconcileReceipt.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            //END RALLY US1926

            //US4039
            Common.GetOpSettingValue(Setting.CheckPaperForDuplicates, out tempSettingValue);
            m_chkCheckForDuplicates.Checked = ParseBool(tempSettingValue.Value);
            // If either of these items are not set then reset the duplicates flag
            if (m_rdoTrackBySerial.Checked == false || m_rdoAuditNumbers.Checked == false)
            {
                if (m_chkCheckForDuplicates.Checked)
                {
                    m_chkCheckForDuplicates.Checked = false;
                    saveFlag = true;
                }

                m_chkCheckForDuplicates.Enabled = false;
            }
            
            Common.GetOpSettingValue(Setting.DefaultReduceAtRegister, out tempSettingValue);
            if (bool.TryParse(tempSettingValue.Value, out result))
            {
                if (result == true)
                {
                    m_rdoReduceAtRegisterTrue.Checked = true;
                }
                else
                {
                    m_rdoReduceAtRegisterFalse.Checked = true;
                }
            }
            //END RALLY TA 9264

            //START RALLY DE7124
            if (m_chkAllowIssuesToExceed.Checked == true || m_rdoTrackByProduct.Checked == true)
            {
                if (m_chkAutoRetire.Checked == true)
                {
                    saveFlag = true;
                }
                m_chkAutoRetire.Checked = false;
                m_chkAutoRetire.Enabled = false;
            }
            else
            {
                m_chkAutoRetire.Enabled = true;
            }

            if (m_chkAutoRetire.Checked == true)
            {
                if (m_chkAllowIssuesToExceed.Checked == true)
                {
                    saveFlag = true;
                }
                m_chkAllowIssuesToExceed.Checked = false;
                m_chkAllowIssuesToExceed.Enabled = false;
            }
            else
            {
                m_chkAllowIssuesToExceed.Enabled = true;
            }

            //END RALLY DE7124
            if (saveFlag)
            {
                SaveSettings();
            }
            m_bModified = false;
            return true;
        }

        private bool SaveInventorySettings()
        {
            int tempValue;
            m_bModified = false;

            if (m_rdoTrackByProduct.Checked)
            {
                tempValue = 0;
            }
            else
            {
                tempValue = 1;
            }
            Common.SetOpSettingValue(Setting.OpPaperTrackingType, tempValue.ToString());

            if (m_rdoAuditNumbers.Checked == true)
            {
                tempValue = 1;
            }
            else
            {
                tempValue = 0;
            }
            Common.SetOpSettingValue(Setting.OpIssueBySerial, tempValue.ToString());

            Common.SetOpSettingValue(Setting.PrintReconcileRecipt, chkPrintReconcileReceipt.Checked.ToString());//RALLY US1926

            Common.SetOpSettingValue(Setting.AllowNegativeInventory, m_chkAllowIssuesToExceed.Checked.ToString());

            Common.SetOpSettingValue(Setting.OpRetireOnZeroInv, m_chkAutoRetire.Checked.ToString());//RALLY TA 9264

            //START RALLY TA 9264
            Common.SetOpSettingValue(Setting.DefaultReduceAtRegister, m_rdoReduceAtRegisterTrue.Checked.ToString());
            //END RALLY TA 9264

            //US4039
            Common.SetOpSettingValue(Setting.CheckPaperForDuplicates, m_chkCheckForDuplicates.Checked.ToString());

            return Common.SaveOperatorSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInventorySettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadInventorySettings();
        }

        private void m_rdoTrackByProduct_Click(object sender, EventArgs e)
        {
            m_rdoQuantity.Checked = true;
            m_rdoQuantity.Enabled = false;
            m_rdoAuditNumbers.Enabled = false;
            m_chkAutoRetire.Enabled = false;
            m_chkAutoRetire.Checked = false;
            m_chkAllowIssuesToExceed.Enabled = true;
            m_bModified = true;

            // US4039
            m_chkCheckForDuplicates.Checked = false;
            m_chkCheckForDuplicates.Enabled = false;
        }

        private void m_rdoTrackBySerial_Click(object sender, EventArgs e)
        {
            if (m_rdoAuditNumbers.Enabled == false)
            {
                m_rdoAuditNumbers.Enabled = true;
                m_rdoQuantity.Enabled = true;
            }
            
            m_chkAutoRetire.Enabled = true;
            
            //US4039
            if (m_rdoAuditNumbers.Checked)
            {
                m_chkCheckForDuplicates.Enabled = true;
            }
            
            m_bModified = true;
        }

        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;

            if (m_rdoAuditNumbers.Checked && m_rdoTrackBySerial.Checked)
            {
                m_chkCheckForDuplicates.Enabled = true;
            }
            else
            {
                m_chkCheckForDuplicates.Checked = false;
                m_chkCheckForDuplicates.Enabled = false;
            }
        }

        //START RALLY DE7124

        private void OnAllowIssuesToExceedModified(object sender, EventArgs e)
        {
            if (m_chkAllowIssuesToExceed.Checked == true)
            {
                m_chkAutoRetire.Checked = false;
                m_chkAutoRetire.Enabled = false;
            }
            else if(m_rdoTrackBySerial.Checked == true)
            {
                m_chkAutoRetire.Enabled = true;
            }
            m_bModified = true;
        }

        private void OnAutoRetireModified(object sender, EventArgs e)
        {
            if (m_chkAutoRetire.Checked == true)
            {
                m_chkAllowIssuesToExceed.Checked = false;
                m_chkAllowIssuesToExceed.Enabled = false;
            }
            else
            {
                m_chkAllowIssuesToExceed.Enabled = true;
            }
            m_bModified = true;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }
        //END RALLY DE7124
        
    }
}
