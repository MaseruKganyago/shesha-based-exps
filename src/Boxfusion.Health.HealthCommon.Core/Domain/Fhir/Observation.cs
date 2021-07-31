using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Observation")]
	public class Observation: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		public virtual string BasedOnOwnerId { get; set; }
		public virtual string BasedOnOwnerType { get; set; }
		public virtual string PartOfOwnerId { get; set; }
		public virtual string PartOfOwnerType { get; set; }
		[ReferenceList("Fhir", "ObservationStatuses")]
		public virtual int? Status { get; set; }
		[MultiValueReferenceList("Fhir", "ObservationCategoryCodes")]
		public virtual int? Category { get; set; }
		[ReferenceList("Fhir", "ObservationCodes")]
		public virtual int? Code { get; set; }
		public virtual Patient Subject { get; set; }
		public virtual Encounter Encounter { get; set; }
		public virtual string FocusOwnerId { get; set; }
		public virtual string FocusOwnerType { get; set; }
		public virtual DateTime? EffectiveDateTime { get; set; }
		public virtual DateTime? EffectivePeriodStart { get; set; }
		public virtual DateTime? EffectivePeriodEnd { get; set; }
		public virtual DateTime? Issued { get; set; }
		public virtual string PerformerOwnerId { get; set; }
		public virtual string PerformerOwnerType { get; set; }
		[ReferenceList("Fhir", "DataAbsentReasons")]
		public virtual int? DataAbsentReason { get; set; }
		[MultiValueReferenceList("Fhir", "ObservationInterpretations")]
		public virtual int? Interpretation { get; set; }
		[ReferenceList("Fhir", "BodySites")]
		public virtual int? BodySite { get; set; }
		[ReferenceList("Fhir", "ObservationMethods")]
		public virtual int? Method { get; set; }
		public virtual Specimen Specimen { get; set; }
		public virtual string DeviceOwnerId { get; set; }
		public virtual string DeviceOwnerType { get; set; }
		public virtual string HasMemberOwnerId { get; set; }
		public virtual string HasMemberOwnerType { get; set; }
		public virtual string DerivedFromOwnerId { get; set; }
		public virtual string DerivedFromOwnerType { get; set; }
	}
}
