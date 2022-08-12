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
	[ReferenceList("Fhir", "LinkTypes")]
	public enum RefListLinkTypes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Replaced-by")]
		replacedBy = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Replaces")]
		replaces = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Refer")]
		refer = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("See also")]
		seealso = 4
	}
}
