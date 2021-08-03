using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Enum
{
	[ReferenceList("HisAdmis", "SeparationChildHealth")]
	public enum RefListSeparationChildHealth : int
	{
		
		[Description("SAM under 5 years")]
		samUunderFive = 1,

		[Description("MAM under 5 years")]
		mamUnderFive = 2,

		[Description("NAM under 5 years")]
		namUnderFive = 3,

		[Description("Pneumonia under 5 years")]
		pneumoniaUnderFive = 4,

		[Description("Diarrhoea under 5 years")]
		diarrhoeaUnder5 = 5,

		[Description("HIV Testing")]
		hivTesting = 6
	}
}
