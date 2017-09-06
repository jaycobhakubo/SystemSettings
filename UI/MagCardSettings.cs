using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class MagCardSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;

        string m_LastCardSwipe = string.Empty;

		public MagCardSettings()
		{
			InitializeComponent();
            LoadLists(); // PDTS 1064

            btnShiftFilterDown.Enabled = false;
            btnShiftFilterUp.Enabled = false;

            if (!Common.IsAdmin)
            {
                gbCardLab.Visible = false;
                gbSources.Visible = false;

                gbFilters.Left = (this.ClientSize.Width - gbFilters.Width) / 2;
                gbFilters.Top = (this.ClientSize.Height - gbFilters.Height) / 2;

                btnDelete.Visible = false;
                btnCopyFilterToLab.Visible = false;
                btnShiftFilterDown.Visible = false;
                btnShiftFilterUp.Visible = false;

                lstFilters.Width = btnCopyFilterToLab.Right - lstFilters.Left;
            }
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

			bool bResult = LoadMagCardSettings();

            if (lstFilters.Items.Count == 0)
                btnCopyFilterToLab.Enabled = false;

            cbFilter_TextUpdate(null, new EventArgs());

            lblFilterResultInfo.Text = string.Empty;
            lblFilterResultInfo.ForeColor = Color.Black;

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
            // PDTS 1064
            // Validate
            if(!ValidateMagCardInput(cboMagCardReaderMode.SelectedIndex + 1, txtReaderPort.Text, txtReaderTrack.Text))
            {
                return false;
            }

			Common.BeginWait();

			bool bResult = SaveMagCardSettings();

			Common.EndWait();

			return bResult;
		}

        // PDTS 1064
        public static bool ValidateMagCardInput(int mode, string portText, string trackText)
        {
            short track;
            int port;

            if(mode == (int)MagneticCardReaderMode.KeyboardAndCPCLTCP)
            {
                if(!int.TryParse(portText, out port) || port < System.Net.IPEndPoint.MinPort || port > System.Net.IPEndPoint.MaxPort)
                {
                    MessageForm.Show(Resources.InvalidMagCardPort);
                    return false;
                }

                if(!short.TryParse(trackText, out track))
                {
                    MessageForm.Show(Resources.InvalidMagCardTrack);
                    return false;
                }
            }

            return true;
        }
		#endregion  // Public Methods


		// Private Routines
		#region  Private Routines
        // PDTS 1064
        private void LoadLists()
        {
            // Load the Mag Card Reader Mode list.
            cboMagCardReaderMode.Items.Clear();
            cboMagCardReaderMode.Items.Add(Resources.MagCardModeKeyboard);
            cboMagCardReaderMode.Items.Add(Resources.MagCardModeCPCLTCP);

            // Select first one by default.
            cboMagCardReaderMode.SelectedIndex = 0;
        }
        //RALLY DE9062
        private void OnModified(object sender, EventArgs e)
        {
            m_bModified = true;
        }

		private void Validate(object sender, EventArgs e)
		{
			if (cbStartCard.Text != string.Empty && cbEndCard.Text != string.Empty)
			{
				btnAccept.Enabled = true;
				btnTest.Enabled = true;
			}
			else
			{
				btnAccept.Enabled = false;
				btnTest.Enabled = false;
			}

            OnModified(sender, e);
		}

		private void lstFilters_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (lstFilters.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnCopyFilterToLab.Enabled = true;

                if (lstFilters.Items.Count > 1)
                {
                    btnShiftFilterDown.Enabled = true;
                    btnShiftFilterUp.Enabled = true;
                }
            }
            else
            {
                if(lstFilters.Items.Count == 0)
                    btnDelete.Enabled = false;
            }
		}

		private bool LoadMagCardSettings()
		{
			// Fill in the operator global settings
			SettingValue tempSettingValue;

			// Get the value
			if (!Common.GetOpSettingValue(Setting.MagneticCardFilters, out tempSettingValue))
				return false;

            MSRSettings tmpSettings = new MSRSettings();

            tmpSettings.setFilters(tempSettingValue.Value);

            if (!Common.GetOpSettingValue(Setting.MSRReadTriggers, out tempSettingValue))
                return false;

            tmpSettings.setReadTriggers(tempSettingValue.Value);

            cbStartCard.Text = MSRSettings.StringToPrintable(tmpSettings.MSRStart);
            cbEndCard.Text = MSRSettings.StringToPrintable(tmpSettings.MSREnd);

			// Fill the list
			lstFilters.Items.Clear();

            foreach(string filter in tmpSettings.MSRFilters)
				lstFilters.Items.Add(filter);

            // PDTS 1064
            // Reader Mode
            if(!Common.GetOpSettingValue(Setting.MagneticCardReaderMode, out tempSettingValue))
                return false;

            int mode;

            if(!int.TryParse(tempSettingValue.Value, out mode))
                return false;

            mode--;

            if(mode < 0 || mode > cboMagCardReaderMode.Items.Count - 1)
                return false;
            else
                cboMagCardReaderMode.SelectedIndex = mode;

            mode++;

            // Reader Parameters.
            if(!Common.GetOpSettingValue(Setting.MagneticCardReaderParameters, out tempSettingValue))
                return false;

            switch((MagneticCardReaderMode)mode)
            {
                default:
                case MagneticCardReaderMode.KeyboardOnly:
                    // We don't care about values.
                    txtReaderIPAddress.Text = string.Empty;
                    txtReaderPort.Text = string.Empty;
                    txtReaderTrack.Text = string.Empty;
                    break;

                case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                    try
                    {
                        string address;
                        int port;
                        short track;

                        CPCLPrinterTCPSource.SettingsFromString(tempSettingValue.Value, out address, out port, out track);

                        txtReaderIPAddress.Text = address;
                        txtReaderPort.Text = port.ToString();
                        txtReaderTrack.Text = track.ToString();
                    }
                    catch
                    {
                        return true;
                    }
                    break;
            }

            //RALLY DE9602
            txtCardDigits.Clear();
            lblISOTracksFound.Text = string.Empty;
            m_LastCardSwipe = string.Empty;

            //END RALLY DE9602
			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveMagCardSettings()
		{
			string start = cbStartCard.Text;
			string end = cbEndCard.Text;
            StringBuilder sb = new StringBuilder();

			Common.SetOpSettingValue(Setting.MSRReadTriggers, start.Length.ToString("D2")+start+end.Length.ToString("D2")+end);
            
			foreach (ListViewItem item in lstFilters.Items)
                sb.Append(item.Text+"\xFF");

            if(sb.Length > 0)
                sb.Remove(sb.Length-1, 1); //remove last null

            string tmp = sb.ToString();

			// Update the setting
            Common.SetOpSettingValue(Setting.MagneticCardFilters, tmp);

            // PDTS 1064
            // Reader Mode
            Common.SetOpSettingValue(Setting.MagneticCardReaderMode, (cboMagCardReaderMode.SelectedIndex + 1).ToString(System.Globalization.CultureInfo.InvariantCulture));

            // Reader Params
            switch((MagneticCardReaderMode)(cboMagCardReaderMode.SelectedIndex + 1))
            {
                default:
                case MagneticCardReaderMode.KeyboardOnly:
                    // We don't care about values.
                    Common.SetOpSettingValue(Setting.MagneticCardReaderParameters, string.Empty);
                    break;

                case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                    Common.SetOpSettingValue(Setting.MagneticCardReaderParameters, 
                                             CPCLPrinterTCPSource.SettingsToString(txtReaderIPAddress.Text.Trim(),
                                                                                   Convert.ToInt32(txtReaderPort.Text.Trim()),
                                                                                   Convert.ToInt16(txtReaderTrack.Text.Trim()))
                        );
                    break;
            }

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
				return false;

			// Set the flag
			m_bModified = false;

			return true;
		}

        private string HexMap(string text, int perLine)
        {
            StringBuilder sb = new StringBuilder(), sbTmp = new StringBuilder();
            int count = 0;

            foreach (char c in text)
            {
                if (c < ' ' || c > '~')
                    sbTmp.Append('.');
                else
                    sbTmp.Append(c);

                sb.Append(Convert.ToByte(c).ToString("X2") + " ");

                count++;

                if (count % perLine == 0)
                {
                    sb.Append(sbTmp.ToString() + "\r\n");
                    sbTmp.Length = 0;
                }
            }

            if (sbTmp.Length > 0)
            {
                if (sbTmp.Length < perLine)
                {
                    sb.Append("".PadRight(3 * (perLine - sbTmp.Length)));
                }

                sb.Append(sbTmp.ToString() + "\r\n");
                sbTmp.Length = 0;
            }

            return sb.ToString();
        }

		private void btnSwipeCard_Click(object sender, EventArgs e)
		{
			MagCardForm magForm = new MagCardForm();
            string start = MSRSettings.PrintableStringToString(cbStartCard.Text);
            string end = MSRSettings.PrintableStringToString(cbEndCard.Text);

            lblISOTracksFound.Text = string.Empty;
            lblISOTracksFound.ForeColor = Color.Black;

			if (magForm.ShowDialog(this) == DialogResult.OK)
			{
                string cardData = magForm.MagCardNumber;

                txtCardDigits.ForeColor = Color.RoyalBlue;
                txtCardDigits.Text = HexMap(cardData, 8);
                
                m_LastCardSwipe = cardData;

                if (cardData.Length > 2)
                {
                    //look for ISO tracks and let user know if they are there
                    string accountOnTrack1 = GameTech.Elite.Base.EnhancedRegularExpression.Match(@"^[^%]*%[a-zA-Z](\d*)", cardData);
                    string accountOnTrack2 = GameTech.Elite.Base.EnhancedRegularExpression.Match(@"^[^;]*;(\d*)", cardData);
                    string accountOnTrack3 = GameTech.Elite.Base.EnhancedRegularExpression.Match(@"^.*;.*;\d{2}(\d*)", cardData);
                    bool haveTrack1 = accountOnTrack1 != string.Empty;
                    bool haveTrack2 = accountOnTrack2 != string.Empty;
                    bool haveTrack3 = accountOnTrack3 != string.Empty;
                    bool accountsMatch = false;
                    StringBuilder sb = new StringBuilder();
                    int tracks = 0;

                    if (haveTrack1)
                    {
                        sb.Append("1");

                        if (haveTrack2 ^ haveTrack3)
                            sb.Append(" and ");
                        else if (haveTrack2 || haveTrack3)
                            sb.Append(", ");

                        tracks++;
                    }

                    if (haveTrack2)
                    {
                        sb.Append("2");

                        if (haveTrack3)
                            sb.Append(" and ");
                        
                        tracks++;
                    }

                    if (haveTrack3)
                    {
                        sb.Append("3");
                        tracks++;
                    }

                    if (tracks != 0)
                    {
                        if (tracks == 1)
                        {
                            sb.Insert(0, "(ISO track ");
                            sb.Append(" found)");
                        }
                        else
                        {
                            sb.Insert(0, "(ISO tracks ");

                            if (haveTrack1 && haveTrack2 && haveTrack3)
                                accountsMatch = accountOnTrack1 == accountOnTrack2 && accountOnTrack1 == accountOnTrack3;
                            else if (haveTrack1 && haveTrack2)
                                accountsMatch = accountOnTrack1 == accountOnTrack2;
                            else if (haveTrack1 && haveTrack3)
                                accountsMatch = accountOnTrack1 == accountOnTrack3;
                            else if (haveTrack2 && haveTrack3)
                                accountsMatch = accountOnTrack2 == accountOnTrack3;

                            sb.Append(" found. Accounts ");

                            if (!accountsMatch)
                            {
                                sb.Append("DON\'T ");

                                lblISOTracksFound.ForeColor = Color.Maroon;
                                txtCardDigits.ForeColor = Color.Red;
                            }

                            sb.Append("match)");
                        }

                        txtCardDigits.Text = txtCardDigits.Text + "\r\n\r\n";

                        if (tracks > 1 && !accountsMatch)
                            txtCardDigits.Text = txtCardDigits.Text + "Account numbers don\'t match!\r\n\r\n";

                        if(haveTrack1)
                            txtCardDigits.Text = txtCardDigits.Text + "ISO track 1 account = "+accountOnTrack1+"\r\n";

                        if (haveTrack2)
                            txtCardDigits.Text = txtCardDigits.Text + "ISO track 2 account = " + accountOnTrack2 + "\r\n";

                        if (haveTrack3)
                            txtCardDigits.Text = txtCardDigits.Text + "ISO track 3 account = " + accountOnTrack3 + "\r\n";

                    }
                    else
                    {
                        txtCardDigits.Text = txtCardDigits.Text + "\r\n\r\n*No ISO tracks found.";
                        sb.Append("(No ISO tracks found)\r\n");

                        lblISOTracksFound.ForeColor = Color.Maroon;
                        txtCardDigits.ForeColor = Color.Red;
                    }

                    if (!start.Contains(Convert.ToString(cardData[0])))
                        txtCardDigits.Text = txtCardDigits.Text + "\r\nThe starting character is not in your list.";

                    if (!end.Contains(Convert.ToString(cardData[cardData.Length - 1])))
                        txtCardDigits.Text = txtCardDigits.Text + "\r\nThe ending character is not in your list.";

                    lblISOTracksFound.Text = sb.ToString();
                }
			}

            magForm.Dispose();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
            if (lstFilters.SelectedItems.Count == 0)
            {
                btnDelete.Enabled = false;
                btnCopyFilterToLab.Enabled = false;
                return;
            }

            int index = lstFilters.SelectedItems[0].Index;

            if (index < 0)
                return;

            lstFilters.Items.RemoveAt(index);

            lstFilters.Focus();

            if (lstFilters.Items.Count != 0)
            {
                if (index == lstFilters.Items.Count)
                    index--;

                lstFilters.Items[index].Focused = true;
                lstFilters.Items[index].Selected = true;

                if (lstFilters.Items.Count == 1)
                {
                    btnShiftFilterDown.Enabled = false;
                    btnShiftFilterUp.Enabled = false;
                }
            }
            else
            {
                btnCopyFilterToLab.Enabled = false;
                btnDelete.Enabled = false;
                btnShiftFilterDown.Enabled = false;
                btnShiftFilterUp.Enabled = false;
            }

            // Set the modified flag
            m_bModified = true;
        }

		private void btnAccept_Click(object sender, EventArgs e)
		{
            bool found = false;

            if (cbFilter.Text == string.Empty)
            {
                btnAccept.Enabled = false;
                return;
            }

            foreach (ListViewItem lvi in lstFilters.Items)
            {
                if (lvi.Text == cbFilter.Text)
                    found = true;
            }

            if (!found)
            {
                lstFilters.Items.Add(cbFilter.Text);
                m_bModified = true;
                lstFilters.Items[lstFilters.Items.Count - 1].Selected = true;
            }
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
            MSRSettings settings = new MSRSettings();

            string start = MSRSettings.PrintableStringToString(cbStartCard.Text);
            string end = MSRSettings.PrintableStringToString(cbEndCard.Text);
            StringBuilder sb = new StringBuilder();

            settings.MSRStart = start;
            settings.MSREnd = end;

            foreach (ListViewItem item in lstFilters.Items)
                sb.Append(item.Text + "\xFF");

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1); //remove last null

            settings.setFilters(sb.ToString());

            settings.alwaysReturnAfterCardRead = true;

            // PDTS 1064
            MagneticCardReader reader = new MagneticCardReader(settings);
            reader.BeginReading();
			MagCardForm magForm = new MagCardForm(reader);
            magForm.ClearCardButtonVisible = false;
            magForm.TestingCards = true;
            
            bool keepGoing = true;

            while (keepGoing)
            {
                if (magForm.ShowDialog(this) == DialogResult.OK)
                {
                    reader.EndReading();

                    if (magForm.MagCardNumber == string.Empty)
                    {
                        if (magForm.BadStartingCharacter)
                        {
                            GTI.Modules.Shared.MessageForm.Show("The starting character on this card was not in the defined list.", "Bad Start Character", MessageFormTypes.OK);
                        }
                        else
                        {
                            if (magForm.MatchedFilter > 0 && settings.MSRFilters[magForm.MatchedFilter - 1].ToLower().Contains("(?#ignore"))
                            {
                                GTI.Modules.Shared.MessageForm.Show("The card matches a filter to be ignored.", "Ignored", MessageFormTypes.OK);
                            }
                            else
                            {
                                if(lstFilters.Items.Count > 0)
                                    GTI.Modules.Shared.MessageForm.Show("The card does not match any filters.", "No Match", MessageFormTypes.OK);
                                else
                                    GTI.Modules.Shared.MessageForm.Show("The card does not match the format for ISO track 1 or ISO track 2.", "No Match", MessageFormTypes.OK);
                            }
                        }
                    }
                    else
                    {
                        string filter = string.Empty;

                        switch (magForm.MatchedFilter)
                        {
                            case -10: //manual
                            {
                                filter = "Manual card entry.";
                            }
                            break;
                            case -1: //no filters, first track was track 1
                            {
                                filter = "Match on filter for track 1.";
                            }
                            break;
                            case -2: //no filters, first track was track 2
                            {
                                filter = "Match on filter for track 2.";
                            }
                            break;
                            case 0: //no match found
                            {
                            }
                            break;
                            default: //match on filter
                            {
                                filter = "Match on filter "+magForm.MatchedFilter.ToString()+".";
                            }
                            break;
                        }

                        GTI.Modules.Shared.MessageForm.Show((filter != string.Empty?filter+"\r\n\r\n":"")+magForm.MagCardNumber, "Result of Card Swipe", MessageFormTypes.OK);
                    }

                    reader.BeginReading();

                    magForm.Dispose();

                    magForm = new MagCardForm(reader);
                    magForm.ClearCardButtonVisible = false;
                    magForm.TestingCards = true;
                }
                else
                {
                    reader.EndReading();
                    keepGoing = false;
                }
            }

            magForm.Dispose();
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
            btnDelete.Enabled = false;
            btnCopyFilterToLab.Enabled = false;
            btnShiftFilterDown.Enabled = false;
            btnShiftFilterUp.Enabled = false;
		}

        // PDTS 1064
        private void cboMagCardReaderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((MagneticCardReaderMode)(cboMagCardReaderMode.SelectedIndex + 1))
            {
                default:
                case MagneticCardReaderMode.KeyboardOnly:
                    groupBoxTCPInput.Visible = false;
                    break;

                case MagneticCardReaderMode.KeyboardAndCPCLTCP:
                    groupBoxTCPInput.Visible = true;
                    break;
            }
        }

		#endregion // Private Routines

        private void btnReset_Leave(object sender, EventArgs e)
        {
            lstFilters.Focus();
        }

        private void btnShiftFilterUp_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItems.Count == 0)
                return;

            int index = lstFilters.SelectedItems[0].Index;

            if (index < 0)
                return;

            ListViewItem item = lstFilters.Items[index];

            if (index > 0)
            {
                lstFilters.Items.RemoveAt(index);
                lstFilters.Items.Insert(index - 1, item);

                // Set the modified flag
                m_bModified = true;
            }
        }

        private void btnShiftFilterDown_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItems.Count == 0)
                return;

            int index = lstFilters.SelectedItems[0].Index;
            
            if (index < 0)
                return;

            ListViewItem item = lstFilters.Items[index];

            if (index+1 < lstFilters.Items.Count)
            {
                lstFilters.Items.RemoveAt(index);
                lstFilters.Items.Insert(index + 1, item);

                // Set the modified flag
                m_bModified = true;
            }
        }

        private void btnCopyFilterToLab_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItems.Count == 0)
                return;

            int index = lstFilters.SelectedItems[0].Index;

            if (index < 0)
                return;

            ListViewItem item = lstFilters.Items[index];

            cbFilter.Text = item.Text;
        }

        private void cbStartCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the modified flag
            m_bModified = true;
        }

        private void cbEndCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the modified flag
            m_bModified = true;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            txtFilterResult.Clear();
            txtFilterResult.Text = GameTech.Elite.Base.EnhancedRegularExpression.Match(cbFilter.Text, m_LastCardSwipe);

            if (txtFilterResult.Text == string.Empty)
            {
                lblFilterResultInfo.Text = "(No match found)";
                lblFilterResultInfo.ForeColor = Color.Maroon;
            }
            else
            {
                lblFilterResultInfo.Text = "(Match found)";
                lblFilterResultInfo.ForeColor = Color.Black;
            }
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip menuItem = sender as ContextMenuStrip;

            if (menuItem != null)
            {
                Control ourControl = menuItem.SourceControl;

                if (ourControl != null)
                {
                    if (ourControl == txtFilterResult)
                    {
                        txtFilterResult.Clear();
                        lblFilterResultInfo.Text = string.Empty;
                        lblFilterResultInfo.ForeColor = Color.Black;
                    }
                    else if (ourControl == txtCardDigits)
                    {
                        txtCardDigits.Clear();
                        lblISOTracksFound.Text = string.Empty;
                        m_LastCardSwipe = string.Empty;
                    }
                }
            }
        }

        private void contextMenuStripForTextbox_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip menuItem = sender as ContextMenuStrip;

            if (menuItem != null)
            {
                Control ourControl = menuItem.SourceControl;

                if (!(ourControl is TextBox || ourControl is ComboBox))
                    return;

                if (ourControl != null)
                {
                    switch (e.ClickedItem.Text)
                    {
                        case "Undo":
                        {
                            ((TextBox)ourControl).Undo();
                        }
                        break;

                        case "Cut":
                        {
                            if (ourControl is TextBox)
                            {
                                ((TextBox)ourControl).Cut();
                            }
                            else
                            {
                                Clipboard.Clear();
                                Clipboard.SetText(((ComboBox)ourControl).SelectedText);
                                
                                StringBuilder sb = new StringBuilder(((ComboBox)ourControl).Text);

                                sb.Remove(((ComboBox)ourControl).SelectionStart, ((ComboBox)ourControl).SelectionLength);

                                ((ComboBox)ourControl).Text = sb.ToString();
                            }
                        }
                        break;

                        case "Copy":
                        {
                            if (ourControl is TextBox)
                            {
                                ((TextBox)ourControl).Copy();
                            }
                            else
                            {
                                Clipboard.Clear();
                                Clipboard.SetText(((ComboBox)ourControl).SelectedText);
                            }
                        }
                        break;

                        case "Paste":
                        {
                            if (ourControl is TextBox)
                            {
                                ((TextBox)ourControl).Paste();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder(((ComboBox)ourControl).Text);

                                sb.Remove(((ComboBox)ourControl).SelectionStart, ((ComboBox)ourControl).SelectionLength);

                                sb.Insert(((ComboBox)ourControl).SelectionStart, Clipboard.GetText());

                                ((ComboBox)ourControl).Text = sb.ToString();
                            }
                        }
                        break;

                        case "Delete":
                        {
                            if (ourControl is TextBox)
                            {
                                StringBuilder sb = new StringBuilder(((TextBox)ourControl).Text);

                                sb.Remove(((TextBox)ourControl).SelectionStart, ((TextBox)ourControl).SelectionLength);

                                ((TextBox)ourControl).Text = sb.ToString();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder(((ComboBox)ourControl).Text);

                                sb.Remove(((ComboBox)ourControl).SelectionStart, ((ComboBox)ourControl).SelectionLength);

                                ((ComboBox)ourControl).Text = sb.ToString();
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void contextMenuStripForTextbox_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menuItem = sender as ContextMenuStrip;

            if (menuItem != null)
            {
                Control ourControl = menuItem.SourceControl;

                if (ourControl != null)
                {
                    if (ourControl is TextBox)
                    {
                        TextBox ourTextBox = (TextBox)ourControl;
                        menuItem.Visible = true;

                        contextMenuStripForText.Items["Undo"].Visible = true;
                        contextMenuStripForText.Items["Separator"].Visible = true;
                        contextMenuStripForText.Items["Undo"].Enabled = ourTextBox.CanUndo;
                        contextMenuStripForText.Items["Paste"].Enabled = Clipboard.ContainsText();
                        contextMenuStripForText.Items["Cut"].Enabled = ourTextBox.SelectionLength > 0;
                        contextMenuStripForText.Items["Copy"].Enabled = ourTextBox.SelectionLength > 0;
                        contextMenuStripForText.Items["Delete"].Enabled = ourTextBox.SelectionLength > 0;
                    }
                    else if (ourControl is ComboBox)
                    {
                        ComboBox ourComboBox = (ComboBox)ourControl;
                        menuItem.Visible = true;

                        contextMenuStripForText.Items["Undo"].Visible = false;
                        contextMenuStripForText.Items["Separator"].Visible = false;
                        contextMenuStripForText.Items["Paste"].Enabled = Clipboard.ContainsText();
                        contextMenuStripForText.Items["Cut"].Enabled = ourComboBox.SelectionLength > 0;
                        contextMenuStripForText.Items["Copy"].Enabled = ourComboBox.SelectionLength > 0;
                        contextMenuStripForText.Items["Delete"].Enabled = ourComboBox.SelectionLength > 0;
                    }
                    else
                    {
                        menuItem.Visible = false;
                    }
                }
            }
        }

        private void cbFilter_TextUpdate(object sender, EventArgs e)
        {
            btnAccept.Enabled = cbFilter.Text != string.Empty;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFilter_TextUpdate(sender, e);
        }

        private void cbFilter_TextChanged(object sender, EventArgs e)
        {
            cbFilter_TextUpdate(sender, e);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (GTI.Modules.Shared.MessageForm.ShowCustomTwoButton(this, new NormalDisplayMode(), "You can analyze cards from scratch or using the curently defined settings.\n\nDo you want to start from scratch and replace the current settings?", "Clear Settings?", false, 2, "Start from scratch", "Keep settings", 0) == 1)
            {
                lstFilters.Items.Clear();
                cbStartCard.Text = "";
                cbEndCard.Text = "";
            }

            MagCardForm magForm = new MagCardForm();
            string currentStart = MSRSettings.PrintableStringToString(cbStartCard.Text);
            string currentEnd = MSRSettings.PrintableStringToString(cbEndCard.Text);
            string start = currentStart;
            string end = currentEnd;
            bool nonISOCardSwiped = false;
            bool filterMatchFailed = false;
            bool badSwipe = false;
            bool accountMismatch = false;
            int swipeNumber = 0;
            StringBuilder sb = new StringBuilder();

            magForm.AnalyzingCards = true;
            magForm.AtLeastOneCardToAnalyze = false;
            magForm.ClearCardButtonVisible = false;

            txtCardDigits.Clear();
            txtCardDigits.ForeColor = Color.Black;
            m_LastCardSwipe = string.Empty;

            lblISOTracksFound.ForeColor = Color.Black;
            lblISOTracksFound.Text = "(Analysis of swiped cards)";
            sb.Append("Analysis of swiped cards:");

            magForm.CenterToScreen();
            magForm.Show(this);

            while (magForm.AnalyzingCards)
            {
                Application.DoEvents();
   
                if (magForm.CardReady)
                {
                    string cardData = magForm.MagCardNumber;

                    swipeNumber++;
                    magForm.AtLeastOneCardToAnalyze = true;

                    if (cardData.Length > 2) //we at least have a start and stop
                    {
                        sb.Append("\r\n\r\nCard swipe " + swipeNumber.ToString() + ":");

                        if (!start.Contains(Convert.ToString(cardData[0])))
                            start = start + cardData[0];

                        if (!end.Contains(Convert.ToString(cardData[cardData.Length - 1])))
                            end = end + cardData[cardData.Length - 1];

                        if (lstFilters.Items.Count == 0)
                        {
                            //look for ISO tracks and let user know if they are there
                            string accountOnTrack1 = GameTech.Elite.Base.EnhancedRegularExpression.Match(@"^[^%]*%[a-zA-Z](\d*)", cardData);
                            string accountOnTrack2 = GameTech.Elite.Base.EnhancedRegularExpression.Match(@"^[^;]*;(\d*)", cardData);
                            bool haveTrack1 = accountOnTrack1 != string.Empty;
                            bool haveTrack2 = accountOnTrack2 != string.Empty;
                            int tracks = 0;

                            if (haveTrack1)
                            {
                                sb.Append("\r\nFound ISO track 1.");
                                sb.Append("\r\nAccount = " + accountOnTrack1);
                                tracks++;
                            }

                            if (haveTrack2)
                            {
                                sb.Append("\r\nFound ISO track 2.");
                                sb.Append("\r\nAccount = " + accountOnTrack2);
                                tracks++;
                            }

                            if (tracks != 0)
                            {
                                if (tracks == 2)
                                {
                                    if (accountOnTrack1 == accountOnTrack2)
                                    {
                                        sb.Append("\r\nAccounts match.");
                                    }
                                    else
                                    {
                                        sb.Append("\r\nAccounts DON\'T match.");
                                        txtCardDigits.ForeColor = Color.Red;
                                        accountMismatch = true;
                                    }
                                }
                            }
                            else
                            {
                                sb.Append("\r\nNo ISO tracks found.");
                                nonISOCardSwiped = true;
                                txtCardDigits.ForeColor = Color.Red;
                            }
                        }
                        else //use existing filters
                        {
                            bool foundOne = false;

                            foreach (ListViewItem lvi in lstFilters.Items)
                            {
                                if (!foundOne)
                                {
                                    string account = GameTech.Elite.Base.EnhancedRegularExpression.Match(lvi.Text, cardData);

                                    if (!string.IsNullOrEmpty(account))
                                    {
                                        sb.Append("\r\nFound a match with filter " + (lvi.Index + 1).ToString() + ".");
                                        sb.Append("\r\nAccount = " + account);

                                        foundOne = true;
                                    }
                                }
                            }

                            if (!foundOne)
                            {
                                sb.Append("\r\nNo match found.");
                                filterMatchFailed = true;
                            }
                        }
                    }
                    else //bad card read?
                    {
                        sb.Append("\r\nCard swipe was bad.");
                        badSwipe = true;
                        txtCardDigits.ForeColor = Color.Red;
                    }
                }
            }

            sb.Append("\r\n\r\n");

            bool newSettings = false;
            StringBuilder settingsChanges = new StringBuilder();

            if (start != currentStart)
            {
                newSettings = true;
                settingsChanges.Append("\r\nChanged start characters.");
            }

            if (end != currentEnd)
            {
                newSettings = true;
                settingsChanges.Append("\r\nChanged end characters.");
            }

            if (newSettings)
            {
                if (GTI.Modules.Shared.MessageForm.Show((start != currentStart?"The starting characters will be changed.\r\n":"")+(end != currentEnd?"The ending characters will be changed.\r\n":"")+"\r\nWould you like to change the settings to work with the analyzed cards?", "Change Settings?", MessageFormTypes.YesNo) == DialogResult.Yes)
                {
                    if (start == ";%") //use the default setting
                        start = "%;";

                    cbStartCard.Text = MSRSettings.StringToPrintable(start);
                    cbEndCard.Text = MSRSettings.StringToPrintable(end);

                    m_bModified = true;

                    sb.Append("The settings have been changed to work with the analyzed cards.\r\n");
                    sb.Append(settingsChanges.ToString());
                }
            }
            else
            {
                if (!(badSwipe || filterMatchFailed || nonISOCardSwiped || accountMismatch))
                    sb.Append("The settings did not need to be changed to work with the analyzed cards.\r\n");
            }


            if (badSwipe)
            {
                sb.Append("\r\nAt least one card swipe was bad.");
                txtCardDigits.ForeColor = Color.Red;
            }

            if (filterMatchFailed)
            {
                sb.Append("\r\nAt least one card swipe did not match any of the filters and will require another custom filter.");
                txtCardDigits.ForeColor = Color.Red;
            }
            
            if (nonISOCardSwiped)
            {
                sb.Append("\r\nAt least one card swipe did not follow the ISO standard and will require a custom filter.");
                txtCardDigits.ForeColor = Color.Red;
            }

            if (accountMismatch)
            {
                sb.Append("\r\nAt least one of the cards swiped had two ISO tracks but the account numbers in the two tracks were different.  This will require filtering for the track with the correct account number.");
                txtCardDigits.ForeColor = Color.Red;
            }

            txtCardDigits.Text = sb.ToString();

            magForm.Dispose();

            txtCardDigits.Focus();
            txtCardDigits.Select(0, -1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!cbStartCard.ContainsFocus && !cbEndCard.ContainsFocus && !cbFilter.ContainsFocus)
            {
                if (keyData == Keys.T || keyData == Keys.D || keyData == Keys.Z ||
                    keyData == Keys.W || keyData == Keys.A || keyData == Keys.F ||
                    keyData == Keys.S || keyData == Keys.R || 
                    keyData == (Keys.T | Keys.Shift) || keyData == (Keys.D | Keys.Shift) || keyData == (Keys.Z | Keys.Shift) ||
                    keyData == (Keys.W | Keys.Shift) || keyData == (Keys.A | Keys.Shift) || keyData == (Keys.F | Keys.Shift) ||
                    keyData == (Keys.S | Keys.Shift) || keyData == (Keys.R | Keys.Shift) ||
                    keyData == Keys.Space || keyData == Keys.Enter || keyData == Keys.Return || keyData == (Keys.LButton|Keys.MButton|Keys.Back)) 
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    } // end class
} // end namespace
