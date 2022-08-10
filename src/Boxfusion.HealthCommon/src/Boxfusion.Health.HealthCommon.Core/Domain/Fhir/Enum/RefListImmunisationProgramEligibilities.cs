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
	[ReferenceList("Fhir", "ImmunisationProgramEligibilities")]
	public enum RefListImmunisationProgramEligibilities: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Eligible")]
		notEligible = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Uninsured")]
		unInsured = 2
	}
}
