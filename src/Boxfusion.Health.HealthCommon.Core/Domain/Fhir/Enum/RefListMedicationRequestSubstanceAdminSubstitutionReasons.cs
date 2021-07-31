using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationRequestSubstanceAdminSubstitutionReasons")]
	public enum RefListMedicationRequestSubstanceAdminSubstitutionReasons: int
	{
		[Description("Continuing Therapy (CT)")]
		continuingTherapy = 1,
		[Description("Formulary Policy (FP)")]
		formularyPolicy = 2,
		[Description("Out of Stock (OS)")]
		outOfStock = 3,
		[Description("Regulatory Requirement (RR)")]
		regulatoryRequirement = 4
	}
}
