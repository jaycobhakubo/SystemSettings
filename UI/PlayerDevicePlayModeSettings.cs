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

            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)//knc
            {
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTraveler);
                        playModeSettingsTraveler.DeviceId = Device.Traveler.Id;                    
                        playModeSettingsTraveler.LoadSettings();
                        //tabCtrl_PlayMode.TabPages.Add(tbPageInit("Traveler", (tempID)));
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTracker);
                        playModeSettingsTracker.DeviceId = Device.Tracker.Id;
                        playModeSettingsTracker.LoadSettings();
                       // tabCtrl_PlayMode.TabPages.Add(tbPageInit("Tracker", (tempID)));
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgExplorer2);
                        playModeSettingsExplorer2.DeviceId = Device.Explorer.Id;
                        playModeSettingsExplorer2.LoadSettings();
                        //tabCtrl_PlayMode.TabPages.Add(tbPageInit("Explorer", (tempID)));
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgFixedBase);
                        playModeSettingsFixedBase.DeviceId = Device.Fixed.Id;
                        playModeSettingsFixedBase.LoadSettings();
                        //tabCtrl_PlayMode.TabPages.Add(tbPageInit("Fixed Base", (tempID)));
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTraveler2);
                        playModeSettingsTraveler2.DeviceId = Device.Traveler2.Id;
                        playModeSettingsTraveler2.LoadSettings();
                        //tabCtrl_PlayMode.TabPages.Add(tbPageInit("Traveler2", (tempID)));
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbpgTedE);
                        playModeSettingsTedE.DeviceId = Device.Tablet.Id;
                        playModeSettingsTedE.LoadSettings();
                        //tabCtrl_PlayMode.TabPages.Add(tbPageInit("Ted-E", (tempID)));
                    }
                }
            }
        }

        private TabPage tbPageInit(string DeviceName, int DeviceId)
        {
            var x = new TabPage();
            x.Text = DeviceName;
            x.Name = DeviceName;
            x.Tag = DeviceId;

            if (tabCtrl_PlayMode.TabPages.Count == 0)
            {
                x.BackColor = Color.Transparent;
                x.BackgroundImage = Properties.Resources.GradientFull;
                PlayModeSettings y = new PlayModeSettings();
                y.DeviceId = DeviceId;
                y.Dock = DockStyle.Fill;
                y.LoadSettings();
                x.Controls.Add(y);
            }
            return x;
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
            var tabCrtrl = (TabControl)sender;
            TabPage x = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(x.Tag);
            SetSelectedDevice(DeviceId);       
        }

        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }
    }
}
