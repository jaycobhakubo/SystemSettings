using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    class SetDeviceSettings: ServerMessage
    {
        private SettingValue[] mSettings;
        private int m_DeviceId;

        public SetDeviceSettings(int DeviceId, SettingValue[] settings)
        {
            m_id = 18244;
			mSettings = settings;
            m_DeviceId = DeviceId;
        }

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);


            requestWriter.Write(m_DeviceId);
            // Settings count
            requestWriter.Write((ushort)mSettings.Length);
            for (int iSetting = 0; iSetting < mSettings.Length; iSetting++)
            {
                requestWriter.Write(mSettings[iSetting].Id);
                requestWriter.Write((ushort)mSettings[iSetting].Value.Length);
                if (mSettings[iSetting].Value.Length > 0)
                {
                    requestWriter.Write(mSettings[iSetting].Value.ToCharArray());
                }
            }
            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        /// <summary>
        /// Parses the response received from the server.
        /// </summary>
        protected override void UnpackResponse()
        {
            base.UnpackResponse();

        }
        #endregion

    }
}
