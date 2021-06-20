using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    /// <summary>
    /// The status history permits the encounter resource to contain the status history without needing to read through the 
    /// historical versions of the resource, or even have the server store them.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.StatusHistory")]
    public class StatusHistory<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// Historic state of the encounter (e.g. planned | arrived | triaged | in-progress | onleave | finished | cancelled +.)
        /// </summary>
        public virtual T? Status { get; set; }
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
