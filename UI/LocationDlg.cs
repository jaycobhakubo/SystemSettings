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

namespace GTI.Modules.SystemSettings.UI
{
	public partial class LocationDlg : GradientForm
	{
		// Members
		public Location m_Location = new Location();

		public LocationDlg(Location location)
		{
			InitializeComponent();

			// Fill in controls
			m_Location = location;
			FillControls();
		}


		// Private Routines
		#region Private Routines
		private void FillControls()
		{
			Common.BeginWait();
			SuspendLayout();

			// Fill in the location data
			txtName.Text = m_Location.Name;
			txtRoom.Text = m_Location.RoomName;
			txtPhone.Text = m_Location.Phone;
			txtModem.Text = m_Location.Modem;
			chkIsActive.Checked = m_Location.Active;

			// Fill in the address data
			if (m_Location.AddressID == CompanySettings.CompanyAddress.AddressID)
			{
				
				txtAddress1.Text = CompanySettings.CompanyAddress.Address1;
				txtAddress2.Text = CompanySettings.CompanyAddress.Address2;
				txtCity.Text = CompanySettings.CompanyAddress.City;
				txtState.Text = CompanySettings.CompanyAddress.State;
				txtZip.Text = CompanySettings.CompanyAddress.Zipcode;
				txtCountry.Text = CompanySettings.CompanyAddress.Country;
			}
			else
			{
			
				FillAddress(m_Location.AddressID);
			}

			ResumeLayout(true);
			Common.EndWait();
		}

		private void FillAddress(int AddressID)
		{
			GetAddressDataMessage msg = new GetAddressDataMessage(AddressID);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageBox.Show(this, string.Format(Resources.GetAddressDataFailed, e));
				return;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.GetAddressDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return;
			}

			// Fill in address controls
			txtAddress1.Text = msg.Properties.Address1;
			txtAddress2.Text = msg.Properties.Address2;
			txtCity.Text = msg.Properties.City;
			txtState.Text = msg.Properties.State;
			txtZip.Text = msg.Properties.Zipcode;
			txtCountry.Text = msg.Properties.Country;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			// First validate input
			if (!ValidateInput())
			{
				return;
			}

			Common.BeginWait();
			if (!SaveLocation())
			{
				Common.EndWait();
				return;
			}
			Common.EndWait();

			// Close the dialog
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private bool SaveLocation()
		{
			
				// If this is a new address, generate a new address ID
				if (m_Location.AddressID == CompanySettings.CompanyAddress.AddressID)
				{
					m_Location.AddressID = 0;  // new record
				}

				if (!SaveLocationAddress())
				{
					return false;
				}
			

			// Save the current selected location data
			if (!SaveLocationData())
			{
				return false;
			}

			return true;
		}

		private bool ValidateInput()
		{
			if (txtAddress1.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterAddress);
				txtAddress1.Select();
				return false;
			}
			if (txtCity.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterCity);
				txtCity.Select();
				return false;
			}
            
            //RALLY DE 2736 removed Country field being a mandatory field

			if (txtState.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterState);
				txtState.Select();
				return false;
			}
			if (txtZip.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterZip);
				txtZip.Select();
				return false;
			}
			if (txtName.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterLocation);
				txtName.Select();
				return false;
			}
            //RALLY DE 2736 removed room name field being a mandatory field

			return true;
		}

		private void chkCompanyAddress_CheckedChanged(object sender, EventArgs e)
		{
			
				txtAddress1.Text = CompanySettings.CompanyAddress.Address1;
				txtAddress2.Text = CompanySettings.CompanyAddress.Address2;
				txtCity.Text = CompanySettings.CompanyAddress.City;
				txtCountry.Text = CompanySettings.CompanyAddress.Country;
				txtState.Text = CompanySettings.CompanyAddress.State;
				txtZip.Text = CompanySettings.CompanyAddress.Zipcode;

				// Disable address editor
				gbAddress.Enabled = false;
			
			
				// Enable address editor
				gbAddress.Enabled = true;
			
		}

		private bool SaveLocationAddress()
		{
			UpdAddressData msg = new UpdAddressData(m_Location.AddressID);
			msg.Properties.Address1 = txtAddress1.Text;
			msg.Properties.Address2 = txtAddress2.Text;
			msg.Properties.City = txtCity.Text;
			msg.Properties.State = txtState.Text;
			msg.Properties.Zipcode = txtZip.Text;
			msg.Properties.Country = txtCountry.Text;

			try
			{
				msg.Send();
				m_Location.AddressID = msg.Properties.AddressID;
			}
			catch (Exception e)
			{
				MessageBox.Show(this, string.Format(Resources.UpdAddressDataFailed, e.Message));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.UpdAddressDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return false;
			}


			return true;
		}

		private bool SaveLocationData()
		{
			m_Location.CompanyID = Common.CompanyId;
			m_Location.Name = txtName.Text;
			m_Location.Modem = txtModem.Text;
			m_Location.Phone = txtPhone.Text;
			m_Location.RoomName = txtRoom.Text;
			m_Location.Active = chkIsActive.Checked;
			m_Location.SubLocationID = 0;

			// Save data to the server
			SetLocationData msg = new SetLocationData(m_Location);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, string.Format(Resources.UpdLocationDataFailed, e));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.UpdLocationDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return false;
			}

			return true;
		}

		#endregion // Private Routines

        private void btnCancel_Leave(object sender, EventArgs e)
        {
            chkIsActive.Focus();
        }

	} // end class
} // end namespace