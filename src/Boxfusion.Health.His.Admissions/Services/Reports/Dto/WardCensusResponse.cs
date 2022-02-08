using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class WardCensusResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int? MidnightCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalAdmittedPatients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalSeparatedPatients { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? TotalBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalBedInWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? BedUtilisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? AverageBedAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? AverageLengthOfStay { get; set; }
    }
}
