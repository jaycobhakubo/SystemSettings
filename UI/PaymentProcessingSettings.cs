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
using GTI.Modules.Shared.Data;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class PaymentProcessingSettings : SettingsControl
    {
        public enum ProcessingFor
        {
            None = 0,
            Shift4 = 1,
            Precidia = 2
        };

        #region Members

        bool m_Modified = false;

        string m_Shift4AuthCode;
        bool m_leavingAuth = false;

        #endregion

        #region Public Methods

        public PaymentProcessingSettings()
        {
            InitializeComponent();

            grpShift4PINPad.Location = grpPrecidiaPINPad.Location;
            grpPrecidiaSupport.Location = new Point(grpPrecidiaSupport.Location.X, grpPrecidiaSupport.Location.Y - (grpPrecidiaPINPad.Location.Y - panelShift4.Location.Y));
            grpPrecidiaPINPad.Location = panelShift4.Location;

            if (!Common.IsAdmin)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;

                cmbProcessor.Enabled = false;
            }
            else
            {
                txtAuthToken.UseSystemPasswordChar = false;
            }
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            bool bResult = LoadPaymentProcessingSettings();

            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SavePaymentProcessingSettings();

            Common.EndWait();

            return bResult;
        }

        /// <summary>
        /// Returns true if any of the UI fields have been altered from their original values
        /// </summary>
        /// <returns></returns>
        public override bool IsModified()
        {
            return m_Modified;
        }

        #endregion

        #region Private Routines

        private bool LoadPaymentProcessingSettings()
        {
            SettingValue tempSettingValue;

            if (Common.GetSystemSettings() == false)
            {
                return false;
            }

            Common.GetOpSettingValue(Setting.CreditCardProcessor, out tempSettingValue);
            cmbProcessor.SelectedIndex = Common.ParseInt(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.Shift4AuthToken, out tempSettingValue);
            txtAuthToken.Text = tempSettingValue.Value;
            m_Shift4AuthCode = txtAuthToken.Text;

            Common.GetOpSettingValue(Setting.PINPadDisplayLineCount, out tempSettingValue);
            nudPINPadDisplayLines.Value = Common.ParseInt(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PinPadDisplayColumnCount, out tempSettingValue);
            nudPINPadDisplayColumns.Value = Common.ParseInt(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PaymentProcessorCommunicationsTimeout, out tempSettingValue);
            nudShift4ComTimeout.Value = Common.ParseInt(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PinPadEnabled, out tempSettingValue);
            chkPINPadEnabled.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.MaximumTotalNotRequiringSignature, out tempSettingValue);
            nudMaxWithoutSignature.Value = Common.ParseDecimal(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.DisplayItemDetailOnPinPad, out tempSettingValue);
            chkPINPadItemDetail.Checked = Common.ParseBool(tempSettingValue.Value);
            chkPINPadItemDetail2.Checked = chkPINPadItemDetail.Checked;

            Common.GetOpSettingValue(Setting.DisplaySubtotalOnPinPad, out tempSettingValue);
            chkPINPadSubtotal.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.DisplayAmountDueOnPinPad, out tempSettingValue);
            chkPINPadAmountDue.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.AllowManualCardEntry, out tempSettingValue);
            chkAllowManualEntry.Checked = Common.ParseBool(tempSettingValue.Value);

            txtGreetingMessage.Text = Common.GetOpSetting(Setting.PinPadGreeting, true);

            txtAfterSaleMessage.Text = Common.GetOpSetting(Setting.PinPadAfterSaleMessage, true);

            txtStationClosedMessage.Text = Common.GetOpSetting(Setting.PinPadStationClosedMessage, true);

            txtFailedMessage.Text = Common.GetOpSetting(Setting.PinPadCardFailMessage, true);

            Common.GetOpSettingValue(Setting.PaymentProcessingEnabled, out tempSettingValue);
            chkPaymentProcessingEnabled.Checked = Common.ParseBool(tempSettingValue.Value);

            txtProcessorAddress.Text = Common.GetOpSetting(Setting.PaymentDeviceAddress, true);

            txtProcessorPort.Text = Common.GetOpSetting(Setting.PaymentDevicePort, true);

            txtTransnetAddress.Text = Common.GetOpSetting(Setting.TransnetAddress, true);
            
            txtTransnetPort.Text = Common.GetOpSetting(Setting.TransnetPort, true);

            txtPaymentAppAddress.Text = Common.GetOpSetting(Setting.PaymentProcessingAppAddress, true);
            
            txtPaymentAppPort.Text = Common.GetOpSetting(Setting.PaymentProcessingAppPort, true);

            m_Modified = false;

            return true;
        }

        private bool SavePaymentProcessingSettings() 
        {
            List<SettingValue> ppSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.CreditCardProcessor;
            s.Value = cmbProcessor.SelectedIndex.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.PaymentDeviceAddress;
            s.Value = txtProcessorAddress.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PaymentDevicePort;
            s.Value = txtProcessorPort.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.Shift4AuthToken;
            s.Value = txtAuthToken.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadEnabled;
            s.Value = chkPINPadEnabled.Checked.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.MaximumTotalNotRequiringSignature;
            s.Value = nudMaxWithoutSignature.Value.ToString("0.00");
            ppSettings.Add(s);

            s.Id = (int)Setting.DisplayItemDetailOnPinPad;
            s.Value = chkPINPadItemDetail.Checked.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.DisplaySubtotalOnPinPad;
            s.Value = chkPINPadSubtotal.Checked.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.DisplayAmountDueOnPinPad;
            s.Value = chkPINPadAmountDue.Checked.ToString();
            ppSettings.Add(s);
            
            s.Id = (int)Setting.PaymentProcessorCommunicationsTimeout;
            s.Value = nudShift4ComTimeout.Value.ToString();
            ppSettings.Add(s);
            
            s.Id = (int)Setting.PINPadDisplayLineCount;
            s.Value = nudPINPadDisplayLines.Value.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadDisplayColumnCount;
            s.Value = nudPINPadDisplayColumns.Value.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadGreeting;
            s.Value = txtGreetingMessage.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadAfterSaleMessage;
            s.Value = txtAfterSaleMessage.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadStationClosedMessage;
            s.Value = txtStationClosedMessage.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PinPadCardFailMessage;
            s.Value = txtFailedMessage.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PaymentProcessingEnabled;
            s.Value = chkPaymentProcessingEnabled.Checked.ToString();
            ppSettings.Add(s);

            if (txtAuthToken.Text != m_Shift4AuthCode)
            {
                //we have a new auth token which means we will need a new access token.
                //we will erase the current access token so the next user to initialize 
                //payment processing will trigger getting a new access token using this auth token.

                ClientDataStoreAccessor cds = new ClientDataStoreAccessor();

                cds.SetValue(ClientDataStoreTypes.Shift4AccessToken, Common.CurrentOperatorId, null, null, string.Empty);
            }

            s.Id = (int)Setting.AllowManualCardEntry;
            s.Value = chkAllowManualEntry.Checked.ToString();
            ppSettings.Add(s);

            s.Id = (int)Setting.TransnetAddress;
            s.Value = txtTransnetAddress.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.TransnetPort;
            s.Value = txtTransnetPort.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PaymentProcessingAppAddress;
            s.Value = txtPaymentAppAddress.Text;
            ppSettings.Add(s);

            s.Id = (int)Setting.PaymentProcessingAppPort;
            s.Value = txtPaymentAppPort.Text;
            ppSettings.Add(s);

            if (!Common.SaveSystemSettings(ppSettings.ToArray()))
                return false;

            m_Modified = false;

            return true;
        }

        private void cmbProcessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessingFor ourProcessor = (ProcessingFor)cmbProcessor.SelectedIndex; //GetTheProcessor();

            switch (ourProcessor)
            {
                case ProcessingFor.None:
                {
                    grpSettings.Visible = false;
                    panelMain.Visible = false;
                }
                break;

                case ProcessingFor.Precidia:
                {
                    grpSettings.Visible = true;
                    panelMain.Visible = true;
                    panelShift4.Visible = false;
                    grpShift4PINPad.Visible = false;
                    grpPrecidiaSupport.Visible = true;
                    grpPrecidiaPINPad.Visible = true;
                }
                break;

                case ProcessingFor.Shift4:
                {
                    grpSettings.Visible = true;
                    panelMain.Visible = true;
                    panelShift4.Visible = true;
                    grpShift4PINPad.Visible = true;
                    grpPrecidiaSupport.Visible = false;
                    grpPrecidiaPINPad.Visible = false;
                }
                break; 
            }

            OnModified(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void chkPINPadItemDetail_CheckedChanged(object sender, EventArgs e)
        {
            chkPINPadItemDetail2.Checked = chkPINPadItemDetail.Checked;
            OnModified(sender, e);
        }

        private void chkPINPadItemDetail2_CheckedChanged(object sender, EventArgs e)
        {
            chkPINPadItemDetail.Checked = chkPINPadItemDetail2.Checked;
            OnModified(sender, e);
        }
        
        private void OnModified(object sender, EventArgs e)
        {
            m_Modified = true;
        }

        #endregion

        private void chkPaymentProcessingEnabled_CheckStateChanged(object sender, EventArgs e)
        {
            DisabledControlsIfPaymentProcessingIsDisabled(chkPaymentProcessingEnabled.Checked);
        }

           
        private bool m_CurrentPaymentProcessorStatus = false;

        private void DisabledControlsIfPaymentProcessingIsDisabled(bool Action)
        {
            label17.Enabled = Action;
            cmbProcessor.Enabled = Action;
            panelMain.Enabled = Action;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void panelMain_Scroll(object sender, ScrollEventArgs e)
        {
            Application.DoEvents();
        }
    }
}
