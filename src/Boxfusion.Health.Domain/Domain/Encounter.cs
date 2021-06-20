using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.BackboneElements;
using Boxfusion.Health.Domain.Domain.CodeableConceptLists;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// 	An interaction during which services are provided to the patient
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Encounter")]
    public class Encounter : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Identifier(s) by which this encounter is known.
        /// </summary>
        public virtual Identifier Identifier { get; set; }

        /// <summary>
        /// planned | arrived | triaged | in-progress | onleave | finished | cancelled +.
        /// </summary>
        public virtual RefListEncounterStatus? Status { get; set; }

        /// <summary>
        /// Concepts representing classification of patient encounter such as ambulatory (outpatient), inpatient, emergency, home health or 
        /// others due to local variations.
        /// </summary>
        public virtual EncounterClass Class { get; set; }

        /// <summary>
        /// Specific type of encounter (e.g. e-mail consultation, surgical day-care, skilled nursing, rehabilitation).
        /// </summary>
        public virtual EncounterType EncounterType { get; set; }

        /// <summary>
        /// Broad categorization of the service that is to be provided (e.g. cardiology).
        /// </summary>
        public virtual EncounterServiceType EncounterServiceType { get; set; }

        /// <summary>
        /// Indicates the urgency of the encounter.
        /// </summary>
        public virtual EncounterPriority Priority { get; set; }

        /// <summary>
        /// The patient or group present at the encounter.
        /// </summary>
        public virtual Patient Subject { get; set; }

        /// <summary>
        /// Where a specific encounter should be classified as a part of a specific episode(s) of care this field should be used. 
        /// This association can facilitate grouping of related encounters together for a specific purpose, such as government reporting, 
        /// issue tracking, association via a common problem. The association is recorded on the encounter as these are typically created after 
        /// the episode of care and grouped on entry rather than editing the episode of care to append another encounter to it 
        /// (the episode of care could span years).
        /// </summary>
        public virtual Patient EpisodeOfCare { get; set; }

        /// <summary>
        /// The request this encounter satisfies (e.g. incoming referral or procedure request).
        /// </summary>
        public virtual ServiceRequest BasedOn { get; set; }

        /// <summary>
        /// The appointment that scheduled this encounter.
        /// </summary>
        public virtual Appointment Appointment { get; set; }

        /// <summary>
        /// Starting time with inclusive boundary
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End time with inclusive boundary, if not ongoing
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Quantity of time the encounter lasted. This excludes the time during leaves of absence.
        /// </summary>
        public virtual TimeSpan? Length { get; set; }

        /// <summary>
        /// Reason the encounter takes place, expressed as a code. For admissions, this can be used for a coded admission diagnosis.
        /// </summary>
        public virtual EncounterReasonCode ReasonCode { get; set; }

        /// <summary>
        /// Reason the encounter takes place, expressed as a code. For admissions, this can be used for a coded admission diagnosis.
        /// </summary>
        public virtual Condition ReasonReference { get; set; }

        /// <summary>
        /// The set of accounts that may be used for billing for this Encounter.
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// The organization that is primarily responsible for this Encounter's services. This MAY be the same as the organization on the 
        /// Patient record, however it could be different, such as if the actor performing the services was from an external organization 
        /// (which may be billed seperately) for an external consultation. Refer to the example bundle showing an abbreviated set of Encounters 
        /// for a colonoscopy.
        /// </summary>
        public virtual Organization ServiceProvider { get; set; }

        /// <summary>
        /// Another Encounter of which this encounter is a part of (administratively or in time).
        /// </summary>
        public virtual Encounter PartOf { get; set; }
    }
}
