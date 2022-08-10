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
	[ReferenceList("Fhir", "CompositionStatuses")]
	public enum RefListCompositionStatuses: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Preliminary")]
		premilinary = 1,
		
		/// <summary>
		/// 
		/// </summary>
		[Description("Final")]
		final = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Amended")]
		amended = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in Error")]
		enteredInError = 4
	}
}
