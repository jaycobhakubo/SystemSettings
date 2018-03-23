﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.SystemSettings.Business;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class RNGConfigurationSettings : SettingsControl
    {
        #region
        private bool m_bModified = false;
        private GetRNGRemoteTypes getRNGRemoteTypes;
        private GetRNGRemoteSettings getRNGRemoteSettings;
        #endregion

        public RNGConfigurationSettings()
        {
            InitializeComponent();
        }

        // Public Methods
        #region Public Methods
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
            this.SuspendLayout();

            bool bResult = LoadRNGTypeSettings();
            bResult = LoadRNGSettings();

            LoadCmbxRngTypes();

            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        //public override bool SaveSettings()
        //{
        //    Common.BeginWait();

        //    bool bResult = SaveRaffleSettings();

        //    Common.EndWait();

        //    return bResult;
        //}
        #endregion  // Public Methods

        private bool LoadRNGTypeSettings()

        {
            getRNGRemoteTypes = new GetRNGRemoteTypes();
            getRNGRemoteTypes.Send();
            return true;
        }


        private void LoadCmbxRngTypes()
        {
            foreach (RNGTypeData rngtd in getRNGRemoteTypes.ListRNGType)
            {
                cbxRNGTypes.Items.Add(rngtd.RNGType);
            }
        }

        private bool LoadRNGSettings()
        {
            getRNGRemoteSettings = new GetRNGRemoteSettings(1);
            getRNGRemoteSettings.Send();
            return true;
        }

   


    }


    public class RNGTypeData
    {
        public int RNGTypeID { get; set; }
        public string RNGType { get; set; }
    }

    public class RNGRemoteSettingsData
    {
        public int RNGTypeID { get; set; }
        public string RNGIpAddress { get; set; }
        public int RNGServerPort { get; set; }
        public bool RNGSSLConnection { get; set; }
        public bool RNGRemoveSettings { get; set; }

    }
}


//foreach (SessionSummaryViewModes value in Enum.GetValues(typeof(SessionSummaryViewModes)))
//            {
//                Business.GenericCBOItem cboItem = new Business.GenericCBOItem();
//                cboItem.CBOValueMember = (int)value;
//                cboItem.CBODisplayMember = EnumToString.GetDescription(value);

//                m_UIModes.Add(cboItem);
//            }
//            cboUIDisplayMode.Items.Clear();
//            cboUIDisplayMode.DataSource = m_UIModes;
//            cboUIDisplayMode.DisplayMember = "CBODisplayMember";
//            cboUIDisplayMode.ValueMember = "CBOValueMember";
