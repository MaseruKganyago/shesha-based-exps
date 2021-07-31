using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.CdmCommunication")]
	public class CdmCommunication: Communication
	{
		public virtual ServiceRequest ServiceRequest { get; set; }
		public virtual DateTime? StartTime { get; set; }
		public virtual DateTime? EndTime { get; set; }
	}
}
