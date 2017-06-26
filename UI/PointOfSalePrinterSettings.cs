using System;
using System.Collections.Generic;
using GTI.Modules.Shared;

//US5104: System Settings: Move Printer settings

namespace GTI.Modules.SystemSettings.UI
{
    public partial class PointOfSalePrinterSettings : SettingsControl
    {
        bool m_bModified;

        #region Public Methods
        public PointOfSalePrinterSettings()
        {
            InitializeComponent();
        }

        public override bool IsModified()
        {
            return m_bModified;
        }

        public override void OnActivate(object o)
        {
            
        }

        public override bool LoadSettings() 
        {
            Common.BeginWait();
            SuspendLayout();

            bool bResult = LoadPrinterSettings();

            ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SavePrinterSettings();

            Common.EndWait();

            return bResult;
        }

        #endregion // Public Methods

        #region Private Routines

        private bool LoadPrinterSettings()
        {
            SettingValue tempSettingValue;
            if (Common.GetSystemSettings() == false)
            {
                return false;
            }

            Common.GetOpSettingValue(Setting.POSReceiptPrinterName, out tempSettingValue);
            txtReceiptPrinter.Text = tempSettingValue.Value;

            //START RALLY DE7282
            string receiptPrinter = Common.GetSystemSetting(Setting.GlobalPrinterName);
            txtGlobalPrinter.Text = receiptPrinter;

            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool SavePrinterSettings()
        {
            List<SettingValue> pSettings = new List<SettingValue>();
            SettingValue s = new SettingValue
            {
                Id = (int) Setting.GlobalPrinterName,
                Value = txtGlobalPrinter.Text
            };

            //START RALLY DE7282
            pSettings.Add(s);

            Common.SetOpSettingValue(Setting.POSReceiptPrinterName, txtReceiptPrinter.Text);

            // Save the operator settings
            if (!Common.SaveOperatorSettings())
            {
                return false;
            }

            if (!Common.SaveSystemSettings(pSettings.ToArray()))
            {
                return false;
            }

            m_bModified = false;

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        #endregion
    }
}
