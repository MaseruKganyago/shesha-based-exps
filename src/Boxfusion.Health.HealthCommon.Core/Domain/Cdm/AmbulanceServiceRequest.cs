using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.AmbulanceServiceRequest")]
	public class AmbulanceServiceRequest: ServiceRequest
	{
		public virtual FhirAddress PickUpAddress { get; set; }
		public virtual string ProvisionalCondition { get; set; }
		public virtual string Comment { get; set; }
	}
}
