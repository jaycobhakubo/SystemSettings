using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class ValidationSettings : SettingsControl
    {
        // Members
        bool m_bModified = false;
        private TreeNode m_TreeNodeParent;

        public ValidationSettings()
        {
            m_TreeNodeParent = null;
            InitializeComponent();
        }

        #region METHODS

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

            bool bResult = LoadValidateSettings();
            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }


        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveSecuritySettings();

            Common.EndWait();

            return bResult;
        }

        private bool SaveSecuritySettings()
        {

            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.EnableValidation;
            s.Value = chkbxEnableValidation.Checked.ToString();
            //if (chkbxEnableValidation.Checked == true)
            //{
            //    s.Value = "True";
            //}
            //else
            //{
            //    s.Value = "False";
            //}
             arrSettings.Add(s);


             s.Id = (int)Setting.ProductValidationCardCount;
             s.Value = cmbxCardCount.SelectedItem.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.MaxValidationPerTransaction;
            s.Value = txtbxValidationMaxPerTransaction.Text;
            arrSettings.Add(s);

      
            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool LoadValidateSettings()
        {
            string SettingValue = "";
            int intResult = 0;
            bool boolResult = false;
            decimal decimalresult = 0M;

            //ENABLE VALIDATION SETTING
            SettingValue = Common.GetSystemSetting(Setting.EnableValidation);
            if (bool.TryParse(SettingValue, out boolResult))
            {
                if (boolResult == true)
                {
                    chkbxEnableValidation.Checked = true;
                }
                else
                {
                    if (chkbxEnableValidation.Checked == false) chkbxEnableValidation.Checked = true;
                    chkbxEnableValidation.Checked = false;
                }
            }

            //PRODUCT CARD COUNT
            LoadCardCount();
            SettingValue = Common.GetSystemSetting(Setting.ProductValidationCardCount);
            if (int.TryParse(SettingValue, out intResult))
            {
                if (intResult == 0)
                {
                    cmbxCardCount.SelectedIndex = 0;
                }
                else
                if (intResult == 1)
                {
                    cmbxCardCount.SelectedIndex = 1;
                }
                else
                if (intResult == 3)
                {
                    cmbxCardCount.SelectedIndex = 2;
                }
                else if (intResult == 6)
                {
                    cmbxCardCount.SelectedIndex = 3;
                }
            }
            
            SettingValue = Common.GetSystemSetting(Setting.MaxValidationPerTransaction);
            if (decimal.TryParse(SettingValue, out decimalresult))
            {
                txtbxValidationMaxPerTransaction.Text = decimalresult.ToString();
            }
            m_bModified = false;
            return true; 
        }

        private void LoadCardCount()//Hardcoded
        {
            if (cmbxCardCount.Items.Count > 0)
            {
                cmbxCardCount.Items.Clear();
            }

            cmbxCardCount.Items.Add("0");
            cmbxCardCount.Items.Add("1");
            cmbxCardCount.Items.Add("3");
            cmbxCardCount.Items.Add("6");
        }

        private bool ValidateFields(string txt)
        {
            int value;
            if (int.TryParse(txt, out value))
            {
                if (value >= 0 && value < 101)
                {
                    return true;
                }
            }

            return false;
        }

        private void HideControls()
        {
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox && Convert.ToString(c.Tag) == "grpbxValidationSettings")
                {

                    foreach (Control c2 in c.Controls)
                    {
                        if (c2 is CheckBox && Convert.ToString(c2.Tag) == "chkbxEnableValidation")
                        {
                            //c2.Visible = true;
                        }
                        else
                        {
                            c2.Visible = false;
                        }
                    }
                 
                }
    
                //else
                //{
                //    c.Visible = false;
                //}

            }
        }

        private void ShowControls()
        {
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox && c.Tag.ToString() == "grpbxValidationSettings")
                {

                    foreach (Control c2 in c.Controls)
                    {
                        if (c2 is CheckBox && Convert.ToString(c2.Tag) == "chkbxEnableValidation")
                        {
                            //c2.Visible = true;
                        }
                        else
                        {
                            c2.Visible = true;
                        }
                    }
                }
                //else
                //{
                //    c.Visible = true;
                //}

            }
        }

        #endregion

        #region EVENTS

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

        private void txtbxValidationMaxPerTransaction_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            btnSave.Enabled = true;
            var result = ValidateFields(txt.Text);
            btnSave.Enabled = result;
            if (result)
            {
                string SettingValue = "";
                decimal decimalresult;
                SettingValue = Common.GetSystemSetting(Setting.MaxValidationPerTransaction);
                if (decimal.TryParse(SettingValue, out decimalresult))
                {
                   
                }

                if (Convert.ToDecimal(txtbxValidationMaxPerTransaction.Text) != decimalresult )
                {
                    m_bModified = true; 
                }
                else
                {
                    m_bModified = false; 
                }
            }
        }

        /// <summary>
        /// Igonore non-integer input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxValidationMaxPerTransaction_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool result = true;
            if (e.KeyChar == (char)Keys.Back)
            {
                result = false;
                
            }
            if(result)
            {
                result = !char.IsDigit(e.KeyChar);
            }
            m_bModified = true; 
            e.Handled = result;
        }
        

      

        private void chkbxEnableValidation_CheckedChanged(object sender, EventArgs e)
        {
            bool IsChecked = false;
            if (chkbxEnableValidation.Checked == true)
            {
                IsChecked = true;
                ShowControls();
            }
            else
            {
                IsChecked = false;
                HideControls();
            }

             string SettingValue = "";
            bool boolResult;
             SettingValue = Common.GetSystemSetting(Setting.EnableValidation);
             bool.TryParse(SettingValue, out boolResult);

             if (IsChecked != boolResult)
             {
                 m_bModified = true;
             }
             else
             {
                 m_bModified = false;
             }
        }

        #endregion

        private void cmbxCardCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SettingValue = "";
            int intResult;
            SettingValue = Common.GetSystemSetting(Setting.ProductValidationCardCount);
            if (int.TryParse(SettingValue, out intResult))
            {
                if (intResult != Convert.ToInt32(cmbxCardCount.SelectedItem))
                {

                    m_bModified = true;
                }
                else
                {
                    m_bModified = false;
                }

            }

        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

      

       
      
      
    }
}
