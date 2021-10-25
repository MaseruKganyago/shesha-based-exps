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
	[ReferenceList("Fhir", "ParticipationStatus")]
	public enum RefListParticipationStatus : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Required")]
		accepted = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Declined")]
		declined = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Tentative")]
		Tentative = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Needs Action")]
		needAction = 4
	}
}
