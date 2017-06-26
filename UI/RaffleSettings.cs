#region Copyright

// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All rights reserved

// US3989 Adding setting for displaying player pictures
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;


namespace GTI.Modules.SystemSettings.UI
{
	public partial class RaffleSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
	    private TreeNode m_TreeNodeParent;
		public RaffleSettings()
		{
		    m_TreeNodeParent = null;
			InitializeComponent();
		}

        public void SetTreeNode(TreeNode parent)
        {
            m_TreeNodeParent = parent;
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

			bool bResult = LoadRaffleSettings();


			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveRaffleSettings();

			Common.EndWait();

			return bResult;
		}
		#endregion  // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadRaffleSettings()
		{
            //RALLY DE 6749 move the raffle duration in seconds to raffle settings from hall settings
            Common.GetSystemSettings();
            string globalSettingValue;

			// Fill in the operator global settings
			SettingValue tempSettingValue;

            Common.GetOpSettingValue(Setting.SwipeEntersRaffle, out tempSettingValue);
            chkEnterRaffle.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            
            //START RALLY DE 6611 add raffle display duration setting (214)
            globalSettingValue = Common.GetSystemSetting(Setting.RaffleDisplayDuration);
            numRaffleDuration.Value = ParseInt(globalSettingValue);
            //END RALLY DE 6611

			Common.GetOpSettingValue(Setting.RemoveWinnerFromNextRaffle, out tempSettingValue);
            chkRemoveWinner.Checked = Common.ParseBool(tempSettingValue.Value);   //RALLY DE9427

            Common.GetOpSettingValue(Setting.ShowPlayerPictures, out tempSettingValue);
            chkDisplayPlayerImage.Checked = Common.ParseBool(tempSettingValue.Value); // US3989
			
			Common.GetOpSettingValue(Setting.MinPlayersForRaffle, out tempSettingValue);
			numPlayersNeededForRaffle.Value = ParseInt(tempSettingValue.Value);

		    Common.GetOpSettingValue(Setting.RaffleDrawingSetting, out tempSettingValue);
		    this.cboDisplayedText.SelectedIndex = ParseInt(tempSettingValue.Value) - 1;

            // US3914
            Common.GetOpSettingValue(Setting.RaffleRunFromLocation, out tempSettingValue);
            this.cboRunFromLocation.SelectedIndex = ParseInt(tempSettingValue.Value) - 1;

            //set the local text
		    string raffleText = this.cboDisplayedText.SelectedItem.ToString();
		    SetRaffleText(raffleText);
			// Set the flag
			m_bModified = false;

			return true;
		}

        private void SetRaffleText(string raffleText)
        {
            if (!string.IsNullOrEmpty(raffleText))
            {
                groupBox1.Text = string.Format("{0} Settings", raffleText);
                chkEnterRaffle.Text = string.Format("Card swipe or player lookup\nenters players into {0}", raffleText);
                chkRemoveWinner.Text = string.Format("Remove winner from\nnext {0}", raffleText);
                lblMinimumPlayers.Text = string.Format("Minimum players needed\nfor {0}", raffleText);
                lblRaffleDuration.Text = string.Format("{0} duration (seconds)", raffleText); //RALLY DE 6749
                if(m_TreeNodeParent != null)
                {
                    m_TreeNodeParent.Text = string.Format("{0} Settings", raffleText);
                }
            }
        }

		private bool SaveRaffleSettings()
		{
			// Update the operator global settings
            Common.SetOpSettingValue(Setting.SwipeEntersRaffle, chkEnterRaffle.Checked.ToString());
			Common.SetOpSettingValue(Setting.RemoveWinnerFromNextRaffle, chkRemoveWinner.Checked.ToString());
			Common.SetOpSettingValue(Setting.MinPlayersForRaffle, numPlayersNeededForRaffle.Value.ToString());

            // US3989
            Common.SetOpSettingValue(Setting.ShowPlayerPictures, chkDisplayPlayerImage.Checked.ToString());

            Common.SetOpSettingValue(Setting.RaffleDrawingSetting, (cboDisplayedText.SelectedIndex + 1).ToString());

            //US3914
            Common.SetOpSettingValue(Setting.RaffleRunFromLocation, (cboRunFromLocation.SelectedIndex + 1).ToString());

            //START RALLY DE 6749
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            //START RALLY DE 6611 add raffle display duration setting (214)
            s.Id = (int)Setting.RaffleDisplayDuration;
            s.Value = numRaffleDuration.Value.ToString();
            arrSettings.Add(s);
            //END RALLY DE 6611

            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }
            //END RALLY DE 6749

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

		#endregion // Private Routines

        private void cboDisplayedText_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            m_bModified = true;
            
            //this.Invalidate();
            SetRaffleText(cboDisplayedText.SelectedItem.ToString());
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkEnterRaffle.Focus();
        }

	} // end class
} // end namespace
