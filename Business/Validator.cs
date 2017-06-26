using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GTI.Modules.SystemSettings.Business
{
    public class Validator
    {
        public Validator()
        {
             
        }

        static public bool ValidateTelephoneNumber(string phoneNumber)
        {
            return false;
        }
        
        static public bool ValidateStreetAddress(string streetAddresss)
        {

            return false;
        }
        
        static public bool ValidateState(string state)
        {
            return false;
        }
        
        public bool ValidateZipCode(string zipCode)
        {
            //this field is not mandatory
            if (string.IsNullOrEmpty(zipCode))
                return true;

            Regex zipRegEx = new Regex("^[0-9]{5}(-[0-9]{4})?$");
            return zipRegEx.IsMatch(zipCode);
        }

        static public bool ValidatePercent(string percent)
        {
            if (string.IsNullOrEmpty(percent))
                return false;
            Regex percentRegEx = new Regex(@"^100\.0*$|^100$|^\d{0,2}(\.\d{1,4})? *%?$");
            return percentRegEx.IsMatch(percent);
        }

        public bool ValidateTaxIDNumber(string taxIDNumber)
        {
            return false;
        }
        


        static public bool ValidateHighRange(string lower, string higher)
        {
            int low, high;

            if (string.IsNullOrEmpty(lower) && string.IsNullOrEmpty(higher))
                return true;

            if (int.TryParse(lower, out low) && int.TryParse(higher, out high))
            {
                if (high < low)
                    return false;
                else
                    return true;
            }
                
            else
                return false;
        }
        
        static public bool ValidateLowRange(string lower, string higher)
        {
            int low, high;
            
            if (string.IsNullOrEmpty(lower) && string.IsNullOrEmpty(higher))
                return true;

            if (int.TryParse(lower, out low) && int.TryParse(higher, out high))
            {
                if (low > high)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        static public bool ValidateInt(string intAsString)
        {
            int intTest;
            return Int32.TryParse(intAsString, out intTest);
        }

        static public bool ValidateDecimal(string intAsDecimal)
        {
            decimal decimalTest;
            return decimal.TryParse(intAsDecimal, out decimalTest);
        }

        public bool ValidateName(string name)
        {
            return false;
        }

        

        public bool ValidateMoney(string money)
        {
            return false;
        }

    }
}
