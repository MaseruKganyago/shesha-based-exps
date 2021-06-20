using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    [Entity(TypeShortAlias = "HealthDomain.Qualification")]
    public class Qualification : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// An identifier for this qualification for the practitioner
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// ACoded representation of the qualification
        /// </summary>
        public virtual QualificationCertificate Code { get; set; }

        /// <summary>
        /// Start Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Organization that regulates and issues the qualification
        /// </summary>
        public virtual Organization Issuer { get; set; }

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
