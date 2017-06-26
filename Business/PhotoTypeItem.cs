using System;
using System.Collections.Generic;
using System.Text;

namespace GTI.Modules.SystemSettings.Business
{
    class PhotoTypeItem
    {
        private int intPhotoTypeID = 0;
        private string strPhotoTypeDesc = "";

        public int PhotoTypeID
        {
            get { return intPhotoTypeID; }
            set { intPhotoTypeID = value; }
        }

        public string PhotoTypeDesc
        {
            get { return strPhotoTypeDesc; }
            set { strPhotoTypeDesc = value; }
        }

        public PhotoTypeItem()
        {

        }
    }
}
