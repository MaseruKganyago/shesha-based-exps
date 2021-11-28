using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    public class DailyStats
    {
        public Single MidnightCount { get; set; }
        public Single TotalAdmittedPatients { get; set; }
        public Single TotalBedAvailability { get; set; }
        public Single TotalSeparatedPatients { get; set; }
        public Single TotalBedInWard { get; set; }
    }
}