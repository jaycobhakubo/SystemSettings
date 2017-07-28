using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class ThirdPartyInterfaceSettings : SettingsControl
    {
        public enum InterfaceFor
        {
            InternalEdgeTracking = 0,
            AristocratOasis10 = 1,
            AristocratOasis11 = 1001,
            BoydBConnect = 2,
            BallyACSC13 = 1002,
            IGTADICRM = 3,
            BallyCMP = 4,
            BallyACSC = 5,
            FortunetFNET = 6,
            KonamiSYNKROS = 7
        };

        public class InterfaceData
        {
            public string name = string.Empty;
            public InterfaceFor interfaceFor;

            public override string ToString()
            {
                return name;
            }
        }

        //Members
        bool m_bModified = false;

        //Public Methods
        #region Public Methods
        public ThirdPartyInterfaceSettings()
        {
            InitializeComponent();

            if (!Common.IsAdmin)
                cbInterface.Enabled = false;

            InterfaceData i = new InterfaceData();
            i.name = "Internal EDGE system";
            i.interfaceFor = InterfaceFor.InternalEdgeTracking;
            cbInterface.Items.Add(i);

//            i = new InterfaceData();
//            i.name = "Aristocrat Oasis 10";
//            i.interfaceFor = InterfaceFor.AristocratOasis10;
//            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Aristocrat Oasis 11 & 12";
            i.interfaceFor = InterfaceFor.AristocratOasis11;
            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Boyd BConnect";
            i.interfaceFor = InterfaceFor.BoydBConnect;
            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Bally ACSC 13.3";
            i.interfaceFor = InterfaceFor.BallyACSC13;
            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "IGT ADI CRM";
            i.interfaceFor = InterfaceFor.IGTADICRM;
            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Bally CMP";
            i.interfaceFor = InterfaceFor.BallyCMP;
            cbInterface.Items.Add(i);

//            i = new InterfaceData();
//            i.name = "Bally ACSC";
//            i.interfaceFor = InterfaceFor.BallyACSC;
//            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Fortunet FNET";
            i.interfaceFor = InterfaceFor.FortunetFNET;
            cbInterface.Items.Add(i);

            i = new InterfaceData();
            i.name = "Konami SYNKROS";
            i.interfaceFor = InterfaceFor.KonamiSYNKROS;
            cbInterface.Items.Add(i);

            cbInterface_SelectedIndexChanged(null, new EventArgs()); //draw the screen

            gbOasis10.Location = gbPIN.Location; //move the Oasis 10 group box over the PIN group box
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
            this.SuspendLayout();

            bool bResult = LoadThirdPartySettings();

            this.ResumeLayout(true);
            Common.EndWait();

            return bResult;
        }

        public override bool SaveSettings()
        {
            Common.BeginWait();

            bool bResult = SaveThirdPartySettings();

            Common.EndWait();

            return bResult;
        }

        #endregion // Public Methods

        // Private Routines
        #region Private Routines 

        private InterfaceFor GetTheInterface(int index = -100)
        {
            int i = index;

            if(i == -100) //use current selection
                i = cbInterface.SelectedIndex;

            if (i < 0 || i >= cbInterface.Items.Count)
                i = GetIndexForInterface(InterfaceFor.InternalEdgeTracking);

            return ((InterfaceData)cbInterface.Items[i]).interfaceFor;
        }

        private int GetIndexForInterface(InterfaceFor theInterface)
        {
            for (int x = 0; x < cbInterface.Items.Count; x++)
            {
                if (((InterfaceData)cbInterface.Items[x]).interfaceFor == theInterface)
                    return x;
            }

            return -1;
        }

        private bool LoadThirdPartySettings()
        {
            SettingValue tempSettingValue;
            int tempInt;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceID, out tempSettingValue);
            if (Int32.TryParse(tempSettingValue.Value, out tempInt))
            {
                int index = GetIndexForInterface((InterfaceFor)tempInt);

                if(index == -1)
                    index = GetIndexForInterface(InterfaceFor.InternalEdgeTracking);

                cbInterface.SelectedIndex = index;
            }
            else
            {
                cbInterface.SelectedIndex = GetIndexForInterface(InterfaceFor.InternalEdgeTracking);
            }

            Common.GetOpSettingValue(Setting.ThirdPartyTimeout, out tempSettingValue);
            if(Int32.TryParse(tempSettingValue.Value, out tempInt))
                thirdPartyTimeout.Value = tempInt/1000;
            else
                thirdPartyTimeout.Value = 5;

            thirdPartyLocation.Text = Common.GetSystemSetting(Setting.ThirdPartyLocation);

            Common.GetOpSettingValue(Setting.ThirdPartyPointScaleNumerator, out tempSettingValue);
            if(Int32.TryParse(tempSettingValue.Value, out tempInt))
                thirdPartyEarnPoints.Value = tempInt;
            else
                thirdPartyEarnPoints.Value = 1;

            Common.GetOpSettingValue(Setting.ThirdPartyPointScaleDenominator, out tempSettingValue);
            if(Int32.TryParse(tempSettingValue.Value, out tempInt))
                thirdPartyEarnPerPennies.Value = Convert.ToDecimal(tempInt) / 100M;
            else
                thirdPartyEarnPerPennies.Value = 1;

            Common.GetOpSettingValue(Setting.ThirdPartyRedeemNumerator, out tempSettingValue);
            if (Int32.TryParse(tempSettingValue.Value, out tempInt))
                thirdPartyRedeemPennies.Value = Convert.ToDecimal(tempInt) / 100M;
            else
                thirdPartyRedeemPennies.Value = 1;

            Common.GetOpSettingValue(Setting.ThirdPartyRedeemDenominator, out tempSettingValue);
            if(Int32.TryParse(tempSettingValue.Value, out tempInt))
                thirdPartyRedeemPerPoints.Value = tempInt;
            else
                thirdPartyRedeemPerPoints.Value = 1;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceID, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'C' || tempSettingValue.Value[0] == 'c')
                rbControlTimeout.Checked = true;
            else if (tempSettingValue.Value[0] == 'S' || tempSettingValue.Value[0] == 's')
                rbSlaveTimeout.Checked = true;
            else if(tempSettingValue.Value[0] == 'I' || tempSettingValue.Value[0] == 'i')
                rbIndependentTimeouts.Checked = true;
            else
                rbControlTimeout.Checked = true;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceExternalRating, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbExternalRating.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbExternalRating.Checked = true;
            else
                cbExternalRating.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfacePINLength, out tempSettingValue);
            if(Int32.TryParse(tempSettingValue.Value, out tempInt))
            {
                if(tempInt >= nudPINLength.Minimum && tempInt <= nudPINLength.Maximum)
                    nudPINLength.Value = tempInt;
                else
                    nudPINLength.Value = 4;
            }
            else
            {
                nudPINLength.Value = 4;
            }

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForPlayerInfo, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForPlayerInfo.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForPlayerInfo.Checked = true;
            else
                cbPINForPlayerInfo.Checked = false;
            
            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForPoints, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForPointInfo.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForPointInfo.Checked = true;
            else
                cbPINForPointInfo.Checked = false;
            
            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForRating, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForRating.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForRating.Checked = true;
            else
                cbPINForRating.Checked = false;
            
            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForRedemption, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForRedemption.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForRedemption.Checked = true;
            else
                cbPINForRedemption.Checked = false;
            
            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForRatingVoid, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForVoidRating.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForVoidRating.Checked = true;
            else
                cbPINForVoidRating.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceNeedPINForRedemptionVoid, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPINForVoidRedemption.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPINForVoidRedemption.Checked = true;
            else
                cbPINForVoidRedemption.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbGetPINAtCardSwipe.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbGetPINAtCardSwipe.Checked = true;
            else
                cbGetPINAtCardSwipe.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfacePlayerInfoHasPoints, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPlayerInfoHasPoints.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPlayerInfoHasPoints.Checked = true;
            else
                cbPlayerInfoHasPoints.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollars, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPointsTransferAsDollars.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPointsTransferAsDollars.Checked = true;
            else
                cbPointsTransferAsDollars.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollarsForRatings, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPointsTransferAsDollarsForSales.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPointsTransferAsDollarsForSales.Checked = true;
            else
                cbPointsTransferAsDollarsForSales.Checked = false;

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollarsForRedemptions, out tempSettingValue);
            if (tempSettingValue.Value[0] == 'F' || tempSettingValue.Value[0] == 'f')
                cbPointsTransferAsDollarsForRedemptions.Checked = false;
            else if (tempSettingValue.Value[0] == 'T' || tempSettingValue.Value[0] == 't')
                cbPointsTransferAsDollarsForRedemptions.Checked = true;
            else
                cbPointsTransferAsDollarsForRedemptions.Checked = false;

            cbPointsTransferAsDollarsForRedemptions_CheckedChanged(null, new EventArgs());

            Common.GetOpSettingValue(Setting.ThirdPartyPlayerSyncMode, out tempSettingValue);
            if (Int32.TryParse(tempSettingValue.Value, out tempInt))
            {
                if (tempInt >= 0 && tempInt < cbxPlayerSyncMode.Items.Count) //in range, use it
                    cbxPlayerSyncMode.SelectedIndex = tempInt;
                else //default to real-time
                    cbxPlayerSyncMode.SelectedIndex = 0;
            }
            else
            {
                cbxPlayerSyncMode.SelectedIndex = 0;
            }

            //set the initial labels for point/points
            thirdPartyEarnPoints_ValueChanged(null, new EventArgs());
            thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

            m_bModified = false;

            return true;
        }

        private bool SaveThirdPartySettings()
        {
            List<SettingValue> tpiSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();

            s.Id = (int)Setting.ThirdPartyTimeout;
            s.Value = (thirdPartyTimeout.Value*1000).ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyLocation;
            s.Value = thirdPartyLocation.Text;
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyPointScaleNumerator;
            s.Value = thirdPartyEarnPoints.Value.ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyPointScaleDenominator;
            s.Value = ((int)(thirdPartyEarnPerPennies.Value*100)).ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyRedeemNumerator;
            s.Value = ((int)(thirdPartyRedeemPennies.Value*100)).ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyRedeemDenominator;
            s.Value = thirdPartyRedeemPerPoints.Value.ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceID;
            s.Value = ((int)GetTheInterface()).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceTimeoutOption;
            if (rbIndependentTimeouts.Checked)
                s.Value = "Independent";
            else if (rbSlaveTimeout.Checked)
                s.Value = "Slave";
            else
                s.Value = "Control";
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceExternalRating;
            s.Value = (cbExternalRating.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfacePINLength;
            s.Value = nudPINLength.Value.ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped;
            s.Value = (cbGetPINAtCardSwipe.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForPlayerInfo;
            s.Value = (cbPINForPlayerInfo.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForPoints;
            s.Value = (cbPINForPointInfo.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRating;
            s.Value = (cbPINForRating.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRedemption;
            s.Value = (cbPINForRedemption.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRatingVoid;
            s.Value = (cbPINForVoidRating.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRedemptionVoid;
            s.Value = (cbPINForVoidRedemption.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfacePlayerInfoHasPoints;
            s.Value = (cbPlayerInfoHasPoints.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollars;
            s.Value = (cbPointsTransferAsDollars.Checked).ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollarsForRedemptions;
            s.Value = (cbPointsTransferAsDollarsForRedemptions.Checked).ToString();
            tpiSettings.Add(s);
            
            s.Id = (int)Setting.ThirdPartyPlayerInterfacePointsTransferedAsDollarsForRatings;
            s.Value = (cbPointsTransferAsDollarsForSales.Checked).ToString();
            tpiSettings.Add(s);

            s.Id = (int)Setting.ThirdPartyPlayerSyncMode;
            s.Value = cbxPlayerSyncMode.SelectedIndex.ToString();
            tpiSettings.Add(s);

            // Update the server
            if (!Common.SaveSystemSettings(tpiSettings.ToArray()))
                return false;

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

        #endregion //Private Routines

        private void thirdPartyRedeemPerPoints_ValueChanged(object sender, EventArgs e)
        {
            if (thirdPartyRedeemPerPoints.Value == 1)
                lblPointsFor.Text = "point has a value of";
            else
                lblPointsFor.Text = "points have a value of";

            OnModified(null, new EventArgs());
        }

        private void thirdPartyEarnPoints_ValueChanged(object sender, EventArgs e)
        {
            if (thirdPartyEarnPoints.Value == 1)
                lblPointsEarned.Text = "point for every";
            else
                lblPointsEarned.Text = "points for every";

            OnModified(null, new EventArgs());
        }

        private void cbInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show fields for this interface and set the defaults
            InterfaceFor ourInterface = GetTheInterface();

            cbExternalRating.Enabled = false;
            lblPlayerSyncMode.Visible = true;
            cbxPlayerSyncMode.Visible = true;
            cbxPlayerSyncMode.SelectedIndex = 0; //real-time
            cbxPlayerSyncMode.Enabled = Common.IsAdmin;

            switch (ourInterface)
            {
                case InterfaceFor.InternalEdgeTracking:
                {
                    lblPlayerSyncMode.Visible = false;
                    cbxPlayerSyncMode.Visible = false;

                    gbOasis10.Visible = false;

                    gbPIN.Visible = false;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    cbGetPINAtCardSwipe.Checked = false;

                    gbTimeout.Visible = false;

                    gbEarned.Visible = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    cbExternalRating.Checked = false;
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 0M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.AristocratOasis10:
                {
                    gbOasis10.Visible = Common.IsAdmin;

                    gbPIN.Visible = false;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    cbGetPINAtCardSwipe.Checked = false;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = false;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false; //true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 0M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.BoydBConnect:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = Common.IsAdmin;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = true;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    nudPINLength.Value = 4;
                    cbGetPINAtCardSwipe.Checked = cbPINForPlayerInfo.Checked;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 1;
                    thirdPartyEarnPerPennies.Value = .01M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = .01M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.IGTADICRM:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = false;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    cbGetPINAtCardSwipe.Checked = false;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = false;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false; //true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 0M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.BallyCMP:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = false;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    cbGetPINAtCardSwipe.Checked = false;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 1;
                    thirdPartyEarnPerPennies.Value = .01M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = true;

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.BallyACSC:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = Common.IsAdmin;
                    cbPINForPlayerInfo.Checked = true;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    nudPINLength.Value = 4;
                    cbGetPINAtCardSwipe.Checked = cbPINForPlayerInfo.Checked;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 1;
                    thirdPartyEarnPerPennies.Value = .01M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false; //true;

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.FortunetFNET:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = Common.IsAdmin;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    nudPINLength.Value = 4;
                    cbGetPINAtCardSwipe.Checked = cbPINForPlayerInfo.Checked;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Enabled = Common.IsAdmin;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    cbExternalRating.Checked = false;
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false; //true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 0M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = Common.IsAdmin;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.KonamiSYNKROS:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = Common.IsAdmin;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = true;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = true;
                    cbPINForVoidRating.Checked = true;
                    cbPINForVoidRedemption.Checked = false;
                    nudPINLength.Value = 4;
                    cbGetPINAtCardSwipe.Checked = cbPINForPlayerInfo.Checked;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 1M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;

                    cbPointsTransferAsDollarsForRedemptions_CheckedChanged(sender, e);
                }
                break;

                case InterfaceFor.AristocratOasis11:
                {
                    gbOasis10.Visible = false;

                    gbPIN.Visible = false;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = false;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    cbGetPINAtCardSwipe.Checked = false;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Enabled = Common.IsAdmin;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    cbExternalRating.Checked = false;
                    thirdPartyEarnPoints.Value = 0;
                    thirdPartyEarnPerPennies.Value = 1M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = false; //true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = 0M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;

                case InterfaceFor.BallyACSC13:
                {
                    cbxPlayerSyncMode.SelectedIndex = 2; //PIN, points, & updating

                    gbOasis10.Visible = false;

                    gbPIN.Visible = Common.IsAdmin;
                    cbPINForPlayerInfo.Checked = false;
                    cbPINForPointInfo.Checked = true;
                    cbPINForRating.Checked = false;
                    cbPINForRedemption.Checked = false;
                    cbPINForVoidRating.Checked = false;
                    cbPINForVoidRedemption.Checked = false;
                    nudPINLength.Value = 4;
                    cbGetPINAtCardSwipe.Checked = cbPINForPlayerInfo.Checked;

                    gbTimeout.Visible = Common.IsAdmin;
                    rbControlTimeout.Checked = true;
                    rbIndependentTimeouts.Checked = false;
                    rbSlaveTimeout.Checked = false;
                    lblTimeout1.Visible = true;
                    lblTimeout2.Visible = true;
                    thirdPartyTimeout.Value = 20;

                    gbEarned.Visible = true;
                    cbExternalRating.Checked = true;
                    cbExternalRating_CheckedChanged(null, new EventArgs());
                    thirdPartyEarnPoints.Value = 1;
                    thirdPartyEarnPerPennies.Value = .01M;
                    thirdPartyEarnPoints_ValueChanged(null, new EventArgs());

                    gbRedeemed.Visible = true;
                    thirdPartyRedeemPerPoints.Value = 1;
                    thirdPartyRedeemPennies.Value = .01M;
                    thirdPartyRedeemPerPoints_ValueChanged(null, new EventArgs());

                    gbFNET.Visible = false;
                    cbPlayerInfoHasPoints.Checked = false;
                    cbPointsTransferAsDollars.Checked = false;
                    cbPointsTransferAsDollarsForSales.Checked = false;
                    cbPointsTransferAsDollarsForRedemptions.Checked = false;
                }
                break;
            }
        }

        private void cbExternalRating_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExternalRating.Enabled)
            {
                if (cbExternalRating.Checked)
                {
                    lblEarn.Visible = false;
                    lblPointsEarned.Visible = false;
                    lblDollarSignForSpent.Visible = false;
                    lblSpent.Visible = false;
                    thirdPartyEarnPerPennies.Visible = false;
                    thirdPartyEarnPoints.Visible = false;
                }
                else
                {
                    lblEarn.Visible = true;
                    lblPointsEarned.Visible = true;
                    lblDollarSignForSpent.Visible = true;
                    lblSpent.Visible = true;
                    thirdPartyEarnPerPennies.Visible = true;
                    thirdPartyEarnPoints.Visible = true;

                    lblEarn.Enabled = true;
                    lblPointsEarned.Enabled = true;
                    lblDollarSignForSpent.Enabled = true;
                    lblSpent.Enabled = true;
                    thirdPartyEarnPerPennies.Enabled = true;
                    thirdPartyEarnPoints.Enabled = true;
                }
            }
            else //can't be changed
            {
                if (cbExternalRating.Checked)
                {
                    lblEarn.Visible = false;
                    lblPointsEarned.Visible = false;
                    lblDollarSignForSpent.Visible = false;
                    lblSpent.Visible = false;
                    thirdPartyEarnPerPennies.Visible = false;
                    thirdPartyEarnPoints.Visible = false;
                }
                else
                {
                    lblEarn.Visible = true;
                    lblPointsEarned.Visible = true;
                    lblDollarSignForSpent.Visible = true;
                    lblSpent.Visible = true;
                    thirdPartyEarnPerPennies.Visible = true;
                    thirdPartyEarnPoints.Visible = true;

                    lblEarn.Enabled = Common.IsAdmin;
                    lblPointsEarned.Enabled = Common.IsAdmin;
                    lblDollarSignForSpent.Enabled = Common.IsAdmin;
                    lblSpent.Enabled = Common.IsAdmin;
                    thirdPartyEarnPerPennies.Enabled = Common.IsAdmin;
                    thirdPartyEarnPoints.Enabled = Common.IsAdmin;
                }
            }

            OnModified(sender, new EventArgs());
        }

        private void cbPINForPlayerInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPINForPlayerInfo.Checked)
            {
                cbGetPINAtCardSwipe.Checked = true;
                cbGetPINAtCardSwipe.Enabled = false;
            }
            else
            {
                cbGetPINAtCardSwipe.Enabled = true;
            }
        }

        private void cbPointsTransferAsDollarsForRedemptions_CheckedChanged(object sender, EventArgs e)
        {
            if(GetTheInterface() == InterfaceFor.FortunetFNET)
                gbRedeemed.Visible = cbPointsTransferAsDollarsForRedemptions.Checked;

            OnModified(sender, e);
        }
    }
}
