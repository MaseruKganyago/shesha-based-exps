using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class TodaysAdmissionResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int TodaysAdmission { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MidnightCountResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int MidnightCount { get; set; }
    } 

    /// <summary>
    /// 
    /// </summary>
    public class DayPatientsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int DayPatients { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TotalAdmissionsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int TotalAdmissions { get; set; }
    }

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
