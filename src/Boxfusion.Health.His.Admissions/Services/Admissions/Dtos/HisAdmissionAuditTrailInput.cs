using Boxfusion.Health.His.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class HisAdmissionAuditTrailInput
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
        /// 
        /// </summary>
        public RefListAdmissionStatuses? AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
    }
}
