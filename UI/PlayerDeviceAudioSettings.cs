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
    public partial class PlayerDeviceAudioSettings : SettingsControl
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

        private AudioSettings m_AudioSettingsSelected; 

        public override bool LoadSettings()
        {
            // m_devices = GetDeviceList();
            Common.BeginWait();
            this.SuspendLayout();
            LoadTab();
            LoadDefaultTab();   
            Common.EndWait();
            return true;
        }

        private void LoadDefaultTab()
        {
            m_AudioSettingsSelected = audioSettingDefault;
            m_AudioSettingsSelected.DeviceId = 0;
            m_AudioSettingsSelected.LoadSettings();
        }

        private void LoadTab()
        {
            int tempID;
            tabCtrl_AudioDevice.TabPages.Clear();
            tabCtrl_AudioDevice.TabPages.Add(tbpgDefault);

            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)//knc
            {
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                         tabCtrl_AudioDevice.TabPages.Add(tbpgTraveler);
                         audioSettingsTraveler.DeviceId = Device.Traveler.Id;
                         audioSettingsTraveler.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Traveler", (tempID)));
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTracker);
                        audioSettingsTracker.DeviceId = Device.Tracker.Id;
                        audioSettingsTracker.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Tracker", (tempID)));
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgExplorer2);
                        audioSettingsExplorer2.DeviceId = Device.Explorer.Id;
                        audioSettingsExplorer2.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Explorer", (tempID)));
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgFixedBase);
                        audioSettingsFixedBase.DeviceId = Device.Fixed.Id;
                        audioSettingsFixedBase.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Fixed Base", (tempID)));
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTraveler2);
                        audioSettingsTraveler2.DeviceId = Device.Traveler2.Id;
                        audioSettingsTraveler2.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Traveler2", (tempID)));
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTedE);
                        audioSettingsTedE.DeviceId = Device.Tablet.Id;
                        audioSettingsTedE.LoadSettings();
                        //tabCtrl_AudioDevice.TabPages.Add(tbPageInit("Ted-E", (tempID)));
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

            if (tabCtrl_AudioDevice.TabPages.Count == 0)
            {
                x.BackColor = Color.Transparent;
                x.BackgroundImage = Properties.Resources.GradientFull;                
                AudioSettings y = new AudioSettings();
                y.DeviceId = DeviceId;
                y.Dock = DockStyle.Fill;
                y.LoadSettings();
                x.Controls.Add(y);
            }
            return x;
        }

        private AudioSettings SetSelectedDevice(int deviceId)
        {
            if (deviceId == 0)
            {
                m_AudioSettingsSelected = audioSettingDefault;
            }
            else
                if (deviceId == Device.Traveler.Id)
                {
                    m_AudioSettingsSelected = audioSettingsTraveler;
                }
                else
                    if (deviceId == Device.Tracker.Id)
                    {
                        m_AudioSettingsSelected = audioSettingsTracker;
                    }
                    else
                        if (deviceId == Device.Fixed.Id)
                        {
                            m_AudioSettingsSelected = audioSettingsFixedBase;
                        }
                        else
                            if (deviceId == Device.Explorer.Id)
                            {
                                m_AudioSettingsSelected = audioSettingsExplorer2;
                            }
                            else
                                if (deviceId == Device.Traveler2.Id)
                                {
                                    m_AudioSettingsSelected = audioSettingsTraveler2;
                                }
                                else
                                    if (deviceId == Device.Tablet.Id)
                                    {
                                        m_AudioSettingsSelected = audioSettingsTedE;
                                    }

            return m_AudioSettingsSelected;
        }

        private void tabCtrl_AudioDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var tabCrtrl = (TabControl)sender;
            //TabPage x = tabCrtrl.SelectedTab;
            //if (x.Controls.Count == 0)
            //{
            //    x.BackColor = Color.Transparent;
            //    x.BackgroundImage = Properties.Resources.GradientFull;
            //    AudioSettings y = new AudioSettings();
            //    y.DeviceId = (int)x.Tag;
            //    y.Dock = DockStyle.Fill;
            //    y.LoadSettings();
            //    x.Controls.Add(y);
            //}
            var tabCrtrl = (TabControl)sender;
            TabPage x = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(x.Tag);
            SetSelectedDevice(DeviceId);                           
        }
    }
}
