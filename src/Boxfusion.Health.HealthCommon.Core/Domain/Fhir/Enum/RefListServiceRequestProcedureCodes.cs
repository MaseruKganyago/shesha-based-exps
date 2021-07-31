using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ServiceRequestProcedureCodes")]
	public enum RefListServiceRequestProcedureCodes: int
	{
		[Description("Excision of lesion of patella")]
		excisionOfLesionOfPatella = 104001
	}
}
