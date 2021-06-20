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
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Position")]
    public class Position : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Longitude with WGS84 datum
        /// </summary>
        public virtual decimal Longitude { get; set; }

        /// <summary>
        /// Latitude with WGS84 datum
        /// </summary>
        public virtual decimal Latitude { get; set; }

        /// <summary>
        /// Altitude with WGS84 datum
        /// </summary>
        public virtual decimal Altitude { get; set; }

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
