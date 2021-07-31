using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationStatementCategory")]
	public enum RefListMedicationStatementCategory: int
	{
		[Description("Inpatient")]
		inpatient = 1,
		[Description("Outpatient")]
		outPatient = 2,
		[Description("Community")]
		community = 3,
		[Description("Patient Specified")]
		patientSpecified = 4
	}
}
