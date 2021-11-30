using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Dtos;
using Shesha.AutoMapper;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.HisPatients.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class HisPatientMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public HisPatientMapProfile()
        {
            CreateMap<HisPatientInput, HisPatient>()
                .ForMember(c => c.CommunicationLanguage, options => options.Ignore())
                .ForMember(c => c.Gender, options => options.MapFrom(c => c.Gender != null ? (RefListGender?)c.Gender.ItemValue : null))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.IdentificationType)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.PatientProvince)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Nationality)))
                .MapReferenceListValuesToDto();

            CreateMap<HisPatient, HisPatientResponse>()
                .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (long?)c.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)c.PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)c.IdentificationType)))
                .MapReferenceListValuesToDto();
        }
    }
}
