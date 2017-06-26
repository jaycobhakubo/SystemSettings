using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.SystemSettings.Business
{
    public class SetDistributorFees : ServerMessage 
    {
        private DistributorFee m_distributorFee;
        public SetDistributorFees(DistributorFee fee)
        {
            m_id = 25018;
            DistributorFee = fee;
        }

        public DistributorFee DistributorFee
        {
            get { return m_distributorFee; }
            set { m_distributorFee = value; }
        }

        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            //write the operator ID
            requestWriter.Write(DistributorFee.OperatorId);

            //write the device ID
            requestWriter.Write(DistributorFee.DeviceId);

            //write the fee type ID
            requestWriter.Write(DistributorFee.DeviceFeeTypeId);

            //write the count
            requestWriter.Write((short) DistributorFee.DistributorFeeData.Count);
            
            //write each fee
            foreach(DistributorFeeDataItem item in DistributorFee.DistributorFeeData)
            {
                //write the distributor fee ID
                requestWriter.Write(item.DistributorFeeId);

                //write the Fee
                requestWriter.Write((short)item.DistributorFee.ToString("F2").Length);
                
                if(item.DistributorFee.ToString("F2").Length > 0)
                {
                    requestWriter.Write(item.DistributorFee.ToString("F2").ToCharArray());
                }

                //write the Min Range
                requestWriter.Write(item.MinRange);

                //write the Max Range
                requestWriter.Write(item.MaxRange);

                //write the Fee Type Id
                if (item.FeeType == 0)
                {
                    requestWriter.Write(DistributorFee.DeviceFeeTypeId);
                }
                else
                {
                    requestWriter.Write(item.FeeType);
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

            // Create the streams we will be reading from.
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);

            // Try to unpack the data.

            // Seek past return code .
            responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
            
            //DistributorFee.OperatorId = responseReader.ReadInt32();
            //DistributorFee.DeviceId = responseReader.ReadInt32();
            //DistributorFee.DeviceFeeTypeId = responseReader.ReadInt32();
            
            //get the number of fees
            short returnDeviceFeeCount = responseReader.ReadInt16();
            
            for (int i = 0; i < returnDeviceFeeCount;i++ )
            {
                //set the unique fee ID 
                DistributorFee.DistributorFeeData[i].DistributorFeeId = responseReader.ReadInt32();
            }
                
                responseReader.Close();
        }
    }
}
