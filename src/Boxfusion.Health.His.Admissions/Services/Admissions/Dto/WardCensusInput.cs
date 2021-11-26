using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    public class WardCensusInput
    {
        public Guid WardId { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
