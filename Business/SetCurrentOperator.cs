// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2009 GameTech
// International, Inc.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

namespace GTI.Modules.Shared
{
    public class SetCurrentOperator : ServerMessage
    {
        #region Member Variables

        
        private int m_OperatorParameters;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GetOperatorDataMessage class with the specified operator Id
        /// </summary>
        public SetCurrentOperator(int operatorId)
            
        {
            m_id = 18130; // Set Machine Operator
            m_OperatorParameters = operatorId;
        }

        #endregion

        #region Member Methods
        /// <summary>
        /// Prepares the request to be sent to the server.
        /// </summary>
        protected override void PackRequest()
        {
            // Create the streams we will be writing to.
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);

            // Operator Id
            requestWriter.Write(m_OperatorParameters);

            // Set the bytes to be sent.
            m_requestPayload = requestStream.ToArray();

            // Close the streams.
            requestWriter.Close();
        }

        
        #endregion

    }
}

