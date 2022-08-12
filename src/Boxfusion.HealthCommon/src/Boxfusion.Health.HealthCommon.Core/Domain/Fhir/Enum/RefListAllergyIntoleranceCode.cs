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
	[ReferenceList("Fhir", "AllergyIntoleranceCode")]
	public enum RefListAllergyIntoleranceCode: long
	{
		[Description("Hemoglobin Okaloosa")]
		hemaglobinOkaloosa = 1,
		[Description("Ornithine racemase")]
		ornithineRacemase = 2,
		[Description("Ferrous sulfate Fe^59^")]
		ferrousSulfate = 3,
		[Description("Galactosyl-N-acetylglucosaminylgalactosylglucosylceramide alpha-galactosyltransferase")]
		galactosylN = 4,
		[Description("Hemoglobin Hopkins-II")]
		hemoglobinHopkinsII = 5
	}
}
