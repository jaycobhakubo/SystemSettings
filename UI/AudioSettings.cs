using System;
using GTI.Modules.Shared;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Business;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class AudioSettings : SettingsControl
    {
        // Members
        bool m_bModified = false;
        bool m_needsSave = false;
        bool m_isDefault;
        private List<CheckBox> audioCheckBoxList;//FIX RALLY DE 2645 added all audio settings to global variable
        GetDeviceSettingsMessage DeviceSettingmsg;

        public AudioSettings()
        {
            InitializeComponent();
            audioCheckBoxList = new List<CheckBox>{chkPlayBallCallSoundEnabled,  //FIX START RALLY DE 2645 added all audio settings to global variable
            chkPlayKeyClickEnabled,chkPlayModeOneAwaySound,chkPlayWinningSoundEnabled};            //FIX END RALLY DE 2645 added all audio settings to global variable
            InitializeTagsForCheckboxes();
        }

        protected void InitializeTagsForCheckboxes()
        {
            chkPlayAllSoundEnabled.Tag = "Enabled";
            foreach (CheckBox checkBox in audioCheckBoxList)
            {
                checkBox.Tag = "Enabled";
            }
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
            bool bResult = LoadAudioSettings();
            this.ResumeLayout(true);
            Common.EndWait();
            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();
            bool bResult = SavePlayerSettings();
            this.ResumeLayout(true);
            Common.EndWait();
            return bResult;
        }

        #endregion  // Public Methods

        // Private Routines
        #region Private Routines

        private bool SetValueToDefault()
        {
            int intNumber;
            bool boolResult;
            SettingValue tempSettingValue;

            Common.GetOpSettingValue(Setting.PlayAllSoundEnabled, out tempSettingValue);
            chkPlayAllSoundEnabled.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427
            chkPlayAllSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayAllSoundEnabled); //license file

            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayAllSoundEnabled) == false)
            {
                chkPlayAllSoundEnabled.Tag = "Disabled";
                chkPlayAllSoundEnabled.Enabled = false;
            }

            Common.GetOpSettingValue(Setting.PlayModeOneAwaySound, out tempSettingValue);
            chkPlayModeOneAwaySound.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            chkPlayModeOneAwaySound.Enabled = Common.GetSettingEnabled(Setting.PlayModeOneAwaySound);  //license file

            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayModeOneAwaySound) == false)
            {
                chkPlayModeOneAwaySound.Tag = "Disabled";
            }

            Common.GetOpSettingValue(Setting.PlayWinningSoundEnabled, out tempSettingValue);
            chkPlayWinningSoundEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

            //license file
            chkPlayWinningSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayWinningSoundEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayWinningSoundEnabled) == false)
            {
                chkPlayWinningSoundEnabled.Tag = "Disabled";
            }

            Common.GetOpSettingValue(Setting.PlayBallCallSoundEnabled, out tempSettingValue);
            chkPlayBallCallSoundEnabled.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427

            //license file
            chkPlayBallCallSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayBallCallSoundEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayBallCallSoundEnabled) == false)
            {
                chkPlayBallCallSoundEnabled.Tag = "Disabled";
            }
            Common.GetOpSettingValue(Setting.PlayKeyClickEnabled, out tempSettingValue);
            chkPlayKeyClickEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

            //license file
            chkPlayKeyClickEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayKeyClickEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayKeyClickEnabled) == false)
            {
                chkPlayKeyClickEnabled.Tag = "Disabled";
            }
            Common.GetOpSettingValue(Setting.MaxVolume, out tempSettingValue);

            //  chkPlayKeyClickEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427         
            boolResult = Int32.TryParse(tempSettingValue.Value, out intNumber);
            if (boolResult)
            {
                numMaxGameVolume.Value = ParseInt(tempSettingValue.Value);
            }
            else
            {
                numMaxGameVolume.Value = 1;
            }

            //FIX START RALLY DE 2645 added all audio settings to global variable
            foreach (CheckBox checkBox in audioCheckBoxList)
            {
                //make sure the enabled part is not part of the license file settings
                if (checkBox.Tag.ToString() != "Disabled")
                {
                    checkBox.Enabled = chkPlayAllSoundEnabled.Checked;
                }
                //RALLY DE8763
                else
                {
                    checkBox.Enabled = false;
                }

                if (checkBox.Checked == true && chkPlayAllSoundEnabled.Checked == false)
                {
                    m_needsSave = true;
                    checkBox.Checked = false;
                }
                //END RALLY DE8763
            }

            maxVolumeLabel.Enabled = chkPlayAllSoundEnabled.Checked;
            numMaxGameVolume.Enabled = chkPlayAllSoundEnabled.Checked;
            MaxTVVolumeLabel.Enabled = chkPlayAllSoundEnabled.Checked;
            numMaxTVVolume.Enabled = chkPlayAllSoundEnabled.Checked;

            if (m_needsSave)
            {
                SavePlayerSettings();
                m_needsSave = false;
            }

            m_bModified = false;
            return true;
        }



        private bool SetUIValue()
        {
            //  string settingValue = "";
            int intNumber;
            bool boolResult;
            SettingValue tempSettingValue;

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayAllSoundEnabled, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayAllSoundEnabled, out tempSettingValue);
                return false;
            }
            chkPlayAllSoundEnabled.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427
            chkPlayAllSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayAllSoundEnabled); //license file

            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayAllSoundEnabled) == false)
            {
                chkPlayAllSoundEnabled.Tag = "Disabled";
                chkPlayAllSoundEnabled.Enabled = false;
            }

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayModeOneAwaySound, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayModeOneAwaySound, out tempSettingValue);
            }
            chkPlayModeOneAwaySound.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            chkPlayModeOneAwaySound.Enabled = Common.GetSettingEnabled(Setting.PlayModeOneAwaySound);  //license file

            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayModeOneAwaySound) == false)
            {
                chkPlayModeOneAwaySound.Tag = "Disabled";
            }

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayWinningSoundEnabled, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayWinningSoundEnabled, out tempSettingValue);
            }
            chkPlayWinningSoundEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

            //license file
            chkPlayWinningSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayWinningSoundEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayWinningSoundEnabled) == false)
            {
                chkPlayWinningSoundEnabled.Tag = "Disabled";
            }

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayBallCallSoundEnabled, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayBallCallSoundEnabled, out tempSettingValue);
            }
            chkPlayBallCallSoundEnabled.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427

            //license file
            chkPlayBallCallSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayBallCallSoundEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayBallCallSoundEnabled) == false)
            {
                chkPlayBallCallSoundEnabled.Tag = "Disabled";
            }

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.PlayKeyClickEnabled, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.PlayKeyClickEnabled, out tempSettingValue);
            }
            chkPlayKeyClickEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

            //license file
            chkPlayKeyClickEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayKeyClickEnabled);
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayKeyClickEnabled) == false)
            {
                chkPlayKeyClickEnabled.Tag = "Disabled";
            }

            if (!DeviceSettingmsg.TryGetSettingValue(Setting.MaxVolume, out tempSettingValue))
            {
                Common.GetOpSettingValue(Setting.MaxVolume, out tempSettingValue);
            }
            //  chkPlayKeyClickEnabled.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427         
            boolResult = Int32.TryParse(tempSettingValue.Value, out intNumber);
            if (boolResult)
            {
                numMaxGameVolume.Value = ParseInt(tempSettingValue.Value);
            }
            else
            {
                numMaxGameVolume.Value = 1;
            }

            //FIX START RALLY DE 2645 added all audio settings to global variable
            foreach (CheckBox checkBox in audioCheckBoxList)
            {
                //make sure the enabled part is not part of the license file settings
                if (checkBox.Tag.ToString() != "Disabled")
                {
                    checkBox.Enabled = chkPlayAllSoundEnabled.Checked;
                }
                //RALLY DE8763
                else
                {
                    checkBox.Enabled = false;
                }

                if (checkBox.Checked == true && chkPlayAllSoundEnabled.Checked == false)
                {
                    m_needsSave = true;
                    checkBox.Checked = false;
                }
                //END RALLY DE8763
            }

            maxVolumeLabel.Enabled = chkPlayAllSoundEnabled.Checked;
            numMaxGameVolume.Enabled = chkPlayAllSoundEnabled.Checked;
            MaxTVVolumeLabel.Enabled = chkPlayAllSoundEnabled.Checked;
            numMaxTVVolume.Enabled = chkPlayAllSoundEnabled.Checked;

            if (m_needsSave)
            {
                SavePlayerSettings();
                m_needsSave = false;
            }
            //FIX END RALLY DE 2645 added all audio settings to global variable
            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool LoadAudioSettings()
        {
            bool tResult = false;
            if (DeviceId != 0)
            {
                DeviceSettingmsg = new GetDeviceSettingsMessage(DeviceId, 0);  //Get the device setting if set if not then get the operator settings.
                DeviceSettingmsg.Send();
                tResult = SetUIValue();

                if (DeviceSettingmsg.DeviceSettingList.Length == 0 || tResult == false)//if zero then default is set
                {
                    if (chkbxUseDefault.Checked != true)
                    {
                        chkbxUseDefault.Checked = true;                     
                    }
                    else
                    {
                        SetValueToDefault();
                    }
                    m_isDefault = true;
                }
                else
                {
                    chkbxUseDefault.Checked = false;
                    m_isDefault = false;
                }
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
            // Update the operator global settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            if (m_isDefault != chkbxUseDefault.Checked)
            {
                m_isDefault = chkbxUseDefault.Checked;
            }

            //license file
            if (chkPlayAllSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                if (chkbxUseDefault.Checked == true || DeviceId == 0)
                {
                    Common.SetOpSettingValue(Setting.PlayAllSoundEnabled, chkPlayAllSoundEnabled.Checked.ToString());
                }
                s.Id = (int)Setting.PlayAllSoundEnabled;
                s.Value = chkPlayAllSoundEnabled.Checked.ToString();
                arrSettings.Add(s);
            }

            //license file
            if (chkPlayModeOneAwaySound.Tag.ToString() == "Enabled" || m_needsSave)
            {
                if (chkbxUseDefault.Checked == true || DeviceId == 0)
                {
                    Common.SetOpSettingValue(Setting.PlayModeOneAwaySound, chkPlayModeOneAwaySound.Checked.ToString());
                }
                s.Id = (int)Setting.PlayModeOneAwaySound;
                s.Value = chkPlayModeOneAwaySound.Checked.ToString();
                arrSettings.Add(s);
            }

            //license file
            if (chkPlayWinningSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                if (chkbxUseDefault.Checked == true || DeviceId == 0)
                {
                    Common.SetOpSettingValue(Setting.PlayWinningSoundEnabled, chkPlayWinningSoundEnabled.Checked.ToString());
                }
                s.Id = (int)Setting.PlayWinningSoundEnabled;
                s.Value = chkPlayWinningSoundEnabled.Checked.ToString();
                arrSettings.Add(s);
            }

            //license file
            if (chkPlayBallCallSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                if (chkbxUseDefault.Checked == true || DeviceId == 0)
                {
                    Common.SetOpSettingValue(Setting.PlayBallCallSoundEnabled, chkPlayBallCallSoundEnabled.Checked.ToString());
                }
                s.Id = (int)Setting.PlayBallCallSoundEnabled;
                s.Value = chkPlayBallCallSoundEnabled.Checked.ToString();
                arrSettings.Add(s);
            }

            //license file
            if (chkPlayKeyClickEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                if (chkbxUseDefault.Checked == true || DeviceId == 0)
                {
                    Common.SetOpSettingValue(Setting.PlayKeyClickEnabled, chkPlayKeyClickEnabled.Checked.ToString());
                }
                s.Id = (int)Setting.PlayKeyClickEnabled;
                s.Value = chkPlayKeyClickEnabled.Checked.ToString();
                arrSettings.Add(s);
            }

            if (chkbxUseDefault.Checked == true || DeviceId == 0)
            {
                Common.SetOpSettingValue(Setting.MaxVolume, numMaxGameVolume.Value.ToString());
            }
            s.Id = (int)Setting.MaxVolume;
            s.Value = numMaxGameVolume.Value.ToString();
            arrSettings.Add(s);


            //RALLY 

            if (chkbxUseDefault.Checked == true || DeviceId == 0)
            {
                Common.SetOpSettingValue(Setting.MaxtvVolume, numMaxTVVolume.Value.ToString());
            }
            s.Id = (int)Setting.MaxtvVolume;
            s.Value = numMaxTVVolume.Value.ToString();
            arrSettings.Add(s);


            if (chkbxUseDefault.Checked == true || DeviceId == 0)
            {
                // Save the operator settings
                if (!Common.SaveOperatorSettings())
                {
                    return false;
                }
                Common.SaveDeviceSettings(DeviceId, arrSettings.ToArray(), 1);
            }
            else
            {
                Common.SaveDeviceSettings(DeviceId, arrSettings.ToArray(), 0);
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
        //FIX START RALLY DE 2645 added all audio settings to global variable
        private void chkPlayAllSoundEnabled_CheckedChanged(object sender, EventArgs e)
        {
            m_bModified = true;
            //if the option is checked then allow rest of list to be enabled
            foreach (CheckBox checkBox in audioCheckBoxList)
            {
                //make sure the checkbox is not part of the license file
                if (checkBox.Tag.ToString() != "Disabled")
                {
                    checkBox.Enabled = chkPlayAllSoundEnabled.Checked;
                    if (chkPlayAllSoundEnabled.Checked == false)
                    {
                        checkBox.Checked = chkPlayAllSoundEnabled.Checked;
                    }
                }
            }
            maxVolumeLabel.Enabled = chkPlayAllSoundEnabled.Checked;
            numMaxGameVolume.Enabled = chkPlayAllSoundEnabled.Checked;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkPlayAllSoundEnabled.Focus();
        }

        private void chkbxUseDefault_CheckedChanged(object sender, EventArgs e)
        {

            Common.BeginWait();
            this.SuspendLayout();

            if (chkbxUseDefault.Checked == true || DeviceId == 0)
            {
                groupBox5.Enabled = false;
                SetValueToDefault();
            }
            else
            {
                groupBox5.Enabled = true;
                SetUIValue();
            }

            if (chkbxUseDefault.Checked != m_isDefault)
            {
                m_bModified = true;
            }

            this.ResumeLayout(true);
            Common.EndWait();
        }

        public int DeviceId { get; set; }
        //FIX END RALLY DE 2645 added all audio settings to global variable

    } // end class
} // end namespace
