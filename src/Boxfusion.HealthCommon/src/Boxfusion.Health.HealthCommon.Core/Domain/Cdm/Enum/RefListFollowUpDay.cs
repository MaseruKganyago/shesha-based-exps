using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Cdm", "FollowUpDay")]
	public enum RefListFollowUpDay: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("1 Day")]
		oneDay = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("3 Days")]
		threeDays = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("7 Days")]
		sevenDays = 3
	}
}
