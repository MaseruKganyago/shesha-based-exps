using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    /// <summary>
    /// A contact party (e.g. guardian, partner, friend) for the patient.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Contact")]
    public class Contact : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The nature of the relationship between the patient and the contact person.
        /// </summary>
        public virtual PatientContactRelationship Relationship { get; set; }

        /// <summary>
        /// A name associated with the contact person.
        /// </summary>
        public virtual HumanName Name { get; set; }

        /// <summary>
        /// A contact detail for the person, e.g. a telephone number or an email address.
        /// </summary>
        public virtual ContactPoint Telecom { get; set; }

        /// <summary>
        /// Address for the contact person.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Administrative Gender - the gender that the contact person is considered to have for administration and record keeping purposes.
        /// </summary>
        public virtual RefListGender? Gender { get; set; }

        /// <summary>
        /// Organization on behalf of which the contact is acting or for which the contact is working.
        /// </summary>
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// Start Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// The type of contact (not to be used when contact is a person. Can be used when contact is an organization)
        /// </summary>
        public virtual ContactEntityType Purpose { get; set; }

        /// <summary>
        /// The Id of the entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerId")]
        [StringLength(40)]
        public virtual string OwnerId { get; protected set; }

        /// <summary>
        /// The Type of entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerType")]
        [StringLength(100)]
        public virtual string OwnerType { get; protected set; }
    }
}
