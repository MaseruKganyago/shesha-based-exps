using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class DailyStats
    {
        /// <summary>
        /// 
        /// </summary>
        public Single MidnightCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Single TotalAdmittedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Single TotalBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Single TotalSeparatedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Single TotalBedInWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Single TodaysAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal BedUtilisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal AverageLengthOfStay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double AverageBedAvailability { get; set; }
    }
}