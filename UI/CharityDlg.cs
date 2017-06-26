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
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class CharityDlg : GradientForm
	{
		// Members
		public Charity charity = new Charity();

		public CharityDlg(Charity charity)
		{
			InitializeComponent();

			// Fill in controls
			this.charity = charity;
			FillControls();
		}

		// Private Routines
		#region Private Routines
		private void FillControls()
		{
			Common.BeginWait();
			SuspendLayout();

			// Fill in the location data
			txtName.Text = charity.Name;
			txtContact.Text = charity.Contact;
			txtPhone.Text = charity.Phone;
			chkIsActive.Checked = charity.Active;

            txtLicense.Text = charity.License;
            txtTaxId.Text = charity.TaxId;

			// Fill in the address data
			txtAddress1.Text = charity.Address1;
			txtAddress2.Text = charity.Address2;
			txtCity.Text = charity.City;
			txtState.Text = charity.State;
			txtZip.Text = charity.PostalCode;
			txtCountry.Text = charity.Country;

			ResumeLayout(true);
			Common.EndWait();
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
            if (!SaveCharityData())
			{
				Common.EndWait();
				return;
			}
			Common.EndWait();

			// Close the dialog
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private bool ValidateInput()
		{
			if (txtName.Text.Length == 0)
			{
				MessageForm.Show(this, Resources.EnterLocation);
				txtName.Select();
				return false;
			}

			return true;
		}

		private bool SaveCharityData()
		{
			charity.Name = txtName.Text;
			charity.Phone = txtPhone.Text;
			charity.Active = chkIsActive.Checked;

            txtName.Text = charity.Name;
            charity.Contact = txtContact.Text;
            charity.Phone = txtPhone.Text;
            charity.Active = chkIsActive.Checked;
            charity.License = txtLicense.Text;
            charity.TaxId = txtTaxId.Text;

            // Fill in the address data
            charity.Address1 = txtAddress1.Text;
            charity.Address2 = txtAddress2.Text;
            charity.City = txtCity.Text;
            charity.State = txtState.Text;
            charity.PostalCode = txtZip.Text;
            charity.Country = txtCountry.Text;

			// Save data to the server
			SetCharityData msg = new SetCharityData(charity);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, string.Format(Resources.SetCharityDataFailed, e));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.SetCharityDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
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