﻿using System;
namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    public class MonthlyStats
    {
        public Single TotalAdmissions { get; set; }
        public Single TotalSeparations { get; set; }
        public Single NumBedsInWard { get; set; }
        public Single TotalBedAvailability { get; set; }
        public decimal BedUtilisation { get; set; }
        public decimal AverageLengthOfStay { get; set; }
        public double AverageBedAvailability { get; set; }
    }
}