using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class UnitMgmtSettings : SettingsControl
    {
        #region Constants and Varibles

        const int TRAVELER = 0;
		const int TRACKER = 1;
		const int FIXED = 2;
		const int EXPLORER = 3;//RALLY TA 7728 Changed MINI to EXPLORER
        // PDTS 964, Rally US765 - WiFi now named II.
        const int TRAVELER2 = 4;
        const int TABLET = 5;//TA12156
		const int NUM_DEVICES = 6;

		// Members
		bool m_bModified = false;
		private bool m_bFixedEnabled;
        private bool m_bExplorerEnabled;//RALLY TA 7728 Changed MINI to EXPLORER
		private bool m_bTrackerEnabled;
		private bool m_bTravelerEnabled;
        private bool m_bTraveler2Enabled; // PDTS 964, Rally US765
        private bool m_bTabletEnabled;//TA12156
		private decimal[] m_arrDeviceFees = new decimal[NUM_DEVICES];	// we will use this to store our device fees so we can reset them
        private int m_POSDefaultDevice;
        private bool m_bRipPacks;
        public Device[] m_devices { get; set; }

        #endregion

        public UnitMgmtSettings()
		{
			InitializeComponent();

			// Add an event handler
			this.chkEnableUnitAssignment.CheckedChanged += new System.EventHandler(this.chkEnableUnitAssignment_CheckedChanged);

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

			bool bResult = LoadUnitMgmtSettings();//knc

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			// Validate
			if ((!ValidateCurrencyData()) || (!ValidateDeviceRanges()))
			{
				return false;
			}

			Common.BeginWait();

			bool bResult = SaveUnitMgmtSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods

		// Private Routines
		#region Private Routines
        
       
		private bool LoadUnitMgmtSettings()//knc
		{

			// Get the valid device types
			if (!GetDeviceTypes())
			{
				return false;
			}

			// Get the device fees
			if (!LoadDeviceFees())
			{
				return false;
			}

            if(!Common.GetSystemSettings())
            {
                return false;
            }

			// Fill in the operator global settings
			SettingValue tempSettingValue;

			Common.GetOpSettingValue(Setting.AllowUnitCrossTransfers, out tempSettingValue);
            chkAllowCrossTransfers.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427

			//RALLY TA 9123 crate server port number
            string crateServerPortNumber = Common.GetSystemSetting(Setting.CrateServerPortNumber);
            m_tbCrateServerPortNumber.Text = crateServerPortNumber;
            //end rally ta 9123
            //US4625
            if (!Common.IsAdmin)
            {
                m_tbCrateServerPortNumber.Visible = false;
                label1.Visible = false;
            }

			Common.GetOpSettingValue(Setting.EnableUnitAssignment, out tempSettingValue);
            chkEnableUnitAssignment.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
            chkEnableUnitAssignment_CheckedChanged(this, new EventArgs());

            //ttp 50344
            if(Common.GetLicenseSettingValue(LicenseSetting.EnableAnonymousMachineAccounts).Equals(bool.TrueString)) //RALLY TA 7896 Moved to license file settings
            {
                chkEnableUnitAssignment.Enabled = false;
                numMaxUnits.Enabled = false;
                lblMaxUnits.Enabled = false;
                chkConfirmUnitAssignment.Enabled = false;
            }

			Common.GetOpSettingValue(Setting.ConfirmUnitAssignment, out tempSettingValue);
            chkConfirmUnitAssignment.Checked = ParseBool(tempSettingValue.Value); //RALLY DE9427
			
			Common.GetOpSettingValue(Setting.MaxAssignableUnits, out tempSettingValue);
			numMaxUnits.Value = ParseInt(tempSettingValue.Value);

            //FIX RALLY DE 3000 get crate server setting from global settings
		    txtCrateServer.Text = Common.GetSystemSetting(Setting.CrateServerAddress);
            //END FIX RALLY DE 3000

            //Common.GetOpSettingValue(Setting.CrateServerAddress, out tempSettingValue);
            //txtCrateServer.Text = tempSettingValue.Value;

            // Add new Setting: WiFi out of range alarm. 
            Common.GetOpSettingValue(Setting.WiFiOutOfRange , out tempSettingValue);
            this.chkWiFiRange.Checked = ParseBool(tempSettingValue.Value);  //RALLY DE9427
        
            //DE13585: Set both radio buttons
            //Get if packs rip
            bool notifyUser = Common.GetSystemSetting(Setting.NotifyUserIfPackInUseInsteadOfRipping).Equals(bool.TrueString);
            rbPackInUseNotify.Checked = notifyUser;
		    rbPackInUseRip.Checked = !notifyUser;

            //Get default device for POS
            int defaultDevice = 0;
            Int32.TryParse(Common.GetSystemSetting(Setting.POSDefaultElectronicUnit), out defaultDevice);
            
			// Fees /  ranges (only display valid devices)
			string[] tempRow;
			if (m_bTravelerEnabled)
			{
                int intNumber;
                string strTravStart;
                string strTravEnd;
                bool boolResult;

                boolResult = Int32.TryParse(Common.GetSystemSetting(Setting.TravStart), out intNumber);
                if (boolResult)
                {
                    strTravStart = intNumber.ToString();
                }
                else
                {
                    strTravStart = "0";
                }

                boolResult = Int32.TryParse(Common.GetSystemSetting(Setting.TravEnd), out intNumber);
                if (boolResult)
                {
                    strTravEnd = intNumber.ToString();
                }
                else
                {
                    strTravEnd = "0";
                }                        

				tempRow = new string[] { Resources.Traveler, strTravStart, strTravEnd };
				gridDeviceRanges.Rows[TRAVELER].SetValues(tempRow);
                tempRow = new string[] { Resources.Traveler, string.Format("{0:f2}", m_arrDeviceFees[TRAVELER]) };//RALLY US2018
				gridDeviceFees.Rows[TRAVELER].SetValues(tempRow);
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[TRAVELER].Cells[2]).Value = (defaultDevice == Device.Traveler.Id ? 1 : 0);
			}
			else
			{
				gridDeviceRanges.Rows[TRAVELER].Visible = false;
				gridDeviceFees.Rows[TRAVELER].Visible = false;
			}

			if (m_bTrackerEnabled)
			{
				tempRow = new string[] { Resources.Tracker, Common.GetSystemSetting(Setting.TrackStart), Common.GetSystemSetting(Setting.TrackEnd) };
				gridDeviceRanges.Rows[TRACKER].SetValues(tempRow);
                tempRow = new string[] { Resources.Tracker, string.Format("{0:f2}", m_arrDeviceFees[TRACKER]) };//RALLY US2018
				gridDeviceFees.Rows[TRACKER].SetValues(tempRow);
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[TRACKER].Cells[2]).Value = (defaultDevice == Device.Tracker.Id ? 1 : 0);
            }
			else
			{
				gridDeviceRanges.Rows[TRACKER].Visible = false;
				gridDeviceFees.Rows[TRACKER].Visible = false;
			}

			if (m_bFixedEnabled)
			{
				gridDeviceRanges.Rows[FIXED].Visible = false;
                tempRow = new string[] { Resources.Fixed, string.Format("{0:f2}", m_arrDeviceFees[FIXED]) };//RALLY US2018
				gridDeviceFees.Rows[FIXED].SetValues(tempRow);
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[FIXED].Cells[2]).Value = (defaultDevice == Device.Fixed.Id ? 1 : 0);
            }
			else
			{
				gridDeviceRanges.Rows[FIXED].Visible = false;
				gridDeviceFees.Rows[FIXED].Visible = false;
			}

			if (m_bExplorerEnabled)
			{
                gridDeviceRanges.Rows[EXPLORER].Visible = false;//RALLY TA 7728 Changed MINI to EXPLORER
                tempRow = new string[] { Resources.Explorer, string.Format("{0:f2}", m_arrDeviceFees[EXPLORER]) };//RALLY TA 7728 Changed MINI to EXPLORER//RALLY US2018
                gridDeviceFees.Rows[EXPLORER].SetValues(tempRow);//RALLY TA 7728 Changed MINI to EXPLORER
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[EXPLORER].Cells[2]).Value = (defaultDevice == Device.Explorer.Id ? 1 : 0);
            }
			else
			{
                gridDeviceRanges.Rows[EXPLORER].Visible = false;//RALLY TA 7728 Changed MINI to EXPLORER
                gridDeviceFees.Rows[EXPLORER].Visible = false;//RALLY TA 7728 Changed MINI to EXPLORER
			}

            // PDTS 964, Rally US765
            if(m_bTraveler2Enabled)
            {
                gridDeviceRanges.Rows[TRAVELER2].Visible = false;
                tempRow = new string[] { Resources.Traveler2, string.Format("{0:f2}", m_arrDeviceFees[TRAVELER2]) };//RALLY US2018
                gridDeviceFees.Rows[TRAVELER2].SetValues(tempRow);
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[TRAVELER2].Cells[2]).Value = (defaultDevice == Device.Traveler2.Id ? 1 : 0);
            }
            else
            {
                gridDeviceRanges.Rows[TRAVELER2].Visible = false;
                gridDeviceFees.Rows[TRAVELER2].Visible = false;
            }

            if (m_bTabletEnabled)//TA12156
            {
                gridDeviceRanges.Rows[TABLET].Visible = false;
                tempRow = new string[] { Resources.Tablet, string.Format("{0:f2}", m_arrDeviceFees[TABLET]) };
                gridDeviceFees.Rows[TABLET].SetValues(tempRow);
                ((DataGridViewCheckBoxCell)gridDeviceFees.Rows[TABLET].Cells[2]).Value = (defaultDevice == Device.Tablet.Id ? 1 : 0);
            }
            else
            {
                gridDeviceRanges.Rows[TABLET].Visible = false;
                gridDeviceFees.Rows[TABLET].Visible = false;
            }

            m_POSDefaultDevice = defaultDevice;

			// If there are no Explorers or Traveler IIs , hide the Unit Assigment group box
            grpUnitAssignment.Visible = (m_bExplorerEnabled || m_bTraveler2Enabled);//RALLY TA 7728 Changed MINI to EXPLORER

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveUnitMgmtSettings()
		{
			// Update the operator global settings
			Common.SetOpSettingValue(Setting.AllowUnitCrossTransfers, chkAllowCrossTransfers.Checked.ToString());
            
            //FIX RALLY DE 3000 set crate server address from global settings
            //Common.SetOpSettingValue(Setting.CrateServerAddress, txtCrateServer.Text);
            // Create a list of just these settings
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.CrateServerAddress;
            s.Value = txtCrateServer.Text;
            arrSettings.Add(s);

            //Start RALLY TA 9123
            s.Id = (int)Setting.CrateServerPortNumber;
            s.Value = m_tbCrateServerPortNumber.Text;
            arrSettings.Add(s);
            //END RALLY TA 9123

            s.Id = (int)Setting.POSDefaultElectronicUnit;
            s.Value = m_POSDefaultDevice.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.NotifyUserIfPackInUseInsteadOfRipping;
            s.Value = rbPackInUseNotify.Checked.ToString();
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            //END FIX RALLY DE 3000

			Common.SetOpSettingValue(Setting.EnableUnitAssignment, chkEnableUnitAssignment.Checked.ToString());
			Common.SetOpSettingValue(Setting.ConfirmUnitAssignment, chkConfirmUnitAssignment.Checked.ToString());
			Common.SetOpSettingValue(Setting.MaxAssignableUnits, numMaxUnits.Value.ToString());

            Common.SetOpSettingValue(Setting.WiFiOutOfRange , chkWiFiRange.Checked.ToString());

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
			{
				return false;
			}

			// Save ranges in the system settings table
			if (!SaveDeviceRanges())
			{
				return false;
			}

            if (!SaveDeviceFees())
            {
                return false;
            }
			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveDeviceRanges()
		{
           
			// Put settings into an array
			SettingValue[] arrRanges = new SettingValue[4];
			arrRanges[0].Id = (int)Setting.TravStart;
			arrRanges[0].Value = m_bTravelerEnabled ? gridDeviceRanges[1, TRAVELER].Value.ToString() : "0";
			arrRanges[1].Id = (int)Setting.TravEnd;
			arrRanges[1].Value = m_bTravelerEnabled ? gridDeviceRanges[2, TRAVELER].Value.ToString() : "0";
			arrRanges[2].Id = (int)Setting.TrackStart;
			arrRanges[2].Value = m_bTrackerEnabled ? gridDeviceRanges[1, TRACKER].Value.ToString() : "0";
			arrRanges[3].Id = (int)Setting.TrackEnd;
			arrRanges[3].Value = m_bTrackerEnabled ? gridDeviceRanges[2, TRACKER].Value.ToString() : "0";

			if (!Common.SaveSystemSettings(arrRanges))
			{
				return false;
			}

			// Update local copy
			Common.SetSystemSettingValue(Setting.TravStart, arrRanges[0].Value);
			Common.SetSystemSettingValue(Setting.TravEnd, arrRanges[1].Value);
			Common.SetSystemSettingValue(Setting.TrackStart, arrRanges[2].Value);
			Common.SetSystemSettingValue(Setting.TrackEnd, arrRanges[3].Value);
            
			return true;
		}

		private bool GetDeviceTypes()
		{
			m_bFixedEnabled = false;
            m_bExplorerEnabled = false;//RALLY TA 7728 Changed MINI to EXPLORER
			m_bTrackerEnabled = false;
			m_bTravelerEnabled = false;
            // PDTS 964, Rally US765
            m_bTraveler2Enabled = false;
            m_bTabletEnabled = false;//TA12156

			// Get device types
            //GetDeviceTypeDataMessage msg = new GetDeviceTypeDataMessage();//knc_1
            //try
            //{
            //    msg.Send();
            //}
            //catch (Exception ex)
            //{
            //    MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, ex.Message));
            //    return false;
            //}

            //// Check return code
            //if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            //{
            //    MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
            //    return false;
            //}




			// Add rows for all of the possible device types 
			if (gridDeviceFees.Rows.Count == 0)
			{
				gridDeviceFees.Rows.Add(NUM_DEVICES);
			}
			if (gridDeviceRanges.Rows.Count == 0)
			{
				gridDeviceRanges.Rows.Add(NUM_DEVICES);
			}

           
			// Determine which device types are valid for this operator
			int tempID;
            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)//knc
			{
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
				{
                    tempID = m_devices[iDevice].Id;
					if (tempID == Device.Traveler.Id)
					{
						m_bTravelerEnabled = true;
					}
					else if (tempID == Device.Tracker.Id)
					{
						m_bTrackerEnabled = true;
					}
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
					{
                        m_bExplorerEnabled = true;//RALLY TA 7728 Changed MINI to EXPLORER
					}
					else if (tempID == Device.Fixed.Id)
					{
						m_bFixedEnabled = true;
					}
                    else if(tempID == Device.Traveler2.Id) // Rally US765
                    {
                        m_bTraveler2Enabled = true;
                    }
                        //TA12156
                    else if (tempID == Device.Tablet.Id)
                    {
                        m_bTabletEnabled = true;
                    }
				}
			}

			// If there are no Explorers or Traveler IIs, hide the Unit Assigment group box
            grpUnitAssignment.Visible = (m_bExplorerEnabled || m_bTraveler2Enabled);//RALLY TA 7728 Changed MINI to EXPLORER

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

		private bool ValidateCurrencyData()
		{
			foreach (DataGridViewRow row in gridDeviceFees.Rows)
			{
				// If row is not visible, just skip it
				if (!row.Visible)
				{
					continue;
				}

                decimal fee;

                if (row.Cells[1].Value == null)
                {
                    MessageForm.Show(this, String.Format(Resources.InvalidFee, row.Cells[0].Value.ToString()));
                    return false;
                }
                else
                if (!decimal.TryParse(row.Cells[1].Value.ToString(), out fee) || row.Cells[1].Value == null)
				{
					MessageForm.Show(this, String.Format(Resources.InvalidFee, row.Cells[0].Value.ToString()));
					return false;
				}
				else
				{
					row.Cells[1].Value = fee.ToString("N", System.Globalization.CultureInfo.CurrentCulture);
				}
			}

			return true;
		}

		private bool ValidateDeviceRanges()
		{
			// Start / end ranges
			int nTravStart = Convert.ToInt32(gridDeviceRanges[1, 0].Value);
			int nTravEnd = Convert.ToInt32(gridDeviceRanges[2, 0].Value);
			if (nTravStart > nTravEnd)
			{
				MessageForm.Show(this, "Invalid Device Ranges for 'Traveler'");
				return false;
			}

			int nTrackStart = Convert.ToInt32(gridDeviceRanges[1, 1].Value);
			int nTrackEnd = Convert.ToInt32(gridDeviceRanges[2, 1].Value);
			if (nTrackStart > nTrackEnd)
			{
				MessageForm.Show(this, "Invalid Device Ranges for 'Tracker'");
				return false;
			}

			if (((nTrackStart < nTravStart) && (nTrackEnd >= nTravStart)) ||
				  ((nTravStart < nTrackStart) && (nTravEnd >= nTrackStart)))
			{
				MessageForm.Show(this, "Device Ranges cannot overlap.");
				return false;
			}


			return true;
		}

		private bool LoadDeviceFees()
		{
           //START RALLY 2018
            m_arrDeviceFees[TRAVELER] = Common.GetDeviceFee(Device.Traveler.Id);
            m_arrDeviceFees[TRACKER] = Common.GetDeviceFee(Device.Tracker.Id);
            m_arrDeviceFees[FIXED] = Common.GetDeviceFee(Device.Fixed.Id);
            m_arrDeviceFees[EXPLORER] = Common.GetDeviceFee(Device.Explorer.Id); //RALLY TA 7728
            // PDTS 964, Rally US765
            m_arrDeviceFees[TRAVELER2] = Common.GetDeviceFee(Device.Traveler2.Id);
            //END RALLY 2018
            m_arrDeviceFees[TABLET] = Common.GetDeviceFee(Device.Tablet.Id);//TA12156 
			return true;
		}

		private bool SaveDeviceFees()
		{
            //START RALLY 2018
			// Create an array of devices
			Device[] arrDevices = new Device[NUM_DEVICES];
			arrDevices[TRAVELER].Id = Device.Traveler.Id;
			arrDevices[TRACKER].Id = Device.Tracker.Id;
            arrDevices[EXPLORER].Id = Device.Explorer.Id;//RALLY TA 7728
			arrDevices[FIXED].Id = Device.Fixed.Id;
            // PDTS 964, Rally US765
            arrDevices[TRAVELER2].Id = Device.Traveler2.Id;
            arrDevices[TABLET].Id = Device.Tablet.Id;//TA12156

			arrDevices[TRAVELER].Fee = m_bTravelerEnabled ? Convert.ToDecimal(gridDeviceFees[1, TRAVELER].Value.ToString()) : 0;
			arrDevices[TRACKER].Fee = m_bTrackerEnabled ? Convert.ToDecimal(gridDeviceFees[1, TRACKER].Value.ToString()) : 0;
            arrDevices[EXPLORER].Fee = m_bExplorerEnabled ? Convert.ToDecimal(gridDeviceFees[1, EXPLORER].Value.ToString()) : 0;//RALLY TA 7728 Changed MINI to EXPLORER
			arrDevices[FIXED].Fee = m_bFixedEnabled ? Convert.ToDecimal(gridDeviceFees[1, FIXED].Value.ToString()) : 0;
            arrDevices[TRAVELER2].Fee = m_bTraveler2Enabled ? Convert.ToDecimal(gridDeviceFees[1, TRAVELER2].Value.ToString()) : 0;
            arrDevices[TABLET].Fee = m_bTabletEnabled ? Convert.ToDecimal(gridDeviceFees[1, TABLET].Value.ToString()) : 0; //TA12156

            if (Common.SaveDeviceFees(arrDevices) == false)
            {
                return false;
            }//not this one
			// Update our local copy
			m_arrDeviceFees[TRAVELER] = arrDevices[TRAVELER].Fee;
			m_arrDeviceFees[TRACKER] = arrDevices[TRACKER].Fee;
            m_arrDeviceFees[EXPLORER] = arrDevices[EXPLORER].Fee;//RALLY TA 7728
			m_arrDeviceFees[FIXED] = arrDevices[FIXED].Fee;
            m_arrDeviceFees[TRAVELER2] = arrDevices[TRAVELER2].Fee; // Rally US765
            m_arrDeviceFees[TABLET] = arrDevices[TABLET].Fee;//TA12156
            //END RALLY 2018
			return true;
		}

		// Called when the data grids are modified
		private void OnModified(object sender, DataGridViewCellEventArgs e)
		{
			m_bModified = true;

            if (e.ColumnIndex == 2 && e.RowIndex != -1) //check box changed, allow only one checked box
            {
                DataGridViewCheckBoxCell ourCell = (DataGridViewCheckBoxCell)gridDeviceFees[e.ColumnIndex, e.RowIndex];

                if (ourCell.Value == ourCell.TrueValue)
                {
                    gridDeviceFees.CellValueChanged -= OnModified;

                    foreach (DataGridViewRow row in gridDeviceFees.Rows)
                        ((DataGridViewCheckBoxCell)row.Cells[2]).Value = ourCell.FalseValue;

                    ourCell.Value = ourCell.TrueValue;

                    switch (e.RowIndex)
                    {
                        case TRAVELER:
                        {
                            m_POSDefaultDevice = Device.Traveler.Id;
                        }
                        break;
                        case TRACKER:
                        {
                            m_POSDefaultDevice = Device.Tracker.Id;
                        }
                        break;
                        case FIXED:
                        {
                            m_POSDefaultDevice = Device.Fixed.Id;
                        }
                        break;
                        case EXPLORER:
                        {
                            m_POSDefaultDevice = Device.Explorer.Id;
                        }
                        break;
                        case TRAVELER2:
                        {
                            m_POSDefaultDevice = Device.Traveler2.Id;
                        }
                        break;
                        case TABLET:
                        {
                            m_POSDefaultDevice = Device.Tablet.Id;
                        }
                        break;
                        default:
                        {
                            m_POSDefaultDevice = 0;
                        }
                        break;
                    }

                    gridDeviceFees.CellValueChanged += OnModified;
                }
                else
                {
                    m_POSDefaultDevice = 0;
                }
            }
		}

        private void gridDeviceFees_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
                gridDeviceFees.EndEdit();
        }

		// Called when the other controls are modified
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void chkEnableUnitAssignment_CheckedChanged(object sender, EventArgs e)
		{
			// Toggle optional controls
			numMaxUnits.Enabled = chkEnableUnitAssignment.Checked;
			lblMaxUnits.Enabled = chkEnableUnitAssignment.Checked;
			chkConfirmUnitAssignment.Enabled = chkEnableUnitAssignment.Checked;
		}

		#endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            gridDeviceRanges.Focus();
        }
	} // end class
} // end namespace

