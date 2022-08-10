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
	[ReferenceList("Cdm", "VisitTasks")]
	public enum RefListVisitTasks: long
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
		screening = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Treatment")]
		treatment = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Psychological Support")]
		psychologicalSupport = 16,

		/// <summary>
		/// 
		/// </summary>
		[Description("Delivery of Medication")]
		deliveryOfMedication = 32,

		/// <summary>
		/// 
		/// </summary>
		[Description("Referral")]
		referral = 64,

		/// <summary>
		/// 
		/// </summary>
		[Description("Disease Prevention")]
		diseasePrevention = 128,

		/// <summary>
		/// 
		/// </summary>
		[Description("Management of Defaulters")]
		managementOfDefaulters = 256,

		/// <summary>
		/// 
		/// </summary>
		[Description("Contact Tracing")]
		contactTracing = 512,

		/// <summary>
		/// 
		/// </summary>
		[Description("Environmental Health Care")]
		environmentalHealthCare = 1024,

		/// <summary>
		/// 
		/// </summary>
		[Description("Maternal & Child Health")]
		maternalAndChildHealth = 2048,

		/// <summary>
		/// 
		/// </summary>
		[Description("Family Planning")]
		familyPlanning = 4096,

		/// <summary>
		/// 
		/// </summary>
		[Description("Communicable Disease Control")]
		communicableDiseaseControl = 8192,

		/// <summary>
		/// 
		/// </summary>
		[Description("Record Keeping")]
		recordKeeping = 16384,

		/// <summary>
		/// 
		/// </summary>
		[Description("Follow-Up")]
		followUp = 32768,

		/// <summary>
		/// 
		/// </summary>
		[Description("Social Services Support")]
		socialServicesSupport = 65536
	}
}
