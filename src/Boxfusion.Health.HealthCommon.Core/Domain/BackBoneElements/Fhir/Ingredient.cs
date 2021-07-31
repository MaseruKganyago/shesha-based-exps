using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Ingredient")]
	public class Ingredient: FullAuditedEntity<Guid>
	{
		[ReferenceList("Fhir", "MedicationIngredients")]
		public virtual int? ItemCodeableConcept { get; set; }
		public virtual string ItemOwnerReferenceId { get; set; }
		public virtual string ItemOwnerReferenceType { get; set; }
		public virtual bool IsActive { get; set; }
		public virtual decimal StrengthNumerator { get; set; }
		public virtual decimal StrengthDenominator { get; set; }
	}
}
