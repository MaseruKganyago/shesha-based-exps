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
	[ReferenceList("Fhir", "MedicationRequestCategoryCodes")]
	public enum RefListMedicationRequestCategoryCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Inpatient")]
		inpatient = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Outpatient")]
		outpatient = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Community")]
		community = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Discharge")]
		discharge = 8
	}
}
