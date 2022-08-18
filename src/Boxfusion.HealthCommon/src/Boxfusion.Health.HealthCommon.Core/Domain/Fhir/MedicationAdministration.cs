using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.MedicationAdministration")]
	public class MedicationAdministration : FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "MedicationAdministrationStatuses")]
		public virtual long? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "MedicationAdministrationCategories")]
		public virtual long? Category { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Medication Medication { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter ContextEncounter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EffectiveStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EffectiveEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual PersonFhirBase Performer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "MedicationAdministrationReasonCode")]
		public virtual long? ReasonCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Condition ReasonCondition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Observation ReasonObservation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual MedicationRequest Request { get; set; }
	}
}
