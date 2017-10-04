// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2007 GameTech
// International, Inc.

using System;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.UI;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings.Business
{
    /// <summary>
    /// Represents the System Settings application.
    /// </summary>
    public sealed class SettingsManager
    {
        #region Constants and Data Types
        private const int ServerCommShutdownWait = 15000;
        private const string LogPrefix = "SystemSettings - ";
        #endregion

        #region Member Variables
        // System Related
        private bool m_initialized;

        private int m_deviceId;
        private int m_machineId;
		private int m_operatorId;
		private int m_staffId;

        private ModuleSettings m_settings;

        private bool m_loggingEnabled;
        private object m_logSync = new object();

        // UIs
        private SplashScreen m_splashScreen;
        private MainForm m_mainForm;
        private WaitForm m_waitForm;
        #endregion

        #region Member Methods
        /// <summary>
        /// Initializes all the UnitManager's data.
        /// </summary>
        /// <param name="showLoadingForm">true to show the module's loading
        /// form; otherwise false.</param>
        public void Initialize(bool showLoadingForm)
        {
            // Check to see if we are already initialized.
            if(m_initialized)
                return;

            ModuleComm modComm = null;

            // Get the system related ids.
            try
            {
                modComm = new ModuleComm();

                m_deviceId = modComm.GetDeviceId();
                m_machineId = modComm.GetMachineId();
				m_operatorId = modComm.GetOperatorId();
				m_staffId = modComm.GetStaffId();

            }
            catch(Exception e)
            {
                MessageForm.Show(Common.ActiveWnd , string.Format(CultureInfo.CurrentCulture, Resources.GetDeviceInfoFailed, e.Message));
                return;
            }

            Application.EnableVisualStyles(); // allows us to do ctrl+a on textboxes... If it breaks something, remove it.

            // Create a settings object with the default values.           
            m_settings = new ModuleSettings();

            // Check to see what resolution to run in.
            if(m_deviceId == Device.POSPortable.Id)
                m_settings.DisplayMode = new CompactDisplayMode();
            else
                m_settings.DisplayMode = new NormalDisplayMode();

            // Create and show the loading form.
            m_splashScreen = new SplashScreen();

            m_splashScreen.Version = GetVersionAndCopyright(true);
            m_splashScreen.Cursor = Cursors.WaitCursor;
			m_splashScreen.ApplicationName = "System Settings";
			m_splashScreen.Status = "Initializing... Please wait.";

			if (showLoadingForm)
			{
				m_splashScreen.Show();
				m_splashScreen.Update();
			}

			// Initialize GTIClient
			GTIClient.OperatorId = m_operatorId;
			GTIClient.StaffId = m_staffId;
			if (GTIClient.InitModuleData() != GTIServerReturnCode.Success)
			{
				MessageForm.Show(Common.ActiveWnd, Resources.InitFailed);
				return;
			}

            // Get the machine's settings from the server.
            m_splashScreen.Status = Resources.LoadingMachineInfo;
            Application.DoEvents();

            try
            {
                GetSettings();
            }
            catch(Exception e)
            {
                MessageForm.Show(string.Format(CultureInfo.CurrentCulture, Resources.GetSettingsFailed, e.Message));
                return;
            }

            // Check to see if we want to log everything.
            try
            {
                if(m_settings.EnableLogging)
                {
                    Logger.EnableFileLog(m_settings.LoggingLevel, m_settings.FileLogRecycleDays);
                    Logger.StartLogger(Logger.StandardPrefix);
                    m_loggingEnabled = true;
                    Log(string.Format(CultureInfo.InvariantCulture, "Initializing System Settings ({0})...", GetVersionAndCopyright(false)), LoggerLevel.Information);
                }
            }
            catch(Exception e)
            {
                MessageForm.Show(string.Format(CultureInfo.CurrentCulture, Resources.LogFailed, e.Message));
                return;
            }

            // Check to see if we only want to display in English.
            if(m_settings.ForceEnglish)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                Log("Forcing English.", LoggerLevel.Configuration);
            }
 
            // Create the main form.
            m_mainForm = new MainForm();

            m_splashScreen.Cursor = Cursors.Default;

            Application.DoEvents();
            m_initialized = true;

            Log("System Settings Initialized!", LoggerLevel.Debug);
        }


		/// <summary>
		/// Tells module to bring the main form to the front.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An EventArgs object that contains the 
		/// event data.</param>
		internal delegate void activateDelegate();
		internal void BringToFront(object sender, EventArgs e)
		{
			if (m_initialized && m_mainForm != null)
			{
				if (m_mainForm.InvokeRequired)
				{
					m_mainForm.Invoke(new activateDelegate(m_mainForm.SetWindowNormal));
				}
				else
				{
					m_mainForm.SetWindowNormal();
				}
			}
		}
		
		/// <summary>
        /// Returns a string with the version and copyright information of 
        /// UnitMgmt.
        /// </summary>
        /// <param name="justVersion">true if just the version is to be 
        /// returned; otherwise false.</param>
        /// <returns>A string with the version and optionally the copyright 
        /// information.</returns>
        public static string GetVersionAndCopyright(bool justVersion)
        {
            // Get version.
            // TTP 50356
            string version = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(CultureInfo.InvariantCulture) +
                "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(CultureInfo.InvariantCulture) +
                "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString(CultureInfo.InvariantCulture) +
                "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString(CultureInfo.InvariantCulture);

            // Get copyright.
            if(!justVersion)
            {
                string copyright = string.Empty;

                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                if(attributes.Length > 0)
                    copyright = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;

                return version + " - " + copyright;
            }
            else
                return version;
        }

        /// <summary>
        /// Writes a message to the UnitMgmt's log.
        /// </summary>
        /// <param name="message">The message to write to the log.</param>
        /// <param name="level">The level of the message.</param>
        /// <returns>true if success; otherwise false.</returns>
        public bool Log(string message, LoggerLevel level)
        {
            lock(m_logSync)
            {
                StackFrame frame = new StackFrame(1, true);
                string fileName = frame.GetFileName();
                int lineNumber = frame.GetFileLineNumber();
                message = SettingsManager.LogPrefix + message;

                if(m_loggingEnabled)
                {
                    try
                    {
                        switch(level)
                        {
                            case LoggerLevel.Severe:
                                Logger.LogSevere(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Warning:
                                Logger.LogWarning(message, fileName, lineNumber);
                                break;

                            default:
                            case LoggerLevel.Information:
                                Logger.LogInfo(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Configuration:
                                Logger.LogConfig(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Debug:
                                Logger.LogDebug(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Message:
                                Logger.LogMessage(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.SQL:
                                Logger.LogSql(message, fileName, lineNumber);
                                break;
                        }

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Shows the main form modally.
        /// </summary>
        public void Start()
        {
            if(m_initialized && m_mainForm != null)
            {
                Log("Starting System Settings.", LoggerLevel.Information);

                Application.Run(m_mainForm);
            }
        }

        /// <summary>
        /// Tells module to close the main form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        public void CloseMainForm(object sender, EventArgs e)
        {
            if(m_mainForm != null)
                m_mainForm.Close();
        }


        /// <summary>
        /// Disposes of the LoadingForm.
        /// </summary>
        public void DisposeLoadingForm()
        {
            if(m_splashScreen != null)
            {
                m_splashScreen.Hide();
                m_splashScreen.Dispose();
                m_splashScreen = null;
            }
        }

        /// <summary>
        /// Prepares the system for shutdown because server 
        /// communications failed.
        /// </summary>
        internal void ServerCommFailed()
        {
            // Display a message saying the module is closing.
            MessageForm.Show(Resources.ServerCommFailed + "\n\n" + Resources.ShuttingDown, "" , MessageFormTypes.Pause, ServerCommShutdownWait);

            Log("Server communications failed.  Shutting down...", LoggerLevel.Severe);
            CloseMainForm(this, new EventArgs());
        }

        /// <summary>
        /// Gets the settings from the server.
        /// </summary>
        private void GetSettings()
        {
            // Send the first message (for global settings).
            GetSettingsMessage settingsMsg = new GetSettingsMessage(m_machineId, SettingsCategory.GlobalSystemSettings);

            try
            {
                settingsMsg.Send();
            }
            catch(Exception e)
            {
				MessageForm.Show(Common.ActiveWnd, "An error occurred while retrieving module settings : " + e.Message);

            }

            // Loop through each setting and parse the value.
            SettingValue[] stationSettings = settingsMsg.Settings;

            foreach(SettingValue setting in stationSettings)
            {
                m_settings.LoadSetting(setting);
            }

            // Now load all the module specific settings.
            // TODO Define UnitMgmt specific settings.
            /*
            settingsMsg = new GetSettingsMessage(m_machineId, SettingsCategory.UnitManagement);

            try
            {
                settingsMsg.Send();
            }
            catch(Exception e)
            {
                ReformatException(e);
            }

            // Loop through each setting and parse the value.
            stationSettings = settingsMsg.Settings;

            foreach(SettingValue setting in stationSettings)
            {
                m_settings.LoadSetting(setting);
            }
            */
        }


        /// <summary>
        /// Cancels any pending transactions and shuts down module.
        /// </summary>
        public void Shutdown()
        {
            Log("Shutting down.", LoggerLevel.Debug);


            if(m_waitForm != null)
            {
                m_waitForm.Dispose();
                m_waitForm = null;
            }

            if(m_mainForm != null)
            {
                m_mainForm.Dispose();
                m_mainForm = null;
            }

            if(m_splashScreen != null)
            {
                m_splashScreen.Dispose();
                m_splashScreen = null;
            }

            Log("Shutdown complete.", LoggerLevel.Information);

            lock(m_logSync)
            {
                m_loggingEnabled = false;
            }

            m_initialized = false;
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets whether the UnitManager was initialized.
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                return m_initialized;
            }
        }

        /// <summary>
        /// Gets UnitMgmt's current settings.
        /// </summary>
        internal ModuleSettings Settings
        {
            get
            {
                return m_settings;
            }
        }

        #endregion
    }
}
