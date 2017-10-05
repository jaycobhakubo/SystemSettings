using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;


namespace GTI.Modules.SystemSettings.Business
{
    class GetDeviceSettingsMessage : ServerMessage
    {
        private const int MinResponseMessageLength = 6;
        private int mDeviceId;
        private int mGlobalSettingId;
        private SettingValue[] m_DeviceSettingList;


        public GetDeviceSettingsMessage(int DeviceId, int GlobalSettingId)
        {
            mDeviceId = DeviceId;
            mGlobalSettingId = GlobalSettingId;
            m_id = 18243;           
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            requestWriter.Write(mDeviceId);
            requestWriter.Write(mGlobalSettingId);
            base.m_requestPayload = requestStream.ToArray();
            requestWriter.Close();
        }

        public int ReturnCode_ { get; set;}

        protected override void UnpackResponse()
        {
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);
            ReturnCode_ = responseReader.ReadInt32();


            if (responseStream.Length < MinResponseMessageLength)
                throw new MessageWrongSizeException(m_strMessageName);

            try
            {
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                Int16 wSettingCount = responseReader.ReadInt16();
                m_DeviceSettingList = new SettingValue[wSettingCount];
                Int16 wStringLen = 0;

                for (int i = 0; i < wSettingCount; i++)
                {
                    m_DeviceSettingList[i].Id = responseReader.ReadInt32();
                    m_DeviceSettingList[i].Category = responseReader.ReadInt32();
                    wStringLen = responseReader.ReadInt16();
                    //if ()
                    m_DeviceSettingList[i].Value = new string(responseReader.ReadChars(wStringLen));
                }
            }
            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException(m_strMessageName, e);
            }
            catch (Exception e)
            {
                throw new ServerException(m_strMessageName, e);
            }
            responseReader.Close();
        }

        public bool TryGetSettingValue(Setting nGlobalSettingId, out SettingValue result)
        {
            result = new SettingValue();
            int nCount = m_DeviceSettingList.Length;

            for (int i = 0; i < nCount; i++)
            {
                if (m_DeviceSettingList[i].Id == (Int32)nGlobalSettingId)
                {
                    result = m_DeviceSettingList[i];
                    return true;
                }
            }
            return false;
        }

        public SettingValue[] DeviceSettingList
        {
            get
            {
                return m_DeviceSettingList;
            }
        }

        public SettingValue[] DeviceSettingPlayerSettingsList
        {
            get
            {
                return m_DeviceSettingList;
            }
        }
    }
}
