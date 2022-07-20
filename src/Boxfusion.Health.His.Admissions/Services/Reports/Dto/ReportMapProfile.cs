using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Domain.Domain.Reports.Dtos;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public ReportMapProfile()
        {
            CreateMap<ReportModelQuery, ReportResponseDto>()
                .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (int?)c.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)c.PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)c.IdentificationType)))
                .ForMember(c => c.AdmissionStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "AdmissionStatuses", (long?)c.AdmissionStatus)))
                .ForMember(c => c.AdmissionType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "AdmissionTypes", (long?)c.AdmissionType)))
                .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "WardSpecialities", (long?)c.Speciality)))
                .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Classifications", (long?)c.Classification)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
                .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "OtherCategories", (long?)c.OtherCategory)))
                .MapReferenceListValuesToDto();//still needs to be fixed on the name part;
        }
    }
}
