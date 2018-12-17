using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class GetPhotoTypeMessage : ServerMessage
    {
        #region Declarations

        private int mintCommandID = 18039;

        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;

        private int mintReturnCode;
        public List<PhotoTypeItem> listPhotoTypes = new List<PhotoTypeItem>();
        
        #endregion

        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }

        public GetPhotoTypeMessage()
        {
            base.m_id = mintCommandID;
        }

        #region Base.Methods

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            base.m_id = this.mintCommandID;

            requestWriter.Write(true);

            // Set the bytes to be sent.
            base.m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            ushort shtCount;
            ushort shtLength;

            try
            {
                mbytResponse = base.m_responsePayload;

                // Check to see if we got the payload correctly.
                if (base.m_requestPayload == null)
                    throw new ServerCommException("GetPhotoTypeMessage.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("GetPhotoTypeMessage.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);
                                
                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                {
                    //-18 will indicate and empty recordset
                    if (mintReturnCode != -18)
                        throw new ServerException("GetPhotoTypeMessage.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());
                }

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Try to unpack the data.
                try
                {
                    //Get count of Motifs
                    shtCount = responseReader.ReadUInt16();

                    for (ushort x = 0; x < shtCount; x++)
                    {
                        PhotoTypeItem ptItem = new PhotoTypeItem();
                        ptItem.PhotoTypeID = responseReader.ReadInt32();
                        //Get Motif Name Length
                        shtLength = responseReader.ReadUInt16();
                        ptItem.PhotoTypeDesc = new string(responseReader.ReadChars(shtLength));

                        if (ptItem.PhotoTypeID != 13)//Exclude tier icon
                        {
                            listPhotoTypes.Add(ptItem);
                        }
                    }
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("GetPhotoTypeMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("GetPhotoTypeMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetPhotoTypeMessage.UnpackResponse()...Exception: " + ex.Message);
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
