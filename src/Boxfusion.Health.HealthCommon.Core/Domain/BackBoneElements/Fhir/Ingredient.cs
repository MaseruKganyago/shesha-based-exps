using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Ingredient")]
	public class Ingredient: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "MedicationIngredients")]
		public virtual int? ItemCodeableConcept { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ItemOwnerReferenceId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ItemOwnerReferenceType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsActive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal StrengthNumerator { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal StrengthDenominator { get; set; }
	}
}
