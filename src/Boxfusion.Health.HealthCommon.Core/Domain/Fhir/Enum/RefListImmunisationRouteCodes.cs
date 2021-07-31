using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ImmunisationRouteCodes")]
	public enum RefListImmunisationRouteCodes: int
	{
		[Description("Injection, Intradermal (IDINJ)")]
		injectionIntrademal = 1,
		[Description("Injection, Intramuscular (IM)")]
		injectionIntramuscular = 2,
		[Description("Inhalation, Nasal (NASINHLC)")]
		inhalationNasal = 3,
		[Description("Injection, Intravenous (IVINJ)")]
		injectionIntravenous = 4,
		[Description("Swallow, Oral (PO)")]
		swallowOral = 5,
		[Description("Injection, Subcutaneous (SQ)")]
		injectionSubcutaneous = 6,
		[Description("Transdermal (TRNSDERM)")]
		transdermal = 7
	}
}
