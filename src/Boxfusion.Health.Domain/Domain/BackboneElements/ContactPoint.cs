using Abp.Domain.Entities.Auditing;
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
    /// Details for all kinds of technology mediated contact points for a person or organization, including telephone, email, etc.
    /// </summary>
    [Entity(TypeShortAlias = "")]
    public class ContactPoint : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Telecommunications form for contact point - what communications system is required to make use of the contact.
        /// </summary>
        public virtual RefListPatientContactPointSystem? System { get; set; }

        /// <summary>
        /// The actual contact point details, in a form that is meaningful to the designated communication system (i.e. phone number or email address).
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Identifies the purpose for the contact point.
        /// </summary>
        public virtual RefListContactPointUse? Use { get; set; }

        /// <summary>
        /// Specifies a preferred order in which to use a set of contacts. ContactPoints with lower rank values are more preferred than 
        /// those with higher rank values.
        /// </summary>
        public virtual int? Rank { get; set; }

        /// <summary>
        /// Start Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

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
