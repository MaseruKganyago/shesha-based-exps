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
	[ReferenceList("Fhir", "MedicationStatementCategory")]
	public enum RefListMedicationStatementCategory: long
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
		outPatient = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Community")]
		community = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Patient Specified")]
		patientSpecified = 4
	}
}
