using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// Ward belongs to a specific facility
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Ward")]
    public class Ward : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Ward number
        /// </summary>
        public virtual string Number { get; set; }
        /// <summary>
        /// Ward description
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// Hospital to which the ward belongs to
        /// </summary>
        public virtual Hospital Hospital { get; set; }
        /// <summary>
        /// Speciality that the ward falls under
        /// </summary>
        public virtual RefListWardSpeciality? Speciality { get; set; }
    }
}
