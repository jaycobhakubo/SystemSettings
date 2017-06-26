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
	public partial class VideoSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public VideoSettings()
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

			bool bResult = LoadVideoSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveVideoSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadVideoSettings()
		{
			// Fill in the operator global settings
			SettingValue tempSettingValue;

            // FIX : TA4750 Remove settings
            //Common.GetOpSettingValue(Setting.UseHardwareAcceleration, out tempSettingValue);
            //chkUseHardwareAccel.Checked = tempSettingValue.Value.Equals(bool.TrueString);
            //Common.GetOpSettingValue(Setting.VideoAdapterNumber, out tempSettingValue);
            //numVideoAdapterId.Value = ParseInt(tempSettingValue.Value);
            //Common.GetOpSettingValue(Setting.ColorDepth, out tempSettingValue);
            //numColorDepth.Value = ParseInt(tempSettingValue.Value);
            // END : TA4750 Remove settings

			Common.GetOpSettingValue(Setting.RefreshRate, out tempSettingValue);
			numRefreshRate.Value = ParseInt(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.ScreenHeight, out tempSettingValue);
			numScreenHeight.Value = ParseInt(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.ScreenWidth, out tempSettingValue);
			numScreenWidth.Value = ParseInt(tempSettingValue.Value);

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveVideoSettings()
		{
			// Update the operator global settings
            // FIX : TA4750 Remove settings
            //Common.SetOpSettingValue(Setting.UseHardwareAcceleration, chkUseHardwareAccel.Checked.ToString());
            //Common.SetOpSettingValue(Setting.VideoAdapterNumber, numVideoAdapterId.Value.ToString());
            //Common.SetOpSettingValue(Setting.ColorDepth, numColorDepth.Value.ToString());
            // END : TA4750 Remove settings

			Common.SetOpSettingValue(Setting.RefreshRate, numRefreshRate.Value.ToString());

			Common.SetOpSettingValue(Setting.ScreenHeight, numScreenHeight.Value.ToString());

			Common.SetOpSettingValue(Setting.ScreenWidth, numScreenWidth.Value.ToString());

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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            numScreenWidth.Focus();
        }


	} // end class
} // end namespace
