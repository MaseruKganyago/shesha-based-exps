using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	[Entity(TypeShortAlias = "HealthCommon.Core.DiagnosticTestServiceRequest")]
	public class DiagnosticTestServiceRequest: ServiceRequest
	{
		public virtual DateTime? ScheduledVisitDate { get; set; }
		public virtual TimeSpan? ScheduledVisitTime { get; set; }
		public virtual bool DiagnosticTestRequired { get; set; }
		[ReferenceList("Cdm", "ExaminationTypes")]
		public virtual int? ExaminationType { get; set; }
		[ReferenceList("Fhir", "BodySites")]
		public virtual int? BodyPart { get; set; }
		public virtual string ExamReason { get; set; }
		public virtual string Comment { get; set; }
	}
}
