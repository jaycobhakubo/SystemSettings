using System;
using System.Collections.Generic;
using System.Text;

namespace GTI.Modules.SystemSettings.Business
{
    class SceneItem
    {
        private int intSceneID = 0;
        private string strSceneName = "";
        private bool boolIsActive = true;

        public int pSceneID
        {
            get { return intSceneID; }
            set { intSceneID = value; }
        }

        public string pSceneName
        {
            get { return strSceneName; }
            set { strSceneName = value; }
        }

        public bool pIsActive
        {
            get { return boolIsActive; }
            set { boolIsActive = value; }
        }

        public SceneItem()
        {
            //constructor
        }
    }
}
