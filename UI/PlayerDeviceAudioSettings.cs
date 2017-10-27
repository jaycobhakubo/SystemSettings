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
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class PlayerDeviceAudioSettings : SettingsControl
    {
        private Device[] m_devices;
        private AudioSettings m_AudioSettingsSelected; 

        public PlayerDeviceAudioSettings()
        {
            InitializeComponent();
        }

        public override void OnActivate(object o)
        {

        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            if (m_AudioSettingsSelected != null)
            {
                m_AudioSettingsSelected.LoadSettings();
            }
            else
            {
                LoadTab();
                LoadDefaultTab();
            }

            this.ResumeLayout(true);
            Common.EndWait();
            return true;
        }


        public override bool SaveSettings()
        {
            bool bResult = m_AudioSettingsSelected.SaveSettings();
            return bResult;
        }

        public override bool IsModified()
        {           
            return m_AudioSettingsSelected.IsModified();
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

            for (int iDevice = 0; iDevice < m_devices.Length; iDevice++)
            {
                if (m_devices[iDevice].LoginConnectionType == DeviceLoginConnectionType.Player)
                {
                    tempID = m_devices[iDevice].Id;

                    if (tempID == Device.Traveler.Id)
                    {
                         tabCtrl_AudioDevice.TabPages.Add(tbpgTraveler);
                         audioSettingsTraveler.DeviceId = Device.Traveler.Id;
                         audioSettingsTraveler.LoadSettings();
                    }
                    else if (tempID == Device.Tracker.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTracker);
                        audioSettingsTracker.DeviceId = Device.Tracker.Id;
                        audioSettingsTracker.LoadSettings();
                    }
                    else if (tempID == Device.Explorer.Id)//RALLY TA 7728 Changed MINI to EXPLORER
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgExplorer2);
                        audioSettingsExplorer2.DeviceId = Device.Explorer.Id;
                        audioSettingsExplorer2.LoadSettings();
                    }
                    else if (tempID == Device.Fixed.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgFixedBase);
                        audioSettingsFixedBase.DeviceId = Device.Fixed.Id;
                        audioSettingsFixedBase.LoadSettings();                      
                    }
                    else if (tempID == Device.Traveler2.Id) // Rally US765
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTraveler2);
                        audioSettingsTraveler2.DeviceId = Device.Traveler2.Id;
                        audioSettingsTraveler2.LoadSettings();                      
                    }
                    else if (tempID == Device.Tablet.Id)
                    {
                        tabCtrl_AudioDevice.TabPages.Add(tbpgTedE);
                        audioSettingsTedE.DeviceId = Device.Tablet.Id;
                        audioSettingsTedE.LoadSettings();                     
                    }
                }
            }
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

        private void tabCtrl_AudioDevice_Selecting(object sender, TabControlCancelEventArgs e)
        {       
            Common.BeginWait();
            this.SuspendLayout();

            var tabCrtrl = (TabControl)sender;
            TabPage tTabPageSelected = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(tTabPageSelected.Tag);
            SetSelectedDevice(DeviceId);

            this.ResumeLayout(true);
            Common.EndWait();
        }

        private void tabCtrl_AudioDevice_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (m_AudioSettingsSelected != null)//Promp to save if modified
            {
                if (m_AudioSettingsSelected.IsModified())
                {
                    DialogResult result = MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
                    this.Refresh();
                    if (result == DialogResult.Yes)
                    {
                        if (!m_AudioSettingsSelected.SaveSettings())
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
                        m_AudioSettingsSelected.LoadSettings();
                    }
                }
            }              
        }

        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }

    }
}
