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
    public partial class ProtocolAdapterSettings : SettingsControl
    {
        bool m_bModified = false;
        private List<Control> listBoxControls = null; // all the list box controls on the UI
        private List<Business.GenericCBOItem> lstPrimaryCommPorts = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstSecondaryCommPorts = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstTertiaryCommPorts = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstPrimaryStreamSubs = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstSecondaryStreamSubs = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstTertiaryStreamSubs = new List<Business.GenericCBOItem>();

        public ProtocolAdapterSettings()
        {
            InitializeComponent();
            PopCombos();
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveProtocolAdapterSettings();

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

            bool bResult = LoadProtocolAdapterSettings();

            ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        private bool SaveProtocolAdapterSettings()
        {
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            Business.GenericCBOItem priCBO, secCBO, terCBO;

            if (string.IsNullOrWhiteSpace(txtprimarySendFreq.Text))
            {
                //DE12939 Refuse save if box is empty
                errorProvider1.Clear();
                errorProvider1.SetError(txtprimarySendFreq, "Value must be filled in to save");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtsecondarySendFreq.Text))
            {
                //DE12939 Refuse save if box is empty
                errorProvider1.Clear();
                errorProvider1.SetError(txtsecondarySendFreq, "Value must be filled in to save");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txttertiarySendFreq.Text))
            {
                //DE12939 Refuse save if box is empty
                errorProvider1.Clear();
                errorProvider1.SetError(txttertiarySendFreq, "Value must be filled in to save");
                return false;
            }

            s.Id = (int)Setting.ProtocolAdapterEnabled;
            int priInt = chkprimaryAdapterEnabled.Checked ? 1 : 0;
            int secInt = chksecondaryAdapterEnabled.Checked ? 1 : 0;
            int terInt = chktertiaryAdapterEnabled.Checked ? 1 : 0;
            s.Value = priInt.ToString() + ',' + secInt.ToString() + ',' + terInt.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ProtocolAdapterStreamIdx;
            priCBO = (Business.GenericCBOItem)cbobxprimaryStreamSubIdx.SelectedItem;
            secCBO = (Business.GenericCBOItem)cbobxsecondaryStreamSubIdx.SelectedItem;
            terCBO = (Business.GenericCBOItem)cbobxtertiaryStreamSubIdx.SelectedItem;
            s.Value = priCBO.CBOValueMember.ToString() + ',' + secCBO.CBOValueMember.ToString() + ',' + terCBO.CBOValueMember.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ProtocolAdapterSendFreq;
            s.Value = txtprimarySendFreq.Text + ',' + txtsecondarySendFreq.Text + ',' + txttertiarySendFreq.Text;
            arrSettings.Add(s);

            s.Id = (int)Setting.ProtocolAdapterCommPort;
            priCBO = (Business.GenericCBOItem)cbobxprimaryCommPort.SelectedItem;
            secCBO = (Business.GenericCBOItem)cbobxsecondaryCommPort.SelectedItem;
            terCBO = (Business.GenericCBOItem)cbobxtertiaryCommPort.SelectedItem;
            s.Value = priCBO.CBOValueMember.ToString() + ',' + secCBO.CBOValueMember.ToString() + ',' + terCBO.CBOValueMember.ToString();
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

            m_bModified = false;
            errorProvider1.Clear();

            return true;
        }

        private bool LoadProtocolAdapterSettings()
        {
            if (!Common.GetSystemSettings())
            {
                return false;
            }

            string tempSettingValue;
            Business.GenericCBOItem cboItem = null;
            string[] tmp;

            tempSettingValue = Common.GetOpSetting(Setting.ProtocolAdapterEnabled);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                chkprimaryAdapterEnabled.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[0]));
                chksecondaryAdapterEnabled.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[1]));
                chktertiaryAdapterEnabled.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[2]));
            }

            tempSettingValue = Common.GetOpSetting(Setting.ProtocolAdapterStreamIdx);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[0]), "cbobxprimaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxprimaryStreamSubIdx.SelectedIndex = cbobxprimaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxprimaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxprimaryStreamSubIdx.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[1]), "cbobxsecondaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxsecondaryStreamSubIdx.SelectedIndex = cbobxsecondaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxsecondaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxsecondaryStreamSubIdx.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[1]), "cbobxtertiaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxtertiaryStreamSubIdx.SelectedIndex = cbobxtertiaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxtertiaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxtertiaryStreamSubIdx.SelectedIndex = -1;
                }
            }

            tempSettingValue = Common.GetOpSetting(Setting.ProtocolAdapterSendFreq);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                txtprimarySendFreq.Text = tmp[0];
                txtsecondarySendFreq.Text = tmp[1];
                txttertiarySendFreq.Text = tmp[2];
            }

            tempSettingValue = Common.GetOpSetting(Setting.ProtocolAdapterCommPort);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[0]), "cbobxprimaryCommPort");
                    if (cboItem != null)
                    {
                        cbobxprimaryCommPort.SelectedIndex = cbobxprimaryCommPort.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxprimaryCommPort.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxprimaryCommPort.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[1]), "cbobxsecondaryCommPort");
                    if (cboItem != null)
                    {
                        cbobxsecondaryCommPort.SelectedIndex = cbobxsecondaryCommPort.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxsecondaryCommPort.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxsecondaryCommPort.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[2]), "cbobxtertiaryCommPort");
                    if (cboItem != null)
                    {
                        cbobxtertiaryCommPort.SelectedIndex = cbobxtertiaryCommPort.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxtertiaryCommPort.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxtertiaryCommPort.SelectedIndex = -1;
                }
            }

            txtprimarySendFreq.Enabled = chkprimaryAdapterEnabled.Checked;
            cbobxprimaryCommPort.Enabled = chkprimaryAdapterEnabled.Checked;
            cbobxprimaryStreamSubIdx.Enabled = chkprimaryAdapterEnabled.Checked;

            txtsecondarySendFreq.Enabled = chksecondaryAdapterEnabled.Checked;
            cbobxsecondaryCommPort.Enabled = chksecondaryAdapterEnabled.Checked;
            cbobxsecondaryStreamSubIdx.Enabled = chksecondaryAdapterEnabled.Checked;

            txttertiarySendFreq.Enabled = chktertiaryAdapterEnabled.Checked;
            cbobxtertiaryCommPort.Enabled = chktertiaryAdapterEnabled.Checked;
            cbobxtertiaryStreamSubIdx.Enabled = chktertiaryAdapterEnabled.Checked;

            m_bModified = false;
            errorProvider1.Clear();

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

        private void PopCombos() //populate combo boxes
        {
            for (int l = 1; l < 14; l++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = l;
                cboItem.CBODisplayMember = "COM" + l.ToString();
                lstPrimaryCommPorts.Add(cboItem);
                lstSecondaryCommPorts.Add(cboItem);
                lstTertiaryCommPorts.Add(cboItem);
            }

            cbobxprimaryCommPort.Items.Clear();
            cbobxprimaryCommPort.DataSource = lstPrimaryCommPorts;
            cbobxprimaryCommPort.DisplayMember = "CBODisplayMember";
            cbobxprimaryCommPort.ValueMember = "CBOValueMember";

            cbobxsecondaryCommPort.Items.Clear();
            cbobxsecondaryCommPort.DataSource = lstSecondaryCommPorts;
            cbobxsecondaryCommPort.DisplayMember = "CBODisplayMember";
            cbobxsecondaryCommPort.ValueMember = "CBOValueMember";

            cbobxtertiaryCommPort.Items.Clear();
            cbobxtertiaryCommPort.DataSource = lstTertiaryCommPorts;
            cbobxtertiaryCommPort.DisplayMember = "CBODisplayMember";
            cbobxtertiaryCommPort.ValueMember = "CBOValueMember";

            for (int s = 0; s <= 2; s++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = s;
                if (s == 0)
                    cboItem.CBODisplayMember = "Normal Bingo";
                else if (s == 1)
                    cboItem.CBODisplayMember = "Bonanza";
                else if (s == 2)
                    cboItem.CBODisplayMember = "Reserved";
                lstPrimaryStreamSubs.Add(cboItem);
                lstSecondaryStreamSubs.Add(cboItem);
                lstTertiaryStreamSubs.Add(cboItem);
            }

            cbobxprimaryStreamSubIdx.Items.Clear();
            cbobxprimaryStreamSubIdx.DataSource = lstPrimaryStreamSubs;
            cbobxprimaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxprimaryStreamSubIdx.ValueMember = "CBOValueMember";

            cbobxsecondaryStreamSubIdx.Items.Clear();
            cbobxsecondaryStreamSubIdx.DataSource = lstSecondaryStreamSubs;
            cbobxsecondaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxsecondaryStreamSubIdx.ValueMember = "CBOValueMember";

            cbobxtertiaryStreamSubIdx.Items.Clear();
            cbobxtertiaryStreamSubIdx.DataSource = lstTertiaryStreamSubs;
            cbobxtertiaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxtertiaryStreamSubIdx.ValueMember = "CBOValueMember";
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;
            ComboBox cComboBox = null;

            if (listBoxControls == null)
            {
                listBoxControls = new List<Control>(this.tabPage1.Controls.Cast<Control>().Where(x => x is ComboBox)); // get all from the tab pages that are group boxes
                listBoxControls.AddRange(new List<Control>(this.tabPage2.Controls.Cast<Control>().Where(x => x is ComboBox)));
                listBoxControls.AddRange(new List<Control>(this.tabPage3.Controls.Cast<Control>().Where(x => x is ComboBox)));
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

        private void chkprimaryAdapterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtprimarySendFreq.Enabled = chkprimaryAdapterEnabled.Checked;
            cbobxprimaryCommPort.Enabled = chkprimaryAdapterEnabled.Checked;
            cbobxprimaryStreamSubIdx.Enabled = chkprimaryAdapterEnabled.Checked;

            m_bModified = true;
        }

        private void chksecondaryAdapterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtsecondarySendFreq.Enabled = chksecondaryAdapterEnabled.Checked;
            cbobxsecondaryCommPort.Enabled = chksecondaryAdapterEnabled.Checked;
            cbobxsecondaryStreamSubIdx.Enabled = chksecondaryAdapterEnabled.Checked;

            m_bModified = true;
        }

        private void chktertiaryAdapterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txttertiarySendFreq.Enabled = chktertiaryAdapterEnabled.Checked;
            cbobxtertiaryCommPort.Enabled = chktertiaryAdapterEnabled.Checked;
            cbobxtertiaryStreamSubIdx.Enabled = chktertiaryAdapterEnabled.Checked;

            m_bModified = true;
        }

        private void numericUpDowns_ValueChanged(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void StreamSubIdx_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void CommPortIdx_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void numericUpDowns_CheckEmpty(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }
    }
}
