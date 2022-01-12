using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Helpers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class TodaysAdmissionResponse
    {
        public int TodaysAdmission { get; set; }
    }
    public class MidnightCountResponse
    {
        public int MidnightCount { get; set; }
    } 
    public class DayPatientsResponse
    {
        public int DayPatients { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class TodaysAdmissionInput
    {
        public Guid WardId { get; set; }
        public DateTime? ReportDate { get; set; }
    }
}
