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
	[ReferenceList("Fhir", "EncounterTypes")]
	public enum RefListEncounterTypes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("GP Consultation")]
		gpConsultation = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Nurse Consultation")]
		nurseConsultation = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Clinical Associate Consultation")]
		clinicalAssociateConsultation = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Specialist Consultation")]
		specialistConsultation = 8
	}
}
