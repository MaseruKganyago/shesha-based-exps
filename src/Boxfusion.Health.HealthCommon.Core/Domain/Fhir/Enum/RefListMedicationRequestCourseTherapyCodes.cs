using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "MedicationRequestCourseTherapyCodes")]
	public enum RefListMedicationRequestCourseTherapyCodes: int
	{
		[Description("Continous Long Term Therapy")]
		continousLongTermTherapy = 1,
		[Description("Short Course (acute) Therapy")]
		shortCourseAcuteTherapy = 2,
		[Description("Seasonal")]
		seasonal = 3
	}
}
