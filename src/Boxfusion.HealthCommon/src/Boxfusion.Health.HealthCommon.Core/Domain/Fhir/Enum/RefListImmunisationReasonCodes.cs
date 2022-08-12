using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "ImmunisationReasonCodes")]
	public enum RefListImmunisationReasonCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Procedure to Meet Occupational Requirement")]
		procedureToMeetOccupationalRequirement = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Travel Vaccinations")]
		travelVaccinations = 2
	}
}
