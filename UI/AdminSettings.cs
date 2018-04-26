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
	public partial class AdminSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public AdminSettings()
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

			bool bResult = LoadAdminSettings();

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

			bool bResult = SaveAdminSettings();

			Common.EndWait();

			return bResult;
		}
		#endregion  // Public Methods

		// Private Routines
		#region Private Routines

		private bool LoadAdminSettings()
		{
            //ttp 50340
            //txtCentralServer.Text = Common.GetSystemSetting(Setting.CentralServerName);
			txtDbName.Text = Common.GetSystemSetting(Setting.DatabaseName);
			txtDbPwd.Text = Common.GetSystemSetting(Setting.DatabasePassword);
			txtDbServer.Text = Common.GetSystemSetting(Setting.DatabaseServer);
			txtDbUser.Text = Common.GetSystemSetting(Setting.DatabaseUser);
			txtServerInstallDrive.Text = Common.GetSystemSetting(Setting.ServerInstallDrive);
			txtServerRoot.Text = Common.GetSystemSetting(Setting.ServerInstallRootDirectory);

            // FIX : TA4750 Remove settings
            //chkAllowAnonymousPlay.Checked = ParseBool(Common.GetSystemSetting(Setting.EnableAnonymousMachineAccounts));
            ////license file
            //chkAllowAnonymousPlay.Enabled = Common.GetSettingEnabled(Setting.EnableAnonymousMachineAccounts);
            // END : TA4750 Remove settings

			// End of day
            dtEndOfDay.Value = ParseDateTime(Common.m_GetHallSettingsMessage.EndOfDayTime);

			// Set flag
			m_bModified = false;

			return true;
		}

		private bool SaveAdminSettings()
		{
			// Create a list of just these settings
			List<SettingValue> arrSettings = new List<SettingValue>();
			SettingValue s = new SettingValue();

            //ttp 50340
            //s.Id = (int)Setting.CentralServerName;
            //s.Value = txtCentralServer.Text;
            //arrSettings.Add(s);

			s.Id = (int)Setting.DatabaseName;
			s.Value = txtDbName.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.DatabasePassword;
			s.Value = txtDbPwd.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.DatabaseServer;
			s.Value = txtDbServer.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.DatabaseUser;
			s.Value = txtDbUser.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.ServerInstallDrive;
			s.Value = txtServerInstallDrive.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.ServerInstallRootDirectory;
			s.Value = txtServerRoot.Text;
			arrSettings.Add(s);

            

            // FIX : TA4750 Remove settings
            //s.Id = (int)Setting.EnableAnonymousMachineAccounts;
            //s.Value = chkAllowAnonymousPlay.Checked.ToString();
            //arrSettings.Add(s);
            // END : TA4750 Remove settings


			// Update the server
			if (!Common.SaveSystemSettings(arrSettings.ToArray()))
			{
				return false;
			}

			// Update our local copy
            //Common.SetSystemSettingValue(Setting.CentralServerName, txtCentralServer.Text);
			Common.SetSystemSettingValue(Setting.DatabaseName, txtDbName.Text);
			Common.SetSystemSettingValue(Setting.DatabasePassword, txtDbPwd.Text);
			Common.SetSystemSettingValue(Setting.DatabaseServer, txtDbServer.Text);
			Common.SetSystemSettingValue(Setting.DatabaseUser, txtDbUser.Text);
			Common.SetSystemSettingValue(Setting.ServerInstallDrive, txtServerInstallDrive.Text);
			Common.SetSystemSettingValue(Setting.ServerInstallRootDirectory, txtServerRoot.Text);
			
            Common.m_GetHallSettingsMessage.EndOfDayTime =  dtEndOfDay.Value.ToString("H:mm");
            
            if (!Common.SaveHallSettings())
            {
                return false;
            }
            // FIX : TA4750 Remove settings
            //Common.SetSystemSettingValue(Setting.EnableAnonymousMachineAccounts, chkAllowAnonymousPlay.Checked.ToString());
            // END : TA4750 Remove settings

			// Set flag
			m_bModified = false;

			return true;
		}

		private bool ValidateInput()
		{
			//if (txtCentralServer.Text.Length == 0)
			//{
			//    MessageForm.Show(this, "Please enter the central server name.");
			//    txtCentralServer.Select();
			//    return false;
			//}

			if (txtDbName.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter the database name.");
				txtDbName.Select();
				return false;
			}

			if (txtDbServer.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter the database server.");
				txtDbServer.Select();
				return false;
			}

			if (txtDbUser.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter the database user name.");
				txtDbUser.Select();
				return false;
			}

			if (txtServerInstallDrive.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter the server install drive.");
				txtServerInstallDrive.Select();
				return false;
			}

			if (txtServerRoot.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter the server root directory.");
				txtServerRoot.Select();
				return false;
			}

			return true;
		}

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

		#endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }


	} // end class
} // end namespace
