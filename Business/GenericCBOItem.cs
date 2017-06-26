using System;
using System.Collections.Generic;
using System.Text;

namespace GTI.Modules.SystemSettings.Business
{
    class GenericCBOItem
    {
        private int intCBOValueMember = 0;
        private string strCBODisplayMember = "";

        public int CBOValueMember
        {
            get { return intCBOValueMember; }
            set { intCBOValueMember = value; }
        }

        public string CBODisplayMember
        {
            get { return strCBODisplayMember; }
            set { strCBODisplayMember = value; }
        }

        public GenericCBOItem()
        {
            //constructor
        }
    }
}
