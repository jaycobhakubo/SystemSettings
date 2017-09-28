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
	public partial class CrateModuleSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public CrateModuleSettings()
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

			bool bResult = LoadCrateModuleSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveCrateModuleSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadCrateModuleSettings()
		{
            // Fill in the operator global settings
		    
            //START RALLY DE 6614
            if (Common.GetSystemSettings() == false)//knc
            {
                return false;
            }

            chkBalanceSales.Checked = ParseBool(Common.GetSystemSetting(Setting.BalanceSales));   //RALLY DE9427

            chkRestartNumbers.Checked = ParseBool(Common.GetSystemSetting(Setting.RestartNumbersOnReset));  //RALLY DE9427

            numDTRDelay.Value = ParseInt(Common.GetSystemSetting(Setting.DTRDelay));  //RALLY DE9427

            numProgramPacketDelay.Value = ParseInt(Common.GetSystemSetting(Setting.ProgramPacketDelay));  //RALLY DE9427

            numSilentPollingInterval.Value = ParseInt(Common.GetSystemSetting(Setting.SilentPollingInterval));  //RALLY DE9427
			
            numPingTimeout.Value = Math.Max(0, ParseInt(Common.GetSystemSetting(Setting.PingTimeoutMilliseconds)));  //RALLY DE9427
            //END RALLY DE 6614

			// Disable ADMIN-ONLY settings
			/*numDTRDelay.Enabled = Common.IsAdmin;
			numPingTimeout.Enabled = Common.IsAdmin;
			numProgramPacketDelay.Enabled = Common.IsAdmin;
			numSilentPollingInterval.Enabled = Common.IsAdmin;*/

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveCrateModuleSettings()
		{
			
            
            //START RALLY DE 6614
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.RestartNumbersOnReset;
            s.Value = chkRestartNumbers.Checked.ToString();
            arrSettings.Add(s);


            s.Id = (int)Setting.BalanceSales;
            s.Value = chkBalanceSales.Checked.ToString();
            arrSettings.Add(s);


            s.Id = (int)Setting.DTRDelay;
            s.Value = numDTRDelay.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.ProgramPacketDelay;
            s.Value = numProgramPacketDelay.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.SilentPollingInterval;
            s.Value = numSilentPollingInterval.Value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PingTimeoutMilliseconds;
            s.Value = numPingTimeout.Value.ToString();
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }
            //END RALLY DE 6614
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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            numSilentPollingInterval.Focus();
        }



	} // end class
} // end namespace
