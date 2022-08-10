using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "MedicatioRequestActSubstanceAdminSubstitutionCodes")]
	public enum RefListMedicatioRequestActSubstanceAdminSubstitutionCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Equivalent (E)")]
		equivalent = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Equivalent Composition (EC)")]
		equivalentComposition = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Brand Composition (BC)")]
		brandComposition = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Generic Composition (G)")]
		genericComposition = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Therapeutic Alternative (TE)")]
		therapeuticAlternative = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Therapeutic Brand (TB)")]
		therapeuticBrand = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Therapeutic Generic (TG)")]
		therapeuticGeneric = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Formulary (F)")]
		formulary = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("None (N)")]
		none = 9
	}
}
