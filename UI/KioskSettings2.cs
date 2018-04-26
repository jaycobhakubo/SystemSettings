using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.UI
{
	public partial class KioskSettings2 : SettingsControl
	{
		// Members
		bool m_bModified = false;
        int m_intPhotoTypeID;

	    public delegate int GetCurrentOperatorDelegate();

	    public delegate void SetCurrentOperatorDelegate(int operatorId);

        Business.GetPhotoTypeMessage objPhotoTypeMessage;
        Business.GetConfigPhotoMessage objGetMessage;
        Business.SetConfigPhotoMessage objSetMessage;
	    private GetCurrentOperatorDelegate m_getCurrentOperator;
	    private SetCurrentOperatorDelegate m_setCurrentOperator;
		public KioskSettings2()
		{
            //int intReturnValue = -18;
            //m_getCurrentOperator = getCurrentOperatorDelegate;
            //m_setCurrentOperator = setCurrentOperatorDelegate;

            InitializeComponent();
            //intReturnValue = PopComboBox();

            //if (intReturnValue == 0 && cboPhotoType.Items.Count > 0)
            //{
            //    cboPhotoType.SelectedIndex = 0;
            //}

		}
        
        public void SetKoiskSettings2Controller(GetCurrentOperatorDelegate getCurrentOperatorDelegate, SetCurrentOperatorDelegate setCurrentOperatorDelegate)
        {
            int intReturnValue = -18;
            m_getCurrentOperator = getCurrentOperatorDelegate;
            m_setCurrentOperator = setCurrentOperatorDelegate;

            intReturnValue = PopComboBox();

            if (intReturnValue == 0 && cboPhotoType.Items.Count > 0)
            {
                cboPhotoType.SelectedIndex = 0;
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

			bool bResult = LoadKioskSettings();

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
            GetConfigPhoto(m_intPhotoTypeID);
            Business.PhotoTypeItem ptItem = null;

            if (objGetMessage.pImageData == null)
            {
                pbImage.Image = null;
            }
            else
            {
                MemoryStream mStream = new MemoryStream(objGetMessage.pImageData);
                pbImage.Image = Image.FromStream(mStream);
            }

            try
            {
                ptItem = FindItemByValue(m_intPhotoTypeID);
                if (ptItem != null)
                {
                    cboPhotoType.SelectedIndex = cboPhotoType.Items.IndexOf(ptItem);
                }
                else
                {
                    cboPhotoType.SelectedIndex = -1;
                }
            }
            catch
            {
                cboPhotoType.SelectedIndex = -1;
            }

            // Set the flag
            m_bModified = false;

            return true;
        }

        private bool SaveKioskSettings()
        {
            byte[] imageData;

            if (pbImage.Image == null)
            {
                imageData = null;
            }
            else
            {
                MemoryStream mStream = new MemoryStream();
                pbImage.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = mStream.ToArray();
            }

            SetConfigPhoto(m_intPhotoTypeID, imageData);

            // Set the flag
            m_bModified = false;

            return true;
        }

        private int GetPhotoType()
        {
            try
            {
                objPhotoTypeMessage = new GTI.Modules.SystemSettings.Business.GetPhotoTypeMessage();
                try
                {
                    objPhotoTypeMessage.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("KioskSettings2.GetPhotoType()...Send()..Exception: " + ex.Message);
                }

                return objPhotoTypeMessage.pReturnCode;
            }
            catch (Exception e)
            {
                throw new Exception("KioskSettings2.GetPhotoType()....Exception: " + e.Message);
            }
        }


        private int GetConfigPhoto(int intPhotoTypeID)
        {
            SetCurrentOperator setOperatorMessage = null;
            try
            {
                int operatorId = m_getCurrentOperator.Invoke();
                setOperatorMessage = new SetCurrentOperator(operatorId);
                setOperatorMessage.Send();
            }
            catch (Exception e)
            {

                throw new Exception("KioskSettings2.GetConfigPhoto()....Exception: " + e.Message);
            }
            finally
            {
                if(setOperatorMessage == null || setOperatorMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    setOperatorMessage = new SetCurrentOperator(Common.CurrentOperatorId);
                    setOperatorMessage.Send();
                    throw new Exception("KioskSettings2.GetConfigPhoto() operator could not be set reverting" );
                    
                }

            }

            try
            {
                objGetMessage = new GTI.Modules.SystemSettings.Business.GetConfigPhotoMessage(intPhotoTypeID);
                try
                {
                    objGetMessage.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("KioskSettings2.GetConfigPhoto()...Send()..Exception: " + ex.Message);
                }
            }

            catch (Exception e)
            {
                throw new Exception("KioskSettings2.GetConfigPhoto()....Exception: " + e.Message);
            }

            try
            {
                int operatorId = Common.CurrentOperatorId;
                setOperatorMessage = new SetCurrentOperator(operatorId);
                setOperatorMessage.Send();
            }

            catch (Exception e)
            {
                throw new Exception("KioskSettings2.GetConfigPhoto()....Exception: " + e.Message);
            }

            finally
            {
                if ( setOperatorMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    throw new Exception("KioskSettings2.GetConfigPhoto() operator could not be reset");
                }
            }
            return objGetMessage.pReturnCode;
        }

        private int SetConfigPhoto(int intPhotoTypeID, byte[] PhotoData)
        {
            SetCurrentOperator setOperatorMessage = null;
            try
            {
                int operatorId = m_getCurrentOperator.Invoke();
                setOperatorMessage = new SetCurrentOperator(operatorId);
                setOperatorMessage.Send();
            }
            catch (Exception e)
            {

                throw new Exception("KioskSettings2.SetConfigPhoto()....Exception: " + e.Message);
            }
            finally
            {
                if (setOperatorMessage == null || setOperatorMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    setOperatorMessage = new SetCurrentOperator(Common.CurrentOperatorId);
                    setOperatorMessage.Send();
                    throw new Exception("KioskSettings2.SetConfigPhoto() operator could not be set reverting");
                }
            }
            try
            {
                objSetMessage = new GTI.Modules.SystemSettings.Business.SetConfigPhotoMessage(intPhotoTypeID, PhotoData);
                try
                {
                    objSetMessage.Send();
                }
                catch (Exception ex)
                {
                    throw new Exception("KioskSettings2.SetConfigPhoto()...Send()..Exception: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("KioskSettings2.SetConfigPhoto()....Exception: " + e.Message);
            }
            try
            {
                int operatorId = Common.CurrentOperatorId;
                setOperatorMessage = new SetCurrentOperator(operatorId);
                setOperatorMessage.Send();
            }
            catch (Exception e)
            {

                throw new Exception("KioskSettings2.SetConfigPhoto()....Exception: " + e.Message);
            }
            finally
            {
                if (setOperatorMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    throw new Exception("KioskSettings2.SetConfigPhoto() operator could not be reset");
                }
            }
            return objSetMessage.pReturnCode;
        }        		
        
		private void OnModified(object sender, EventArgs e)
		{
			m_bModified = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (cboPhotoType.SelectedValue != null)
            {
                Business.PhotoTypeItem ptItem = (Business.PhotoTypeItem)cboPhotoType.SelectedItem;
                m_intPhotoTypeID = ptItem.PhotoTypeID;
                SaveSettings();
            }
            else
            {
                if (cboPhotoType.Items.Count > 0)
                {
                    MessageForm.Show("Please select a photo type.");
                }
            }
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
            if (cboPhotoType.SelectedValue != null)
            {
                Business.PhotoTypeItem ptItem = (Business.PhotoTypeItem)cboPhotoType.SelectedItem;
                m_intPhotoTypeID = ptItem.PhotoTypeID;
                LoadSettings();
            }
            else
            {
                if (cboPhotoType.Items.Count > 0)
                {
                    MessageForm.Show("Please select a photo type.");
                }
            }
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboPhotoType.SelectedValue != null)
            {
                Business.PhotoTypeItem ptItem = (Business.PhotoTypeItem)cboPhotoType.SelectedItem;
                m_intPhotoTypeID = ptItem.PhotoTypeID;
                pbImage.Image = null;
                SaveSettings();
                LoadSettings();
            }
            else
            {
                if (cboPhotoType.Items.Count > 0)
                {
                    MessageForm.Show("Please select a photo type.");
                }
            }            
        }       
        
        private void btnGetImage_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //pbImage.Load(openFileDialog1.FileName.ToString());
                //pbImage.Image = new Bitmap(openFileDialog1.OpenFile());
                pbImage.Image = Image.FromFile(openFileDialog1.FileName.ToString());
                SetImage(pbImage);

                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    // Insert code to read the stream here.
                    myStream.Close();
                }
            }
            openFileDialog1.Dispose();
        }

        //Generate new image dimensions
        private Size GenerateImageDimensions(int currW, int currH, int destW, int destH)
        {
            //double to hold the final multiplier to use when scaling the image
            double multiplier = 0;

            //string for holding layout
            string layout;

            //determine if it's Portrait or Landscape
            if (currH > currW) layout = "portrait";
            else layout = "landscape";

            switch (layout.ToLower())
            {
                case "portrait":
                    //calculate multiplier on heights
                    if (destH > destW)
                    {
                        multiplier = (double)destW / (double)currW;
                    }

                    else
                    {
                        multiplier = (double)destH / (double)currH;
                    }
                    break;
                case "landscape":
                    //calculate multiplier on widths
                    if (destH > destW)
                    {
                        multiplier = (double)destW / (double)currW;
                    }

                    else
                    {
                        multiplier = (double)destH / (double)currH;
                    }
                    break;
            }

            //return the new image dimensions
            return new Size((int)(currW * multiplier), (int)(currH * multiplier));
        }

        //Resize the image
        private void SetImage(PictureBox pb)
        {
            try
            {
                //create a temp image
                Image img = pb.Image;

                //calculate the size of the image
                Size imgSize = GenerateImageDimensions(img.Width, img.Height, this.pbImage.Width, this.pbImage.Height);

                //create a new Bitmap with the proper dimensions
                Bitmap finalImg = new Bitmap(img, imgSize.Width, imgSize.Height);

                //create a new Graphics object from the image
                Graphics gfx = Graphics.FromImage(img);

                //clean up the image (take care of any image loss from resizing)
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //empty the PictureBox
                pb.Image = null;

                //center the new image
                pb.SizeMode = PictureBoxSizeMode.CenterImage;

                //set the new image
                pb.Image = finalImg;
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cboPhotoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
        }

        private int PopComboBox()
        {
            int intReturn = 0;
            intReturn = GetPhotoType();
            cboPhotoType.Items.Clear();

            if (objPhotoTypeMessage.listPhotoTypes.Count > 0)
            {
                //this populates the combo box; there is no need to iterate through the list
                cboPhotoType.DataSource = objPhotoTypeMessage.listPhotoTypes;            
                cboPhotoType.DisplayMember = "PhotoTypeDesc";
                cboPhotoType.ValueMember = "PhotoTypeID";
            }

            return intReturn;
        }

        private Business.PhotoTypeItem FindItemByValue(int selectedVal)
        {
            Business.PhotoTypeItem objReturn = null;

            for (int i = 0; i < cboPhotoType.Items.Count; i++)
            {
                objReturn = (Business.PhotoTypeItem)cboPhotoType.Items[i];
                if (objReturn.PhotoTypeID == selectedVal)
                {
                    break;
                }
            }

            return objReturn;
        }

        #endregion // Private Routines

        private void btnDelete_Leave(object sender, EventArgs e)
        {
            base.LeaveLastTab(sender, e);
        }

    } // end class
} // end namespace

