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
	[ReferenceList("Fhir", "ImmunisationOriginCodes")]
	public enum RefListImmunisationOriginCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Other Provider")]
		otherProvider = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Written Record")]
		writtenRecord = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Parent/ Guardian/ Patient Recall")]
		parentGuardianPateintRecall = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("School Record")]
		schoolRecord = 4
	}
}
