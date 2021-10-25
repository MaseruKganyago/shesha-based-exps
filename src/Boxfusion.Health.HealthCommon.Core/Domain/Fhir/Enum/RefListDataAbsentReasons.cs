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
	[ReferenceList("Fhir", "DataAbsentReasons")]
	public enum RefListDataAbsentReasons: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Unknown")]
		unknown = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Asked But Unknown")]
		askedButUnknown = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Temporarily Unknown")]
		temporarilyUnknown = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Asked")]
		notAsked = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Asked But Declined")]
		askedDeclined = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Masked")]
		masked = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Applicable")]
		notApplicable = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Unsupported")]
		unsupported = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("As Text")]
		asText = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Error")]
		error = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not a Number (NaN)")]
		notANumber = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Negative Infinity (NINF)")]
		negativeInfinity = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Positive Infinity (PINF)")]
		positiveInfinity = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Performed")]
		notPerformed = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Permitted")]
		notPermitted = 15
	}
}
