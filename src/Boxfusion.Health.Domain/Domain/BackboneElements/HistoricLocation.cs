using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.BackboneElements
{
    [Entity(TypeShortAlias = "HealthDomain.HistoricLocation")]
    public class HistoricLocation<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// List of locations where the patient has been during this encounter.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// planned | active | reserved | completed
        /// </summary>
        public virtual T? Status { get; set; }

        /// <summary>
        /// This will be used to specify the required levels (bed/ward/room/etc.) desired to be recorded to simplify either messaging or query.
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_PhysicalTypeId")]
        [StringLength(40)]
        public virtual string PhysicalTypeId { get; set; }

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
