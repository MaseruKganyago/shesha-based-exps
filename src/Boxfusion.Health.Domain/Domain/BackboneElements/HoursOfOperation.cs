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
    [Entity(TypeShortAlias = "HealthDomain.HoursOfOperation")]
    public class HoursOfOperation : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// mon | tue | wed | thu | fri | sat | sun
        /// </summary>
        public virtual RefListDaysOfWeek? DaysOfWeek { get; set; }

        /// <summary>
        /// The Location is open all day
        /// </summary>
        public virtual bool AllDay { get; set; }

        /// <summary>
        /// Time that the Location opens
        /// </summary>
        public virtual DateTime? OpeningTime { get; set; }

        /// <summary>
        /// Time that the Location closes
        /// </summary>
        public virtual DateTime? ClosingTime { get; set; }

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
