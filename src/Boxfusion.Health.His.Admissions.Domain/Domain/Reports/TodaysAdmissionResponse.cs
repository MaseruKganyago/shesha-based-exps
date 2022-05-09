using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class TodaysAdmissionInput
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid WardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReportDate { get; set; }
    }
}
