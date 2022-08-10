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
	[ReferenceList("Fhir", "EncounterServiceTypes")]
	public enum RefListEncounterServiceTypes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("General Practice")]
		generalPractice = 1
	}
}
