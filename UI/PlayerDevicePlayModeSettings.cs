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
    public partial class PlayerDevicePlayModeSettings : SettingsControl
    {
        private Device[] m_devices;
        private PlayModeSettings selectedPlayModeSettings;

        public PlayerDevicePlayModeSettings()
        {
            InitializeComponent();
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
            selectedPlayModeSettings = playModeSettingsDefault;
            selectedPlayModeSettings.DeviceId = 0;
            selectedPlayModeSettings.LoadSettings();
        }

        private void LoadTab()
        {
            int tempID;
            tabCtrl_PlayMode.TabPages.Clear();
            tabCtrl_PlayMode.TabPages.Add(tbpgDefault);

            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)
            {
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTraveler);
                        playModeSettingsTraveler.DeviceId = Device.Traveler.Id;                    
                        playModeSettingsTraveler.LoadSettings();                 
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTracker);
                        playModeSettingsTracker.DeviceId = Device.Tracker.Id;
                        playModeSettingsTracker.LoadSettings();                    
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgExplorer2);
                        playModeSettingsExplorer2.DeviceId = Device.Explorer.Id;
                        playModeSettingsExplorer2.LoadSettings();
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgFixedBase);
                        playModeSettingsFixedBase.DeviceId = Device.Fixed.Id;
                        playModeSettingsFixedBase.LoadSettings();                   
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTraveler2);
                        playModeSettingsTraveler2.DeviceId = Device.Traveler2.Id;
                        playModeSettingsTraveler2.LoadSettings();                    
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTedE);
                        playModeSettingsTedE.DeviceId = Device.Tablet.Id;
                        playModeSettingsTedE.LoadSettings();                     
                    }
                }
            }
        }

        private PlayModeSettings SetSelectedDevice(int deviceId)
        {
            if (deviceId == 0)
            {
                selectedPlayModeSettings = playModeSettingsDefault;
            }
            else
            if (deviceId == Device.Traveler.Id)
            {
                selectedPlayModeSettings = playModeSettingsTraveler;
            }
            else
            if (deviceId == Device.Tracker.Id)
            {
                selectedPlayModeSettings = playModeSettingsTracker;
            }
            else
            if (deviceId == Device.Fixed.Id)
            {
                selectedPlayModeSettings = playModeSettingsFixedBase;
            }
            else
            if (deviceId == Device.Explorer.Id)
            {
                selectedPlayModeSettings = playModeSettingsExplorer2;
            }
            else
            if (deviceId == Device.Traveler2.Id)
            {
                selectedPlayModeSettings = playModeSettingsTraveler2;
            }
            else
            if (deviceId == Device.Tablet.Id)
            {
                selectedPlayModeSettings = playModeSettingsTedE;
            }
            return selectedPlayModeSettings;
        }

        private void tabCtrl_PlayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.BeginWait();
            this.SuspendLayout();

            var tabCrtrl = (TabControl)sender;
            TabPage tTablPageSelected = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(tTablPageSelected.Tag);
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
