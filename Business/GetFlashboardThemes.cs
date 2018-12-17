using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTI.Modules.Shared;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class FlashboardTheme
    {
        public int ID
        {
            get;
            set;
        }
        public bool Active
        {
            get;
            set;
        }
        public string DllName
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (DisplayName == null)
                return base.ToString();
            else
                return DisplayName;
        }
    }

    public class GetFlashboardThemes : ServerMessage
    {
        public List<FlashboardTheme> Themes
        {
            get;
            private set;
        }

        public GetFlashboardThemes()
        {
            m_id = 18261;
            m_strMessageName = "Get Flashboard Themes";
            Themes = new List<FlashboardTheme>();
        }


        protected override void PackRequest()
        {
        }


        protected override void UnpackResponse()
        {
            base.UnpackResponse();

            // Create the streams we will be reading from.
            using (var responseStream = new MemoryStream(m_responsePayload))
            using (var reader = new BinaryReader(responseStream, Encoding.Unicode))
            {
                // Try to unpack the data.
                try
                {
                    // Seek past return code.
                    reader.BaseStream.Seek(sizeof(int), SeekOrigin.Begin);

                    ushort listCount = reader.ReadUInt16();
                    for (int i = 0; i < listCount; i++)
                    {
                        FlashboardTheme theme = new FlashboardTheme();

                        theme.ID = reader.ReadInt32();
                        theme.Active = reader.ReadBoolean();
                        theme.DllName = ReadString(reader);
                        theme.DisplayName = ReadString(reader);

                        Themes.Add(theme);
                    }
                }
                catch (EndOfStreamException e)
                {
                    throw new MessageWrongSizeException(m_strMessageName, e);
                }
                catch (Exception e)
                {
                    throw new ServerException(m_strMessageName, e);
                }

                // Close the streams.
                reader.Close();
            }
        }
    }
}
