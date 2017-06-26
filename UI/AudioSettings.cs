using System;
using GTI.Modules.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class AudioSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        bool m_needsSave = false;
	    private List<CheckBox> audioCheckBoxList;//FIX RALLY DE 2645 added all audio settings to global variable


		public AudioSettings()
		{
			InitializeComponent();
            //FIX START RALLY DE 2645 added all audio settings to global variable
            audioCheckBoxList = new List<CheckBox>{chkPlayBallCallSoundEnabled,
                chkPlayKeyClickEnabled,chkPlayModeOneAwaySound,chkPlayWinningSoundEnabled};
            //FIX END RALLY DE 2645 added all audio settings to global variable
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

			bool bResult = SavePlayerSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods

		// Private Routines
		#region Private Routines

		private bool LoadAudioSettings()
		{
            int intNumber;
            bool boolResult;
//            bool flag;  //RALLY DE9427

			// Fill in the operator global settings            
			SettingValue tempSettingValue;

            Common.GetOpSettingValue(Setting.PlayAllSoundEnabled, out tempSettingValue);
            chkPlayAllSoundEnabled.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427
           
            //license file
		    chkPlayAllSoundEnabled.Enabled = Common.GetSettingEnabled(Setting.PlayAllSoundEnabled);
            
            //set the tag from the license file if it is disabled
            if (Common.GetSettingEnabled(Setting.PlayAllSoundEnabled) == false)
            {
                chkPlayAllSoundEnabled.Tag = "Disabled";
                chkPlayAllSoundEnabled.Enabled = false;
            }

            Common.GetOpSettingValue(Setting.PlayModeOneAwaySound, out tempSettingValue);
            chkPlayModeOneAwaySound.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            //license file
		    chkPlayModeOneAwaySound.Enabled = Common.GetSettingEnabled(Setting.PlayModeOneAwaySound);
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

		private bool SavePlayerSettings()
		{
			// Update the operator global settings
            
            //license file
            if(chkPlayAllSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                Common.SetOpSettingValue(Setting.PlayAllSoundEnabled, chkPlayAllSoundEnabled.Checked.ToString());
            }

            //license file
            if (chkPlayModeOneAwaySound.Tag.ToString() == "Enabled" || m_needsSave)
            {
                Common.SetOpSettingValue(Setting.PlayModeOneAwaySound, chkPlayModeOneAwaySound.Checked.ToString());
            }

            //license file
            if (chkPlayWinningSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                Common.SetOpSettingValue(Setting.PlayWinningSoundEnabled, chkPlayWinningSoundEnabled.Checked.ToString());
            }

            //license file
            if (chkPlayBallCallSoundEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                Common.SetOpSettingValue(Setting.PlayBallCallSoundEnabled, chkPlayBallCallSoundEnabled.Checked.ToString());
            }

            //license file
            if (chkPlayKeyClickEnabled.Tag.ToString() == "Enabled" || m_needsSave)
            {
                Common.SetOpSettingValue(Setting.PlayKeyClickEnabled, chkPlayKeyClickEnabled.Checked.ToString());
            }

            Common.SetOpSettingValue(Setting.MaxVolume, numMaxGameVolume.Value.ToString());
		    //RALLY 
            Common.SetOpSettingValue(Setting.MaxtvVolume, numMaxTVVolume.Value.ToString());
			

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

        
        //FIX END RALLY DE 2645 added all audio settings to global variable
        
	} // end class
} // end namespace
