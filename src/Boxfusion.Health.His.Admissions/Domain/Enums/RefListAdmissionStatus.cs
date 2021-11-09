using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enums
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("HisAdmis", "AdmissionStatus")]
	public enum RefListAdmissionStatus: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Admitted")]
		admitted = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Separated")]
		separated = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("In-Transit")]
		inTransit = 3
	}
}
