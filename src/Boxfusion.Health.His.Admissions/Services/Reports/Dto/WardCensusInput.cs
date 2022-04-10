using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto
{
    public class WardCensusInput
    {
        public Guid WardId { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? TotalMonthlyAdmissions { get; set; }
    }
    public class WardCensusInput2
    {
        public Guid WardId { get; set; }
        public DateTime? ReportDate { get; set; }
        public int todaysAdmission { get; set; }
        public int midnightCount { get; set; }
        public int dayPatient { get; set; }        
    }
}
