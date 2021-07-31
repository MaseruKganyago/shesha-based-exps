using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ObservationCategoryCodes")]
	public enum RefListObservationCategoryCodes: int
	{
		[Description("Social History")]
		socialHistory = 1,
		[Description("Vital Signs")]
		vitalSigns = 2,
		[Description("Imaging")]
		imaging = 4,
		[Description("Laboratory")]
		laboratory = 8,
		[Description("Procedure")]
		procedure = 16,
		[Description("Survey")]
		survey = 32,
		[Description("Exam")]
		exam = 64,
		[Description("Therapy")]
		therapy = 128,
		[Description("Activity")]
		activity = 256
	}
}
