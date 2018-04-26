using System;
using System.Collections.Generic;
using System.Globalization;
using GTI.Modules.Shared;

//US5103: System Settings: Move CBB settings

namespace GTI.Modules.SystemSettings.UI
{
    public partial class CrystalBallSettings : SettingsControl
    {
        bool m_bModified;

        #region Public Methods
        public CrystalBallSettings()
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

            bool bResult = LoadCbbSettings();

            ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            // Validate
            if (!ValidateInput())
            {
                return false;
            }

            Common.BeginWait();

            bool bResult = SaveCbbSettings();

            Common.EndWait();

            return bResult;
        }

        #endregion // Public Methods

        #region Private Routines

        private bool LoadCbbSettings()
        {
            //START RALLY TA 6095 CBB enabled/disabled
            if (Common.CBBEnabled)
            {
                SettingValue tempSettingValue;
                Common.GetOpSettingValue(Setting.CBBScannerPort, out tempSettingValue);
                numCBBScannerPort.Value = ParseDecimal(tempSettingValue.Value);

                Common.GetOpSettingValue(Setting.CBBSheetDefinition, out tempSettingValue);
                txtCBBDefFile.Text = tempSettingValue.Value;

                Common.GetOpSettingValue(Setting.CBBPlayItSheetType, out tempSettingValue);
                //ATD: Values will be 1 or 2; therefore, subtract 1
                cboPlayItSheet.SelectedIndex = Math.Min(4, Math.Max(0, ParseInt(tempSettingValue.Value) - 1));// Rally US505 - Create the ability to sell CBB cards

                //Rally: DE2317 Changed from a check box that allows PlayItSheets to be either on or off
                //to a combo box that allows selecting either electronic or paper or both setting selected.
                Common.GetOpSettingValue(Setting.PrintCBBCardsToPlayItSheet, out tempSettingValue);
                cboPrintCBBCardsToPlayitSheet.SelectedIndex = Math.Min(3, Math.Max(0, ParseInt(tempSettingValue.Value)));//RALLY TA8689 Create setting between thermal and non thermal

                chkEnableCBBFavorites.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.EnableCBBFavorites)); // US2418

                //Common.GetOpSettingValue(Setting.CbbScannerType, out tempSettingValue);
                cboCbbScannerType.SelectedIndex = Common.ParseInt(Common.GetSystemSetting(Setting.CbbScannerType)) + 1; // US2418
            }
            else
            {
                grpCBB.Visible = false;
                chkEnableCBBFavorites.Visible = false;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool SaveCbbSettings()
        {
            List<SettingValue> pSettings = new List<SettingValue>();
            SettingValue value = new SettingValue
            {
                Id = (int) Setting.EnableCBBFavorites,
                Value = chkEnableCBBFavorites.Checked.ToString()
            };

            SettingValue cbbScannerType = new SettingValue
            {
                Id = (int)Setting.CbbScannerType,
                Value = (cboCbbScannerType.SelectedIndex - 1).ToString()
            };

            //US2418 
            //US2418
            pSettings.Add(value);
            pSettings.Add(cbbScannerType);

            Common.SetOpSettingValue(Setting.CBBScannerPort, numCBBScannerPort.Value.ToString(CultureInfo.InvariantCulture));

            Common.SetOpSettingValue(Setting.CBBSheetDefinition, txtCBBDefFile.Text);

            //ATD: SelectedIndex values will be 0 or 1; therefore, add 1
            Common.SetOpSettingValue(Setting.CBBPlayItSheetType, Convert.ToString(cboPlayItSheet.SelectedIndex + 1));

            //Rally: DE2317 Changed from a text box to a combo box
            Common.SetOpSettingValue(Setting.PrintCBBCardsToPlayItSheet, Convert.ToString(cboPrintCBBCardsToPlayitSheet.SelectedIndex));
            
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

        private bool ValidateInput()
        {
            // Validate CBB settings
            if (grpCBB.Visible)
            {
                if (txtCBBDefFile.Text.Length == 0)
                {
                    MessageForm.Show(this, "Please enter a valid CBB def file.");
                    txtCBBDefFile.Select();
                    return false;
                }
            }

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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }
    }
}
