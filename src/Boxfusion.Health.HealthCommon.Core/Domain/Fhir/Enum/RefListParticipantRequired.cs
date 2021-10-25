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
	[ReferenceList("Fhir", "ParticipantRequired")]
	public enum RefListParticipantRequired : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Required")]
		required = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Optional")]
		optional = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Information Only")]
		informationOnly = 3
	}
}
