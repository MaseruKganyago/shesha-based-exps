using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.ChwVisitServiceRequest")]
	public class ChwVisitServiceRequest: CdmServiceRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListVisitTypes? VisitType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsSampleCollection { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsMedicationDelivery { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? VisitDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual TimeSpan? VisitTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Address { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Cdm", "VisitTasks")]
		public virtual RefListVisitTasks VisitTasks { get; set; }
	}
}
