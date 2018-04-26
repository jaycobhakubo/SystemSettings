//US4434 Auto issue a cashiers bank

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using System.ComponentModel;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class OperatorManagement : SettingsControl
    {
        private OperatorManagementPresenter m_operatorManagementPresenter;
        private int m_previousSelectedID;
        
        private int m_currentlySelectedOperatorIndex;
        private ActivityState m_activityState;
        private MainForm m_mainForm;
        private int m_currentAddressId;
        private int m_currentBillingAddressId;
        public bool m_IsModified;
        private bool m_loadingOperator = false;

        public bool IsModifiedBool
        {
            get
            {
                return m_IsModified; 
            }
            
            set
            {
                m_IsModified = value;
                m_OperatorGroupBox1.Enabled = !value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool LoadSettings() 
        {
            m_activityState = ActivityState.All;
            comboOperatorDisplayMode.SelectedIndex = 0;
            m_operatorManagementPresenter.LoadModel(m_currentlySelectedOperatorIndex);
            IsModifiedBool = false;
           
            return true;
        }

        /// <summary>ima
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool SaveSettings() 
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return false;
            //FIX START RALLY DE 3581: changing setting page after edit crashed
            IsModifiedBool = false;
            m_operatorManagementPresenter.UpdateOperator(CreateBingoOperator(m_previousSelectedID));
            m_operatorManagementPresenter.SaveModel(m_currentlySelectedOperatorIndex);
            //DE12971: Fix Operator Management crash on not saving settings before trying to switch tabs
            /*if (m_mainForm != null)
            {
                m_mainForm.LoadComboBox();
            }*/
            //FIX END RALLY DE 3581: changing setting page after edit crashed
            return true;
        }

        //START RALLY DE 6576
        public BingoOperator GetCurrentOperator(int operatorID)
        {
            return m_operatorManagementPresenter.GetOperatorByID(operatorID);
        }
        //END RALLY DE 6576
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsModified() { return IsModifiedBool; }

        /// <summary>
        /// 
        /// </summary>
        public OperatorManagement()
        {
            InitializeComponent();
            if(!DesignMode)
            {
                m_operatorManagementPresenter = new OperatorManagementPresenter(this);
            }
            m_previousSelectedID = -1;
            m_currentlySelectedOperatorIndex = 0;
            SetOperatorDetailsEnabled(false);
            comboOperatorDisplayMode.SelectedIndex = 0;
            m_currentAddressId = 0;
            m_currentBillingAddressId = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorList"></param>
        public void LoadOperatorList(List<BingoOperator> operatorList, int selectedIndex)
        {
            gtiListView1.Items.Clear();
           
            foreach (BingoOperator bingoOperator in operatorList)
            {
                ListViewItem item = new ListViewItem(new string[]
                           { bingoOperator.OperatorName, 
                             bingoOperator.OperatorId.ToString()});
                item.Tag = false;
                gtiListView1.Items.Add(item);
                
            }
            if (gtiListView1.Items.Count > 0 && selectedIndex < gtiListView1.Items.Count && selectedIndex > 0)
            {
                gtiListView1.Items[selectedIndex].Selected = true;
            }
            else if(gtiListView1.Items.Count > 0)
            {
                gtiListView1.Items[0].Selected = true;
                m_currentlySelectedOperatorIndex = 0;
            }
            else
            {
                ClearOperatorDetails();
                SetOperatorDetailsEnabled(false);
                m_currentlySelectedOperatorIndex = -1;
            }
        }
        /// <summary>
        /// creates a bingo operator from the data in the form
        /// </summary>
        /// <param name="operatorID">the operator id to </param>
        /// <returns>a BingoOperator data object</returns>
        public BingoOperator CreateBingoOperator(int operatorID)
        {
            
            BingoOperator bingoOperator = new BingoOperator();
            if (operatorID >= 0)
            {
                bingoOperator.OperatorName = operatorNameTextBox.Text;
                bingoOperator.OperatorId = operatorID;
                bingoOperator.operatorAddress1 = m_textBoxAddress1.Text;
                bingoOperator.operatorAddress2 = m_textBoxAddress2.Text;
                bingoOperator.operatorAddressCity = m_textBoxCity.Text;
                bingoOperator.operatorAddressState = m_textBoxState.Text;
                bingoOperator.operatorAddressZip = m_textBoxZipCode.Text;
                bingoOperator.operatorAddressCountry = m_textBoxCountry.Text;
                bingoOperator.OperatorIsActive = operatorIsActiveCheckBox.Checked;
                bingoOperator.OperatorTaxpayerId = operatorTaxIDTextBox.Text;
                bingoOperator.OperatorLicenseNumber = operatorLicenseNumberTextBox.Text;
                bingoOperator.operatorBillingAddress1 = m_textBoxbillingAddress1.Text;
                bingoOperator.operatorBillingAddress2 = m_textBoxBillingAddress2.Text;
                bingoOperator.operatorBillingAddressCity = m_textBoxBillingAddressCity.Text;
                bingoOperator.operatorBillingAddressState = m_textBoxBillingAddressSate.Text;
                bingoOperator.operatorBillingAddressZip = m_textBoxBillingZipCode.Text;
                bingoOperator.operatorBillingAddressCountry = m_textBoxBillingAddressCountry.Text;
                bingoOperator.OperatorPhoneNumber = operatorPhoneTextBox.Text;
                bingoOperator.OperatorContactName = operatorContactNameTextBox.Text;
                bingoOperator.OperatorCashMethodId = operatorCashMethodIDCombo.SelectedIndex + 1; //RALLY DE 3143 need values of 1 or 2 (non zero)
                bingoOperator.OperatorCode = operatorCodeTextBox.Text;
                bingoOperator.OperatorHallRentAmount = Convert.ToDecimal(operatorHallRentAmountTextBox.Text);
                bingoOperator.OperatorPercentageOfProfits = Convert.ToDecimal(operatorProfitPercentTextBox.Text);
                bingoOperator.OperatorPercentageOfStateRevenue = Convert.ToDecimal(operatorStatePercentTextBox.Text);
                bingoOperator.OperatorModemNumber = operatorModemTextBox.Text;
                bingoOperator.OperatorBillingAddressId = m_currentBillingAddressId;
                bingoOperator.OperatorAddressId = m_currentAddressId;
                
                return bingoOperator;
            }
            return null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bingoOperator"></param>
        public void SetOperatorDetails(BingoOperator bingoOperator)
        {
            m_loadingOperator = true;
            operatorNameTextBox.Text = bingoOperator.OperatorName;
            m_textBoxAddress1.Text = bingoOperator.operatorAddress1;
            m_textBoxAddress2.Text = bingoOperator.operatorAddress2;
            m_textBoxCity.Text = bingoOperator.operatorAddressCity;
            m_textBoxState.Text = bingoOperator.operatorAddressState;
            m_textBoxZipCode.Text = bingoOperator.operatorAddressZip;
            m_textBoxCountry.Text = bingoOperator.operatorAddressCountry;
            operatorIsActiveCheckBox.Checked = bingoOperator.OperatorIsActive;
            operatorLicenseNumberTextBox.Text = bingoOperator.OperatorLicenseNumber;
            m_textBoxbillingAddress1.Text = bingoOperator.operatorBillingAddress1;
            m_textBoxBillingAddress2.Text = bingoOperator.operatorBillingAddress2;
            m_textBoxBillingAddressCity.Text = bingoOperator.operatorBillingAddressCity;
            m_textBoxBillingAddressSate.Text = bingoOperator.operatorBillingAddressState;
            m_textBoxBillingZipCode.Text = bingoOperator.operatorBillingAddressZip;
            m_textBoxBillingAddressCountry.Text = bingoOperator.operatorBillingAddressCountry;
            operatorPhoneTextBox.Text = bingoOperator.OperatorPhoneNumber;
            operatorContactNameTextBox.Text = bingoOperator.OperatorContactName;
            operatorHallRentAmountTextBox.Text = bingoOperator.OperatorHallRentAmount.ToString();
            operatorProfitPercentTextBox.Text = bingoOperator.OperatorPercentageOfProfits.ToString();
            operatorStatePercentTextBox.Text = bingoOperator.OperatorPercentageOfStateRevenue.ToString();
            operatorTaxIDTextBox.Text = bingoOperator.OperatorTaxpayerId;
            operatorCashMethodIDCombo.SelectedIndex = bingoOperator.OperatorCashMethodId - 1;//RALLY DE 3143 need values of 1 or 2 (non zero)
            operatorCodeTextBox.Text = bingoOperator.OperatorCode;
            operatorModemTextBox.Text = bingoOperator.OperatorModemNumber;
            m_currentAddressId = bingoOperator.OperatorAddressId;
            m_currentBillingAddressId = bingoOperator.OperatorBillingAddressId;
            
            if(m_currentAddressId == m_currentBillingAddressId)
            {
                m_chkUseAddress.Checked = true;
                SetBillingEnabled(false);
                LoadAddress(true);
            }
            else
            {
                m_chkUseAddress.Checked = false;
                SetBillingEnabled(true);
            }

            IsModifiedBool = false;
            m_loadingOperator = false;
        }
        /// <summary>
        /// 
        /// </summary>
        private void ClearOperatorDetails()
        {
            bool savedLoadingStatus = m_loadingOperator;
            m_loadingOperator = true;

            ControlCollection componentList = operatorDetailsGroupBox.Controls;
            
            foreach (Control component in componentList)
            {
                if (component.GetType() == typeof(TextBox))
                {
                    ((TextBox)component).Text = "";
                }
            }
            
            operatorIsActiveCheckBox.Checked = false;
            m_loadingOperator = savedLoadingStatus;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetOperatorDetailsEnabled(bool enabled)
        {
            ControlCollection componentList = operatorDetailsGroupBox.Controls;
            foreach(Control component in componentList)
            {
                if(component.GetType() == typeof(TextBox))
                {
                    ((TextBox) component).Enabled = enabled;
                }
                else if(component.GetType() == typeof(Label))
                {
                    ((Label) component).Enabled = enabled;
                }
                //START RALLY DE 4098 setting is not disabled when no operator selected
                else if(component.GetType()== typeof(MaskedTextBox))
                {
                    ((MaskedTextBox) component).Enabled = enabled;
                }
                else if (component.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)component).Enabled = enabled;
                }
                //END RALLY DE 4098
            }
            operatorIsActiveCheckBox.Enabled = enabled;
            m_chkUseAddress.Enabled = enabled;//RALLY DE 4098 setting is not disabled when no operator selected
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible)
                || m_previousSelectedID < 0)
                return;
    
            IsModifiedBool = false;

            //US4434
            //Save operator setting for auto issue
            //US4639: Moved to POS settings
            int operatorId = int.Parse(gtiListView1.SelectedItems[0].SubItems[1].Text);
            //var autoIssue = chkbxAutoIssue.Visible ? chkbxAutoIssue.Checked.ToString() : "False";
            //Common.SetOpSettingValue(operatorId, Setting.AutoIssueBank, autoIssue);

            m_operatorManagementPresenter.UpdateOperator(CreateBingoOperator(m_previousSelectedID));
            m_operatorManagementPresenter.SaveModel(m_currentlySelectedOperatorIndex);
            

            if(m_mainForm != null)
            {
                m_mainForm.LoadComboBox();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gtiListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gtiListView1.SelectedItems.Count > 0 )
            {
                var operatorId = gtiListView1.SelectedItems[0].SubItems[1].Text;

                SetOperatorDetailsEnabled(true);
                m_operatorManagementPresenter.OperatorSelected(operatorId);
                m_previousSelectedID = Convert.ToInt32(operatorId);
                m_currentlySelectedOperatorIndex = gtiListView1.SelectedIndices[0];

                //US4434
                //update UI for auto issue
                //US4639: Moved to POS Settings
                /*
                SettingValue setting;
                var operatorSettingsMessage = new GetSettingsOperatorMessage(int.Parse(operatorId));
                operatorSettingsMessage.Send();
                operatorSettingsMessage.SettingsDictionary.TryGetValue((int)Setting.AutoIssueBank, out setting);
                //set check box
                bool autoIssue;
                bool.TryParse(setting.Value, out autoIssue);
                chkbxAutoIssue.Checked = autoIssue;*/
            }
            else
            {
                ClearOperatorDetails();
                SetOperatorDetailsEnabled(false);
                m_previousSelectedID = -1;
                m_currentlySelectedOperatorIndex = -1;
            }

            gtiListView1.Focus();
        }

        /// <summary>
        /// add a new operator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { "New Operator","0" });

            BingoOperator bingoOperator = new BingoOperator();
            bingoOperator.OperatorId = 0;
            bingoOperator.OperatorName = "New Operator";
            bingoOperator.OperatorCashMethodId = 1;
            gtiListView1.Items.Add(item);
            m_operatorManagementPresenter.AddOperator(bingoOperator);
            
            item.Selected = true;
            IsModifiedBool = true;
        }

        private void comboOperatorDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivityState newState = (ActivityState)comboOperatorDisplayMode.SelectedIndex;

            m_operatorManagementPresenter.Reset(m_currentlySelectedOperatorIndex);
            m_operatorManagementPresenter.ChangeActiveState(newState, m_currentlySelectedOperatorIndex);
            m_activityState = newState;
        }

        private bool ShowSaveDialog()
        {
            DialogResult result = 
            
                MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
            
            if(result == DialogResult.Yes)
            {
                if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible)
                   || m_previousSelectedID < 0)
                    return false;

                IsModifiedBool = false;
                m_operatorManagementPresenter.UpdateOperator(CreateBingoOperator(m_previousSelectedID));
                m_operatorManagementPresenter.SaveModel(m_currentlySelectedOperatorIndex);
                
                if (m_mainForm != null)
                {
                    m_mainForm.LoadComboBox();
                }

                IsModifiedBool = false;
                return true;
            }

            else if(result == DialogResult.No)
            {
                
                IsModifiedBool = false;
               
                return true;
            }

            else if(result == DialogResult.Cancel)
            {
                IsModifiedBool = true;
                //this means do not navigate away from the current page
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates a percentage Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (Validator.ValidatePercent(textBox.Text))
            {
                m_errorValidator.SetError(textBox, string.Empty);
            }
            else
            {
                e.Cancel = true;
                m_errorValidator.SetError(textBox, Resources.ErrorPercent);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            e.Handled = ! char.IsDigit(e.KeyChar);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = false;

            if (!char.IsControl(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case (char)46://period
                        result = false;
                        break;
                    default:
                        result = !char.IsDigit(e.KeyChar);
                        break;
                }
            }

            e.Handled = result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HallRentAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            bool result = false;

            if (!char.IsControl(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Back:
                        result = false;
                        break;
                    case (char)46://period
                        result = false;
                        break;
                    
                    default:
                        result = !char.IsDigit(e.KeyChar);
                        break;
                }
            }
            if(result == false)
            {
                IsModifiedBool = true;
            }
            e.Handled = result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //RALLY DE 6216 Reset on system settings a dialog popped up. removed
            IsModifiedBool = false;
            m_operatorManagementPresenter.Reset(m_currentlySelectedOperatorIndex);
            comboOperatorDisplayMode.SelectedIndex = 0;
        }

        private void operatorCashMethodIDCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnModified(sender, e);

            if (operatorCashMethodIDCombo.SelectedIndex == 2)
            {
                //if (chkbxAutoIssue.Visible != false) chkbxAutoIssue.Visible = false;
                operatorIsActiveCheckBox.Location = new System.Drawing.Point(239, 267);

            }
            else
            {
               // if (chkbxAutoIssue.Visible != true) chkbxAutoIssue.Visible = true;
                operatorIsActiveCheckBox.Location = new System.Drawing.Point(238, 286);
                //chkbxAutoIssue.Location = new System.Drawing.Point(238, 254);
            }
        }

        internal void SetForm(MainForm mainForm)
        {
            m_mainForm = mainForm;
        }

        private void m_chkUseAddress_CheckedChanged(object sender, EventArgs e)
        {
            OnModified(sender, e);

            CheckBox checkBox = sender as CheckBox;

            //if true
            if (checkBox != null && checkBox.Checked)
            {
                //load the text boxes with the operator address information
                LoadAddress(true);
                //disable the text boxes
                SetBillingEnabled(false);
                //set the address id somehow
                m_currentBillingAddressId = m_currentAddressId;
            }
                //else
            else
            {
                //unload the text boxes with the operator address information
                LoadAddress(false);
                //enable the text boxes
                SetBillingEnabled(true);
                //set unique address id? or will model handle it?
                m_currentBillingAddressId = 0;
            }
        }

        private void LoadAddress(bool flag)
        {
            if(flag)
            {
                m_textBoxbillingAddress1.Text = m_textBoxAddress1.Text;
                m_textBoxBillingAddress2.Text = m_textBoxAddress2.Text;
                m_textBoxBillingAddressCity.Text = m_textBoxCity.Text;
                m_textBoxBillingAddressSate.Text = m_textBoxState.Text;
                m_textBoxBillingZipCode.Text = m_textBoxZipCode.Text;
                m_textBoxBillingAddressCountry.Text = m_textBoxCountry.Text;
            }

            else
            {
                m_textBoxbillingAddress1.Text = String.Empty;
                m_textBoxBillingAddress2.Text = String.Empty;
                m_textBoxBillingAddressCity.Text = String.Empty;
                m_textBoxBillingAddressSate.Text = String.Empty;
                m_textBoxBillingZipCode.Text = String.Empty;
                m_textBoxBillingAddressCountry.Text = String.Empty;
            }
        }

        private void SetBillingEnabled(bool enabled)
        {
            m_labelBillingAdress1.Enabled = enabled;
            m_labelBillingAdress2.Enabled = enabled;
            m_labelBillingCity.Enabled = enabled;
            m_labelBillingState.Enabled = enabled;
            m_labelBillingCountry.Enabled = enabled;
            m_labelBillingState.Enabled = enabled;
            m_labelBillingZipCode.Enabled = enabled;
            m_textBoxbillingAddress1.Enabled = enabled;
            m_textBoxBillingAddress2.Enabled = enabled;
            m_textBoxBillingAddressCity.Enabled = enabled;
            m_textBoxBillingAddressSate.Enabled = enabled;
            m_textBoxBillingAddressCountry.Enabled = enabled;
            m_textBoxBillingZipCode.Enabled = enabled;
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        private void m_textBoxAddress1_KeyUp(object sender, KeyEventArgs e)
        {
            if(m_chkUseAddress.Checked == true)
                m_textBoxbillingAddress1.Text = m_textBoxAddress1.Text;
        }

        private void m_textBoxAddress2_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_chkUseAddress.Checked )
                m_textBoxBillingAddress2.Text = m_textBoxAddress2.Text;
        }

        private void m_textBoxCity_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_chkUseAddress.Checked )
                m_textBoxBillingAddressCity.Text = m_textBoxCity.Text;
        }

        private void m_textBoxState_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_chkUseAddress.Checked )
                m_textBoxBillingAddressSate.Text = m_textBoxState.Text;
        }

        private void m_textBoxZipCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_chkUseAddress.Checked )
                m_textBoxBillingZipCode.Text = m_textBoxZipCode.Text;
        }

        private void m_textBoxCountry_KeyUp(object sender, KeyEventArgs e)
        {
             if (m_chkUseAddress.Checked )
                 m_textBoxBillingAddressCountry.Text = m_textBoxCountry.Text;
        }

        private void operatorNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!m_loadingOperator)
            {
                IsModifiedBool = true;

                if (m_currentlySelectedOperatorIndex != -1)
                    gtiListView1.Items[m_currentlySelectedOperatorIndex].SubItems[0].Text = operatorNameTextBox.Text;
            }
        }

        private void OnModified(object sender, EventArgs e)
        {
            IsModifiedBool = true;
        }
    }
}
