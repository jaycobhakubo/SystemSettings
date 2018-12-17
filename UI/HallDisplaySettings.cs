using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Business;


namespace GTI.Modules.SystemSettings.UI
{
	public partial class HallDisplaySettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        bool m_boolColumnClickFlag = false; //this will prevent the ColumnClick event from firing the ItemChecked event
        string m_AllowableScenes = "";  //this is a comma delimited list
        string m_DefaultScene = "";
        int m_AnticipationType;
        List<Business.GenericCBOItem> lstCboDefaultScenes = new List<Business.GenericCBOItem>();
        List<string> lstAllowableScenes = new List<string>();        
        Business.GetScenesMessage objGetScenes;
        Business.ListViewSorter Sorter = new Business.ListViewSorter();
        private BindingList<FlashboardTheme> m_themes = new BindingList<FlashboardTheme>();

		public HallDisplaySettings()
		{
			InitializeComponent();
            lvAllowableScenes.View = View.Details;
            lvAllowableScenes.CheckBoxes = true;
            lvAllowableScenes.FullRowSelect = true;
            lvAllowableScenes.MultiSelect = false;
            lvAllowableScenes.HideSelection = false;
		}

		// Public Methods
		#region Public Methods
		public override bool IsModified()
		{
			return m_bModified;
		}

		public override bool LoadSettings()
		{
			Common.BeginWait();
			this.SuspendLayout();

			bool bResult = LoadHallDisplaySettings();
            if (bResult)
            {
                bResult = LoadScenes();
            }

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveHallDisplaySettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private Routines
		#region Private Routines

        private int GetScenes()
        {
            try
            {
                objGetScenes = new GTI.Modules.SystemSettings.Business.GetScenesMessage();
                
                try
                {
                    objGetScenes.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("HallDisplaySettings.GetScenes()...Send()..Exception: " + ex.Message);
                }

                return objGetScenes.pReturnCode;              
            }
            catch (Exception e)
            {
                throw new Exception("HallDisplaySettings.GetScenes()....Exception: " + e.Message);
            }
        }

        /// US5625
        /// <summary>
        /// Loads the remote display themes and puts them into the UI
        /// </summary>
        private void GetThemes()
        {
            m_themes.Clear();
            try
            {
                GetFlashboardThemes getThemes = new GetFlashboardThemes();
                getThemes.Send();
                foreach (var theme in getThemes.Themes)
                {
                    if(theme.Active)
                        m_themes.Add(theme);
                }
            }
            catch (ServerException ex)
            {
                string err = String.Format("Unable to get themes for flashboard. Reason: {0}", ex.ReturnCode);
                SettingsManager.Log(err, LoggerLevel.Severe);
                MessageForm.Show(err);
            }
            catch (Exception ex)
            {
                string err = "Unable to get themes for flashboard: " + ex.ToString();
                SettingsManager.Log(err, LoggerLevel.Severe);
                MessageForm.Show(err);
            }
            cboThemes.DataSource = m_themes;
        }

		private bool LoadHallDisplaySettings()
		{
            GetThemes();

            int intTempVal;
            m_AllowableScenes = "";
            m_DefaultScene = "";

		    Common.GetSystemSettings();
            // Fill in the operator global settings
			SettingValue tempSettingValue;

			Common.GetOpSettingValue(Setting.ShowPlayersWinningInfo, out tempSettingValue);
            chkShowWinnerInfo.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
			
			Common.GetOpSettingValue(Setting.ShowWinnersOnly, out tempSettingValue);
            chkShowWinnersOnly.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
			
            //license file
		    chkShowWinnersOnly.Enabled = Common.GetSettingEnabled(Setting.ShowWinnersOnly);

            //FIX RALLY DE 3221 : Change settings from operator specific to global settings

            chkFlashboardCamera.Checked = ParseBool(Common.GetSystemSetting(Setting.UseVirtualFlashboardCamera));  //RALLY DE9427

            numPreviousWinnerDisplayInterval.Value = ParseInt(Common.GetSystemSetting(Setting.PreviousWinnerDisplayInterval));  //RALLY DE9427
            
            //START RALLY US1897
            chkShowPayoutAmount.Checked = ParseBool(Common.GetSystemSetting(Setting.ShowPayoutAmount));  //RALLY DE9427
            //END RALLY US1897

            numPreviousWinnerDisplayTime.Value = ParseInt(Common.GetSystemSetting(Setting.PreviousWinnerDisplayTime));  //RALLY DE9427

            numWinnerPollInterval.Value = ParseInt(Common.GetSystemSetting(Setting.WinnerPollInterval));  //RALLY DE9427

            numScreenSaverTimeout.Value = ParseInt(Common.GetSystemSetting(Setting.ScreenSaverTimeout)); //RALLY DE9427

            intTempVal = ParseInt(Common.GetSystemSetting(Setting.BallCallCameraChannel));  //RALLY DE9427
            //END FIX RALLY DE 3221

            int index;
                switch (intTempVal)
                {
                    case -1:
                        cboCameraChannel.SelectedIndex = 0; //S-Video
                        break;
                    case -2:
                        cboCameraChannel.SelectedIndex = 1; //Composite
                        break;
                    case -3:
                        cboCameraChannel.SelectedIndex = 2; //USB RALLY TA 9120 added USB setting
                        break;
                    //RALLY DE 2886 if value is an integer then see if it is in the list
                    //else add a new item
                    default:
                        index = cboCameraChannel.Items.IndexOf(intTempVal);
                        if(index == -1)
                            index = cboCameraChannel.Items.Add(intTempVal);
                        cboCameraChannel.SelectedIndex = index;
                        break;
                }

            m_AnticipationType = ParseInt(Common.GetSystemSetting(Setting.DisplayNextBall));  //US4727
            if (m_AnticipationType == 1)
            {
                rdChangeBallColor.Checked = true;
                label7.Enabled = false;
                numMinColorCircleTime.Enabled = false;
            }
            else if (m_AnticipationType == 2)
            {
                rdNextBallOnly.Checked = true;
                label7.Enabled = false;
                numMinColorCircleTime.Enabled = false;
            }
            else if (m_AnticipationType == 0)
            {
                rdChangeBGColor.Checked = true;
                label7.Enabled = false;
                numMinColorCircleTime.Enabled = false;
            }
            else
            {
                rdCycleMode.Checked = true;
                label7.Enabled = true;
                numMinColorCircleTime.Enabled = true;
            }

            numMinBallCallTime.Value = ParseInt(Common.GetSystemSetting(Setting.BallImageMinDisplayTime));//US4727
            numMinColorCircleTime.Value = ParseInt(Common.GetSystemSetting(Setting.ColorCircleMinDisplayTime));//US5289

            Common.GetOpSettingValue(Setting.AllowableSceneIDs, out tempSettingValue);
            m_AllowableScenes = tempSettingValue.Value.ToString();

            PopAllowableScenesList();

            Common.GetOpSettingValue(Setting.DefaultSceneID, out tempSettingValue);
            m_DefaultScene = tempSettingValue.Value.ToString();

            /* Default Scene ID and Allowable Scenes will be retrieved from OperatorSettings

            Common.GetSystemSettings();
            txtAllowableScenes.Text = Common.GetSystemSetting(Setting.AllowableSceneIDs);
            txtDefaultSceneId.Text = Common.GetSystemSetting(Setting.DefaultSceneID);
			
			// Disable ADMIN-ONLY settings
			txtAllowableScenes.Enabled = Common.IsAdmin;
			txtDefaultSceneId.Enabled = Common.IsAdmin;
            */

            string themeFileName = Common.GetSystemSetting(Setting.FlashboardTheme); // US5625

            if (cboThemes.Items != null)
            {
                if (!String.IsNullOrWhiteSpace(themeFileName))
                {
                    foreach (FlashboardTheme theme in cboThemes.Items)
                    {
                        if (String.Equals(theme.DllName, themeFileName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            cboThemes.SelectedItem = theme;
                            break;
                        }
                    }

                    if (cboThemes.SelectedItem == null) // we got through them all and didn't find the setting in the current list
                    {
                        FlashboardTheme theme = new FlashboardTheme
                        {
                            DisplayName = themeFileName,
                            DllName = themeFileName,
                        };

                        m_themes.Add(theme); // add the theme to the bound list (automatically updates the UI)
                        cboThemes.SelectedItem = theme;
                    }
                }
                else
                {
                    cboThemes.SelectedItem = cboThemes.Items[0];
                }
            }

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveHallDisplaySettings()
		{
            string strTempVal;

            //FIX RALLY DE 3221 : Change settings from operator specific to global settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            
            s.Id = (int)Setting.UseVirtualFlashboardCamera;
		    s.Value = chkFlashboardCamera.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PreviousWinnerDisplayInterval;
            s.Value = numPreviousWinnerDisplayInterval.Value.ToString();
            arrSettings.Add(s);
            
            s.Id = (int)Setting.PreviousWinnerDisplayTime;
            s.Value = chkFlashboardCamera.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.WinnerPollInterval;
            s.Value = numWinnerPollInterval.Value.ToString();
            arrSettings.Add(s);
            //START RALLY US1897
            s.Id = (int)Setting.ShowPayoutAmount;
            s.Value = chkShowPayoutAmount.Checked.ToString();
            arrSettings.Add(s);
            //END RALLY US1897
            s.Id = (int)Setting.ScreenSaverTimeout;
            s.Value = numScreenSaverTimeout.Value.ToString();
            arrSettings.Add(s);

            strTempVal = cboCameraChannel.Text;
            switch (strTempVal)
            {
                case "S-Video":
                    strTempVal = "-1";
                    break;
                case "Composite":
                    strTempVal = "-2";
                    break;
                case "USB": //RALLY TA 9120 added USB setting
                    strTempVal = "-3";
                    break;

            }

            s.Id = (int)Setting.BallCallCameraChannel;
            s.Value = strTempVal;
            arrSettings.Add(s);

            s.Id = (int)Setting.BallImageMinDisplayTime;
            s.Value = numMinBallCallTime.Value.ToString();
            arrSettings.Add(s);//US4727

            s.Id = (int)Setting.ColorCircleMinDisplayTime;
            s.Value = numMinColorCircleTime.Value.ToString();
            arrSettings.Add(s);//US5289

            if (rdChangeBallColor.Checked)
                m_AnticipationType = 1;
            else if (rdNextBallOnly.Checked)
                m_AnticipationType = 2;
            else if (rdChangeBGColor.Checked)
                m_AnticipationType = 0;
            else
                m_AnticipationType = 3;
            s.Id = (int)Setting.DisplayNextBall;
            s.Value = m_AnticipationType.ToString();
            arrSettings.Add(s); //US4727
            
            s.Id = (int)Setting.FlashboardTheme;
            FlashboardTheme temp = (cboThemes.SelectedItem as FlashboardTheme);
            if(temp == null)
                s.Value = cboThemes.Text; // if they manually typed something in
            else
                s.Value = temp.DllName;
            arrSettings.Add(s); // US5625

            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }
            //END FIX RALLY DE 3221
            // Update the operator global settings
			Common.SetOpSettingValue(Setting.ShowPlayersWinningInfo, chkShowWinnerInfo.Checked.ToString());

            if(chkShowWinnersOnly.Enabled)
            {
                Common.SetOpSettingValue(Setting.ShowWinnersOnly, chkShowWinnersOnly.Checked.ToString());
            }

            Common.SetOpSettingValue(Setting.AllowableSceneIDs, m_AllowableScenes.ToString());
            Common.SetOpSettingValue(Setting.DefaultSceneID, m_DefaultScene.ToString());

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
			{
				return false;
			}            

            /* Default Scene ID and Allowable Scenes will be saved to OperatorSettings

            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            s.Id = (int)Setting.AllowableSceneIDs;
            s.Value = txtAllowableScenes.Text;
            arrSettings.Add(s);
            s.Id = (int)Setting.DefaultSceneID;
            s.Value = txtDefaultSceneId.Text;
            arrSettings.Add(s);
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                m_bModified = false;
                return false;
            }
            */
            
            // Set the flag
			m_bModified = false;            
            
            return true;
            
		}

		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{			
            m_AllowableScenes = "";
            m_DefaultScene = "";

            //get Allowable Scenes
            for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
            {
                if (lvAllowableScenes.Items[i].Checked)
                {
                    m_AllowableScenes = m_AllowableScenes + lvAllowableScenes.Items[i].SubItems[1].Text + ",";
                }
            }

            //remove last comma
            try
            {
                if (m_AllowableScenes.Length > 1)
                {
                    m_AllowableScenes = m_AllowableScenes.Substring(0, m_AllowableScenes.Length - 1);
                }
                else
                {
                    for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
                    {
                        if (lvAllowableScenes.Items[i].Checked)
                        {
                            m_AllowableScenes = lvAllowableScenes.Items[i].SubItems[1].Text;
                            break;
                        }
                    }

                    if (m_AllowableScenes.Length == 0)
                    {
                        //make sure a value is entered if an error is thrown
                        m_AllowableScenes = "1";
                    }    
                }
            }
            catch
            {
                //make sure a value is entered if an error is thrown
                m_AllowableScenes = "1";
            }

            //get default scene
            try
            {
                Business.GenericCBOItem cboItem = (Business.GenericCBOItem)cboDefaultScene.SelectedItem;
                    
                if (cboItem != null)
                {
                    m_DefaultScene = cboItem.CBOValueMember.ToString();
                }
                else
                {
                    for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
                    {
                        if (lvAllowableScenes.Items[i].Checked)
                        {
                            m_DefaultScene = lvAllowableScenes.Items[i].SubItems[1].Text;
                            break;
                        }
                    }

                    if (m_DefaultScene.Length == 0)
                    {
                        //make sure a value is entered if an error is thrown
                        m_DefaultScene = "1";
                    }    
                }
            }
            catch
            {
                //make sure a value is entered if an error is thrown
                m_DefaultScene = "1";
            }

            SaveSettings();
            LoadSettings();
        }

		private void btnReset_Click(object sender, EventArgs e)
		{
            LoadSettings();
		}

        private void cboCameraChannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers to be entered into the text box 
            int isNumber = 0;
            bool result = int.TryParse(e.KeyChar.ToString(), out isNumber);
            
            //FIX RALLY 2886 -- allow camera channel to be added to combo box
            if (result)
            {
                int index = cboCameraChannel.Items.Add(isNumber);
                cboCameraChannel.SelectedIndex = index;
            }
            e.Handled = true;
        }

        private void HallDisplaySettings_Load(object sender, EventArgs e)
        {  
            lvAllowableScenes.Columns.Add("Scene Name", lvAllowableScenes.Width, HorizontalAlignment.Left);
            lvAllowableScenes.Columns.Add("SceneID", 0, HorizontalAlignment.Left);
        }

        private bool LoadScenes()
        {            
            int intReturnVal = GetScenes();
            List<Business.SceneItem> lstScenes = objGetScenes.listScenes;
            lvAllowableScenes.Items.Clear();
            
            if (intReturnVal == 0)
            {                
                foreach (Business.SceneItem mItem in lstScenes)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = mItem.pSceneName.ToString();
                    lvi.SubItems.Add(mItem.pSceneID.ToString());

                    foreach (string sItem in lstAllowableScenes)
                    {
                        if (mItem.pSceneID.ToString() == sItem.ToString())
                        {
                            lvi.Checked = true;
                            break;
                        }
                    }

                    lvAllowableScenes.Items.Add(lvi);
                }

                RefreshCombo();                
                return true;
            }
            else
            {
                if (lstCboDefaultScenes != null)
                {
                    lstCboDefaultScenes.Clear();
                }
                                
                return false;
            }
        }

        private void PopAllowableScenesList()
        {
            //this is a list of SceneIDs
            lstAllowableScenes.Clear();
            string[] arScenes = m_AllowableScenes.Split(',');
            foreach (string strItem in arScenes)
            {
                lstAllowableScenes.Add(strItem.Trim());
            }
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;
            ComboBox cComboBox = null;

            foreach (Control xControl in this.grpSceneInfo.Controls)
            {
                if (xControl.Name == strCBOName)
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

        private void lvAllowableScenes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!m_boolColumnClickFlag)
            {
                RefreshCombo();
            }
        }

        private void RefreshCombo()
        {
            if (lstCboDefaultScenes != null)
            {
                lstCboDefaultScenes.Clear();
            }

            cboDefaultScene.DataSource = null;

            for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
            {
                if (lvAllowableScenes.Items[i].Checked)
                {
                    Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                    cboItem.CBODisplayMember = lvAllowableScenes.Items[i].Text;
                    cboItem.CBOValueMember = Convert.ToInt32(lvAllowableScenes.Items[i].SubItems[1].Text);
                    lstCboDefaultScenes.Add(cboItem);
                }
            }

            cboDefaultScene.DataSource = lstCboDefaultScenes;
            cboDefaultScene.DisplayMember = "CBODisplayMember";
            cboDefaultScene.ValueMember = "CBOValueMember";

            PopCboDefaultScene();
        }

        private void PopCboDefaultScene()
        {
            try
            {
                //Display the selected item
                Business.GenericCBOItem cboItem = FindItemByValue(Convert.ToInt32(m_DefaultScene), "cboDefaultScene");
                if (cboItem != null)
                {
                    cboDefaultScene.SelectedIndex = cboDefaultScene.Items.IndexOf(cboItem);
                }
                else
                {
                    cboDefaultScene.SelectedIndex = -1;
                }
            }
            catch
            {
                cboDefaultScene.SelectedIndex = -1;
            }
        }

        #endregion // Private Routines

        private void lvAllowableScenes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //We do not want this event to fire the lvMotif_ItemCheck event
            m_boolColumnClickFlag = true;

            lvAllowableScenes.ListViewItemSorter = Sorter;
            if (!(lvAllowableScenes.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lvAllowableScenes.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lvAllowableScenes.Sorting == SortOrder.Ascending)
                    lvAllowableScenes.Sorting = SortOrder.Descending;
                else
                    lvAllowableScenes.Sorting = SortOrder.Ascending;
            }
            else
            {
                lvAllowableScenes.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lvAllowableScenes.Sort();

            m_boolColumnClickFlag = false;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void rdCycleMode_CheckedChanged(object sender, EventArgs e)
        {
            numMinColorCircleTime.Enabled = rdCycleMode.Checked;
            label7.Enabled = rdCycleMode.Checked;
        }

    } // end class
} // end namespace
