using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "AllergyIntoleranceSeverities")]
	public enum RefListAllergyIntoleranceSeverities: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Mild")]
		mild = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Moderate")]
		moderate = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Severe")]
		severe = 3
	}
}
