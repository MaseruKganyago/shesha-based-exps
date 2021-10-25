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
	[ReferenceList("Fhir", "EncounterPriorities")]
	public enum RefListEncounterPriorities : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("ASAP")]
		A = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Callback results")]
		CR = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Callback for scheduling")]
		CS = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Contact placer for scheduling")]
		CSR = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Elective")]
		EL = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Emergency")]
		EM = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Preop")]
		P = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("As needed")]
		PRN = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Routine")]
		R = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Rush Reporting")]
		RR = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Stat")]
		S = 11,

		/// <summary>
		/// 
		/// </summary>
		[Description("Timing Critical")]
		T = 12,

		/// <summary>
		/// 
		/// </summary>
		[Description("Use as directed")]
		UD = 13,

		/// <summary>
		/// 
		/// </summary>
		[Description("Urgent")]
		UR = 14
	}
}
