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
        public int? BedUtilisation { get; set; }
        public int? Alos { get; set; }
    }
}
