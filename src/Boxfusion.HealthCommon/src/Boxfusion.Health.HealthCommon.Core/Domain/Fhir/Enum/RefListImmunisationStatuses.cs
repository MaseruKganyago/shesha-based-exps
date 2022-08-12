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
	[ReferenceList("Fhir", "ImmunisationStatuses")]
	public enum RefListImmunisationStatuses: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Preparation")]
		preparation = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("In Progress")]
		inProgress = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Not Done")]
		notDone = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("On Hold")]
		onHold = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Stopped")]
		stopped = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Completed")]
		completed = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in Error")]
		enteredInError = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Unknown")]
		unknown = 8
	}
}
