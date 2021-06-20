using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    [Entity(TypeShortAlias = "HealthDomain.Diagnosis")]
    public class Diagnosis : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The diagnosis or procedure relevant to the encounter
        /// </summary>
        public virtual Condition Condition { get; set; }

        /// <summary>
        /// Role that this diagnosis has within the encounter (e.g. admission, billing, discharge …).
        /// </summary>
        [Column("Frwk_UseId")]
        [StringLength(40)]
        public virtual string UseId { get; set; }

        /// <summary>
        /// Ranking of the diagnosis (for each role type)
        /// </summary>
        public virtual int? Rank { get; set; }

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
