using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Data;


namespace GTI.Modules.SystemSettings.UI
{
    public partial class PlayerDeviceSettings : SettingsControl
    {
        private Device[] m_devices;
        private PlayerSettings selectedPlayerSettings;

        public PlayerDeviceSettings()
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();         
        }

        public override void OnActivate(object o)
        {

        }


        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            LoadTab();
            LoadDefaultTab();

            this.ResumeLayout(true);
            Common.EndWait();
            return true;
        }
      
        private void LoadDefaultTab()
        {
            selectedPlayerSettings = plyrSettingDefault;
            selectedPlayerSettings.DeviceId = 0;
            selectedPlayerSettings.LoadSettings();
        }

        private void LoadTab()
        {
            int tempID;
            tabCtrl_PlayerSettingDevice.TabPages.Clear();
            tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgDefault);

            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)
            {                
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgTraveler);
                        plyeSettingTraveler.DeviceId = Device.Traveler.Id;
                        plyeSettingTraveler.LoadSettings();
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgTracker);
                        plyrSettingTracker.DeviceId = Device.Tracker.Id;
                        plyrSettingTracker.LoadSettings();
                     
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgExplorer2);
                        plyrSettingExplorer2.DeviceId = Device.Explorer.Id;
                        plyrSettingExplorer2.LoadSettings();
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgFixedBase);
                        plyrSettingFixedBase.DeviceId = Device.Fixed.Id;
                        plyrSettingFixedBase.LoadSettings();
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgTraveler2);
                        plyrSettingTraveler2.DeviceId = Device.Traveler2.Id;
                        plyrSettingTraveler2.LoadSettings();
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbpgTedE);
                        plyrSettingTedE.DeviceId = Device.Tablet.Id;
                        plyrSettingTedE.LoadSettings();
                    }
                }
            }
        }
        
        private Device[] GetDeviceList()
        {
            // Get device types
            GetDeviceTypeDataMessage msg = new GetDeviceTypeDataMessage();
            try
            {
                msg.Send();
            }
            catch (Exception ex)
            {
                MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, ex.Message));
            }
            // Check return code
            if (msg.ServerReturnCode != GTIServerReturnCode.Success)
            {
                MessageForm.Show(this, string.Format(Properties.Resources.GetDeviceTypesFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
            }
            var devices = msg.Devices;
            return devices;
        }

        private PlayerSettings SetSelectedDevice(int p_deviceId)
        {
                if (p_deviceId == 0)
                {
                     selectedPlayerSettings = plyrSettingDefault;
                }
                else if (p_deviceId == Device.Traveler.Id)
                {
                     selectedPlayerSettings = plyeSettingTraveler;
                }
                else if (p_deviceId == Device.Tracker.Id)
                { 
                    selectedPlayerSettings = plyrSettingTracker;
                }
                else if (p_deviceId == Device.Fixed.Id)
                {
                    selectedPlayerSettings = plyrSettingFixedBase;
                }
                else if (p_deviceId == Device.Explorer.Id)
                {
                    selectedPlayerSettings = plyrSettingExplorer2;
                }
                else if (p_deviceId == Device.Traveler2.Id)
                {
                    selectedPlayerSettings = plyrSettingTraveler2;
                }
                else if (p_deviceId == Device.Tablet.Id)
                {
                    selectedPlayerSettings = plyrSettingTedE;
                }
                return selectedPlayerSettings;
        }

        private void tabCtrl_PlayerSettingDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.BeginWait();
            this.SuspendLayout();

            var tabCrtrl = (TabControl)sender;
            TabPage tTabPage = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(tTabPage.Tag);
            SetSelectedDevice(DeviceId);     
        
            this.ResumeLayout(true);
            Common.EndWait();                                
        }

        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }   
    }
}
