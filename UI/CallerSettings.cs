#region copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2015 All Rights Reserved
//
// US3987 Adding support for displaying the number of verified winners
// DE12893: Cool Down Timer Value does not save if RNG is disabled
#endregion

using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;
using System.Linq;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class CallerSettings : SettingsControl
    {
        #region Constants
        private const int RF_DISABLED_INDEX = 0;
        #endregion

        #region Private Members
        /// <summary>
        /// Whether or not any field in the UI has been modified from its default value
        /// </summary>
        private bool m_bModified = false;

        private List<Business.GenericCBOItem> lstRFSerialPort = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstFBInterfacePort = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstFBInterfaceType = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstRFTransmitterType = new List<Business.GenericCBOItem>();   // US4490
        //private List<Business.GenericCBOItem> lstScanner1Ports = new List<Business.GenericCBOItem>();       // US4468
        //private List<Business.GenericCBOItem> lstScanner2Ports = new List<Business.GenericCBOItem>();
        private List<Business.GenericCBOItem> lstFbNumDisplayTypes = new List<Business.GenericCBOItem>();   // US4487
        private List<Control> listBoxControls = null; // all the list box controls on the UI
        private bool m_RNGBallCalls; //RALLY DE 6616

        #endregion

        public CallerSettings()
		{
			InitializeComponent();
            PopCombos();
		}

		#region Public Methods
        /// <summary>
        /// Returns true if any of the UI fields have been altered from their original values
        /// </summary>
        /// <returns></returns>
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

			bool bResult = LoadCallerSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			if (!ValidateInput())
			{
				return false;
			}

			Common.BeginWait();

			bool bResult = SaveCallerSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		#region Private Routines
		private bool ValidateInput()
		{
			if (cboRFSerialPort.SelectedIndex == -1)
			{
				MessageForm.Show(this, "Please select the RF Serial Port.");
				cboRFSerialPort.Select();
				return false;
			}

            if(chkEnableBlower.Checked)
            {
                string regex = @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
                Regex ipAddressRegex = new Regex(regex);

                Match m = ipAddressRegex.Match(tbBlowerAddress.Text);
                if (m.Length != tbBlowerAddress.Text.Length)
                {
                    MessageForm.Show(this, "Please enter a valid IP Address for the Blower.");
                    tbBlowerAddress.Select();
                    return false;
                }
            }

			return true;
		}

		private bool LoadCallerSettings()
		{
            //FIX START RALLY DE 3174 get the global settings
            if (!Common.GetSystemSettings())
            {
                return false;
            }
            //END FIX RALLY DE 3174

            // Fill in the operator global settings
            Business.GenericCBOItem cboItem = null;
            SettingValue tempSettingValue;
			bool saveFlag = false; //RALLY DE 6442

            //RALLY TA 9089 allow auto game advance
			Common.GetOpSettingValue(Setting.AllowAutoGameAdvance, out tempSettingValue);
            chkAllowAutoGameAdvance.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            //END RALLY TA 9089

            //START RALLY TA 9169 Allow wild manual calls
            Common.GetOpSettingValue(Setting.AllowManualWildCalls, out tempSettingValue);
            chkAllowManualWildCalls.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            //END RALLY TA 9169

            // US3987 Adding support for displaying the number of verified winners
            Common.GetOpSettingValue(Setting.DisplayGameWinnerCount, out tempSettingValue);
            chkDisplayWinnerCount.Checked = ParseBool(tempSettingValue.Value);

            //RALLY TA 9092 cool down timer setting
            Common.GetOpSettingValue(Setting.CoolDownTimer, out tempSettingValue);

            //RALLY DE 6616 cool down timer setting dependant on RNG ball calls enabled
            //Always on no need for this logic
            //numCoolDownTimer.Enabled = ParseBool(Common.GetLicenseSettingValue(LicenseSetting.EnableBingoRNG)) ||     //RALLY DE9427
            //    ParseBool(Common.GetSystemSetting(Setting.BlowerEnabled));

            //END RALLY DE 6616
            int cooldownTimer;
            if (int.TryParse(tempSettingValue.Value, out cooldownTimer) && cooldownTimer <= numCoolDownTimer.Maximum &&
                  cooldownTimer >= numCoolDownTimer.Minimum)
            {
                numCoolDownTimer.Value = cooldownTimer;
            }
            else
            {
                numCoolDownTimer.Value = numCoolDownTimer.Minimum;
            }

            // US5249 Allow user to enable or disable a cooldown timer sound
            Common.GetOpSettingValue(Setting.PlayCooldownTimerSound, out tempSettingValue);
            chkPlayCooldownTimerSound.Checked = ParseBool(tempSettingValue.Value);
            
            //Rally 2560 -- Allow Card Verification Status override
            Common.GetOpSettingValue(Setting.AllowCardStatusOverride, out tempSettingValue);
            chkCardStatusOverride.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
			Common.GetOpSettingValue(Setting.PrintWinners, out tempSettingValue);
            chkPrintWinners.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427
            
            //RALLY TA 6877 Print Ball Calls on Winner Reciept
            Common.GetOpSettingValue(Setting.PrintBallCalls, out tempSettingValue);
            chkPrintBallCalls.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
            if (chkPrintWinners.Checked == false)
            {
                if (chkPrintBallCalls.Checked == true)
                {
                    chkPrintBallCalls.Checked = false;
                    saveFlag = true;
                }
                chkPrintBallCalls.Enabled = false;
            }
            else
            {
                chkPrintBallCalls.Enabled = true;
            }
            //END RALLY TA 6877

            //START RALLY DE 6442 disable one touch verify if static drop in mode setting is enabled
            string staticValue = Common.GetLicenseSettingValue(LicenseSetting.StaticDropInMode);

            bool boolResult;
            if (bool.TryParse(staticValue, out boolResult))
            {
                if (boolResult == true)
                {
                    chkEnableOneTouchVerify.Enabled = false;
                    if (chkEnableOneTouchVerify.Checked)
                    {
                        chkEnableOneTouchVerify.Checked = false;
                        saveFlag = true;
                    }
                }

            }
            //END RALLY DE 6442
            //license file
		    chkPrintWinners.Enabled = ParseBool(Common.GetOpSetting(Setting.PrintWinners, true));

            chkAllowPlayTypeToggle.Checked = ParseBool(Common.GetOpSetting(Setting.AllowPlayTypeToggle, true));  //RALLY DE9427

            //US4625
            if (!Common.IsAdmin)
                chkAllowPlayTypeToggle.Visible = false;
		    
            string value = Common.GetOpSetting(Setting.RFSerialPort);
 
            try
            {
                cboItem = FindItemByValue(Convert.ToInt32(value), "cboRFSerialPort");

                if (cboItem != null)
                {
                    cboRFSerialPort.SelectedIndex = cboRFSerialPort.Items.IndexOf(cboItem);
                }
                else
                {
                    cboRFSerialPort.SelectedIndex = -1;
                }
            }
            catch
            {
                cboRFSerialPort.SelectedIndex = -1;
            }

            cboRFSerialPort_SelectedIndexChanged(null, new EventArgs());

		    value = Common.GetOpSetting(Setting.FlashboardInterfacePort, true);

            try
            {
                cboItem = FindItemByValue(Convert.ToInt32(value), "cboFBInterfacePort");

                if (cboItem != null)
                {
                    cboFBInterfacePort.SelectedIndex = cboFBInterfacePort.Items.IndexOf(cboItem);
                }
                else
                {
                    cboFBInterfacePort.SelectedIndex = -1;
                }
            }
            catch
            {
                cboFBInterfacePort.SelectedIndex = -1;
            }

            cboFBInterfacePort_SelectedIndexChanged(null, new EventArgs());

            //START RALLY TA 8743 Enable one touch verify
            chkEnableOneTouchVerify.Checked = ParseBool(Common.GetOpSetting(Setting.EnableOneTouchVerify, true));  //RALLY DE9427
            //END RALLY TA 8743
            
            value = Common.GetOpSetting(Setting.FlashBoardInterfaceType, true);

            try
            {
                cboItem = FindItemByValue(Convert.ToInt32(value), "cboFBInterfaceType");
                if (cboItem != null)
                {
                    cboFBInterfaceType.SelectedIndex = cboFBInterfaceType.Items.IndexOf(cboItem);
                }
                else
                {
                    cboFBInterfaceType.SelectedIndex = -1;
                }
            }
            catch
            {
                cboFBInterfaceType.SelectedIndex = -1;
            }

            //
            // Get the blower settings
            //
            value = Common.GetOpSetting(Setting.BlowerEnabled, true);
            
            try
            {
                chkEnableBlower.Checked = ParseBool(value);
            }
            catch
            {
                chkEnableBlower.Checked = false;
            }
            
            chkEnableBlower_CheckedChanged(null, new EventArgs());

            value = Common.GetOpSetting(Setting.BlowerAddress, true);
            tbBlowerAddress.Text = value;
            
            // Have a default?
            //US4625
            if (!Common.IsAdmin)
            {
                label5.Visible = false;
                tbBlowerAddress.Visible = false;
            }

            // RALLY US4490 Get RF Transmitter type
            value = Common.GetOpSetting(Setting.RFTransmitterType, true);
            cboRFTransType.SelectedIndex = (int)ConvertToRFTransType(value);

            // RALLY US4487 get flashboard numeric display type
            value = Common.GetOpSetting(Setting.FlashboardNumericDisplayMode, true);
            cboFbNumDisplay.SelectedIndex = (int)ConvertToFlashboardDisplayMode(value); 

            // END RALLY US4468

            value = Common.GetOpSetting(Setting.LEDFlashboardEnabled, true);// RALLY US4487
            
            try
            {
                chkEnableLedFB.Checked = ParseBool(value);
            }
            catch
            {
                chkEnableLedFB.Checked = false;
            }

            chkEnableLedFB_CheckedChanged(null, new EventArgs());

            // US4753
            value = Common.GetOpSetting(Setting.RFPacketDelay, true);
            int rfDelayTimer;
            
            if (int.TryParse(value, out rfDelayTimer) && (rfDelayTimer <= numRfPacketSleep.Maximum) && rfDelayTimer >= numRfPacketSleep.Minimum)
                numRfPacketSleep.Value = rfDelayTimer;
            else
                numRfPacketSleep.Value = numRfPacketSleep.Minimum;

		    value = Common.GetSystemSetting(Setting.ClientBroadcastRate);
            int gameStateBroadcastDelay;
            if (int.TryParse(value, out gameStateBroadcastDelay) && (gameStateBroadcastDelay <= numGameStateBroadcastDelay.Maximum) && gameStateBroadcastDelay >= numGameStateBroadcastDelay.Minimum)
                numGameStateBroadcastDelay.Value = gameStateBroadcastDelay;
            else
                numGameStateBroadcastDelay.Value = numGameStateBroadcastDelay.Minimum;

            if (!Common.IsAdmin)
            {
                //hide RF Packaet Delay
                numRfPacketSleep.Visible = false;
                rfDelayLabel.Visible = false;
                rfDelayMsLabel.Visible = false;

                //hide Game State Broadcast Delay
                numGameStateBroadcastDelay.Visible = false;
                lblGameStateBroadcastDelay.Visible = false;
                lblGameStateBroadcastDelayMs.Visible = false;
            }

            value = Common.GetSystemSetting(Setting.EnableRNGBallCalls);
            try
            {
                chkEnableRNGBallCalls.Checked = ParseBool(value);
            }
            catch
            {
                chkEnableRNGBallCalls.Checked = false;
            }

            staticValue = Common.GetLicenseSettingValue(LicenseSetting.EnableBingoRNG);
            if (bool.TryParse(staticValue, out boolResult))
            {
                chkEnableRNGBallCalls.Visible = boolResult;
                lbl_sec.Visible = boolResult;
            }

            // US4793
            value = Common.GetOpSetting(Setting.BonusBallRange, true);

            List<string> bonusBalls = value.Split(',').ToList();

            chkExtraBonus1.Checked = bonusBalls.Exists(s => s.Trim() == "76");
            chkExtraBonus2.Checked = bonusBalls.Exists(s => s.Trim() == "77");
            chkExtraBonus3.Checked = bonusBalls.Exists(s => s.Trim() == "78");
            chkExtraBonus4.Checked = bonusBalls.Exists(s => s.Trim() == "79");
            chkExtraBonus5.Checked = bonusBalls.Exists(s => s.Trim() == "80");

			// Set the flag
			m_bModified = false;

 			//START RALLY DE 6442
            if (saveFlag)
            {
                SaveCallerSettings();
            }
            //END RALLY DE 6442
			return true;
		}

		private bool SaveCallerSettings()
        {
            // Update the operator global settings
            Common.SetOpSettingValue(Setting.AllowAutoGameAdvance, chkAllowAutoGameAdvance.Checked.ToString()); //RALLY TA 9089

            Common.SetOpSettingValue(Setting.EnableOneTouchVerify, chkEnableOneTouchVerify.Checked.ToString()); //RALLY TA 8743
            Common.SetOpSettingValue(Setting.CoolDownTimer, numCoolDownTimer.Value.ToString()); //RALLY TA 9092

            //if (m_RNGBallCalls || chkEnableBlower.Checked) //RALLY DE 6616 - DE12893
            //{
            //    Common.SetOpSettingValue(Setting.CoolDownTimer, numCoolDownTimer.Value.ToString()); //RALLY TA 9092
            //}

            //START RALLY TA 9169 Allow wild manual calls
            Common.SetOpSettingValue(Setting.AllowManualWildCalls, chkAllowManualWildCalls.Checked.ToString());
            //END RALLY TA 9169

            //license file
            if (chkPrintWinners.Enabled)
            {
                Common.SetOpSettingValue(Setting.PrintWinners, chkPrintWinners.Checked.ToString());
            }

            //RALLY TA 6877 Print Ball Calls on Winner reciept
            Common.SetOpSettingValue(Setting.PrintBallCalls, chkPrintBallCalls.Checked.ToString());
            //END RALLY TA 6877

            //Rally 2560 -- Allow Card Verification Status override
            Common.SetOpSettingValue(Setting.AllowCardStatusOverride, chkCardStatusOverride.Checked.ToString());

            //FIX RALLY DE 3174 set caller caller flashboard interface settings from global settings

            // US3987 Adding support for displaying the number of verified winners
            Common.SetOpSettingValue(Setting.DisplayGameWinnerCount, chkDisplayWinnerCount.Checked.ToString());

            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            //FIX RALLY DE 3258 start
            s.Id = (int)Setting.AllowPlayTypeToggle;
            s.Value = chkAllowPlayTypeToggle.Checked.ToString();
            arrSettings.Add(s);
            //END FIX RALLY DE 3258

            Business.GenericCBOItem rfItem = (Business.GenericCBOItem)cboRFSerialPort.SelectedItem;
            s.Id = (int)Setting.RFSerialPort;
            s.Value = rfItem.CBOValueMember.ToString();
            arrSettings.Add(s);

            Business.GenericCBOItem fbItem = (Business.GenericCBOItem)cboFBInterfacePort.SelectedItem;
            s.Id = (int)Setting.FlashboardInterfacePort;
            s.Value = fbItem.CBOValueMember.ToString();
            arrSettings.Add(s);

            Business.GenericCBOItem fbtItem = (Business.GenericCBOItem)cboFBInterfaceType.SelectedItem;
            s.Id = (int)Setting.FlashBoardInterfaceType;
            s.Value = fbtItem.CBOValueMember.ToString();
            arrSettings.Add(s);

            // Add system settings for blower
            s.Id = (int)Setting.BlowerEnabled;
            s.Value = chkEnableBlower.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.BlowerAddress;
            s.Value = tbBlowerAddress.Text;
            arrSettings.Add(s);

            // Rally US4490 Add RF Transmitter Type for player units
            s.Id = (int)Setting.RFTransmitterType;
            s.Value = ConvertFromRFTransType((RFTransmitterType)cboRFTransType.SelectedIndex);
            arrSettings.Add(s);

            // RALLY US4487 get flashboard numeric display type
            s.Id = (int)Setting.FlashboardNumericDisplayMode;
            s.Value = ConvertFromFlashboardDisplayMode((FlashboardDisplayMode)cboFbNumDisplay.SelectedIndex);
            arrSettings.Add(s);

            // US4468 get blower barcode scanner
            // Moved to Blower Settings
            /*Business.GenericCBOItem cboScanner1Item = (Business.GenericCBOItem)cboScanner1Port.SelectedItem;
            s.Id = (int)Setting.BlowerScanner1Port;
            s.Value = cboScanner1Item.CBOValueMember.ToString();
            arrSettings.Add(s);

            Business.GenericCBOItem cboScanner2Item = (Business.GenericCBOItem)cboScanner2Port.SelectedItem;
            s.Id = (int)Setting.BlowerScanner2Port;
            s.Value = cboScanner2Item.CBOValueMember.ToString();
            arrSettings.Add(s);*/

            s.Id = (int)Setting.LEDFlashboardEnabled;
            s.Value = chkEnableLedFB.Checked.ToString();
            arrSettings.Add(s);

            // US4753 add RF Packet Sleep
            s.Id = (int)Setting.RFPacketDelay;
            s.Value = numRfPacketSleep.Value.ToString();
            arrSettings.Add(s);

		    s.Id = (int) Setting.ClientBroadcastRate;
		    s.Value = numGameStateBroadcastDelay.Value.ToString();
            arrSettings.Add(s);

            // US4793
            List<string> extraBonusBalls = new List<string>();

            if(chkExtraBonus1.Checked)
                extraBonusBalls.Add("76");
            
            if(chkExtraBonus2.Checked)
                extraBonusBalls.Add("77");
            
            if(chkExtraBonus3.Checked)
                extraBonusBalls.Add("78");
            
            if(chkExtraBonus4.Checked)
                extraBonusBalls.Add("79");
            
            if(chkExtraBonus5.Checked)
                extraBonusBalls.Add("80");
            
            s.Id = (int)Setting.BonusBallRange;
            s.Value = String.Join(",",extraBonusBalls);
            arrSettings.Add(s);

            s.Id = (int)Setting.PlayCooldownTimerSound;
            s.Value = chkPlayCooldownTimerSound.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.EnableRNGBallCalls;
            s.Value = chkEnableRNGBallCalls.Checked.ToString();
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            //END FIX RALLY DE 3174

            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        /// <summary>
        /// Event triggered when any of the fields on the UI had something change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

        /// <summary>
        /// Populates the combo boxes for the UI
        /// </summary>
        private void PopCombos()
        {
            //cboRFSerialPort
            for (int i = -1; i < 14; i++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = i;
                switch (i)
                {
                    case -1:
                        cboItem.CBODisplayMember = "Auto";
                        break;
                    case RF_DISABLED_INDEX:
                        cboItem.CBODisplayMember = "Disabled";
                        break;
                    default:
                        cboItem.CBODisplayMember = "COM" + i.ToString();
                        break;
                }

                lstRFSerialPort.Add(cboItem);                
            }
            cboRFSerialPort.Items.Clear();
            cboRFSerialPort.DataSource = lstRFSerialPort;            
            cboRFSerialPort.DisplayMember = "CBODisplayMember";
            cboRFSerialPort.ValueMember = "CBOValueMember";

            //cboFBInterfacePort
            for (int j = 0; j < 14; j++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = j;
                switch (j)
                {                    
                    case 0:
                        cboItem.CBODisplayMember = "Disabled";
                        break;
                    default:
                        cboItem.CBODisplayMember = "COM" + j.ToString();
                        break;
                }
                lstFBInterfacePort.Add(cboItem);
            }
            cboFBInterfacePort.Items.Clear();
            cboFBInterfacePort.DataSource = lstFBInterfacePort;
            cboFBInterfacePort.DisplayMember = "CBODisplayMember";
            cboFBInterfacePort.ValueMember = "CBOValueMember";

            //cboFBInterfaceType
            for (int k = 1; k < 4; k++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = k;
                switch (k)
                {
                    case 1:
                        cboItem.CBODisplayMember = "USB";
                        break;
                    case 2:
                        cboItem.CBODisplayMember = "Serial";
                        break;
                    case 3:
                        cboItem.CBODisplayMember = "Ethernet";
                        break;
                }
                lstFBInterfaceType.Add(cboItem);
            }
            cboFBInterfaceType.Items.Clear();
            cboFBInterfaceType.DataSource = lstFBInterfaceType;
            cboFBInterfaceType.DisplayMember = "CBODisplayMember";
            cboFBInterfaceType.ValueMember = "CBOValueMember";

            // Rally US4490
            lstRFTransmitterType.Clear(); // because I have trust issues
            foreach (RFTransmitterType value in Enum.GetValues(typeof(RFTransmitterType)))
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = (int)value;
                cboItem.CBODisplayMember = EnumToString.GetDescription(value);

                lstRFTransmitterType.Add(cboItem);
            }
            cboRFTransType.Items.Clear();
            cboRFTransType.DataSource = lstRFTransmitterType;
            cboRFTransType.DisplayMember = "CBODisplayMember";
            cboRFTransType.ValueMember = "CBOValueMember";

            // RALLY US4487 get flashboard numeric display type
            lstFbNumDisplayTypes.Clear(); // because I have trust issues
            foreach (FlashboardDisplayMode value in Enum.GetValues(typeof(FlashboardDisplayMode)))
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = (int)value;
                cboItem.CBODisplayMember = EnumToString.GetDescription(value);

                lstFbNumDisplayTypes.Add(cboItem);
            }
            cboFbNumDisplay.Items.Clear();
            cboFbNumDisplay.DataSource = lstFbNumDisplayTypes;
            cboFbNumDisplay.DisplayMember = "CBODisplayMember";
            cboFbNumDisplay.ValueMember = "CBOValueMember";

            // RALLY US4468 blower COM ports
            /* Moved to Blower Settings
            for (int l = 1; l < 14; l++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = l;
                cboItem.CBODisplayMember = "COM" + l.ToString();
                lstScanner1Ports.Add(cboItem);
                lstScanner2Ports.Add(cboItem);
            }
            
            cboScanner1Port.Items.Clear();
            cboScanner1Port.DataSource = lstScanner1Ports;
            cboScanner1Port.DisplayMember = "CBODisplayMember";
            cboScanner1Port.ValueMember = "CBOValueMember";

            cboScanner2Port.Items.Clear();
            cboScanner2Port.DataSource = lstScanner2Ports;
            cboScanner2Port.DisplayMember = "CBODisplayMember";
            cboScanner2Port.ValueMember = "CBOValueMember";
            if (cboScanner2Port.SelectedIndex == cboScanner1Port.SelectedIndex)
                ++cboScanner2Port.SelectedIndex;*/
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;            
            ComboBox cComboBox = null;

            if (listBoxControls == null)
            {
                listBoxControls = new List<Control>(this.grpCaller.Controls.Cast<Control>().Where(x => x is ComboBox)); // get all from the group boxes that are combo boxes
                listBoxControls.AddRange(this.grpBlower.Controls.Cast<Control>().Where(x => x is ComboBox));
                listBoxControls.AddRange(this.grpFlashboard.Controls.Cast<Control>().Where(x => x is ComboBox));
                listBoxControls.AddRange(this.grpRF.Controls.Cast<Control>().Where(x => x is ComboBox));
                listBoxControls.AddRange(this.grpFBI.Controls.Cast<Control>().Where(x => x is ComboBox));
            }

            foreach (Control xControl in listBoxControls)
            {
                if (String.Equals(xControl.Name, strCBOName))
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

        /// Rally US4490
        /// <summary>
        /// Converts from the RF Transmitter type enum value to the expected stored format
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string ConvertFromRFTransType(RFTransmitterType type)
        {
            if (type == RFTransmitterType.FNET)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }

        /// <summary>
        /// Converts from the expected stored format for the RF Transmitter type to the enum value
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private RFTransmitterType ConvertToRFTransType(string type)
        {
            if (String.Equals(type, "True") || String.Equals(type, "1"))
            {
                return RFTransmitterType.FNET;
            }
            else
            {
                return RFTransmitterType.GTI;
            }
        }
        
        /// US4487
        /// <summary>
        /// Converts from the flashboard number display mode to the expected stored format
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string ConvertFromFlashboardDisplayMode(FlashboardDisplayMode type)
        {
            if (type == FlashboardDisplayMode.BallCount)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// US4487
        /// <summary>
        /// Converts from the expected stored format for the flashboard display to the expected stored format
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private FlashboardDisplayMode ConvertToFlashboardDisplayMode(string type)
        {
            if (String.Equals(type, "1"))
            {
                return FlashboardDisplayMode.BallCount;
            }
            else
            {
                return FlashboardDisplayMode.GameNumber;
            }
        }

        /// <summary>
        /// Actions that occur when the "enable ball blower" checkbox status changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEnableBlower_CheckedChanged(object sender, EventArgs e)
        {
            if(sender != null)
                m_bModified = true;
            tbBlowerAddress.Enabled = chkEnableBlower.Checked;
            //cboScanner1Port.Enabled = chkEnableBlower.Checked;
            //cboScanner2Port.Enabled = chkEnableBlower.Checked;

            //DE12893
           
        }

        private void tbBlowerAddress_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Decimal && e.KeyChar != (char)Keys.Delete && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;

            if (tbBlowerAddress.Text.Length == 15 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
                e.Handled = true;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkPrintWinners.Focus();
        }

        //RALLY TA 6877
        private void chkPrintWinners_CheckedChanged(object sender, EventArgs e)
        {
            m_bModified = true;
            if (chkPrintWinners.Checked == false)
            {
                chkPrintBallCalls.Checked = false;
                chkPrintBallCalls.Enabled = false;
            }
            else
            {
                chkPrintBallCalls.Enabled = true;
            }
        }

        /// Rally US4490
        /// <summary>
        /// Actions that occur when the "selected index" on the caller's RF serial port changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRFSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRFSerialPort.SelectedIndex >= 0)
            {
                Business.GenericCBOItem item = lstRFSerialPort[cboRFSerialPort.SelectedIndex];
                cboRFTransType.Enabled = (item.CBOValueMember != RF_DISABLED_INDEX);
                numRfPacketSleep.Enabled = (item.CBOValueMember != RF_DISABLED_INDEX);
            }
        }

        private void cboFBInterfacePort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Business.GenericCBOItem item = lstFBInterfacePort[cboFBInterfacePort.SelectedIndex];
            cboFBInterfaceType.Enabled = (item.CBOValueMember != RF_DISABLED_INDEX);
        }

        private void chkEnableLedFB_CheckedChanged(object sender, EventArgs e)
        {
            cboFbNumDisplay.Enabled = chkEnableLedFB.Checked;
            OnModified(sender, e);
        }
        
        #endregion // Private Routines

        private void chkEnableRNGBallCalls_CheckedChanged(object sender, EventArgs e)
        {
            m_bModified = true;
           // numCoolDownTimer.Enabled = chkEnableRNGBallCalls.Checked;
        }

    

       

	} // end class
} // end namespace
