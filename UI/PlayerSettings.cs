#region Copyright

// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All rights reserved

// US4010 Adding setting for displaying the verified card on a player unit
// US4147 Adding support for being able to specify the length of a players PIN
#endregion

//DE12696: System Settings: Set the PIN length > Field length
//US4185: (US4183) Player PIN Length must be >= 4 digits.
//US4187: (ND) North Dakota Mode > Force Player PIN Required to be enabled.
//US5175: System Settings > Player Unit: Ted-E Setting to enable reset radio on WiFi interuption

using System;
using System.Windows.Forms;
using GTI.Modules.Shared;
using System.Collections.Generic;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Business;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class PlayerSettings : SettingsControl
    {
        private const int PlayerPinMaxLength = 2;
        // Members
        bool m_bModified = false;

        public PlayerSettings()
        {
            InitializeComponent();
        }

        // Public Methods
        #region Public Methods
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

            bool bResult = LoadPlayerSettings();


            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SavePlayerSettings();

            Common.EndWait();

            return bResult;
        }

        #endregion  // Public Methods

        // Private Routines
        #region Private Routines

        private bool LoadPlayerSettings()
        {

            //START RALLY DE 9171
            if (Common.GetSystemSettings() == false)
            {
                return false;
            }
            //END RALLY DE 9171
            // Fill in the operator global settings            
            SettingValue tempSettingValue;

            //Get the device setting if set if not then get the operator settings.
            GetDeviceSettings x = new GetDeviceSettings(0, 0);
            x.Send();
           SettingValue[] z  = x.DeviceSettingList;
            if (z.Length != 0)
            {
                int i = 0;
            }

            Common.GetOpSettingValue(Setting.VIPRequiresPIN, out tempSettingValue);
            chkPlayerPIN.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427

            Common.GetOpSettingValue(Setting.PlayWinAnimationDuration, out tempSettingValue);
            txtPlayWinAnimationDuration.Text = tempSettingValue.Value.ToString();

            //Rally US1998
            Common.GetOpSettingValue(Setting.EnablePeekMode, out tempSettingValue);
            chkPeekMode.Checked = Common.ParseBool(tempSettingValue.Value);

            //START RALLY TA 9171 loss threshold settings
            string settingValue = Common.GetSystemSetting(Setting.WiredNetworkLossThreshold);
            txtWiredNetworkConnectionLossThreshold.Text = settingValue;

            settingValue = Common.GetSystemSetting(Setting.WirelessNetworkLossThreshold);
            txtWirelessNetworkConnectionLossThreshold.Text = settingValue;
            //END RALLY TA 9171

            Common.GetOpSettingValue(Setting.EnableAutoModeButton, out tempSettingValue);
            chkAutoModeOn.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.EnableLockScreenButton, out tempSettingValue);
            chkLockScreenOn.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4010 
            Common.GetOpSettingValue(Setting.DisplayVerifiedCard, out tempSettingValue);
            chkDisplayVerifiedCard.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4010 
            Common.GetOpSettingValue(Setting.DisplayFunGamesOnLogin, out tempSettingValue);
            chkDisplayFunGamesOnLogin.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4538
            Common.GetOpSettingValue(Setting.PatternShadingEnabled, out tempSettingValue);
            chkBingoPatternShading.Checked = Common.ParseBool(tempSettingValue.Value);

            //US3860
            Common.GetOpSettingValue(Setting.TVWithoutPurchase, out tempSettingValue);
            chkTVwoPurchase.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4716
            Common.GetOpSettingValue(Setting.ClearWinnersScreen, out tempSettingValue);
            chkClearWinnersScreen.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4611
            //May eventually have to be checked for each type of player device. Currently only checks for TED-E
            GetAllowForFunGamesMessage msg = new GetAllowForFunGamesMessage();
            try
            {
                msg.Send();
            }
            catch (Exception e)
            {
                MessageForm.Show(this, string.Format(Resources.GetFunGameDataFailed, e));
                return false;
            }

            if (msg.funGamesAllowed == true)
            {
                Common.GetOpSettingValue(Setting.AllowFunMultiplayerGames, out tempSettingValue);
                chkEnableMultiplayerOnFunGames.Checked = Common.ParseBool(tempSettingValue.Value);
            }

            else
                chkEnableMultiplayerOnFunGames.Enabled = false;

            // US4526
            settingValue = Common.GetSystemSetting(Setting.PlayerPinLength);
            txtPlayerPINLength.Text = settingValue;

            //US4187 
            if (bool.Parse(Common.GetLicenseSettingValue(LicenseSetting.NDSalesMode)))
            {
                //if not enabled then enable
                if (!chkPlayerPIN.Checked)
                {
                    chkPlayerPIN.Checked = true;
                    SavePlayerSettings();
                }

                //do not allow user to modify. Always enabled
                chkPlayerPIN.Enabled = false;
            }

            //US4539
            settingValue = Common.GetSystemSetting(Setting.LogoutPacksOnSessionEnd);
            try
            {
                chkLogoutPackSessionClose.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkLogoutPackSessionClose.Checked = false;
            }

            //US5123
            settingValue = Common.GetSystemSetting(Setting.DisplayProgressiveOnPlayerUnit);
            try
            {
                chkDisplayProgressives.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkDisplayProgressives.Checked = false;
            }

            //US5137
            settingValue = Common.GetSystemSetting(Setting.PlayerUnitRoverPackOnReboot);
            try
            {
                chkRecoverOnReboot.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkRecoverOnReboot.Checked = false;
            }

            //US5139
            settingValue = Common.GetSystemSetting(Setting.PlayerUnitsCacheSettings);
            try
            {
                chkCacheSettings.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkCacheSettings.Checked = false;
            }

            //US5171
            settingValue = Common.GetSystemSetting(Setting.PlayerUnitRebootUpperThreshold);
            txtRebootTimeThreshold.Text = settingValue;

            //5175
            settingValue = Common.GetSystemSetting(Setting.ResetTedeRadioOnWifiInterruptions);
            try
            {
                chkBoxResetRadioOnWifiInterruptions.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkBoxResetRadioOnWifiInterruptions.Checked = false;
            }

            if (!Common.IsAdmin) // the logged in user is not a tech, hide any settings they shouldn't see
            {
                lblCrateRebootThresholdSeconds.Visible = false;
                lblCrateRebootThreshold.Visible = false;
                txtRebootTimeThreshold.Visible = false;

                chkBoxResetRadioOnWifiInterruptions.Visible = false;
            }
            chkbxUseDefault.Checked = true;
            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool SavePlayerSettings()
        {
            Common.SetOpSettingValue(Setting.VIPRequiresPIN, chkPlayerPIN.Checked.ToString());
            Common.SetOpSettingValue(Setting.PlayWinAnimationDuration, txtPlayWinAnimationDuration.Text.ToString());
            Common.SetOpSettingValue(Setting.EnablePeekMode, chkPeekMode.Checked.ToString());//US1998
            Common.SetOpSettingValue(Setting.EnableAutoModeButton, chkAutoModeOn.Checked.ToString());
            Common.SetOpSettingValue(Setting.EnableLockScreenButton, chkLockScreenOn.Checked.ToString());
            Common.SetOpSettingValue(Setting.DisplayVerifiedCard, chkDisplayVerifiedCard.Checked.ToString()); //US4010
            Common.SetOpSettingValue(Setting.DisplayFunGamesOnLogin, chkDisplayFunGamesOnLogin.Checked.ToString()); //US4526
            Common.SetOpSettingValue(Setting.PatternShadingEnabled, chkBingoPatternShading.Checked.ToString()); //US4538
            Common.SetOpSettingValue(Setting.AllowFunMultiplayerGames, chkEnableMultiplayerOnFunGames.Checked.ToString()); //US4611
            Common.SetOpSettingValue(Setting.TVWithoutPurchase, chkTVwoPurchase.Checked.ToString()); //US3860
            Common.SetOpSettingValue(Setting.ClearWinnersScreen, chkClearWinnersScreen.Checked.ToString()); //US4716
            //START RALLY TA 9171 loss threshold setting values

            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.WiredNetworkLossThreshold;
            s.Value = txtWiredNetworkConnectionLossThreshold.Text;
            arrSettings.Add(s);

            s.Id = (int)Setting.WirelessNetworkLossThreshold;
            s.Value = txtWirelessNetworkConnectionLossThreshold.Text;
            arrSettings.Add(s);

            // US4147
            s.Id = (int)Setting.PlayerPinLength;
            s.Value = txtPlayerPINLength.Text;
            arrSettings.Add(s);

            //US4539
            s.Id = (int)Setting.LogoutPacksOnSessionEnd;
            s.Value = chkLogoutPackSessionClose.Checked.ToString();
            arrSettings.Add(s);

            //US5123
            s.Id = (int)Setting.DisplayProgressiveOnPlayerUnit;
            s.Value = chkDisplayProgressives.Checked.ToString();
            arrSettings.Add(s);

            //US5137
            s.Id = (int)Setting.PlayerUnitRoverPackOnReboot;
            s.Value = chkRecoverOnReboot.Checked.ToString();
            arrSettings.Add(s);

            //US5139
            s.Id = (int)Setting.PlayerUnitsCacheSettings;
            s.Value = chkCacheSettings.Checked.ToString();
            arrSettings.Add(s);

            //US5171
            s.Id = (int)Setting.PlayerUnitRebootUpperThreshold;
            s.Value = txtRebootTimeThreshold.Text;
            arrSettings.Add(s);

            if (Common.IsAdmin) // the logged in user is not a tech, hide any settings they shouldn't see
            {
                //US5175
                s.Id = (int) Setting.ResetTedeRadioOnWifiInterruptions;
                s.Value = chkBoxResetRadioOnWifiInterruptions.Checked.ToString();
                arrSettings.Add(s);
            }

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            //END RALLY TA 9171


            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }

            // Set the flag
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

        #endregion //Private Routines

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers to be entered into the text box 
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            //START RALLY DE 7070 need to handle the backspace character
            if (e.Handled == true)
            {
                if (e.KeyChar == '\b')
                    e.Handled = false;
            }
            //END RALLY DE 7070
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkPlayerPIN.Focus();
        }

        //DE12696: System Settings: Set the PIN length > Field length
        private void txtPlayerPINLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers to be entered into the text box 
            if (txtPlayerPINLength.Text.Length >= PlayerPinMaxLength)
            {
                e.Handled = true;
            }
            else
            {
                int isNumber;
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            }

            //check for backspace
            if (e.Handled)
            {
                if (e.KeyChar == '\b')
                    e.Handled = false;
            }
        }

        //US4185: (US4183) Player PIN Length must be >= 4 digits.
        private void txtPlayerPINLength_Leave(object sender, EventArgs e)
        {
            int result;
            var success = int.TryParse(txtPlayerPINLength.Text, out result);

            //if null or invalid number then default back to 4
            if (!success)
            {
                //DE12732
                txtPlayerPINLength.Text = 4.ToString();
                return;
            }

            //if less than 4 default back to 4
            if (result < 4)
            {
                txtPlayerPINLength.Text = 4.ToString();
            }
        }

        private void chkbxUseDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxUseDefault.Checked == true)
            {
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
            }
        }
    } // end class
} // end namespace
