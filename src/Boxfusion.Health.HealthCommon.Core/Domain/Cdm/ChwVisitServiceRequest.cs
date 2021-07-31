using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.ChwVisitServiceRequest")]
	public class ChwVisitServiceRequest: ServiceRequest
	{
		[ReferenceList("Cdm", "VisitTypes")]
		public virtual int? VisitType { get; set; }
		public virtual bool IsSampleCollection { get; set; }
		public virtual bool IsMedicationDelivery { get; set; }
		public virtual DateTime? VisitDate { get; set; }
		public virtual TimeSpan? VisitTime { get; set; }
		public virtual string Comment { get; set; }
	}
}
