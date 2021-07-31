using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "DocumentReferenceStatuses")]
	public enum RefListDocumentReferenceStatuses: int
	{
		[Description("Current")]
		current = 1,
		[Description("Superseded")]
		superseded = 2,
		[Description("Entered in Error")]
		enteredInError = 3
	}
}
