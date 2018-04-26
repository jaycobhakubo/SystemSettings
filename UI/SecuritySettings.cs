using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;


namespace GTI.Modules.SystemSettings.UI
{
    public partial class SecuritySettings : SettingsControl
    {
        // Members
        bool m_bModified = false;
      
        public SecuritySettings()
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

            bool bResult = LoadSecuritySettings();
            m_bModified = false;
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
        #endregion  // Public Methods

        // Private Routines
        #region Private Routines

        /// <summary>
        /// Loads the security settings into the UI
        /// </summary>
        /// <returns></returns>
        private bool LoadSecuritySettings()
        {
            // Fill in  global settings

            int result = 0;
            bool boolResult = false;
            bool saveFlag = false;
            string tempString = Common.GetSystemSetting(Setting.MinimumPasswordLength);
            if (int.TryParse(tempString, out result)
                && (result <= numMinimumPasswordLength.Maximum)
                && result >= numMinimumPasswordLength.Minimum)
            {
                numMinimumPasswordLength.Value = result;
            }
            else
            {
                numMinimumPasswordLength.Value = numMinimumPasswordLength.Minimum;
                saveFlag = true;
            }

            //Start Rally DE9748
            tempString = Common.GetSystemSetting(Setting.MaxStaffMachines);
            if (int.TryParse(tempString, out result)
                && (result <= numMaxLoginLimit.Maximum)
                && result >= numMaxLoginLimit.Minimum)
            {
                numMaxLoginLimit.Value = result;
            }
            else
            {
                numMaxLoginLimit.Value = numMaxLoginLimit.Minimum;
                saveFlag = true;

            }
            //End Rally DE9748

            tempString = Common.GetSystemSetting(Setting.AutomaticUnlockTime);
            if (int.TryParse(tempString, out result)
                && (result <= numAutomaticUnlockTime.Maximum)
                && result >= numAutomaticUnlockTime.Minimum)
            {
                numAutomaticUnlockTime.Value = result;
            }
            else
            {
                numAutomaticUnlockTime.Value = numAutomaticUnlockTime.Minimum;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.PreviousPasswordNumber);
            if (int.TryParse(tempString, out result)
                && (result <= numPreviousPasswordReuse.Maximum)
                && result >= numPreviousPasswordReuse.Minimum)
            {
                numPreviousPasswordReuse.Value = result;
            }
            else
            {
                numPreviousPasswordReuse.Value = numPreviousPasswordReuse.Minimum;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.PasswordLockoutAttempts);
            if (int.TryParse(tempString, out result)
                && (result <= numPasswordLockOutAttempts.Maximum)
                && result >= numPasswordLockOutAttempts.Minimum)
            {
                numPasswordLockOutAttempts.Value = result;
            }
            else
            {
                numPasswordLockOutAttempts.Value = 0;
                saveFlag = true;
            }

            decimal expiringDays; // DE13056 the range has to be set first
            string expiringDaysString;
            byte minMax = Common.GetSettingMinMax(Setting.PinExpireDays, out expiringDaysString);

            if (!string.IsNullOrEmpty(expiringDaysString))
            {
                expiringDays = ParseDecimal(expiringDaysString);

                if (minMax == 2)
                {
                    if (expiringDays > 0)
                    {
                        numPinExpireDays.Maximum = expiringDays;
                        numPinExpireDays.Minimum = 1; // if the setting exists, then '0' or 'doesn't expire' is not allowed.
                    }
                }
            }

            tempString = Common.GetSystemSetting(Setting.PinExpireDays);
            if (int.TryParse(tempString, out result)
                && (result <= numPinExpireDays.Maximum)
                && result >= numPinExpireDays.Minimum)
            {
                numPinExpireDays.Value = result;
            }
            else
            {
                //if the expiring days are not zero and the value is currently greater than the expiring days
                //or the value is unlimited then set it to the max value
                numPinExpireDays.Value = numPinExpireDays.Maximum;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.PasswordComplexitySetting);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkUsePasswordComplexity.Checked = boolResult;
            }
            else
            {
                chkUsePasswordComplexity.Checked = false;
                saveFlag = true;
            }

            //Start RALLY US2057
            tempString = Common.GetSystemSetting(Setting.UsePasswordKeypad);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkUseNumericKeypad.Checked = boolResult;
                if (chkUseNumericKeypad.Checked == true && chkUsePasswordComplexity.Checked == true)
                {
                    chkUseNumericKeypad.Checked = false;
                    saveFlag = true;
                }
            }
            //END RALLY US2057

            //START RALLY TA 10508
            tempString = Common.GetSystemSetting(Setting.ScreenSaverEnabled);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkScreenSaverEnabled.Checked = boolResult;
            }
            else
            {
                chkScreenSaverEnabled.Checked = false;
                saveFlag = true;
            }

            tempString = Common.GetSystemSetting(Setting.ScreenSaverWait);
            if (int.TryParse(tempString, out result)
                && (result <= numScreenSaverWait.Maximum)
                && result >= numScreenSaverWait.Minimum)
            {
                numScreenSaverWait.Value = result;
            }
            else
            {
                numScreenSaverWait.Value = numScreenSaverWait.Minimum;
                saveFlag = true;
            }
            //END RALLY TA 10508

            //US5294
            tempString = Common.GetSystemSetting(Setting.InactiveAutoLogout);
            if (bool.TryParse(tempString, out boolResult))
            {
                chkAutoLogout.Checked = boolResult;
            }
            else
            {
                chkAutoLogout.Checked = false;
                saveFlag = true;
            }

            numPinExpireDays.Enabled = Common.GetSettingEnabled(Setting.PinExpireDays);
            if (numPinExpireDays.Enabled == false)//RALLY DE 6754 pin expire days was not set correctly
            {
                numPinExpireDays.Enabled = false;
                pinExpireDaysLabel.Enabled = false;
            }

            // Set the flag
            m_bModified = false;

            chkScreenSaverEnabled_CheckedChanged(null, new EventArgs()); // force update of UI

            if (saveFlag == true)
            {
                SaveSecuritySettings();
            }
            return true;
        }

        /// <summary>
        /// Saves the security settings from the UI to the server
        /// </summary>
        /// <returns></returns>
        private bool SaveSecuritySettings()
        {
            
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.MinimumPasswordLength;
            s.Value = numMinimumPasswordLength.Value.ToString();
            arrSettings.Add(s);

            //Start Rally DE9748
            s.Id = (int)Setting.MaxStaffMachines;
            s.Value = numMaxLoginLimit.Value.ToString();
            arrSettings.Add(s);
            //End Rally DE9748

            s.Id = (int)Setting.AutomaticUnlockTime;
            s.Value = numAutomaticUnlockTime.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PreviousPasswordNumber;
            s.Value = numPreviousPasswordReuse.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PasswordLockoutAttempts;
            s.Value = numPasswordLockOutAttempts.Value.ToString();
            arrSettings.Add(s);

            //set pin expires
            //RALLY DE 4426 START changed pin expire days to a global setting
            //RALLY DE 6791 pin expire days was not set from the license file correctly
            if (numPinExpireDays.Enabled)
            {
                s.Id = (int)Setting.PinExpireDays;
                s.Value = numPinExpireDays.Value.ToString();
                arrSettings.Add(s);
            }
            //END RALLY DE 6791
            //END RALLY DE 4426

            s.Id = (int)Setting.UsePasswordKeypad;
            s.Value = chkUseNumericKeypad.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PasswordComplexitySetting;
            s.Value = chkUsePasswordComplexity.Checked.ToString();
            arrSettings.Add(s);

            //START RALLY TA 10508
            s.Id = (int)Setting.ScreenSaverEnabled;
            s.Value = chkScreenSaverEnabled.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ScreenSaverWait;
            s.Value = numScreenSaverWait.Value.ToString();
            arrSettings.Add(s);
            //END RALLY TA 10508

            //US5294
            s.Id = (int)Setting.InactiveAutoLogout;
            s.Value = chkAutoLogout.Checked.ToString();
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

        #endregion // Private Routines

       

        //START RALLY DE9445
        private void chkUsePasswordComplexity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsePasswordComplexity.Checked)
            {
                if (numMinimumPasswordLength.Value < 3)
                {
                    numMinimumPasswordLength.Value = 3;
                }

                chkUseNumericKeypad.Checked = false;
                chkUseNumericKeypad.Enabled = false;
            }
            else
            {
                chkUseNumericKeypad.Enabled = true;
            }
            m_bModified = true;
        }

        //END RALLY DE9445

        private void chkScreenSaverEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScreenSaverEnabled.Checked)
                chkAutoLogout.Enabled = true;
            else
                chkAutoLogout.Enabled = false;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

    } // end class
} // end namespace
