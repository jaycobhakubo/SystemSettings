using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;
using GTI.Modules.SystemSettings.UI;

namespace GTI.Modules.SystemSettings.Business
{
    class SetRNGSettings : ServerMessage
    {
        private List<RNGRemoteSettingsData> mListRNGRemoteSettings;

        public SetRNGSettings(List<RNGRemoteSettingsData> ListRNGRemoteSettings)
        {
            m_id = 18256;
            mListRNGRemoteSettings = ListRNGRemoteSettings;
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();            // Create the streams we will be writing to.
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            requestWriter.Write((ushort)mListRNGRemoteSettings.Count());

            foreach (RNGRemoteSettingsData rngSettings in mListRNGRemoteSettings)  //settings count
            {
                requestWriter.Write((int)rngSettings.RNGTypeID);
                requestWriter.Write((ushort)rngSettings.RNGIpAddress.Length);
                requestWriter.Write(rngSettings.RNGIpAddress.ToCharArray());
                requestWriter.Write((int)rngSettings.RNGServerPort);

                byte tempIsEnable;
                if (rngSettings.RNGSSLConnection == true)
                {
                    tempIsEnable = (byte)1;
                }
                else
                {
                    tempIsEnable = (byte)0;
                }
                requestWriter.Write(tempIsEnable);


                if (rngSettings.RNGRemoveSettings == true)
                {
                    tempIsEnable = (byte)1;
                }
                else
                {
                    tempIsEnable = (byte)0;
                }
                requestWriter.Write(tempIsEnable);
            }

            m_requestPayload = requestStream.ToArray();
            requestWriter.Close();            // Close the streams.bn
        }
    }
}


