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
	[ReferenceList("Fhir", "EncounterClasses")]
	public enum RefListRefListEncounterClasses : long
	{
		[Description("Ambulatory")]
		AMB = 1,

		[Description("Emergency")]
		EMER = 2,

		[Description("Field")]
		FLD = 3,

		[Description("Home Health")]
		HH = 4,

		[Description("Inpatient Encounter")]
		IMP = 5,

		[Description("Inpatient Acute")]
		ACUTE = 6,

		[Description("Inpatient Non-Acute")]
		NONAC = 7,

		[Description("Observation Encounter")]
		OBSENC = 8,

		[Description("Pre-Admission")]
		PRENC = 9,

		[Description("Short Stay")]
		SS = 10,

		[Description("Virtual")]
		VR = 11
	}
}
