using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.BackboneElements;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    [Entity(TypeShortAlias = "HealthDomain.Practioner")]
    public class Practioner : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// An identifier for the person as this agent
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// Whether this practitioner's record is in active use
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// The name(s) associated with the practitioner
        /// </summary>
        public virtual HumanName HumanName { get; set; }

        /// <summary>
        /// A contact detail for the practitioner (that apply to all roles)
        /// </summary>
        public virtual ContactPoint Telecom { get; set; }

        /// <summary>
        /// Address(es) of the practitioner that are not role specific (typically home address)
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// male | female | other | unknown
        /// </summary>
        public virtual RefListGender? Gender { get; set; }

        /// <summary>
        /// The date on which the practitioner was born
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// Image of the person
        /// </summary>
        public virtual Attachment Photo { get; set; }

        /// <summary>
        /// Certification, licenses, or training pertaining to the provision of care
        /// </summary>
        public virtual Qualification Qualification { get; set; }

        /// <summary>
        /// A language the practitioner can use in patient communication
        /// </summary>
        public virtual Communication Communication { get; set; }
    }
}
