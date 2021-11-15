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
	[ReferenceList("HisAdmis", "AdmissionType")]
	public enum RefListAdmissionType: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Normal Admission")]
		normalAdmission = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Internal Transfer-In")]
		internalTransferIn = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("External Transfer-In")]
		externalTransferIn = 3
	}
}
