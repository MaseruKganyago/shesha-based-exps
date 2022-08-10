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
	[ReferenceList("Fhir", "LocationBedStatuses")]
	public enum RefListLocationBedStatuses : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Closed")]
		C = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Housekeeping")]
		H = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Isolated")]
		I = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Contaminated")]
		K = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Occupied")]
		O = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Unoccupied")]
		U = 6
	}
}
