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
        #region MEMBER VARIABLES
        private bool m_bModified = false;
        private GetRNGRemoteTypes getRNGRemoteTypes;
        private GetRNGRemoteSettings getRNGRemoteSettings;     
        private RNGTypeData mRNGTypeData;      
        #endregion

        #region CONSTRUCTORS
        public RNGConfigurationSettings()
        {
            InitializeComponent();
        }
        #endregion 

        #region PUBLIC METHODS

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

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveRNGSettings();

            Common.EndWait();

            return bResult;
        }
        #endregion  // Public Methods

        #region PRIVATE METHODS
        private bool SaveRNGSettings()
        {
            SetRNGSettings tSetRngSettings = new  SetRNGSettings (GetNewValue());
            tSetRngSettings.Send();
            return true;
        }

        private void PopulateDataToUI_CmbxRngTypes()
        {
            cbxRNGTypes.Items.Clear();
            cbxRNGTypes.DataSource = getRNGRemoteTypes.ListRNGType;
            cbxRNGTypes.DisplayMember = "RNGType";
            cbxRNGTypes.ValueMember = "RNGTypeID";
            if (cbxRNGTypes.Items.Count > 0) cbxRNGTypes.SelectedIndex = 0;                                       
        }

        #region SERVER MESSAGE
        private bool GetRNGTypeSettingsFSM()
        {
            getRNGRemoteTypes = new GetRNGRemoteTypes();
            getRNGRemoteTypes.Send();
            return true;
        }

        private bool GetRNGSettingsFromServerMessage(int rngremotetypeid)
        {
            getRNGRemoteSettings = new GetRNGRemoteSettings(mRNGTypeData.RNGTypeID);
            getRNGRemoteSettings.Send();
            return true;
        }

        private List<RNGRemoteSettingsData> GetNewValue()
        {
            var mListRNGSettingData = new List<RNGRemoteSettingsData>();
            var NewRNGSettings = new RNGRemoteSettingsData();
            NewRNGSettings.RNGTypeID = mRNGTypeData.RNGTypeID; //Selected rng type
            NewRNGSettings.RNGIpAddress = txtbxRNGIpAddress.Text;
            NewRNGSettings.RNGServerPort = (int)numUDRngPort.Value;
            if (chkbxSecureConnection.Checked == true)
            {
                NewRNGSettings.RNGSSLConnection = true;
            }
            else
            {
                NewRNGSettings.RNGSSLConnection = false;
            }

            NewRNGSettings.RNGRemoveSettings = false;
            mListRNGSettingData.Add(NewRNGSettings);
            return mListRNGSettingData;
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

        #endregion
        #endregion

        #region EVENTS
        //Disable / enable Internal RNG
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

        //Selecting RNG Types in combobox
        private void cbxRNGTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mRNGTypeData = new RNGTypeData();// = (RNGTypeData)cbxRNGTypes.SelectedItem;
            mRNGTypeData = (RNGTypeData)cbxRNGTypes.SelectedItem;
            GetRNGSettingsFromServerMessage (mRNGTypeData.RNGTypeID);
            PopulateDataToUIControls();                                    
        }

        //Saving changes
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #endregion
    }

    #region DATA HANDLERs
    //RNG TYpes
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

    //RNG Settings
    public class RNGRemoteSettingsData
    {
        public int RNGTypeID { get; set; }
        public string RNGIpAddress { get; set; }
        public int RNGServerPort { get; set; }
        public bool RNGSSLConnection { get; set; }
        public bool RNGRemoveSettings { get; set; }

    }
    #endregion
}

