using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationReasonCodes")]
	public enum RefListImmunisationReasonCodes: int
	{
		[Description("Procedure to Meet Occupational Requirement")]
		procedureToMeetOccupationalRequirement = 1,
		[Description("Travel Vaccinations")]
		travelVaccinations = 2
	}
}
