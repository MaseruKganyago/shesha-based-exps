using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary
{
    /// <summary>
    /// 
    /// </summary>
	public class ConsultationSummaryMapProfile: ShaProfile
	{
        /// <summary>
        /// 
        /// </summary>
		public ConsultationSummaryMapProfile()
		{
            CreateMap<CdmMedicationRequest, MedicationTextModel>()
                .ForMember(a => a.Dosage, options => options.MapFrom(b => GetRefListItemText("Cdm", "Dosages", (int?)b.Dosage)));

            CreateMap<ReferralServiceRequest, FacilityHolder>()
                .ForMember(a => a.FacilityName, options => options.MapFrom(b => GetRefListItemText("Fhir", "HealthcareServicec80PracticeCodes", (int?)b.Department)));
        }
	}
}
