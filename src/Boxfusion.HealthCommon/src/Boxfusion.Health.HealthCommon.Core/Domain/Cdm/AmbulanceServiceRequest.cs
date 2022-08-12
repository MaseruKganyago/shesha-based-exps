using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
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
	[Entity(TypeShortAlias = "HealthCommon.Core.AmbulanceServiceRequest")]
	public class AmbulanceServiceRequest: CdmServiceRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual FhirAddress PickUpAddress { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Cdm", "ProvisionalCondition")]
		public virtual RefListProvisionalCondition? ProvisionalCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }
	}
}
