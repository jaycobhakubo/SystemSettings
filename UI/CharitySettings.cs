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
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;


namespace GTI.Modules.SystemSettings.UI
{
	public partial class CharitySettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        Business.ListViewSorter Sorter = new Business.ListViewSorter();

        public CharitySettings()
		{
			InitializeComponent();
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

			bool bResult = LoadCharities();

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


		// Private Routines
		#region  Private Routines
		private bool LoadCharities()
		{
			lstCharities.Items.Clear();

			//Get the location data from the server
			GetCharityDataMessage msg = new GetCharityDataMessage(0);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, string.Format(Resources.GetLocationDataFailed, e));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.GetLocationDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return false;
			}

			// Fill the arrMachines
			foreach (Charity tmp in msg.items)
			{
			    ListViewItem itmX = lstCharities.Items.Add(tmp.Name);

				// set the tag to be the location itself
				itmX.Tag = tmp;
			}

			// Set the flag
			m_bModified = false;

			return true;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			// Create a new location
			Charity charity = new Charity();

			// Display the dialog
			CharityDlg dlg = new CharityDlg(charity);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				LoadSettings();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			OnEdit();
		}

		private void lstLocations_DoubleClick(object sender, EventArgs e)
		{
			OnEdit();
		}

		private void OnEdit()
		{
			// Make sure exactly one item is selected
			if (lstCharities.SelectedItems.Count != 1)
			{
				MessageForm.Show(this, Resources.SelectSingleItem);
				return;
			}

			// Get the selected item
			Charity charity = (Charity)(lstCharities.SelectedItems[0].Tag);

			// Display the dialog
			CharityDlg dlg = new CharityDlg(charity);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				LoadSettings();
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}
        	
        private void lstLocations_ColumnClick(object sender, ColumnClickEventArgs e)
        {            
            lstCharities.ListViewItemSorter = Sorter;
            if (!(lstCharities.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lstCharities.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lstCharities.Sorting == SortOrder.Ascending)
                    lstCharities.Sorting = SortOrder.Descending;
                else
                    lstCharities.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstCharities.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lstCharities.Sort();
        }

        #endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            lstCharities.Focus();
        }

        private void btnEdit_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }


    } // end class
} // end namespace
