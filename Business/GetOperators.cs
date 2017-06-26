using System;
using System.Collections.Generic;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Properties;

namespace GTI.Modules.SystemSettings.Business
{
    public class GetOperatorList 
    {
        private List<BingoOperator> m_bingoOperatorList;
        private GetOperatorCompleteMessage m_getOperatorCompleteMessage;

        public GetOperatorList()
        {
              
        }
        
        public List<BingoOperator> GetOperatorData()
        {
            m_bingoOperatorList = new List<BingoOperator>();
            PopulateOperatorData();
            TranslateLists();
            //m_bingoOperatorList.Add(bingoOperator);
            return m_bingoOperatorList;
        }

        protected void TranslateLists()
        {
            foreach (Operator item in m_getOperatorCompleteMessage.OperatorList)
            {
                BingoOperator bingoOperator = new BingoOperator();
                bingoOperator.OperatorId = item.Id;
                bingoOperator.OperatorName = item.Name;
                bingoOperator.OperatorIsActive = item.IsActive;
                bingoOperator.OperatorContactName = item.ContactName;
                bingoOperator.OperatorHallRentAmount = item.HallRent;
                bingoOperator.OperatorLicenseNumber = item.Licence;
                bingoOperator.OperatorPercentageOfProfits = item.PercentOfProfitsToCharity;
                bingoOperator.OperatorPercentageOfStateRevenue = item.PercentPrizesToState;
                bingoOperator.OperatorTaxpayerId = item.TaxPayerId;
                bingoOperator.OperatorPhoneNumber = item.Phone;
                bingoOperator.OperatorAddressId = item.AddressID;
                bingoOperator.operatorAddress1 = item.Address1;
                bingoOperator.operatorAddress2 = item.Address2;
                bingoOperator.operatorAddressCity = item.City;
                bingoOperator.operatorAddressState = item.State;
                bingoOperator.operatorAddressZip = item.Zip;
                bingoOperator.operatorAddressCountry = item.Country;
                bingoOperator.operatorBillingAddressCountry = item.Country;
                bingoOperator.OperatorBillingAddressId = item.BillingAddressId;
                bingoOperator.operatorBillingAddress1 = item.BillingAddress1;
                bingoOperator.operatorBillingAddress2 = item.BillingAddress2;
                bingoOperator.operatorBillingAddressCity = item.BillingCity;
                bingoOperator.operatorBillingAddressState = item.BillingState;
                bingoOperator.operatorBillingAddressZip = item.BillingZip;
                bingoOperator.operatorBillingAddressCountry = item.BillingCountry;
                bingoOperator.PlayerTierCalcId = item.PlayerTierCalcId;
                bingoOperator.OperatorCode = item.Code;
                bingoOperator.OperatorCashMethodId = item.CashMethodID;
                bingoOperator.OperatorModemNumber = item.Modem;
                m_bingoOperatorList.Add(bingoOperator);
            }
        }

        protected bool PopulateOperatorData()
        {
            

            //Get the Operator Table data
            m_getOperatorCompleteMessage = new GetOperatorCompleteMessage(0);

            
            try
            {

                m_getOperatorCompleteMessage.Send();


                if (m_getOperatorCompleteMessage.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    MessageForm.Show(Common.ActiveWnd, string.Format(Resources.GetSystemSettingsFailed, GTIClient.GetServerErrorString(m_getOperatorCompleteMessage.ServerReturnCode)));
                    return false;
                }
                
            }
            catch (Exception e)
            {
                MessageForm.Show(Common.ActiveWnd, string.Format(Resources.GetSystemSettingsFailed, e));
                return false;
            }
            return true;
        }
    }
}
