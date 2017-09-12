using System;
using System.Reflection;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class MainForm : GradientForm
	{
		// The active control
		SettingsControl m_activeControl = null;
		SettingsControl m_previousControl = null;
		bool m_bResetPreviousControl = false;
	    private int m_currentOperator = 0;
      
		public MainForm()
		{
            
			// Initialize the common module data for the current operator
            if (!Common.InitModuleData(0))
            {
                Application.ExitThread();
            }
            
		    m_currentOperator = -1; //FIX RALLY DE 3581 changing setting page after edit crashed
            InitializeComponent();
            kioskAdvanced2.SetKoiskSettings2Controller(this.GetCurrentOperator, this.SetCurrentOperator);
            licenseFileSettings1.SetLicenseFileSettingsController();

            m_devices = GetDeviceList();

            //if it is the admin
            if(Common.IsAdmin)
            {
                LoadComboBox();
            }
            else
            {

                comboBox1.Visible = false;
                label1.Text = String.Format("Current Operator: {0}",
                                            Common.OperatorName);
                m_currentOperator = Common.OperatorId;
                LoadSettings();
            }

    
		}

        //

        private Device[] m_devices;
        private Device[] GetDeviceList()
        {
            // Get device types
            GetDeviceTypeDataMessage msg = new GetDeviceTypeDataMessage();//knc_1
            try
            {
                msg.Send();
            }
            catch (Exception ex)
            {
                MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, ex.Message));
         //       return false;
            }

            // Check return code
            if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            {
                MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));

           //     return false;
            }

            var x = msg.Devices;
            return  x;
        }

        internal void LoadComboBox()
        {
            //populate the combo box with the operators
            operatorManagement1.LoadSettings();
            
            comboBox1.Items.Clear();
            foreach(ListViewItem item in operatorManagement1.gtiListView1.Items)
            {
                int operatorId; 
                Int32.TryParse(item.SubItems[1].Text, out operatorId);
                string comboBoxItem = string.Format("{1} - {0}", item.Text, operatorId.ToString());
                int index = comboBox1.Items.Add(comboBoxItem); 
                if(Common.OperatorId == operatorId)
                {
                    comboBox1.SelectedIndex = index;
                    CreateNodes();
                }
            }

            //select the current operator
            //display name of operator
            //load the settings for that operator
        }

        internal void LoadSettings()
        {
            //START RALLY DE9656 
            // Initialize the settings controls
            SuspendLayout();
            companySettings1.LoadSettings();  // Company settings must be initialized before 'Location' and 'Operator' or any other control in which the company address is used            
            companySettings1.Hide();
            companySettings1.Enabled = false;

            locationSettings1.LoadSettings();
            locationSettings1.Hide();
            locationSettings1.Enabled = false;

            charitySettings.LoadSettings();
            charitySettings.Hide();
            charitySettings.Enabled = false;

            unitMgmtSettings1.m_devices = m_devices;
            unitMgmtSettings1.LoadSettings();//knc
            unitMgmtSettings1.Hide();
            unitMgmtSettings1.Enabled = false;

            hallDisplaySettings1.LoadSettings();
            hallDisplaySettings1.Hide();
            hallDisplaySettings1.Enabled = false;

            callerSettings1.LoadSettings();
            callerSettings1.Hide();
            callerSettings1.Enabled = false;

            blowerSettings.LoadSettings();
            blowerSettings.Hide();
            blowerSettings.Enabled = false;

            posSettings1.LoadSettings();
            posSettings1.Hide();
            posSettings1.Enabled = false;

            kioskSettings1.LoadSettings();
            kioskSettings1.Hide();
            kioskSettings1.Enabled = false;

            //kioskSettings2            
            kioskAdvanced2.LoadSettings();
            kioskAdvanced2.Hide();
            kioskAdvanced2.Enabled = false;

            crateModuleSettings1.LoadSettings();
            crateModuleSettings1.Hide();
            crateModuleSettings1.Enabled = false;

            bingoSettings1.LoadSettings();
            bingoSettings1.Hide();
            bingoSettings1.Enabled = false;

            receiptSettings1.LoadSettings();
            receiptSettings1.Hide();
            receiptSettings1.Enabled = false;

            magCardSettings1.LoadSettings();
            magCardSettings1.Hide();
            magCardSettings1.Enabled = false;

            currencySettings1.LoadSettings();
            currencySettings1.Hide();
            currencySettings1.Enabled = false;

            machineSettings1.LoadSettings();
            machineSettings1.Hide();
            machineSettings1.Enabled = false;

            globalSettings1.LoadSettings();
            globalSettings1.Hide();
            globalSettings1.Enabled = false;

            creditSettings1.LoadSettings();
            creditSettings1.Hide();
            creditSettings1.Enabled = false;

            videoSettings1.LoadSettings();
            videoSettings1.Hide();
            videoSettings1.Enabled = false;

            raffleSettings1.LoadSettings();
            raffleSettings1.Hide();
            raffleSettings1.Enabled = false;

            audioSettings1.LoadSettings();
            audioSettings1.Hide();
            audioSettings1.Enabled = false;

            playModeSettings1.LoadSettings();
            playModeSettings1.Hide();
            playModeSettings1.Enabled = false;

            motifSettings1.LoadSettings();
            motifSettings1.Hide();
            motifSettings1.Enabled = false;
            
            adminSettings1.LoadSettings();
            adminSettings1.Hide();
            adminSettings1.Enabled = false;

            playerSettings1.LoadSettings();
            playerSettings1.Hide();
            playerSettings1.Enabled = false;

            operatorManagement1.LoadSettings();
            operatorManagement1.Hide();
            operatorManagement1.Enabled = false;
            operatorManagement1.SetForm(this);

            operatorSettings1.LoadSettings();
            operatorSettings1.Hide();
            operatorSettings1.Enabled = false;
            
            distributorFeesSettings1.LoadSettings();
            distributorFeesSettings1.Hide();
            distributorFeesSettings1.Enabled = false;
            
            inventorySettings1.LoadSettings();
            inventorySettings1.Hide();
            inventorySettings1.Enabled = false;


            //licenseFileSettings            
            licenseFileSettings1.LoadSettings();
            licenseFileSettings1.Hide();
            licenseFileSettings1.Enabled = false;


            moneyCenterSettings1.SetForm(this); // Rally DE8593: System Settings->Cash Method->Money Center
            moneyCenterSettings1.LoadSettings();
            moneyCenterSettings1.Hide();
            moneyCenterSettings1.Enabled = false;
            
            securitySettings1.LoadSettings();
            securitySettings1.Hide();
            securitySettings1.Enabled = false;

            thirdPartyInterfaceSettings1.LoadSettings();
            thirdPartyInterfaceSettings1.Hide();
            thirdPartyInterfaceSettings1.Enabled = false;

            //validationSettings1.LoadSettings();
            //validationSettings1.Hide();
           //validationSettings1.Enabled = false;

            //US4096
            channelSettings1.LoadSettings();
            channelSettings1.Hide();
            channelSettings1.Enabled = false;

            tenderSettings.LoadSettings();
            tenderSettings.Hide();
            tenderSettings.Enabled = false;

            paymentProcessingSettings.LoadSettings();
            paymentProcessingSettings.Hide();
            paymentProcessingSettings.Enabled = false;
            
            sessionSummarySettings1.LoadSettings();
            sessionSummarySettings1.Hide();
            sessionSummarySettings1.Enabled = false;

            //US5103: System Settings: Move CBB settings
            crystalBallSettings.LoadSettings();
            crystalBallSettings.Hide();
            crystalBallSettings.Enabled = false;

            //US5104: System Settings: Move Printer settings
            pointOfSalePrinterSettings.LoadSettings();
            pointOfSalePrinterSettings.Hide();
            pointOfSalePrinterSettings.Enabled = false;

            kioskSalesSettings1.LoadSettings();
            kioskSalesSettings1.Hide();
            kioskSalesSettings1.Enabled = false;

            //END RALLY DE9656

            CreateNodes();

            ResumeLayout();
        }

		// Restore and activate the window
		internal void SetWindowNormal()
		{
			this.WindowState = FormWindowState.Normal;
			this.Activate();
		}

		internal void BringToFront(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(this.SetWindowNormal));
			}
			else
			{
				this.SetWindowNormal();
			}
		}

		public void CloseModule(object sender, EventArgs e)
		{
			this.Close();
		}

        public OperatorManagement getOperatorManagement()
        {
            return operatorManagement1;
        }

		// Private Routines
		#region Private Routines
		private void CreateNodes()
		{
		    TreeNode nodeParent;
		    TreeNode nodeChild;

            object selectedNode = (treeView1.SelectedNode != null ? treeView1.SelectedNode.Tag : null);
            if (selectedNode == null)
            {
                if (Common.IsAdmin)
                    selectedNode = operatorManagement1;
                else
                    selectedNode = operatorSettings1;
            }

            treeView1.Nodes.Clear();

            //START RALLY DE9656
            if (Common.IsAdmin)
            {
                //// Administrative Settings
                nodeParent = new TreeNode("Administrative Settings", 0, 1);
                nodeParent.Tag = adminSettings1;
                treeView1.Nodes.Add(nodeParent);
            }

            //// Bingo Settings
            nodeParent = new TreeNode("Bingo Settings", 0, 1);
            nodeParent.Tag = bingoSettings1;
            treeView1.Nodes.Add(nodeParent);

            //// Caller
            //if (Common.GetDeviceCount(Device.Caller) > 0)
           // {
                nodeParent = new TreeNode("Caller", 0, 1);
                nodeParent.Tag = callerSettings1;
            //}

            //US5335
            if (Common.IsAdmin)
            {
                nodeChild = nodeParent.Nodes.Add("Blower Settings");
                nodeChild.Tag = blowerSettings;
            }
            treeView1.Nodes.Add(nodeParent);

            //TA11876 Adding support for Charities
            nodeParent = new TreeNode("Charities", 0, 1);
            nodeParent.Tag = charitySettings; 
            treeView1.Nodes.Add(nodeParent);
            //end TA11876

            nodeParent = new TreeNode("Configured Photos", 0, 1);
            nodeParent.Tag = kioskAdvanced2;
            treeView1.Nodes.Add(nodeParent);

            //// Credit Settings
            if (Common.IsCreditEnabled)
            {
                nodeParent = new TreeNode("Credit Settings", 0, 1);
                nodeParent.Tag = creditSettings1;
                treeView1.Nodes.Add(nodeParent);
            }

            //Distributor Fees Settings
            nodeParent = new TreeNode("Distributor Fees");
            nodeParent.Tag = distributorFeesSettings1;
            treeView1.Nodes.Add(nodeParent);
           
            // This next node is for GAMETECH techs only
            //As of US4625, only certain settings are tech only
            // Global Settings
            nodeParent = new TreeNode("Global Settings", 0, 1);
            nodeParent.Tag = globalSettings1;
            treeView1.Nodes.Add(nodeParent);

            //Inventory Settings
            nodeParent = new TreeNode("Inventory Settings");
            nodeParent.Tag = inventorySettings1;
            treeView1.Nodes.Add(nodeParent);

            // Kiosk
            if (Common.GetDeviceCount(Device.Kiosk) > 0)
            {
                nodeParent = new TreeNode("Kiosk", 0, 1);
                nodeParent.Tag = kioskSettings1;
                treeView1.Nodes.Add(nodeParent);
            }


            if (Common.GetDeviceCount(Device.AdvancedPOSKiosk) > 0 ||
                Common.GetDeviceCount(Device.BuyAgainKiosk) > 0 ||
                Common.GetDeviceCount(Device.SimplePOSKiosk) > 0 ||
                Common.GetDeviceCount(Device.HybridKiosk) > 0
               )
          {
                nodeParent = new TreeNode("POS Kiosk", 0, 1);
                nodeParent.Tag = kioskSalesSettings1;
                treeView1.Nodes.Add(nodeParent);
          }
    

            //License File Settings
            nodeParent = new TreeNode("License File Settings", 0, 1);
            nodeParent.Tag = licenseFileSettings1;
            treeView1.Nodes.Add(nodeParent);
            
            // Locations
            nodeParent = new TreeNode("Locations", 0, 1);
            nodeParent.Tag = locationSettings1;
            treeView1.Nodes.Add(nodeParent);

            // Machine Settings
            nodeParent = new TreeNode("Machine Settings", 0, 1);
            nodeParent.Tag = machineSettings1;
            treeView1.Nodes.Add(nodeParent);

            // Mag Card Settings
            nodeParent = new TreeNode("Magnetic Card", 0, 1);
            nodeParent.Tag = magCardSettings1;
            treeView1.Nodes.Add(nodeParent);

            //RALLY DE 6756 Money center settings
            if (CheckMoneyCenterPermission())
            {
                nodeParent = new TreeNode("Money Center");
                nodeParent.Tag = moneyCenterSettings1;
                treeView1.Nodes.Add(nodeParent);
                //END RALLY DE 6756
            }

            if (Common.IsAdmin)
            {
                nodeParent = new TreeNode("Operator Management", 0, 1);
                nodeParent.Tag = operatorManagement1;
                //treeView1.SelectedNode = nodeParent;
                treeView1.Nodes.Add(nodeParent);
            }
            else
            {
                nodeParent = new TreeNode("Operator Settings", 0, 1);
                nodeParent.Tag = operatorSettings1;
                //treeView1.SelectedNode = nodeParent;
                treeView1.Nodes.Add(nodeParent);
            }

            //Player Unit Settings
            // Rally DE 2390 = Player Settings Settings Simplification 
            nodeParent = new TreeNode("Player Device Settings", 0, 1);
            nodeParent.Tag = playerDeviceSettings1;
            treeView1.Nodes.Add(nodeParent);

            //Player Unit Settings
            // Rally DE 2390 = Player Settings Settings Simplification 
            nodeParent = new TreeNode("Player Unit Settings", 0, 1);
            nodeParent.Tag = playerSettings1;

            // Rally DE 2390 = Player Settings Settings Simplification 
            nodeChild = nodeParent.Nodes.Add("Audio Settings");
            nodeChild.Tag = audioSettings1;

            // Rally DE 2390 = Player Settings Settings Simplification 
            nodeChild = nodeParent.Nodes.Add("Play Mode Settings");
            nodeChild.Tag = playModeSettings1;


            treeView1.Nodes.Add(nodeParent);

            // POS
            // TTP 50358
           if (Common.GetDeviceCount(Device.POS) + Common.GetDeviceCount(Device.POSPortable) +
                Common.GetDeviceCount(Device.POSManagement) > 0)
            {
                nodeParent = new TreeNode("Point of Sale", 0, 1);
                nodeParent.Tag = posSettings1;

                //US5103: System Settings: Move CBB settings
                nodeChild = nodeParent.Nodes.Add("Crystal Ball Bingo");
                nodeChild.Tag = crystalBallSettings;

                nodeChild = nodeParent.Nodes.Add("Payment Processing Settings");
                nodeChild.Tag = paymentProcessingSettings;

                //US5104: System Settings: Move Printer settings
                // Need to check for IT status for the precidia settings
                nodeChild = nodeParent.Nodes.Add("Printer");
                nodeChild.Tag = pointOfSalePrinterSettings;

                nodeChild = nodeParent.Nodes.Add("Tendering Settings");
                nodeChild.Tag = tenderSettings;

                treeView1.Nodes.Add(nodeParent);

                //nodeChild = nodeParent.Nodes.Add("Validation Settings");
                //nodeChild.Tag = validationSettings1;
            }
            
            //RALLY TA 8297 START Setting for enabling disabling raffle
            string licenseResult = Common.GetLicenseSettingValue(LicenseSetting.EnableRaffle);
            bool enableRaffle;
            bool result = Boolean.TryParse(licenseResult, out enableRaffle);

            if (result && enableRaffle)
            { ////// Raffle Settings
                nodeParent = new TreeNode("Raffle Settings", 0, 1);
                nodeParent.Tag = raffleSettings1;
                raffleSettings1.SetTreeNode(nodeParent);
                raffleSettings1.LoadSettings();
                treeView1.Nodes.Add(nodeParent);
            }
            //END RALLY TA 8927

            // Receipt Management
            nodeParent = new TreeNode("Receipt Management", 0, 1);
            nodeParent.Tag = receiptSettings1;
            treeView1.Nodes.Add(nodeParent);

          
            // Hall Display
            if (Common.GetDeviceCount(Device.RemoteDisplay) > 0)
            {
                nodeParent = new TreeNode("Remote Display", 0, 1);
                nodeParent.Tag = hallDisplaySettings1;
                treeView1.Nodes.Add(nodeParent);
            }

            //Security Settings
            nodeParent = new TreeNode("Security Settings", 0, 1);
            nodeParent.Tag = securitySettings1;
            treeView1.Nodes.Add(nodeParent);

            //Player tracking
            nodeParent = new TreeNode("Player Tracking", 0, 1);
            nodeParent.Tag = thirdPartyInterfaceSettings1;
            treeView1.Nodes.Add(nodeParent);

            // Unit Management
            
            nodeParent = new TreeNode("Unit Management", 0, 1);
            nodeParent.Tag = unitMgmtSettings1;
            if (Common.IsAdmin)
            {
                nodeChild = nodeParent.Nodes.Add("Crate Module");
                nodeChild.Tag = crateModuleSettings1;
                treeView1.Nodes.Add(nodeParent);
            }

            //DE12932: remove second instance of Validation Settings
            //Validation Settings
            //nodeParent = new TreeNode("Validation Settings", 0, 1);
            //nodeParent.Tag = validationSettings1;
            //treeView1.Nodes.Add(nodeParent);

            //// Video Settings
            if (Common.GetDeviceCount(Device.Kiosk) + Common.GetDeviceCount(Device.RemoteDisplay) > 0 )
            {
                nodeParent = new TreeNode("Video Settings", 0, 1);
                nodeParent.Tag = videoSettings1;
                treeView1.Nodes.Add(nodeParent);
            }
            //END RALLY DE9656

            //US4096
            //Channel settings
            nodeParent = new TreeNode("Channel Settings", 0, 1);
            nodeParent.Tag = channelSettings1;
            treeView1.Nodes.Add(nodeParent);


                        //US4846 Session Summary Settings
            //US4096
           //Channel settings
            nodeParent = new TreeNode("Session Summary", 0, 1);
            nodeParent.Tag = sessionSummarySettings1;
            treeView1.Nodes.Add(nodeParent);

            //SORT by alphabetical order
            treeView1.Sort();

 
            foreach (TreeNode tn in treeView1.Nodes)
            {

                if (tn.Text.IndexOf("Settings") != -1)           //Remove parent node  "Settings"
                {
                    tn.Text = tn.Text.Replace("Settings", "").Trim();
                    
                }


                if (tn.Nodes.Count != 0)  //Remove child node  "Settings"
                {
                    foreach (TreeNode childNode in tn.Nodes) 
                    {
                        if (childNode.Text.IndexOf("Settings") != -1)
                        {
                            childNode.Text = childNode.Text.Replace("Settings", "").Trim();
                        }
                    }
                }
            }


            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.Tag == selectedNode)
                {
                    treeView1.SelectedNode = tn;
                    break;
                }
                else
                {
                    if (tn.GetNodeCount(false) > 0)
                    {
                        foreach (TreeNode sn in tn.Nodes)
                        {
                            if (sn.Tag == selectedNode)
                            {
                                treeView1.SelectedNode = sn;
                                break;
                            }
                        }
                    }
                }
            }
		}

        //START RALLY DE 6756
        private bool CheckMoneyCenterPermission()
        {     
            //check the cash method id for the current operator
            //BingoOperator currentOperator = operatorManagement1.GetCurrentOperator(m_currentOperator);
            //if (currentOperator != null)
            //{
            //    if (currentOperator.OperatorCashMethodId == 3)
            //        return true;
            //}
            return true;
        }
        //END RALLY DE 6756

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)//knc
        {
            //START FIX RALLY DE2661 -- this needs to be done before the new control 
            //is displayed
            // Reset the previous control now that it is hidden to avoid a delayed response
            if (m_bResetPreviousControl)
            {
                m_activeControl.LoadSettings();
                m_bResetPreviousControl = false;
            }
            //END FIX RALLY DE2661

            if(m_activeControl != null)
            {
                m_activeControl.Enabled = false;
                m_activeControl.Hide();
                m_activeControl.Visible = false;
            }
			// Get the selected node and display its panel
			m_previousControl = m_activeControl;
			m_activeControl = (SettingsControl)(treeView1.SelectedNode.Tag);
			m_activeControl.OnActivate(treeView1.SelectedNode);
		    m_activeControl.Enabled = true;
            m_activeControl.Show();
		    m_activeControl.Visible = true;
            m_activeControl.BringToFront();
			m_activeControl.Update();
            treeView1.SelectedNode = e.Node;

            /* This code was used to force the first child node to be selected
             * when a parent node was clicked 
            if (e.Node.Nodes.Count < 1)
            {
                treeView1.SelectedNode = e.Node;
            }
            else
            {
                treeView1.SelectedNode = e.Node.Nodes[0];
            }
            */

            treeView1.Update();

			Application.DoEvents();
		}

		private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)//knc
		{
			// Prompt to save if modified
			if (m_activeControl != null)
			{
				if (m_activeControl.IsModified())
				{
					DialogResult result = MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
					this.Refresh();
					if (result == DialogResult.Yes)
					{
						// If save fails remain on current tab
						if (!m_activeControl.SaveSettings())
						{
							e.Cancel = true;
						}

					}
					else if (result == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
					else
					{
						// Flag it for reset if they do not save
						m_bResetPreviousControl = true;
					}
				}

                if (m_activeControl == posSettings1) //Flex tendering mode may have changed
                    tenderSettings.LoadSettings();

                if (m_activeControl == tenderSettings) //Tendering mode may have changed
                    posSettings1.LoadSettings();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Prompt to save if modified
			if (m_activeControl != null)
			{
				if (m_activeControl.IsModified())
				{
					DialogResult result = MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
					this.Refresh();
					if (result == DialogResult.Yes)
					{
						// If save fails remain on current tab
						if (!m_activeControl.SaveSettings())
						{
							e.Cancel = true;
						}
					}
					else if (result == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//about window
			AboutBox about = new AboutBox();
			//about.AssemblyCompany = AssemblyCompany;
			//about.AssemblyCopyright = AssemblyCopyright;
			about.AssemblyDescription = AssemblyDescription;
			about.AssemblyProduct = AssemblyProduct;
			about.AssemblyVersion = AssemblyVersion;
			about.AssemblyTitle = AssemblyTitle;
			about.ShowDialog();
		}

		#endregion // Private Routines

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0)
				{
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{

			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

	    public int CurrentOperator
	    {
	        get { return m_currentOperator; }
            set { m_currentOperator = value;}
	    }

	    public int GetCurrentOperator()
        {
	        return CurrentOperator;
        }

        public void SetCurrentOperator(int operatorId)
        {
            CurrentOperator = operatorId;
            //todo this is a bad bad call it means something broke handle it
        }

		#endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool changeOp = true;
            if (m_activeControl != null)
            {
                if (m_activeControl.IsModified())
                {
                    DialogResult result = MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
                    this.Refresh();
                    if (result == DialogResult.Yes)
                    {
                        // If save fails remain on current tab
                        if (!m_activeControl.SaveSettings())
                        {
                            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                            comboBox1.SelectedIndex = m_currentOperator - 1;
                            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                            changeOp = false;
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                        comboBox1.SelectedIndex = m_currentOperator - 1;
                        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                        m_bResetPreviousControl = true; // Flag it for reset if they do not save
                        changeOp = false;
                    }
                    else
                    {
                        // Flag it for reset if they do not save
                        m_bResetPreviousControl = true;
                    }
                }
            }

            if (changeOp == true)
            {
                string operatorID = comboBox1.SelectedItem as string;
                string[] operatorIDList = operatorID.Split();
                operatorID = operatorIDList[0];
                int oID;
                if (Int32.TryParse(operatorID, out oID))
                {
                    //FIX START RALLY DE 3581: changing setting page after edit crashed
                    if (m_currentOperator != oID)
                    {
                        Common.InitModuleData(oID);
                        m_currentOperator = oID;
                        LoadSettings();
                    }

                    //FIX END RALLY DE 3581
                    moneyCenterSettings1.SetForm(this); // Rally DE8593: System Settings->Cash Method->Money Center
                    moneyCenterSettings1.LoadSettings();
                }
            }
        }

	} // end class

    
} // end namespace