using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.ReferralServiceRequest")]
	public class ReferralServiceRequest: ServiceRequest
	{
		[ReferenceList("Cdm", "HealthDepartments")]
		public virtual int? Department { get; set; }
		public virtual string ReferralReason { get; set; }
		public virtual string Comment { get; set; }
	}
}
