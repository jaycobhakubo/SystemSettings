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
using System.Globalization;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.Shared.Business;


namespace GTI.Modules.SystemSettings.UI
{
	public partial class MachineSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        private int m_currentOperatorID;
		public MachineSettings()
		{
			InitializeComponent();

			// Select the ALL filter
			cboFilter.SelectedIndex = 0;
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
            
            //Start Rally DE10010
            // Fill the list of machines
            if (cboFilter.SelectedIndex == 0)
            {
                AddToMachineList(Common.m_GetMachineDataMessage.MachineDataList);
            }
            else
            {
                // Filter the list
                AddToMachineList(Common.GetMachineList(cboFilter.SelectedIndex));
            }
            //End Rally DE10010

			this.ResumeLayout(true);
			Common.EndWait();

			return true; ;
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
		private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			// If we are still initializing the app, just return
			if (!Common.IsInitialized)
			{
				return;
			}

			Common.BeginWait();
			
			if (cboFilter.SelectedIndex == 0)
			{
				AddToMachineList(Common.m_GetMachineDataMessage.MachineDataList);
			}
			else
			{
				// Filter the list
				AddToMachineList(Common.GetMachineList(cboFilter.SelectedIndex));
			}
            Common.EndWait();
		}

		private void AddToMachineList(Machine[] arrMachines)
		{
            //ttp 50338
            lstStations.Items.Clear();

			int nCount = arrMachines.Length;
			for (int i = 0; i < nCount; i++)
			{
                Machine s = arrMachines[i];

				ListViewItem itmX = lstStations.Items.Add(s.ClientIdentifier);
				itmX.SubItems.Add(s.DeviceType.Name); // PDTS 964
				itmX.SubItems.Add(s.Description);

				// set the tag to be the item itself
				itmX.Tag = s;
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			OnEdit();
		}

		private void lstStations_DoubleClick(object sender, EventArgs e)
		{
			OnEdit();
		}

		private void OnEdit()
		{
			// Make sure an item is selected
			if (lstStations.SelectedItems.Count == 0)
			{
				return;
			}
            
			// Get the selected items into an array
            List<Machine> arrSelectedMachines = new List<Machine>();
			int nCount = lstStations.SelectedItems.Count;
			for (int i = 0; i < nCount; i++)
			{
                arrSelectedMachines.Add((Machine)lstStations.SelectedItems[i].Tag);
			}

			// Show the settings dialog if all machines are of the same type
            if (AreMachinesOfSameType(arrSelectedMachines))
            {
                if (IsUserDefinedAllSame(arrSelectedMachines))
                {
                    MachineSettingsDlg dlg = new MachineSettingsDlg(arrSelectedMachines.ToArray(), Common.OperatorId);
                    dlg.Height = 720;
                    dlg.Width = 728;
                    dlg.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.MultipleMachineEditError),
                           Resources.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
          
                }
            }
            else
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.MultipleMachineEditError),
                                Resources.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
		}

        //FIX: RALLY DE 2837 Start -- checked for machines of the same type
        private bool AreMachinesOfSameType(List<Machine> machineList)
        {
            if (machineList.Count == 0)
                return false;
            
                //get the first machines type
            Machine baseMachine = machineList[0];

            foreach (Machine machine in machineList)
                {
                    //if any other machine is of a different type then return false
                    if (machine.DeviceType.Id != baseMachine.DeviceType.Id)
                        return false;

                }
                 
            return true;
        }
        //FIX: RALLY DE 2837 End

        private bool IsUserDefinedAllSame(List<Machine> selectedMachines)
        {
            if (selectedMachines.Count == 0)
                return false;
            //get the first machines module list
            Machine baseMachine = selectedMachines[0];
            if (baseMachine.DeviceType.Id != Device.UserDefined.Id)
                return true;

            GetMachineModules getMachineModulesMessage = new GetMachineModules(baseMachine.Id);
            try
            {
                getMachineModulesMessage.Send();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error getting machine modules {0}", e.Message), "Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MachineModule baseMachineModule = getMachineModulesMessage.MachineModule;
            foreach (Machine machine in selectedMachines)
            {
                getMachineModulesMessage = new GetMachineModules(machine.Id);
                getMachineModulesMessage.Send();
                MachineModule machineModule = getMachineModulesMessage.MachineModule;
                if (machineModule.ModuleIDs.Count != baseMachineModule.ModuleIDs.Count)
                    return false;
                foreach (int moduleID in machineModule.ModuleIDs)
                {
                    if (!baseMachineModule.ModuleIDs.Contains(moduleID))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
		#endregion // Private Routines

        //ttp 50339, extra, this was not implemented at beginning, so add it
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboFilter_SelectedIndexChanged(this, null);
        }

        private void btnRefresh_Leave(object sender, EventArgs e)
        {
            cboFilter.Focus();
        }



        


	} // end class
} // end namespace
