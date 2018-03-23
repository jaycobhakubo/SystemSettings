﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.UI;

namespace GTI.Modules.SystemSettings.Business
{
    public class GetRNGRemoteTypes : ServerMessage
    {
        public List<RNGTypeData> ListRNGType { get; set; }

        public GetRNGRemoteTypes()
        {
            m_id = 18254;
            ListRNGType = new List<RNGTypeData>();
        }

        protected override void PackRequest()
        {
            MemoryStream requestStream = new MemoryStream();
            BinaryWriter requestWriter = new BinaryWriter(requestStream, Encoding.Unicode);
            m_requestPayload = requestStream.ToArray();
            //throw new NotImplementedException();
        }

        protected override void UnpackResponse()
        {
            base.UnpackResponse();
            MemoryStream responseStream = new MemoryStream(m_responsePayload);
            BinaryReader responseReader = new BinaryReader(responseStream, Encoding.Unicode);
            responseReader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);
            ushort tempLength = 0;

            ushort Count = responseReader.ReadUInt16();
          
            for (int iType = 0; iType < Count; iType++)
            {
                var tempValue = new RNGTypeData();
                tempValue.RNGTypeID = responseReader.ReadInt32();//1
                tempLength = responseReader.ReadUInt16();//3
                tempValue.RNGType = new string(responseReader.ReadChars(tempLength));
                ListRNGType.Add(tempValue);
            }
            responseReader.Close();
        }


    }
}
