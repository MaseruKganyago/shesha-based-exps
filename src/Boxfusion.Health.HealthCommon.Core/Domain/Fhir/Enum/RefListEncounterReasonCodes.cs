using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterReasonCodes")]
	public enum RefListEncounterReasonCodes : long
	{
		[Description("Follow-up Consultation")]
		followUpConsultation = 1,
		[Description("Null")]
		nullReasonCode = 2
	}
}
