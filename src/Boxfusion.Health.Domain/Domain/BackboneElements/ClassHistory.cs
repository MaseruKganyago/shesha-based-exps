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
    /// The class history permits the tracking of the encounters transitions without needing to go through the resource history. 
    /// This would be used for a case where an admission starts of as an emergency encounter, then transitions into an inpatient scenario. 
    /// Doing this and not restarting a new encounter ensures that any lab/diagnostic results can more easily follow the patient and not require 
    /// re-processing and not get lost or cancelled during a kind of discharge from emergency to inpatient.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.ClassHistory")]
    public class ClassHistory : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_ClassId")]
        [StringLength(40)]
        public virtual string ClassId { get; set; }
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
