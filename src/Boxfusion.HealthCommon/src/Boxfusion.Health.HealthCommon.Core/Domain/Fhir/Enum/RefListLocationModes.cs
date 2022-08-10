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
	[ReferenceList("Fhir", "LocationModes")]
	public enum RefListLocationModes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Instance")]
		instance = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Kind")]
		kind = 2
	}
}
