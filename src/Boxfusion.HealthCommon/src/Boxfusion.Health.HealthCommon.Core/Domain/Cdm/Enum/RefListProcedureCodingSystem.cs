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
	[ReferenceList("Cdm", "ProcedureCodingSystem")]
	public enum RefListProcedureCodingSystem: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Free text")]
		freeText = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("SNOMED")]
		snomed = 2
	}
}
