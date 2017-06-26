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
	public partial class GlobalSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public GlobalSettings()
		{
			InitializeComponent();

			// Manually set event handler
			this.chkEnableLogging.CheckedChanged += new System.EventHandler(this.chkEnableLogging_CheckedChanged);
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

			bool bResult = LoadGlobalSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			// Validate
			if (!ValidateInput())
			{
				return false;
			}

			Common.BeginWait();

			bool bResult = SaveGlobalSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadGlobalSettings()
		{

            //Multiple Operators settings
//            string result;
            bool saveFlag = false; //RALLY DE 4426

            //license file changes
		    chkSharePointsSetting.Tag = "Enabled";
		    chkShareCreditSetting.Tag = "Enabled";
           
            string tempSetting = Common.GetSystemSetting(Setting.PinExpireDays);          
            
            //START RALLY DE 4426
            //license file
            
            //END RALLY DE 4426
            chkShareCreditSetting.Checked = ParseBool(Common.GetSystemSetting(Setting.ShareOperatorCredits));  //RALLY DE9427
            
            //license file
		    chkShareCreditSetting.Enabled = Common.GetSettingEnabled(Setting.ShareOperatorCredits);

            if (chkShareCreditSetting.Enabled == false)
            {
                chkShareCreditSetting.Tag = "Disabled";
                chkShareCreditSetting.Visible = false;
            }

            chkSharePointsSetting.Checked = ParseBool(Common.GetSystemSetting(Setting.ShareOperatorPoints));  //RALLY DE9427

            //license file
		    chkSharePointsSetting.Enabled = Common.GetSettingEnabled(Setting.ShareOperatorPoints);
            
            if(chkSharePointsSetting.Enabled == false)
            {
                chkSharePointsSetting.Tag = "Disabled";
            }

            //US4625
            //US1848 Adding Comps / Coupons
            chkEnableCouponManagement.Checked = ParseBool(Common.GetSystemSetting(Setting.EnableCouponManagement));
            chkCouponsTaxable.Checked = ParseBool(Common.GetSystemSetting(Setting.AreCouponsTaxable));

            chkEnableLogging.Checked = ParseBool(Common.GetSystemSetting(Setting.EnableLogging));
            numLogRecycleDays.Value = ParseInt(Common.GetSystemSetting(Setting.LogRecycleDays));
            // FIX : TA4750 Remove settings
            numDownloadRecycleDays.Value = ParseInt(Common.GetSystemSetting(Setting.DownloadRecycleDays)); //US4625 readd this setting, make admin only
            // END : TA4750 Remove settings
            cboLogLevel.SelectedIndex = ParseInt(Common.GetSystemSetting(Setting.LoggingLevel));

            txtClientInstallDrive.Text = Common.GetSystemSetting(Setting.ClientInstallDrive);
            txtClientRoot.Text = Common.GetSystemSetting(Setting.ClientInstallRootDirectory);

            if(!Common.IsAdmin)
            {
                chkEnableCouponManagement.Visible = false;
                chkCouponsTaxable.Visible = false;

                groupBox6.Visible = false;
                chkEnableLogging.Visible = false;
                numLogRecycleDays.Visible = false;
                cboLogLevel.Visible = false;
                numDownloadRecycleDays.Visible = false;

                txtClientInstallDrive.Visible = false;
                txtClientRoot.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }//End US4625

			chkForceEnglish.Checked = ParseBool(Common.GetSystemSetting(Setting.ForceEnglish));
            chkShowCursor.Checked = ParseBool(Common.GetSystemSetting(Setting.ShowMouseCursor));
            

			// Toggle logging controls
			chkEnableLogging_CheckedChanged(null, null);

            //START RALLY DE 4426 set pin expire days will be saved if they do not conform
            if (saveFlag)
            {
                SaveGlobalSettings();
            }
            //END RALLY DE 4426

			// Set flag
			m_bModified = false;

			return true;
		}

		private bool SaveGlobalSettings()
		{
			// Create a list of just these settings
			List<SettingValue> arrSettings = new List<SettingValue>();
			SettingValue s = new SettingValue();
		    
            //Add the checkboxes
            
            //license file
            if (chkSharePointsSetting.Enabled)
            {
                s.Id = (int) Setting.ShareOperatorPoints;
                s.Value = chkSharePointsSetting.Checked.ToString();
                arrSettings.Add(s);
            }

		    //license file
            if (chkShareCreditSetting.Enabled)
            {
                s.Id = (int) Setting.ShareOperatorCredits;
                s.Value = chkShareCreditSetting.Checked.ToString();
                arrSettings.Add(s);
            }

            s.Id = (int)Setting.ClientInstallDrive;
			s.Value = txtClientInstallDrive.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.ClientInstallRootDirectory;
			s.Value = txtClientRoot.Text;
			arrSettings.Add(s);

			s.Id = (int)Setting.EnableLogging;
			s.Value = chkEnableLogging.Checked.ToString();
			arrSettings.Add(s);

			s.Id = (int)Setting.LogRecycleDays;
			s.Value = numLogRecycleDays.Value.ToString();
			arrSettings.Add(s);

            // FIX : TA4750 Remove settings
            s.Id = (int)Setting.DownloadRecycleDays;
            s.Value = numDownloadRecycleDays.Value.ToString();
            arrSettings.Add(s);
            // END : TA4750 Remove settings

			s.Id = (int)Setting.LoggingLevel;
			s.Value = cboLogLevel.SelectedIndex.ToString();
			arrSettings.Add(s);

			s.Id = (int)Setting.ForceEnglish;
			s.Value = chkForceEnglish.Checked.ToString();
			arrSettings.Add(s);

			s.Id = (int)Setting.ShowMouseCursor;
			s.Value = chkShowCursor.Checked.ToString();
			arrSettings.Add(s);

            s.Id = (int)Setting.EnableCouponManagement;
            s.Value = chkEnableCouponManagement.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.AreCouponsTaxable;
            s.Value = chkCouponsTaxable.Checked.ToString();
            arrSettings.Add(s);

			// Update the server
			if (!Common.SaveSystemSettings(arrSettings.ToArray()))
			{
				return false;
			}

			// Update our local copy
			Common.SetSystemSettingValue(Setting.ClientInstallDrive, txtClientInstallDrive.Text);
			Common.SetSystemSettingValue(Setting.ClientInstallRootDirectory, txtClientRoot.Text);
			
			Common.SetSystemSettingValue(Setting.EnableLogging, chkEnableLogging.Checked.ToString());
            // FIX : TA4750 Remove settings
            Common.SetSystemSettingValue(Setting.DownloadRecycleDays, numDownloadRecycleDays.Value.ToString());
            // END : TA4750 Remove settings
            
			Common.SetSystemSettingValue(Setting.LogRecycleDays, numLogRecycleDays.Value.ToString());
			Common.SetSystemSettingValue(Setting.LoggingLevel, cboLogLevel.SelectedIndex.ToString());
			Common.SetSystemSettingValue(Setting.ForceEnglish, chkForceEnglish.Checked.ToString());
			Common.SetSystemSettingValue(Setting.ShowMouseCursor, chkShowCursor.Checked.ToString());
		    
		    Common.SetSystemSettingValue(Setting.ShareOperatorCredits, chkShareCreditSetting.Checked.ToString());
		    Common.SetSystemSettingValue(Setting.ShareOperatorPoints, chkSharePointsSetting.Checked.ToString());
            Common.SetSystemSettingValue(Setting.EnableCouponManagement, chkEnableCouponManagement.Checked.ToString());

			// Set flag
			m_bModified = false;

			return true;
		}

		private bool ValidateInput()
		{
			if (txtClientInstallDrive.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter a client install drive.");
				txtClientInstallDrive.Select();
				return false;
			}

			if (txtClientRoot.Text.Length == 0)
			{
				MessageForm.Show(this, "Please enter a client root folder.");
				txtClientRoot.Select();
				return false;
			}

			if (cboLogLevel.SelectedIndex == -1)
			{
				MessageForm.Show(this, "Please select a valid log level.");
				cboLogLevel.Select();
				return false;
			}

			return true;
		}

		private void chkEnableLogging_CheckedChanged(object sender, EventArgs e)
		{
			lblLogLevel.Enabled = chkEnableLogging.Checked;
			lblLogRecycleDays.Enabled = chkEnableLogging.Checked;
			numLogRecycleDays.Enabled = chkEnableLogging.Checked;
			cboLogLevel.Enabled = chkEnableLogging.Checked;
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
            txtClientInstallDrive.Focus();
        }

        private void chkEnableCouponManagement_CheckedChanged(object sender, EventArgs e)
        {
            // if coupon management is checked then taxable coupons is enabled
            chkCouponsTaxable.Enabled = chkEnableCouponManagement.Checked;

            m_bModified = true;
        }
    } // end class
} // end namespace
