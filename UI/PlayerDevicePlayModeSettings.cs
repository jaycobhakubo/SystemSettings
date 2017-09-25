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
        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }

        public PlayerDevicePlayModeSettings()
        {
            InitializeComponent();
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();
            // m_devices = GetDeviceList();
            LoadTab();
            Common.EndWait();
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
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Traveler", (tempID)));
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Tracker", (tempID)));
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Explorer", (tempID)));
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Fixed Base", (tempID)));
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Traveler2", (tempID)));
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayMode.TabPages.Add(tbPageInit("Ted-E", (tempID)));
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

        private void tabCtrl_PlayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabCrtrl = (TabControl)sender;
            TabPage x = tabCrtrl.SelectedTab;
            if (x.Controls.Count == 0)
            {
                x.BackColor = Color.Transparent;
                x.BackgroundImage = Properties.Resources.GradientFull;
                PlayModeSettings y = new PlayModeSettings();
                y.DeviceId = (int)x.Tag;
                y.Dock = DockStyle.Fill;
                y.LoadSettings();
                x.Controls.Add(y);
            }
        }
    }
}
