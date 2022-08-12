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
	[ReferenceList("Fhir", "ImmunisationFundingSources")]
	public enum RefListImmunisationFundingSources: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Private Funding")]
		privateFunding = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Public Funding")]
		publicFunding = 2
	}
}
