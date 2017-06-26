using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    public class GetLicenseFileMessage : ServerMessage
    {
        private List<LicenseFileItem> m_LicenseFileItems;

        public GetLicenseFileMessage()
        {
            m_id = 25016;
            m_returnCode = (int)GTIServerReturnCode.Success;
            m_LicenseFileItems = new List<LicenseFileItem>();
        }

        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

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

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Try to unpack the data.
            try
            {
                // Seek past return code.
                responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                Int16 count = responseReader.ReadInt16();

                for(int i=0;i<count;i++)
                {
                    LicenseFileItem item = new LicenseFileItem();
                    item.settingID = responseReader.ReadInt32();
                    short stringLen = responseReader.ReadInt16();
                    if (stringLen > 0)
                        item.value = new string(responseReader.ReadChars(stringLen));
                    item.settingPermission = responseReader.ReadByte();
                    item.settingRange = responseReader.ReadByte();
                    m_LicenseFileItems.Add(item);
                }
            }

            catch (EndOfStreamException e)
            {
                throw new MessageWrongSizeException("Get License File", e);
            }
            catch (Exception e)
            {
                throw new ServerException("Get License File", e);
            }

            // Close the streams.
            responseReader.Close();
        }

    #region Properties
        public List<LicenseFileItem> LicenseFileItems
        {
            get { return m_LicenseFileItems; }
        }
    #endregion

    }

    public enum SettingPermission
    {
        ReadOnly = 0,
        Admin = 1,
        Customer = 2
    }

    public enum SettingRange
    {
        NoRange = 0,
        MinRange = 1,
        MaxRange = 2
    }

    public class LicenseFileItem
    {
        //todo refactor to properties
        public int settingID;
        public byte settingPermission;
        public byte settingRange;
        public string value;
        
        public LicenseFileItem()
        {
            
        }
    }
}
