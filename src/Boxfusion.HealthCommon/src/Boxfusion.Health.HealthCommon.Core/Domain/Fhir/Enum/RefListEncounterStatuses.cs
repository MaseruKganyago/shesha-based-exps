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
	[ReferenceList("Fhir", "EncounterStatuses")]
	public enum RefListEncounterStatuses : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Planned")]
		planned = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Arrived")]
		arrived = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Triaged")]
		triaged = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("In Progress")]
		inprogressed = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("On Leave")]
		onleave = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Finished")]
		finished = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Cancelled")]
		cancelled = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in Error")]
		enteredInError = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Unknown")]
		unknown = 9
	}
}
