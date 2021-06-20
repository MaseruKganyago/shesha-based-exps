using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    [Entity(TypeShortAlias = "HealthDomain.Participant")]
    public class Participant<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_TypeId")]
        [StringLength(40)]
        public virtual string TypeId { get; set; }
        /// <summary>
        /// Start Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End Time period when id is/was valid for use
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }
        public virtual Practioner Individual { get; set; }
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
