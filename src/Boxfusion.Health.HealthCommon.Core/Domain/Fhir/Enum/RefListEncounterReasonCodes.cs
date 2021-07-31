﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "EncounterReasonCodes")]
	public enum RefListEncounterReasonCodes : int
	{
		[Description("Follow-up Consultation")]
		followUpConsultation = 1
	}
}
