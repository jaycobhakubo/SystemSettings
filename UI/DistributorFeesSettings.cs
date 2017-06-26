using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Controls;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    //todo populate tab item texts based on something in managed elite module
    public partial class DistributorFeesSettings : SettingsControl
    {
        // Members
        private bool m_bModified = false;
        private DistributorFeesPresenter m_distributorFeesPresenter;
        private int m_SelectedID;
        private ListViewItem m_selectedListViewItem;
        
        //The following lists indexed by device
        private List<RadioButton> m_radioInventoryList;
        private List<RadioButton> m_radioPerUseList;
        private List<TextBox> m_textBoxFeeInventoryList;
        private List<TextBox> m_textBoxFeePerUseList;
        private List<ComboBox> m_comboBoxFrequencyList;
        private List<TextBox> m_textBoxStartValueList;
        private List<GTIListView> m_gtiListViewItemsList;
        private List<Label> m_labelCurrencyPerUseList;
        private List<Label> m_labelFeePerUseList;
        private List<Label> m_labelStartValuePerUseList;
        private List<Label> m_labelFrequencyInventoryList;
        private List<Label> m_labelCurrencyInventoryList;
        private List<Label> m_labelFeeInventoryList;
        private List<Button> m_buttonAddTierButtonList;
        private List<Button> m_buttonRemoveTierButtonList;
        private DistributorFeeDataItem m_currentDistributorFeeDataItem;
        private int m_previouslySelectedTabDeviceId;
        private int m_previouslySelectedTierId;
        private bool m_InventoryEventFlag;

        //US3339
        private TabPage m_tabPagecbb = new TabPage("CBB");
        private Label lblElectronicFee = new Label();
        private Label lblPaperFees = new Label();
       // private Label CurrencySign = new Label();
       // private Label CurrencySign2 = new Label();
        private TextBox txtbxPaperFees = new TextBox();
        private TextBox txtbxElectronicFees = new TextBox();
        private GroupBox grpbxCBBTab = new GroupBox();
        /// <summary>
        /// 
        /// </summary>
        public DistributorFeesSettings()
        {
            InitializeComponent();

            if (Common.CBBEnabled == true)//US3339 TA12821
            {
                m_tabControl.TabPages.Add(m_tabPagecbb);
                m_tabPagecbb.Tag = 0;
                m_tabPagecbb.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientPanel;
                grpbxCBBTab.Size = new Size(440, 280);
                grpbxCBBTab.Location = new Point(13, 15);
                grpbxCBBTab.BackColor = System.Drawing.Color.Transparent;
                m_tabPagecbb.Controls.Add(grpbxCBBTab);

                lblElectronicFee.Text = "Electronic Fee";
                lblElectronicFee.Size = new Size(130, 20);
                lblElectronicFee.Location = new Point(50, 50);
                //m_tabPagecbb.Controls.Add(lblElectronicFee);
                grpbxCBBTab.BackColor = System.Drawing.Color.Transparent;
                grpbxCBBTab.Controls.Add(lblElectronicFee);

                lblPaperFees.Text = "Paper Fee";
                lblPaperFees.Size = new Size(125, 20);
                lblPaperFees.Location = new Point(50, 90);
                //m_tabPagecbb.Controls.Add(lblPaperFees);
                grpbxCBBTab.Controls.Add(lblPaperFees);

                txtbxElectronicFees.Size = new Size(125, 25);
                txtbxElectronicFees.Location = new Point(220, 50);
                txtbxElectronicFees.KeyPress += new KeyPressEventHandler(PercentTextBox_KeyPress);
                grpbxCBBTab.Controls.Add(txtbxElectronicFees);
                
                txtbxPaperFees.Size = new Size(125, 25);
                txtbxPaperFees.Location = new Point(220, 90);
                txtbxPaperFees.KeyPress += new KeyPressEventHandler(PercentTextBox_KeyPress);
                grpbxCBBTab.Controls.Add(txtbxPaperFees);
            }

            if (!DesignMode)
            {
                m_distributorFeesPresenter = new DistributorFeesPresenter(this);
            }
            
            //todo set the currency to the current currency settings
            //m_labelFeeCurrency.Text = 
            InitializeLists();
            m_SelectedID = -1;
            m_previouslySelectedTabDeviceId = Device.Fixed.Id; //RALLY TA 7728
            m_previouslySelectedTierId = -1;
            SetEnabledAddTierButtons(false);
            m_InventoryEventFlag = true;
        }

        private void InitializeLists()
        {
            m_radioInventoryList = new List<RadioButton>();
            m_radioInventoryList.Add(m_rdoInventoryFixedBase);
            m_radioInventoryList.Add(m_rdoInventoryTraveler);
            m_radioInventoryList.Add(m_rdoInventoryTraveler2);
            m_radioInventoryList.Add(m_rdoInventoryTracker);
            m_radioInventoryList.Add(m_rdoInventoryExplorer);//RALLY TA 7728
            m_radioInventoryList.Add(m_rdoInventoryTedE);

            m_radioPerUseList = new List<RadioButton>();
            m_radioPerUseList.Add(m_rdoPerUseFixedBase);
            m_radioPerUseList.Add(m_rdoPerUseTraveler);
            m_radioPerUseList.Add(m_rdoPerUseTraveler2);
            m_radioPerUseList.Add(m_rdoPerUseTracker);
            m_radioPerUseList.Add(m_rdoPerUseExplorer);//RALLY TA 7728
            m_radioPerUseList.Add(m_rdoPerUseTedE); 

            m_textBoxFeeInventoryList = new List<TextBox>();
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryFixedBase);
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryTraveler);
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryTraveler2);
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryTracker);
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryExplorer);//RALLY TA 7728
            m_textBoxFeeInventoryList.Add(m_textFeeInventoryTedE);

            m_textBoxFeePerUseList = new List<TextBox>();
            m_textBoxFeePerUseList.Add(m_textFeePerUseFixedBase);
            m_textBoxFeePerUseList.Add(m_textFeePerUseTraveler);
            m_textBoxFeePerUseList.Add(m_textFeePerUseTraveler2);
            m_textBoxFeePerUseList.Add(m_textFeePerUseTracker);
            m_textBoxFeePerUseList.Add(m_textFeePerUseExplorer);//RALLY TA 7728
            m_textBoxFeePerUseList.Add(m_textFeePerUseTedE);//RALLY TA 7728

            m_comboBoxFrequencyList = new List<ComboBox>();
            m_comboBoxFrequencyList.Add(m_cboFrequencyFixedBase);
            m_comboBoxFrequencyList.Add(m_cboFrequencyTraveler);
            m_comboBoxFrequencyList.Add(m_cboFrequencyTraveler2);
            m_comboBoxFrequencyList.Add(m_cboFrequencyTracker);
            m_comboBoxFrequencyList.Add(m_cboFrequencyExplorer);//RALLY TA 7728
            m_comboBoxFrequencyList.Add(m_cboFrequencyTedE);

            m_textBoxStartValueList = new List<TextBox>();
            m_textBoxStartValueList.Add(m_TextStartPerUseFixedBase);
            m_textBoxStartValueList.Add(m_TextStartPerUseTraveler);
            m_textBoxStartValueList.Add(m_TextStartPerUseTraveler2);
            m_textBoxStartValueList.Add(m_TextStartPerUseTracker);
            m_textBoxStartValueList.Add(m_TextStartPerUseExplorer);//RALLY TA 7728
            m_textBoxStartValueList.Add(m_TextStartPerUseTedE);

            m_gtiListViewItemsList = new List<GTIListView>();
            m_gtiListViewItemsList.Add(m_gtiListViewFixedBase);
            m_gtiListViewItemsList.Add(m_gtiListViewTraveler);
            m_gtiListViewItemsList.Add(m_gtiListViewTraveler2);
            m_gtiListViewItemsList.Add(m_gtiListViewTracker);
            m_gtiListViewItemsList.Add(m_gtiListViewExplorer);//RALLY TA 7728
            m_gtiListViewItemsList.Add(m_gtiListViewTedE);

            m_labelCurrencyPerUseList = new List<Label>();
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseFixedBase);
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseTraveler);
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseTraveler2);
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseTracker);
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseExplorer);//RALLY TA 7728
            m_labelCurrencyPerUseList.Add(m_labelFeeCurrencyPerUseTedE);

            m_labelFeePerUseList = new List<Label>();
            m_labelFeePerUseList.Add(m_labelFeePerUseFixedBase);
            m_labelFeePerUseList.Add(m_labelFeePerUseTraveler);
            m_labelFeePerUseList.Add(m_labelFeePerUseTraveler2);
            m_labelFeePerUseList.Add(m_labelFeePerUseTracker);
            m_labelFeePerUseList.Add(m_labelFeePerUseExplorer);//RALLY TA 7728
            m_labelFeePerUseList.Add(m_labelFeePerUseTedE);

            m_labelStartValuePerUseList = new List<Label>();
            m_labelStartValuePerUseList.Add(m_labelStartValueFixedBase);
            m_labelStartValuePerUseList.Add(m_labelStartValueTraveler);
            m_labelStartValuePerUseList.Add(m_labelStartValueTraveler2);
            m_labelStartValuePerUseList.Add(m_labelStartValueTracker);
            m_labelStartValuePerUseList.Add(m_labelStartValueExplorer);//RALLY TA 7728
            m_labelStartValuePerUseList.Add(m_labelStartValueTedE);

            m_labelCurrencyInventoryList = new List<Label>();
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryFixedBase);
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryTraveler);
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryTraveler2);
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryTracker);
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryExplorer);//RALLY TA 7728
            m_labelCurrencyInventoryList.Add(m_labelCurrencyInventoryTedE);

            m_labelFeeInventoryList = new List<Label>();
            m_labelFeeInventoryList.Add(m_labelFeeInventoryFixedBase);
            m_labelFeeInventoryList.Add(m_labelFeeInventoryTraveler);
            m_labelFeeInventoryList.Add(m_labelFeeInventoryTraveler2);
            m_labelFeeInventoryList.Add(m_labelFeeInventoryTracker);
            m_labelFeeInventoryList.Add(m_labelFeeInventoryExplorer);//RALLY TA 7728
            m_labelFeeInventoryList.Add(m_labelFeeInventoryTedE);

            m_labelFrequencyInventoryList = new List<Label>();
            m_labelFrequencyInventoryList.Add(m_labelFrequencyFixedBase);
            m_labelFrequencyInventoryList.Add(m_labelFrequencyTraveler);
            m_labelFrequencyInventoryList.Add(m_labelFrequencyTraveler2);
            m_labelFrequencyInventoryList.Add(m_labelFrequencyTracker);
            m_labelFrequencyInventoryList.Add(m_labelFrequencyExplorer);//RALLY TA 7728
            m_labelFrequencyInventoryList.Add(m_labelFrequencyTedE);

            m_buttonAddTierButtonList = new List<Button>();
            m_buttonAddTierButtonList.Add(m_AddButtonFixedBase);
            m_buttonAddTierButtonList.Add(m_AddButtonTraveler);
            m_buttonAddTierButtonList.Add(m_AddButtonTraveler2);
            m_buttonAddTierButtonList.Add(m_AddButtonTracker);
            m_buttonAddTierButtonList.Add(m_AddButtonExplorer);//RALLY TA 7728
            m_buttonAddTierButtonList.Add(m_AddButtonTedE);

            m_buttonRemoveTierButtonList = new List<Button>();
            m_buttonRemoveTierButtonList.Add(m_removeButtonFixedBase);
            m_buttonRemoveTierButtonList.Add(m_removeButtonTraveler);
            m_buttonRemoveTierButtonList.Add(m_removeButtonTraveler2);
            m_buttonRemoveTierButtonList.Add(m_removeButtonTracker);
            m_buttonRemoveTierButtonList.Add(m_removeButtonExplorer);//RALLY TA 7728
            m_buttonRemoveTierButtonList.Add(m_removeButtonTedE);
        }


        public bool IsModifiedBool
        {
            get { return m_bModified; }
            set { m_bModified = value;}
        }

       

        // Public Methods
        #region Public Methods
        public override bool IsModified()
        {
            return IsModifiedBool;
        }

        public override void OnActivate(object o)
        {

        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            bool bResult = LoadDistributorFeesSettings();
            m_distributorFeesPresenter.Reset();
            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        private bool LoadDistributorFeesSettings()
        {
            m_currentDistributorFeeDataItem = null;

            if(m_distributorFeesPresenter.LoadSettings())
            {
                IsModifiedBool = false;
                return true;
            }

            else
            {
                return false;
            }
        }

        public override bool SaveSettings()
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return false;

            Common.BeginWait();

            bool bResult = SaveDistributorFeesSettings(GetDeviceType());

            Common.EndWait();

            return bResult;
        }

        private bool SaveDistributorFeesSettings(int deviceId)
        {
            bool rc = false;

            if (deviceId == 0)
                rc = SaveDistributorGeneralFeeSettings();
            else
                rc = SaveDistributorDeviceFeeSettings(deviceId);

            return rc;
        }

        private bool SaveDistributorGeneralFeeSettings()
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return false;

            int deviceIndex = GetDeviceIndex(0);
            if (deviceIndex == 6) // CBB fees
            {
                // Update the Electronic values
                DistributorFeeDataItem item = m_distributorFeesPresenter.GetLastDistributorFee(0, 5);
                if (item != null)
                {
                    if (txtbxElectronicFees.Text.Length > 0)
                        item.DistributorFee = Convert.ToDecimal(txtbxElectronicFees.Text);
                    else
                        item.DistributorFee = 0;

                    m_distributorFeesPresenter.UpdateDistributorFee(item, 0, 5, 0);
                }
                
                item = m_distributorFeesPresenter.GetLastDistributorFee(0, 6);
                if (item != null)
                {
                    if (txtbxPaperFees.Text.Length > 0)
                        item.DistributorFee = Convert.ToDecimal(txtbxPaperFees.Text);
                    else
                        item.DistributorFee = 0;

                    m_distributorFeesPresenter.UpdateDistributorFee(item, 0, 6, 0);
                }
            }

            bool result = m_distributorFeesPresenter.SaveSettings(0);
            
            if (result == true)
                m_bModified = false;

            return result;
        }

        private bool SaveDistributorDeviceFeeSettings(int deviceId)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return false;
           
            int deviceIndex = GetDeviceIndex(deviceId);
            if (m_currentDistributorFeeDataItem == null)
            {
                m_currentDistributorFeeDataItem = GetCurrentDataItem(deviceId);
            }

            //there is still a chance it could be null
            if(m_currentDistributorFeeDataItem != null)
            {
                if(m_radioInventoryList[deviceIndex].Checked && m_comboBoxFrequencyList[deviceIndex].SelectedIndex == 0)
                {
                    //update current fee (Inventory Monthly)
                    m_currentDistributorFeeDataItem.DistributorFee =
                        Convert.ToDecimal(m_textBoxFeeInventoryList[deviceIndex].Text);
                    
                    m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 2, 0);      
                }
                else if (m_radioInventoryList[deviceIndex].Checked && m_comboBoxFrequencyList[deviceIndex].SelectedIndex == 1)
                {
                    //update current fee (Inventory Daily)
                    m_currentDistributorFeeDataItem.DistributorFee =
                       Convert.ToDecimal(m_textBoxFeeInventoryList[deviceIndex].Text);
                   
                    m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 4, 0);

                }
                else if (m_radioInventoryList[deviceIndex].Checked && m_comboBoxFrequencyList[deviceIndex].SelectedIndex == 2)
                {
                    //update current fee (Inventory Weekly)
                   
                    m_currentDistributorFeeDataItem.DistributorFee =
                       Convert.ToDecimal(m_textBoxFeeInventoryList[deviceIndex].Text);
                   
                    m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 3, 0);
                }
            }
            //not saving anything because nothing is selected
            else
            {
                IsModifiedBool = false;
                return true;
            }
            bool bResult = m_distributorFeesPresenter.SaveSettings(deviceId);

            if(bResult == false)
            {
                return false;
            }
            
            IsModifiedBool = false;
            return true;
        }

        #endregion  // Public Methods

        internal void LoadDistributorFees(List<DistributorFee> list)
        {
            //START RALLY TA 7728 changed constants to device.<device> enumeration
            DistributorFee fee = list.Find(i => i.DeviceId == Device.Fixed.Id);
            LoadTabPage(fee, Device.Fixed.Id);

            fee = list.Find(i => i.DeviceId == Device.Traveler.Id);
            LoadTabPage(fee, Device.Traveler.Id);

            fee = list.Find(i => i.DeviceId == Device.Traveler2.Id);
            LoadTabPage(fee, Device.Traveler2.Id);

            fee = list.Find(i => i.DeviceId == Device.Tracker.Id);
            LoadTabPage(fee, Device.Tracker.Id);

            fee = list.Find(i => i.DeviceId == Device.Explorer.Id);
            LoadTabPage(fee, Device.Explorer.Id);

            fee = list.Find(i => i.DeviceId == Device.Tablet.Id);
            LoadTabPage(fee, Device.Tablet.Id);
            //END RALLY TA 7728

            // US3339 Adding support for fees that that are not tied to 
            //  a device type
            fee = list.Find(i => i.DeviceId == 0);
            LoadTabPage(fee, 0);
        }

        internal int GetDeviceIndex(int deviceId)
        {
            int deviceIndex = 0;
            
            switch (deviceId)
            {
                case (3):
                    deviceIndex = 0;
                    break;
                case (1):
                    deviceIndex = 1;
                    break;
                case (14):
                    deviceIndex = 2;
                    break;
                case (2):
                    deviceIndex = 3;
                    break;
                case (4):
                    deviceIndex = 4;
                    break;
                case (17):
                    deviceIndex = 5;
                    break;
                
                // US3339
                case (0):
                    deviceIndex = 6;
                    break;
            }
            return deviceIndex;
        }

        internal void LoadTabPage(DistributorFee fee,int deviceId)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            m_InventoryEventFlag = false;

            // US3339
            if (deviceIndex != 6)
            {
                //clear out the previous data
                m_errorValidator.SetError(m_textBoxStartValueList[deviceIndex], string.Empty);
                m_gtiListViewItemsList[deviceIndex].Items.Clear();
                m_radioInventoryList[deviceIndex].Checked = false;
                m_radioPerUseList[deviceIndex].Checked = false;
                SetPerUseEnabled(deviceId, false);
                SetInventoryEnabled(deviceId, false);
                ClearAllData(deviceId);
                m_buttonRemoveTierButtonList[deviceIndex].Enabled = false;
                m_buttonAddTierButtonList[deviceIndex].Enabled = false;
            }
            
            //fee exists
            if(fee != null )
            {   
                //inventory type
                if(fee.DeviceFeeTypeId == 2 ||
                   fee.DeviceFeeTypeId == 3 ||
                   fee.DeviceFeeTypeId == 4)
                {
                    SetInventoryEnabled(deviceId, true);
                    SetPerUseEnabled(deviceId, false);
                    m_buttonRemoveTierButtonList[deviceIndex].Enabled = false;
                    //set the inventory checkbox
                    m_radioInventoryList[deviceIndex].Checked = true;
                    
                    //last item of the fee list
                    int lastItemIndex = fee.DistributorFeeData.Count - 1;
                    
                    //set the inventory fee text
                    if (lastItemIndex >= 0)
                    {    m_textBoxFeeInventoryList[deviceIndex].Text =
                            fee.DistributorFeeData[lastItemIndex].DistributorFee.ToString("F2");
                    }
                  
                    //set the inventory fee frequency
                    switch(fee.DeviceFeeTypeId)
                    {
                        //monthly
                        case(2):
                            m_comboBoxFrequencyList[deviceIndex].SelectedIndex = 0;    
                            break;

                        //daily
                        case (4):
                            m_comboBoxFrequencyList[deviceIndex].SelectedIndex = 1;
                            break;

                        //weekly
                        case(3):
                            m_comboBoxFrequencyList[deviceIndex].SelectedIndex = 2;    
                            break;


                    }
                }
                // US3339 CBB Electronic / CBB Paper 
                else if (deviceId == 0)
                {
                    // Find the CBB Electronic fee
                    DistributorFeeDataItem item = fee.DistributorFeeData.Find(i => i.FeeType == 5);
                    if(item != null)
                        txtbxElectronicFees.Text = item.DistributorFee.ToString("F2");

                    // Find the CBB Paper
                    item = fee.DistributorFeeData.Find(i => i.FeeType == 6);
                    if (item != null)
                        txtbxPaperFees.Text = item.DistributorFee.ToString("F2");
                        
                }
                //Per Use Type
                else
                {
                    m_radioPerUseList[deviceIndex].Checked = true;
                    ListViewItem lbItem = null;
                    SetInventoryEnabled(deviceId,false);
                    SetPerUseEnabled(deviceId,true);
                    int i = 1;
                    foreach (DistributorFeeDataItem item in fee.DistributorFeeData)
                    {
                        
                        lbItem = new ListViewItem(new string[] {i.ToString(),
                            item.MinRange.ToString(),item.MaxRange.ToString(),
                            item.DistributorFee.ToString("F2")});
                        lbItem.Tag = deviceId.ToString();
                        m_gtiListViewItemsList[deviceIndex].Items.Add(lbItem);
                        
                        if(i==1)
                        {
                            m_buttonRemoveTierButtonList[deviceIndex].Enabled = true;
                            lbItem.Selected = true;
                           
                        }

                        i++;
                    }

                    if(i==2)
                    {
                        //only one item so disable the start value box
                    
                        m_textBoxStartValueList[deviceIndex].Enabled = false;
                        m_labelStartValuePerUseList[deviceIndex].Enabled = false;
                    }
                    
                    if(i>=2)
                    {
                        //one item or more so enable the add tier button
                        m_buttonAddTierButtonList[deviceIndex].Enabled = true;
                    }
                }
            }
            m_InventoryEventFlag = true;
        }
          
        private int GetCurrentTierCount(int deviceId)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            int tierCount = m_gtiListViewItemsList[deviceIndex].Items.Count;
            return tierCount;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            //get the current tier count and add one
            int deviceId = GetDeviceType();
            
            int tierCount = GetCurrentTierCount(deviceId) + 1;

            int deviceIndex = GetDeviceIndex(deviceId);

            int previousStartValue = m_distributorFeesPresenter.GetPreviousStartValue(deviceId, tierCount );
            
            previousStartValue++;
            
            //tier level, start, end, fee
            ListViewItem item = new ListViewItem(new string[] {tierCount.ToString(), previousStartValue.ToString(),"9999","0.00"});
            m_selectedListViewItem = item;
            DistributorFeeDataItem fee = new DistributorFeeDataItem();
            
            fee.DistributorFeeId = 0;
            fee.DistributorFee = 0;
            fee.MaxRange = 9999;
            fee.MinRange = previousStartValue;

            m_gtiListViewItemsList[deviceIndex].Items.Add(item);
            
            m_textBoxStartValueList[deviceIndex].Enabled = true;
            m_labelStartValuePerUseList[deviceIndex].Enabled = true;
            
            //add it to the list
            m_distributorFeesPresenter.AddDistributorFees(fee,deviceId,1);
            
            item.Tag = deviceId.ToString();
            item.Selected = true;
            IsModifiedBool = true;
        }

        private int GetDeviceType()
        {
            int deviceType;
            bool result = int.TryParse(m_tabControl.SelectedTab.Tag.ToString(), out deviceType);
            if (result == false)
                return 0;
            else
            {
                return deviceType;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDistributorFeesSettings(GetDeviceType());
            m_currentDistributorFeeDataItem = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int deviceId = GetDeviceType();
            bool result = true;
            if (e.KeyChar == (char)Keys.Back)
            {
                result = false;
                
            }
            if(result)
            {
                result = !char.IsDigit(e.KeyChar);
            }
            
            e.Handled = result;
        }

        /// <summary>
        /// Validates a Money Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            if (Validator.ValidateDecimal(textBox.Text))
            {
                m_errorValidator.SetError(textBox, string.Empty);
            }
            else
            {
                e.Cancel = true;
                m_errorValidator.SetError(textBox, Resources.ErrorMoney);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void PercentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            int deviceId = m_previouslySelectedTabDeviceId;
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

            if (result == false)
            {
                m_bModified = true;
                m_currentDistributorFeeDataItem = GetCurrentDataItem(deviceId);
            }

            e.Handled = result;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SetEnabledAddTierButtons(false);
            m_distributorFeesPresenter.Reset();
            IsModifiedBool = false;
            m_currentDistributorFeeDataItem = null;
        }

        private void SetEnabledAddTierButtons(bool enabled)
        {
            foreach(Button button in m_buttonAddTierButtonList)
            {
                button.Enabled = enabled;
            }
        }

        private void ClearAllData(int deviceID)
        {
            int deviceIndex = GetDeviceIndex(deviceID);
            m_textBoxFeeInventoryList[deviceIndex].Text = "";
            m_textBoxFeePerUseList[deviceIndex].Text = "";
            m_textBoxStartValueList[deviceIndex].Text = "";
            m_comboBoxFrequencyList[deviceIndex].SelectedIndex = -1;
            m_gtiListViewItemsList[deviceIndex].Items.Clear();
        }

        private void m_StartNumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            

            if (Validator.ValidateInt(textBox.Text))
            {
                m_errorValidator.SetError(textBox, string.Empty);
               
            }

            else
            {
                e.Cancel = true;
                m_errorValidator.SetError(textBox, Resources.ErrorNumber);
                return;
            }

        }

        private void m_rdoInventory_Click(object sender, EventArgs e)
        {
            if (m_InventoryEventFlag)
            {
                //get the current device ID
                int deviceId = GetDeviceType();

                //get the current device Index
                int deviceIndex = GetDeviceIndex(deviceId);

                //set per use to disabled including list
                SetPerUseEnabled(deviceId, false);

                //set remove button to disabled
                m_buttonRemoveTierButtonList[deviceIndex].Enabled = false;

                //disable the current inventory button
                m_radioPerUseList[deviceIndex].Checked = false;

                //set inventory to enabled
                SetInventoryEnabled(deviceId, true);

                //clear previous data
                ClearAllData(deviceId);

                //remove all fees for this device
                m_distributorFeesPresenter.ClearFees(deviceId);

                //set add tier button to disabled
                m_buttonAddTierButtonList[deviceIndex].Enabled = false;

                //set frequency to daily
                m_comboBoxFrequencyList[deviceIndex].SelectedIndex = 1;

                //either get a new distributor fee or the last one
                DistributorFeeDataItem fee = GetLastDistributorFee(deviceId);

                //set currently selected fee to this value
                m_currentDistributorFeeDataItem = fee;

                //set current fee to current value
                m_textBoxFeeInventoryList[deviceIndex].Text = fee.DistributorFee.ToString("F2");

                //either add a new record or update the current one
                m_distributorFeesPresenter.UpdateDistributorFee(fee, deviceId, 2, 0);

                //go into save mode
                m_bModified = true;
            }
        }

        private DistributorFeeDataItem GetLastDistributorFee(int deviceId)
        {
            return m_distributorFeesPresenter.GetLastDistributorFee(deviceId);
        }
        
        private DistributorFeeDataItem GetFirstDistributorFee(int deviceId)
        {
            return m_distributorFeesPresenter.GetFirstDistributorFee(deviceId);
        }

        private void SetPerUseEnabled(int deviceId, bool enabled)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            
            //set per use fee area
            m_textBoxFeePerUseList[deviceIndex].Enabled = enabled;

            //set per use start text box
            m_textBoxStartValueList[deviceIndex].Enabled = enabled;

            //set lists to enabled/disabled
            m_gtiListViewItemsList[deviceIndex].Enabled = enabled;

            //set currency to enabled/disabled
            m_labelCurrencyPerUseList[deviceIndex].Enabled = enabled;

            //set fee label to enabled/disabled
            m_labelFeePerUseList[deviceIndex].Enabled = enabled;

            //set Start Value to enabled/disabled
            m_labelStartValuePerUseList[deviceIndex].Enabled = enabled;
            
            //set the button to enabled
            m_buttonAddTierButtonList[deviceIndex].Enabled = enabled;
        }

        private void m_rdoPerUse_Click(object sender, EventArgs e)
        {
            
            //get the current device ID
            int deviceId = GetDeviceType();

            //get the current device Index
            int deviceIndex = GetDeviceIndex(deviceId);

            //set per use to enabled including list
            SetPerUseEnabled(deviceId, true);

            //clear all previous data
            ClearAllData(deviceId);

            //remove all fees for this device
            m_distributorFeesPresenter.ClearFees(deviceId);

            //set inventory to disabled
            SetInventoryEnabled(deviceId, false);

            //set inventory checkbox to disabled RALLY DE 3190
            m_radioInventoryList[deviceIndex].Checked = false;

            //set remove button to enabled
            m_buttonRemoveTierButtonList[deviceIndex].Enabled = true;

            //either get a new distributor fee or the first one
            DistributorFeeDataItem fee = GetFirstDistributorFee(deviceId);
            
            //check to see if the fee is new or not 
            if(fee.MinRange == 0)
            {
                fee.MinRange = 1;
                fee.MaxRange = 9999;
                fee.DistributorFee = 0;
            }

            //add a new entry to the gti list
            ListViewItem item = new ListViewItem(new string[]
                                                              {
                                                                  "1", fee.MinRange.ToString(), fee.MaxRange.ToString(),
                                                                  fee.DistributorFee.ToString("F2")
                                                              });
            //set the tag on the item
            item.Tag = deviceId.ToString();

            //add the item to the appropriate list
            m_gtiListViewItemsList[deviceIndex].Items.Add(item);
            
            //set current fee to current fee value
            m_textBoxFeePerUseList[deviceIndex].Text = fee.DistributorFee.ToString("F2");
    
            //set currently selected fee to this value
            m_currentDistributorFeeDataItem = fee;

            //set the first start value and disable the start value text box
            m_textBoxStartValueList[deviceIndex].Enabled = false;
            m_textBoxStartValueList[deviceIndex].Text = "1";
            m_labelStartValuePerUseList[deviceIndex].Enabled = false;

            //either add a new record or update the current one
            m_distributorFeesPresenter.UpdateDistributorFee(fee, deviceId, 1, 1);

            //select the current item
            item.Selected = true;

            //go into save mode
            m_bModified = true;
        }

        private DistributorFeeDataItem GetCurrentDataItem(int deviceId, int type = 0)
        {
            int deviceIndex = GetDeviceIndex(deviceId);

            DistributorFeeDataItem item = null;

            if (deviceIndex == 6)//for cbb distributor fee
            {
//                decimal fee;

                item = m_distributorFeesPresenter.GetLastDistributorFee(deviceId);

                //if (decimal.TryParse(m_textBoxFeeInventoryList[deviceIndex].Text, out fee))
                //{
                //    item.DistributorFee = fee;
                //}
            }
            //check to see if it is inventory or per use or neither
            else if(m_radioInventoryList[deviceIndex].Checked)
            {
                
                decimal fee;

                item = m_distributorFeesPresenter.GetLastDistributorFee(deviceId);

                if(decimal.TryParse(m_textBoxFeeInventoryList[deviceIndex].Text,out fee))
                {
                    item.DistributorFee = fee;
                }
                
            }
            else if(m_radioPerUseList[deviceIndex].Checked)
            {
               
                decimal fee;
                int startValue;
                //item = m_distributorFeesPresenter.GetFirstDistributorFee(deviceId);
                int tierId = GetCurrentTierId(deviceId);
                
                //this means that it is in transient mode
                if (tierId == 0)
                {
                    tierId = m_previouslySelectedTierId;
                }

                //if the fee is not added to the model it will be here
                item = m_distributorFeesPresenter.GetSelectedDistributorFee(deviceId, tierId);
                
                if(decimal.TryParse(m_textBoxFeePerUseList[deviceIndex].Text,out fee))
                {
                    item.DistributorFee = fee;
                }

                if (int.TryParse(m_textBoxStartValueList[deviceIndex].Text, out startValue))
                {
                    item.MinRange = startValue;
                }
            }
            
            return item;
        }

        private int GetCurrentTierId(int deviceId)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            GTIListView listView = m_gtiListViewItemsList[deviceIndex];
            if (listView.SelectedItems.Count > 0)
            {
                return Convert.ToInt32(listView.SelectedItems[0].SubItems[0].Text);
            }
            else
                return 0;
        }

        private int GetCurrentEndID(int deviceId)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            GTIListView listView = m_gtiListViewItemsList[deviceIndex];
            if (listView.SelectedItems.Count > 0)
            {
                return Convert.ToInt32(listView.SelectedItems[0].SubItems[2].Text);
            }
            else
                return 0;
        }

        private void SetInventoryEnabled(int deviceId, bool enabled)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            m_textBoxFeeInventoryList[deviceIndex].Enabled = enabled;
            m_comboBoxFrequencyList[deviceIndex].Enabled = enabled;
            m_labelCurrencyInventoryList[deviceIndex].Enabled = enabled;
            m_labelFeeInventoryList[deviceIndex].Enabled = enabled;
            m_labelFrequencyInventoryList[deviceIndex].Enabled = enabled;
           
        }

        private void m_tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ////clear the textbox of cbb US3339 TA12821
            //if (Common.CBBEnabled == true)
            //{
            //    txtbxPaperFees.Text = "";
            //    txtbxElectronicFees.Text = "";
            //}


            //1. check to see if form is dirty
            if (m_bModified == true)
            {
                DialogResult result =

                    MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader,
                                     MessageFormTypes.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    bool SaveResult = SaveDistributorFeesSettings(m_previouslySelectedTabDeviceId);
                    if (SaveResult)
                    {
                        m_bModified = false;
                        m_previouslySelectedTabDeviceId = GetDeviceType();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

                else if (result == DialogResult.No)
                {
                    m_distributorFeesPresenter.Reset();
                    IsModifiedBool = false;
                    m_currentDistributorFeeDataItem = null;
                }

                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            m_previouslySelectedTabDeviceId = GetDeviceType();
        }

        private void m_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_currentDistributorFeeDataItem = null;
        }

        private void m_cboFrequency_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            int deviceId = GetDeviceType();
            m_currentDistributorFeeDataItem = GetCurrentDataItem(deviceId);
            if (comboBox.SelectedIndex == 0)
            {
                m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 2, 0);
            }
            else if (comboBox.SelectedIndex == 1)
            {
                m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 4, 0);
            }
            else if (comboBox.SelectedIndex == 2)
            {
                m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 3, 0);
            }
            m_bModified = true;
        }

        private void m_gtiListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GTIListView listView = sender as GTIListView;
            
            if (listView.SelectedItems.Count > 0)
            {
                int deviceId = Convert.ToInt32(listView.SelectedItems[0].Tag);
                int deviceIndex = GetDeviceIndex(deviceId);
                
                //only update the display stuff
                if (m_radioPerUseList[deviceIndex].Checked && listView.SelectedItems.Count > 0)
                {
                    m_textBoxFeePerUseList[deviceIndex].Text = listView.SelectedItems[0].SubItems[3].Text;
                    m_textBoxStartValueList[deviceIndex].Text = listView.SelectedItems[0].SubItems[1].Text;
                    m_previouslySelectedTierId = GetCurrentTierId(deviceId);
                    m_buttonRemoveTierButtonList[deviceIndex].Enabled = true;

                    //if it is the first tier level disable the start value
                    int tierLevel = Convert.ToInt32(listView.SelectedItems[0].SubItems[0].Text);
                    m_textBoxFeePerUseList[deviceIndex].Enabled = true;
                    m_labelFeePerUseList[deviceIndex].Enabled = true;
                    if(tierLevel == 1)
                    {
                        m_textBoxStartValueList[deviceIndex].Enabled = false;
                        m_labelStartValuePerUseList[deviceIndex].Enabled = false;
                        
                    }

                    else if(tierLevel > 1)
                    {
                        m_textBoxStartValueList[deviceIndex].Enabled = true;
                        m_labelStartValuePerUseList[deviceIndex].Enabled = true;
                    }
                }
            }

            //deselect the current item
            else
            {
                int deviceId = GetDeviceType();
                int deviceIndex = GetDeviceIndex(deviceId);
                DistributorFeeDataItem item = GetCurrentDataItem(deviceId);
                m_distributorFeesPresenter.UpdateDistributorFee(item, deviceId, 1, m_previouslySelectedTierId);
                m_textBoxStartValueList[deviceIndex].Text = "";
                m_textBoxStartValueList[deviceIndex].Enabled = false;
                m_labelStartValuePerUseList[deviceIndex].Enabled = false;
                m_textBoxFeePerUseList[deviceIndex].Text = "";
                m_textBoxFeePerUseList[deviceIndex].Enabled = false;
                m_labelFeePerUseList[deviceIndex].Enabled = false;
                m_buttonRemoveTierButtonList[deviceIndex].Enabled = false;
            }
            
        }

        public void UpdateViewDistributorFee(DistributorFee fee, int deviceId, int feeType)
        {
            int deviceIndex = GetDeviceIndex(deviceId);
            GTIListView listView = new GTIListView();

            if (deviceIndex != 6)
            {
                listView = m_gtiListViewItemsList[deviceIndex];
            }

            if(feeType == 1 )
            {
                for(int i=0;i<listView.Items.Count;i++)
                {
                    listView.Items[i].SubItems[1].Text = fee.DistributorFeeData[i].MinRange.ToString();
                    listView.Items[i].SubItems[2].Text = fee.DistributorFeeData[i].MaxRange.ToString();
                    listView.Items[i].SubItems[3].Text = fee.DistributorFeeData[i].DistributorFee.ToString("F2");
                }
            }
        }

        private void m_TextStartPerUse_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int deviceId = GetDeviceType();
            int deviceIndex = GetDeviceIndex(deviceId);
            int tierLevel = GetCurrentTierId(deviceId);

            if (textBox != null)
            {
                int startValue;
                if (Int32.TryParse(textBox.Text, out startValue))
                {
                    int previousStartValue = m_distributorFeesPresenter.GetPreviousStartValue(deviceId, tierLevel);
                    if (startValue <= previousStartValue)
                    {
                        m_errorValidator.SetError(textBox, Resources.ErrorLessThanPreviousStartValue);
                        m_gtiListViewItemsList[deviceIndex].Enabled = false;
                    }
                    else
                    {
                        m_errorValidator.SetError(textBox, string.Empty);
                        m_gtiListViewItemsList[deviceIndex].Enabled = true;
                    }
                }
            }
            //run validation?
            m_currentDistributorFeeDataItem = GetCurrentDataItem(deviceId);
            m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem,deviceId,1,tierLevel);

            if(tierLevel > 0)
            {
                GTIListView listView = m_gtiListViewItemsList[deviceIndex];
                listView.Items[tierLevel - 1].SubItems[1].Text = m_textBoxStartValueList[deviceIndex].Text;
            }
            
        }

        private void m_textFeePerUse_KeyUp(object sender, KeyEventArgs e)
        {
            int deviceId = GetDeviceType();
            int deviceIndex = GetDeviceIndex(deviceId);
            int tierLevel = GetCurrentTierId(deviceId);

            //run validation?
            m_currentDistributorFeeDataItem = GetCurrentDataItem(deviceId);
            m_distributorFeesPresenter.UpdateDistributorFee(m_currentDistributorFeeDataItem, deviceId, 1, tierLevel);

            if (tierLevel > 0)
            {
                GTIListView listView = m_gtiListViewItemsList[deviceIndex];
                listView.Items[tierLevel - 1].SubItems[3].Text = m_textBoxFeePerUseList[deviceIndex].Text;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int deviceId = GetDeviceType();
            int tierId = GetCurrentTierId(deviceId);
            m_distributorFeesPresenter.RemoveTier(deviceId, tierId);
        }

        private void m_tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(m_tabControl.TabPages[e.Index].Text, m_tabControl.Font, System.Drawing.Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

        private void m_FixedBaseTabPage_Click(object sender, EventArgs e)
        {

        }
    }
}
