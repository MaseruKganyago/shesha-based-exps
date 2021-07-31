using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterTypes")]
	public enum RefListEncounterTypes : int
	{
		[Description("GP Consultation")]
		gpConsultation = 1,

		[Description("Nurse Consultation")]
		nurseConsultation = 2,

		[Description("Clinical Associate Consultation")]
		clinicalAssociateConsultation = 4,

		[Description("Specialist Consultation")]
		specialistConsultation = 8
	}
}
