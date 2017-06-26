using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class RemoteDisplaySetting
    {
        public int MachineID { get; set; }
        public int AdaptorID { get; set; }
        public int SettingTypeId { get; set; }
        public string Value { get; set; }
        public int OperatorID { get; set; }
        
    }
    public class GetMachineRemoteDisplayConfigurations : ServerMessage
    {
        public List<RemoteDisplayConfiguration> DisplayConfigurationList { get; set; }
        private List<RemoteDisplaySetting> DisplaySettingsList { get; set; }
        public int OperatorID { get; set; }
        int MachineID { get; set; }

        public GetMachineRemoteDisplayConfigurations(int machineID, int operatorID)
        {      
            MachineID = machineID;
            OperatorID = operatorID;
            m_id = 18189;
            m_strMessageName = "Get Remote Display Configuration";
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            //MachineID
            requestWriter.Write(MachineID);

            //Machine Adaptor ID (0 for all)
            requestWriter.Write(0);

            //Operator ID
            requestWriter.Write(OperatorID);

            //Configuration Type Id(0 for all)
            requestWriter.Write(0);

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            try
            {
                DisplayConfigurationList = new List<RemoteDisplayConfiguration>();
                DisplaySettingsList = new List<RemoteDisplaySetting>();

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

                ushort machineSettingsCount = responseReader.ReadUInt16();
                ushort stringLen;

                for (ushort i = 0; i < machineSettingsCount; i++)
                {
                    RemoteDisplaySetting remoteDisplaySetting = new RemoteDisplaySetting();
                    remoteDisplaySetting.MachineID = responseReader.ReadInt32();
                    remoteDisplaySetting.AdaptorID = responseReader.ReadInt32();
                    remoteDisplaySetting.OperatorID = responseReader.ReadInt32();
                    remoteDisplaySetting.SettingTypeId = responseReader.ReadInt32();
                    stringLen = responseReader.ReadUInt16();
                    remoteDisplaySetting.Value = new string(responseReader.ReadChars(stringLen));
                    DisplaySettingsList.Add(remoteDisplaySetting);
                }

                //set the number of adapters
                List<int> adaptorList = new List<int>();
                foreach (RemoteDisplaySetting remoteSetting in DisplaySettingsList)
                {
                    if (!adaptorList.Contains(remoteSetting.AdaptorID))
                    {
                        adaptorList.Add(remoteSetting.AdaptorID);
                    }
                }

                foreach (int adaptorId in adaptorList)
                {
//                    bool isActive;
                    
                    int defaultScene;

                    RemoteDisplayConfiguration remoteDisplayConfiguration = new RemoteDisplayConfiguration();
                    remoteDisplayConfiguration.MachineID = MachineID;
                    remoteDisplayConfiguration.AdaptorID = adaptorId;
                    RemoteDisplaySetting isActiveSetting = DisplaySettingsList.Find(i=>i.AdaptorID == adaptorId && i.MachineID == MachineID && i.SettingTypeId == (int)RemoteDisplayConfigurationType.AdapterEnabled);
                    if (isActiveSetting.Value == "1")
                        remoteDisplayConfiguration.AdaptorEnabled = true;
                    else 
                        remoteDisplayConfiguration.AdaptorEnabled = false;
                    RemoteDisplaySetting resolutionSetting = DisplaySettingsList.Find(i => i.AdaptorID == adaptorId && i.MachineID == MachineID && i.SettingTypeId == (int)RemoteDisplayConfigurationType.Resolution); ;
                    remoteDisplayConfiguration.Resolution = resolutionSetting.Value;
                    RemoteDisplaySetting allowedScenesSetting = DisplaySettingsList.Find(i => i.AdaptorID == adaptorId && i.MachineID == MachineID && i.SettingTypeId == (int)RemoteDisplayConfigurationType.AllowedScenes);
                    remoteDisplayConfiguration.AllowedScenes = allowedScenesSetting.Value;
                    RemoteDisplaySetting allowedAccrualsSetting = DisplaySettingsList.Find(i => i.AdaptorID == adaptorId && i.MachineID == MachineID && i.SettingTypeId == (int)RemoteDisplayConfigurationType.EnabledAccruals);
                    remoteDisplayConfiguration.EnabledAccruals = allowedScenesSetting.Value;
                    RemoteDisplaySetting defaultSceneSetting = DisplaySettingsList.Find(i => i.AdaptorID == adaptorId && i.MachineID == MachineID && i.SettingTypeId == (int)RemoteDisplayConfigurationType.DefaultScene);
                    if (int.TryParse(defaultSceneSetting.Value, out defaultScene))
                    {
                        remoteDisplayConfiguration.DefaultScene = defaultScene;
                    }
                    DisplayConfigurationList.Add(remoteDisplayConfiguration);
                }
            }
            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException("GetRemoteDisplayConfigurations.UnpackResponse()...EndOfStreamException: ", e);
            }
          
            catch (Exception ex)
            {
                throw new Exception("GetRemoteDisplayConfigurations.UnpackResponse()...Exception: " + ex.Message);
            }
        }
    }
}
