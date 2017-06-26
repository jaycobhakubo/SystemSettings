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
	public partial class CreditSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public CreditSettings()
		{
			InitializeComponent();

			// Add an event handler
			this.chkPurgeCredits.CheckedChanged += new System.EventHandler(this.chkPurgeCredits_CheckedChanged);
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

			bool bResult = LoadCreditSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveCreditSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadCreditSettings()
		{   
            // Fill in the operator global settings
			SettingValue tempSettingValue;
		    bool licenseValue;
		    bool saveFlag = false;
			Common.GetOpSettingValue(Setting.PurgeCreditsAtEOD, out tempSettingValue);
            chkPurgeCredits.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
			Common.GetOpSettingValue(Setting.MinPurgeAmount, out tempSettingValue);
			numMinPurgeAmt.Value = ParseDecimal(tempSettingValue.Value) /100;//convert to dollar as display

			Common.GetOpSettingValue(Setting.MaxPurgeInactivityPeriod, out tempSettingValue);
			numMaxInactivityAge.Value = ParseDecimal(tempSettingValue.Value);
            
            //ttp 50210, we are suppose to use global setting, but it seems confused that 
            //between operator seting or global setting, we address this setting from global now
            //when time comes, we may address all others           
            //Common.GetOpSettingValue(Setting.MaxCreditWinAmount, out tempSettingValue);
            //numMaxCreditWin.Value = ParseDecimal(tempSettingValue.Value) /100;
            licenseValue = Common.GetSettingEnabled(Setting.MaxCreditWinAmount);

            if (licenseValue == false)
            {
                numMaxCreditWin.Enabled = false;
            }
            else
            {
                string value;
                byte minMax = Common.GetSettingMinMax(Setting.MaxCreditWinAmount, out value);
                if (value != null)
                {
                    if (minMax == 1)
                    {
                        numMaxCreditWin.Minimum = ParseDecimal(value);
                    }
                    else if (minMax == 2)
                    {
                        numMaxCreditWin.Maximum = ParseDecimal(value);
                    }
                }
            }

            try
            {
                numMaxCreditWin.Value = ParseDecimal(Common.GetSystemSetting(Setting.MaxCreditWinAmount)) ;
            }
            catch (Exception /*e*/)
            {
                MessageForm.Show(string.Format(Resources.ErrorLicenseFile, "Max Credit Win Amount", numMaxCreditWin.Maximum), Resources.ErrorLicenseFileHeader);
                numMaxCreditWin.Value = numMaxCreditWin.Maximum;
                saveFlag = true;
            }
            //this setting was removed due to the license file but is ready for reactivation

            //licenseValue = Common.GetSettingEnabled(Setting.TaxFormMinWinAmount);

            //if (licenseValue == false)
            //{
            //    numMinWinAmount.Enabled = false;
            //}
            //else
            //{
            //    string value;
            //    byte minMax = Common.GetSettingMinMax(Setting.TaxFormMinWinAmount, out value);
            //    if (value != null)
            //    {
            //        if (minMax == 1)
            //        {
            //            numMinWinAmount.Minimum = ParseDecimal(value);
            //        }
            //        else if (minMax == 2)
            //        {
            //            numMinWinAmount.Maximum = ParseDecimal(value);
            //        }
            //    }
            //}   
           
            //try
            //{
            //    numMinWinAmount.Value = ParseDecimal(Common.GetSystemSetting(Setting.TaxFormMinWinAmount));
            //}

            //catch(Exception e)
            //{
            //    MessageForm.Show(string.Format(Resources.ErrorLicenseFile, "Tax Form Min Win Amount", numMinWinAmount.Minimum), Resources.ErrorLicenseFileHeader);
            //    numMinWinAmount.Value = numMinWinAmount.Minimum;
            //    saveFlag = true;
            //}

            if(saveFlag)
            {
                SaveCreditSettings();
            }
			// Toggle optional Purge controls
			chkPurgeCredits_CheckedChanged(null, null);

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveCreditSettings()
		{
			// Update the operator global settings
			Common.SetOpSettingValue(Setting.PurgeCreditsAtEOD, chkPurgeCredits.Checked.ToString());
            Common.SetOpSettingValue(Setting.MinPurgeAmount, (100* numMinPurgeAmt.Value).ToString()); //convert to penny to save
            Common.SetOpSettingValue(Setting.MaxPurgeInactivityPeriod, numMaxInactivityAge.Value.ToString());
            //Common.SetOpSettingValue(Setting.MaxCreditWinAmount, (100* numMaxCreditWin.Value).ToString());

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
			{
				return false;
			}

            //ttp 50210, we are suppose to use global setting, but it seems confused that 
            //between operator seting or global setting, we address this setting from global now
            //when time comes, we may address all others
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            if (numMaxCreditWin.Enabled)
            {
                s.Id = (int) Setting.MaxCreditWinAmount;
                s.Value = (numMaxCreditWin.Value).ToString(); //RALLY DE2704 casting a decimal to an int
                arrSettings.Add(s);
            }
            //s.Id = (int)Setting.TaxFormMinWinAmount;
            //s.Value = (100* numMinWinAmount.Value).ToString();//RALLY DE2704 casting a decimal to an int
            //arrSettings.Add(s);
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                m_bModified = false;
                return false;
            }
			// Set the flag
			m_bModified = false;

			return true;
		}

		private void chkPurgeCredits_CheckedChanged(object sender, EventArgs e)
		{
			// Show or hide the purge amount
			lblMinPurgeAmt.Enabled = chkPurgeCredits.Checked;
			lblPurgeExtra.Enabled = chkPurgeCredits.Checked;
			lblPurgeMaxInactivity.Enabled = chkPurgeCredits.Checked;
			numMinPurgeAmt.Enabled = chkPurgeCredits.Checked;
			numMaxInactivityAge.Enabled = chkPurgeCredits.Checked;
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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            numMaxCreditWin.Focus();
        }
	} // end class
} // end namespace
