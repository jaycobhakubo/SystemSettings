using System;
using System.Collections.Generic;
using System.Text;

namespace GTI.Modules.SystemSettings.Business
{
    class MotifItem
    {
        private int intMotifID = 0;
        private string strMotifName = "";
        private bool boolIsDefault = false;

        public int MotifID
        {
            get { return intMotifID; }
            set { intMotifID = value; }
        }

        public string MotifName
        {
            get { return strMotifName; }
            set { strMotifName = value; }
        }

        public bool IsDefault
        {
            get { return boolIsDefault; }
            set { boolIsDefault = value; }
        }

        public MotifItem()
        {
            //constructor
        }
    }
}
