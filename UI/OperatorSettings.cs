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
using GTI.Modules.SystemSettings.Business;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class OperatorSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
       
		// Constructor
		#region Constructor
		public OperatorSettings()
		{
			InitializeComponent();

			// Add this handler in code so it won't get overwritten by the designer
			//this.chkCompanyAddress.CheckedChanged += new System.EventHandler(this.chkCompanyAddress_CheckedChanged);
			
		}

		#endregion


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

			bool bResult = LoadOperatorSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			if (!ValidateInput())
			{
				return false;
			}

			Common.BeginWait();

			bool bResult = SaveOperatorSettings();

			Common.EndWait();

			return bResult;
		}
		#endregion // Public Methods


		// Private Methods
		#region Private Methods

		private bool SaveOperatorSettings()
		{
			// Save the address
			
			
			if (!SaveOperatorAddress())
			{
				return false;
			}
			

			// Update the server settings
            Common.m_GetOperatorCompleteMessage.OperatorList[0].ContactName = txtContactName.Text;
            Common.m_GetOperatorCompleteMessage.OperatorList[0].Code = txtCode.Text;
			Common.m_GetOperatorCompleteMessage.OperatorList[0].Licence = txtLicense.Text;
			Common.m_GetOperatorCompleteMessage.OperatorList[0].Modem = txtModem.Text;
			Common.m_GetOperatorCompleteMessage.OperatorList[0].Name = txtOperatorName.Text;
			Common.m_GetOperatorCompleteMessage.OperatorList[0].Phone = txtPhoneNo.Text;
			Common.m_GetOperatorCompleteMessage.OperatorList[0].IsActive = chkIsActive.Checked;
		    Common.m_GetOperatorCompleteMessage.OperatorList[0].PlayerTierCalcId = (int)numPlayerTierID.Value;
		    Common.m_GetOperatorCompleteMessage.OperatorList[0].PercentOfProfitsToCharity = Convert.ToDecimal(txtPercentOfProfitsToCharity.Text);
		    Common.m_GetOperatorCompleteMessage.OperatorList[0].PercentPrizesToState =
		        Convert.ToDecimal(txtPercentofProfitsToState.Text);
		    Common.m_GetOperatorCompleteMessage.OperatorList[0].HallRent = Convert.ToDecimal(txtHallRentAmount.Text);
			
            // Save the operator data)
			if (!Common.SaveOperatorData())
			{
				return false;
			}

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool LoadOperatorSettings()
		{
			// Fill in the address data

            txtAddress1.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Address1;
            txtAddress2.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Address2;
            txtCity.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].City;
            txtState.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].State;
            txtZip.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Zip;
            txtCountry.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Country;

            txtBillingAddress1.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingAddress1;
            txtBillingAddress2.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingAddress2;
            txtBillingCity.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingCity;
            txtBillingState.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingState;
            txtBillingZip.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingZip;
            txtBillingCountry.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].BillingCountry;
            

			// Fill in the server settings
			txtContactName.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].ContactName;
			txtCode.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Code;
			txtLicense.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Licence;
			txtModem.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Modem;
			txtOperatorName.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Name;
			txtPhoneNo.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].Phone;
			chkIsActive.Checked = Common.m_GetOperatorCompleteMessage.OperatorList[0].IsActive;
		    txtHallRentAmount.Text = Common.m_GetOperatorCompleteMessage.OperatorList[0].HallRent.ToString();
		    txtPercentOfProfitsToCharity.Text =
		        Common.m_GetOperatorCompleteMessage.OperatorList[0].PercentOfProfitsToCharity.ToString();
		    txtPercentofProfitsToState.Text =
		        Common.m_GetOperatorCompleteMessage.OperatorList[0].PercentPrizesToState.ToString();
		    numPlayerTierID.Value = Common.m_GetOperatorCompleteMessage.OperatorList[0].PlayerTierCalcId;
            // Set the flag
			m_bModified = false;

			return true;
		}

		public bool FillAddress(int AddressID, int billingAddressID)
		{
			GetAddressDataMessage msg = new GetAddressDataMessage(AddressID);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageBox.Show(this, string.Format(Resources.GetAddressDataFailed, e));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
				MessageForm.Show(this, string.Format(Resources.GetAddressDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return false;
			}

			// Fill in address controls
			txtAddress1.Text = msg.Properties.Address1;
			txtAddress2.Text = msg.Properties.Address2;
			txtCity.Text = msg.Properties.City;
			txtState.Text = msg.Properties.State;
			txtZip.Text = msg.Properties.Zipcode;
			txtCountry.Text = msg.Properties.Country;

            msg = new GetAddressDataMessage(billingAddressID);
            msg.Send();
            
            // Check return code
            if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            {
                MessageForm.Show(this, string.Format(Resources.GetAddressDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
                return false;
            }

            txtBillingAddress1.Text = msg.Properties.Address1;
            txtBillingAddress2.Text = msg.Properties.Address2;
            txtBillingCity.Text = msg.Properties.City;
            txtBillingState.Text = msg.Properties.State;
            txtBillingZip.Text = msg.Properties.Zipcode;
            txtBillingCountry.Text = msg.Properties.Country;

			return true;
		}

		private bool SaveOperatorAddress()
		{
            UpdAddressData msg = new UpdAddressData(Common.m_GetOperatorCompleteMessage.OperatorList[0].AddressID);
			msg.Properties.Address1 = txtAddress1.Text;
			msg.Properties.Address2 = txtAddress2.Text;
			msg.Properties.City = txtCity.Text;
			msg.Properties.State = txtState.Text;
			msg.Properties.Zipcode = txtZip.Text;
			msg.Properties.Country = txtCountry.Text;

			try
			{
				msg.Send();

				// Get the new address ID in the case of a new address
				if (Common.m_GetOperatorCompleteMessage.OperatorList[0].AddressID == 0)
				{
					Common.m_GetOperatorCompleteMessage.OperatorList[0].AddressID = msg.Properties.AddressID;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(this, string.Format(Resources.UpdAddressDataFailed , e));
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

		

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;
			SaveSettings();
		}

		private bool ValidateInput()
		{


			return true;
		}

		// Called whenever any value changes
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		

		#endregion // Private Methods

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Validator.ValidatePercent(textBox.Text))
            {
                m_errorProvider.SetError(textBox, string.Empty);
            }
            else
            {
                e.Cancel = true;
                m_errorProvider.SetError(textBox, Resources.ErrorPercent);
            }
        }

        private void txtModem_KeyPress(object sender, KeyPressEventArgs e)
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
