using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    public class AllSettingsModel
    {
        public List<OperatorSetting> m_lOperatorSettings;
        
        public AllSettingsModel()
        {
            m_lOperatorSettings = new List<OperatorSetting>();
        }

        internal void LoadValues()
        {
            //OperatorSetting operator1 = new OperatorSetting(1);
            //operator1.LoadSettings();
            
            //m_lOperatorSettings.Add(operator1);
            
        }
    }
    public class OperatorSetting
    {
        public Dictionary<int, string> m_settingDictionary;
        public int m_OperatorID;

        public OperatorSetting(int operatorID)
        {
            m_OperatorID = operatorID;
            m_settingDictionary = new Dictionary<int, string>();
        }

        public void LoadSettings()
        {
            Common.GetOperatorSettings(m_OperatorID);
            SettingValue tempValue;
            Setting tempSetting;
            EnumConverter converter = new EnumConverter(typeof(Setting));
            foreach (int enumId in Enum.GetValues(typeof(Setting)))
            {
                
                tempSetting = (Setting)Enum.Parse(typeof(Setting),enumId.ToString());
                Common.GetOpSettingValue(tempSetting, out tempValue);
                m_settingDictionary.Add(enumId, tempValue.Value);
            }
        }
    }
}
