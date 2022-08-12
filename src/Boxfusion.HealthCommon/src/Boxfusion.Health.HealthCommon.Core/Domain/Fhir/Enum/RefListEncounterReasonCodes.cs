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
	/// 
	[Obsolete("This list will likely need to configured on a per client basis and should therefore be data driven. Once dependency from Ward Admissions module has been removed will need to Delete this from the project")]
	[ReferenceList("Fhir", "EncounterReasonCodes")]
	public enum RefListEncounterReasonCodes : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Follow-up Consultation")]
		followUpConsultation = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Null")]
		nullReasonCode = 2
	}
}
