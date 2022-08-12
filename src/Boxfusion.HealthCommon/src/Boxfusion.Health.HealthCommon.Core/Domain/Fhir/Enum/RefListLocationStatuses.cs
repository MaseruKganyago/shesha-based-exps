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
	[ReferenceList("Fhir", "LocationStatuses")]
	public enum RefListLocationStatuses : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Active")]
		active = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Suspended")]
		suspended = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Inactive")]
		inactive = 3
	}
}
