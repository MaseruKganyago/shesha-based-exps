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
	[ReferenceList("Fhir", "MaritalStatus")]
	public enum RefListMaritalStatus : long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Annulled")]
		A = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Divorced")]
		D = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Interlocutory")]
		I = 3,

		/// <summary>
		/// 
		/// </summary>
		[Description("Legally Separated")]
		L = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Married")]
		M = 5,

		/// <summary>
		/// 
		/// </summary>
		[Description("Polygamous")]
		P = 6,

		/// <summary>
		/// 
		/// </summary>
		[Description("Never Married")]
		S = 7,

		/// <summary>
		/// 
		/// </summary>
		[Description("Domestic partner")]
		T = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Unmarried")]
		U = 9,

		/// <summary>
		/// 
		/// </summary>
		[Description("Widowed")]
		W = 10,

		/// <summary>
		/// 
		/// </summary>
		[Description("Unknown")]
		UNK = 11
	}
}
