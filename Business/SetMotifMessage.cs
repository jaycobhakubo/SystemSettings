using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class SetMotifMessage : ServerMessage
    {
         #region Declarations

        private int mintCommandID = 18158;

        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;

        private int mintReturnCode;

        private UInt16 muintMotifCount = 0;
        private List<MotifItem> listMotifs;
        
        #endregion

        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }     

        public SetMotifMessage(List<MotifItem> lMotifs)
        {
            base.m_id = mintCommandID;
            listMotifs = lMotifs;
            muintMotifCount = (UInt16)listMotifs.Count;
        }

        #region Base.Methods

        protected override void PackRequest()
        {
            ushort ushtLength = 0;
           
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            base.m_id = this.mintCommandID;

            requestWriter.Write(muintMotifCount);
            foreach (MotifItem mItem in listMotifs)
            {
                requestWriter.Write(mItem.MotifID);
                ushtLength = Convert.ToUInt16(mItem.MotifName.Length);
                requestWriter.Write(ushtLength);
                requestWriter.Write(mItem.MotifName.ToCharArray());
                requestWriter.Write(mItem.IsDefault);
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
                    throw new ServerCommException("SetMotifMessage.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("SetMotifMessage.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);

                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                    throw new ServerException("SetMotifMessage.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Try to unpack the data.
                try
                {
                    //nothing to unpack
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("SetMotifMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("SetMotifMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetMotifMessage.UnpackResponse()...Exception: " + ex.Message);
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
