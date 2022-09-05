using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "OutCome")]
	public enum RefListOutCome: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Queued")]
		queued = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Completed")]
		completed = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Error")]
		error = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Partial")]
		partial = 4
	}
}
