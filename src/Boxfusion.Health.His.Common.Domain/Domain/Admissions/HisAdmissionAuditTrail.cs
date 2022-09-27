using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisAdmissionAuditTrail")]
    public class HisAdmissionAuditTrail : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual WardAdmission Admission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? AuditTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person Initiator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListWardAdmissionStatuses? WardAdmissionStatus { get; set; }
    }
}
