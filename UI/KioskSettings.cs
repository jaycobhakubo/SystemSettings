#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © FortuNet dba GameTech
// International, Inc.
//
// US3692 Adding support for whole points
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;
using System.Text.RegularExpressions;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class KioskSettings : SettingsControl
	{
		// Members
		bool m_bModified = false;
        int m_MaxFontHeight = 10;
        bool m_wholePoints = false;

		// Constants
		const int SWIPE_MODE_INTERVAL = 4;
		const int SWIPE_MODE_TRACKING = 6;


		public KioskSettings()
		{
			InitializeComponent();

            //Load Windows fonts into the combo box.
            LoadFonts();
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

			bool bResult = LoadKioskSettings();

            // US3692
            if(m_wholePoints)
                numPointsPerSwipe.DecimalPlaces = 0;

			this.ResumeLayout(true);
			Common.EndWait();

			return bResult;
		}

		public override bool SaveSettings()
		{
			Common.BeginWait();

			bool bResult = SaveKioskSettings();

			Common.EndWait();

			return bResult;
		}

		#endregion  // Public Methods



		// Private Routines
		#region Private Routines
		private bool LoadKioskSettings()
		{
			// Fill in the operator global settings
			SettingValue tempSettingValue;

            String result = Common.GetLicenseSettingValue(LicenseSetting.ForceWholeProductPoints);
            if (!string.IsNullOrEmpty(result))
                m_wholePoints = Convert.ToBoolean(result);


		    //US4625 Restrict enabling for admin only settings
            Common.GetOpSettingValue(Setting.BillAcceptor, out tempSettingValue);
            txtBillAcceptor.Text = tempSettingValue.Value;

            Common.GetOpSettingValue(Setting.CoinAcceptor, out tempSettingValue);
            txtCoinAcceptor.Text = tempSettingValue.Value;

            if (!Common.IsAdmin)
            {
                grpBillCoinAcceptor.Visible = false;
                label2.Visible = false;
                txtBillAcceptor.Visible = false;
                label4.Visible = false;
                txtCoinAcceptor.Visible = false;
            }
            //End US4625

			Common.GetOpSettingValue(Setting.TitleMessage, out tempSettingValue);
			txtTitle.Text = tempSettingValue.Value;

			Common.GetOpSettingValue(Setting.TextLine1, out tempSettingValue);
			txtLine1.Text = tempSettingValue.Value;

			//Common.GetOpSettingValue(Setting.TextLine2, out tempSettingValue);
			//txtLine2.Text = tempSettingValue.Value;

			Common.GetOpSettingValue(Setting.PointsPerSwipe, out tempSettingValue);
			numPointsPerSwipe.Value = ParseDecimal(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.ActivityTimeout, out tempSettingValue);
			numTimeout.Value = ParseInt(tempSettingValue.Value);

			Common.GetOpSettingValue(Setting.SwipeType, out tempSettingValue);
			cboSwipeMode.SelectedIndex = Math.Min(4, Math.Max(0, ParseInt(tempSettingValue.Value) - 1));

            Common.GetOpSettingValue(Setting.KioskFont, out tempSettingValue);
            cboFont.SelectedIndex = 0;
            if (tempSettingValue.Value.Length > 0)
            {
                for (int i = 0; i < cboFont.Items.Count; i++)
                {
                    if (cboFont.Items[i].ToString().ToLower() == tempSettingValue.Value.ToString().ToLower())
                    {
                        cboFont.SelectedIndex = i;
                        break;
                    }
                }               
            }

            Common.GetOpSettingValue(Setting.KioskTitleColor, out tempSettingValue);
            txtColor.Tag = tempSettingValue.Value.ToString();
            try
            {
                txtColor.ForeColor = Color.FromArgb(Convert.ToInt32(tempSettingValue.Value));
            }
            catch
            {
                txtColor.ForeColor = Color.Black;
            }

            Common.GetOpSettingValue(Setting.KioskLineColor, out tempSettingValue);
            txtLineColor.Tag = tempSettingValue.Value.ToString();
            try
            {
                txtLineColor.ForeColor = Color.FromArgb(Convert.ToInt32(tempSettingValue.Value));
            }
            catch
            {
                txtLineColor.ForeColor = Color.Black;
            }

			// Set optional controls
			cboSwipeMode_SelectedIndexChanged(null, null);

			// Set the flag
			m_bModified = false;

			return true;
		}

		private bool SaveKioskSettings()
		{
			// Update the operator global settings			
			Common.SetOpSettingValue(Setting.BillAcceptor, txtBillAcceptor.Text);
			Common.SetOpSettingValue(Setting.CoinAcceptor, txtCoinAcceptor.Text);
            Common.SetOpSettingValue(Setting.TitleMessage, CleanInput(txtTitle.Text));
            
            //FIX RALLY DE1639 changed text line to allow carriage returns and line feeds
            //FIX RALLY DE 2998 changed to allow all kinds of crazy characters inputed
            Common.SetOpSettingValue(Setting.TextLine1,txtLine1.Text);
            //END FIX RALLY DE 2998
            //END FIX RALLY DE1639
            
            Common.SetOpSettingValue(Setting.SwipeType, Convert.ToString(cboSwipeMode.SelectedIndex + 1));
			Common.SetOpSettingValue(Setting.PointsPerSwipe, numPointsPerSwipe.Value.ToString());
			Common.SetOpSettingValue(Setting.ActivityTimeout, numTimeout.Value.ToString());

			// Update the optional swipe setting
			switch (cboSwipeMode.SelectedIndex)
			{
				case SWIPE_MODE_INTERVAL:
					Common.SetOpSettingValue(Setting.IntervalPeriod, numSwipeModeSpecifics.Value.ToString());
					break;

				case SWIPE_MODE_TRACKING:
					Common.SetOpSettingValue(Setting.MinPoints, numSwipeModeSpecifics.Value.ToString());
					break;
			}

            Common.SetOpSettingValue(Setting.KioskFont, cboFont.Items[cboFont.SelectedIndex].ToString());
            Common.SetOpSettingValue(Setting.KioskTitleColor, txtColor.Tag.ToString());
            Common.SetOpSettingValue(Setting.KioskLineColor, txtLineColor.Tag.ToString());

			// Save the operator settings
			if (!Common.SaveOperatorSettings())
			{
				return false;
			}

			// Set the flag
			m_bModified = false;

			return true;
		}

		private void cboSwipeMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Decide if we need to display additional swipe settings
			SettingValue tempSettingValue;
            int intValue = 0;
			switch (cboSwipeMode.SelectedIndex)
			{
				case SWIPE_MODE_INTERVAL:
					lblSwipeModeSpecifics1.Text = "Number of minutes between swipes";
					lblSwipeModeSpecifics2.Text = "(Interval Mode Only)";
					numSwipeModeSpecifics.Visible = true;
					Common.GetOpSettingValue(Setting.IntervalPeriod, out tempSettingValue);

                    intValue = ParseInt(tempSettingValue.Value);
                    if (intValue > 0)
                    {
                        if (intValue <= numSwipeModeSpecifics.Maximum) //RALLY DE 8716
                        {
                            numSwipeModeSpecifics.Value = ParseInt(tempSettingValue.Value);
                        }
                        else
                        {
                            numSwipeModeSpecifics.Value = numSwipeModeSpecifics.Maximum; //RALLY DE 8716
                        }
                    }
                    else
                    {
                        numSwipeModeSpecifics.Value = 1;
                    }
                    break;

				case SWIPE_MODE_TRACKING:
					lblSwipeModeSpecifics1.Text = "Minimum number of points to award";
					lblSwipeModeSpecifics2.Text = "(Tracking Mode Only)";
					numSwipeModeSpecifics.Visible = true;
					Common.GetOpSettingValue(Setting.MinPoints, out tempSettingValue);

                    intValue = ParseInt(tempSettingValue.Value);
                    if (intValue > 0)
                    {
                        if (intValue <= numSwipeModeSpecifics.Maximum) //RALLY DE 8716
                        {
                            numSwipeModeSpecifics.Value = ParseInt(tempSettingValue.Value);
                        }
                        else
                        {
                            numSwipeModeSpecifics.Value = numSwipeModeSpecifics.Maximum; //RALLY DE 8716
                        }
                    }
                    else
                    {
                        numSwipeModeSpecifics.Value = 1;
                    }
                    break;

				default:
					lblSwipeModeSpecifics1.Text = "";
					lblSwipeModeSpecifics2.Text = "";
					numSwipeModeSpecifics.Visible = false;
					break;
			} // end switch
		}

		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
            LoadSettings();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			LoadSettings();
		}

		#endregion // Private Routines

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = txtColor.ForeColor;
            DialogResult dResult = colorDialog1.ShowDialog();
            
            if (dResult == DialogResult.OK)
            {
                txtColor.ForeColor = colorDialog1.Color;
                txtColor.Tag = colorDialog1.Color.ToArgb().ToString(); 
            }
        }

        private void txtColor_Enter(object sender, EventArgs e)
        {
            btnColor.Focus();
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Font ffFont = new Font(cboFont.Items[cboFont.SelectedIndex].ToString(), 12);
            //cboFont.Font = ffFont;
        }

        private void txtLineColor_Enter(object sender, EventArgs e)
        {
            btnLineColor.Focus();
        }

        private void btnLineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = txtLineColor.ForeColor;
            DialogResult dResult = colorDialog1.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                txtLineColor.ForeColor = colorDialog1.Color;
                txtLineColor.Tag = colorDialog1.Color.ToArgb().ToString();
            }
        }

        public void LoadFonts()
        {
            InstalledFontCollection iFonts = new InstalledFontCollection();
            int intFontHeightInPix = 0;

            cboFont.Items.Clear();

            foreach (FontFamily fFam in iFonts.Families)
            {                
                if (fFam.IsStyleAvailable(FontStyle.Regular))
                {
                    intFontHeightInPix = (fFam.GetCellAscent(FontStyle.Regular) * 16) / 2048 + (fFam.GetCellDescent(FontStyle.Regular) * 16) / 2048;

                    if (intFontHeightInPix > m_MaxFontHeight)
                    {
                        m_MaxFontHeight = intFontHeightInPix;
                    }
                    cboFont.Items.Add(fFam.Name.ToString());
                }
            }
        }

        private void cboFont_DrawItem(object sender, DrawItemEventArgs e)
        {
            //combobox DrawMode property must be OwnerDrawVariable

            // If the index is invalid then simply exit.
            if (e.Index == -1 || e.Index >= cboFont.Items.Count)
                return;

            // Draw the background of the item.
            e.DrawBackground();

            // Should we draw the focus rectangle?
            if ((e.State & DrawItemState.Focus) != 0)
                e.DrawFocusRectangle();

            Brush b = null;

            try
            {

                // Create a new background brush.
                b = new SolidBrush(e.ForeColor);

                Font xFont = new Font(cboFont.Items[e.Index].ToString(), 12);

                // Draw the item.
                e.Graphics.DrawString(
                    cboFont.Items[e.Index].ToString(),
                    xFont,
                    b,
                    e.Bounds
                    );

            } // End try

            finally
            {

                // Should we cleanup the brush?
                if (b != null)
                    b.Dispose();

                b = null;

            } // End finally
        }

        private void cboFont_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Font xFont = new Font(cboFont.Items[e.Index].ToString(), 12);
            SizeF stringSize = e.Graphics.MeasureString(xFont.Name, xFont);
            
            // Set the height and width of the item
            //e.ItemHeight = (int)stringSize.Height;
            e.ItemHeight = m_MaxFontHeight;
            e.ItemWidth = (int)stringSize.Width;
        }

        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(strIn, @"[^\w\.,:;?!@$%&*()-+= ]", "");
        }

        //START FIX RALLY DE1639 changed text line to allow carriage returns and line feeds
        static string CleanMessageInput(string strIn)
        {
            return Regex.Replace(strIn, @"[^\w\r\n\.,:;?!@$%&*()-+= ]", "");
        }

        private void btnReset_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }
        //END FIX RALLY DE1639 changed text line to allow carriage returns and line feeds


	} // end class
} // end namespace

