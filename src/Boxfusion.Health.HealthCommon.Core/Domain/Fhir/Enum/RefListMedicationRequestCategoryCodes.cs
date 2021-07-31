using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationRequestCategoryCodes")]
	public enum RefListMedicationRequestCategoryCodes: int
	{
		[Description("Inpatient")]
		inpatient = 1,
		[Description("Outpatient")]
		outpatient = 2,
		[Description("Community")]
		community = 4,
		[Description("Discharge")]
		discharge = 8
	}
}
