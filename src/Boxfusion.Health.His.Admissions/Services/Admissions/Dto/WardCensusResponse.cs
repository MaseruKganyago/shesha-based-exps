using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    public class WardCensusResponse
    {
        public int? MidnightCount { get; set; }
        public int? TotalAdmittedPatients { get; set; }
        public int? TotalSeparatedPatients { get; set; }
        public int? TotalBedAvailability { get; set; }
        public int? TotalBedInWard { get; set; }
        public decimal? BedUtilisation { get; set; }
        public decimal? AverageBedAvailability { get; set; }
        public decimal? AverageLengthOfStay { get; set; }
    }
}
