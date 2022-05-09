using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class WardCensusInput
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid WardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReportDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TotalMonthlyAdmissions { get; set; }
    }

}
