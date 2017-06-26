using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;
namespace GTI.Modules.SystemSettings.UI
{
    public partial class ChannelDlg : GradientForm
    {
        //Members
        public Channel m_Channel = new Channel();

        public ChannelDlg(Channel channel)
        {
            InitializeComponent();
            
            //Fill in controls
            this.m_Channel = channel;
            FillControls();
        }

        //Private Routines
        #region Private Routines

        private void FillControls()
        {
            Common.BeginWait();
            SuspendLayout();

            //Fill in data
            txtName.Text = m_Channel.ChannelName;
            chkIsEnabled.Checked = m_Channel.Enabled;

            ResumeLayout(true);
            Common.EndWait();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Validate input
            if (!ValidateInput())
            {
                return;
            }

            Common.BeginWait();
            if (!SaveChannel())
            {
                Common.EndWait();
                return;
            }
            Common.EndWait();

            // Close the dialog
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInput()
        {

            if (txtName.Text.Length == 0)
            {
                MessageForm.Show(this, Resources.EnterChannelName);
                txtName.Select();
                return false;
            }

            return true;
        }

        private bool SaveChannel()
        {
            m_Channel.ChannelName = txtName.Text;
            m_Channel.Enabled = chkIsEnabled.Checked;

            //Save data to server

            SetChannelData msg = new SetChannelData(m_Channel);
			try
			{
				msg.Send();
			}
			catch (Exception e)
			{
				MessageForm.Show(this, string.Format(Resources.SetChannelDataFailed, e));
				return false;
			}

			// Check return code
			if (msg.ServerReturnCode != GTIServerReturnCode.Success)
			{
                MessageForm.Show(this, string.Format(Resources.SetChannelDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)));
				return false;
			}
            

            return true;
        }
        #endregion

        private void btnCancel_Leave(object sender, EventArgs e)
        {
            chkIsEnabled.Focus();
        }
    }
}
