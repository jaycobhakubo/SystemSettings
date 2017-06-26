using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.Shared;

namespace GTI.Modules.SystemSettings.Data
{
	// High level interface to GTI Server for use by GUI
    class GTIClient
    {
		private static Int32 m_nStaffId;
		private static Int32 m_nOperatorId;

		// Private constructor for static class
		private GTIClient() { }

        private static void SendMessage(ServerMessage msg)
        {
			// Since this call may take a while, process any queued up messages here like refreshing the screen
			Application.DoEvents();

			GTIServerReturnCode nError = GTIServerReturnCode.GeneralError;

			Common.BeginWait();

			try
			{
				msg.Send();
				nError = msg.ServerReturnCode;
			}
			catch (MessageWrongSizeException)
			{
				nError = GTIServerReturnCode.InvalidResonseSize;
			}
			catch (ServerCommException)
			{
				nError = GTIServerReturnCode.ServerCommError;
			}
			catch (ServerException)
			{
				nError = msg.ServerReturnCode;
			}

			Common.EndWait();

			// If unsuccessful, give error message
            if ( nError != GTIServerReturnCode.Success )
            {
				MessageForm.Show(Common.ActiveWnd, String.Format(Resources.MessageError, msg.MessageName, GetServerErrorString(nError)), Resources.Error );
            }
        }

		public static string GetServerErrorString(GTIServerReturnCode nErrorCode)
		{
			// Server error strings
			string[] GTIServerErrors = {
            Resources.Success , 
            Resources.ErrorGeneral ,
            Resources.ErrorBusy ,
            Resources.ErrorParam , 
            Resources.ErrorSql , 
            Resources.ErrorNoAuth ,
			Resources.ErrorStringLen ,
			Resources.ErrorServer ,
			Resources.ErrorComm };


			// Validate parameter
			int nError = (int)nErrorCode;
			if ((-nError >= GTIServerErrors.Length) || (-nError < 0))
			{
				return String.Format(Resources.ErrorUnknown, nError);
			}

			return GTIServerErrors[-nError];
		}

/////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Message Section
/////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static GTIServerReturnCode InitModuleData()
		{
			//GTIServerReturnCode nError = GTIServerReturnCode.GeneralError;

			//// Get POS Menus
			//if ((nError = GetPosMenus(out Common.arrPosMenus)) != GTIServerReturnCode.Success)
			//{
			//    MessageForm.Show(Common.ActiveWnd, Resources.PosMenusNotFound);
			//    return bResult;
			//}

			//// Get Program arrMachines
			//if ((nError = GetProgramList(out Common.arrPrograms)) != GTIServerReturnCode.Success)
			//{
			//    MessageForm.Show(Common.ActiveWnd, Resources.ProgramListNotFound);
			//    return bResult;
			//}

			return GTIServerReturnCode.Success;
		}



#region Public Properties
		public static Int32 StaffId
		{
			get { return m_nStaffId; }
			set { m_nStaffId = value; }
		}

		public static Int32 OperatorId
		{
			get { return m_nOperatorId; }
			set { m_nOperatorId = value; }
		}

#endregion
	
	}
}
