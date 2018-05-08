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
                tempValue.RNGTypeID = responseReader.ReadInt32();//TypeId
                tempLength = responseReader.ReadUInt16();//IpAddress(unsigned)
                tempValue.RNGIpAddress = new string(responseReader.ReadChars(tempLength));//IpAddress(string)
                tempValue.RNGServerPort = responseReader.ReadInt32();//Server Port
                byte SSLConnection = 0;
                SSLConnection = responseReader.ReadByte();//SSL COnnection
                tempValue.RNGSSLConnection = SSLConnection == 0 ? false : true;
                tempValue.RNGRemoveSettings = false;
                //byte RemoveSettings = 0;
                //RemoveSettings = responseReader.ReadByte();//Remove Settings
                //tempValue.RNGRemoveSettings = SSLConnection == 0 ? false : true;
                ListRNGRemoteSettings.Add(tempValue);
            }
            responseReader.Close();
        }


    }
}
