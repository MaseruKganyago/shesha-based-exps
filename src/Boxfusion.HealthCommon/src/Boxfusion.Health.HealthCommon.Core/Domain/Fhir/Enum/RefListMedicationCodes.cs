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
	[ReferenceList("Fhir", "MedicationCodes")]
	public enum RefListMedicationCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Codeine phosphate")]
		codeinePhosphate = 1
	}
}
