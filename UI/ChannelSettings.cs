using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;


namespace GTI.Modules.SystemSettings.UI
{
    public partial class ChannelSettings : SettingsControl
    {
        //Members
        bool m_bModified = false;
        Business.ListViewSorter Sorter = new Business.ListViewSorter();

        public ChannelSettings()
        {
            InitializeComponent();
        }

        //Public Methods
        #region Public Methods

        public override bool IsModified()
        {
            return m_bModified;
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            bool bResult = LoadChannels();

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

        #endregion

        //Private Routines
        #region Private Routines

        private bool LoadChannels()
        {
            lstChannels.Items.Clear();

            //Get the channel data from the server
            GetChannelDataMessage msg = new GetChannelDataMessage((byte)1);
            try
            {
                msg.Send();
            }
            catch (Exception e)
            {
                MessageForm.Show(this, string.Format(Resources.GetChannelDataFailed, e));
                return false;
            }

            // Check return code
            if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            {
                MessageForm.Show(this, string.Format(Resources.GetChannelDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
                return false;
            }

            // Fill the arrMachines
            foreach (Channel tmp in msg.items)
            {
                ListViewItem itmX = lstChannels.Items.Add(tmp.ChannelNumber.ToString());
                itmX.SubItems.Add(tmp.ChannelName);
                itmX.SubItems.Add(tmp.Enabled ? "Enabled" : "Disabled");

                // set the tag to be the channel itself
                itmX.Tag = tmp;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        /*private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create a new channel
            Channel chan = new Channel();
            chan.ChannelID = 0;
            
            //Display the dialog
            ChannelDlg dlg = new ChannelDlg(chan);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadChannels();
            }
        }*/

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        /*private void btnRemove_Click(object sender, EventArgs e)
        {

        }*/

        private void lstChannels_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void OnEdit()
        {
            // Make sure exactly one item is selected
            if (lstChannels.SelectedItems.Count != 1)
            {
                MessageForm.Show(this, Resources.SelectSingleItem);
                return;
            }

            // Get the selected item
            Channel chan = (Channel)(lstChannels.SelectedItems[0].Tag);

            // Display the dialog
            ChannelDlg dlg = new ChannelDlg(chan);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                LoadSettings();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadChannels();
        }

        private void lstChannels_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstChannels.ListViewItemSorter = Sorter;
            if (!(lstChannels.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lstChannels.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lstChannels.Sorting == SortOrder.Ascending)
                    lstChannels.Sorting = SortOrder.Descending;
                else
                    lstChannels.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstChannels.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lstChannels.Sort();
        }

        #endregion

        private void btnReset_Leave(object sender, EventArgs e)
        {
            lstChannels.Focus();
        }

        private void btnEdit_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

    }
}
