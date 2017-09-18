using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Business;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.SystemSettings.Data;

namespace GTI.Modules.SystemSettings
{
	/// <summary>
	/// Common class
	/// </summary>
	 class Common
	{
		// Private constructor
		static Common() 
        {
            m_GlobalSettings  = new SortedSet<int>
            {
                (int)Setting.MaxCreditWinAmount , 
                (int)Setting.TaxFormMinWinAmount ,
                (int)Setting.CrateServerAddress , 
                (int)Setting.FlashboardInterfacePort ,
                (int)Setting.FlashBoardInterfaceType , 
                (int)Setting.RFSerialPort ,
                (int)Setting.AllowQuantitySale ,
                (int)Setting.PrintQuantitySaleReceipts , 
                (int)Setting.UseVirtualFlashboardCamera ,
                (int)Setting.PreviousWinnerDisplayInterval , 
                (int)Setting.PreviousWinnerDisplayTime ,
                (int)Setting.WinnerPollInterval , 
                (int)Setting.ScreenSaverTimeout ,
                (int)Setting.BallCallCameraChannel , 
                (int)Setting.AllowPlayTypeToggle ,
                (int)Setting.PlayType ,
                (int)Setting.ShareOperatorPoints ,
                (int)Setting.ShareOperatorCredits ,
                (int)Setting.ForcePackToPlayer ,
                (int)Setting.PrintCardFaces , 
                (int)Setting.PrintCardNumbers ,
                (int)Setting.UseConsecutiveCards , 
                (int)Setting.UseSameCards ,
                (int)Setting.PrintFacesToGlobalPrinter ,
                (int)Setting.LockSessionVoids , 
                (int)Setting.PinExpireDays ,
                (int)Setting.CrateServerPortNumber , 
                (int)Setting.RaffleDisplayDuration ,
                (int)Setting.WiredNetworkLossThreshold , 
                (int)Setting.WirelessNetworkLossThreshold ,
                (int)Setting.RestartNumbersOnReset , 
                (int)Setting.BalanceSales ,
                (int)Setting.DTRDelay , 
                (int)Setting.ProgramPacketDelay ,
                (int)Setting.SilentPollingInterval , 
                (int)Setting.PingTimeoutMilliseconds ,
                (int)Setting.GlobalPrinterName , 
                (int)Setting.UseExchangeRateOnSale ,
                (int)Setting.EnableRegisterSalesReport , 
                (int)Setting.PrizeFeeAmount ,
                (int)Setting.PrizeFeeAmountType , 
                (int)Setting.PrizeFeeMinAmount ,
                (int)Setting.MinimumSaleAllowed , 
                (int)Setting.ShowPayoutAmount ,
                (int)Setting.MinimumPasswordLength , 
                (int)Setting.AutomaticUnlockTime ,
                (int)Setting.PreviousPasswordNumber , 
                (int)Setting.PasswordLockoutAttempts ,
                (int)Setting.PasswordComplexitySetting , 
                (int)Setting.UseHardwareAcceleration ,
                (int)Setting.TravStart , 
                (int)Setting.TravEnd ,
                (int)Setting.TrackStart , 
                (int)Setting.TrackEnd,
                //New Settings to track
                (int)Setting.ShowMouseCursor,
                (int)Setting.POSReceiptPrinterName,
                (int)Setting.CashDrawerEjectCode,
                (int)Setting.DatabaseServer,
                (int)Setting.DatabaseName,
                (int)Setting.DatabaseUser,
                (int)Setting.DatabasePassword,
                (int)Setting.ForceEnglish,     
                (int)Setting.VideoAdapterNumber,
                (int)Setting.ScreenWidth,
                (int)Setting.ScreenHeight,
                (int)Setting.RefreshRate,
                (int)Setting.ColorDepth,
                (int)Setting.CurrencyRegion,
                (int)Setting.EnableLogging,
                (int)Setting.KioskReceiptPrinterName,
                (int)Setting.LatchBallCalls,
                (int)Setting.OpVipCardRequired,
                (int)Setting.CentralServerName,
                (int)Setting.SellElectronics,
                (int)Setting.PrintRegisterReceiptsNumber,
                (int)Setting.DisclaimerLine1,
                (int)Setting.DisclaimerLine2,
                (int)Setting.DisclaimerLine3,
                (int)Setting.LoggingLevel,
                (int)Setting.LogRecycleDays,
                (int)Setting.MaxBetValue,
                (int)Setting.ServerInstallDrive,
                (int)Setting.ServerInstallRootDirectory,
                (int)Setting.ClientInstallDrive,
                (int)Setting.ClientInstallRootDirectory,
                (int)Setting.DownloadRecycleDays,
                (int)Setting.ExportDataToCentral,
                (int)Setting.MagneticCardReaderMode,
                (int)Setting.MagneticCardReaderParameters,
                (int)Setting.ClientBroadcastRate,
                (int)Setting.MaxStaffMachines,
                (int)Setting.UnitAssignmentReceipt,
                (int)Setting.DefaultCardColor,
                (int)Setting.DefaultCardBackgroundColor,
                (int)Setting.UnassignUnitsOnSessionChange,
                (int)Setting.MaxPayoutPerSession,
                (int)Setting.WinNotificationToCaller,
                (int)Setting.RandomRaffleParticipants,
                (int)Setting.AllowMultipleOperators,
                (int)Setting.ScreenSaverEnabled,
                (int)Setting.ScreenSaverWait,
                (int)Setting.UsePasswordKeypad, 
                (int)Setting.ThirdPartyLocation,
                (int)Setting.ThirdPartyTimeout,
                (int)Setting.ThirdPartyPointScaleNumerator,
                (int)Setting.ThirdPartyPointScaleDenominator,
                (int)Setting.ThirdPartyRedeemNumerator,
                (int)Setting.ThirdPartyRedeemDenominator,
                (int)Setting.ThirdPartyPlayerInterfaceID,
                (int)Setting.ThirdPartyPlayerInterfaceTimeoutOption,
                (int)Setting.ThirdPartyPlayerInterfaceExternalRating,
                (int)Setting.ThirdPartyPlayerInterfacePINLength,
                (int)Setting.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForPlayerInfo,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForPoints,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRating,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRedemption,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRatingVoid,
                (int)Setting.ThirdPartyPlayerInterfaceNeedPINForRedemptionVoid,
	            (int)Setting.EnableValidation,
    	        (int)Setting.ProductValidationCardCount,
        	    (int)Setting.MaxValidationPerTransaction
            };
        }

		// Constants
		const int ADMIN_STAFF_ID = 2;

        private static readonly SortedSet<int> m_GlobalSettings; 
		// Public Properties
		#region "Public Properties"
		private static int m_nOperatorId = 0;
        private static int m_nCompanyId = 0;
        private static int m_nStaffId = 0;
        private static int m_nMachineId = 0;
        private static int m_nDeviceId = 0;
		private static bool m_bInitialized = false;
		private static bool m_bCreditEnabled = false;
        private static bool m_bTXPayoutsEnabled = false;
        private static bool m_bMultipleCharities;
	    private static string m_sOperatorName;
	    private static int m_nCurrentOperatorId = 0;
	    private static bool m_bCBBEnabled = false;//RALLY TA 6095 disable CBB

		// Operator / Machine data
		public static GetOperatorCompleteMessage m_GetOperatorCompleteMessage;
		public static GetSettingsOperatorMessage m_GetSettingsOperatorMessage;
		public static GetMachineDataMessage m_GetMachineDataMessage;
		public static GetSettingsMessage m_GetSystemSettingsMessage;
	    public static GetLicenseFileSettingsMessage m_GetLicenseFileMessage;
	    public static GetHallSettingsMessage m_GetHallSettingsMessage;

        public static bool MultipleCharites
        {
            get { return Common.m_bMultipleCharities; }
            set { Common.m_bMultipleCharities = value; }
        }

        //START RALLY TA 6095 -- check CBB enableability in license file
	    public static bool CBBEnabled
	    {
            get { return Common.m_bCBBEnabled; }
            set { Common.m_bCBBEnabled = value;}
	    }
        //END RALLY TA 6095
	    public static string OperatorName
	    {
            set { m_sOperatorName = value; }
            get { return m_sOperatorName; }
	    }

        public static int OperatorId
        {
            set { m_nOperatorId = value; }
            get { return m_nOperatorId; }
        }

		public static int CompanyId
        {
            set { m_nCompanyId = value; }
            get { return m_nCompanyId; }
        }

		public static int StaffId
        {
			set { m_nStaffId = value; }
			get { return m_nStaffId; }
        }

		public static int DeviceId
        {
			set { m_nDeviceId = value; }
			get { return m_nDeviceId; }
        }

		public static int MachineId
        {
			set { m_nMachineId = value; }
			get { return m_nMachineId; }
        }

		public static bool IsInitialized
		{
			get { return m_bInitialized; }
		}

		public static bool IsAdmin
		{
			get { return (StaffId == ADMIN_STAFF_ID); }
		}

		public static bool IsCreditEnabled
		{
			get { return m_bCreditEnabled; }
		}

        public static bool AreTXPayoutsEnabled
        {
            get { return m_bTXPayoutsEnabled; }
        }

		#endregion // Member properties


		// Public Static Methods
		#region Public static methods


		public static bool InitModuleData(int OperatorIDParameter)
		{
			try
			{
                ModuleComm modComm = null;

                modComm = new ModuleComm();
                if (OperatorIDParameter == 0)
                {
                    m_nOperatorId = modComm.GetOperatorId();
                    m_nCurrentOperatorId = m_nOperatorId;
                }
                else
                {
                    m_nOperatorId = OperatorIDParameter;
                } 
                m_nDeviceId = modComm.GetDeviceId();
                m_nMachineId = modComm.GetMachineId();
                m_nStaffId = modComm.GetStaffId();

				if (!GetHallSettings())
				{
				    return false;
				}
				// Get the operator table data
				if (!GetOperatorData())
				{
					return false;
				}

				// Get the operator settings
				if (!GetOperatorSettings())
				{
					return false;
				}

				// Get the machine arrMachines
				if (!GetMachineData())
				{
					return false;
				}

				// Get the global settings
				if (!GetSystemSettings())
				{
					return false;
				}

                if (! GetLicenseFile())
                {
                    return false;
                }

                // Check if credit is enabled
                if (!GetCreditEnabled())
                {
                    return false;
                }

                //START RALLY TA 6095 -- set CBB enabled
                SetCBBSetting();
			    
                //END RALLY TA 6095

				// Set the company id
			    m_nCompanyId = m_GetOperatorCompleteMessage.OperatorList[0].CompanyID;

                // Set the current operator name
			    m_sOperatorName = GetCurrentOperatorName();

				// Set the flag
				m_bInitialized = true;

				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.ModuleInitFailed, e));
				return false;
			}
		}

        private static string GetCurrentOperatorName()
        {
            Operator currentOperator = m_GetOperatorCompleteMessage.OperatorList.Find(i => i.Id == m_nOperatorId);
            
            if(currentOperator != null)
            {
                return currentOperator.Name;
            }
            else
            {
                return "";
            }           
        }

        private  static bool GetLicenseFile()
        {
            
            //this is just loaded for testing
            //algorithm:
            //get message
            //for each setting in the message set the corresponding settings values
            //test settings:
            //44,98,100,113,145,153,154,155,156,157,158,180
            //44 = Setting.OpAllowReturns, operator setting, pos setting
            //98 = Setting.PrintWinners, operator setting, caller setting
            //100 = Setting.ShowWinnersOnly, operator setting, remote display settings
            //145 = Setting.ShareOperatorCredits, system setting, globals settings
            //153 = Setting.PlayAllSoundEnabled, operator setting, audio settings
            //154 = Setting.PlayModeOneAwaySound, operator setting, audio settings
            //155 = Setting.PlayWinningSoundEnabled, operator setting, audio settings
            //156 = Setting.PlayBallCallSoundEnabled, operator setting, audio settings
            //157 = Setting.PlayKeyClickEnabled , operator setting, audio settings
            //180 = Setting.ShareOperatorPoints, system setting, global settings

            m_GetLicenseFileMessage = new GetLicenseFileSettingsMessage(false);
            m_GetLicenseFileMessage.Send();
            return true;
        }
        //START RALLY TA 6095 -- Set CBB enabled
        //START RALLY TA 7896 -- Replaced getSystemFeaturesMessage with license file settings
        private static void SetCBBSetting()
        {
            //todo make this a required value
            string result = GetLicenseSettingValue(LicenseSetting.CBBEnabled);
            if (!string.IsNullOrEmpty(result))
                m_bCBBEnabled = Convert.ToBoolean(result);
            else
                m_bCBBEnabled = false;
        }
        //END RALLY TA 7896
        //END RALLY TA 6095 
        public static bool GetHallSettings()
        {
            m_GetHallSettingsMessage = new GetHallSettingsMessage();
            try
            {
                m_GetHallSettingsMessage.Send();
                if(m_GetHallSettingsMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetSystemSettingsFailed, GTIClient.GetServerErrorString(m_GetHallSettingsMessage.ServerReturnCode)));
                    return false;   
                }
                return true;
            }

            catch (Exception e)
            {

                MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetSystemSettingsFailed, e));
                return false;
            }
        }

		public static bool GetSystemSettings()
		{
		    if (m_GetSystemSettingsMessage != null)
		    {
		        return true;
		    }

		    m_GetSystemSettingsMessage = new GetSettingsMessage();

			try
			{
				m_GetSystemSettingsMessage.Send();
                if (m_GetSystemSettingsMessage.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetSystemSettingsFailed, GTIClient.GetServerErrorString(m_GetMachineDataMessage.ServerReturnCode)));
					return false;
				}
			   
				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetSystemSettingsFailed, e));
				return false;
			}   
		}

		public static bool GetMachineData()
		{
			try
			{
				// Get the active machine arrMachines
				m_GetMachineDataMessage = new GetMachineDataMessage(0);
				m_GetMachineDataMessage.Send();
				if (m_GetMachineDataMessage.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetMachineDataFailed, GTIClient.GetServerErrorString(m_GetMachineDataMessage.ServerReturnCode)));
					return false;
				}

				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetMachineDataFailed, e));
				return false;
			}
		}

		public static SMachineData[] GetMachineList(int nDeviceId)
		{
			List<SMachineData>  machineList = new List<SMachineData>();

			int nCount = m_GetMachineDataMessage.MachineDataList.Length;
			for (int i = 0; i < nCount; i++)
			{
				if (m_GetMachineDataMessage.MachineDataList[i].nDeviceId == nDeviceId)
				{
					machineList.Add(m_GetMachineDataMessage.MachineDataList[i]);
				}
			}

			return machineList.ToArray();
		}

		public static bool GetOperatorData()
		{
			try
			{
				// Get the operator table data
				m_GetOperatorCompleteMessage = new GetOperatorCompleteMessage(m_nOperatorId);
              
                m_GetOperatorCompleteMessage.Send();
				if (m_GetOperatorCompleteMessage.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetOperatorDataFailed, GTIClient.GetServerErrorString(m_GetOperatorCompleteMessage.ServerReturnCode)));
					return false;
				}

				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetOperatorDataFailed, e), Properties.Resources.ModuleName);
				return false;
			}
		}

        public static bool GetOperatorSettings(int operatorID)
        {
            m_nOperatorId = operatorID;
            GetOperatorSettings();
            return true;
        }
        //START RALLY 2018
        public static decimal GetDeviceFee(int deviceId)
        {
            decimal returnValue = 0.0M;
            if (m_GetOperatorCompleteMessage != null && m_GetOperatorCompleteMessage.OperatorList.Count > 0)
            {
                OperatorFee operatorFee = m_GetOperatorCompleteMessage.OperatorList[0].OperatorFeeList.Find(i => i.DeviceId == deviceId);
                if (operatorFee != null &&  decimal.TryParse(operatorFee.Fee, out returnValue))
                {
                    return returnValue;
                }
            }
            return returnValue;
        }
        //END RALLY 2018
        //START RALLY US2018
        public static bool SaveDeviceFees(Device[] feeArray)
        {
            // Create a message
            SetOperatorDeviceFeesMessage msg = new SetOperatorDeviceFeesMessage(Common.OperatorId, feeArray);
            try
            {
                msg.Send();
            }
            catch (Exception ex)
            {
                MessageForm.Show(String.Format(Resources.UpdDeviceFeesFailed, ex));
                return false;
            }

            // Check return value
            if (msg.ReturnCode != (int)GTIServerReturnCode.Success)
            {
                MessageForm.Show(String.Format(Resources.UpdDeviceFeesFailed, msg.ReturnCode));
                return false;
            }

            //update the local copy
            if (m_GetOperatorCompleteMessage != null && m_GetOperatorCompleteMessage.OperatorList.Count > 0 &&
                m_GetOperatorCompleteMessage.OperatorList[0].OperatorFeeList != null)
            {
                m_GetOperatorCompleteMessage.OperatorList[0].OperatorFeeList.Clear();
                foreach (Device device in feeArray)
                {
                    OperatorFee operatorFee = new OperatorFee();
                    operatorFee.DeviceId = device.Id;
                    operatorFee.Fee = device.Fee.ToString();
                    m_GetOperatorCompleteMessage.OperatorList[0].OperatorFeeList.Add(operatorFee);
                }
            }
            return true;
        }
        //END RALLY 2018
		public static bool GetOperatorSettings()
		{
			try
			{
				// Get the operator table data
				m_GetSettingsOperatorMessage = new GetSettingsOperatorMessage(m_nOperatorId);
				m_GetSettingsOperatorMessage.Send();
				if (m_GetSettingsOperatorMessage.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetOperatorSettingsFailed, GTIClient.GetServerErrorString(m_GetOperatorCompleteMessage.ServerReturnCode)), Properties.Resources.ModuleName);
					return false;
				}

				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.GetOperatorSettingsFailed, e), Properties.Resources.ModuleName);
				return false;
			}
		}

		public static bool GetCreditEnabled()
		{
            //START RALLY DE 6755
            m_bCreditEnabled = false;
            string creditEnabled = GetLicenseSettingValue(LicenseSetting.CreditEnabled);
            m_bCreditEnabled = ParseBool(creditEnabled);
            return true;
            //END RALLY DE 6755
		}

        public static bool GetTXPayoutsEnabled()
        {
            //Start TA11876
            m_bTXPayoutsEnabled = false;
            string TXPayoutsEnabled = GetLicenseSettingValue(LicenseSetting.EnableTXPayouts);
            m_bTXPayoutsEnabled = ParseBool(TXPayoutsEnabled);
            return true;
            //end TA11876
        }

		public static bool SaveOperatorData()
		{
			try
			{
				// Create a new message to save off the current operator settings
				SetOperatorCompleteMessage msg = new SetOperatorCompleteMessage(m_GetOperatorCompleteMessage.OperatorList[0]);
				msg.Send();
				if (msg.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdOperatorDataFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Properties.Resources.ModuleName);
					return false;
				}

				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdOperatorDataFailed, e), Properties.Resources.ModuleName);
				return false;
			}
		}

		public static bool SaveOperatorSettings()
		{
            return true;
		}

	    public static bool IsGlobalSetting(SettingValue val)
	    {
            return m_GlobalSettings.Contains((int)val.Id);
           
            //FIX RALLY DE 3258 added play type setting and allow play type toggle setting (134 and 146)
            //FIX RALLY DE 3290 added settings 145 and 180 share player points and player credits 
            //TASK RALLY TA 5745 added setting 196 Play with paper
            //TASK RALLY TA 6042 set force pack to player as a global value
            //TASK RALLY TA 6245 set setting 197 "allow melange special games" to a global value
            //DEFECT RALLY DE 4054, DE 4240 set settings 188 and 187 to a global value
            //RALLY DE 4075 Added setting print faces to global printer to be dependant on play with paper
            //RALLY TA 6542 Added setting for 90 number bingo
            //RALLY TA 6653 Added setting for 90 number bingo RNG 
            //RALLY DE 4052 Added Quick Pick Enabled Setting (License File only no UI)
            //RALLY DE 1937 Added Lock Session Voids Setting (License File only no UI)
            //FIX RALLY DE 4426 added pin expire days to global settings
            //FIX RALLY TA 7896 removed settings that are now license file only settings
            //RALLY DE 3523 credit enabled being saved into the operator table
            //RALLY TA 9123 crate server port setting is a global setting
            //RALLY DE 9162 Added Raffle duration in seconds setting
            //RALLY TA 9171 Added support for broadcast time out settings
            //RALLY DE 6614 Added the crate server settings to be global
            //RALLY DE7285 global printer name is now a global setting
            //RALLY US1650 disable register closing report
            //RALLY US1658 use exchange rate on sale
            //RALLY US1572 prize fees
            //RALLY US1854 minimun sale amount
            //RALLY US1897 show payout amount
            //RALLY US1940 Minimum password length, password complexity
            //RALLY US1941 Previous password number
            //RALLY US1942 Password lockout attempts
            //RALLY US1944 Automatic unlock time
            //RALLY DE10419 use hardware acceleration should be a global setting
	    }


        public static bool SaveDeviceSettings(int DeviceId, SettingValue[] arrSettings)
        {
            SetDeviceSettings msg = new SetDeviceSettings(DeviceId, arrSettings);

            try
            {
                msg.Send();

                if (msg.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Properties.Resources.ModuleName);
                    return false;
                }

                //DEFECT RALLY DE 4008 START -- global settings not updated in operator settings table
                //foreach (SettingValue settingValue in arrSettings)
                //{
                //    Setting tempSetting = (Setting)Enum.ToObject(typeof(Setting), settingValue.Id);
                //    SetOpSettingValue(tempSetting, settingValue.Value);
                //    //START RALLY US1572
                //    SetSystemSettingValue(tempSetting, settingValue.Value);
                //    //END RALLY US1572
                //}
                //END DEFECT RALLY DE 4008
                return true;
            }
            catch (Exception e)
            {
                MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, e), Properties.Resources.ModuleName);
                return false;
            }
        }


	    public static bool SaveSystemSettings( SettingValue[] arrSettings )
		{
			SetSystemSettingsMessage msg = new SetSystemSettingsMessage(arrSettings);

			try
			{
				msg.Send();

				if (msg.ServerReturnCode != GTIServerReturnCode.Success)
				{
					MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Properties.Resources.ModuleName);
					return false;
				}

                //DEFECT RALLY DE 4008 START -- global settings not updated in operator settings table
                foreach (SettingValue settingValue in arrSettings)
                {
                    Setting tempSetting = (Setting)Enum.ToObject(typeof(Setting), settingValue.Id);
                    SetOpSettingValue(tempSetting, settingValue.Value);
                    //START RALLY US1572
                    SetSystemSettingValue(tempSetting, settingValue.Value);
                    //END RALLY US1572
                }
                //END DEFECT RALLY DE 4008
				return true;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, e), Properties.Resources.ModuleName);
				return false;
			}
		}

        public static bool SaveHallSettings()
        {
            SetHallSettings msg = new SetHallSettings();
            
            //These settings should be set by the module
            msg.HallId = m_GetHallSettingsMessage.HallId;
            msg.HallName = m_GetHallSettingsMessage.HallName;
            msg.PrintBarCode = m_GetHallSettingsMessage.PrintBarCode;
            msg.SalesTax = m_GetHallSettingsMessage.SalesTax;
            msg.EndOfDay = m_GetHallSettingsMessage.EndOfDayTime;

            try
            {
                msg.Send();
                if (msg.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Properties.Resources.ModuleName);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdSystemSettingsFailed, e), Properties.Resources.ModuleName);
                return false;
            }           
        }

		public static bool GetOpSettingValue(Setting setting, out SettingValue val)
		{
			int nSettingId = (int)setting;

			return m_GetSettingsOperatorMessage.SettingsDictionary.TryGetValue(nSettingId, out val);
		}

		public static string GetOpSetting(Setting s, bool returnSystemSettingIfNoOpSetting = false)
		{
			SettingValue tempSettingValue;

			if (m_GetSettingsOperatorMessage.SettingsDictionary.TryGetValue((int)s, out tempSettingValue))
			{
				return tempSettingValue.Value;
			}
			else
			{
                if (returnSystemSettingIfNoOpSetting)
                    return GetSystemSetting(s);
                else
				    return "";
			}
		}

        public static bool UpdateOperatorSetting(Setting setting, string strValue)
        {
            // Get the existing value
            SettingValue tempSetting;
            int nSettingId = (int)setting;

            if (!m_GetSettingsOperatorMessage.SettingsDictionary.TryGetValue(nSettingId, out tempSetting))
            {
                return false;
            }

            // Remove the old value
            m_GetSettingsOperatorMessage.SettingsDictionary.Remove(nSettingId);

            // Add updated value
            tempSetting.Value = strValue;
            m_GetSettingsOperatorMessage.SettingsDictionary.Add(nSettingId, tempSetting);
            return true;
        }

		public static bool SetOpSettingValue(Setting setting, string value)
		{
            if (UpdateOperatorSetting(setting, value))
            {
                
                try
                {
                    ArrayList settings = new ArrayList();
                    settings.Add(new SettingValue { Id = (int)setting, Value = value });
                    UpdSettingsOperatorMessage msg = new UpdSettingsOperatorMessage(m_nOperatorId, settings);

                    msg.Send();
                    if (msg.ServerReturnCode != GTIServerReturnCode.Success)
                    {
                        MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdOperatorSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Properties.Resources.ModuleName);
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    MessageForm.Show(Common.ActiveWnd, string.Format(Properties.Resources.UpdOperatorSettingsFailed, e), Properties.Resources.ModuleName);
                    return false;
                }
            }
            else
            {
                return false;
            }
		}

        //US4434
        public static bool SetOpSettingValue(int operatorId, Setting setting, string value)
        {
            if (UpdateOperatorSetting(setting, value))
            {

                try
                {
                    ArrayList settings = new ArrayList();
                    settings.Add(new SettingValue { Id = (int)setting, Value = value });
                    UpdSettingsOperatorMessage msg = new UpdSettingsOperatorMessage(operatorId, settings);

                    msg.Send();
                    if (msg.ServerReturnCode != GTIServerReturnCode.Success)
                    {
                        MessageForm.Show(ActiveWnd, string.Format(Resources.UpdOperatorSettingsFailed, GTIClient.GetServerErrorString(msg.ServerReturnCode)), Resources.ModuleName);
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    MessageForm.Show(ActiveWnd, string.Format(Resources.UpdOperatorSettingsFailed, e), Resources.ModuleName);
                    return false;
                }
            }

            return false;
        }


	    public static string GetSystemSetting(Setting s)
		{
			int nCount = m_GetSystemSettingsMessage.Settings.Length;
			for (int i = 0; i < nCount; i++)
			{
				if (m_GetSystemSettingsMessage.Settings[i].Id == (int)s)
				{
					return m_GetSystemSettingsMessage.Settings[i].Value;
				}
			}

			// Setting not found
			return "";
		}

        public static bool GetSettingEnabled(Setting s)
        {
            LicenseFileItem item = m_GetLicenseFileMessage.LicenseFileItems.Find(i => i.settingID == (int)s);
            if (item == null)
                return true;
            else
            {
                //Check to see if it can be changed
                if (item.settingPermission > 0)
                {
                    bool value;
                    //Check the license file value to see if it is a boolean
                    if (bool.TryParse(item.value, out value))
                    {
                        //If the min/max is zero then return true
                        if (item.settingRange == 0)
                            return true;

                        //If the license file is true
                        if (value)
                        {
                            //if it is a max value return false 
                            if (item.settingRange == 2)
                                return true;
                            //otherwise the user can set it to false
                            else
                                return false;
                        }
                        else
                        {
                            //if it is a min value return false
                            if (item.settingRange == 1)
                                return true;
                            //otherwise the user can set it to true
                            else
                                return false;
                        }
                    }
                    //otherwise it is not a boolean and it needs to have its min max checked
                    else
                    {
                        return true;
                    }
                }
                //the setting permission is zero so the user cannot change
                else
                {
                    return false;
                }
            }
        }


        public static bool GetSettingEnabled(LicenseSetting s)
        {
            LicenseFileItem item = m_GetLicenseFileMessage.LicenseFileItems.Find(i => i.settingID == (int)s);
            
            if(item == null)
                return true;
            
            else
            {
                if(item.settingPermission > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string GetLicenseSettingValue(LicenseSetting s)
        {
            LicenseFileItem item = m_GetLicenseFileMessage.LicenseFileItems.Find(i => i.settingID == (int)s);
            if (item == null)
                return null;
            else
            {
                //todo: this value should always be set
                if (item.value == null)
                    return "";
                else
                return item.value;
            }
        }

        public static byte GetSettingMinMax(LicenseSetting s, out string value)
        {
            LicenseFileItem item = m_GetLicenseFileMessage.LicenseFileItems.Find(i => i.settingID == (int)s);
            if (item == null || item.settingRange == 0)
            {
                value = "";
                return 0;
            }
            else
            {
                value = item.value;
                return item.settingRange;
            }
        }

        public static byte GetSettingMinMax(Setting s, out string value)
        {
            LicenseFileItem item = m_GetLicenseFileMessage.LicenseFileItems.Find(i => i.settingID == (int)s);
            if (item == null || item.settingRange == 0)
            {
                value = "";
                return 0;
            }
            else
            {
                value = item.value;
                return item.settingRange;
            }
        }
        
		public static bool SetSystemSettingValue(Setting s, string strValue)
		{
			int nCount = m_GetSystemSettingsMessage.Settings.Length;
			for (int i = 0; i < nCount; i++)
			{
				if (m_GetSystemSettingsMessage.Settings[i].Id == (int)s)
				{
					m_GetSystemSettingsMessage.Settings[i].Value = strValue;
					return true;
				}
			}

			// Setting not found
			return false;
		}

      

		public static bool CompareByteArrays(byte[] arr1, byte[] arr2)
		{
			if (arr1.Length != arr2.Length)
			{
				return false;
			}

			for (int i = 0; i < arr1.Length; i++)
			{
				if (arr1[i] != arr2[i])
				{
					return false;
				}
			}

			return true;
		}

		// Properties
		public static IWin32Window ActiveWnd
		{
			// Return the active window if it exists
			get
			{
				if (Application.OpenForms.Count > 0)
				{
					return Application.OpenForms[Application.OpenForms.Count - 1];
				}
				else
				{
					return null;
				}
			}
		}

	    public static int CurrentOperatorId
	    {
	        get { return m_nCurrentOperatorId; }
	        set { m_nCurrentOperatorId = value; }
	    }

	    public static void BeginWait()
		{
			Cursor.Current = Cursors.WaitCursor;
		}

		public static void EndWait()
		{
			Cursor.Current = Cursors.Default;
		}

		// Check for an existing mutex
		public static bool MutexExists(string strName)
		{
			try
			{
				Mutex m = Mutex.OpenExisting(strName);
                
				return true;
			}
			catch (WaitHandleCannotBeOpenedException)
			{
				return false;
			}
			catch (Exception e)
			{
				MessageForm.Show(Common.ActiveWnd, "An unexpected error occurred while opening mutex : " + e);
				return true;
			}
		}


		// The following routines were added to avoid Parse() from throwing exceptions for null values
		public static bool ParseBool(string s)
		{
			// Try to parse the value
			bool result;
			bool default_value = false;
			if (bool.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public static DateTime ParseDateTime(string s)
		{
			// Try to parse the value
			DateTime result;
			DateTime default_value = DateTime.Now;
			if (DateTime.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public static int ParseInt(string s)
		{
			// Try to parse the value
			int result;
			int default_value = 0;
			if (int.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public static decimal ParseDecimal(string s)
		{
			// Try to parse the value
			decimal result;
			decimal default_value = 0;
			if (decimal.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public static int GetDeviceCount(Device device)
		{
			int nDeviceCount = 0;
			int nCount = m_GetMachineDataMessage.MachineDataList.Length;
			for (int i = 0; i < nCount; i++)
			{
				if (m_GetMachineDataMessage.MachineDataList[i].nDeviceId == device.Id)
				{
					nDeviceCount++;
				}
			}

			return nDeviceCount;
		}

        //START RALLY US1833
        internal static string GetLicenseFileExpriationDate()
        {
            return m_GetLicenseFileMessage.ExpirationDate.ToShortDateString();
        }
        //END RALLY US1833

        #endregion	// "Public Static Methods"
    }

    
}

