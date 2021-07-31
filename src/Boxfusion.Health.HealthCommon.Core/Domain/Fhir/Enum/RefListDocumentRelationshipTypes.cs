using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "DocumentRelationshipTypes")]
	public enum RefListDocumentRelationshipTypes: int
	{
		[Description("Replaces")]
		replaces = 1,
		[Description("Transforms")]
		transforms = 2,
		[Description("Signs")]
		signs = 3,
		[Description("Appends")]
		appends = 4
	}
}
