using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Models;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class AccrualDisplayItem
    {
        public int MachineID { get; set; }
        public int OperatorID { get; set; }
        public int AdapterID { get; set; }
        public int SequenceNumber { get; set; }
        public int AccrualID { get; set; }
        public string OverrideText { get; set; }
        public string AccrualName { get; set; }

        public override string ToString()
        {
            return AccrualName;
        }
    }

    public class GetAccrualDisplayItems : ServerMessage
    {
        public int MachineID { get; set; }
        public int OperatorID { get; set; }
        public List<AccrualDisplayItem> AccrualDisplayItems { get; set; }
        public GetAccrualDisplayItems(int machineID, int operatorID)
        {
            MachineID = machineID;
            OperatorID = operatorID;
            m_id = 18191;
            m_strMessageName = "Get Progressive Display Items";
        }

        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            //Machine ID
            requestWriter.Write(MachineID);

            //Operator ID
            requestWriter.Write(OperatorID);

            // Set the bytes to be sent.
            base.m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        protected override void UnpackResponse()
        {
            
            try
            {
                AccrualDisplayItems = new List<AccrualDisplayItem>();

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

                ushort accrualDisplayItemsCount = responseReader.ReadUInt16();
                ushort stringLen;

                for (ushort i = 0; i < accrualDisplayItemsCount; i++)
                {
                    AccrualDisplayItem accrualItem = new AccrualDisplayItem();
                    accrualItem.MachineID = responseReader.ReadInt32();
                    accrualItem.OperatorID = responseReader.ReadInt32();
                    accrualItem.AdapterID = responseReader.ReadInt32();
                    accrualItem.SequenceNumber = responseReader.ReadInt32();
                    accrualItem.AccrualID = responseReader.ReadInt32();
                    stringLen = responseReader.ReadUInt16();
                    accrualItem.OverrideText = new string(responseReader.ReadChars(stringLen));
                    AccrualDisplayItems.Add(accrualItem);
                }            
            }

            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException("Get Progressive Display Items End Of StreamException: ", e);
            }
          
            catch (Exception ex)
            {
                throw new Exception("Get Progressive Display Items " + ex.Message);
            }
        }        
    }
}
