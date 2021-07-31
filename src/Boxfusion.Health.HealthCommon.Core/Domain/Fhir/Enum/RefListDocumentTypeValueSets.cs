using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "DocumentTypeValueSets")]
	public enum RefListDocumentTypeValueSets: int
	{
		[Description("Sick Note")]
		sickNote = 1
	}
}
