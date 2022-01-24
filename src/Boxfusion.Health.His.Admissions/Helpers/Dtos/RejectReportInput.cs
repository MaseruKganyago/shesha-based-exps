using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Helpers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class RejectReportInput: WardCensusInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string RejectionReason { get; set; }
    }
}
