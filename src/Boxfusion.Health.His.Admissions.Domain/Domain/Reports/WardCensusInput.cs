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
    /// <summary>
    /// 
    /// </summary>
    public class WardCensusInput2
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
        public int todaysAdmission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int midnightCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dayPatient { get; set; }        
    }
}
