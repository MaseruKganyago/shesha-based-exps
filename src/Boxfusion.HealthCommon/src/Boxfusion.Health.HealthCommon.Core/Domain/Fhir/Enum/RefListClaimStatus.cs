using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "ClaimStatus")]
	public enum RefListClaimStatus: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Active")]
		active = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Cancelled")]
		cancelled = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Draft")]
		draft = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Entered in error")]
		enteredInError = 4
	}
}
