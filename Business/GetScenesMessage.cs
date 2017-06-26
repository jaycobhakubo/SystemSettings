using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class GetScenesMessage : ServerMessage
    {
        #region Declarations

        private int mintCommandID = 18161;

        protected byte[] mbyteResponsePayload = null;
        protected byte[] mbytResponse = null;

        private int mintReturnCode;
        public List<SceneItem> listScenes = new List<SceneItem>();
        
        #endregion

        public int pReturnCode
        {
            get { return mintReturnCode; }
            //set { mintReturnCode = value; }
        }

        public GetScenesMessage()
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
            ushort shtSceneCount;
            ushort shtNameLength;

            try
            {
                mbytResponse = base.m_responsePayload;

                // Check to see if we got the payload correctly.
                if (base.m_requestPayload == null)
                    throw new ServerCommException("GetScenesMessage.UnpackResponse()..Server communication lost.");

                if (mbytResponse.Length < sizeof(int))
                    throw new MessageWrongSizeException("GetScenesMessage.UnpackResponse()..Message payload size is too small.");

                // Check the return code.
                mintReturnCode = BitConverter.ToInt32(mbytResponse, 0);
                                
                if (mintReturnCode != (int)GTIServerReturnCode.Success)
                {
                    //-18 will indicate and empty recordset
                    if (mintReturnCode != -18)
                        throw new ServerException("GetScenesMessage.UnpackResponse()..Server Error Code: " + mintReturnCode.ToString());
                }

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(mbytResponse);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                // Try to unpack the data.
                try
                {
                    //Get count
                    shtSceneCount = responseReader.ReadUInt16();

                    for (ushort x = 0; x < shtSceneCount; x++)
                    {
                        SceneItem mItem = new SceneItem();
                        mItem.pSceneID = responseReader.ReadInt32();
                        //Get Motif Name Length
                        shtNameLength = responseReader.ReadUInt16();
                        mItem.pSceneName = new string(responseReader.ReadChars(shtNameLength));
                        mItem.pIsActive = responseReader.ReadBoolean();
                                                
                        if (mItem.pIsActive)
                        {
                            //only add Active scenes
                            listScenes.Add(mItem);
                        }
                    }
                }
                catch (EndOfStreamException e)
                {
                    throw new EndOfStreamException("GetScenesMessage.UnpackResponse()...EndOfStreamException: ", e);
                }
                catch (Exception e)
                {
                    throw new Exception("GetScenesMessage.UnpackResponse()...Exception: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetScenesMessage.UnpackResponse()...Exception: " + ex.Message);
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
