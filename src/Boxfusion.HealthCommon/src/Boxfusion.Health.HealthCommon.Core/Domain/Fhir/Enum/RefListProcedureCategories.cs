using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ProcedureCategories")]
	public enum RefListProcedureCategories : long
	{
		[Description("Psychiatry procedure or service")]
		psychiatryProcedureOrService = 1,
		[Description("Counselling")]
		counselling = 2,
		[Description("Patient Specified")]
		patientSpecified = 4,
		[Description("Surgical procedure")]
		surgicalProcedure = 8,
		[Description("Diagnostic procedure")]
		diagnosticProcedure = 16,
		[Description("Chiropractic manipulation")]
		chiropracticManipulation = 32,
		[Description("Social service procedure")]
		socialServiceProcedure = 64,
		[Description("Education")]
		education = 128
	}
}
