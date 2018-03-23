using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.UI;


namespace GTI.Modules.SystemSettings.Business
{
    class GetRNGRemoteSettings: ServerMessage
    {
    public List<RNGRemoteSettingsData> ListRNGRemoteSettings { get; set; }
    private int mRNGRemoteTypeID;

    public GetRNGRemoteSettings(int RNGTypeID)
        {
            m_id = 18255;
            mRNGRemoteTypeID = RNGTypeID;
            ListRNGRemoteSettings = new List<RNGRemoteSettingsData>();
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            requestWriter.Write(mRNGRemoteTypeID);
            m_requestPayload = requestStream.ToArray();
            //throw new NotImplementedException();
        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);
            responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
            ushort tempLength = 0;

            ushort Count = responseReader.ReadUInt16();
          
            for (int iType = 0; iType < Count; iType++)
            {
                var tempValue = new RNGRemoteSettingsData();
                tempValue.RNGTypeID = responseReader.ReadInt32();//1
                tempLength = responseReader.ReadUInt16();//2
                tempValue.RNGIpAddress = new string(responseReader.ReadChars(tempLength));
                tempValue.RNGServerPort = responseReader.ReadInt32();//3
                byte SSLConnection = 0;
                SSLConnection = responseReader.ReadByte();//2
                tempValue.RNGSSLConnection = SSLConnection == 0 ? false : true;
                byte RemoveSettings = 0;
                RemoveSettings = responseReader.ReadByte();//2
                tempValue.RNGRemoveSettings = SSLConnection == 0 ? false : true;
                ListRNGRemoteSettings.Add(tempValue);
            }
            responseReader.Close();
        }


    }
}
