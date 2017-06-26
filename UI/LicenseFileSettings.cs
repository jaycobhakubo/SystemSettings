#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2013 Fortunet
//
// US428 disabling license file expiration
// US3692 Adding support for whole points
//
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class LicenseFileSettings : SettingsControl
    {
        public LicenseFileSettings()
        {
            InitializeComponent();
            //InitializeDataGridView();
            //lblExpirationDate.Text = Common.GetLicenseFileExpriationDate();
        }

        public void SetLicenseFileSettingsController()
        {
            InitializeDataGridView();
//            lblExpirationDate.Text = Common.GetLicenseFileExpriationDate();
        }
        public void InitializeDataGridView()
        {
            foreach (string propertyName in Enum.GetNames(typeof(LicenseSetting)))
            {
                
                LicenseSetting setting =(LicenseSetting) Enum.Parse(typeof(LicenseSetting), propertyName);
                if (setting != LicenseSetting.MinValueId)
                {
                    string settingValue = Common.GetLicenseSettingValue(setting);
                    string settingName = GetSettingName(setting);
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = settingName;
                    //START RALLY DE 6615 license file values not being displayed
                    if (string.IsNullOrEmpty(settingValue))
                    {
                        row.Cells[1].Value = "Not Set";
                    }
                    else
                    {
                        row.Cells[1].Value = settingValue;
                    }
                    //END RALLY DE 6615
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private string GetSettingName(LicenseSetting setting)
        {
            int settingID = (int)setting;
            string result;
            switch (settingID)
            {
                //case(1000):
                //    result = "Minimum Value ID";
                //    break;
                case (1001):
                    result = "CBB Enabled";
                    break;
                case (1002):
                    result = "Perm Version";
                    break;
                case (1003):
                    result = "Enable anonymous machine accounts";
                    break;
                case (1004):
                    result = "Main stage mode";
                    break;
                case (1005):
                    result = "Credit enabled";
                    break;
                case (1006):
                    result = "Use pre printed packs";
                    break;
                case (1007):
                    result = "Play with paper";
                    break;
                case (1008):
                    result = "Allow melange games";
                    break;
                case (1009):
                    result = "Enable 90 number bingo";
                    break;
                case (1010):
                    result = "Enable bingo RNG";
                    break;
                case (1011):
                    result = "Quick pick enabled";
                    break;
                case (1012):
                    result = "Payouts enabled";
                    break;
                case (1013):
                    result = "Force whole product points";
                    break;
                case (1014):
                    result = "Inventory center enabled";
                    break;
                case (1015):
                    result = "Enable raffle";
                    break;
                case (1016):
                    result = "Progressives enabled";
                    break;
                case (1017):
                    result = "Static drop in mode";
                    break;
                //US4230: Hide Slingo from license file settings
                //case (1018): 
                //    result = "Slingo enabled";
                //    break;
                //case (1020):
                //    result = "Slingo free space";
                //    break;
                case (1021):
                    result = "Enable non session progressives";//DE10571
                    break;
                case (1022):
                    result = "Enable TX payouts";
                    break;
                case (1023):
                    result = "Allow bank modifications";
                    break;
                case (1027):
                    result = "North Dakota mode"; //DE12701
                    break;
                default:
                    result = "Unknown setting";
                    break;
            }
            return result;
        }
    }
}
