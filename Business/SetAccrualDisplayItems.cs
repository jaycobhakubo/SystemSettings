using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.SystemSettings.Models;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    
    public class SetAccrualDisplayItems : ServerMessage
    {
       
        private List<AccrualDisplayItem> AccrualDisplayItems { get; set; }
        private int m_adapterId;
        private int m_operatorId;
        private int m_machineId;

        public SetAccrualDisplayItems(List<AccrualDisplayItem> accrualDisplayItems,int adapterID, int operatorID,int machineId)
        {
            AccrualDisplayItems = accrualDisplayItems;
            m_adapterId = adapterID;
            m_operatorId = operatorID;
            m_machineId = machineId;
            m_id = 18190;
            m_strMessageName = "Set Accrual Display Items";
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            //MachineID
            requestWriter.Write(m_machineId);

            //AdapterID
            requestWriter.Write(m_adapterId);

            //OperatorID
            requestWriter.Write(m_operatorId);

            //Settings count
            requestWriter.Write((ushort)AccrualDisplayItems.Count);

            foreach (AccrualDisplayItem accrualDisplayItem in AccrualDisplayItems)
            {
                requestWriter.Write(accrualDisplayItem.SequenceNumber);
                requestWriter.Write(accrualDisplayItem.AccrualID);
                requestWriter.Write((ushort)accrualDisplayItem.OverrideText.Length);
                requestWriter.Write(accrualDisplayItem.OverrideText.ToCharArray());
            }

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
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
