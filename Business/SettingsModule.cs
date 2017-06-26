// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2007 GameTech
// International, Inc.

using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.Business
{
	/// <summary>
	/// The implementation of the IGTIModule COM interface for the Module.
	/// </summary>
	[
		ComVisible(true),
		Guid("C7103876-A9F9-4b66-9F3D-E150ACB466E5"),
		ClassInterface(ClassInterfaceType.None),
		ComSourceInterfaces(typeof(_IGTIModuleEvents)),
		ProgId("GTI.Modules.SystemSettings")
	]

	public sealed class SystemSettings : IGTIModule
	{
        #region Constants
        private const string ModuleName = "GameTech Edge Bingo System Settings Module"; // Rally TA8833
        #endregion

        #region Events
        /// <summary>
        /// The signature of the 'Stopped' COM connection point handler.
        /// </summary>
        /// <param name="moduleId">The id of the stopped module.</param>
        public delegate void IGTIModuleStoppedEventHandler(int moduleId);

        /// <summary>
        /// The event that will translate to the COM connection point.
        /// </summary>
        public event IGTIModuleStoppedEventHandler Stopped;

        /// <summary>
        /// Occurs when something wants the module to stop itself.
        /// </summary>
        internal event EventHandler StopUnitMgmt;

		/// <summary>
		/// Occurs when something wants receipt management to come to the front 
		/// of the screen.
		/// </summary>
		internal event EventHandler BringToFront;

        // PDTS 966
        /// <summary>
        /// Occurs when a server initiated message was received from the 
        /// server.
        /// </summary>
        internal event MessageReceivedEventHandler ServerMessageReceived; 
		#endregion

        #region Member Variables
        private int m_moduleId;
        private Thread m_unitThread;
		private Mutex m_Mutex = null;
        #endregion

        #region Member Methods
        /// <summary>
        /// Starts the module.  If the module is already started nothing
        /// happens.  This method will block if another thread is currently
        /// executing it.
        /// </summary>
        /// <param name="moduleId">The id to be given to the module.</param>
        public void StartModule(int moduleId)
        {
			// Check if an instance is already running, if not create a mutex so other instances will not launch
			string strModuleName = "System Settings";
			if (Common.MutexExists(strModuleName))
			{
				return;
			}
			else
			{
				// Create a mutex, but leave it unlocked so we can open it from another process
				m_Mutex = new Mutex(false, strModuleName);
			}

            // Assign the id.
            m_moduleId = moduleId;

            // Create a thread
            m_unitThread = new Thread(Run);

            // Change the thread regional settings to the current OS 
            // globalization info.
            m_unitThread.CurrentUICulture = CultureInfo.CurrentCulture;

			// Set the apartment state to STA so we can use OLE controls like OpenFileDialog
			if (!m_unitThread.TrySetApartmentState(ApartmentState.STA))
			{
				MessageForm.Show(Common.ActiveWnd, "Unable to set apartment state.");
			}

            // Start it.
            m_unitThread.Start();

        }

        /// <summary>
        /// Creates the UnitManager object and blocks until the manager is 
        /// told to close or the user closes the it.
        /// </summary>
        private void Run()
        {
            SettingsManager manager = null;

            try
            {
                // Create and initialize a new UnitManager object.
                manager = new SettingsManager();
                manager.Initialize(true);

                // Listen for the event where something wants the manager 
                // to stop.
                StopUnitMgmt += new EventHandler(manager.CloseMainForm);
				BringToFront += new EventHandler(manager.BringToFront);

				if (manager.IsInitialized)
				{
					// Close the loading form
					manager.DisposeLoadingForm();

					// Show the manager and block.
					manager.Start();
				}
				else
				{
					MessageForm.Show("The System Settings module failed to initialize properly, and will now shut down. Check to be sure the GTI Server is running.");
				}
            }
            catch(Exception e)
            {
                MessageBoxOptions options = 0;

                if(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
                    options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;

                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Resources.ModuleError, e.Message + "\n" + e.StackTrace),
                                Resources.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                options);
            }
            finally
            {
				// Release the mutex
				if (m_Mutex != null)
				{
					m_Mutex.Close();
				}

				try
                {
                    // Shutdown the Module.
                    if(manager != null)
                    {
                        manager.Shutdown();
                        manager = null;
                    }

                    OnStop();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// This method blocks until the module is stopped.  If the module is 
        /// already stopped nothing happens.
        /// </summary>
        public void StopModule()
        {
            if(m_unitThread != null)
            {
                // Send the stop event to module's controller.
                EventHandler stopHandler = StopUnitMgmt;

                if(stopHandler != null)
                    stopHandler(this, new EventArgs());

                m_unitThread.Join();
            }
        }

        /// <summary>
        /// Signals the COM connection point that we have stopped.
        /// </summary>
        internal void OnStop()
        {
            IGTIModuleStoppedEventHandler handler = Stopped;

            if(handler != null)
                handler(m_moduleId);
        }

        /// <summary>
        /// Returns the name of this GTI module.
        /// </summary>
        /// <returns>The module's name.</returns>
        public string QueryModuleName()
        {
            return ModuleName;
        }

		/// <summary>
		/// Tells the module to bring itself to the front of the screen.
		/// </summary>
		public void ComeToFront()
		{
			EventHandler handler = BringToFront;

			if (handler != null)
				handler(this, new EventArgs());
		}

        // PDTS 966
        /// <summary>
        /// Tells the module that a server initiated message was received.
        /// </summary>
        /// <param name="commandId">The id of the message received.</param>
        /// <param name="messageData">The payload data of the message or null 
        /// if the message has no data.</param>
        public void MessageReceived(int commandId, object msgData)
        {
            MessageReceivedEventArgs args = new MessageReceivedEventArgs(commandId, msgData);

            MessageReceivedEventHandler handler = ServerMessageReceived;

            if(handler != null)
                handler(this, args);
        }
		#endregion
    }
}
