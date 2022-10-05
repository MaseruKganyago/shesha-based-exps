using Boxfusion.Health.His.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class HisAdmissionAuditTrailDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Admission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid Initiator { get; set; }
        /// <summary>
         
        /// </summary>
        public RefListWardAdmissionStatuses? WardAdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
    }
}
