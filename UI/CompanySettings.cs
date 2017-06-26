using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class CompanySettings : SettingsControl
	{
		// Members
		int m_nAddressId = 0;
		bool m_bModified = false;

		// Constructor
		public CompanySettings()
		{
			InitializeComponent();
		}


		// Public Methods
		#region Public Methods
		public override bool IsModified()
		{
			return m_bModified;
		}

		// Keep a copy of the company address so we don't have to keep fetching it
		public static Address CompanyAddress = new Address();
		public static void UpdateCompanyAddress(UpdAddressData msg)
		{
			CompanyAddress.AddressID = msg.Properties.AddressID;
			CompanyAddress.Address1 = msg.Properties.Address1;
			CompanyAddress.Address2 = msg.Properties.Address2;
			CompanyAddress.City = msg.Properties.City;
			CompanyAddress.State = msg.Properties.State;
			CompanyAddress.Country = msg.Properties.Country;
			CompanyAddress.Zipcode = msg.Properties.Zipcode;
			CompanyAddress.AddressID = msg.Properties.AddressID;
		}
		public static void SetCompanyAddress(GetAddressDataMessage msg)
		{
			CompanyAddress.AddressID = msg.Properties.AddressID;
			CompanyAddress.Address1 = msg.Properties.Address1;
			CompanyAddress.Address2 = msg.Properties.Address2;
			CompanyAddress.City = msg.Properties.City;
			CompanyAddress.State = msg.Properties.State;
			CompanyAddress.Country = msg.Properties.Country;
			CompanyAddress.Zipcode = msg.Properties.Zipcode;
			CompanyAddress.AddressID = msg.Properties.AddressID;
		}


		public override bool LoadSettings()
		{
			bool bResult = true;
			Common.BeginWait();
			this.SuspendLayout();

			if (!GetCompanyData())
			{
				bResult = false;
			}
			else if (!GetAddressData())
			{
				bResult = false;
			}
			else
			{
				m_bModified = false;
			}

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			// Validate input
			if (!ValidateInput())
			{
				return false;
			}

			bool bResult = true;
			Common.BeginWait();

			if (!SaveCompanyData())
			{
				bResult = false;
			}
			else if (!SaveAddressData())
			{
				bResult = false;
			}
			else
			{
				m_bModified = false;
			}

			Common.EndWait();

			return bResult;
		}

		#endregion // Public Methods


		// Private Routines
		#region Private Routines
		private bool GetCompanyData()
		{
			GetCompanyDataMessage msgData = new GetCompanyDataMessage(Common.CompanyId);
			try
			{
				msgData.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, String.Format(Resources.GetCompanyDataFailed, e));
				return false;
			}

			// Fill in the controls
			txtName.Text = msgData.Properties.Name;
			txtOwner.Text = msgData.Properties.Owner;
			txtPhone.Text = msgData.Properties.Phone;
			m_nAddressId = msgData.Properties.AddressID;
			chkIsActive.Checked = msgData.Properties.Active;

			return true;
		}

		private bool GetAddressData()
		{
			GetAddressDataMessage msg = new GetAddressDataMessage(m_nAddressId);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, String.Format(Resources.GetAddressDataFailed, e));
				return false;
			}

			// Fill in the controls
			txtAddress1.Text = msg.Properties.Address1;
			txtAddress2.Text = msg.Properties.Address2;
			txtCity.Text = msg.Properties.City;
			txtState.Text = msg.Properties.State;
			txtZip.Text = msg.Properties.Zipcode;
			txtCountry.Text = msg.Properties.Country;

			// Update global copy
			SetCompanyAddress(msg);

			return true;
		}

		private bool SaveAddressData()
		{
			UpdAddressData addressMsg = new UpdAddressData(m_nAddressId);
			addressMsg.Properties.Address1 = txtAddress1.Text;
			addressMsg.Properties.Address2 = txtAddress2.Text;
			addressMsg.Properties.City = txtCity.Text;
			addressMsg.Properties.State = txtState.Text;
			addressMsg.Properties.Zipcode = txtZip.Text;
			addressMsg.Properties.Country = txtCountry.Text;

			try
			{
				addressMsg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, String.Format(Resources.UpdAddressDataFailed, e));
				return false;
			}

			// Update global copy
			UpdateCompanyAddress(addressMsg);

			return true;
		}

		private bool SaveCompanyData()
		{
			UpdCompanyDataMessage msg = new UpdCompanyDataMessage(Common.CompanyId);

			msg.Properties.Name = txtName.Text;
			msg.Properties.Active = chkIsActive.Checked;
			msg.Properties.AddressID = m_nAddressId;
			msg.Properties.Owner = txtOwner.Text;
			msg.Properties.Phone = txtPhone.Text;
			msg.Properties.SubCompanyID = 0;

			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, String.Format(Resources.UpdCompanyDataFailed, e));
				return false;
			}

			return true;

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		// Event handler for any change made 
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
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
			if (txtCountry.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterCountry);
				txtCountry.Select();
				return false;
			}
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
				MessageForm.Show(this, Resources.EnterCompanyName);
				txtName.Select();
				return false;
			}
			if (txtPhone.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterPhone);
				txtPhone.Select();
				return false;
			}
			//RALLY DE 2736 removed Owner field being a mandatory field

			return true;
		}

		#endregion // Private Routines

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers, back space, space, or -+() to be entered into the text box
            bool boolReturn = false;
            int isNumber = 0;

            switch (e.KeyChar)
            {
                case (char)8:   //back space
                    boolReturn = false;
                    break;
                case (char)32:  //space
                    boolReturn = false;
                    break;
                case (char)40:  //(
                    boolReturn = false;
                    break;
                case (char)41:  //)
                    boolReturn = false;
                    break;
                case (char)43:  //+
                    boolReturn = false;
                    break;
                case (char)45:  //-
                    boolReturn = false;
                    break;
                default:
                    boolReturn = !int.TryParse(e.KeyChar.ToString(), out isNumber);
                    break;
            }            

            e.Handled = boolReturn;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            chkIsActive.Focus();
        }

	} // end class
} // end namespace
