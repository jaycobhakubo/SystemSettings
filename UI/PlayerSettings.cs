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
        private const int PlayerPinMaxLength = 2; // Members      
        bool m_bModified = false;
        GetDeviceSettings DeviceSettingmsg;

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
            return true;
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

        private bool SetValueToDefault()
        {
            SettingValue tempSettingValue;            //END RALLY DE 9171 // Fill in the operator global settings   
            string settingValue = "";

            Common.GetOpSettingValue(Setting.VIPRequiresPIN, out tempSettingValue);
            chkPlayerPIN.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427

            Common.GetOpSettingValue(Setting.PlayWinAnimationDuration, out tempSettingValue);
            txtPlayWinAnimationDuration.Text = tempSettingValue.Value.ToString();

            //Rally US1998
            Common.GetOpSettingValue(Setting.EnablePeekMode, out tempSettingValue);
            chkPeekMode.Checked = Common.ParseBool(tempSettingValue.Value);

            //START RALLY TA 9171 loss threshold settings
            settingValue = Common.GetSystemSetting(Setting.WiredNetworkLossThreshold);
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
                else
                { 
                
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
            // Set the flag
            m_bModified = false;
            return true;
        }


        private bool SetUIValue()
        {
            string settingValue = "";          
            SettingValue tempSettingValue;            //END RALLY DE 9171 // Fill in the operator global settings   


            if (!DeviceSettingmsg.TryGetSettingValue(Setting.VIPRequiresPIN, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.VIPRequiresPIN, out tempSettingValue);
            }        
            chkPlayerPIN.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            //PlayWinAnimation
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayWinAnimationDuration, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayWinAnimationDuration, out tempSettingValue);
            }
            txtPlayWinAnimationDuration.Text = tempSettingValue.Value.ToString();

            //EnablePeekMode
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.EnablePeekMode, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.EnablePeekMode, out tempSettingValue);
            }
            chkPeekMode.Checked = Common.ParseBool(tempSettingValue.Value);

            //WiredNetworkLossThreshold
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.WiredNetworkLossThreshold, out tempSettingValue))            //Rally US1998
            {
                settingValue = Common.GetSystemSetting(Setting.WiredNetworkLossThreshold);    //START RALLY TA 9171 loss threshold settings
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }
            txtWiredNetworkConnectionLossThreshold.Text = settingValue; 

            //WirelessNetworkLossThreshold
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.WirelessNetworkLossThreshold, out tempSettingValue))            //Rally US1998
            {
                settingValue = Common.GetSystemSetting(Setting.WirelessNetworkLossThreshold);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }
            txtWirelessNetworkConnectionLossThreshold.Text = settingValue;
           
          
            //END RALLY TA 9171
            //Enable Auto Mode Butoton
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.EnableAutoModeButton, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.EnableAutoModeButton, out tempSettingValue);
            }          
            chkAutoModeOn.Checked = Common.ParseBool(tempSettingValue.Value);
            
            //Enable Lock Screen
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.EnableLockScreenButton, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.EnableLockScreenButton, out tempSettingValue);
            }          
            chkLockScreenOn.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4010  
            //Display Verified Card
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.DisplayVerifiedCard, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.DisplayVerifiedCard, out tempSettingValue);
            }          
            chkDisplayVerifiedCard.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4010 
            //Display Fun Game
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.DisplayFunGamesOnLogin, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.DisplayFunGamesOnLogin, out tempSettingValue);
            }
            chkDisplayFunGamesOnLogin.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4538
            //Pattern Shading Enabled
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PatternShadingEnabled, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.PatternShadingEnabled, out tempSettingValue);
            }          
            chkBingoPatternShading.Checked = Common.ParseBool(tempSettingValue.Value);

            //US3860
            //TVWithout Purchase
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.TVWithoutPurchase, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.TVWithoutPurchase, out tempSettingValue);
            }         
            chkTVwoPurchase.Checked = Common.ParseBool(tempSettingValue.Value);

            //US4716
            //Clear winner sceen
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.ClearWinnersScreen, out tempSettingValue))            //Rally US1998
            {
                Common.GetOpSettingValue(Setting.ClearWinnersScreen, out tempSettingValue);
            }        
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
                if (!DeviceSettingmsg.TryGetSettingValue(Setting.AllowFunMultiplayerGames, out tempSettingValue))            //Rally US1998
                {
                    Common.GetOpSettingValue(Setting.AllowFunMultiplayerGames, out tempSettingValue);
                }
                chkEnableMultiplayerOnFunGames.Checked = Common.ParseBool(tempSettingValue.Value);            
            }

            else
                chkEnableMultiplayerOnFunGames.Enabled = false;

            // US4526
            //Player Pin Length        
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayerPinLength, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.PlayerPinLength);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }   
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
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.LogoutPacksOnSessionEnd, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.LogoutPacksOnSessionEnd);
               
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }
                try
                {
                    chkLogoutPackSessionClose.Checked = ParseBool(settingValue);
                }
                catch
                {
                    chkLogoutPackSessionClose.Checked = false;
                }
        
            //US5123
                if (!DeviceSettingmsg.TryGetSettingValue(Setting.DisplayProgressiveOnPlayerUnit, out tempSettingValue))
                {
                    settingValue = Common.GetSystemSetting(Setting.DisplayProgressiveOnPlayerUnit);
                }
                else
                {
                    settingValue = tempSettingValue.Value;
                }       
            try
            {
                chkDisplayProgressives.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkDisplayProgressives.Checked = false;
            }

            //US5137
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayerUnitRoverPackOnReboot, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.PlayerUnitRoverPackOnReboot);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }         
            try
            {
                chkRecoverOnReboot.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkRecoverOnReboot.Checked = false;
            }

            //US5139
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayerUnitsCacheSettings, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.PlayerUnitsCacheSettings);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }                 
            try
            {
                chkCacheSettings.Checked = ParseBool(settingValue);
            }
            catch
            {
                chkCacheSettings.Checked = false;
            }

            //US5171
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayerPinLength, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.PlayerPinLength);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }          
            txtRebootTimeThreshold.Text = settingValue;

            //5175
            //US5139
            if (!DeviceSettingmsg.TryGetSettingValue(Setting.ResetTedeRadioOnWifiInterruptions, out tempSettingValue))
            {
                settingValue = Common.GetSystemSetting(Setting.ResetTedeRadioOnWifiInterruptions);
            }
            else
            {
                settingValue = tempSettingValue.Value;
            }                    
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
            // Set the flag
            m_bModified = false;
            return true;
        }

        private bool LoadPlayerSettings()
        {
            if (DeviceId != 0)
            {
                DeviceSettingmsg = new GetDeviceSettings(DeviceId, 0);  //Get the device setting if set if not then get the operator settings.
                DeviceSettingmsg.Send();

                if (DeviceSettingmsg.DeviceSettingList.Length == 0)//if zero then default is set
                {
                    chkbxUseDefault.Checked = true;
                }
                else
                {
                    chkbxUseDefault.Checked = false;
                }

                if (Common.GetSystemSettings() == false)         //START RALLY DE 9171
                {
                    return false;
                }

                SetUIValue();
            }
            else
            {
                SetValueToDefault();
                if (chkbxUseDefault.Checked != false) { chkbxUseDefault.Checked = false; }
                chkbxUseDefault.Visible = false;
            }
            

            m_bModified = false;
            return true;
        }

       
        private bool SavePlayerSettings()
        {
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            if (chkbxUseDefault.Checked == true || DeviceId == 0)
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
            }
         
            
                s.Id = (int)Setting.VIPRequiresPIN;
                s.Value = chkPlayerPIN.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.PlayWinAnimationDuration;
                s.Value = txtPlayWinAnimationDuration.Text.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.EnablePeekMode;
                s.Value = chkPeekMode.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.EnableAutoModeButton;
                s.Value = chkAutoModeOn.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.EnableLockScreenButton;
                s.Value = chkLockScreenOn.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.DisplayVerifiedCard;
                s.Value = chkDisplayVerifiedCard.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.DisplayFunGamesOnLogin;
                s.Value = chkDisplayFunGamesOnLogin.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.PatternShadingEnabled;
                s.Value = chkBingoPatternShading.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.AllowFunMultiplayerGames;
                s.Value = chkEnableMultiplayerOnFunGames.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.TVWithoutPurchase;
                s.Value = chkTVwoPurchase.Checked.ToString();
                arrSettings.Add(s);

                s.Id = (int)Setting.ClearWinnersScreen;
                s.Value = chkClearWinnersScreen.Checked.ToString();
                arrSettings.Add(s);

          

            // Create a list of just these settings
        

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

            if (chkbxUseDefault.Checked == true || DeviceId == 0)
            {
                // Update the server
                if (!Common.SaveSystemSettings(arrSettings.ToArray()))//knc
                {
                    return false;
                }
                // Save the operator settings
                if (!Common.SaveOperatorSettings())
                {
                    return false;
                }

                Common.SaveDeviceSettings(DeviceId, arrSettings.ToArray(), 1);//delete
            }
            else
            {
                //END RALLY TA 9171
                Common.SaveDeviceSettings(DeviceId, arrSettings.ToArray(), 0);//add
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

        #region Event

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

                txtPlayerPINLength.Text = 4.ToString(); //DE12732
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
                SetValueToDefault();
            }
            else
            {
                groupBox5.Enabled = true;
                SetUIValue();
            }
        }

        #endregion

        #region Properties

        public int DeviceId { get; set; }

        #endregion
    } // end class
} // end namespace
