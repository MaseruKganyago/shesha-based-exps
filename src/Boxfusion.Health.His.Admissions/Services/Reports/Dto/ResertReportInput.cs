using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class ResertReportInput
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid wardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime reportDate { get; set; }
    }
}
