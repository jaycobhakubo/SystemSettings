using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class BingoSettings : SettingsControl
	{
        private class PermFileHandle
        {
            public int FileID { get; private set; }
            public string FileName { get; private set; }
            public PermFileHandle(int fileId, string fileName)
            {
                FileID = fileId;
                FileName = fileName;
            }
        }

		// Members
		bool m_bModified = false;
	    private int m_originalMaxCardLimit;

		public BingoSettings()
		{
            InitializeComponent();
		}

		// Public Methods
		#region Public Methods
        public void LoadQuickDrawPermCandidates()
        {
            quickDrawElecPermFileCombo.Items.Clear();
            quickDrawElecPermFileCombo.DisplayMember = "FileName";
            quickDrawElecPermFileCombo.ValueMember = "FileID";
            var perms = GetPermFilesMessage.GetList(true);
            if(perms != null && perms.Count > 0)
                foreach(var p in perms)
                    if (p.Value.EndsWith(".upd"))
                        quickDrawElecPermFileCombo.Items.Add(new PermFileHandle(p.Key, p.Value));
        }

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
		    LoadQuickDrawPermCandidates();
			bool bResult = LoadBingoSettings();


			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
        {
            //US5287: adding a confirmation prompt to change max card limit
            if (m_originalMaxCardLimit != numMaxCardLimit.Value)
            {
                var dialogResults = MessageForm.Show("Changing the max card limit may override the session card limit. Do you want to continue?", "Max Card Limit", MessageFormTypes.YesNo);

                if (dialogResults == DialogResult.No)
                {
                    numMaxCardLimit.Value = m_originalMaxCardLimit;
                    return false;
                }
            }

			Common.BeginWait();

			bool bResult = SaveBingoSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods

		// Private Routines
		#region Private Routines
		private bool LoadBingoSettings()
		{
			// Fill in the operator global settings
            //Common.GetSystemSettings(); //RALLY TA 5745

		    bool licenseValue;
//            decimal decItem = 0;
		    bool saveFlag = false;
            SettingValue tempSettingValue;

			Common.GetOpSettingValue(Setting.MaxBetValue, out tempSettingValue);
            
            licenseValue = Common.GetSettingEnabled(Setting.MaxBetValue);

            if (licenseValue == false)
            {
                numMaxBet.Enabled = false;
                m_MaxBetValueLabel.Enabled = false;
            }

            else
            {
                string value;
                byte minMax = Common.GetSettingMinMax(Setting.MaxBetValue, out value);
                if (value != null)
                {
                    if (minMax == 1)
                    {
                        numMaxBet.Minimum = ParseDecimal(value);
                    }
                    else if (minMax == 2)
                    {
                        numMaxBet.Maximum = ParseDecimal(value);
                    }
                }
            }
            try
            {
                numMaxBet.Value = ParseDecimal(tempSettingValue.Value); 
            }
            
            catch(Exception /*e*/)
            {
                MessageForm.Show(string.Format(Resources.ErrorLicenseFile, "Max Bet", numMaxBet.Maximum), Resources.ErrorLicenseFileHeader);
                numMaxBet.Value = numMaxBet.Maximum;
                saveFlag = true;
            }

            int qdExpCount = 0;
            Int32.TryParse(Common.GetSystemSetting(Setting.QuickDrawExpireCount), out qdExpCount);
            quickDrawCardsExpireNUD.Value = qdExpCount;

            int qdPermFileId = 1;
            Int32.TryParse(Common.GetSystemSetting(Setting.QuickDrawElecPermFile), out qdPermFileId);
            foreach(var i in quickDrawElecPermFileCombo.Items)
            {
                var pfh = i as PermFileHandle;
                if(pfh != null && pfh.FileID == qdPermFileId)
                {
                    quickDrawElecPermFileCombo.SelectedItem = pfh;
                    break;
                }
            }

            Common.GetOpSettingValue(Setting.CBBAutoLock, out tempSettingValue);
            txtLockCBBGames.Text = tempSettingValue.Value.ToString();

            //US3298 Adding support for allowing the user to specify the number of games to play before 
            txtVoidLockGames.Text = Common.GetSystemSetting(Setting.VoidLockAtGameCount);
            txtVoidLockGames.Enabled = Common.GetSettingEnabled(Setting.VoidLockAtGameCount);
            lblVoidLock.Enabled = txtVoidLockGames.Enabled;
           
            //START RALLY TA 5745 Play With Paper System Settings

            chkConsecutiveCards.Checked = ParseBool(Common.GetSystemSetting(Setting.UseConsecutiveCards));  //RALLY DE9427

            chkSameCard.Checked = ParseBool(Common.GetSystemSetting(Setting.UseSameCards));  //RALLY DE9427

            bool playWithPaper = ParseBool(Common.GetLicenseSettingValue(LicenseSetting.PlayWithPaper));  //RALLY DE9427
            
                if (playWithPaper)
                {
                    chkSameCard.Enabled = false;

                    chkConsecutiveCards.Enabled = false;
                    if (chkConsecutiveCards.Checked || chkSameCard.Checked)
                    {
                        saveFlag = true;
                    }
                    chkConsecutiveCards.Checked = false;
                    chkSameCard.Checked = false;
                }

                //START RALLY DE8921, DE8922
                else
                {
                    chkConsecutiveCards.Enabled = Common.GetSettingEnabled(Setting.UseConsecutiveCards);
                    chkSameCard.Enabled = Common.GetSettingEnabled(Setting.UseSameCards);
                }
                //END RALLY DE8921, DE8922
            
            //END RALLY TA 5745 

            //START RALLY DE 4864  Added force pack to player as a editable setting

            m_chkForcePackToPlayer.Checked = ParseBool(Common.GetSystemSetting(Setting.ForcePackToPlayer));  //RALLY DE9427

            licenseValue = Common.GetSettingEnabled(Setting.ForcePackToPlayer);
            m_chkForcePackToPlayer.Enabled = licenseValue ? true : false;  //RALLY DE9427
           
            //END RALLY DE 4864

            Common.GetOpSettingValue(Setting.MaxCardLimit, out tempSettingValue);

            licenseValue = Common.GetSettingEnabled(Setting.MaxCardLimit);

            if (licenseValue == false)
            {
                numMaxCardLimit.Enabled = false;
                m_labelMaxCardLimit.Enabled = false;
            }
            else
            {
                string value;
                byte minMax = Common.GetSettingMinMax(Setting.MaxCardLimit, out value);
                if (value != null)
                {
                    if (minMax == 1)
                    {
                        numMaxCardLimit.Minimum = Convert.ToInt32(value);
                    }
                    else if (minMax == 2)
                    {

                        numMaxCardLimit.Maximum = Convert.ToInt32(value);
                    }
                }
            }

            m_originalMaxCardLimit = Convert.ToInt32(tempSettingValue.Value);
		    numMaxCardLimit.Value = m_originalMaxCardLimit;
            try
            {
                numMaxCardLimit.Value = ParseDecimal(tempSettingValue.Value);
            }
            catch (Exception /*e*/)
            {
                MessageForm.Show(string.Format(Resources.ErrorLicenseFile,"Max Card Limit",numMaxCardLimit.Maximum), Resources.ErrorLicenseFileHeader);
                numMaxCardLimit.Value = numMaxCardLimit.Maximum;
                saveFlag = true;
            }

            //START RALLY TA 6095 -- Hide CBB games 
            if (Common.CBBEnabled == false)
            {
                lblCBBGame.Visible = false;
                lblCBBGamePost.Visible = false;
                txtLockCBBGames.Visible = false;
            }
            //END RALLY TA 6095
            
            chkSequentialGames.Checked = ParseBool(Common.GetSystemSetting(Setting.UseLinearGameNumbering)); // US4804

            if (!Common.IsAdmin) // the logged in user is not a tech, hide any settings they shouldn't see
            {
                chkSequentialGames.Visible = false;
                quickDrawGB.Visible = false;
            }

            if(saveFlag)
            {
                SaveBingoSettings();
            }
			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveBingoSettings()
		{
            // Update the operator  settings
            
            if (numMaxBet.Enabled == true)
            {
                Common.SetOpSettingValue(Setting.MaxBetValue, (numMaxBet.Value).ToString()); //convert back to penny
            }

            if (numMaxCardLimit.Enabled)
            {
                Common.SetOpSettingValue(Setting.MaxCardLimit,
                    numMaxCardLimit.Value.ToString(CultureInfo.InvariantCulture));

                m_originalMaxCardLimit = Convert.ToInt32(numMaxCardLimit.Value);
            }

            Common.SetOpSettingValue(Setting.CBBAutoLock, txtLockCBBGames.Text.ToString());


            //START RALLY TA 5745 Play with paper setting
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            if (txtVoidLockGames.Enabled)
            {
                s.Id = (int)Setting.VoidLockAtGameCount;
                s.Value = txtVoidLockGames.Text;
                arrSettings.Add(s);
                
//                Common.GetSystemSetting(Setting.VoidLockAtGameCount, txtVoidLockGames.Text.ToString());
            }

            s.Id = (int)Setting.QuickDrawExpireCount;
            s.Value = quickDrawCardsExpireNUD.Value.ToString();
            arrSettings.Add(s);

            var epfHandle = quickDrawElecPermFileCombo.SelectedItem as PermFileHandle;
            if(epfHandle != null)
            {
                s.Id = (int)Setting.QuickDrawElecPermFile;
                s.Value = epfHandle.FileID.ToString();
                arrSettings.Add(s);
            }

            s.Id = (int)Setting.UseSameCards;
            s.Value = chkSameCard.Checked.ToString(); 
            arrSettings.Add(s);

            s.Id = (int)Setting.UseConsecutiveCards;
            s.Value = chkConsecutiveCards.Checked.ToString();
            arrSettings.Add(s);
            
            //START RALLY DE 4864 Force pack to player settings
            
            s.Id = (int)Setting.ForcePackToPlayer;
            s.Value = m_chkForcePackToPlayer.Checked.ToString();
            arrSettings.Add(s);

            //END RALLY DE 4864

            // US4804
            s.Id = (int)Setting.UseLinearGameNumbering;
            s.Value = chkSequentialGames.Checked.ToString();
            arrSettings.Add(s);
            
            if(!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }
            //END RALLY TA 5745

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

        private void txtLockCBBGames_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers to be entered into the text box 
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        //Validate user input.
        //Only allow 3 to 90 numbers 
        private void quickDrawCardsExpireNUD_KeyPress(object sender, KeyPressEventArgs e)
        {
   
            bool result = true;//not allow
        
            if (e.KeyChar == (char)Keys.Back)
            {
                result = false;
            }

            if (result)
            {
                result = !char.IsDigit(e.KeyChar);
                if (result == false)
                {
                    TextBoxBase txtbase = quickDrawCardsExpireNUD.Controls[1] as TextBoxBase;
                    int currentPosition = txtbase.SelectionStart;

                    if (currentPosition == 0 && (char)e.KeyChar == '0')
                    {
                        result = true;
                    }
                    else
                    {
                        string BallNumber_s = quickDrawCardsExpireNUD.Text;
                        BallNumber_s = BallNumber_s.Insert(currentPosition, e.KeyChar.ToString());
                        int BallNumber_i;
                        BallNumber_i = Convert.ToInt32(BallNumber_s.ToString());
                        if (BallNumber_i >= 1 && BallNumber_i <= 90)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                }
            }
            e.Handled = result;       
        }

        private void quickDrawCardsExpireNUD_Leave(object sender, EventArgs e)
        {//If the user enter 1 then replace with minimum value which is 3
            if (quickDrawCardsExpireNUD.Value < 3)
            {
                quickDrawCardsExpireNUD.Value = quickDrawCardsExpireNUD.Minimum;
            }
        }

        //FIX END RALLY DE2942
	} // end class
} // end namespace
