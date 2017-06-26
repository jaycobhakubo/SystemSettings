using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class MachineSetting
    {
        public int MachineID { get; set; }
        public int Type { get; set; }
        public int SubType { get; set; }
        public string Value { get; set; }
    }
    public class GetMachineCapabilites : ServerMessage
    {
        public List<MachineCapabilites> MachineCapabilitesList { get; set; }
        private List<MachineSetting> MachineSettingsList { get; set; }
        int MachineID { get; set; }
    
        public GetMachineCapabilites(int machineID)
        {
            MachineCapabilitesList = new List<MachineCapabilites>();
            MachineID = machineID;
            m_id = 18187;
            m_strMessageName = "Get Machine Capabilites";
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            //MachineID
            requestWriter.Write(MachineID);

            //Machine Capability type id (0 for all)
            requestWriter.Write(0);

            //Machine Capability Sub type id(0 for all)
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
                MachineCapabilitesList = new List<MachineCapabilites>();
                MachineSettingsList = new List<MachineSetting>();

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
                    MachineSetting machineSetting = new MachineSetting();
                    machineSetting.MachineID = responseReader.ReadInt32();
                    machineSetting.Type = responseReader.ReadInt32();
                    machineSetting.SubType = responseReader.ReadInt32();
                    stringLen = responseReader.ReadUInt16();
                    machineSetting.Value = new string(responseReader.ReadChars(stringLen));
                    MachineSettingsList.Add(machineSetting);
                }

                //set the number of adapters
                List<MachineSetting> adaptorList = MachineSettingsList.FindAll(i => i.Type == (int)MachineCapabilityTypes.AvailableAdapterNumber);
                foreach (MachineSetting adaptor in adaptorList)
                {
                    MachineCapabilites machineCapability = new MachineCapabilites();
                    int adaptorNumber;
                    
                    if (int.TryParse(adaptor.Value, out adaptorNumber))
                    {
                        //Adapter Number
                        machineCapability.AdapterNumber = adaptorNumber;
                        machineCapability.AdapterResoultions = new List<string>();

                        //Adapter Name
                        MachineSetting adaptorName = MachineSettingsList.Find(i => i.Type == (int)MachineCapabilityTypes.AdapterDescription && i.SubType == adaptorNumber);
                        machineCapability.AdapterDescription = adaptorName.Value;

                        //Adapter Resolutions
                        List<MachineSetting> adaptorResolutions   = MachineSettingsList.FindAll(i => i.Type == (int)MachineCapabilityTypes.AvailableAdapterResolutions &&
                            i.SubType == adaptorNumber);
                        foreach (MachineSetting resolution in adaptorResolutions)
                        {
                            machineCapability.AdapterResoultions.Add(resolution.Value);
                        }

                        MachineCapabilitesList.Add(machineCapability);
                    }
                }

                //set the number of audio adapters
                adaptorList = MachineSettingsList.FindAll(i => i.Type == (int)MachineCapabilityTypes.AvailableAudioAdapterNumber);
                foreach (MachineSetting adaptor in adaptorList)
                {
                    MachineCapabilites machineCapability = new MachineCapabilites();
                    int adaptorNumber;

                    if (int.TryParse(adaptor.Value, out adaptorNumber))
                    {
                        //Adapter Number
                        machineCapability.AdapterNumber = adaptorNumber;

                        //Adapter Name
                        MachineSetting adaptorName = MachineSettingsList.Find(i => i.Type == (int)MachineCapabilityTypes.AudioAdapterDescription && i.SubType == adaptorNumber);
                        machineCapability.AdapterDescription = adaptorName.Value;

                        MachineCapabilitesList.Add(machineCapability);
                    }
                }
            }
            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException("GetConfigPhotoMessage.UnpackResponse()...EndOfStreamException: ", e);
            }
          
            catch (Exception ex)
            {
                throw new Exception("GetConfigPhotoMessage.UnpackResponse()...Exception: " + ex.Message);
            }
        }
    }
}
