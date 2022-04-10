using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto
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
