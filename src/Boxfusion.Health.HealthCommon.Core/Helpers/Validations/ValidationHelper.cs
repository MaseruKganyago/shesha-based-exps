using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        public static bool IsValidIdentityNumber(string identityNumber)
        {
            // assume everything is correct and if it later turns out not to be, just set this to false
            var correct = true;

            //Ref: http://www.sadev.co.za/content/what-south-african-id-number-made
            // SA ID Number have to be 13 digits, so check the length
            if (identityNumber.Length != 13 || !IsNumeric(identityNumber))
                return false;

            // get first 6 digits as a valid date
            DateTime fromDateValue;
            var tempDate = identityNumber.Substring(2, 2) + "-" + identityNumber.Substring(4, 2) + "-" + identityNumber.Substring(0, 2);
            var formats = "MM-dd-yy";
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, out fromDateValue)) { }  else return false;

            // get the gender
            correct = int.TryParse(identityNumber.Substring(6, 4), out int result);
            if (!correct) return false;

            // get country ID for citzenship
            correct = int.TryParse(identityNumber.Substring(10, 1), out int citizenship);
            if (correct)
                if (citizenship < 0 || citizenship > 1) return false;

            // apply Luhn formula for check-digits
            return checkLuhn(identityNumber);
        }

        private static bool IsNumeric(string number)
        {
            if (Regex.IsMatch(number, @"^\d+$"))
                return true;
            else
                return false;
        }

        //Luhn algorithm
        private static bool checkLuhn(String cardNo)
        {
            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    }
}
