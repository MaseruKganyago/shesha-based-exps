using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.CdmCommunication")]
	[Table("Fhir_Communications")]
	public class CdmCommunication: Communication
	{
		public virtual ServiceRequest ServiceRequest { get; set; }
		public virtual DateTime? StartTime { get; set; }
		public virtual DateTime? EndTime { get; set; }
	}
}
