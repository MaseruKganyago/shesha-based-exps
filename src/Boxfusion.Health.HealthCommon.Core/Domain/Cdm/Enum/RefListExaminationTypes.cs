using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
	[ReferenceList("Cdm", "ExaminationTypes")]
	public enum RefListExaminationTypes: int
	{
		[Description("Health Education & Promotions")]
		healthEducationAndPromotions = 1,
		[Description("Record Vitals")]
		recordVitals = 2,
		[Description("Screening")]
		screening = 3,
		[Description("Treatment")]
		treatment = 4,
		[Description("Psychological Support")]
		psychologicalSupport = 5,
		[Description("Delivery of Medication")]
		deliveryOfMedication = 6,
		[Description("Referral")]
		referral = 7,
		[Description("Disease Prevention")]
		diseasePrevention = 8,
		[Description("Management of Defaulters")]
		managementOfDefaulters = 9,
		[Description("Contact Tracing")]
		contactTracing = 10,
		[Description("Enviromemnt Health Care")]
		enviromentHealthCare = 11,
		[Description("Meternal & Child Health")]
		mentalAndChildHealth = 12,
		[Description("Family Planning")]
		familyPlanning = 13,
		[Description("Communicable Disease Control")]
		communicableDiseaseControl = 14,
		[Description("Record Keeping")]
		recordKeeping = 15,
		[Description("Follow-Up")]
		followUp = 16,
		[Description("Social Services Support")]
		socialServicesSupport = 17
	}
}
