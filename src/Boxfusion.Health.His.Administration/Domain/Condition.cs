using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Boxfusion.Health.Domain.Domain.FHIR.CodableConceptLists;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// Patient's condition or diagnoses
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Condition")]
    public class Condition<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// Business identifiers assigned to this condition by the performer or other systems which remain constant as the resource is updated and propagates from server to server.
        /// </summary>
        public virtual string Identifier { get; set; }
        /// <summary>
        /// The recordedDate represents when this particular Condition record was created in the system, which is often a system-generated date.
        /// </summary>
        public virtual DateTime? RecordedDate { get; set; }
        /// <summary>
        /// The clinical status of the condition.
        /// </summary>
        public virtual RefListClinicalStatus? ClinicalStatus { get; set; }
        /// <summary>
        /// The verification status to support the clinical status of the condition.
        /// </summary>
        public virtual RefListConditionVerificationStatus? VerificationStatus { get; set; }
        /// <summary>
        /// A category assigned to the condition.
        /// </summary>
        public virtual RefListConditionCategory? Category { get; set; }
        /// <summary>
        /// A subjective assessment of the severity of the condition as evaluated by the clinician.
        /// </summary>
        public virtual RefListConditionSeverity? Severity { get; set; }
        /// <summary>
        /// dentification of the condition, problem or diagnosis.
        /// </summary>
        public virtual ICDCode Code { get; set; }
        /// <summary>
        /// The anatomical location where this condition manifests itself.
        /// </summary>
        public virtual BodySite BodySite { get; set; }
        /// <summary>
        /// Indicates the patient or group who the condition record is associated with.
        /// </summary>
        public virtual Patient<T> Subject { get; set; }
        /// <summary>
        /// The Encounter during which this Condition was created or to which the creation of this record is tightly associated.
        /// </summary>
        public virtual Encounter<T> Encounter { get; set; }
        /// <summary>
        /// Individual who recorded the record and takes responsibility for its content.
        /// </summary>
        public virtual Practioner Recorder { get; set; }
        /// <summary>
        /// Individual who is making the condition statement.
        /// </summary>
        public virtual Practioner Asserter { get; set; }
        /// <summary>
        /// Additional information about the Condition. This is a general notes/comments entry for description of the Condition, its diagnosis and prognosis.
        /// </summary>
        public virtual string Note { get; set; }
    }
}
