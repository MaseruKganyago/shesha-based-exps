using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Domain.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class AdmissionsUtilityHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="separationDate"></param>
        /// <returns></returns>
        public static string AgeBreakdown(DateTime dateOfBirth, DateTime separationDate)
        {

            int Years = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
            DateTime PastYearDate = dateOfBirth.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == separationDate)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= separationDate)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = separationDate.Subtract(PastYearDate.AddMonths(Months)).Days;

            if (Years == 0 && Months == 0 && Days >= 0)
            {
                if (Days <= 6)
                    return "0-6 days";

                if (Days <= 7 && Days >= 28)
                    return "7-28 days";

                if (Days <= 29)
                    return "29 days - 11 months";
            }

            if (Years == 0 && Months <= 11 && Days >= 0)
            {
                if (Days <= 6)
                    return "0-6 days";

                if (Days >= 7 && Days <= 28)
                    return "7-28 days";

                if (Days <= 29)
                    return "29 days - 11 months";
            }

            if (Years < 5)
                return "12-59 months";

            if (Years > 5 && Years < 12)
                return "5-12 years";

            if (Years > 12)
                return "> 12 years";

            return " No age range found";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dob"></param>
        /// <returns></returns>
        public static int GetAge(DateTime dob)
        {
            //int age = 0;
            //age = DateTime.Now.AddYears(-dob.Year).Year;
            //return age;
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - dob.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
