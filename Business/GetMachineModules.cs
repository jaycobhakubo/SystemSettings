using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class MachineModule
    {
        public MachineModule()
        {
            ModuleIDs = new List<int>();
        }     
        public List<int> ModuleIDs { get; set; }
    }

    public class GetMachineModules : ServerMessage
    {
        public MachineModule MachineModule { get; set; }
        int MachineID { get; set; }
        public GetMachineModules(int machineID)
        {
            MachineID = machineID;
            m_id = 25007;
            m_strMessageName = "Get Machine Modules";
        }
        
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
                        MemoryStream requestStream = new MemoryStream();
                        BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

                        //MachineID
                        requestWriter.Write(MachineID);

                        // Set the bytes to be sent.
                        base.m_requestPayload = requestStream.ToArray();

                        // Close the streams.
                        requestWriter.Close();
        }
        protected override void UnpackResponse()
        {
            try
            {
                MachineModule = new MachineModule();

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

                ushort moduleCount = responseReader.ReadUInt16();

                for (ushort i = 0; i < moduleCount; i++)
                {
                    MachineModule.ModuleIDs.Add(responseReader.ReadInt32());
                }
        
            }
            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException("GetMachineModules.UnpackResponse()...EndOfStreamException: ", e);
            }
          
            catch (Exception ex)
            {
                throw new Exception("GetMachineModules.UnpackResponse()...Exception: " + ex.Message);
            }
        }
    }

}
