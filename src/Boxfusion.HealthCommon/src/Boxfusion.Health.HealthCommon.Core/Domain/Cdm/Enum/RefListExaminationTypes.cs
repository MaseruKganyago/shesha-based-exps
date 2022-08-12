using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Cdm", "ExaminationTypes")]
	public enum RefListExaminationTypes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Health Education & Promotions")]
		healthEducationAndPromotions = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Record Vitals")]
		recordVitals = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Screening")]
		screening = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Treatment")]
		treatment = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Psychological Support")]
		psychologicalSupport = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Delivery of Medication")]
		deliveryOfMedication = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Referral")]
		referral = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Disease Prevention")]
		diseasePrevention = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Management of Defaulters")]
		managementOfDefaulters = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Contact Tracing")]
		contactTracing = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Enviromemnt Health Care")]
		enviromentHealthCare = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Meternal & Child Health")]
		mentalAndChildHealth = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Family Planning")]
		familyPlanning = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Communicable Disease Control")]
		communicableDiseaseControl = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Record Keeping")]
		recordKeeping = 15,
		/// <summary>
		/// 
		/// </summary>
		[Description("Follow-Up")]
		followUp = 16,
		/// <summary>
		/// 
		/// </summary>
		[Description("Social Services Support")]
		socialServicesSupport = 17
	}
}
