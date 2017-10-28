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
    public partial class PlayerDevicePlayModeSettings : SettingsControl
    {
        private Device[] m_devices;
        private PlayModeSettings selectedPlayModeSettings;

        public PlayerDevicePlayModeSettings()
        {
            InitializeComponent();
        }

        public override void OnActivate(object o)
        {

        }

        public override bool IsModified()
        {
            return selectedPlayModeSettings.IsModified();
        }
        
         public override bool SaveSettings()
        {
            bool bResult = selectedPlayModeSettings.SaveSettings();
            return bResult;
        }

        public override bool LoadSettings()
        {
      
            Common.BeginWait();
            this.SuspendLayout();

            if (selectedPlayModeSettings != null)
            {
                selectedPlayModeSettings.LoadSettings();
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


        public Device[] Devices
        {
            get { return m_devices; }
            set { m_devices = value; }
        }

        private void tabCtrl_PlayMode_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Common.BeginWait();
            this.SuspendLayout();

            var tabCrtrl = (TabControl)sender;
            TabPage tTablPageSelected = tabCrtrl.SelectedTab;
            int DeviceId = Convert.ToInt32(tTablPageSelected.Tag);
            SetSelectedDevice(DeviceId);
            selectedPlayModeSettings.LoadSettings();
            this.ResumeLayout(true);
            Common.EndWait();
        }

        private void tabCtrl_PlayMode_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (selectedPlayModeSettings != null)//Promp to save if modified
            {
                if (selectedPlayModeSettings.IsModified())
                {
                    DialogResult result = MessageForm.Show(this, Resources.SaveChangesMessage, Resources.SaveChangesHeader, MessageFormTypes.YesNoCancel);
                    this.Refresh();
                    if (result == DialogResult.Yes)
                    {
                        if (!selectedPlayModeSettings.SaveSettings())
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
                        selectedPlayModeSettings.LoadSettings();
                    }
                }
            }          
        }
    }
}
