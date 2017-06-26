using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.UI
{
    /// <summary>
    /// This Control has the Bingo Play mode Settings
    /// </summary>
 
	public partial class PlayModeSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
	    public List<CheckableSetting> m_settingList;
        public List<CheckBox> m_checkBoxList;
	    private int m_playMode;
        //FIX: RALLY DE2390 Updated Play Modes Start:
        /// <summary>
        /// Initializes the PlayModeSettings Control
        /// </summary>
        public PlayModeSettings()
		{
			InitializeComponent();
            m_settingList = new List<CheckableSetting>();
            m_checkBoxList = new List<CheckBox>{m_chkAllowCatchUp,m_chkAllowDaubOnImage, //RALLY DE 6346 remove green button daub 
                m_chkAllowPreCallErrors,m_chkAllowPreDaubing};//RALLY DE 6346 remove green button daub 
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

			SuspendLayout();

			bool bResult = LoadPlayerSettings();


			ResumeLayout(true);
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

        private void DisplayCheckableSettings()
        {
            //clear check boxes
            foreach(CheckBox checkBox in m_checkBoxList)
            {
                checkBox.Visible = false;
            }

            foreach(CheckableSetting setting in m_settingList)
            {
                CheckBox currentCheckBox =
                        m_checkBoxList.Find(i => ((CheckableSetting)i.Tag).settingName == setting.settingName);
                currentCheckBox.Visible = true;
                currentCheckBox.Checked = setting.value.Value.Equals(bool.TrueString);
                currentCheckBox.Enabled = false;
                
                foreach(int visibilitySetting in setting.settingVisibility)
                {
                    if(visibilitySetting == m_playMode)
                    {
                        if (setting.isGreyed || setting.licenseEnabled == false)
                        {
                            currentCheckBox.Enabled = false;

                        }
                        else
                        {
                            currentCheckBox.Enabled = true;
                        }
                        break;
                    }
                }
            }
        }

        private CheckableSetting AddSettingToList(Setting settingId, SettingValue value, string name, List<int> playMode, bool licenseEnabled)
        {
            CheckableSetting newSetting = new CheckableSetting();
            newSetting.settingId = settingId;
            newSetting.value = value;
            newSetting.settingName = name;
            newSetting.settingVisibility = playMode;
            if(newSetting.value.Value == "False")
                newSetting.isGreyed = true;
            newSetting.licenseEnabled = licenseEnabled;
            m_settingList.Add(newSetting);    
            
            return newSetting;
        }

		private bool LoadPlayerSettings()
		{

		    bool licenseValue;
		    // Fill in the operator global settings            
		    SettingValue tempSettingValue = new SettingValue();
		    m_settingList.Clear();

		    //Get the play Mode
		    //the play mode comes from the operator settings

            Common.GetOpSettingValue(Setting.RFMode, out tempSettingValue);
            licenseValue = Common.GetSettingEnabled(Setting.RFMode);

            
            if (licenseValue == false)
            {
                m_rdoButtonAuto.Enabled = false;
                m_rdoButtonManual.Enabled = false;
                m_rdoButtonSemiAuto.Enabled = false;
            }
            //START RALLY DE 6624
            else
            {
                string value;
                byte minMax = Common.GetSettingMinMax(Setting.RFMode, out value);
                if (value != null)
                {
                    if (minMax == 1)
                    {
                        int minimum = Convert.ToInt32(value);
                        //complete auto dont disable anything
                        if (minimum == 1)
                        {
                            m_rdoButtonAuto.Enabled = true;
                            m_rdoButtonManual.Enabled = true;
                            m_rdoButtonSemiAuto.Enabled = true;
                        }
                        //semi auto disable auto
                        else if (minimum == 2)
                        {
                            m_rdoButtonAuto.Enabled = false;
                            m_rdoButtonManual.Enabled = true;
                            m_rdoButtonSemiAuto.Enabled = true;
                        }
                        //manual disable auto and semi-auto and manual since you can't select anything else
                        else if (minimum == 3)
                        {
                            m_rdoButtonAuto.Enabled = false;
                            m_rdoButtonManual.Enabled = false;
                            m_rdoButtonSemiAuto.Enabled = false;
                        }

                    }

                }
            }
            //END RALLY DE 6624
        
		    m_playMode = ParseInt(tempSettingValue.Value);
		    
            m_cboPlayDaubLocation.Visible = true;
		    m_daubLocationTextBox.Visible = true;
		    
            m_cboPlayDaubLocation.Enabled = false;
		    m_daubLocationTextBox.Enabled = false;

            //lists to define in what playmode type to show the checkable settings
            //1 = Auto, 2 = semiAuto, 3 = Manual
            List<int> semiAuto = new List<int>(){2};
            List<int> semiAutoManual = new List<int>(){2,3};
           

		    Common.GetOpSettingValue(Setting.PlayModeCatchUpEnabled, out tempSettingValue);
		    //license file
            licenseValue = Common.GetSettingEnabled(Setting.PlayModeCatchUpEnabled);
            m_chkAllowCatchUp.Tag =AddSettingToList(Setting.PlayModeCatchUpEnabled, tempSettingValue, "Allow Daub Catch Up", semiAuto,licenseValue);
		    
		    Common.GetOpSettingValue(Setting.PlayModePreDaubEnabled, out tempSettingValue);
		    //license file
            licenseValue = Common.GetSettingEnabled(Setting.PlayModePreDaubEnabled);
            m_chkAllowPreDaubing.Tag = AddSettingToList(Setting.PlayModePreDaubEnabled, tempSettingValue, "Allow Pre Daubing", semiAuto, licenseValue);

		    Common.GetOpSettingValue(Setting.PlayModePreDaubErrorsEnabled, out tempSettingValue);
            //license file
            licenseValue = Common.GetSettingEnabled(Setting.PlayModePreDaubErrorsEnabled);
            m_chkAllowPreCallErrors.Tag = AddSettingToList(Setting.PlayModePreDaubErrorsEnabled, tempSettingValue, "Allow Pre Call Daub Errors", semiAuto,licenseValue);

           

            //START FIX RALLY DE2849 -- removed combo box dependancy on allow pre daub
            
            //END FIX RALLY DE2849 -- removed combo box dependancy on allow pre daub
            
            
		    Common.GetOpSettingValue(Setting.PlayModeDaubOnImageEnabled, out tempSettingValue);
            //license file
            licenseValue = Common.GetSettingEnabled(Setting.PlayModeDaubOnImageEnabled);
		    m_chkAllowDaubOnImage.Tag = AddSettingToList(Setting.PlayModeDaubOnImageEnabled, tempSettingValue, "Allow Daub on Ball Image", semiAutoManual,licenseValue);
            ((CheckableSetting)m_chkAllowDaubOnImage.Tag).isGreyed = false;
            
            Common.GetOpSettingValue(Setting.PlayModeGreenDaubEnabled, out tempSettingValue);
            licenseValue = Common.GetSettingEnabled(Setting.PlayModeGreenDaubEnabled);
            //RALLY START DE 6346 Deleted
            //m_chkAllowGreenButtonDaub.Tag = AddSettingToList(Setting.PlayModeGreenDaubEnabled, tempSettingValue, "Allow Green Button Daub", semiAuto,licenseValue);
		    //((CheckableSetting) m_chkAllowGreenButtonDaub.Tag).isGreyed = false;
            //RALLY DE 6346 END
            Common.GetOpSettingValue(Setting.PlayDaubLocation, out tempSettingValue);
		    //license file
            licenseValue = Common.GetSettingEnabled(Setting.PlayDaubLocation);
            
            m_cboPlayDaubLocation.SelectedIndex = Math.Min(3, Math.Max(0, ParseInt(tempSettingValue.Value) - 1));
            m_cboPlayDaubLocation.Tag = licenseValue.ToString();
            
            //START DE2849
            //START FIX RALLY DE2661 -- changed the update based on play mode
            if (((CheckableSetting)m_chkAllowCatchUp.Tag).value.Value == "False" &&
                 m_playMode == 2 && ((CheckableSetting)m_chkAllowPreDaubing.Tag).value.Value == "False" && 
                 m_cboPlayDaubLocation.Tag.ToString() == "True")//RALLY DE 5485 Added play mode location dependancy on allow pre daub checkbox
            {
                m_daubLocationTextBox.Enabled = true;
                m_cboPlayDaubLocation.Enabled = true;
            }
            //END DE2661
            //END DE2849
            if (m_cboPlayDaubLocation.Tag.ToString() == "False" &&
                m_cboPlayDaubLocation.SelectedIndex <2)
            {
                m_chkAllowPreDaubing.Enabled = false;
                m_chkAllowPreCallErrors.Enabled = false;
                ((CheckableSetting)m_chkAllowPreDaubing.Tag).licenseEnabled = false;
                ((CheckableSetting)m_chkAllowPreCallErrors.Tag).licenseEnabled = false;
            }
            //START FIX RALLY DE2661 -- this needs to be done after the new control 
            //is displayed
            if (m_playMode == 1)
            {
                m_rdoButtonAuto.Checked = true;
            }

            else if (m_playMode == 2)
            {
                m_rdoButtonSemiAuto.Checked = true;
            }

            else
            {
                m_rdoButtonManual.Checked = true;
            }
            //END FIX RALLY DE2661
            
            OnModified(m_cboPlayDaubLocation,new EventArgs());

		    DisplayCheckableSettings();
			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SavePlayerSettings()
		{
			// Update the operator global settings

            //Save the play mode
            Common.SetOpSettingValue(Setting.RFMode, m_playMode.ToString());
                     
            //save all the checkable settings
            foreach (CheckableSetting setting in m_settingList)
            {
                Common.SetOpSettingValue(setting.settingId, setting.value.Value);
            }

            //save the unique settings that are not checkable
            Common.SetOpSettingValue(Setting.PlayDaubLocation, Convert.ToString(m_cboPlayDaubLocation.SelectedIndex + 1));
            
		   

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
        
        private static void ToggleSettingValue(CheckableSetting setting)
        {
            if(setting.value.Value == "False")
            {
                setting.value.Value = "True";
            }

            else if(setting.value.Value == "True")
            {
                setting.value.Value = "False";
            }
        }

        private void setSettingsToFalse()
        {
            CheckableSetting allowPreDaubSetting = m_settingList.Find(i => i.settingId == Setting.PlayModePreDaubEnabled);
            CheckableSetting allowPreDaubErrors = m_settingList.Find(i => i.settingId == Setting.PlayModePreDaubErrorsEnabled);
            CheckableSetting allowCatchUp = m_settingList.Find(i => i.settingId == Setting.PlayModeCatchUpEnabled);
            
            if(allowPreDaubErrors.licenseEnabled == true)
            {
                allowPreDaubErrors.value.Value = "False";
            }
            
            allowPreDaubErrors.isGreyed = true;
            
            if(allowCatchUp.licenseEnabled == true)
            {
                allowCatchUp.value.Value = "False";
            }
            
            allowCatchUp.isGreyed = true;
            
            if(allowPreDaubSetting.licenseEnabled == true)
            {
                allowPreDaubSetting.value.Value = "False";
            }
            
            allowPreDaubSetting.isGreyed = true;
        }

        private void UpdateModel(CheckableSetting setting)
        {
            CheckableSetting preDaubErrors =
                    m_settingList.Find(i => Setting.PlayModePreDaubErrorsEnabled == i.settingId);
            CheckableSetting preDaubSetting =
                       m_settingList.Find(i => Setting.PlayModePreDaubEnabled == i.settingId);
            
            if (setting.settingId == Setting.PlayModeCatchUpEnabled)
            {
              

                if (setting.value.Value == "True")
                {
                    preDaubSetting.isGreyed = true;
                    if(preDaubSetting.licenseEnabled == true)
                    {
                        preDaubSetting.value.Value = "False";
                    }
                    preDaubErrors.isGreyed = true;
                    
                    if(preDaubErrors.licenseEnabled == true)
                    {
                        preDaubErrors.value.Value = "False";
                    }
                    
                    if(m_cboPlayDaubLocation.Tag.ToString() == "True")
                    {
                        m_cboPlayDaubLocation.SelectedIndex = 0;
                    }
                    else
                    {
                        if (m_cboPlayDaubLocation.SelectedIndex < 2)
                        {
                            preDaubSetting.isGreyed = true;
                            preDaubErrors.isGreyed = true;
                        }
                    }
                    m_cboPlayDaubLocation.Enabled = false;
                    m_daubLocationTextBox.Enabled = false;
                }

                else
                {
                    if(preDaubSetting.licenseEnabled == true)
                    {
                        preDaubSetting.isGreyed = false;
                    }

                    if (preDaubSetting.value.Value == "True")
                    {
                        preDaubErrors.isGreyed = false;
                    }

                    if (m_cboPlayDaubLocation.Tag.ToString() == "True")
                    {
                        m_cboPlayDaubLocation.Enabled = true;
                        m_daubLocationTextBox.Enabled = true;
                    }
                    else
                    {
                        if (m_cboPlayDaubLocation.SelectedIndex < 2)
                        {
                            preDaubSetting.isGreyed = true;
                            preDaubErrors.isGreyed = true;
                        }
                    }
                }
            }

            else if (setting.settingId == Setting.PlayModePreDaubEnabled)
            {
                CheckableSetting catchUpSetting =
                       m_settingList.Find(i => Setting.PlayModeCatchUpEnabled == i.settingId);

                if (setting.value.Value == "True")
                {
                    catchUpSetting.isGreyed = true;
                    if(catchUpSetting.licenseEnabled == true)
                    {
                        catchUpSetting.value.Value = "False";
                    }
                    if(preDaubErrors.licenseEnabled == true)
                    {
                        preDaubErrors.isGreyed = false;
                    }
                    //START RALLY DE 5485 play daub location is dependent on play mode pre daub enabled
                    if (m_cboPlayDaubLocation.Tag.ToString() == "True")
                    {
                        m_cboPlayDaubLocation.SelectedIndex = 2;
                    }
                        m_cboPlayDaubLocation.Enabled = false;
                        m_daubLocationTextBox.Enabled = false;
                    //END RALLY DE 5485
                }

                else
                {
                    preDaubErrors.isGreyed = true;

                    if(preDaubErrors.licenseEnabled)
                    {
                        preDaubErrors.value.Value = "False";
                    }
                    //START RALLY DE 5485 play daub location is dependant on play mode pre daub enabled
                    if (m_cboPlayDaubLocation.Tag.ToString() == "True")
                    {
                        m_cboPlayDaubLocation.Enabled = true;
                        m_daubLocationTextBox.Enabled = true;
                    }
                    else
                    {
                        if (m_cboPlayDaubLocation.SelectedIndex < 2)
                        {
                            preDaubSetting.isGreyed = true;
                            preDaubErrors.isGreyed = true;
                        }
                    }
                    //END RALLY DE 5485
                    if (m_cboPlayDaubLocation.SelectedIndex == 0 && catchUpSetting.licenseEnabled)
                    {
                        catchUpSetting.isGreyed = false;
                    }
                }              
            }
        }
        #endregion //Private Routines
        
        //Events
        #region Events
        
        private void OnRadioCheckButton(object sender, EventArgs e)
        {
            m_bModified = true;
            //updates the global play mode and updates the checkbox view if 
            //neccessary

          
            if (m_rdoButtonAuto.Checked && m_playMode != 1)
            {
                m_playMode = 1;
                setSettingsToFalse();
                m_cboPlayDaubLocation.Enabled = false;
                m_daubLocationTextBox.Enabled = false;
                
                ((CheckableSetting) m_chkAllowDaubOnImage.Tag).isGreyed = true;
                DisplayCheckableSettings();
            }

            else if (m_rdoButtonSemiAuto.Checked && m_playMode != 2)
            {
                m_playMode = 2;

                if (m_cboPlayDaubLocation.Tag.ToString() == "True" && m_chkAllowPreDaubing.Checked  != true)//RALLY DE 5485
                {
                    m_cboPlayDaubLocation.Enabled = true;
                    m_daubLocationTextBox.Enabled = true;
                }
                if(((CheckableSetting)m_chkAllowDaubOnImage.Tag).licenseEnabled)
                {
                    ((CheckableSetting)m_chkAllowDaubOnImage.Tag).isGreyed = false;
                }
                DisplayCheckableSettings();
            }

            else if (m_rdoButtonManual.Checked && m_playMode != 3)
            {
                m_playMode = 3;
                setSettingsToFalse();
                m_cboPlayDaubLocation.Enabled = false;
                m_daubLocationTextBox.Enabled = false;

                if (((CheckableSetting)m_chkAllowDaubOnImage.Tag).licenseEnabled)
                {
                    ((CheckableSetting)m_chkAllowDaubOnImage.Tag).isGreyed = false;
                } 
                DisplayCheckableSettings();
            }
            
            OnModified(m_cboPlayDaubLocation, new EventArgs());
        }

		private void OnModified(object sender, EventArgs e)
		{
            if(sender.Equals(m_cboPlayDaubLocation))
            {
                CheckableSetting preDaubSetting =
                   m_settingList.Find(i => Setting.PlayModePreDaubEnabled == i.settingId);
                
                CheckableSetting preDaubErrors =
                   m_settingList.Find(i => Setting.PlayModePreDaubErrorsEnabled == i.settingId);
                
                CheckableSetting catchUpSetting =
                   m_settingList.Find(i => Setting.PlayModeCatchUpEnabled == i.settingId);
                
                if(m_cboPlayDaubLocation.SelectedIndex == 0)
                {
                    if(catchUpSetting.licenseEnabled)
                    {
                        catchUpSetting.isGreyed = false;
                    }

                    if(preDaubSetting.licenseEnabled)
                    {
                        preDaubSetting.isGreyed = false;
                    }

                    preDaubErrors.isGreyed = true;

                    if (preDaubSetting.value.Value == "True" && preDaubSetting.licenseEnabled)
                    {
                        preDaubErrors.isGreyed = false;
                    }
                }

                else if(m_cboPlayDaubLocation.SelectedIndex == 1)
                {
                    catchUpSetting.isGreyed = true;
                    if(catchUpSetting.licenseEnabled)
                    {
                        catchUpSetting.value.Value = "False";
                    }
                    if(preDaubSetting.licenseEnabled)
                    {
                        preDaubSetting.isGreyed = false;
                    }
                    preDaubErrors.isGreyed = true;
                    if (preDaubSetting.value.Value == "True" && preDaubErrors.licenseEnabled)
                    {
                        preDaubErrors.isGreyed = false;
                    }
                    
                }

                else if(m_cboPlayDaubLocation.SelectedIndex == 2)
                {
                    catchUpSetting.isGreyed = true;
                    catchUpSetting.value.Value = "False";

                    if(preDaubSetting.licenseEnabled)
                    {
                        preDaubSetting.isGreyed = false;
                    }
                    if (preDaubSetting.value.Value == "True" && preDaubErrors.licenseEnabled)
                    {
                        preDaubErrors.isGreyed = false;
                    }
                }
                else if (m_cboPlayDaubLocation.SelectedIndex == 3)
                {
                    if (catchUpSetting.licenseEnabled)
                    {
                        catchUpSetting.isGreyed = false;
                    }

                    if (preDaubSetting.licenseEnabled)
                    {
                        preDaubSetting.isGreyed = false;
                    }

                    preDaubErrors.isGreyed = true;

                    if (preDaubSetting.value.Value == "True" && preDaubSetting.licenseEnabled)
                    {
                        preDaubErrors.isGreyed = false;
                    }
                }

                DisplayCheckableSettings();
            }
			m_bModified = true;
		}

        private void m_SettingCheckedBox_AfterSelect(object sender, EventArgs e)
        {
            //find the object in the List and update its status

            CheckBox checkBox = sender as CheckBox;

            m_bModified = true;
            CheckableSetting setting = checkBox.Tag as CheckableSetting;
            ToggleSettingValue(setting);
            UpdateModel(setting);
            
            DisplayCheckableSettings();        
        }

        private void m_SettingCheckedBox_AfterSelect_Others(object sender, EventArgs e)
        {
            //find the object in the List and update its status

            CheckBox checkBox = sender as CheckBox;

            m_bModified = true;
            CheckableSetting setting = checkBox.Tag as CheckableSetting;
            ToggleSettingValue(setting);
            //UpdateModel(setting);

            //DisplayCheckableSettings();
        }


        #endregion//Events

        private void btnReset_Leave(object sender, EventArgs e)
        {
            m_rdoButtonAuto.Focus();
        }

        //FIX: RALLY DE2390 Updated Play Modes End:
    } // end class
    
    //A data transfer object 
    public class CheckableSetting
    {
        public Setting settingId;
        public SettingValue value;
        public string settingName;
        public List<int> settingVisibility;
        public bool isGreyed;
        public bool licenseEnabled;
        
    }
} // end namespace
