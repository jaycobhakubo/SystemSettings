﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class RNGConfigurationSettings : SettingsControl
    {
        #region MEMBER VARIABLES
        
        private bool                                m_bModified = false;
        private List<RNGTypeData>                   m_listRemoteType;
        private List<RNGRemoteSettingsData>         m_listRemoteSettings;
        private RNGRemoteSettingsData               m_remoteSettings;
        private RNGTypeData                         m_remoteType;
        private bool                                m_isRemoteRNG;

        #endregion

        #region CONSTRUCTORS

        public RNGConfigurationSettings()
        {
            InitializeComponent();
        }
        #endregion 

        #region PUBLIC METHODS

        public override void OnActivate(object o)
        {
        }

        public override bool LoadSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();
            bool bResult = LoadRemoteRNGSettings();
            this.ResumeLayout(true);
            Common.EndWait();
            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();
            this.SuspendLayout();
            bool bResult = SaveRemoteSettings();
            this.ResumeLayout(true);
            Common.EndWait();
            return bResult;
        }

        #endregion  // Public Methods

        #region PRIVATE METHODS

        private bool LoadRemoteRNGSettings()
        {         
            populatechkbxUseInternalRNG();
            bool bResult = GetRemoteTypeSettings();
            PopulateCmbxRngTypes();
            return true;
        }

        private void populatechkbxUseInternalRNG()
        {
            var isRemoteRNG = Common.GetSystemSetting(Setting.RemoteRNG);
            m_isRemoteRNG = (isRemoteRNG == "True") ? true : false;
            //chkbxUseInternalRNG.Checked = m_isRemoteRNG;;
        }

        private bool SaveRemoteSettings()
        {
            var saveRemoteSettings = new SetRNGSettings(GetNewListRemoteSettings());
            saveRemoteSettings.Send();

            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            s.Id = (int)Setting.RemoteRNG;
            s.Value = m_isRemoteRNG.ToString();
            arrSettings.Add(s);
            // Update the server
            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

            m_bModified = false;
            return true;
        }

        private void PopulateCmbxRngTypes()
        {
            //cbxRNGTypes.Items.Clear();
            cbxRNGTypes.SelectedIndex = -1;
            cbxRNGTypes.DataSource = m_listRemoteType;
            cbxRNGTypes.DisplayMember = "RNGType";
            cbxRNGTypes.ValueMember = "RNGTypeID";
            if (cbxRNGTypes.Items.Count > 0)
            {
                cbxRNGTypes.SelectedIndex = 0;
            }
        }



        private List<RNGRemoteSettingsData> GetNewListRemoteSettings()
        {
            var newListRemoteSetting = new List<RNGRemoteSettingsData>();
            //var newRemoteSettings = new RNGRemoteSettingsData();

            m_remoteSettings.RNGTypeID = m_remoteType.RNGTypeID; //Selected rng type
            m_remoteSettings.RNGIpAddress = txtbxRNGIpAddress.Text;
            m_remoteSettings.RNGServerPort = (int)numUDRngPort.Value;

            if (chkbxSecureConnection.Checked == true)
            {
                m_remoteSettings.RNGSSLConnection = true;
            }
            else
            {
                m_remoteSettings.RNGSSLConnection = false;
            }

            m_remoteSettings.RNGRemoveSettings = false;
            m_isRemoteRNG = chkbxUseInternalRNG.Checked;
            newListRemoteSetting.Add(m_remoteSettings);
            m_listRemoteSettings = newListRemoteSetting;
            return newListRemoteSetting;
        }

       
        private void PopulateControls()
        {
            txtbxRNGIpAddress.Text = m_remoteSettings.RNGIpAddress;
            var stringtempData = m_remoteSettings.RNGServerPort.ToString();
            int result;
            if (int.TryParse(stringtempData, out result)
                 && (result <= numUDRngPort.Maximum)
                 && result >= numUDRngPort.Minimum)
            {
                numUDRngPort.Value = result;
            }
            else
            {
                numUDRngPort.Value = numUDRngPort.Minimum;
            }
            if (m_remoteSettings.RNGSSLConnection == true)
            {
                chkbxSecureConnection.Checked = true;
            }
            else
            {
                chkbxSecureConnection.Checked = false;
            }

            if (chkbxUseInternalRNG.Checked == m_isRemoteRNG)
            {
                UseInternalRNG(m_isRemoteRNG);
            }
            else
            {
                chkbxUseInternalRNG.Checked = m_isRemoteRNG;
            }
           
   
            m_bModified = false;
        }

        private void UseInternalRNG(bool isEnabled)
        {
            lblRngTypes.Enabled = isEnabled;
            cbxRNGTypes.Enabled = isEnabled;
            lblRngIPAddress.Enabled = isEnabled;
            txtbxRNGIpAddress.Enabled = isEnabled;
            lblRNGPort.Enabled = isEnabled;
            numUDRngPort.Enabled = isEnabled;
            chkbxSecureConnection.Enabled = isEnabled;
        }

        #region SERVER MESSAGE

        private bool GetRemoteTypeSettings()
        {
            var getRemoteTypes = new GetRNGRemoteTypes();
            getRemoteTypes.Send();
            m_listRemoteType = getRemoteTypes.ListRNGType;
            return true;
        }

        private bool GetRemoteSettings(/*int rngremotetypeid*/)
        {

            var getRemoteSettings = new GetRNGRemoteSettings(m_remoteType.RNGTypeID);
            getRemoteSettings.Send();
            m_listRemoteSettings = getRemoteSettings.ListRNGRemoteSettings;
            m_remoteSettings = m_listRemoteSettings.FirstOrDefault(l => l.RNGTypeID == m_remoteType.RNGTypeID);
            return true;
        }

        #endregion

        #endregion

        #region EVENTS

        //Disable / enable Internal RNG
        private void chkbxUseInternalRNG_CheckedChanged(object sender, EventArgs e)
        {
            UseInternalRNG(chkbxUseInternalRNG.Checked);        
        }

        //Selecting RNG Types in combobox
        private void cbxRNGTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRNGTypes.SelectedIndex != -1)
            {
               // m_remoteType = new RNGTypeData();// = (RNGTypeData)cbxRNGTypes.SelectedItem;
                m_remoteType = (RNGTypeData)cbxRNGTypes.SelectedItem;
                GetRemoteSettings(/*m_remoteType.RNGTypeID*/);
                PopulateControls();
            }
        }

        //Saving changes
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        //Reset changes
        private void btnReset_Click(object sender, EventArgs e)
        {
            PopulateControls();
            m_bModified = false;
        }

        //Set control modify = true
        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

        #endregion    
 

        #region PROPERTIES

        public override bool IsModified()
        {
            return m_bModified;
        }

        #endregion
    }

    #region DATA HANDLERs
    //RNG TYpes
    public class RNGTypeData
    {
        private int m_RNGTYpeId;
        private string m_RNGType;

        public int RNGTypeID 
        { 
            get{return m_RNGTYpeId;}
            set { m_RNGTYpeId = value; }
        }
        public string RNGType
        {
            get { return m_RNGType; }
            set { m_RNGType = value; } 
        }
    }

    //RNG Settings
    public class RNGRemoteSettingsData
    {
        public int      RNGTypeID { get; set; }
        public string   RNGIpAddress { get; set; }
        public int      RNGServerPort { get; set; }
        public bool     RNGSSLConnection { get; set; }
        public bool     RNGRemoveSettings { get; set; }

    }
    #endregion
}
