#region copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2017 All Rights Reserved
//
// DE13417: Changed UI to use new setting as opposed to re-using old setting. Reworked logic to be the same as other setting pages
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.UI
{
    /// <summary>
    /// Encapsulates the UI for the system settings for the 'Session Summary' module
    /// </summary>
    public partial class SessionSummarySettings : SettingsControl
    {
        #region MEMBER VARIABLE

        private bool m_bModified = false;

        #endregion

        #region CONSTRUCTORS

        public SessionSummarySettings()
        {
            InitializeComponent();
        }

        #endregion

        #region METHOD OVERRIDE

        /// <summary>
        /// Returns true if any of the UI fields have been altered from their original values
        /// </summary>
        /// <returns></returns>
        public override bool IsModified()
        {
            return m_bModified;
        }

        /// <summary>
        /// Loads the settings for this UI from the server
        /// </summary>
        /// <returns></returns>
        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();

            bool bResult = LoadSessionSummarySettings();
            m_bModified = false;

            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        /// <summary>
        /// Sends the edited setting values to the server to update them
        /// </summary>
        /// <returns></returns>
        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveSessionSummarySettings();

            Common.EndWait();

            return bResult;
        }

        #endregion

        #region MEMBER METHOD

        private bool LoadSessionSummarySettings()
        {
            if (!Common.GetSystemSettings())
                return false;

            SettingValue tempSettingValue;
            bool saveFlag = false;


            // DE13417
            Common.GetOpSettingValue(Setting.SessionSummaryBankUsePreviousClose, out tempSettingValue);
            chkbxSetBankToEndBank.Checked = ParseBool(tempSettingValue.Value);


            // Set the flag
            m_bModified = false;
            if (saveFlag)
                SaveSessionSummarySettings();

            return true;
        }
        
        private bool SaveSessionSummarySettings()
        {
            // Create a list of settings to save
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.SessionSummaryBankUsePreviousClose;
            s.Value = chkbxSetBankToEndBank.Checked.ToString();
            arrSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// Actions that occur when the 'save' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Actions that occur when the 'Reset' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        /// <summary>
        /// Actions that occur when the value of a setting is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        #endregion
        
    }
}
