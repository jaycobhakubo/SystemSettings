using System;
using System.Collections.Generic;
using System.Globalization;
using GTI.Modules.Shared;

//US4848: Add signature lines to void receipts

namespace GTI.Modules.SystemSettings.UI
{
	public partial class ReceiptSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

        public class CardRangeItem
        {
            public int value;
            public string description;

            public CardRangeItem(int value, string desc)
            {
                this.value = value;
                description = desc;
            }

            public override string ToString()
            {
                return description;
            }
        }

		public ReceiptSettings()
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

			bool bResult = LoadReceiptSettings();

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveReceiptSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion // Public Methods


		// Private Routines
		#region Private Routines
		private bool LoadReceiptSettings()
		{
			// Fill in the operator global settings
			SettingValue tempSettingValue;
		    
            //START RALLY TA 5745 Play with paper settings are global
            bool saveFlagEnabled = false;
            Common.GetSystemSettings();
            //END RALLY TA 5745

            string globalSettingValue;
            chkPrintFacesToGlobalPrinter.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.PrintFacesToGlobalPrinter)); //RALLY DE9427 //RALLY DE 4075

            Common.GetOpSettingValue(Setting.PrintIncompleteTransactionReceipt, out tempSettingValue);
            chkPrintIncompleteTransactionReceipts.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PrintPlayerID, out tempSettingValue);
            chkPrintPlayerID.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.IncompleteTransactionReceiptText1, out tempSettingValue);
            txtIncompleteSale1.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.IncompleteTransactionReceiptText2, out tempSettingValue);
            txtIncompleteSale2.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.VoidingWithClosedSessionMode, out tempSettingValue);
            m_cboClosedSessionVoidMode.SelectedIndex = Common.ParseInt(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PrintPlayerIdentityAsAccountNumber, out tempSettingValue);
            chkPrintAccount.Checked = Common.ParseBool(tempSettingValue.Value);

            Common.GetOpSettingValue(Setting.PrintReceiptSortedByPackageType, out tempSettingValue);
            chkSortReceipt.Checked = Common.ParseBool(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.PrintStaffFirstNameOnly, out tempSettingValue);
            chkPrintStaffFirstNameOnly.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
			
			Common.GetOpSettingValue(Setting.PrintPointInfo, out tempSettingValue);
            chkPrintPointInfo.Checked = Common.ParseBool(tempSettingValue.Value); //RALLY DE9427
            
			Common.GetOpSettingValue(Setting.PrintPlayerSignatureLine, out tempSettingValue);
            chkPrintSignatureLine.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427

            Common.GetOpSettingValue(Setting.PrintNonElectronicReceipts, out tempSettingValue);
            chkPrintNonelecReceipts.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427

            Common.GetOpSettingValue(Setting.CompactPaperPacksSold, out tempSettingValue);
            chkCompactPaperInfo.Checked = Common.ParseBool(tempSettingValue.Value);
            
            // PDTS 964
            Common.GetOpSettingValue(Setting.PrintProductNames, out tempSettingValue);
            chkPrintProductNames.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427

            Common.GetOpSettingValue(Setting.PrintOperatorInfoOnReceipt, out tempSettingValue);
            chkPrintOperatorInfo.Checked = Common.ParseBool(tempSettingValue.Value);

            //RALLY US2139
            Common.GetOpSettingValue(Setting.PrintPointsRedeemed, out tempSettingValue);
            chkPrintPlayerPointsRedeemed.Checked = Common.ParseBool(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.CardFacePointSize, out tempSettingValue);
			numCardFacePointSize.Value = ParseInt(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.PrintRegisterReceiptsNumber, out tempSettingValue);
			numCopies.Value = ParseInt(tempSettingValue.Value);

            //ttp 50202
            Common.GetOpSettingValue(Setting.NumberOfPayoutReceipts, out tempSettingValue);
            numPayoutCopies.Value = ParseInt(tempSettingValue.Value);

            //US4848 print voided receipt signature lines
            Common.GetOpSettingValue(Setting.PrintVoidSignatureLines, out tempSettingValue);
            var signatureLines = int.Parse(string.IsNullOrEmpty(tempSettingValue.Value) ? "0" : tempSettingValue.Value);
            if (signatureLines <= 0)
		    {
                //default value to 1 and disable numeric up down
		        numVoidSignatureLines.Value = 1;
		        numVoidSignatureLines.Enabled = false;
                chkPrintVoidSignatureLines.Checked = false;
		    }
		    else
		    {
                //set value and enable controls
                numVoidSignatureLines.Value = signatureLines;
                numVoidSignatureLines.Enabled = true;
		        chkPrintVoidSignatureLines.Checked = true;
		    }

		    // FIX : TA4750 Remove settings
            //Common.GetOpSettingValue(Setting.DisclaimerLine1, out tempSettingValue);
            //txtDisclaimer1.Text = tempSettingValue.Value;

            //Common.GetOpSettingValue(Setting.DisclaimerLine2, out tempSettingValue);
            //txtDisclaimer2.Text = tempSettingValue.Value;

            //Common.GetOpSettingValue(Setting.DisclaimerLine3, out tempSettingValue);
            //txtDisclaimer3.Text = tempSettingValue.Value;
            // END : TA4750 Remove settings

            //Rally TA 4712
		    Common.GetOpSettingValue(Setting.MultipleReceiptVoiding, out tempSettingValue);
            chkMultipleRecieptVoiding.Checked = Common.ParseBool(tempSettingValue.Value);  //RALLY DE9427
            
		    Common.GetOpSettingValue(Setting.ReceiptHeaderLine1, out tempSettingValue);
		    txtHeader1.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.ReceiptHeaderLine2, out tempSettingValue);
            txtHeader2.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.ReceiptHeaderLine3, out tempSettingValue);
            txtHeader3.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.ReceiptFooterLine1, out tempSettingValue);
            txtFooter1.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.ReceiptFooterLine2, out tempSettingValue);
            txtFooter2.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.ReceiptFooterLine3, out tempSettingValue);
            txtFooter3.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.DisclaimerLine1, out tempSettingValue);
            txtDisclaimer1.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.DisclaimerLine2, out tempSettingValue);
            txtDisclaimer2.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.DisclaimerLine3, out tempSettingValue);
            txtDisclaimer3.Text = tempSettingValue.Value;


            //DE 4240 4054
            chkPrintCardFaces.Checked = Common.ParseBool(Common.GetSystemSetting(Setting.PrintCardFaces)); //RALLY DE9427 //RALLY DE 4240
		    
            globalSettingValue = Common.GetSystemSetting(Setting.PrintCardNumbers);//RALLY DE 4054
            int printCardRanges = ParseInt(globalSettingValue);

            //START RALLY TA 5745 Play With Paper functionality added
            bool playWithPaperEnabled = Common.ParseBool(Common.GetLicenseSettingValue(LicenseSetting.PlayWithPaper)); //RALLY DE9427  //RALLY TA 7896 moved to license file settings
             
            //START RALLY DE 6226
            if (playWithPaperEnabled)
            {
                m_cboPrintCardRanges.Items.Clear();
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(2, "Print start number only"));
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(3, "Do not print on receipt"));
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(4, "Only print CBB card numbers"));

                chkPrintCardFaces.Enabled = false;
                chkPrintFacesToGlobalPrinter.Enabled = false; //RALLY DE 4075 Added this setting to be dependant on play with paper
                //RALLY DE6200 removed multiple void setting from play with paper dependancy
                if (chkPrintCardFaces.Checked || chkPrintFacesToGlobalPrinter.Checked)
                //RALLY DE6200 removed multiple void setting from play with paper dependancy
                {
                    saveFlagEnabled = true;
                }

                chkPrintCardFaces.Checked = false;
                chkPrintFacesToGlobalPrinter.Checked = false;  //RALLY DE 4075 Added this setting to be dependant on play with paper
                if (!chkPrintCardFaces.Text.EndsWith("*")) //RALLY DE 6226 text kept adding multiple receipts
                {
                    chkPrintCardFaces.Text += "*";
                    chkPrintFacesToGlobalPrinter.Text += "*";  //RALLY DE 4075 Added this setting to be dependant on play with paper
                    m_lblPrintCardRanges.Text += "*";
                }

                //RALLY DE6200 removed multiple void setting from play with paper dependancy
                if (printCardRanges < 2)
                {
                    printCardRanges = 2;
                    saveFlagEnabled = true;
                }

                m_lblPlayWithPaperDependency.Visible = true;
            }
            //START RALLY DE 6735
            else
            {
                m_cboPrintCardRanges.Items.Clear();
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(0, "Print game counts"));
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(1, "Print card numbers"));
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(3, "Do not print on receipt"));
                m_cboPrintCardRanges.Items.Add(new CardRangeItem(4, "Only print CBB card numbers"));

                if (printCardRanges == 2)
                {
                    printCardRanges = 1;
                    saveFlagEnabled = true;
                }
            }

            //select the item with printCardRanges as its value
            foreach (CardRangeItem cri in m_cboPrintCardRanges.Items)
            {
                if (cri.value == printCardRanges)
                    m_cboPrintCardRanges.SelectedItem = cri;
            }

            //END RALLY DE 6735
            //END RALLY TA 5745
			// Get the operator data
		    

			//START RALLY TA 5745
            if(saveFlagEnabled)
                SaveReceiptSettings();
            //END RALLY TA 5745

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveReceiptSettings()
		{
            //START RALLY TA 4250
            // Create a list of just these settings  
            List<SettingValue> arrSettings = new List<SettingValue>();
            SettingValue s = new SettingValue();
            //END RALLY TA 4250

			// Update the operator global settings

            Common.SetOpSettingValue(Setting.PrintPointInfo, chkPrintPointInfo.Checked.ToString());

            Common.SetOpSettingValue(Setting.PrintPlayerID, chkPrintPlayerID.Checked.ToString());

            Common.SetOpSettingValue(Setting.PrintIncompleteTransactionReceipt, chkPrintIncompleteTransactionReceipts.Checked.ToString());

            Common.SetOpSettingValue(Setting.IncompleteTransactionReceiptText1, txtIncompleteSale1.Text);
            
            Common.SetOpSettingValue(Setting.IncompleteTransactionReceiptText2, txtIncompleteSale2.Text);

            Common.SetOpSettingValue(Setting.VoidingWithClosedSessionMode, m_cboClosedSessionVoidMode.SelectedIndex.ToString());

            Common.SetOpSettingValue(Setting.PrintPlayerIdentityAsAccountNumber, chkPrintAccount.Checked.ToString());

            Common.SetOpSettingValue(Setting.PrintReceiptSortedByPackageType, chkSortReceipt.Checked.ToString());
            
            Common.SetOpSettingValue(Setting.PrintStaffFirstNameOnly, chkPrintStaffFirstNameOnly.Checked.ToString());

			Common.SetOpSettingValue(Setting.PrintPlayerSignatureLine, chkPrintSignatureLine.Checked.ToString());

            Common.SetOpSettingValue(Setting.PrintNonElectronicReceipts, chkPrintNonelecReceipts.Checked.ToString());

            Common.SetOpSettingValue(Setting.CompactPaperPacksSold, chkCompactPaperInfo.Checked.ToString());

            // PDTS 964
            Common.SetOpSettingValue(Setting.PrintProductNames, chkPrintProductNames.Checked.ToString());

			Common.SetOpSettingValue(Setting.CardFacePointSize, numCardFacePointSize.Value.ToString());

			Common.SetOpSettingValue(Setting.PrintRegisterReceiptsNumber, numCopies.Value.ToString());
            //ttp 50202
            Common.SetOpSettingValue(Setting.NumberOfPayoutReceipts, numPayoutCopies.Value.ToString());

            //US4848 save voided signature lines
            Common.SetOpSettingValue(Setting.PrintVoidSignatureLines, 
                chkPrintVoidSignatureLines.Checked ? numVoidSignatureLines.Value.ToString(CultureInfo.InvariantCulture): "0");

            // FIX : TA4750 Remove settings
            //Common.SetOpSettingValue(Setting.DisclaimerLine1, txtDisclaimer1.Text);

            //Common.SetOpSettingValue(Setting.DisclaimerLine2, txtDisclaimer2.Text);

            //Common.SetOpSettingValue(Setting.DisclaimerLine3, txtDisclaimer3.Text);
            // END : TA4750 Remove settings

            //RALLY TA 4714
		    Common.SetOpSettingValue(Setting.MultipleReceiptVoiding, chkMultipleRecieptVoiding.Checked.ToString());

		    Common.SetOpSettingValue(Setting.ReceiptHeaderLine1, txtHeader1.Text);
            Common.SetOpSettingValue(Setting.ReceiptHeaderLine2, txtHeader2.Text);
            Common.SetOpSettingValue(Setting.ReceiptHeaderLine3, txtHeader3.Text);

            Common.SetOpSettingValue(Setting.ReceiptFooterLine1, txtFooter1.Text);
            Common.SetOpSettingValue(Setting.ReceiptFooterLine2, txtFooter2.Text);
            Common.SetOpSettingValue(Setting.ReceiptFooterLine3, txtFooter3.Text);

            Common.SetOpSettingValue(Setting.DisclaimerLine1, txtDisclaimer1.Text);
            Common.SetOpSettingValue(Setting.DisclaimerLine2, txtDisclaimer2.Text);
            Common.SetOpSettingValue(Setting.DisclaimerLine3, txtDisclaimer3.Text);

            //RALLY US2139
            Common.SetOpSettingValue(Setting.PrintPointsRedeemed, chkPrintPlayerPointsRedeemed.Checked.ToString());
		    //START RALLY TA 5745 changed card ranges from a text box to a combo box with three values
            //START RALLY DE4250  Setting Print Faces to global printer is now a global setting
            //START RALLY DE4052  Setting print card faces is now a global setting

            Common.SetOpSettingValue(Setting.PrintCardNumbers, ((CardRangeItem)(m_cboPrintCardRanges.SelectedItem)).value.ToString());
            Common.SetOpSettingValue(Setting.PrintFacesToGlobalPrinter, chkPrintFacesToGlobalPrinter.Checked.ToString());
            Common.SetOpSettingValue(Setting.PrintCardFaces, chkPrintCardFaces.Checked.ToString());
            
            Common.SetOpSettingValue(Setting.PrintOperatorInfoOnReceipt, chkPrintOperatorInfo.Checked.ToString());
           
            s.Id = (int)Setting.PrintCardNumbers;
            s.Value = ((CardRangeItem)(m_cboPrintCardRanges.SelectedItem)).value.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PrintFacesToGlobalPrinter;
            s.Value = chkPrintFacesToGlobalPrinter.Checked.ToString();
            arrSettings.Add(s);

            s.Id = (int)Setting.PrintCardFaces;
            s.Value = chkPrintCardFaces.Checked.ToString();
            arrSettings.Add(s);

            //END RALLY DE4250
            //END RALLY DE4052
            //END RALLY TA 5745
            // Update the operator data

            //Save the global settings

            if (!Common.SaveSystemSettings(arrSettings.ToArray()))
            {
                return false;
            }

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
			{
				return false;
			}

            // Save the Hall Settings
            if (!Common.SaveHallSettings())
            {
                return false;
            }

			// Set the flag
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

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

        //US4848
        private void chkPrintVoidSignatureLines_CheckedChanged(object sender, EventArgs e)
        {
            //set on modified flag
            m_bModified = true;

            numVoidSignatureLines.Enabled = chkPrintVoidSignatureLines.Checked;
        }
	} // end class
} // end namespace

