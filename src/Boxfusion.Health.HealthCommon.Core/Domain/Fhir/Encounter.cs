using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Encounter")]
	public class Encounter: FullAuditedEntity<Guid>
	{
        public virtual string Identifier { get; set; }

        [ReferenceList("Fhir", "EncounterStatuses")]
        public virtual int? Status { get; set; }

        [ReferenceList("Fhir", "EncounterClasses")]
        public virtual int? Class { get; set; }

        [MultiValueReferenceList("Fhir", "EncounterTypes")]
        public virtual int? Type { get; set; }

        [ReferenceList("Fhir", "EncounterServiceTypes")]
        public virtual int? ServiceType { get; set; }

        [ReferenceList("Fhir", "EncounterPriorities")]
        public virtual int? Priority { get; set; }

        public virtual Patient Subject { get; set; }

        public virtual EpisodeOfCare EpisodeOfCare { get; set; }

        public virtual ServiceRequest BasedOn { get; set; }

        public virtual Practitioner Performer { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual DateTime? StartDateTime { get; set; }

        public virtual DateTime? EndDateTime { get; set; }

        [MultiValueReferenceList("Fhir", "EncounterReasonCodes")]
        public virtual int? ReasonCode { get; set; }

        public virtual string ReasonReferenceOwnerId { get; set; }

        public virtual string ReasonReferenceOwnerType { get; set; }

        public virtual  FhirOrganisation ServiceProvider { get; set; }

        public virtual Encounter PartOf { get; set; }
    }
}
