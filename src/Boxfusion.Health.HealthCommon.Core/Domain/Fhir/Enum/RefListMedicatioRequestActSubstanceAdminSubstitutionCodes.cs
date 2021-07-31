using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicatioRequestActSubstanceAdminSubstitutionCodes")]
	public enum RefListMedicatioRequestActSubstanceAdminSubstitutionCodes: int
	{
		[Description("Equivalent (E)")]
		equivalent = 1,
		[Description("Equivalent Composition (EC)")]
		equivalentComposition = 2,
		[Description("Brand Composition (BC)")]
		brandComposition = 3,
		[Description("Generic Composition (G)")]
		genericComposition = 4,
		[Description("Therapeutic Alternative (TE)")]
		therapeuticAlternative = 5,
		[Description("Therapeutic Brand (TB)")]
		therapeuticBrand = 6,
		[Description("Therapeutic Generic (TG)")]
		therapeuticGeneric = 7,
		[Description("Formulary (F)")]
		formulary = 8,
		[Description("None (N)")]
		none = 9
	}
}
