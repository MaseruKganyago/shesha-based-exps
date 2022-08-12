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
	[ReferenceList("Fhir", "MedicationRequestCourseTherapyCodes")]
	public enum RefListMedicationRequestCourseTherapyCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Continous Long Term Therapy")]
		continousLongTermTherapy = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Short Course (acute) Therapy")]
		shortCourseAcuteTherapy = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Seasonal")]
		seasonal = 3
	}
}
