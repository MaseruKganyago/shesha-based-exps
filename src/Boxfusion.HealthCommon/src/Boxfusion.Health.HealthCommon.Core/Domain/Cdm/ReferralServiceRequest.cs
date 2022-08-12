using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.ReferralServiceRequest")]
	[Table("Fhir_ServiceRequests")]
	public class ReferralServiceRequest: CdmServiceRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual RefListHealthcareServicec80PracticeCodes? Department { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string ReferralReason { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual string Comment { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public virtual string ReceivingPractitioner { get; set; }

    }
}
