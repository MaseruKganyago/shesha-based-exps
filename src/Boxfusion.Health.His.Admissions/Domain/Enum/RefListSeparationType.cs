using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enum
{
	[ReferenceList("HisAdmis", "SeparationType")]
	public enum RefListSeparationType : int
	{
		[Description("Discharged (including Abscondment & RHT)")]
		discharged = 1,

		[Description("Death")]
		death = 2,

		[Description("Transfer Out to Other Ward")]
		internalTransfer = 3,

		[Description("Transfer Out to Other Facility")]
		externalTransfer = 4			
	}
}
