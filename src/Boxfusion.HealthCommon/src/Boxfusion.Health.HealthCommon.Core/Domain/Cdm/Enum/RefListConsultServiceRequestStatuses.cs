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
	[ReferenceList("Cdm", "ConsultServiceRequestStatuses")]
	public enum RefListConsultServiceRequestStatuses: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("In Progress")]
		inProgress = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Completed")]
		completed = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cancelled")]
		cancelled = 3
	}
}
