using System;
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
        private RNGTypeData mRNGTypeData;

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

            bool bResult = GetRNGTypeSettingsFSM();
            PopulateDataToUI_CmbxRngTypes();

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


        private void PopulateDataToUI_CmbxRngTypes()
        {
            cbxRNGTypes.Items.Clear();
            cbxRNGTypes.DataSource = getRNGRemoteTypes.ListRNGType;
            cbxRNGTypes.DisplayMember = "RNGType";
            cbxRNGTypes.ValueMember = "RNGTypeID";


            if (cbxRNGTypes.Items.Count > 0)  //Since we only have one rng type setting as of now let set the rng type setting into that
            {
                cbxRNGTypes.SelectedIndex = 0;
            }
        }


        private bool GetRNGTypeSettingsFSM()

        {
            getRNGRemoteTypes = new GetRNGRemoteTypes();
            getRNGRemoteTypes.Send();
            return true;
        }


        private void PopulateDataToUIControls()
        {
            var tempdata = new RNGRemoteSettingsData();
            tempdata = getRNGRemoteSettings.ListRNGRemoteSettings.FirstOrDefault(l => l.RNGTypeID == mRNGTypeData.RNGTypeID);
            txtbxRNGIpAddress.Text = tempdata.RNGIpAddress;

           var stringtempData = tempdata.RNGServerPort.ToString();
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
            if (tempdata.RNGSSLConnection == true)
            {
                chkbxSecureConnection.Checked = true;
            }
            else
            {
                chkbxSecureConnection.Checked = false;
            }
        }



        private bool GetRNGSettingsFromServerMessage(int rngremotetypeid)
        {
            getRNGRemoteSettings = new GetRNGRemoteSettings(1);
            getRNGRemoteSettings.Send();
            return true;
        }

        private void chkbxUseInternalRNG_CheckedChanged(object sender, EventArgs e)
        {
            var IsEnabled = chkbxUseInternalRNG.Checked;
            lblRngTypes.Enabled = IsEnabled;
            cbxRNGTypes.Enabled = IsEnabled;
            lblRngIPAddress.Enabled = IsEnabled;
            txtbxRNGIpAddress.Enabled = IsEnabled;
            lblRNGPort.Enabled = IsEnabled;
            numUDRngPort.Enabled = IsEnabled;
            chkbxSecureConnection.Enabled = IsEnabled;
          
        }

        private void cbxRNGTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mRNGTypeData = new RNGTypeData();// = (RNGTypeData)cbxRNGTypes.SelectedItem;
            mRNGTypeData = (RNGTypeData)cbxRNGTypes.SelectedItem;
             GetRNGSettingsFromServerMessage (mRNGTypeData.RNGTypeID);
             PopulateDataToUIControls();
                          
          
        }

   
      

    }


    public class RNGTypeData
    {
        private int mRNGTYpeId;
        private string mRNGType;


        public int RNGTypeID 
        { 
            get{return mRNGTYpeId;}
            set { mRNGTYpeId = value; }
        }
        public string RNGType
        {
            get { return mRNGType; }
            set { mRNGType = value; } 
        }


    }

    public class RNGRemoteSettingsData
    {
        public int RNGTypeID { get; set; }
        public string RNGIpAddress { get; set; }
        public int RNGServerPort { get; set; }
        public bool RNGSSLConnection { get; set; }
       // public bool RNGRemoveSettings { get; set; }

    }
}

