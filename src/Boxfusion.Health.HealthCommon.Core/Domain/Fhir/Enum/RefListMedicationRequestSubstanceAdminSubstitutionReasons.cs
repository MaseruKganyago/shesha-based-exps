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
	[ReferenceList("Fhir", "MedicationRequestSubstanceAdminSubstitutionReasons")]
	public enum RefListMedicationRequestSubstanceAdminSubstitutionReasons: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Continuing Therapy (CT)")]
		continuingTherapy = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Formulary Policy (FP)")]
		formularyPolicy = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Out of Stock (OS)")]
		outOfStock = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Regulatory Requirement (RR)")]
		regulatoryRequirement = 4
	}
}
