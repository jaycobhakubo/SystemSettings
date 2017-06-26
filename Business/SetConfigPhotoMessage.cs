using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class SetConfigPhotoMessage : ServerMessage
    {
        #region Declarations

        private int mintCommandID = 18160;

        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;

        private int mintReturnCode;

        private int mintPhotoTypeID = 0;
        private int intPhotoLength;
        private byte[] ImageData = null;

        #endregion

        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }      

        public SetConfigPhotoMessage(int PhotoTypeID, byte[] Photo)
        {
            base.m_id = mintCommandID;
            mintPhotoTypeID = PhotoTypeID;
            if (Photo == null)
            {
                intPhotoLength = 0;
            }
            else
            {
                ImageData = Photo;
                intPhotoLength = Photo.Length;
            }            
        }

        #region Base.Methods

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            base.m_id = this.mintCommandID;

            requestWriter.Write(mintPhotoTypeID);
            requestWriter.Write(intPhotoLength);
            if (intPhotoLength > 0)
            {
                //only send ImageData if intPhotoLength > 0
                requestWriter.Write(ImageData);
            }

            // Set the bytes to be sent.
            base.m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            try
            {
                mbytResponse = base.m_responsePayload;

                // Check to see if we got the payload correctly.
                if (base.m_requestPayload == null)
                    throw new ServerCommException("SetConfigPhotoMessage.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("SetConfigPhotoMessage.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);

                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                    throw new ServerException("SetConfigPhotoMessage.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Try to unpack the data.
                try
                {
                    //only a return code is passed
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("SetConfigPhotoMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("SetConfigPhotoMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetConfigPhotoMessage.UnpackResponse()...Exception: " + ex.Message);
            }

        }

        public override void Send()
        {
            //This calls PackRequest() and UnpackResponse()
            base.Send();
        }

        #endregion

    }//class
}//namespace
