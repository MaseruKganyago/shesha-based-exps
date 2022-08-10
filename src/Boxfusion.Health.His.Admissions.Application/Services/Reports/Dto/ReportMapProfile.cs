using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
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
                .ForMember(c => c.Gender, options => options.MapFrom(c => GetRefListItemValueDto("Shesha.Core", "Gender", (int?)c.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => GetRefListItemValueDto("Cdm", "Countries", (int?)c.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => GetRefListItemValueDto("His", "Provinces", (int?)c.PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => GetRefListItemValueDto("His", "IdentificationTypes", (int?)c.IdentificationType)))
                .ForMember(c => c.AdmissionStatus, options => options.MapFrom(c => GetRefListItemValueDto("His", "AdmissionStatuses", (int?)c.AdmissionStatus)))
                .ForMember(c => c.AdmissionType, options => options.MapFrom(c => GetRefListItemValueDto("His", "AdmissionTypes", (int?)c.AdmissionType)))
                .ForMember(c => c.Speciality, options => options.MapFrom(c => GetRefListItemValueDto("Fhir", "WardSpecialities", (int?)c.Speciality)))
                .ForMember(c => c.Classification, options => options.MapFrom(c => GetRefListItemValueDto("His", "Classifications", (int?)c.Classification)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => GetRefListItemValueDto("Cdm", "Countries", (int?)c.Nationality)))
                .ForMember(c => c.OtherCategory, options => options.MapFrom(c => GetRefListItemValueDto("His", "OtherCategories", (int?)c.OtherCategory)))
                .MapReferenceListValuesToDto();//still needs to be fixed on the name part;
        }
    }
}
