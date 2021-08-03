using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enum
{
	[ReferenceList("HisAdmis", "OtherCategories")]
	public enum RefListOtherCategories : int
	{
		[Description("Maternal Deaths")]
		maternalDeaths = 1,

		[Description("Prisoner")]
		prisoner = 2,

		[Description("MVA")]
		mva = 3,

		[Description("Gunshot")]
		gunshot = 4,

		[Description("Burn Wounds")]
		burnWounds = 5,

		[Description("Stab Wounds")]
		stabWounds = 6,

		[Description("Day Patients")]
		dayPatients = 7,

		[Description("Lodgers")]
		lodgers = 8,

		[Description("Cancellations ")]
		cancellations = 9
	}
}
