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
	[ReferenceList("Fhir", "ServiceRequestParticipantRoles")]
	public enum RefListServiceRequestParticipantRoles: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Patient")]
		patient = 116154003
	}
}
