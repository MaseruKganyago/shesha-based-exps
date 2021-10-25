using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.DiagnosticTestServiceRequest")]
	public class DiagnosticTestServiceRequest: CdmServiceRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ScheduledVisitDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? ScheduledVisitTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool DiagnosticTestRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cdm", "Covid19TestTypes")]
		public virtual int? ExaminationType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cdm", "Covid19ReferralReasons")]
		public virtual int? ExamReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cdm", "Covid19FacilityTypes")]
		public virtual int? FacilityType { get; set; }
    }
}
