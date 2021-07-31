using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.DocumentReference")]
	public class DocumentReference: FullAuditedEntity<Guid>
	{
		public virtual string MasterIdentifier { get; set; }
		public virtual string Identifier { get; set; }
		[ReferenceList("Fhir", "DocumentReferenceStatuses")]
		public virtual int? Status { get; set; }
		[ReferenceList("Fhir", "CompositionStatuses")]
		public virtual int? DocStatus { get; set; }
		[ReferenceList("Fhir", "DocumentTypeValueSets")]
		public virtual int? Type { get; set; }
		[MultiValueReferenceList("Fhir", "DocumentClassValueSets")]
		public virtual UInt64? Category { get; set; }
		public virtual string SubjectOwnerId { get; set; }
		public virtual string SubjectOwnerType { get; set; }
		public virtual DateTime? Date { get; set; }
		public virtual string AuthorOwnerId { get; set; }
		public virtual string AuthorOwnerType { get; set; }
		public virtual FhirOrganisation Custodian { get; set; }
		public virtual string Description { get; set; }
		[ReferenceList("Fhir", "SecurityLabels")]
		public virtual int? SecurityLabel { get; set; }
		public virtual string ContextEncounterOwnerId { get; set; }
		public virtual string ContextEnounterOwnerType { get; set; }
		[ReferenceList("Fhir", "VersionThreeActCodes")]
		public virtual int? ContextEvent { get; set; }
		public virtual DateTime? ContextPeriodStart { get; set; }
		public virtual DateTime? ContextPeriodEnd { get; set; }
		[ReferenceList("Fhir", "FacilityTypeCodeValueSets")]
		public virtual int? ContextFacilityType { get; set; }
		[ReferenceList("Fhir", "HealthcareServicec80PracticeCodes")]
		public virtual int? ContextPracticeSetting { get; set; }
		public virtual Patient ContextSourcePatientInfo { get; set; }
		public virtual string ContextRelatedOwnerId { get; set; }
		public virtual string ContextRelatedOwnerType { get; set; }
	}
}
