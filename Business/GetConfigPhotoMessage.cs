using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class GetConfigPhotoMessage : ServerMessage
    {
        #region Declarations

        private int mintCommandID = 18159;

        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;

        private int mintReturnCode;
        private byte[] ImageData = null;

        private int mintPhotoTypeID = 0;

        #endregion

        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }

        public byte[] pImageData
        {
            get { return ImageData; }
        }

        public GetConfigPhotoMessage(int intPhotoTypeID)
        {
            base.m_id = mintCommandID;
            mintPhotoTypeID = intPhotoTypeID;
        }

        #region Base.Methods

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            base.m_id = this.mintCommandID;

            requestWriter.Write(mintPhotoTypeID);

            // Set the bytes to be sent.
            base.m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            int intPhotoFieldLength;

            try
            {
                mbytResponse = base.m_responsePayload;

                // Check to see if we got the payload correctly.
                if (base.m_requestPayload == null)
                    throw new ServerCommException("GetConfigPhotoMessage.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("GetConfigPhotoMessage.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);

                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                {
                    //-18 will indicate and empty recordset
                    if (mintReturnCode != -18)
                    {
                        throw new ServerException("GetConfigPhotoMessage.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());
                    }
                    else
                    {                        
                        return;
                    }
                }

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                try
                {

                    responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
                    ushort _count = responseReader.ReadUInt16();

                    for (ushort x = 0; x < _count; x++ )
                    {
                        //Get Photo Field Length
                        intPhotoFieldLength = responseReader.ReadInt32();
                        if (intPhotoFieldLength > 0)
                        {
                            ImageData = responseReader.ReadBytes(intPhotoFieldLength);
                        }
                        else
                        {
                            ImageData = null;
                        }
                    }                    
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("GetConfigPhotoMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("GetConfigPhotoMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetConfigPhotoMessage.UnpackResponse()...Exception: " + ex.Message);
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
