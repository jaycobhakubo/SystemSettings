using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GTI.Modules.Shared;
using System.Collections;

namespace GTI.Modules.SystemSettings.Business
{
    public class OperatorManagementModel
    {
        //holds the list collection
        private List<BingoOperator> _bingoOperators;

        public OperatorManagementModel()
        {
            _bingoOperators = new List<BingoOperator>();
        }

        public bool addOperator(BingoOperator bingoOperator)
        {
            //check for exisiting?
            _bingoOperators.Add(bingoOperator);
            return true;
        }

        public bool saveToDatabase()
        {
            //save all the operator data
            foreach(BingoOperator bingoOperator in BingoOperators)
            {
                GetOperatorCompleteMessage getOperatorMessage = new GetOperatorCompleteMessage(bingoOperator.OperatorId);
                getOperatorMessage.Send();
                Operator dbOperator;
                
                if(getOperatorMessage.ReturnCode == (int)GTIServerReturnCode.Success)
                {            
                    dbOperator = getOperatorMessage.OperatorList.Find(i => i.Id == bingoOperator.OperatorId);      
                }

                else
                {
                    return false;
                }
                
                //check the address ids
                if (CheckAddressIds(bingoOperator) == false)
                    return false;

                //create an operator object which is different than a bingo operator object slightly
                Operator newOperator = ConvertToOperator(bingoOperator,dbOperator);
                
                SetOperatorCompleteMessage setOperatorMessage = new SetOperatorCompleteMessage(newOperator);
                setOperatorMessage.Send();
                
                //if the return code is good then get the new operator ID if there is one
                if(setOperatorMessage.ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    //check to see if it is a new operator
                    if(bingoOperator.OperatorId == 0)
                    {
                        bingoOperator.OperatorId = setOperatorMessage.OperatorId;
                        
                        //add a new operator settings to the operator settings table
                        if(AddNewOperatorSettingsTable(bingoOperator.OperatorId) == false)
                            return false;
                    }
                    else
                    {
                        bingoOperator.OperatorId = setOperatorMessage.OperatorId;    
                    }
                }

                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool AddNewOperatorSettingsTable(int operatorID)
        {
            GetSettingsMessage getDefaultSettingsMessage = new GetSettingsMessage(0,0,SettingsCategory.AllCategories,0);
            getDefaultSettingsMessage.Send();
            if (operatorID != 0 && getDefaultSettingsMessage.ServerReturnCode == GTIServerReturnCode.Success)
            {
                ArrayList settingList = new ArrayList(getDefaultSettingsMessage.Settings);
                
                ArrayList modifiedSettingList = new ArrayList();
                
                foreach(SettingValue setting in settingList)
                {
                    //FIX RALLY DE 3000  some settings do not get copied into operator settings table
                    if (!Common.IsGlobalSetting(setting))
                    {
                        modifiedSettingList.Add(setting);
                    }
                }

                UpdSettingsOperatorMessage settingsMessage = new UpdSettingsOperatorMessage(operatorID,modifiedSettingList);
                settingsMessage.Send();
                    
                if(settingsMessage.ServerReturnCode == GTIServerReturnCode.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        //FIX START RALLY DE 3581: new operator setting multiple addresses
        private bool CheckBillingAndOperatorAddress(BingoOperator operatorToSave)
        {
            if(operatorToSave.operatorBillingAddress1 == operatorToSave.operatorAddress1 &&
                operatorToSave.operatorBillingAddress2 == operatorToSave.operatorAddress2 &&
                operatorToSave.operatorBillingAddressCity == operatorToSave.operatorAddressCity &&
                operatorToSave.operatorBillingAddressState == operatorToSave.operatorAddressState &&
                operatorToSave.operatorBillingAddressZip == operatorToSave.operatorAddressZip &&
                operatorToSave.operatorBillingAddressCountry == operatorToSave.operatorAddressCountry)
            {
                return true;
            }
            return false;
        }

        private bool CheckAddressIds(BingoOperator operatorToSave)
        {
            //if it is a new operator and both address fields are the same update once
            if(operatorToSave.OperatorAddressId == 0 && operatorToSave.OperatorBillingAddressId == 0 &&
                CheckBillingAndOperatorAddress(operatorToSave))
            {
               
                UpdAddressData updateAddressDataMessageSame = new UpdAddressData(operatorToSave.OperatorAddressId);
                updateAddressDataMessageSame.Properties.Address1 = operatorToSave.operatorAddress1;
                updateAddressDataMessageSame.Properties.Address2 = operatorToSave.operatorAddress2;
                updateAddressDataMessageSame.Properties.City = operatorToSave.operatorAddressCity;
                updateAddressDataMessageSame.Properties.State = operatorToSave.operatorAddressState;
                updateAddressDataMessageSame.Properties.Country = operatorToSave.operatorAddressCountry;
                updateAddressDataMessageSame.Properties.Zipcode = operatorToSave.operatorAddressZip;
                updateAddressDataMessageSame.Send();

                if (updateAddressDataMessageSame.ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    operatorToSave.OperatorAddressId = updateAddressDataMessageSame.Properties.AddressID;
                    operatorToSave.OperatorBillingAddressId = updateAddressDataMessageSame.Properties.AddressID;
                    return true;
                }
            }
            //FIX END RALLY DE 3581: new operator setting multiple addresses
            UpdAddressData updateAddressDataMessage = new UpdAddressData(operatorToSave.OperatorAddressId);
            updateAddressDataMessage.Properties.Address1 = operatorToSave.operatorAddress1;
            updateAddressDataMessage.Properties.Address2 = operatorToSave.operatorAddress2;
            updateAddressDataMessage.Properties.City = operatorToSave.operatorAddressCity;
            updateAddressDataMessage.Properties.State = operatorToSave.operatorAddressState;
            updateAddressDataMessage.Properties.Country = operatorToSave.operatorAddressCountry;
            updateAddressDataMessage.Properties.Zipcode = operatorToSave.operatorAddressZip;
            updateAddressDataMessage.Send();
            
            if(updateAddressDataMessage.ReturnCode == (int)GTIServerReturnCode.Success)
            {
                operatorToSave.OperatorAddressId = updateAddressDataMessage.Properties.AddressID;
            }
            
            else
            {
                return false;
            }
    
            updateAddressDataMessage = new UpdAddressData(operatorToSave.OperatorBillingAddressId);
            updateAddressDataMessage.Properties.Address1 = operatorToSave.operatorBillingAddress1;
            updateAddressDataMessage.Properties.Address2 = operatorToSave.operatorBillingAddress2;
            updateAddressDataMessage.Properties.City = operatorToSave.operatorBillingAddressCity;
            updateAddressDataMessage.Properties.State = operatorToSave.operatorBillingAddressState;
            updateAddressDataMessage.Properties.Zipcode = operatorToSave.operatorBillingAddressZip;
            updateAddressDataMessage.Properties.Country = operatorToSave.operatorBillingAddressCountry;
            updateAddressDataMessage.Send();

            if(updateAddressDataMessage.ReturnCode == (int)GTIServerReturnCode.Success)
            {
                
                operatorToSave.OperatorBillingAddressId = updateAddressDataMessage.Properties.AddressID;
                return true;
            }
            else
            {
                return false;
            } 
        }

        public Operator ConvertToOperator(BingoOperator bingoOperator,Operator dboperator)
        {
            Operator newOperator;
            
            if(dboperator == null)
            {
                newOperator = new Operator();
            }
            
            else
            {
                newOperator = dboperator;
            }

            newOperator.Id = bingoOperator.OperatorId;
            newOperator.CashMethodID = bingoOperator.OperatorCashMethodId;
            newOperator.PlayerTierCalcId = bingoOperator.PlayerTierCalcId;
            newOperator.Code = bingoOperator.OperatorCode;
            newOperator.Modem = bingoOperator.OperatorModemNumber;
            
            newOperator.AddressID = bingoOperator.OperatorAddressId;
            newOperator.CompanyID = 1;
            newOperator.Name = bingoOperator.OperatorName;
            newOperator.Phone = bingoOperator.OperatorPhoneNumber;
            newOperator.IsActive = bingoOperator.OperatorIsActive;
            newOperator.Licence = bingoOperator.OperatorLicenseNumber;
            newOperator.ContactName = bingoOperator.OperatorContactName;
            newOperator.TaxPayerId = bingoOperator.OperatorTaxpayerId;
            newOperator.BillingAddressId = bingoOperator.OperatorBillingAddressId;
            newOperator.HallRent = bingoOperator.OperatorHallRentAmount;
            newOperator.PercentOfProfitsToCharity = bingoOperator.OperatorPercentageOfProfits;
            newOperator.PercentPrizesToState = bingoOperator.OperatorPercentageOfStateRevenue;
            
            return newOperator;
        }

        public bool loadFromDatabase()
        {
            //Stream fStream = File.OpenRead("Database.xml");
            //XmlSerializer serializer = new XmlSerializer(typeof(List<BingoOperator>));
            ////BinaryFormatter serializer = new BinaryFormatter();
            //BingoOperators.Clear();
            
            //BingoOperators =  (List<BingoOperator>)serializer.Deserialize(fStream);
            //fStream.Close();
            BingoOperators.Clear();
            GetOperatorList operatorListMessage = new GetOperatorList();
            BingoOperators = operatorListMessage.GetOperatorData();
            return true;
        }

        public List<BingoOperator> GetOperatorsByActivity(bool isActive)
        {
                return _bingoOperators.FindAll(i => i.OperatorIsActive == isActive);
        }

        /// <summary>
        /// A list of the bingo operators
        /// </summary>
        public List<BingoOperator> BingoOperators
        {
            get { return _bingoOperators; }
            set { _bingoOperators = value; }
        }

        /// <summary>
        /// Update the bingoOperator in the internal model
        /// </summary>
        /// <param name="bingoOperator">a bingo Operator</param>
        internal void UpdateOperator(BingoOperator bingoOperator)
        {
            BingoOperator operatorToUpdate = _bingoOperators.Find(i => i.OperatorId == bingoOperator.OperatorId);
            
            if (operatorToUpdate != null)
            {
                //match new operator data
                UpdateOperatorProperties(bingoOperator, operatorToUpdate);
            }
            else
            {
                _bingoOperators.Add(bingoOperator);
            }
        }

        internal void UpdateOperatorProperties(BingoOperator bingoOperator, BingoOperator operatorToUpdate)
        {
            operatorToUpdate.OperatorName = bingoOperator.OperatorName;
            operatorToUpdate.OperatorContactName = bingoOperator.OperatorContactName;
            operatorToUpdate.OperatorAddressId = bingoOperator.OperatorAddressId;
            operatorToUpdate.operatorAddress1 = bingoOperator.operatorAddress1;
            operatorToUpdate.operatorAddress2 = bingoOperator.operatorAddress2;
            operatorToUpdate.operatorAddressCity = bingoOperator.operatorAddressCity;
            operatorToUpdate.operatorAddressState = bingoOperator.operatorAddressState;
            operatorToUpdate.operatorAddressZip = bingoOperator.operatorAddressZip;
            operatorToUpdate.operatorAddressCountry = bingoOperator.operatorAddressCountry;
            operatorToUpdate.OperatorBillingAddressId = bingoOperator.OperatorBillingAddressId;
            operatorToUpdate.operatorBillingAddress1 = bingoOperator.operatorBillingAddress1;
            operatorToUpdate.operatorBillingAddress2 = bingoOperator.operatorBillingAddress2;
            operatorToUpdate.operatorBillingAddressCity = bingoOperator.operatorBillingAddressCity;
            operatorToUpdate.operatorBillingAddressState = bingoOperator.operatorBillingAddressState;
            operatorToUpdate.operatorBillingAddressZip = bingoOperator.operatorBillingAddressZip;
            operatorToUpdate.operatorBillingAddressCountry = bingoOperator.operatorBillingAddressCountry;
            operatorToUpdate.OperatorPercentageOfProfits = bingoOperator.OperatorPercentageOfProfits;
            operatorToUpdate.OperatorPercentageOfStateRevenue = bingoOperator.OperatorPercentageOfStateRevenue;
            operatorToUpdate.OperatorPhoneNumber = bingoOperator.OperatorPhoneNumber;
            operatorToUpdate.OperatorTaxpayerId = bingoOperator.OperatorTaxpayerId;
            operatorToUpdate.OperatorIsActive = bingoOperator.OperatorIsActive;
            operatorToUpdate.OperatorHallRentAmount = bingoOperator.OperatorHallRentAmount;
            operatorToUpdate.OperatorLicenseNumber = bingoOperator.OperatorLicenseNumber;
            
            operatorToUpdate.OperatorCashMethodId = bingoOperator.OperatorCashMethodId;
            operatorToUpdate.PlayerTierCalcId = bingoOperator.PlayerTierCalcId;
            operatorToUpdate.OperatorCode = bingoOperator.OperatorCode;
            operatorToUpdate.OperatorModemNumber = bingoOperator.OperatorModemNumber;
        }

        /// <summary>
        /// returns a bingo operator in the model based off of the operatorID
        /// </summary>
        /// <param name="operatorID">operator ID in string form</param>
        /// <returns>null if not in the model</returns>
        internal BingoOperator GetOperatorByID(string operatorID)
        {
            BingoOperator bingoOperator = _bingoOperators.Find(i => i.OperatorId == Convert.ToInt32(operatorID));
            return bingoOperator;
        }

        internal void Reset()
        {
            _bingoOperators.Clear();
            loadFromDatabase();
        }
    }

    [Serializable]
    public class BingoOperator 
    {   
        private int operatorID ;
        private int operatorAddressID;
        private string operatorLicenseNumber;
        private string operatorTaxpayerID;
        private int operatorBillingAddressID;
        private int operatorRegisterTransactionRangeStart;
        private int operatorRegisterTransactionRangeEnd;
        private int operatorPayoutTransactionNumberRangeStart;
        private int operatorPayoutTransactionNumberRangeEnd;
        private bool operatorIsActive;
        private string operatorPhoneNumber;
        private string operatorContactName;
        private string operatorName;

        public  string operatorAddress1;
        public string operatorAddress2;
        public  string operatorAddressCity;
        public string operatorAddressState;
        public string operatorAddressZip;
        public string operatorAddressCountry;

        public string operatorBillingAddress1;
        public string operatorBillingAddress2;

        public string operatorBillingAddressCity;
        public string operatorBillingAddressState;
        public string operatorBillingAddressZip;
        public string operatorBillingAddressCountry;

        private decimal operatorHallRentAmount;
        private decimal operatorPercentageOfProfits;
        private decimal operatorPercentageOfStateRevenue;

        private int operatorCashMethodID;
        private string operatorCode;
        private int playerTierCalcID;
        private string operatorModemNumber;

        public BingoOperator()
        {
            operatorID = 0;
        }
        public int OperatorId
        {
            get { return operatorID; }
            set { operatorID = value; }
        }

        public int OperatorAddressId
        {
            get { return operatorAddressID; }
            set { operatorAddressID = value; }
        }

        public string OperatorLicenseNumber
        {
            get { return operatorLicenseNumber; }
            set { operatorLicenseNumber = value; }
        }

        public string OperatorTaxpayerId
        {
            get { return operatorTaxpayerID; }
            set { operatorTaxpayerID = value; }
        }

        public int OperatorBillingAddressId
        {
            get { return operatorBillingAddressID; }
            set { operatorBillingAddressID = value; }
        }

        public bool OperatorIsActive
        {
            get { return operatorIsActive; }
            set { operatorIsActive = value; }
        }

        public string OperatorPhoneNumber
        {
            get { return operatorPhoneNumber; }
            set { operatorPhoneNumber = value; }
        }

        public string OperatorContactName
        {
            get { return operatorContactName; }
            set { operatorContactName = value; }
        }

        public decimal OperatorHallRentAmount
        {
            get { return operatorHallRentAmount; }
            set { operatorHallRentAmount = value; }
        }

        public decimal OperatorPercentageOfProfits
        {
            get { return operatorPercentageOfProfits; }
            set { operatorPercentageOfProfits = value; }
        }

        public decimal OperatorPercentageOfStateRevenue
        {
            get { return operatorPercentageOfStateRevenue; }
            set { operatorPercentageOfStateRevenue = value; }
        }

        public string OperatorName
        {
            get { return operatorName; }
            set { operatorName = value; }
        }

        public int OperatorRegisterTransactionRangeStart
        {
            get { return operatorRegisterTransactionRangeStart; }
            set { operatorRegisterTransactionRangeStart = value; }
        }

        public int OperatorRegisterTransactionRangeEnd
        {
            get { return operatorRegisterTransactionRangeEnd; }
            set { operatorRegisterTransactionRangeEnd = value; }
        }

        public int OperatorPayoutTransactionNumberRangeStart
        {
            get { return operatorPayoutTransactionNumberRangeStart; }
            set { operatorPayoutTransactionNumberRangeStart = value; }
        }

        public int OperatorPayoutTransactionNumberRangeEnd
        {
            get { return operatorPayoutTransactionNumberRangeEnd; }
            set { operatorPayoutTransactionNumberRangeEnd = value; }
        }

        public int OperatorCashMethodId
        {
            get { return operatorCashMethodID; }
            set { operatorCashMethodID = value; }
        }

        public string OperatorCode
        {
            get { return operatorCode; }
            set { operatorCode = value; }
        }

        public int PlayerTierCalcId
        {
            get { return playerTierCalcID; }
            set { playerTierCalcID = value; }
        }

        public string OperatorModemNumber
        {
            get { return operatorModemNumber; }
            set { operatorModemNumber = value; }
        }
    }
}
