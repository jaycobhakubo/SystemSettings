using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Business;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class AccrualSceneDialog : GradientForm
	{
		// Members
		public Location m_Location = new Location();
        public List<AccrualDisplayItem> AccrualDisplayItems { get; set; }
        private List<Accrual> m_accrualList;
        private int m_adapterID;
        private int m_operatorID;
        private int m_machineID;
        private bool m_accrualLoading;
        private bool m_saveFlag;
        public AccrualSceneDialog(List<AccrualDisplayItem> accrualDisplayItems, List<Accrual> accrualList,int machineid, int operatorid, int adaptorid)
		{
			InitializeComponent();
            m_accrualList = accrualList;
            m_adapterID = adaptorid;
            m_operatorID = operatorid;
            m_machineID = machineid;
            m_saveFlag = false;
            AccrualDisplayItems = new List<AccrualDisplayItem>();
            foreach (AccrualDisplayItem accrualDisplayItem in accrualDisplayItems)
            {
                Accrual accrual = m_accrualList.Find(i => i.Id == accrualDisplayItem.AccrualID);

                if (accrual != null)
                {
                    accrualDisplayItem.AccrualName = accrual.Name;
                    AccrualDisplayItems.Add(accrualDisplayItem); //RALLY DE8859
                }

                //START RALLY DE8859
                //The associated accrual was not found so the accrual display item is incorrect
                else
                {
                    m_saveFlag = true;
                }
                //END RALLY DE8859
            }
			// Fill in controls			
			FillControls();
		}


		// Private Routines
		#region Private Routines
		private void FillControls()
		{
			Common.BeginWait();
			SuspendLayout();

            m_accrualLoading = true;
            foreach (Accrual accrual in m_accrualList)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = accrual.Name;
                listItem.Tag = accrual;
                AccrualDisplayItem accrualDisplayItem = AccrualDisplayItems.Find(i => i.AccrualID == accrual.Id);
                if (accrualDisplayItem != null)
                {
                    listItem.Checked = true;
                }
                listViewAccruals.Items.Add(listItem);
                
            }
            m_accrualLoading = false;

            PopulateAccrualDisplayItems();
			
		    //START RALLY DE8859
            if (m_saveFlag)
            {
                SaveAccruals();
            }
            //END RALLY DE8859
			ResumeLayout(true);
			Common.EndWait();
		}

        private void PopulateAccrualDisplayItems()
        {
            listBoxAccrualScene.Items.Clear();
            AccrualDisplayItems.Sort((x, y) => x.SequenceNumber.CompareTo(y.SequenceNumber));              
            int sequenceNumber = 0;
            foreach (AccrualDisplayItem accrualDisplayItem in AccrualDisplayItems)
            {
                accrualDisplayItem.SequenceNumber = sequenceNumber;
                sequenceNumber++;
            }
            listBoxAccrualScene.Items.AddRange(AccrualDisplayItems.ToArray());
            
        }

		

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			
			Common.BeginWait();
			if (!SaveAccruals())
			{
				Common.EndWait();
			}
			Common.EndWait();

			this.Close();
		}

        private bool SaveAccruals()
        {
            SetAccrualDisplayItems setAccrualDisplayItems = new SetAccrualDisplayItems(AccrualDisplayItems, m_adapterID, m_operatorID,m_machineID);
            try
            {
                setAccrualDisplayItems.Send();
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Error saving accruals {0}", ex.Message), "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                DialogResult = DialogResult.None;
                return false;
            }
            DialogResult = DialogResult.OK;
            return true;
        }

		#endregion // Private Routines

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //add it to the list
            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index >= 0 && m_accrualLoading == false)
                {
                    Accrual accrual = listViewAccruals.Items[e.Index].Tag as Accrual;
                    AddAccrual(accrual);
                }
            }

            //remove it from the list
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (e.Index >= 0 && m_accrualLoading == false)
                {
                    Accrual accrual = listViewAccruals.Items[e.Index].Tag as Accrual;
                    RemoveAccrual(accrual);
                }

            }
        }

        private void RemoveAccrual(Accrual accrual)
        {
            AccrualDisplayItem accrualDisplayItem = AccrualDisplayItems.Find(i => i.AccrualID == accrual.Id);
            if (accrualDisplayItem != null)
            {
                AccrualDisplayItems.Remove(accrualDisplayItem);
                PopulateAccrualDisplayItems();
            }
        }

        private void AddAccrual(Accrual accrual)
        {
            AccrualDisplayItem accrualDisplayItem = AccrualDisplayItems.Find(i => i.AccrualID == accrual.Id);
            if (accrualDisplayItem == null)
            {
                accrualDisplayItem = new AccrualDisplayItem();
                accrualDisplayItem.AccrualID = accrual.Id;
                accrualDisplayItem.AccrualName = accrual.Name;
                accrualDisplayItem.AdapterID = m_adapterID;
                accrualDisplayItem.OperatorID = m_operatorID;
                accrualDisplayItem.OverrideText = accrual.Name;
                accrualDisplayItem.MachineID = m_machineID;
                accrualDisplayItem.SequenceNumber = NextSequenceNumber();
                AccrualDisplayItems.Add(accrualDisplayItem);
                PopulateAccrualDisplayItems();
            }
        }

        private int NextSequenceNumber()
        {
            int maxNumber = 0;
            foreach (AccrualDisplayItem accrualItem in AccrualDisplayItems)
            {
                if (maxNumber <= accrualItem.SequenceNumber)
                {
                    maxNumber++;
                }
            }
            return maxNumber;
        }
        private void ButtonUp_Click(object sender, EventArgs e)
        {
            AccrualDisplayItem accrualDisplayItem = listBoxAccrualScene.SelectedItem as AccrualDisplayItem;
            if (accrualDisplayItem != null)
            {
                int indexToReduce = AccrualDisplayItems.FindIndex(i => i.SequenceNumber == accrualDisplayItem.SequenceNumber);
                int indexToAdd = AccrualDisplayItems.FindIndex(i => i.SequenceNumber == accrualDisplayItem.SequenceNumber - 1);
                if (indexToReduce >= 0 && indexToAdd >= 0)
                {
                    AccrualDisplayItems[indexToReduce].SequenceNumber--;
                    AccrualDisplayItems[indexToAdd].SequenceNumber++;
                    PopulateAccrualDisplayItems();
                    listBoxAccrualScene.SelectedItem = accrualDisplayItem;
                }
            }

        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            //moves the selected accrual down
            AccrualDisplayItem accrualDisplayItem = listBoxAccrualScene.SelectedItem as AccrualDisplayItem;
            if (accrualDisplayItem != null)
            {
                int indexToReduce = AccrualDisplayItems.FindIndex(i => i.SequenceNumber == accrualDisplayItem.SequenceNumber + 1);
                int indexToAdd = AccrualDisplayItems.FindIndex(i => i.SequenceNumber == accrualDisplayItem.SequenceNumber );
                if (indexToReduce >= 0 && indexToAdd >= 0)
                {
                    AccrualDisplayItems[indexToReduce].SequenceNumber--;
                    AccrualDisplayItems[indexToAdd].SequenceNumber++;
                    PopulateAccrualDisplayItems();
                    listBoxAccrualScene.SelectedItem = accrualDisplayItem;                   
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //determine the position to enable/disable the up down arrows

            //display the text
            AccrualDisplayItem accrualDisplayItem = listBoxAccrualScene.SelectedItem as AccrualDisplayItem;
            if (accrualDisplayItem != null)
            {
                labelDisplayText.Enabled = true;
                textBoxAccrualText.Enabled = true;
                textBoxAccrualText.Text = accrualDisplayItem.OverrideText;
                if (accrualDisplayItem.SequenceNumber == 0)
                {
                    ButtonUp.Enabled = false;
                }
                else
                {
                    ButtonUp.Enabled = true;
                }
                if (accrualDisplayItem.SequenceNumber == AccrualDisplayItems.Count - 1)
                {
                    ButtonDown.Enabled = false;
                }
                else
                {
                    ButtonDown.Enabled = true;
                }
            }
            else
            {
                labelDisplayText.Enabled = false;
                textBoxAccrualText.Enabled = false;
                textBoxAccrualText.Text = string.Empty;
            }
        }

        private void textBoxAccrualText_TextChanged(object sender, EventArgs e)
        {
            AccrualDisplayItem accrualDisplayItem = listBoxAccrualScene.SelectedItem as AccrualDisplayItem;
            if (accrualDisplayItem != null)
            {
                accrualDisplayItem.OverrideText = textBoxAccrualText.Text;
            }
            
        }


       


        
    } // end class
} // end namespace