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
	[ReferenceList("Cdm", "PractitionerRoles")]
	public enum RefListPractitionerRoles : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Doctor")]
		doctor = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Nurse")]
		nurse = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Clinical Associate")]
		clinicalAssociate = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Clinical Associate")]
		adminClerk = 224608005,

		/// <summary>
		/// 
		/// </summary>
		[Description("Community Health Worker")]
		chw = 224608006,
	}
}
