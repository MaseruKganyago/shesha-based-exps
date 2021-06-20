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
    /// A human's name with the ability to identify parts and usage.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.HumanName")]
    public class HumanName : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Identifies the purpose for this name.
        /// </summary>
        public virtual RefListPatientNameUse Use { get; set; }

        /// <summary>
        /// Specifies the entire name as it should be displayed e.g. on an application UI. This may be provided instead of or as well as the specific parts.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// The part of a name that links to the genealogy. In some cultures (e.g. Eritrea) the family name of a son is the 
        /// first name of his father.
        /// </summary>
        public virtual string Family { get; set; }

        /// <summary>
        /// Given name.
        /// </summary>
        public virtual string Given { get; set; }

        /// <summary>
        /// Part of the name that is acquired as a title due to academic, legal, employment or nobility status, etc. 
        /// and that appears at the start of the name.
        /// </summary>
        public virtual string Prefix { get; set; }

        /// <summary>
        /// Part of the name that is acquired as a title due to academic, legal, employment or nobility status, etc. 
        /// and that appears at the end of the name.
        /// </summary>
        public virtual string Suffix { get; set; }

        /// <summary>
        /// Starting time with inclusive boundary
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End time with inclusive boundary, if not ongoing
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
