using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "DocumentTypeValueSets")]
	public enum RefListDocumentTypeValueSets: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Sick Note")]
		SickNote = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Covid-19")]
        Covid19 = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("eScript")]
        eScript = 3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Referral to Facility")]
        ReferralToFacility = 4,
        /// <summary>
        /// 
        /// </summary>
        [Description("Consultation Report")]
        ConsultationReport = 5
    }
}
