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
	public partial class CurrencySettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

		public CurrencySettings()
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

			bool bResult = true;

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = true;

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

	} // end class
} // end namespace
