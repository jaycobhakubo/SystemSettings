using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.SystemSettings.Business
{
    public class RemoveDistributorFeesMessage : ServerMessage
    {
        private List<DistributorFeeDataItem> m_distributorFeeList;

        /// <summary>
        /// Removes the distributor fees in the list.  This ignores fees with a fee ID of 0
        /// </summary>
        /// <param name="feeList"> a list of fees</param>
        public RemoveDistributorFeesMessage(List<DistributorFeeDataItem> feeList)
        {
            m_id = 25019;
            DistributorFeeList = feeList;
        }

        public List<DistributorFeeDataItem> DistributorFeeList
        {
            get { return m_distributorFeeList; }
            set { m_distributorFeeList = value; }
        }

        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            List<DistributorFeeDataItem> feeList = m_distributorFeeList.FindAll(i => i.DistributorFeeId != 0);

            if (feeList != null )
            {
                //write the count
                requestWriter.Write((short) feeList.Count);

                //write the feeId
                foreach (DistributorFeeDataItem item in m_distributorFeeList)
                {
                    //write the distributor fee ID
                    requestWriter.Write(item.DistributorFeeId);
                }
            }

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }
        
    }
}