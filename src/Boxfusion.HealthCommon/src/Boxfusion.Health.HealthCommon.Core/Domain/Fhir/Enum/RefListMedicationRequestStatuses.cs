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
	[ReferenceList("Fhir", "MedicationReuestStatuses")]
	public enum RefListMedicationRequestStatuses: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Active")]
		active = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("On Hold")]
		onHold = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cancelled")]
		cancelled = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Completed")]
		completed = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in Error")]
		enteredInError = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Stopped")]
		stopped = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Draft")]
		draft = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Unknown")]
		Unknown = 8
	}
}
