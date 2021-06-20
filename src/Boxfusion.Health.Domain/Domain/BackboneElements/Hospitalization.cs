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
    /// Details about the admission to a healthcare service.
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Hospitalization")]
    public class Hospitalization : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Pre-admission identifier.
        /// </summary>
        public virtual Identifier PreAdmissionIdentifier { get; set; }

        /// <summary>
        /// The location/organization from which the patient came before admission.
        /// </summary>
        public virtual Location Origin { get; set; }

        /// <summary>
        /// From where patient was admitted (physician referral, transfer).
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_AdmitSourceId")]
        [StringLength(40)]
        public virtual string AdmitSourceId { get; set; }

        /// <summary>
        /// Whether this hospitalization is a readmission and why if known.
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_ReAdmissionId")]
        [StringLength(40)]
        public virtual string ReAdmissionId { get; set; }

        /// <summary>
        /// Diet preferences reported by the patient.
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_DietPreferenceId")]
        [StringLength(40)]
        public virtual string DietPreferenceId { get; set; }

        /// <summary>
        /// Special courtesies (VIP, board member).
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_SpecialCourtesyId")]
        [StringLength(40)]
        public virtual string SpecialCourtesyId { get; set; }

        /// <summary>
        /// Any special requests that have been made for this hospitalization encounter, such as the provision of specific equipment or other things.
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_SpecialArrangementId")]
        [StringLength(40)]
        public virtual string SpecialArrangementId { get; set; }

        /// <summary>
        /// Location/organization to which the patient is discharged.
        /// </summary>
        public virtual Location Destination { get; set; }

        /// <summary>
        /// Location/organization to which the patient is discharged.
        /// The Id of the codebleconceptlist this class history relates to.
        /// </summary>
        [Column("Frwk_DischargeDispositionId")]
        [StringLength(40)]
        public virtual string DischargeDispositionId { get; set; }

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
