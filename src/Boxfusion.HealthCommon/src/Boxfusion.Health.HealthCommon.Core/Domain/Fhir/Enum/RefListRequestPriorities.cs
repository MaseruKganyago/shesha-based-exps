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
	[ReferenceList("Fhir", "RequestPriorities")]
	public enum RefListRequestPriorities : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Routine")]
		routine = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Urgent")]
		urgent = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Asap")]
		asap = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Stat")]
		stat = 4
	}
}
