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
	[ReferenceList("Fhir", "ImmunisationSubpotentReasons")]
	public enum RefListImmunisationSubpotentReasons: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Partial Dose")]
		partialDose = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Cold Chain Break")]
		partialChainBreak = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Manufacture Recall")]
		manufactureRecall = 4
	}
}
