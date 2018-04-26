using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class MotifSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        bool m_boolColumnClickFlag = false;
        
        Business.GetMotifMessage objGetMotifs;
        Business.SetMotifMessage objSetMotifs;
        Business.ListViewSorter Sorter = new Business.ListViewSorter();

		public MotifSettings()
		{
			InitializeComponent();
            lvMotif.View = View.Details;
            lvMotif.CheckBoxes = true;
            lvMotif.FullRowSelect = true;
            lvMotif.MultiSelect = false;
            lvMotif.HideSelection = false;
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

			bool bResult = LoadMotifSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveMotifSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods

        
		// Private Routines
		#region Private Routines

        private int GetMotifs()
        {
            try
            {
                objGetMotifs = new GTI.Modules.SystemSettings.Business.GetMotifMessage();
                try
                {
                    objGetMotifs.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("MotifSettings.GetMotifs()...Send()..Exception: " + ex.Message);
                }

                return objGetMotifs.pReturnCode;
            }
            catch (Exception e)
            {
                throw new Exception("MotifSettings.GetMotifs()....Exception: " + e.Message);
            }
        }

        private int SetMotifs(List<Business.MotifItem> listMotifs)
        {
            try
            {
                objSetMotifs = new GTI.Modules.SystemSettings.Business.SetMotifMessage(listMotifs);
                try
                {
                    objSetMotifs.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("MotifSettings.SetMotifs()...Send()..Exception: " + ex.Message);
                }

                return objSetMotifs.pReturnCode;
            }
            catch (Exception e)
            {
                throw new Exception("MotifSettings.SetMotifs()....Exception: " + e.Message);
            }
        }
        
		private bool LoadMotifSettings()
		{               
            GetMotifs();
            List<Business.MotifItem> lstMotifs = objGetMotifs.listMotifs;

            lvMotif.Items.Clear();
			foreach (Business.MotifItem mItem in lstMotifs)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Checked = mItem.IsDefault;
                lvi.Text = mItem.MotifName.ToString();
                lvi.SubItems.Add(mItem.MotifID.ToString());
                lvMotif.Items.Add(lvi);
            }
            
			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveMotifSettings()
		{
            bool IsDefaultSet = false;
            int intReturnCode = 0;
            List<Business.MotifItem> lstMotifs = objGetMotifs.listMotifs;

            lstMotifs.Clear();
            foreach (ListViewItem lvi in lvMotif.Items)
            {
                Business.MotifItem mItem = new GTI.Modules.SystemSettings.Business.MotifItem();
                mItem.IsDefault = lvi.Checked;
                mItem.MotifName = lvi.SubItems[0].Text;
                mItem.MotifID = Convert.ToInt32(lvi.SubItems[1].Text);

                lstMotifs.Add(mItem);
            }

            //make sure at least one Motif is set as the default
            foreach (Business.MotifItem xItem in lstMotifs)
            {
                if (xItem.IsDefault == true)
                {
                    IsDefaultSet = true;
                    break;
                }
            }

            //no default was set; make the first one the default
            if (!IsDefaultSet)
            {
                lstMotifs[0].IsDefault = true;
            }

            if (lstMotifs.Count > 0)
            {
                intReturnCode = SetMotifs(lstMotifs);
            }

            switch (intReturnCode)
            {
                case 0:
                    break;
                case -3:
                    MessageForm.Show("Parameter Error - Updates Failed");
                    break;
                case -4:
                    MessageForm.Show("SQL Error - Updates Failed");
                    break;
            }

            //refresh the ListView
            LoadSettings();

			// Set the flag
			m_bModified = false;

			return true;
		}
        
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (lvMotif.Items.Count > 0)
            {
                SaveSettings();
                LoadSettings();
            }
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

        private void MotifSettings_Load(object sender, EventArgs e)
        {
            //the first column will be the check box
            //lvMotif.Columns.Add("Is Default", lvMotif.Width / 4, HorizontalAlignment.Left);            
            lvMotif.Columns.Add("Motif Name", lvMotif.Width, HorizontalAlignment.Left);
            lvMotif.Columns.Add("MotifID", 0, HorizontalAlignment.Left);
        }

        private void lvMotif_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!m_boolColumnClickFlag)
            {
                //if a box is checked, uncheck all others
                if (e.NewValue == CheckState.Checked)
                {
                    foreach (ListViewItem lvi in lvMotif.Items)
                    {
                        if (lvi.Index != e.Index)
                        {
                            lvi.Checked = false;
                        }
                    }
                }
            }
        }

        private void lvMotif_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //We do not want this event to fire the lvMotif_ItemCheck event
            m_boolColumnClickFlag = true;

            lvMotif.ListViewItemSorter = Sorter;
            if (!(lvMotif.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lvMotif.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lvMotif.Sorting == SortOrder.Ascending)
                    lvMotif.Sorting = SortOrder.Descending;
                else
                    lvMotif.Sorting = SortOrder.Ascending;
            }
            else
            {
                lvMotif.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lvMotif.Sort();

            m_boolColumnClickFlag = false;
        }

        #endregion //Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

    } // end class
} // end namespace

