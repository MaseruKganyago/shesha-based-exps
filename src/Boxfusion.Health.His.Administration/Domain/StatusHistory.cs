using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.DataTypes;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// The status history permits the encounter resource to contain the status history without needing to read through the 
    /// historical versions of the resource, or even have the server store them.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.StatusHistory")]
    public class StatusHistory<T, TEntity> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable where TEntity: class
    {
        /// <summary>
        /// Historic state of the encounter (e.g. planned | arrived | triaged | in-progress | onleave | finished | cancelled +.)
        /// </summary>
        public virtual T? Status { get; set; }
        /// <summary>
        /// The time that the episode was in the specified status
        /// </summary>
        public virtual Period Period { get; set; }
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
