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
        public Device[] Devices 
        { 
            get {return m_devices;}
            set { m_devices = value; }
        }

        public PlayerDeviceSettings()
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
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Traveler", (tempID)));
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Tracker", (tempID)));
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Explorer", (tempID)));
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Fixed Base", (tempID)));
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Traveler2", (tempID)));
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_PlayerSettingDevice.TabPages.Add(tbPageInit("Ted-E", (tempID)));
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

            if (tabCtrl_PlayerSettingDevice.TabPages.Count == 0)
            {
                x.BackColor = Color.Transparent;
                x.BackgroundImage = Properties.Resources.GradientFull;
                PlayerSettings y = new PlayerSettings();
                y.DeviceId = DeviceId;
                y.Dock = DockStyle.Fill;
                y.LoadSettings();
                x.Controls.Add(y);
            }
            return x;
        }


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
            return x;
        }

        private void tabCtrl_PlayerSettingDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabCrtrl = (TabControl)sender;
            TabPage x = tabCrtrl.SelectedTab;
            x.BackColor = Color.Transparent;
            x.BackgroundImage = Properties.Resources.GradientFull;
            PlayerSettings y = new PlayerSettings();
            y.DeviceId = (int)x.Tag;
            y.Dock = DockStyle.Fill;
            y.LoadSettings();
            x.Controls.Add(y);
        }
    }
}
