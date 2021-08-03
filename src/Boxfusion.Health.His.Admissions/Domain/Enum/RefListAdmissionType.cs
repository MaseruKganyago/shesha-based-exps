using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enum
{
	[ReferenceList("HisAdmis", "AdmissionType")]
	public enum RefListAdmissionType : int
	{
		[Description("Admission")]
		admission = 1,

		[Description("Internal Transfer-In")]
		internalTransferIn = 2,

		[Description("External Transfer-In")]
		externalTransferIn = 3
	}
}
