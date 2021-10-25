using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Observation")]
	public class Observation: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BasedOnOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string BasedOnOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PartOfOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PartOfOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListObservationStatuses? Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ObservationCategoryCodes")]
		public virtual RefListObservationCategoryCodes? Category { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListObservationCodes? Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter Encounter { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string FocusOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string FocusOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EffectiveDateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EffectivePeriodStart { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EffectivePeriodEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Issued { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string PerformerOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListDataAbsentReasons? DataAbsentReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "ObservationInterpretations")]
		public virtual RefListObservationInterpretations? Interpretation { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "BodySites")]
		public virtual RefListBodySite? BodySite { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListObservationMethods? Method { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Specimen Specimen { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string DeviceOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string DeviceOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string HasMemberOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string HasMemberOwnerType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string DerivedFromOwnerId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string DerivedFromOwnerType { get; set; }
	}
}
