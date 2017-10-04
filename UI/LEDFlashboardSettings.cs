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
    public partial class LEDFlashboardSettings : SettingsControl
    {
        bool m_bModified = false;
        private List<Control> listBoxControls = null; // all the list box controls on the UI
        private List<Business.GenericCBOItem> lstPrimaryStreamSubs = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstSecondaryStreamSubs = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstTertiaryStreamSubs = new List<Business.GenericCBOItem>();

        public LEDFlashboardSettings()
        {
            InitializeComponent();
            PopCombos();
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveLEDFlashboardSettings();

            Common.EndWait();

            return bResult; 
        }

        public override bool IsModified()
        {
            return m_bModified;
        }

        private bool SaveLEDFlashboardSettings()
        {
            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrimarySendFreq.Text) || string.IsNullOrWhiteSpace(txtSecondarySendFreq.Text)
                || string.IsNullOrWhiteSpace(txtTertiarySendFreq.Text))
            {
                MessageBox.Show("All fields must have a value. Unable to save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            Business.GenericCBOItem priCBO, secCBO, terCBO;
            int priInt, secInt, terInt;
            string priColor, secColor, terColor;

            s.Id = (int)Setting.LEDAdapterEnabled;
            priInt = chkPrimaryEnableAdapter.Checked ? 1 : 0;
            secInt = chkSecondaryEnableAdapter.Checked ? 1 : 0;
            terInt = chkTertiaryEnableAdapter.Checked ? 1 : 0;
            s.Value = priInt.ToString() + ',' + secInt.ToString() + ',' + terInt.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDAdapterStreamIdx;
            priCBO = (Business.GenericCBOItem)cbobxPrimaryStreamSubIdx.SelectedItem;
            secCBO = (Business.GenericCBOItem)cbobxSecondaryStreamSubIdx.SelectedItem;
            terCBO = (Business.GenericCBOItem)cbobxTertiaryStreamSubIdx.SelectedItem;
            s.Value = priCBO.CBOValueMember.ToString() + ',' + secCBO.CBOValueMember.ToString() + ',' + terCBO.CBOValueMember.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDAdapterSendFreq;
            s.Value = txtPrimarySendFreq.Text + ',' + txtSecondarySendFreq.Text + ',' + txtTertiarySendFreq.Text;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDBingoFlashOff;
            priColor = encodeRGB(btnPBingoFlashOff.BackColor.R, btnPBingoFlashOff.BackColor.G, btnPBingoFlashOff.BackColor.B);
            secColor = encodeRGB(btnSBingoFlashOff.BackColor.R, btnSBingoFlashOff.BackColor.G, btnSBingoFlashOff.BackColor.B);
            terColor = encodeRGB(btnTBingoFlashOff.BackColor.R, btnTBingoFlashOff.BackColor.G, btnTBingoFlashOff.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDBingoFlashOn;
            priColor = encodeRGB(btnPBingoFlashOn.BackColor.R, btnPBingoFlashOn.BackColor.G, btnPBingoFlashOn.BackColor.B);
            secColor = encodeRGB(btnSBingoFlashOn.BackColor.R, btnSBingoFlashOn.BackColor.G, btnSBingoFlashOn.BackColor.B);
            terColor = encodeRGB(btnTBingoFlashOn.BackColor.R, btnTBingoFlashOn.BackColor.G, btnTBingoFlashOn.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDBingoNormal;
            priColor = encodeRGB(btnPBingoNormal.BackColor.R, btnPBingoNormal.BackColor.G, btnPBingoNormal.BackColor.B);
            secColor = encodeRGB(btnSBingoNormal.BackColor.R, btnSBingoNormal.BackColor.G, btnSBingoNormal.BackColor.B);
            terColor = encodeRGB(btnTBingoNormal.BackColor.R, btnTBingoNormal.BackColor.G, btnTBingoNormal.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDCountSign;
            priColor = encodeRGB(btnPCountSign.BackColor.R, btnPCountSign.BackColor.G, btnPCountSign.BackColor.B);
            secColor = encodeRGB(btnSCountSign.BackColor.R, btnSCountSign.BackColor.G, btnSCountSign.BackColor.B);
            terColor = encodeRGB(btnTCountSign.BackColor.R, btnTCountSign.BackColor.G, btnTCountSign.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDCallColorOff;
            priColor = encodeRGB(btnPCallOff.BackColor.R, btnPCallOff.BackColor.G, btnPCallOff.BackColor.B);
            secColor = encodeRGB(btnSCallOff.BackColor.R, btnSCallOff.BackColor.G, btnSCallOff.BackColor.B);
            terColor = encodeRGB(btnTCallOff.BackColor.R, btnTCallOff.BackColor.G, btnTCallOff.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDCallColor;
            priColor = encodeRGB(btnPCall.BackColor.R, btnPCall.BackColor.G, btnPCall.BackColor.B);
            secColor = encodeRGB(btnSCall.BackColor.R, btnSCall.BackColor.G, btnSCall.BackColor.B);
            terColor = encodeRGB(btnTCall.BackColor.R, btnTCall.BackColor.G, btnTCall.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDCallFlashOn;
            priColor = encodeRGB(btnPCallFlashOn.BackColor.R, btnPCallFlashOn.BackColor.G, btnPCallFlashOn.BackColor.B);
            secColor = encodeRGB(btnSCallFlashOn.BackColor.R, btnSCallFlashOn.BackColor.G, btnSCallFlashOn.BackColor.B);
            terColor = encodeRGB(btnTCallFlashOn.BackColor.R, btnTCallFlashOn.BackColor.G, btnTCallFlashOn.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDCallFlashOff;
            priColor = encodeRGB(btnPCallFlashOff.BackColor.R, btnPCallFlashOff.BackColor.G, btnPCallFlashOff.BackColor.B);
            secColor = encodeRGB(btnSCallFlashOff.BackColor.R, btnSCallFlashOff.BackColor.G, btnSCallFlashOff.BackColor.B);
            terColor = encodeRGB(btnTCallFlashOff.BackColor.R, btnTCallFlashOff.BackColor.G, btnTCallFlashOff.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDHotball;
            priColor = encodeRGB(btnPHotball.BackColor.R, btnPHotball.BackColor.G, btnPHotball.BackColor.B);
            secColor = encodeRGB(btnSHotball.BackColor.R, btnSHotball.BackColor.G, btnSHotball.BackColor.B);
            terColor = encodeRGB(btnTHotball.BackColor.R, btnTHotball.BackColor.G, btnTHotball.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDHotballCall;
            priColor = encodeRGB(btnPHotballCall.BackColor.R, btnPHotballCall.BackColor.G, btnPHotballCall.BackColor.B);
            secColor = encodeRGB(btnSHotballCall.BackColor.R, btnSHotballCall.BackColor.G, btnSHotballCall.BackColor.B);
            terColor = encodeRGB(btnTHotballCall.BackColor.R, btnTHotballCall.BackColor.G, btnTHotballCall.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDHotballFlashOn;
            priColor = encodeRGB(btnPHotballFlashOn.BackColor.R, btnPHotballFlashOn.BackColor.G, btnPHotballFlashOn.BackColor.B);
            secColor = encodeRGB(btnSHotballFlashOn.BackColor.R, btnSHotballFlashOn.BackColor.G, btnSHotballFlashOn.BackColor.B);
            terColor = encodeRGB(btnTHotballFlashOn.BackColor.R, btnTHotballFlashOn.BackColor.G, btnTHotballFlashOn.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDHotballFlashOff;
            priColor = encodeRGB(btnPHotballFlashOff.BackColor.R, btnPHotballFlashOff.BackColor.G, btnPHotballFlashOff.BackColor.B);
            secColor = encodeRGB(btnSHotballFlashOff.BackColor.R, btnSHotballFlashOff.BackColor.G, btnSHotballFlashOff.BackColor.B);
            terColor = encodeRGB(btnTHotballFlashOff.BackColor.R, btnTHotballFlashOff.BackColor.G, btnTHotballFlashOff.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDGameSign;
            priColor = encodeRGB(btnPGameSign.BackColor.R, btnPGameSign.BackColor.G, btnPGameSign.BackColor.B);
            secColor = encodeRGB(btnSGameSign.BackColor.R, btnSGameSign.BackColor.G, btnSGameSign.BackColor.B);
            terColor = encodeRGB(btnTGameSign.BackColor.R, btnTGameSign.BackColor.G, btnTGameSign.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDLastCallSign;
            priColor = encodeRGB(btnPLastCallSign.BackColor.R, btnPLastCallSign.BackColor.G, btnPLastCallSign.BackColor.B);
            secColor = encodeRGB(btnSLastCallSign.BackColor.R, btnSLastCallSign.BackColor.G, btnSLastCallSign.BackColor.B);
            terColor = encodeRGB(btnTLastCallSign.BackColor.R, btnTLastCallSign.BackColor.G, btnTLastCallSign.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDPatternOff;
            priColor = encodeRGB(btnPPatternOff.BackColor.R, btnPPatternOff.BackColor.G, btnPPatternOff.BackColor.B);
            secColor = encodeRGB(btnSPatternOff.BackColor.R, btnSPatternOff.BackColor.G, btnSPatternOff.BackColor.B);
            terColor = encodeRGB(btnTPatternOff.BackColor.R, btnTPatternOff.BackColor.G, btnTPatternOff.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
            arrSettings.Add(s);

            s.Id = (int)Setting.LEDPatternOn;
            priColor = encodeRGB(btnPPatternOn.BackColor.R, btnPPatternOn.BackColor.G, btnPPatternOn.BackColor.B);
            secColor = encodeRGB(btnSPatternOn.BackColor.R, btnSPatternOn.BackColor.G, btnSPatternOn.BackColor.B);
            terColor = encodeRGB(btnTPatternOn.BackColor.R, btnTPatternOn.BackColor.G, btnTPatternOn.BackColor.B);
            s.Value = priColor + ',' + secColor + ',' + terColor;
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

            // Set the flag
            m_bModified = false;

            return true; 
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            SuspendLayout();

            bool bResult = LoadLEDFlashboardSettings();

            ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        private bool LoadLEDFlashboardSettings()
        {
            if (!Common.GetSystemSettings())
            {
                return false;
            }

            string tempSettingValue;
            Business.GenericCBOItem cboItem = null;
            int priInt, secInt, terInt;
            string[] tmp;
            bool ok;

            tempSettingValue = Common.GetOpSetting(Setting.LEDAdapterEnabled);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                chkPrimaryEnableAdapter.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[0]));
                chkSecondaryEnableAdapter.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[1]));
                chkTertiaryEnableAdapter.Checked = Convert.ToBoolean(Convert.ToInt32(tmp[2]));
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDAdapterStreamIdx);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[0]), "cbobxPrimaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxPrimaryStreamSubIdx.SelectedIndex = cbobxPrimaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxPrimaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxPrimaryStreamSubIdx.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[1]), "cbobxSecondaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxSecondaryStreamSubIdx.SelectedIndex = cbobxSecondaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxSecondaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxSecondaryStreamSubIdx.SelectedIndex = -1;
                }

                try
                {
                    cboItem = FindItemByValue(Convert.ToInt32(tmp[1]), "cbobxTertiaryStreamSubIdx");
                    if (cboItem != null)
                    {
                        cbobxTertiaryStreamSubIdx.SelectedIndex = cbobxTertiaryStreamSubIdx.Items.IndexOf(cboItem);
                    }
                    else
                    {
                        cbobxTertiaryStreamSubIdx.SelectedIndex = -1;
                    }
                }
                catch
                {
                    cbobxTertiaryStreamSubIdx.SelectedIndex = -1;
                }
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDAdapterSendFreq);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                txtPrimarySendFreq.Text = tmp[0];
                txtSecondarySendFreq.Text = tmp[1];
                txtTertiarySendFreq.Text = tmp[2];
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDBingoFlashOff);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPBingoFlashOff, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSBingoFlashOff, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTBingoFlashOff, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDBingoFlashOn);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPBingoFlashOn, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSBingoFlashOn, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTBingoFlashOn, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDBingoNormal);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPBingoNormal, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSBingoNormal, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTBingoNormal, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDCountSign);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPCountSign, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSCountSign, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTCountSign, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDCallColorOff);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPCallOff, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSCallOff, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTCallOff, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDCallColor);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPCall, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSCall, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTCall, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDCallFlashOn);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPCallFlashOn, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSCallFlashOn, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTCallFlashOn, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDCallFlashOff);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPCallFlashOff, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSCallFlashOff, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTCallFlashOff, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDHotball);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPHotball, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSHotball, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTHotball, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDHotballCall);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPHotballCall, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSHotballCall, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTHotballCall, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDHotballFlashOn);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPHotballFlashOn, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSHotballFlashOn, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTHotballFlashOn, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDHotballFlashOff);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPHotballFlashOff, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSHotballFlashOff, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTHotballFlashOff, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDGameSign);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPGameSign, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSGameSign, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTGameSign, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDLastCallSign);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPLastCallSign, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSLastCallSign, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTLastCallSign, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDPatternOff);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPPatternOff, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSPatternOff, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTPatternOff, terInt);
            }

            tempSettingValue = Common.GetOpSetting(Setting.LEDPatternOn);
            if (!string.IsNullOrWhiteSpace(tempSettingValue))
            {
                tmp = tempSettingValue.Split(',');
                ok = Int32.TryParse(tmp[0], out priInt);
                if (ok)
                    setInitialButtonColor(btnPPatternOn, priInt);
                ok = Int32.TryParse(tmp[1], out secInt);
                if (ok)
                    setInitialButtonColor(btnSPatternOn, secInt);
                ok = Int32.TryParse(tmp[2], out terInt);
                if (ok)
                    setInitialButtonColor(btnTPatternOn, terInt);
            }

            cbobxPrimaryStreamSubIdx.Enabled = chkPrimaryEnableAdapter.Checked;
            txtPrimarySendFreq.Enabled = chkPrimaryEnableAdapter.Checked;
            primaryLEDGroupbox.Enabled = chkPrimaryEnableAdapter.Checked;

            cbobxSecondaryStreamSubIdx.Enabled = chkSecondaryEnableAdapter.Checked;
            txtSecondarySendFreq.Enabled = chkSecondaryEnableAdapter.Checked;
            secondaryLEDGroupbox.Enabled = chkSecondaryEnableAdapter.Checked;

            cbobxTertiaryStreamSubIdx.Enabled = chkTertiaryEnableAdapter.Checked;
            txtTertiarySendFreq.Enabled = chkTertiaryEnableAdapter.Checked;
            tertiaryLEDGroupbox.Enabled = chkTertiaryEnableAdapter.Checked;

            m_bModified = false;

            return true;
        }

        private string encodeRGB(byte r, byte g, byte b) //encodes RGB values into a BBRRRGGG byte
        {
            byte grb = (byte)((b & 0xc0) + ((r >> 2) & 0x38) + (g >> 5));
            return grb.ToString();
        }

        private string decodeRGB(int rgb) //decodes an int based on a BBRRRGGG byte back into RGB values
        {
            int nR, nG, nB;
            nG = ((((rgb >> 0) & 7) * (255 / 7))); // green
            nR = ((((rgb >> 3) & 7) * (255 / 7))); // red
            nB = ((((rgb >> 6) & 3) * (255 / 3))); // blue
            string tmp = nR.ToString() + " " + nG.ToString() + " " + nB.ToString();
            return tmp;
        }

        private void setInitialButtonColor(Button button, int RGBcolor)
        {
            string[] outColor = decodeRGB(RGBcolor).Split(' ');
            int newR, newG, newB;
            bool rYes, gYes, bYes;
            rYes = Int32.TryParse(outColor[0], out newR);
            gYes = Int32.TryParse(outColor[1], out newG);
            bYes = Int32.TryParse(outColor[2], out newB);
            if (rYes && gYes && bYes)
                button.BackColor = System.Drawing.Color.FromArgb(newR, newG, newB);
        }

        private void setNewButtonColor(Button button)
        {
            LEDFlashboardColorPicker picker = new LEDFlashboardColorPicker(button.BackColor);
            picker.ShowDialog();
            if (picker.DialogResult == DialogResult.OK)
            {
                string tmp = encodeRGB(picker.pickedColor.R, picker.pickedColor.G, picker.pickedColor.B);
                button.BackColor = picker.pickedColor;
            }
        }

        private void colorButton_Click(System.Object sender, System.EventArgs e)
        {
            setNewButtonColor((Button)sender);
            m_bModified = true;
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

        private void chkPrimaryEnableAdapter_CheckedChanged(object sender, EventArgs e)
        {
            cbobxPrimaryStreamSubIdx.Enabled = chkPrimaryEnableAdapter.Checked;
            txtPrimarySendFreq.Enabled = chkPrimaryEnableAdapter.Checked;
            primaryLEDGroupbox.Enabled = chkPrimaryEnableAdapter.Checked;

            m_bModified = true;
        }

        private void chkSecondaryEnableAdapter_CheckedChanged(object sender, EventArgs e)
        {
            cbobxSecondaryStreamSubIdx.Enabled = chkSecondaryEnableAdapter.Checked;
            txtSecondarySendFreq.Enabled = chkSecondaryEnableAdapter.Checked;
            secondaryLEDGroupbox.Enabled = chkSecondaryEnableAdapter.Checked;

            m_bModified = true;
        }

        private void chkTertiaryEnableAdapter_CheckedChanged(object sender, EventArgs e)
        {
            cbobxTertiaryStreamSubIdx.Enabled = chkTertiaryEnableAdapter.Checked;
            txtTertiarySendFreq.Enabled = chkTertiaryEnableAdapter.Checked;
            tertiaryLEDGroupbox.Enabled = chkTertiaryEnableAdapter.Checked;

            m_bModified = true;
        }

        private void PopCombos() //populate combo boxes
        {
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

            cbobxPrimaryStreamSubIdx.Items.Clear();
            cbobxPrimaryStreamSubIdx.DataSource = lstPrimaryStreamSubs;
            cbobxPrimaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxPrimaryStreamSubIdx.ValueMember = "CBOValueMember";

            cbobxSecondaryStreamSubIdx.Items.Clear();
            cbobxSecondaryStreamSubIdx.DataSource = lstSecondaryStreamSubs;
            cbobxSecondaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxSecondaryStreamSubIdx.ValueMember = "CBOValueMember";

            cbobxTertiaryStreamSubIdx.Items.Clear();
            cbobxTertiaryStreamSubIdx.DataSource = lstTertiaryStreamSubs;
            cbobxTertiaryStreamSubIdx.DisplayMember = "CBODisplayMember";
            cbobxTertiaryStreamSubIdx.ValueMember = "CBOValueMember";
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;
            ComboBox cComboBox = null;

            if (listBoxControls == null)
            {
                listBoxControls = new List<Control>(this.groupBox2.Controls.Cast<Control>().Where(x => x is ComboBox)); // get all from the tab pages that are group boxes
                listBoxControls.AddRange(new List<Control>(this.groupBox4.Controls.Cast<Control>().Where(x => x is ComboBox)));
                listBoxControls.AddRange(new List<Control>(this.groupBox5.Controls.Cast<Control>().Where(x => x is ComboBox)));
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

        private void numericUpDowns_ValueChanged(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void StreamSubIdx_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        private void numericUpDowns_LostFocus(object sender, EventArgs e)
        {
            m_bModified = true;
        }
    }
}
