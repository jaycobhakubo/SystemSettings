using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Models;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class MachineSettingsDlg : GradientForm
    {
        #region Private Members

        private SMachineData[] m_arrMachines = new SMachineData[0];
        private List<int> m_moduleIds;
        private Int32 m_nDeviceId = 0;
        private GetMachineSettingsOnlyMessage m_GetMachineSettingsMsg = new GetMachineSettingsOnlyMessage(0, 0);  // we need this for multi-select

        //START RALLY US1594
        private GetMachineCapabilites m_GetMachineCapabilitiesMsg;
        private GetAccrualDisplayItems m_GetAccrualDisplayItemsMsg;
        private GetMachineRemoteDisplayConfigurations m_GetRemoteDisplayConfigurationsMessage;
        private List<RemoteDisplayConfiguration> m_remoteDisplayConfigurations;
        private List<AccrualDisplayItem> m_accrualDisplayItems;
        private List<Accrual> m_accrualList;
        private GetAccuralMessage m_getAccrualMessage;
        private RemoteDisplayConfiguration m_currentRemoteDisplayConfiguration;
        private bool m_accrualEnabled;
        //END RALLY US1594

        private List<MachineCapabilites> m_audioCapabilities;
        private int m_currentGameAudioAdapterId;
        private int m_currentTvAudioAdapterId;

        //These variables are for Display Scenes
        private bool m_boolColumnClickFlag = false; //this will prevent the ColumnClick event from firing the ItemChecked event
        private string m_AllowableScenes = "";  //this is a comma delimited list
        private string m_DefaultScene = "";
        private int m_operatorID;//RALLY US1594
        private List<Business.GenericCBOItem> lstCboDefaultScenes = new List<Business.GenericCBOItem>();
        private List<string> lstAllowableScenes = new List<string>();

        //For anticipation settings
        private int m_AnticipationType;

        //START RALLY DE 4009
        private List<Label> m_cardReaderLabelList = new List<Label>();
        private List<TextBox> m_cardReaderTextBoxList = new List<TextBox>();

        //END RALLY DE 4009

        private Business.GetScenesMessage objGetScenes;
        private Business.ListViewSorter Sorter = new Business.ListViewSorter();

        private class TenderInfo
        {
            public int settingID;
            public string name;

            public override string ToString()
            {
                return name;
            }
        }

        #endregion

        public MachineSettingsDlg(SMachineData[] arrMachines, int operatorID)//RALLY US1594
        {
            InitializeComponent();
            m_operatorID = operatorID;//RALLY US1594
            //START RALLY DE 4009
            m_cardReaderLabelList.Add(lblCardReaderAddress);
            m_cardReaderLabelList.Add(lblCardReaderPort);
            m_cardReaderLabelList.Add(lblCardTrack);

            m_cardReaderTextBoxList.Add(txtCardReaderIPAddress);
            m_cardReaderTextBoxList.Add(txtCardReaderPort);
            m_cardReaderTextBoxList.Add(txtCardTrack);


            //END RALLY DE 4009

            lvAllowableScenes.View = View.Details;
            lvAllowableScenes.CheckBoxes = true;
            lvAllowableScenes.FullRowSelect = true;
            lvAllowableScenes.MultiSelect = false;
            lvAllowableScenes.HideSelection = false;

            LoadComboboxComPort();
            LoadLists();

            m_arrMachines = arrMachines;

            // Determine an appropriate Device Id for this group of machines
            m_nDeviceId = DetermineDeviceId();

            m_moduleIds = new List<int>();

            if (m_nDeviceId == Device.UserDefined.Id)
            {
                m_moduleIds = DetermineModuleIds();
            }

            Common.BeginWait();

            if (!LoadMachineSettings())
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            Common.EndWait();
        }


        // Private Routines
        #region  Private Routines
        // PDTS 1064 - Portable POS Card Swipe
        private void LoadLists()
        {
            // Load the Mag Card Reader Mode list.
            cboMagCardReaderMode.Items.Clear();
            cboMagCardReaderMode.Items.Add(Resources.MagCardModeKeyboard);
            cboMagCardReaderMode.Items.Add(Resources.MagCardModeCPCLTCP);

            // Select first one by default.
            cboMagCardReaderMode.SelectedIndex = 0;
        }

        private int GetScenes()
        {
            try
            {
                objGetScenes = new GTI.Modules.SystemSettings.Business.GetScenesMessage();

                try
                {
                    objGetScenes.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("MachineSettingsDlg.GetScenes()...Send()..Exception: " + ex.Message);
                }

                return objGetScenes.pReturnCode;

            }
            catch (Exception e)
            {
                throw new Exception("MachineSettingsDlg.GetScenes()....Exception: " + e.Message);
            }
        }

        private bool LoadMachineSettings()
        {
            // If this a multi-select, we will start with all default settings
            if (m_arrMachines.Length == 1)
            {
                // Get the machine settings from the server (single selection only)
                m_GetMachineSettingsMsg = new GetMachineSettingsOnlyMessage(m_arrMachines[0].nMachineId, 0);  // zero will return all settings from machine settings table, regardless of category
                try
                {
                    m_GetMachineSettingsMsg.Send();
                }
                catch (Exception e)
                {
                    MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
                    return false;
                }

                // Check return value
                if (m_GetMachineSettingsMsg.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, GTIClient.GetServerErrorString(m_GetMachineSettingsMsg.ServerReturnCode)));
                    return false;
                }

                if (m_nDeviceId == (int)Device.RemoteDisplay.Id || (m_nDeviceId == Device.UserDefined.Id && m_moduleIds.Contains(10)))
                {
                    m_GetMachineCapabilitiesMsg = new GetMachineCapabilites(m_arrMachines[0].nMachineId);
                    try
                    {
                        m_GetMachineCapabilitiesMsg.Send();
                    }
                    catch (Exception e)
                    {
                        MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
                    }



                    m_GetRemoteDisplayConfigurationsMessage = new GetMachineRemoteDisplayConfigurations(m_arrMachines[0].nMachineId, Common.OperatorId);
                    try
                    {
                        m_GetRemoteDisplayConfigurationsMessage.Send();
                        m_remoteDisplayConfigurations = m_GetRemoteDisplayConfigurationsMessage.DisplayConfigurationList;
                    }
                    catch (Exception e)
                    {
                        MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
                    }

                    PopulateAccrualDisplayItems();

                    string licenseResult = Common.GetLicenseSettingValue(LicenseSetting.AccrualEnabled);
                    bool result;
                    if (bool.TryParse(licenseResult, out result) && result == true)
                    {
                        m_getAccrualMessage = new GetAccuralMessage(0, true, false);
                        try
                        {
                            m_getAccrualMessage.Send();
                            m_accrualList = m_getAccrualMessage.AccuralList;
                        }
                        catch (Exception e)
                        {
                            MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
                        }
                    }
                    else
                    {
                        m_accrualList = new List<Accrual>();
                    }
                    m_accrualEnabled = result;   //RALLY DE9673
                }

                // Fixed Base stuff goes here
                if (m_nDeviceId == Device.Fixed.Id)
                {
                    m_GetMachineCapabilitiesMsg = new GetMachineCapabilites(m_arrMachines[0].nMachineId);
                    try
                    {
                        m_GetMachineCapabilitiesMsg.Send();
                    }
                    catch (Exception e)
                    {
                        MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
                    }

                    m_audioCapabilities = new List<MachineCapabilites>(m_GetMachineCapabilitiesMsg.MachineCapabilitesList);
                    m_currentGameAudioAdapterId = m_currentTvAudioAdapterId = 0;
                }
            }

            // Fill in the controls
            FillControls();
            LoadScenes();

            // Disable the ADMIN-ONLY controls if needed - we do it here because the CheckChanged event handlers enable the text boxes
            /*txtClientInstallDrive.Enabled = Common.IsAdmin && !chkClientInstallDrive.Checked;
            chkClientInstallDrive.Enabled = Common.IsAdmin;
            txtClientRootDir.Enabled = Common.IsAdmin && !chkClientRootDir.Checked;
            chkClientRootDir.Enabled = Common.IsAdmin;*/

            /*These were replaced     
            txtAllowableScenes.Enabled = Common.IsAdmin && !chkAllowableScenes.Checked;
            chkAllowableScenes.Enabled = Common.IsAdmin;
            txtDefaultSceneID.Enabled = Common.IsAdmin && !chkDefaultSceneID.Checked;
            chkDefaultSceneID.Enabled = Common.IsAdmin;
            */

            return true;
        }

        private int DetermineDeviceId()
        {
            int nCount = m_arrMachines.Length;

            // Get the first device id
            int nDeviceId = m_arrMachines[0].nDeviceId;

            // Check if they are all the same, or return "User Defined" if not
            for (int i = 0; i < nCount; i++)
            {
                if (m_arrMachines[i].nDeviceId != nDeviceId)
                {
                    return (int)Device.UserDefined.Id;
                }
            }

            return nDeviceId;
        }

        private List<int> DetermineModuleIds()
        {
            List<int> moduleIds = new List<int>();
            GetMachineModules getMachineModulesMessage = new GetMachineModules(m_arrMachines[0].nMachineId);

            try
            {
                getMachineModulesMessage.Send();

                moduleIds = getMachineModulesMessage.MachineModule.ModuleIDs;
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error getting module ids {0}", e.Message), "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return moduleIds;
        }

        private void LoadComboboxComPort()
        {
            var lstComPortKioskBillAcceptor = new List<Business.GenericCBOItem>();
            for (int i = 0; i < 14; i++)
            {
                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                cboItem.CBOValueMember = i;
                switch (i)
                {
                    case 0:
                        cboItem.CBODisplayMember = "Disabled";
                        break;
                    default:
                        cboItem.CBODisplayMember = "COM" + i.ToString();
                        break;
                }

                lstComPortKioskBillAcceptor.Add(cboItem);
            }
            cboKioskBillAcceptorComPort.Items.Clear();
            cboKioskBillAcceptorComPort.DataSource = lstComPortKioskBillAcceptor;
            cboKioskBillAcceptorComPort.DisplayMember = "CBODisplayMember";
            cboKioskBillAcceptorComPort.ValueMember = "CBOValueMember";
        }


        private void FillControls()
        {

            bool IsHallDisplayVisible = (m_nDeviceId == Device.RemoteDisplay.Id || (m_nDeviceId == Device.UserDefined.Id && m_moduleIds.Contains(10)));     // Decide which controls we are going to show for this device type
            SettingValue s;      // Fill in the settings

            grpHallDisplay.Visible = IsHallDisplayVisible;
            if (IsHallDisplayVisible == false)
            {
                tabMachineDialog.TabPages.Remove(tpHallDisplay);
            }
            else
            {
                SetRemoteDisplayTab();
            }
            // TTP 50339
            bool IsPOSVisible = (m_nDeviceId == Device.UserDefined.Id && m_moduleIds.Contains(1)) 
                || (m_nDeviceId == Device.POS.Id)
                || (m_nDeviceId == Device.POSPortable.Id)
                || (m_nDeviceId == Device.AdvancedPOSKiosk.Id)
                || (m_nDeviceId == Device.BuyAgainKiosk.Id)
                || (m_nDeviceId == Device.SimplePOSKiosk.Id)
                || (m_nDeviceId == Device.HybridKiosk.Id)
                || (m_nDeviceId == Device.POSManagement.Id);
            // Rally 	DE2837 Allow the caller to configure reciept printer
            //   || (m_nDeviceId == Device.Caller.Id);

            bool t_isKioskSalesActive =    //Show only this setting only if one of the kiosk is being used.
             ((m_nDeviceId == Device.AdvancedPOSKiosk.Id)
                || (m_nDeviceId == Device.BuyAgainKiosk.Id)
                || (m_nDeviceId == Device.SimplePOSKiosk.Id)
                || (m_nDeviceId == Device.HybridKiosk.Id));
                
            grpbxKioskSales.Visible = t_isKioskSalesActive;
            if (t_isKioskSalesActive)
            {
                grpPOS.Size = new System.Drawing.Size(672, 477);
                string tempString = "";
                int tempSelectedIndex = 0;
                bool tempResult = false;

                //kiosk sales - com port
                if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.KioskPeripheralsAcceptorComPort, out s))
                {
                    chkbxBillAcceptor.Checked = false;
                    tempString = s.Value;
                }
                else
                {
                    chkbxBillAcceptor.Checked = true;
                    tempString = Common.GetSystemSetting(Setting.KioskPeripheralsAcceptorComPort);                  
                }


                try//If theres any issue just set to 0
                {
                    tempResult = int.TryParse(tempString, out tempSelectedIndex);

                    if (tempResult)//If the setting is not numeric set it  as  disable
                    {
                        cboKioskBillAcceptorComPort.SelectedIndex = tempSelectedIndex;
                    }
                    else
                    {
                        cboKioskBillAcceptorComPort.SelectedIndex = 0;
                        //  saveFlag = true;
                    }
                }
                catch
                {
                    cboKioskBillAcceptorComPort.SelectedIndex = 0;
                    // saveFlag = true;
                }                  


                //Kiosk - sales (printer name)
                if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.KioskPeripheralsTicketPrinterName, out s))
                {
                    chkbxTicketPrinter.Checked = false;
                    txtbxKioskTicketPrinterName.Text = s.Value;

                }
                else
                {
                    chkbxTicketPrinter.Checked = true;
                    tempString = Common.GetSystemSetting(Setting.KioskPeripheralsTicketPrinterName);
                    txtbxKioskTicketPrinterName.Text = tempString;
                }
            }
            else
            {
                grpPOS.Size = new System.Drawing.Size(672, 566);
            }
            
            grpPOS.Visible = IsPOSVisible;

            if (IsPOSVisible == false)
            {
                tabMachineDialog.TabPages.Remove(tpPOS);
                tabMachineDialog.TabPages.Remove(tpPaymentProcessing);
            }

            if (!(m_nDeviceId == Device.Caller.Id || (m_nDeviceId == Device.UserDefined.Id && m_moduleIds.Contains(11))))
            {
                RemoveCallerTab();
            }

            if ((m_nDeviceId == Device.UserDefined.Id && m_moduleIds.Contains(12)) ||
                (m_nDeviceId == Device.Kiosk.Id) &&
                !grpPOS.Visible // PDTS 1064
                )
            {
                grpVideo.Visible = true;
                grpVideo.Location = grpPOS.Location;

            }
            else
            {
                tabMachineDialog.TabPages.Remove(tpVideo);
            }

            // For TA12839
            if (m_nDeviceId == Device.Fixed.Id)
            {
                SetFixedBaseTab();
            }
            else
            {
                tabMachineDialog.TabPages.Remove(tpFixedBase);
            }

          

            // Client Install Drive
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ClientInstallDrive, out s))
            {
                chkClientInstallDrive.Checked = false;
                txtClientInstallDrive.Text = s.Value;
            }
            else
            {
                chkClientInstallDrive.Checked = true;
                txtClientInstallDrive.Text = Common.GetSystemSetting(Setting.ClientInstallDrive);//RALLY DE9744
            }

            // Client Root folder
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ClientInstallRootDirectory, out s))
            {
                chkClientRootDir.Checked = false;
                txtClientRootDir.Text = s.Value;
            }
            else
            {
                chkClientRootDir.Checked = true;
                txtClientRootDir.Text = Common.GetSystemSetting(Setting.ClientInstallRootDirectory);//RALLY DE9744
            }

            // Global Printer
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.GlobalPrinterName, out s))
            {
                chkGlobalPrinter.Checked = false;
                txtGlobalPrinter.Text = s.Value;
            }
            else
            {
                chkGlobalPrinter.Checked = true;
                txtGlobalPrinter.Text = Common.GetSystemSetting(Setting.GlobalPrinterName);//RALLY DE9744
            }

            // Crate Server
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.CrateServerAddress, out s))
            {
                chkCrateServer.Checked = false;
                txtCrateServer.Text = s.Value;
            }
            else
            {
                chkCrateServer.Checked = true;
                txtCrateServer.Text = Common.GetSystemSetting(Setting.CrateServerAddress);//RALLY DE9744				
            }

            // Logging Level
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.LoggingLevel, out s))
            {
                chkLogLevel.Checked = false;
                cboLogLevel.SelectedIndex = Math.Max(0, Math.Min(Int32.Parse(s.Value), 7));
            }
            else
            {
                chkLogLevel.Checked = true;
                cboLogLevel.SelectedIndex = Math.Max(0, Math.Min(Int32.Parse(Common.GetSystemSetting(Setting.LoggingLevel)), 7));
            }

            //ttp 50168 Receipt copies
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.PrintRegisterReceiptsNumber, out s))
            {
                checkReceiptCopies.Checked = false;
                numReceiptCopies.Value = Common.ParseInt(s.Value);
            }
            else
            {
                checkReceiptCopies.Checked = true;
                numReceiptCopies.Value = Common.ParseInt(Common.GetOpSetting(Setting.PrintRegisterReceiptsNumber));
            }

            //RALLY DE 3331
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ShowMouseCursor, out s))
            {
                chkUseCursor.Checked = false;
                checkShowCursor.Checked = Common.ParseBool(s.Value);
            }
            else
            {
                chkUseCursor.Checked = true;
                checkShowCursor.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowMouseCursor));//RALLY DE9744
            }

            // Receipt Printer
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.POSReceiptPrinterName, out s))
            {
                chkReceiptPrinter.Checked = false;
                chkCallerReceiptPrinter.Checked = false;
                txtReceiptPrinter.Text = s.Value;
                textCallerReceiptPrinter.Text = s.Value;
            }
            else
            {
                chkReceiptPrinter.Checked = true;
                chkCallerReceiptPrinter.Checked = true;
                txtReceiptPrinter.Text = Common.GetOpSetting(Setting.POSReceiptPrinterName);
                textCallerReceiptPrinter.Text = Common.GetOpSetting(Setting.POSReceiptPrinterName);
            }

            // Sell Electronics
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.SellElectronics, out s))
            {
                chkSellElectronics.Checked = false;
                cboSellElectronics.SelectedIndex = s.Value.Equals(bool.TrueString) ? 1 : 0;
            }
            else
            {
                chkSellElectronics.Checked = true;
                cboSellElectronics.SelectedIndex = Common.GetOpSetting(Setting.SellElectronics).Equals(bool.TrueString) ? 1 : 0;
            }

            // PDTS 584
            // Cash Drawer Eject Code
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.CashDrawerEjectCode, out s))
            {
                chkCashDrawerEjectCode.Checked = false;
                txtCashDrawerEjectCode.Text = s.Value;
            }
            else
            {
                chkCashDrawerEjectCode.Checked = true;
                txtCashDrawerEjectCode.Text = Common.GetOpSetting(Setting.CashDrawerEjectCode);
            }

            //Allowed tender types
            TenderInfo ti = new TenderInfo();
            bool isSet = false;

            chkAllowedTenders.Checked = true;

            ti.name = "Cash";
            ti.settingID = (int)Setting.AllowCash;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.AllowCash, out s))
            {
                chkAllowedTenders.Checked = false;
                bool.TryParse(s.Value, out isSet);
            }

            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(ti), isSet);

            ti = new TenderInfo();
            isSet = false;
            ti.name = "Checks";
            ti.settingID = (int)Setting.AllowChecks;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.AllowChecks, out s))
            {
                chkAllowedTenders.Checked = false;
                bool.TryParse(s.Value, out isSet);
            }

            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(ti), isSet);

            ti = new TenderInfo();
            isSet = false;
            ti.name = "Credit Cards";
            ti.settingID = (int)Setting.AllowCreditCards;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.AllowCreditCards, out s))
            {
                chkAllowedTenders.Checked = false;
                bool.TryParse(s.Value, out isSet);
            }

            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(ti), isSet);

            ti = new TenderInfo();
            isSet = false;
            ti.name = "Debit Cards";
            ti.settingID = (int)Setting.AllowDebitCards;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.AllowDebitCards, out s))
            {
                chkAllowedTenders.Checked = false;
                bool.TryParse(s.Value, out isSet);
            }

            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(ti), isSet);

            ti = new TenderInfo();
            isSet = false;
            ti.name = "Gift Cards";
            ti.settingID = (int)Setting.AllowGiftCards;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.AllowGiftCards, out s))
            {
                chkAllowedTenders.Checked = false;
                bool.TryParse(s.Value, out isSet);
            }

            clbAllowedTenders.SetItemChecked(clbAllowedTenders.Items.Add(ti), isSet);

            clbAllowedTenders.Sorted = true;

            //US4511: Support Chatsworth CBB scanner
            //CBB Scanner Type
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.CbbScannerType, out s))
            {
                chkCbbScannerType.Checked = false;
                int scannerType;
                if (int.TryParse(s.Value, out scannerType))
                {
                    cboCbbScannerType.SelectedIndex = scannerType + 1;
                }
            }
            else
            {
                chkCbbScannerType.Checked = true;
                cboCbbScannerType.SelectedIndex = Common.ParseInt(Common.GetSystemSetting(Setting.CbbScannerType))+1;
            }

            //US4511: Support Chatsworth CBB scanner
            //CBB Scanner Port
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.CBBScannerPort, out s))
            {
                chkCbbScannerPort.Checked = false;
                int scannerType;
                if (int.TryParse(s.Value, out scannerType))
                {
                    numCBBScannerPort.Value = scannerType;
                }
            }
            else
            {
                chkCbbScannerPort.Checked = true;
                numCBBScannerPort.Value = Common.ParseInt(Common.GetOpSetting(Setting.CBBScannerPort));
            }

            // PDTS 1064
            // Mag. Card Reader Mode
            int mode = 0;

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.MagneticCardReaderMode, out s))
            {
                chkMagCardReaderMode.Checked = false;
                int.TryParse(s.Value, out mode);
                mode--;
            }
            else
            {
                chkMagCardReaderMode.Checked = true;
                int.TryParse(Common.GetOpSetting(Setting.MagneticCardReaderMode), out mode);
                mode--;
            }

            if (mode >= 0 && mode <= cboMagCardReaderMode.Items.Count - 1)
                cboMagCardReaderMode.SelectedIndex = mode;

            mode++;

            // Reader Parameters.
            string cardParams;

            if (!chkMagCardReaderMode.Checked && m_GetMachineSettingsMsg.TryGetSettingValue(Setting.MagneticCardReaderParameters, out s))
            {
                cardParams = s.Value;
            }
            else
            {
                cardParams = Common.GetOpSetting(Setting.MagneticCardReaderParameters);
            }

            switch ((MagneticCardReaderMode)mode)
            {
                default:
                case MagneticCardReaderMode.KeyboardOnly:
                    // We don't care about values.
                    txtCardReaderIPAddress.Text = string.Empty;
                    txtCardReaderPort.Text = string.Empty;
                    txtCardTrack.Text = string.Empty;
                    SetCardParametersVisible(false); //RALLY DE 4009
                    break;

                case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                    try
                    {
                        string address;
                        int port;
                        short track;
                        SetCardParametersVisible(true);//RALLY DE 4009
                        CPCLPrinterTCPSource.SettingsFromString(cardParams, out address, out port, out track);

                        txtCardReaderIPAddress.Text = address;
                        txtCardReaderPort.Text = port.ToString();
                        txtCardTrack.Text = track.ToString();
                    }
                    catch
                    {
                        txtCardReaderIPAddress.Text = string.Empty;
                        txtCardReaderPort.Text = string.Empty;
                        txtCardTrack.Text = string.Empty;
                    }
                    break;
            }

            //Payment Processing
            if (Common.ParseInt(Common.GetOpSetting(Setting.CreditCardProcessor)) == 0)
            {
                tabMachineDialog.TabPages.Remove(tpPaymentProcessing);
            }
            else
            {
                if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.PaymentProcessingEnabled, out s))
                {
                    checkPaymentProcessorEnabled.Checked = false;
                    chkPaymentProcessingEnabled.Checked = Common.ParseBool(s.Value);
                }
                else
                {
                    checkReceiptCopies.Checked = true;
                    chkPaymentProcessingEnabled.Checked = Common.ParseBool(Common.GetOpSetting(Setting.PaymentProcessingEnabled));
                }

                if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.PaymentDeviceAddress, out s))
                {
                    checkPaymentProcessorAddress.Checked = false;
                    txtPaymentProcessorAddress.Text = s.Value;
                }
                else
                {
                    checkPaymentProcessorAddress.Checked = true;
                    txtPaymentProcessorAddress.Text = Common.GetOpSetting(Setting.PaymentDeviceAddress);
                }

                if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.PaymentDevicePort, out s))
                {
                    checkPaymentProcessorPort.Checked = false;
                    txtPaymentProcessorPort.Text = s.Value;
                }
                else
                {
                    checkPaymentProcessorPort.Checked = true;
                    txtPaymentProcessorPort.Text = Common.GetOpSetting(Setting.PaymentDevicePort);
                }
            }

            // Screen Width
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ScreenWidth, out s))
            {
                chkScreenWidth.Checked = false;
                numScreenWidth.Value = Common.ParseInt(s.Value);
            }
            else
            {
                chkScreenWidth.Checked = true;
                numScreenWidth.Value = Common.ParseInt(Common.GetOpSetting(Setting.ScreenWidth));
            }

            // Screen Height
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ScreenHeight, out s))
            {
                chkScreenHeight.Checked = false;
                numScreenHeight.Value = Common.ParseInt(s.Value);
            }
            else
            {
                chkScreenHeight.Checked = true;
                numScreenHeight.Value = Common.ParseInt(Common.GetOpSetting(Setting.ScreenHeight));
            }

            // Refresh Rate
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.RefreshRate, out s))
            {
                chkRefreshRate.Checked = false;
                numRefreshRate.Value = Common.ParseInt(s.Value);
            }
            else
            {
                chkRefreshRate.Checked = true;
                numRefreshRate.Value = Common.ParseInt(Common.GetOpSetting(Setting.RefreshRate));
            }

            // US4645
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.BallCallCameraChannel, out s))
            {   // JAN - this logic is goofy, but I didn't want to break the existing functionality... Should probably be reworked to more closely match the enum...
                string selVal;
                int parseVal = Common.ParseInt(s.Value);
                int upper = Enum.GetValues(typeof(BallCameraType)).Cast<int>().Max(), lower = Enum.GetValues(typeof(BallCameraType)).Cast<int>().Min();

                if (parseVal <= upper
                    && parseVal >= lower) // if the parsed value is within the bounds of the enum, use the enum 
                {
                    selVal = EnumToString.GetDescription((BallCameraType)parseVal);
                }
                else // it's a user-entered value.
                {
                    selVal = s.Value;
                }

                bool found = false;
                foreach (var item in cboCameraChannel.Items)
                {
                    if (String.Equals(item.ToString(), selVal))
                    {
                        cboCameraChannel.SelectedItem = item;
                        found = true;
                        break;
                    }
                }

                if (!found) // it's a user-entered value.
                {
                    cboCameraChannel.Items.Add(selVal);
                    cboCameraChannel.SelectedIndex = (cboCameraChannel.Items.Count - 1);
                }

                chkCallerBallCamera.Checked = false;
                cboCameraChannel.Enabled = true;
            }
            else
            {
                cboCameraChannel.SelectedIndex = 0;
                chkCallerBallCamera.Checked = true;
            }
        }
        //START RALLY US1594
        private void SetRemoteDisplayTab()
        {
            SettingValue s;
            //            string strTemp = "";

            buttonSetAccruals.Visible = Common.ParseBool(Common.GetLicenseSettingValue(LicenseSetting.AccrualEnabled));
            //bool.TryParse(accrualEnabledString, out m_accrualEnabled);

            //if (m_accrualEnabled == false)
            //{
            //    buttonSetAccruals.Visible = false;
            //}

            //Use Virtual Flashboard Camera
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.UseVirtualFlashboardCamera, out s))
            {
                chkUseVirtualDefault.Checked = false;
                chkUseVirtualFlashboardCamera.Checked = Common.ParseBool(s.Value);  //RALLY DE9427

            }
            else
            {
                chkUseVirtualFlashboardCamera.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.UseVirtualFlashboardCamera));  //RALLY DE9427
                chkUseVirtualDefault.Checked = true;

            }

            //START RALLY US1897        
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ShowPayoutAmount, out s))
            {
                chkShowPayoutAmountDefault.Checked = false;

                chkShowPayoutAmounts.Checked = Common.ParseBool(s.Value);  //RALLY DE9427

            }
            else
            {
                chkShowPayoutAmounts.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowPayoutAmount)); //RALLY DE9744 RALLY DE9427

            }
            //END RALLY US1897
            //Screen Saver Timeout
            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.ScreenSaverTimeout, out s))
            {
                chkScreenSaverTimeout.Checked = false;
                numScreenSaverTimeout.Value = Convert.ToInt32(s.Value);
                numScreenSaverTimeout.Enabled = true; //RALLY DE2873 screen saver timeout  should be greyed out
                ScreenSaverTimeoutLabel.Enabled = true; //RALLY DE2873 screen saver timeout  should be greyed out
            }

            else
            {
                chkScreenSaverTimeout.Checked = true;
                numScreenSaverTimeout.Value = Convert.ToInt32(Common.GetSystemSetting(Setting.ScreenSaverTimeout));//RALLY DE9744
                numScreenSaverTimeout.Enabled = false; //RALLY DE2873 screen saver timeout  should be greyed out
                ScreenSaverTimeoutLabel.Enabled = false; //RALLY DE2873 screen saver timeout  should be greyed out
            }

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.DisplayNextBall, out s))//US4727
            {
                chkAnticipationDefault.Checked = false;
                m_AnticipationType = Convert.ToInt32(s.Value);

                if (m_AnticipationType == 1)
                {
                    rdChangeBallColor.Checked = true;
                }
                else if (m_AnticipationType == 2)
                {
                    rdNextBallOnly.Checked = true;
                }
                else
                {
                    rdChangeBGColor.Checked = true;
                }

                rdChangeBallColor.Enabled = true;
                rdNextBallOnly.Enabled = true;
                rdChangeBGColor.Enabled = true;
            }

            else
            {
                chkAnticipationDefault.Checked = true;
                m_AnticipationType = Convert.ToInt32(Common.GetSystemSetting(Setting.DisplayNextBall));

                if (m_AnticipationType == 1)
                {
                    rdChangeBallColor.Checked = true;
                }
                else if (m_AnticipationType == 2)
                {
                    rdNextBallOnly.Checked = true;
                }
                else
                {
                    rdChangeBGColor.Checked = true;
                }

                rdChangeBallColor.Enabled = false;
                rdNextBallOnly.Enabled = false;
                rdChangeBGColor.Enabled = false;
            }

            if (m_GetMachineSettingsMsg.TryGetSettingValue(Setting.BallImageMinDisplayTime, out s))//US4727
            {
                chkMinBallTimeDefault.Checked = false;
                numMinBallCallTime.Value = Convert.ToInt32(s.Value);
                numMinBallCallTime.Enabled = true;
                label23.Enabled = true;
            }
            else
            {
                chkMinBallTimeDefault.Checked = true;
                numMinBallCallTime.Value = Convert.ToInt32(Common.GetSystemSetting(Setting.BallImageMinDisplayTime));
                numMinBallCallTime.Enabled = false;
                label23.Enabled = false;
            }

            cboVideoAdapter.Items.AddRange(m_GetMachineCapabilitiesMsg.MachineCapabilitesList.ToArray());
            if (cboVideoAdapter.Items.Count > 0)
            {
                cboVideoAdapter.SelectedIndex = 0;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        //END RALLY US1594
        //START RALLY DE 4009
        private void SetCardParametersVisible(bool visible)
        {

            foreach (TextBox textBox in m_cardReaderTextBoxList)
            {
                textBox.Visible = visible;
            }

            foreach (Label label in m_cardReaderLabelList)
            {
                label.Visible = visible;
            }
        }
        //END RALLY DE 4009

        private void RemoveCallerTab()
        {
            tabMachineDialog.TabPages.Remove(tpCaller);
            grpCaller.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // PDTS 1064
            // Validate
            if (!MagCardSettings.ValidateMagCardInput(cboMagCardReaderMode.SelectedIndex + 1, txtCardReaderPort.Text, txtCardTrack.Text))
            {
                return;
            }

            Common.BeginWait();
            bool bSuccess = SaveMachineSettings();
            Common.EndWait();

            if (!bSuccess)
            {
                return;
            }

            // Close the dialog
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private bool SaveMachineSettings()
        {
            // Gather up the settings we are going to set (we only need ID and VALUE for this msg)
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            // General Settings   // Client Install Drive         
            if (!chkClientInstallDrive.Checked)
            {
                s.Id = (int)Setting.ClientInstallDrive;
                s.Value = txtClientInstallDrive.Text;
                arrSettings.Add(s);
            }

            // Client Root folder
            if (!chkClientRootDir.Checked)
            {
                s.Id = (int)Setting.ClientInstallRootDirectory;
                s.Value = txtClientRootDir.Text;
                arrSettings.Add(s);
            }

            // Global Printer
            if (!chkGlobalPrinter.Checked)
            {
                s.Id = (int)Setting.GlobalPrinterName;
                s.Value = txtGlobalPrinter.Text;
                arrSettings.Add(s);
            }

            // Crate Server
            if (!chkCrateServer.Checked)
            {
                s.Id = (int)Setting.CrateServerAddress;
                s.Value = txtCrateServer.Text;
                arrSettings.Add(s);
            }

            // Logging Level
            if (!chkLogLevel.Checked)
            {
                s.Id = (int)Setting.LoggingLevel;
                s.Value = cboLogLevel.SelectedIndex.ToString();
                arrSettings.Add(s);
            }

            //ttp 50168 receipt copies
            if (!checkReceiptCopies.Checked)
            {
                s.Id = (int)Setting.PrintRegisterReceiptsNumber;
                s.Value = numReceiptCopies.Value.ToString();
                arrSettings.Add(s);
            }

            //RALLY DE 3331
            if (!chkUseCursor.Checked)
            {
                s.Id = (int)Setting.ShowMouseCursor;
                s.Value = checkShowCursor.Checked.ToString();
                arrSettings.Add(s);
            }

            if (!chkCallerReceiptPrinter.Checked)
            {
                s.Id = (int)Setting.POSReceiptPrinterName;
                s.Value = textCallerReceiptPrinter.Text;
                arrSettings.Add(s);
            }

            // POS settings
            // Receipt Printer
            if (!chkReceiptPrinter.Checked)
            {
                s.Id = (int)Setting.POSReceiptPrinterName;
                s.Value = txtReceiptPrinter.Text;
                arrSettings.Add(s);
            }

            // Sell Electronics
            if (!chkSellElectronics.Checked)
            {
                s.Id = (int)Setting.SellElectronics;
                s.Value = cboLogLevel.SelectedIndex == 1 ? "True" : "False";
                arrSettings.Add(s);
            }

            // PDTS 584
            // Cash Drawer Eject Doe
            if (!chkCashDrawerEjectCode.Checked)
            {
                s.Id = (int)Setting.CashDrawerEjectCode;
                s.Value = txtCashDrawerEjectCode.Text.Trim();
                arrSettings.Add(s);
            }

            //CBB Scanner Type
            if (!chkCbbScannerType.Checked)
            {
                s.Id = (int)Setting.CbbScannerType;
                s.Value = (cboCbbScannerType.SelectedIndex - 1).ToString();
                arrSettings.Add(s);
            }

            //CBB Scanner Port
            if (!chkCbbScannerPort.Checked)
            {
                s.Id = (int)Setting.CBBScannerPort;
                s.Value = numCBBScannerPort.Text;
                arrSettings.Add(s);
            }

            if (!chkAllowedTenders.Checked)
            {
                for (int x = 0; x < clbAllowedTenders.Items.Count; x++)
                {
                    s.Id = ((TenderInfo)clbAllowedTenders.Items[x]).settingID;
                    s.Value = clbAllowedTenders.GetItemChecked(x).ToString();
                    arrSettings.Add(s);
                }
            }

            // PDTS 1064
            if (!chkMagCardReaderMode.Checked)
            {
                s.Id = (int)Setting.MagneticCardReaderMode;
                s.Value = (cboMagCardReaderMode.SelectedIndex + 1).ToString(System.Globalization.CultureInfo.InvariantCulture);
                arrSettings.Add(s);

                s.Id = (int)Setting.MagneticCardReaderParameters;

                switch ((MagneticCardReaderMode)(cboMagCardReaderMode.SelectedIndex + 1))
                {
                    default:
                    case MagneticCardReaderMode.KeyboardOnly:
                        // We don't care about values.
                        s.Value = string.Empty;
                        break;

                    case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                        s.Value = CPCLPrinterTCPSource.SettingsToString(txtCardReaderIPAddress.Text.Trim(),
                                                                        Convert.ToInt32(txtCardReaderPort.Text.Trim()),
                                                                        Convert.ToInt16(txtCardTrack.Text.Trim()));
                        break;
                }
                arrSettings.Add(s);
            }

            if (!chkCallerBallCamera.Checked)
            {
                s.Id = (int)Setting.BallCallCameraChannel;
                string strTempVal = cboCameraChannel.Text;

                foreach (BallCameraType value in Enum.GetValues(typeof(BallCameraType)))
                {
                    if (String.Equals(strTempVal, EnumToString.GetDescription(value), StringComparison.CurrentCultureIgnoreCase)) // compare what is selected against the enum's (description) values
                    {
                        strTempVal = ((int)value).ToString(); // if we find one, take that value. Otherwise, keep what the user enterred
                        break;
                    }
                }

                s.Value = strTempVal;
                arrSettings.Add(s);
            }

            // Hall display settings
            SetCurrentRemoteConfiguration();
            //Use Virtual Flashboard Camera
            if (!chkUseVirtualDefault.Checked)
            {
                s.Id = (int)Setting.UseVirtualFlashboardCamera;
                s.Value = chkUseVirtualFlashboardCamera.Checked.ToString();
                arrSettings.Add(s);
            }

            //Screen Saver Timeout
            if (!chkScreenSaverTimeout.Checked)
            {
                s.Id = (int)Setting.ScreenSaverTimeout;
                s.Value = numScreenSaverTimeout.Value.ToString();
                arrSettings.Add(s);
            }
            //START RALLY US1897
            if (!chkShowPayoutAmountDefault.Checked)
            {
                s.Id = (int)Setting.ShowPayoutAmount;
                s.Value = chkShowPayoutAmounts.Checked.ToString();
                arrSettings.Add(s);
            }

            if (!chkMinBallTimeDefault.Checked)
            {
                s.Id = (int)Setting.BallImageMinDisplayTime;
                s.Value = numMinBallCallTime.Value.ToString();
                arrSettings.Add(s);//US4727
            }

            if (!chkAnticipationDefault.Checked)
            {
                if (rdChangeBallColor.Checked)
                    m_AnticipationType = 1;
                else if (rdNextBallOnly.Checked)
                    m_AnticipationType = 2;
                else
                    m_AnticipationType = 0;
                s.Id = (int)Setting.DisplayNextBall;
                s.Value = m_AnticipationType.ToString();
                arrSettings.Add(s); //US4727
            }

            //END RALLY US1897
            if (m_remoteDisplayConfigurations != null)
                SaveRemoteDisplayConfigurations();

            // Video settings
            // Screen Width
            if (!chkScreenWidth.Checked)
            {
                s.Id = (int)Setting.ScreenWidth;
                s.Value = numScreenWidth.Value.ToString();
                arrSettings.Add(s);
            }

            // Screen Height
            if (!chkScreenHeight.Checked)
            {
                s.Id = (int)Setting.ScreenHeight;
                s.Value = numScreenHeight.Value.ToString();
                arrSettings.Add(s);
            }

            // Refresh Rate
            if (!chkRefreshRate.Checked)
            {
                s.Id = (int)Setting.RefreshRate;
                s.Value = numRefreshRate.Value.ToString();
                arrSettings.Add(s);
            }

            // TA12839 Fixed base data being saved
            if (m_nDeviceId == Device.Fixed.Id)
            {
                if (m_audioCapabilities.Count > 0)
                {
                    // might be assuming the indexes are in the proper order. May want to check this.
                    if (!chkUseGameDefault.Checked)
                    {
                        s.Id = (int)Setting.GameSoundsAdapterId;
                        s.Value = m_currentGameAudioAdapterId.ToString();
                        arrSettings.Add(s);
                    }

                    if (!chkUseTvDefault.Checked)
                    {
                        s.Id = (int)Setting.TVSoundsAdapterId;
                        s.Value = m_currentTvAudioAdapterId.ToString();
                        arrSettings.Add(s);
                    }
                }
            }

            //Payment processing settings
            if (!checkPaymentProcessorEnabled.Checked)
            {
                s.Id = (int)Setting.PaymentProcessingEnabled;
                s.Value = chkPaymentProcessingEnabled.Checked.ToString();
                arrSettings.Add(s);
            }

            if (!checkPaymentProcessorAddress.Checked)
            {
                s.Id = (int)Setting.PaymentDeviceAddress;
                s.Value = txtPaymentProcessorAddress.Text;
                arrSettings.Add(s);
            }

            if (!checkPaymentProcessorPort.Checked)
            {
                s.Id = (int)Setting.PaymentDevicePort;
                s.Value = txtPaymentProcessorPort.Text;
                arrSettings.Add(s);
            }

            if (!chkbxBillAcceptor.Checked)
            {
                s.Id = (int)Setting.KioskPeripheralsAcceptorComPort;
                s.Value = cboKioskBillAcceptorComPort.SelectedValue.ToString();
                arrSettings.Add(s);
            }

            if (!chkbxTicketPrinter.Checked)
            {
                s.Id = (int)Setting.KioskPeripheralsTicketPrinterName;
                s.Value = txtbxKioskTicketPrinterName.Text;
                arrSettings.Add(s);
            }
           
            // Create an array of machine ids
            List<Int32> arrMachineIds = new List<Int32>();
            int nCount = m_arrMachines.Length;
            for (int i = 0; i < nCount; i++)
            {
                arrMachineIds.Add(m_arrMachines[i].nMachineId);
            }

            // Send a message to the server
            SetMachineSettingsExMessage msg = new SetMachineSettingsExMessage(arrMachineIds.ToArray(), arrSettings.ToArray());

            try
            {
                msg.Send();
            }
            catch (Exception e)
            {
                MessageForm.Show(this, string.Format(Resources.UpdMachineSettingsFailed, e));
                return false;
            }

            // Check return value
            if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            {
                MessageForm.Show(this, string.Format(Resources.UpdMachineSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
                return false;
            }

            return true;
        }

        private void SaveRemoteDisplayConfigurations()
        {
            foreach (RemoteDisplayConfiguration remoteDisplayConfiguration in m_remoteDisplayConfigurations)
            {
                if (!(remoteDisplayConfiguration.AdaptorEnabled == true &&
                    (string.IsNullOrEmpty(remoteDisplayConfiguration.AllowedScenes) ||
                    remoteDisplayConfiguration.AdaptorID < 0 ||
                    remoteDisplayConfiguration.DefaultScene == 0 ||
                    remoteDisplayConfiguration.MachineID < 0 ||
                    string.IsNullOrEmpty(remoteDisplayConfiguration.Resolution))))
                {
                    SetRemoteDisplayConfigurations setConfigurationsMessage = new SetRemoteDisplayConfigurations(remoteDisplayConfiguration, Common.OperatorId);
                    try
                    {
                        setConfigurationsMessage.Send();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(string.Format("Error saving remote display configurations {0}", e.Message), "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Function to prepare the FixedBase tab and it's contents. Entering this function assumes that the selected machine is a Fixed Base
        private void SetFixedBaseTab()
        {
            foreach (MachineCapabilites mc in m_audioCapabilities)
            {
                cboGameSoundsOutput.Items.Add(mc);

                cboTvSoundsOutput.Items.Add(mc);
            }

            if (m_GetMachineSettingsMsg.MachineSettingsList.Length > 0)
            {
                foreach (SettingValue sv in m_GetMachineSettingsMsg.MachineSettingsList)
                {
                    if (sv.Id == (int)Setting.GameSoundsAdapterId)
                    {
                        m_currentGameAudioAdapterId = Int32.Parse(sv.Value);
                        chkUseGameDefault.Checked = false;
                        if (m_currentGameAudioAdapterId >= cboGameSoundsOutput.Items.Count)
                            m_currentGameAudioAdapterId = 0;
                    }

                    else if (sv.Id == (int)Setting.TVSoundsAdapterId)
                    {
                        m_currentTvAudioAdapterId = Int32.Parse(sv.Value);
                        chkUseTvDefault.Checked = false;
                        if (m_currentTvAudioAdapterId >= cboTvSoundsOutput.Items.Count)
                            m_currentTvAudioAdapterId = 0;
                    }
                }
            }

            if (cboGameSoundsOutput.Items.Count > 0)
                cboGameSoundsOutput.SelectedIndex = m_currentGameAudioAdapterId;
            if (cboTvSoundsOutput.Items.Count > 0)
                cboTvSoundsOutput.SelectedIndex = m_currentTvAudioAdapterId;
        }

        #endregion // Private Routines

        private void chkClientInstallDrive_CheckedChanged(object sender, EventArgs e)
        {
            txtClientInstallDrive.Enabled = !chkClientInstallDrive.Checked;
            if (chkClientInstallDrive.Checked)
            {
                txtClientInstallDrive.Text = Common.GetSystemSetting(Setting.ClientInstallDrive);//RALLY DE9744
            }
        }

        private void chkClientRootDir_CheckedChanged(object sender, EventArgs e)
        {
            txtClientRootDir.Enabled = !chkClientRootDir.Checked;
            if (chkClientRootDir.Checked)
            {
                txtClientRootDir.Text = Common.GetSystemSetting(Setting.ClientInstallRootDirectory);//RALLY DE9744
            }
        }

        private void chkGlobalPrinter_CheckedChanged(object sender, EventArgs e)
        {
            txtGlobalPrinter.Enabled = !chkGlobalPrinter.Checked;
            if (chkGlobalPrinter.Checked)
            {
                txtGlobalPrinter.Text = Common.GetSystemSetting(Setting.GlobalPrinterName);//RALLY DE9744
            }
        }

        private void chkCrateServer_CheckedChanged(object sender, EventArgs e)
        {
            txtCrateServer.Enabled = !chkCrateServer.Checked;
            if (chkCrateServer.Checked)
            {
                txtCrateServer.Text = Common.GetSystemSetting(Setting.CrateServerAddress);//RALLY DE9744
            }
        }

        private void chkLogLevel_CheckedChanged(object sender, EventArgs e)
        {
            cboLogLevel.Enabled = !chkLogLevel.Checked;
            if (chkLogLevel.Checked)
            {
                cboLogLevel.SelectedIndex = Math.Max(0, Math.Min(Common.ParseInt(Common.GetSystemSetting(Setting.LoggingLevel)), 7));//RALLY DE9744
            }
        }

        private void chkReceiptPrinter_CheckedChanged(object sender, EventArgs e)
        {
            txtReceiptPrinter.Enabled = !chkReceiptPrinter.Checked;
            if (grpCaller.Enabled && chkCallerReceiptPrinter.Checked != chkReceiptPrinter.Checked)
            {
                chkCallerReceiptPrinter.Checked = chkReceiptPrinter.Checked;
            }
            if (chkReceiptPrinter.Checked)
            {
                txtReceiptPrinter.Text = Common.GetOpSetting(Setting.POSReceiptPrinterName);
            }
        }

        private void chkCallerReceiptPrinter_CheckedChanged(object sender, EventArgs e)
        {
            textCallerReceiptPrinter.Enabled = !chkCallerReceiptPrinter.Checked;
            if (grpPOS.Enabled && chkReceiptPrinter.Checked != chkCallerReceiptPrinter.Checked)
            {
                chkReceiptPrinter.Checked = chkCallerReceiptPrinter.Checked;
            }
            if (chkCallerReceiptPrinter.Checked)
            {
                textCallerReceiptPrinter.Text = Common.GetOpSetting(Setting.POSReceiptPrinterName);
            }
        }

        private void textCallerReceiptPrinter_TextChanged(object sender, EventArgs e)
        {
            if (grpPOS.Enabled && string.Compare(textCallerReceiptPrinter.Text, txtReceiptPrinter.Text) != 0)
            {
                txtReceiptPrinter.Text = textCallerReceiptPrinter.Text;
            }
        }

        private void txtReceiptPrinter_TextChanged(object sender, EventArgs e)
        {
            if (grpCaller.Enabled && string.Compare(textCallerReceiptPrinter.Text, txtReceiptPrinter.Text) != 0)
            {
                textCallerReceiptPrinter.Text = txtReceiptPrinter.Text;
            }
        }
        private void chkSellElectronics_CheckedChanged(object sender, EventArgs e)
        {
            cboSellElectronics.Enabled = !chkSellElectronics.Checked;
            if (chkSellElectronics.Checked)
            {
                cboSellElectronics.SelectedIndex = Common.GetOpSetting(Setting.SellElectronics).Equals(bool.TrueString) ? 1 : 0;
            }
        }

        // PDTS 584
        private void chkCashDrawerEjectCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCashDrawerEjectCode.Enabled = !chkCashDrawerEjectCode.Checked;
            if (chkCashDrawerEjectCode.Checked)
            {
                txtCashDrawerEjectCode.Text = Common.GetOpSetting(Setting.CashDrawerEjectCode);
            }
        }

        private void checkReceiptCopies_CheckedChanged(object sender, EventArgs e)
        {
            numReceiptCopies.Enabled = !checkReceiptCopies.Checked;
            if (checkReceiptCopies.Checked)
            {
                numReceiptCopies.Value = Common.ParseInt(Common.GetOpSetting(Setting.PrintRegisterReceiptsNumber));
            }
        }

        private void checkShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            checkShowCursor.Enabled = !chkUseCursor.Checked;
            if (chkUseCursor.Checked)
            {
                checkShowCursor.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.ShowMouseCursor));//RALLY DE9744
            }
        }

        // PDTS 1064
        private void chkMagCardReaderMode_CheckedChanged(object sender, EventArgs e)
        {
            cboMagCardReaderMode.Enabled = !chkMagCardReaderMode.Checked;
            txtCardReaderIPAddress.Enabled = !chkMagCardReaderMode.Checked;
            txtCardReaderPort.Enabled = !chkMagCardReaderMode.Checked;
            txtCardTrack.Enabled = !chkMagCardReaderMode.Checked;
            if (chkMagCardReaderMode.Checked)
            {
                int mode = 0;
                int.TryParse(Common.GetOpSetting(Setting.MagneticCardReaderMode), out mode);

                if (mode > 0)
                    mode--;

                if (mode >= 0 && mode <= cboMagCardReaderMode.Items.Count - 1)
                    cboMagCardReaderMode.SelectedIndex = mode;

                string settings = Common.GetOpSetting(Setting.MagneticCardReaderParameters);

                switch ((MagneticCardReaderMode)(cboMagCardReaderMode.SelectedIndex + 1))
                {
                    default:
                    case MagneticCardReaderMode.KeyboardOnly:
                        // We don't care about values.
                        txtCardReaderIPAddress.Text = string.Empty;
                        txtCardReaderPort.Text = string.Empty;
                        txtCardTrack.Text = string.Empty;
                        break;

                    case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                        try
                        {
                            string address;
                            int port;
                            short track;

                            CPCLPrinterTCPSource.SettingsFromString(settings, out address, out port, out track);

                            txtCardReaderIPAddress.Text = address;
                            txtCardReaderPort.Text = port.ToString();
                            txtCardTrack.Text = track.ToString();
                        }
                        catch
                        {
                            txtCardReaderIPAddress.Text = string.Empty;
                            txtCardReaderPort.Text = string.Empty;
                            txtCardTrack.Text = string.Empty;
                        }
                        break;
                }
            }
        }

        private void cboMagCardReaderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((MagneticCardReaderMode)(cboMagCardReaderMode.SelectedIndex + 1))
            {
                default:
                case MagneticCardReaderMode.KeyboardOnly:
                    lblCardReaderAddress.Visible = false;
                    txtCardReaderIPAddress.Visible = false;
                    lblCardReaderPort.Visible = false;
                    txtCardReaderPort.Visible = false;
                    lblCardTrack.Visible = false;
                    txtCardTrack.Visible = false;
                    break;

                case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                    lblCardReaderAddress.Visible = true;
                    txtCardReaderIPAddress.Visible = true;
                    lblCardReaderPort.Visible = true;
                    txtCardReaderPort.Visible = true;
                    lblCardTrack.Visible = true;
                    txtCardTrack.Visible = true;
                    break;
            }
        }

        private void MachineSettingsDlg_Resize(object sender, EventArgs e)
        {
            int intFormHeight = 0;
            intFormHeight = this.Height;

            this.btnCancel.Top = intFormHeight - this.btnCancel.Height - 40;
            this.btnSave.Top = intFormHeight - this.btnSave.Height - 40;
        }

        private void chkScreenWidth_CheckedChanged_1(object sender, EventArgs e)
        {
            numScreenWidth.Enabled = !chkScreenWidth.Checked;
            if (chkScreenWidth.Checked)
            {
                numScreenWidth.Value = Common.ParseInt(Common.GetOpSetting(Setting.ScreenWidth));
            }
        }

        private void chkScreenHeight_CheckedChanged_1(object sender, EventArgs e)
        {
            numScreenHeight.Enabled = !chkScreenHeight.Checked;
            if (chkScreenHeight.Checked)
            {
                numScreenHeight.Value = Common.ParseInt(Common.GetOpSetting(Setting.ScreenHeight));
            }
        }

        private void chkRefreshRate_CheckedChanged_1(object sender, EventArgs e)
        {
            numRefreshRate.Enabled = !chkRefreshRate.Checked;
            if (chkRefreshRate.Checked)
            {
                numRefreshRate.Value = Common.ParseInt(Common.GetOpSetting(Setting.RefreshRate));
            }
        }

        private void chkDisplayScenes_CheckedChanged_1(object sender, EventArgs e)
        {
            lvAllowableScenes.Enabled = chkIsActive.Checked;
            cboDefaultScene.Enabled = chkIsActive.Checked;
            cboVideoSettings.Enabled = chkIsActive.Checked;
        }

        private void chkUseVirtualDefault_CheckedChanged(object sender, EventArgs e)
        {
            //            string strTemp;
            chkUseVirtualFlashboardCamera.Enabled = !chkUseVirtualDefault.Checked;
            if (chkUseVirtualDefault.Checked)
            {
                chkUseVirtualFlashboardCamera.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.UseVirtualFlashboardCamera));  //RALLY DE9427 RALLY DE9744
            }
        }

        private void chkScreenSaverTimeout_CheckedChanged(object sender, EventArgs e)
        {
            numScreenSaverTimeout.Enabled = !chkScreenSaverTimeout.Checked;

            ScreenSaverTimeoutLabel.Enabled = !chkScreenSaverTimeout.Checked;  //RALLY DE2873: Screen saver timeout
            if (chkScreenSaverTimeout.Checked)
            {
                numScreenSaverTimeout.Value = Common.ParseInt(Common.GetSystemSetting(Setting.ScreenSaverTimeout));//RALLY DE9744
            }
        }

        private void chkMinBallTimeDefault_CheckedChanged(object sender, EventArgs e)
        {
            numMinBallCallTime.Enabled = !chkMinBallTimeDefault.Checked;

            label23.Enabled = !chkMinBallTimeDefault.Checked;
            if (chkMinBallTimeDefault.Checked)
            {
                numMinBallCallTime.Value = Common.ParseInt(Common.GetSystemSetting(Setting.BallImageMinDisplayTime));//US4727
            }
        }

        private void chkAnticipationDefault_CheckedChanged(object sender, EventArgs e)
        {
            rdChangeBallColor.Enabled = !chkAnticipationDefault.Checked;
            rdChangeBGColor.Enabled = !chkAnticipationDefault.Checked;
            rdNextBallOnly.Enabled = !chkAnticipationDefault.Checked;

            if (chkAnticipationDefault.Checked)
            {
                m_AnticipationType = Convert.ToInt32(Common.GetSystemSetting(Setting.DisplayNextBall));

                if (m_AnticipationType == 1)
                {
                    rdChangeBallColor.Checked = true;
                }
                else if (m_AnticipationType == 2)
                {
                    rdNextBallOnly.Checked = true;
                }
                else
                {
                    rdChangeBGColor.Checked = true;
                }
            }
        }

        private void chkCbbScannerPort_CheckedChanged(object sender, EventArgs e)
        {
            numCBBScannerPort.Enabled = !chkCbbScannerPort.Checked;
            if (chkCbbScannerPort.Checked)
            {
                numCBBScannerPort.Value = Common.ParseInt(Common.GetSystemSetting(Setting.CBBScannerPort));
            }
        }

        private void chkCbbScannerType_CheckedChanged(object sender, EventArgs e)
        {
            cboCbbScannerType.Enabled = !chkCbbScannerType.Checked;
            if (chkCbbScannerType.Checked)
            {
                cboCbbScannerType.SelectedIndex = Common.ParseInt(Common.GetSystemSetting(Setting.CbbScannerType));
            }
        }

      
        private bool LoadScenes()
        {
            int intReturnVal = GetScenes();
            List<Business.SceneItem> lstScenes = objGetScenes.listScenes;
            lvAllowableScenes.Items.Clear();

            if (intReturnVal == 0)
            {
                foreach (Business.SceneItem mItem in lstScenes)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = mItem.pSceneName.ToString();
                    lvi.SubItems.Add(mItem.pSceneID.ToString());
                    lvi.Checked = false;
                    foreach (string sItem in lstAllowableScenes)
                    {
                        if (mItem.pSceneID.ToString() == sItem.ToString())
                        {
                            lvi.Checked = true;
                            break;
                        }
                    }
                    if (m_accrualEnabled == false)
                    {
                        if (mItem.pSceneID != 9)
                        {
                            lvAllowableScenes.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        lvAllowableScenes.Items.Add(lvi);
                    }

                }

                RefreshCombo();
                return true;
            }
            else
            {
                if (lstCboDefaultScenes != null)
                {
                    lstCboDefaultScenes.Clear();
                }

                return false;
            }
        }

        private void PopAllowableScenesList()
        {
            //this is a list of SceneIDs
            if (lstAllowableScenes != null)
            {
                lstAllowableScenes.Clear();
            }

            string[] arScenes = m_AllowableScenes.Split(',');
            foreach (string strItem in arScenes)
            {
                lstAllowableScenes.Add(strItem.Trim());
            }
        }

        private Business.GenericCBOItem FindItemByValue(int selectedVal, string strCBOName)
        {
            Business.GenericCBOItem objReturn = null;
            ComboBox cComboBox = null;

            foreach (Control xControl in this.groupAdaptorSettings.Controls)
            {
                if (xControl.Name == strCBOName)
                {
                    cComboBox = (ComboBox)xControl;
                    break;
                }
            }

            if (cComboBox != null)
            {
                for (int i = 0; i < cComboBox.Items.Count; i++)
                {
                    objReturn = (Business.GenericCBOItem)cComboBox.Items[i];
                    if (objReturn.CBOValueMember == selectedVal)
                    {
                        break;
                    }
                }
            }
            return objReturn;
        }

        private void RefreshCombo()
        {
            if (lstCboDefaultScenes != null)
            {
                lstCboDefaultScenes.Clear();
                buttonSetAccruals.Visible = false;
            }

            cboDefaultScene.DataSource = null;

            for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
            {
                if (lvAllowableScenes.Items[i] != null && lvAllowableScenes.Items[i].Checked)
                {
                    Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
                    cboItem.CBODisplayMember = lvAllowableScenes.Items[i].Text;
                    cboItem.CBOValueMember = Convert.ToInt32(lvAllowableScenes.Items[i].SubItems[1].Text);
                    if (cboItem.CBOValueMember == 9)
                    {
                        buttonSetAccruals.Visible = true;
                    }
                    lstCboDefaultScenes.Add(cboItem);
                }
            }

            cboDefaultScene.DataSource = lstCboDefaultScenes;
            cboDefaultScene.DisplayMember = "CBODisplayMember";
            cboDefaultScene.ValueMember = "CBOValueMember";

            PopCboDefaultScene();
        }

        private void PopCboDefaultScene()
        {
            try
            {
                //Display the selected item
                Business.GenericCBOItem cboItem = FindItemByValue(Convert.ToInt32(m_DefaultScene), "cboDefaultScene");
                if (cboItem != null)
                {
                    cboDefaultScene.SelectedIndex = cboDefaultScene.Items.IndexOf(cboItem);
                }
                else
                {
                    cboDefaultScene.SelectedIndex = -1;
                }
            }
            catch
            {
                cboDefaultScene.SelectedIndex = -1;
            }
        }

        private void MachineSettingsDlg_Load(object sender, EventArgs e)
        {
            lvAllowableScenes.Columns.Add("Scene Name", lvAllowableScenes.Width, HorizontalAlignment.Left);
            lvAllowableScenes.Columns.Add("SceneID", 0, HorizontalAlignment.Left);
        }


        private void lvAllowableScenes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //We do not want this event to fire the lvMotif_ItemCheck event
            m_boolColumnClickFlag = true;

            lvAllowableScenes.ListViewItemSorter = Sorter;
            if (!(lvAllowableScenes.ListViewItemSorter is Business.ListViewSorter))
                return;
            Sorter = (Business.ListViewSorter)lvAllowableScenes.ListViewItemSorter;

            if (Sorter.LastSort == e.Column)
            {
                if (lvAllowableScenes.Sorting == SortOrder.Ascending)
                    lvAllowableScenes.Sorting = SortOrder.Descending;
                else
                    lvAllowableScenes.Sorting = SortOrder.Ascending;
            }
            else
            {
                lvAllowableScenes.Sorting = SortOrder.Descending;
            }
            Sorter.ByColumn = e.Column;

            lvAllowableScenes.Sort();

            m_boolColumnClickFlag = false;
        }

        //START RALLY DE 4009
        private void btnCancel_Leave(object sender, EventArgs e)
        {
            txtClientInstallDrive.Focus();
        }

        private void cboMagCardReaderMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboMagCardReaderMode.SelectedIndex == 0)
            {
                SetCardParametersVisible(false);
            }
            else if (cboMagCardReaderMode.SelectedIndex == 1)
            {
                SetCardParametersVisible(true);
            }
        }

        //START RALLY US1594
        private void cboVideoAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentRemoteConfiguration();
            MachineCapabilites machineCapability = cboVideoAdapter.SelectedItem as MachineCapabilites;
            cboVideoSettings.Items.Clear();
            cboVideoSettings.Items.AddRange(machineCapability.AdapterResoultions.ToArray());
            RemoteDisplayConfiguration remoteDisplayConfiguration = m_remoteDisplayConfigurations.Find(i => i.AdaptorID == machineCapability.AdapterNumber);
            if (remoteDisplayConfiguration == null)
            {
                remoteDisplayConfiguration = new RemoteDisplayConfiguration();
                remoteDisplayConfiguration.AdaptorEnabled = true;
                remoteDisplayConfiguration.AdaptorID = machineCapability.AdapterNumber;
                remoteDisplayConfiguration.AllowedScenes = string.Empty;
                remoteDisplayConfiguration.DefaultScene = 0;
                remoteDisplayConfiguration.EnabledAccruals = string.Empty;
                remoteDisplayConfiguration.MachineID = m_arrMachines[0].nMachineId;
                remoteDisplayConfiguration.Resolution = string.Empty;
                m_remoteDisplayConfigurations.Add(remoteDisplayConfiguration);
            }
            m_currentRemoteDisplayConfiguration = remoteDisplayConfiguration;
            m_DefaultScene = remoteDisplayConfiguration.DefaultScene.ToString();
            m_AllowableScenes = remoteDisplayConfiguration.AllowedScenes;
            chkIsActive.Checked = remoteDisplayConfiguration.AdaptorEnabled;

            PopAllowableScenesList();
            LoadScenes();
            PopCboDefaultScene();

            if (cboVideoSettings.Items.Count > 0)
            {
                cboVideoSettings.SelectedItem = remoteDisplayConfiguration.Resolution;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void SetCurrentRemoteConfiguration()
        {
            if (m_currentRemoteDisplayConfiguration != null)
            {
                m_currentRemoteDisplayConfiguration.AdaptorEnabled = chkIsActive.Checked;
                m_currentRemoteDisplayConfiguration.DefaultScene = GetDefaultScene();
                m_currentRemoteDisplayConfiguration.EnabledAccruals = string.Empty;
                m_currentRemoteDisplayConfiguration.AllowedScenes = GetAllowedScenes();
                if (cboVideoSettings.SelectedItem != null)
                {
                    m_currentRemoteDisplayConfiguration.Resolution = cboVideoSettings.SelectedItem.ToString();
                }
                else if (cboVideoSettings.Items.Count > 0)
                {
                    m_currentRemoteDisplayConfiguration.Resolution = cboVideoSettings.Items[0].ToString();
                }
                else
                {
                    m_currentRemoteDisplayConfiguration.Resolution = string.Empty;
                }
                int index = m_remoteDisplayConfigurations.FindIndex(i => i.AdaptorID == m_currentRemoteDisplayConfiguration.AdaptorID);
                if (index != -1)
                {
                    m_remoteDisplayConfigurations[index] = m_currentRemoteDisplayConfiguration;
                }
            }
        }

        private string GetAllowedScenes()
        {
            string allowableScenes = string.Empty;

            //get Allowable Scenes
            for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
            {
                if (lvAllowableScenes.Items[i].Checked)
                {
                    allowableScenes = allowableScenes + lvAllowableScenes.Items[i].SubItems[1].Text + ",";
                }
            }

            //remove last comma
            if (allowableScenes.Length > 0)
            {
                allowableScenes = allowableScenes.Substring(0, allowableScenes.Length - 1);
            }

            if (!string.IsNullOrEmpty(allowableScenes))
                return allowableScenes;

            return "1";
        }

        private int GetDefaultScene()
        {
            Business.GenericCBOItem cboItem = (Business.GenericCBOItem)cboDefaultScene.SelectedItem;
            int defaultSceneID = 1;
            if (cboItem != null)
            {
                m_DefaultScene = cboItem.CBOValueMember.ToString();
            }
            else
            {
                for (int i = 0; i < lvAllowableScenes.Items.Count; i++)
                {
                    if (lvAllowableScenes.Items[i].Checked)
                    {
                        m_DefaultScene = lvAllowableScenes.Items[i].SubItems[1].Text;
                        break;
                    }
                }
            }
            if (int.TryParse(m_DefaultScene, out defaultSceneID))
            {
                return defaultSceneID;
            }
            return 1;
        }

        private void lvAllowableScenes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!m_boolColumnClickFlag)
            {
                RefreshCombo();
            }
        }

        private void buttonSetAccruals_Click(object sender, EventArgs e)
        {
            int machineid = m_arrMachines[0].nMachineId;
            int operatorId = Common.OperatorId;
            int adaptorId;
            MachineCapabilites machineCapability = cboVideoAdapter.SelectedItem as MachineCapabilites;
            if (machineCapability != null)
            {
                adaptorId = machineCapability.AdapterNumber;

                AccrualSceneDialog accrualSceneDialog = new AccrualSceneDialog(m_accrualDisplayItems.FindAll(i => i.AdapterID == adaptorId), m_accrualList, machineid, operatorId, adaptorId);
                accrualSceneDialog.ShowDialog(this);//RALLY DE8859
                if (accrualSceneDialog.DialogResult == DialogResult.OK)
                {
                    PopulateAccrualDisplayItems();
                }
            }
        }

        private void PopulateAccrualDisplayItems()
        {
            m_GetAccrualDisplayItemsMsg = new GetAccrualDisplayItems(m_arrMachines[0].nMachineId, Common.OperatorId);
            try
            {
                m_GetAccrualDisplayItemsMsg.Send();
                m_accrualDisplayItems = m_GetAccrualDisplayItemsMsg.AccrualDisplayItems;
            }
            catch (Exception e)
            {
                MessageForm.Show(this, string.Format(Resources.GetMachineSettingsFailed, e));
            }
        }

        //START RALLY US1897
        private void chkShowPayoutAmountDefault_CheckedChanged(object sender, EventArgs e)
        {
            //            string strTemp;
            //chkUseVirtualFlashboardCamera.Enabled = !chkUseVirtualDefault.Checked;
            chkShowPayoutAmounts.Enabled = !chkShowPayoutAmountDefault.Checked;
            if (chkShowPayoutAmountDefault.Checked)
            {
                chkShowPayoutAmounts.Checked = Common.ParseBool(Common.GetOpSetting(Setting.ShowPayoutAmount));  //RALLY DE9427
            }
        }

        private void chkbxTicketPrinter_CheckedChanged(object sender, EventArgs e)
        {
            txtbxKioskTicketPrinterName.Enabled = !chkbxTicketPrinter.Checked;
        }

        private void chkbxBillAcceptor_CheckedChanged(object sender, EventArgs e)
        {
            cboKioskBillAcceptorComPort.Enabled = !chkbxBillAcceptor.Checked;
        }

        //private void chkSellElectronics_CheckedChanged(object sender, EventArgs e)
        //{
        //    cboSellElectronics.Enabled = !chkSellElectronics.Checked;
        //    if (chkSellElectronics.Checked)
        //    {
        //        cboSellElectronics.SelectedIndex = Common.GetOpSetting(Setting.SellElectronics).Equals(bool.TrueString) ? 1 : 0;
        //    }
        //}

        //END RALLY US1897
        //END RALLY US1594
        //END RALLY DE 4009

        private void chkUseGameDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGameDefault.Checked && cboGameSoundsOutput.Items.Count > 0)
                m_currentGameAudioAdapterId = cboGameSoundsOutput.SelectedIndex = 0;
            cboGameSoundsOutput.Enabled = !chkUseGameDefault.Checked;
        }

        private void chkUseTvDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTvDefault.Checked && cboTvSoundsOutput.Items.Count > 0)
                m_currentTvAudioAdapterId = cboTvSoundsOutput.SelectedIndex = 0;
            cboTvSoundsOutput.Enabled = !chkUseTvDefault.Checked;
        }

        private void cboGameSoundsOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_currentGameAudioAdapterId = cboGameSoundsOutput.SelectedIndex;
        }

        private void cboTvSoundsOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_currentTvAudioAdapterId = cboTvSoundsOutput.SelectedIndex;
        }

        private void chkAllowedTenders_CheckedChanged(object sender, EventArgs e)
        {
            clbAllowedTenders.Enabled = !chkAllowedTenders.Checked;
        }

        private void chkCallerBallCamera_CheckedChanged(object sender, EventArgs e)
        {
            cboCameraChannel.Enabled = !chkCallerBallCamera.Checked;
        }

        private void checkPaymentProcessorEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaymentProcessorEnabled.Checked)
            {
                chkPaymentProcessingEnabled.Enabled = false;
                chkPaymentProcessingEnabled.Checked = Common.ParseBool(Common.GetOpSetting(Setting.PaymentProcessingEnabled));
            }
            else
            {
                chkPaymentProcessingEnabled.Enabled = true;
            }
        }

        private void checkPaymentProcessorAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaymentProcessorAddress.Checked)
            {
                txtPaymentProcessorAddress.Enabled = false;
                txtPaymentProcessorAddress.Text = Common.GetOpSetting(Setting.PaymentDeviceAddress);
            }
            else
            {
                txtPaymentProcessorAddress.Enabled = true;
            }
        }

        private void checkPaymentProcessorPort_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaymentProcessorPort.Checked)
            {
                txtPaymentProcessorPort.Enabled = false;
                txtPaymentProcessorPort.Text = Common.GetOpSetting(Setting.PaymentDevicePort);
            }
            else
            {
                txtPaymentProcessorPort.Enabled = true;
            }
        }

 

     

    }//class
}
