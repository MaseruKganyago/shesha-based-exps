using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ProcedureCategories")]
	public enum RefListProcedureCategories : int
	{
		[Description("Psychiatry procedure or service")]
		psychiatryProcedureOrService = 24642003,
		[Description("Counselling")]
		counselling = 409063005,
		[Description("Education")]
		education = 409073007,
		[Description("Surgical procedure")]
		surgicalProcedure = 387713003,
		[Description("Diagnostic procedure")]
		diagnosticProcedure = 103693007,
		[Description("Chiropractic manipulation")]
		chiropracticManipulation = 46947000,
		[Description("Social service procedure")]
		socialServiceProcedure = 410606002
	}
}
