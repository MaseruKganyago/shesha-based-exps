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
	[ReferenceList("Fhir", "ImmunisationRouteCodes")]
	public enum RefListImmunisationRouteCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Injection, Intradermal (IDINJ)")]
		injectionIntrademal = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Injection, Intramuscular (IM)")]
		injectionIntramuscular = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Inhalation, Nasal (NASINHLC)")]
		inhalationNasal = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Injection, Intravenous (IVINJ)")]
		injectionIntravenous = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Swallow, Oral (PO)")]
		swallowOral = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Injection, Subcutaneous (SQ)")]
		injectionSubcutaneous = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Transdermal (TRNSDERM)")]
		transdermal = 7
	}
}
