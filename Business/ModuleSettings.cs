// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2007 GameTech
// International, Inc.

using System;
using System.Globalization;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Business
{
    /// <summary>
    /// Contains all the different settings for the UnitMgmt module.
    /// </summary>
    internal class ModuleSettings
    {
        #region Member Variables
        protected object m_syncRoot = new object();
        public static DisplayMode m_displayMode;
        protected bool m_forceEnglish;
        protected bool m_enableLogging;
        protected int m_loggingLevel;
        protected int m_fileLogRecycleDays;
        #endregion

        #region Member Methods
        /// <summary>
        /// Parses a setting from the server and loads it into the 
        /// ModuleSettings, if valid.
        /// </summary>
        /// <param name="setting">The setting to parse.</param>
        public void LoadSetting(SettingValue setting)
        {
            try
            {
                Setting param = (Setting)setting.Id;

                switch(param)
                {
                    case Setting.ForceEnglish:
                        m_forceEnglish = Convert.ToBoolean(setting.Value, CultureInfo.InvariantCulture);
                        break;

                    case Setting.EnableLogging:
                        m_enableLogging = Convert.ToBoolean(setting.Value, CultureInfo.InvariantCulture);
                        break;

                    case Setting.LoggingLevel:
                        m_loggingLevel = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                        break;

                    case Setting.LogRecycleDays:
                        m_fileLogRecycleDays = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                        break;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets an object that can be used to synchronize access to 
        /// the settings.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return m_syncRoot;
            }
        }

        /// <summary>
        /// Gets or sets the display mode to use for user interfaces.
        /// </summary>
        public DisplayMode DisplayMode
        {
            get
            {
                return m_displayMode;
            }
            set
            {
                m_displayMode = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to force the program to display in the 
        /// English language.
        /// </summary>
        public bool ForceEnglish
        {
            get
            {
                return m_forceEnglish;
            }
            set
            {
                m_forceEnglish = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to log output.
        /// </summary>
        public bool EnableLogging
        {
            get
            {
                return m_enableLogging;
            }
            set
            {
                m_enableLogging = value;
            }
        }

        /// <summary>
        /// Gets or sets level of logging.
        /// </summary>
        public int LoggingLevel
        {
            get
            {
                return m_loggingLevel;
            }
            set
            {
                m_loggingLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of days to keep a file log.
        /// </summary>
        public int FileLogRecycleDays
        {
            get
            {
                return m_fileLogRecycleDays;
            }
            set
            {
                m_fileLogRecycleDays = value;
            }
        }
        #endregion
    }
}
