using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    
    public class SetRemoteDisplayConfigurations : ServerMessage
    {
        private RemoteDisplayConfiguration displayConfiguration { get; set; }
        private List<RemoteDisplaySetting> DisplaySettingsList { get; set; }
        private int m_operatorId;

        public SetRemoteDisplayConfigurations(RemoteDisplayConfiguration configuration,int operatorId)
        {
            displayConfiguration = configuration;
            m_operatorId = operatorId;
            m_id = 18188;
            m_strMessageName = "Set Remote Display Configuration";
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            PrepareSettingList();

            //MachineID
            requestWriter.Write(displayConfiguration.MachineID);

            //OperatorID
            requestWriter.Write(m_operatorId);

            //SettingsCount
            requestWriter.Write((ushort)DisplaySettingsList.Count);

            foreach (RemoteDisplaySetting setting in DisplaySettingsList)
            {
                requestWriter.Write(setting.AdaptorID);
                requestWriter.Write(setting.SettingTypeId);
                requestWriter.Write((ushort)setting.Value.Length);
                requestWriter.Write(setting.Value.ToCharArray());
            }

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        private void PrepareSettingList()
        {
            //Prepare the Settings List
            DisplaySettingsList = new List<RemoteDisplaySetting>();

            RemoteDisplaySetting setting = new RemoteDisplaySetting();
            setting.AdaptorID = displayConfiguration.AdaptorID;
            setting.SettingTypeId = (int)RemoteDisplayConfigurationType.AdapterEnabled;
            if (displayConfiguration.AdaptorEnabled)
            {
                setting.Value = "1";
            }
            else
            {
                setting.Value = "0";
            }

            DisplaySettingsList.Add(setting);

            setting = new RemoteDisplaySetting();
            setting.AdaptorID = displayConfiguration.AdaptorID;
            setting.SettingTypeId = (int)RemoteDisplayConfigurationType.AllowedScenes;
            setting.Value = displayConfiguration.AllowedScenes;
            DisplaySettingsList.Add(setting);

            setting = new RemoteDisplaySetting();
            setting.AdaptorID = displayConfiguration.AdaptorID;
            setting.SettingTypeId = (int)RemoteDisplayConfigurationType.DefaultScene;
            setting.Value = displayConfiguration.DefaultScene.ToString();
            DisplaySettingsList.Add(setting);

            setting = new RemoteDisplaySetting();
            setting.AdaptorID = displayConfiguration.AdaptorID;
            setting.SettingTypeId = (int)RemoteDisplayConfigurationType.Resolution;
            setting.Value = displayConfiguration.Resolution;
            DisplaySettingsList.Add(setting);
        }

        
        protected override void UnpackResponse()
        {
            try
            {
                
                // Check to see if we got the payload correctly.
                if (m_responsePayload == null)
                    throw new ServerCommException("Server communication lost");

                if (m_responsePayload.Length < sizeof(int))
                    throw new MessageWrongSizeException("Invalid Message Received");

                // Create the streams we will be reading from.
                MemoryStream responseStream = new MemoryStream(m_responsePayload);
                BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

                int returnCode = responseReader.ReadInt32();

                if (returnCode != (int)GTIServerReturnCode.Success)
                {
                    throw new ServerException("Server Error Code: " + returnCode.ToString());
                }

            }
            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException("EndOfStreamException: ", e);
            }
          
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }
    }
}
