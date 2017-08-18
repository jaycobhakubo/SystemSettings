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
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class BlowerSettings : SettingsControl
    {
        bool m_bModified = false;
        private List<Control> listBoxControls = null; // all the list box controls on the UI
        private List<Business.GenericCBOItem> lstScanner1Ports = new List<Business.GenericCBOItem>();       // US4468
        private List<Business.GenericCBOItem> lstScanner2Ports = new List<Business.GenericCBOItem>();

        public BlowerSettings()
        {
            InitializeComponent();
            PopCombos();
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveBlowerSettings();

            Common.EndWait();

            return bResult; 
        }

        public override bool IsModified()
        {
            return m_bModified;
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            SuspendLayout();

            bool bResult = LoadBlowerSettings();

            ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        private bool SaveBlowerSettings()
        {
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.ScannableBallQty;
            s.Value = upDownBallQty.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerAckTimeout;
            s.Value = upDownAckTimeout.Value.ToString();
            arrSettings.Add(s);

            Business.GenericCBOItem cboScanner1Item = (Business.GenericCBOItem)cboScanner1Port.SelectedItem;
            s.Id = (int)Setting.BlowerScanner1Port;
            s.Value = cboScanner1Item.CBOValueMember.ToString();
            arrSettings.Add(s);

            Business.GenericCBOItem cboScanner2Item = (Business.GenericCBOItem)cboScanner2Port.SelectedItem;
            s.Id = (int)Setting.BlowerScanner2Port;
            s.Value = cboScanner2Item.CBOValueMember.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerDropBallDuration;
            s.Value = upDownDropDuration.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerBallMixEnabled;
            s.Value = chkMixEnabled.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerBallMixDuration;
            s.Value = upDownMixDuration.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerBallMixStartVoltPerc;
            s.Value = upDownStartVoltPer.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerBallMixEndVoltPerc;
            s.Value = upDownFinishVoltPer.Value.ToString();
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            //END FIX RALLY DE 3174

            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }

            // Set the flag
            m_bModified = false;

            return true; 
        }

        private bool LoadBlowerSettings()
        {
            if (!Common.GetSystemSettings())
            {
                return false;
            }

            //SettingValue tempSettingValue;
            string tempSettingValue;
            Business.GenericCBOItem cboItem = null;

            //Common.GetOpSettingValue(Setting.ScannableBallQty, out tempSettingValue);
            tempSettingValue = Common.GetSystemSetting(Setting.ScannableBallQty);
            int tmp = 0;
            if (int.TryParse(tempSettingValue, out tmp))
                upDownBallQty.Value = tmp;
            else
                upDownBallQty.Value = 75;


            tempSettingValue = Common.GetSystemSetting(Setting.BlowerAckTimeout);
            if (int.TryParse(tempSettingValue, out tmp))
                upDownAckTimeout.Value = tmp;
            else
                upDownAckTimeout.Value = 800;

            // START RALLY US4468 get blower scanner COM ports
            string value = Common.GetOpSetting(Setting.BlowerScanner1Port, true);

            try
            {
                cboItem = FindItemByValue(Convert.ToInt32(value), "cboScanner1Port");
                if (cboItem != null)
                {
                    cboScanner1Port.SelectedIndex = cboScanner1Port.Items.IndexOf(cboItem);
                }
                else
                {
                    cboScanner1Port.SelectedIndex = -1;
                }
            }
            catch
            {
                cboScanner1Port.SelectedIndex = -1;
            }

            value = Common.GetOpSetting(Setting.BlowerScanner2Port, true);

            try
            {
                cboItem = FindItemByValue(Convert.ToInt32(value), "cboScanner2Port");
                if (cboItem != null)
                {
                    cboScanner2Port.SelectedIndex = cboScanner2Port.Items.IndexOf(cboItem);
                }
                else
                {
                    cboScanner2Port.SelectedIndex = -1;
                }
            }
            catch
            {
                cboScanner2Port.SelectedIndex = -1;
            }

            tempSettingValue = Common.GetSystemSetting(Setting.BlowerDropBallDuration);
            if (int.TryParse(tempSettingValue, out tmp))
                upDownDropDuration.Value = tmp;
            else
                upDownDropDuration.Value = 6500;

            tempSettingValue = Common.GetSystemSetting(Setting.BlowerBallMixDuration);
            if (int.TryParse(tempSettingValue, out tmp))
                upDownMixDuration.Value = tmp;
            else
                upDownMixDuration.Value = 15000;

            tempSettingValue = Common.GetSystemSetting(Setting.BlowerBallMixStartVoltPerc);
            if (int.TryParse(tempSettingValue, out tmp))
                upDownStartVoltPer.Value = tmp;
            else
                upDownStartVoltPer.Value = 50;

            tempSettingValue = Common.GetSystemSetting(Setting.BlowerBallMixEndVoltPerc);
            if (int.TryParse(tempSettingValue, out tmp))
                upDownFinishVoltPer.Value = tmp;
            else
                upDownFinishVoltPer.Value = 78;

            tempSettingValue = Common.GetSystemSetting(Setting.BlowerBallMixEnabled);
            chkMixEnabled.Checked = ParseBool(tempSettingValue);

            upDownMixDuration.Enabled = chkMixEnabled.Checked;
            upDownStartVoltPer.Enabled = chkMixEnabled.Checked;
            upDownFinishVoltPer.Enabled = chkMixEnabled.Checked;

            // DE13642 Set the flag
            m_bModified = false;

            return true;
        }

        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void chkMixEnabled_CheckedChanged(object sender, EventArgs e)
        {
            upDownMixDuration.Enabled = chkMixEnabled.Checked;
            upDownStartVoltPer.Enabled = chkMixEnabled.Checked;
            upDownFinishVoltPer.Enabled = chkMixEnabled.Checked;

            m_bModified = true;
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;
            ComboBox cComboBox = null;

            if (listBoxControls == null)
            {
                listBoxControls = new List<Control>(this.groupBox1.Controls.Cast<Control>().Where(x => x is ComboBox)); // get all from the group boxes that are combo boxes
            }

            foreach (Control xControl in listBoxControls)
            {
                if (String.Equals(xControl.Name, strCBOName))
                {
                    cComboBox = (ComboBox)xControl;
                    break;
                }
            }

            if (cComboBox != null)
            {
                for (int i = 0; i < cComboBox.Items.Count; i++)
                {
                    objReturn = (Business.GenericCBOItem)cComboBox.Items[i];
                    if (objReturn.CBOValueMember == selectedVal)
                    {
                        break;
                    }
                }
            }
            return objReturn;
        }

                /// <summary>
        /// Populates the combo boxes for the UI
        /// </summary>
        private void PopCombos()
        {
            for (int l = 1; l < 14; l++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = l;
                cboItem.CBODisplayMember = "COM" + l.ToString();
                lstScanner1Ports.Add(cboItem);
                lstScanner2Ports.Add(cboItem);
            }

            cboScanner1Port.Items.Clear();
            cboScanner1Port.DataSource = lstScanner1Ports;
            cboScanner1Port.DisplayMember = "CBODisplayMember";
            cboScanner1Port.ValueMember = "CBOValueMember";

            cboScanner2Port.Items.Clear();
            cboScanner2Port.DataSource = lstScanner2Ports;
            cboScanner2Port.DisplayMember = "CBODisplayMember";
            cboScanner2Port.ValueMember = "CBOValueMember";
            if (cboScanner2Port.SelectedIndex == cboScanner1Port.SelectedIndex)
                ++cboScanner2Port.SelectedIndex;
        }
    }
}
