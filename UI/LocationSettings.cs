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
	public partial class LocationSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        Business.ListViewSorter Sorter = new Business.ListViewSorter();

		public LocationSettings()
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

			bool bResult = LoadLocations();

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
		private bool LoadLocations()
		{
			lstLocations.Items.Clear();

			//Get the location data from the server
			GetLocationDataMessage msg = new GetLocationDataMessage();
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
			foreach (Location tmp in msg.Items)
			{
				
			    ListViewItem itmX = lstLocations.Items.Add(tmp.Name);
				itmX.SubItems.Add(tmp.RoomName);
				itmX.SubItems.Add(tmp.Active ? "Active" : "Inactive");

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
			Location loc = new Location();
			loc.LocationID = 0;
			loc.AddressID = 0;

			// Display the dialog
			LocationDlg dlg = new LocationDlg(loc);
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
			if (lstLocations.SelectedItems.Count != 1)
			{
				MessageForm.Show(this, Resources.SelectSingleItem);
				return;
			}

			// Get the selected item
			Location loc = (Location)(lstLocations.SelectedItems[0].Tag);

			// Display the dialog
			LocationDlg dlg = new LocationDlg(loc);
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
            lstLocations.ListViewItemSorter = Sorter;
            if (!(lstLocations.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lstLocations.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lstLocations.Sorting == SortOrder.Ascending)
                    lstLocations.Sorting = SortOrder.Descending;
                else
                    lstLocations.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstLocations.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lstLocations.Sort();
        }

        #endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            lstLocations.Focus();
        }

        private void btnEdit_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }


    } // end class
} // end namespace
