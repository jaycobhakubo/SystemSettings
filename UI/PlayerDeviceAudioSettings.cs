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
    public partial class PlayerDeviceAudioSettings : UserControl
    {
        private Device[] m_devices;
        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }

        public PlayerDeviceAudioSettings()
        {
            InitializeComponent();
        }

        public override bool LoadSettings()
        {
            // m_devices = GetDeviceList();
            LoadTab();
            return true;
        }

        private void LoadTab()
        {
            int tempID;
            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)//knc
            {
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Traveler"));
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Tracker"));
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Explorer"));
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Fixed Base"));
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Traveler2"));
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Ted-E"));
                    }
                }
            }
        }
    }
}
