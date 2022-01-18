using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Dtos;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.HisPatients.Dtos
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
                .ForMember(c => c.MaritalStatus, options => options.MapFrom(c => c.Gender != null ? (RefListGender?)c.MaritalStatus.ItemValue : null))
                .ForMember(c => c.Gender, options => options.MapFrom(c => c.Gender != null ? (RefListGender?)c.Gender.ItemValue : null))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.IdentificationType)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.PatientProvince)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Nationality)))
                .ForMember(a => a.LinkToOtherPatient, options => options.MapFrom(b => GetEntity<HisPatient>(b.LinkToOtherPatient)))
                .ForMember(c => c.TypeOfLinkToOtherPatient, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.TypeOfLinkToOtherPatient)))
                .ForMember(c => c.IdentityVerificationStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.IdentityVerificationStatus)))
                .ForMember(c => c.Title, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Title)))
                .ForMember(c => c.Ethnicity, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.Ethnicity)))
                .MapReferenceListValuesToDto();

            CreateMap<HisPatient, HisPatientResponse>()
                .ForMember(c => c.MaritalStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "MaritalStatus", (long?)c.MaritalStatus)))
                .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (long?)c.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)c.PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)c.IdentificationType)))
                .ForMember(c => c.TypeOfLinkToOtherPatient, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "LinkTypes", (long?)c.TypeOfLinkToOtherPatient)))
                .ForMember(c => c.IdentityVerificationStatus, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "IdentityVerificationStatus", (long?)c.IdentityVerificationStatus)))
                .ForMember(c => c.Title, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "PersonTitles", (long?)c.Title)))
                .ForMember(c => c.Ethnicity, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "PersonEthnicity", (long?)c.Ethnicity)))
                .ForMember(c => c.LinkToOtherPatient, options => options.MapFrom(c => c.LinkToOtherPatient != null ? new EntityWithDisplayNameDto<Guid?>(c.LinkToOtherPatient.Id, c.LinkToOtherPatient.FullName) : null))
                .MapReferenceListValuesToDto();
        }
    }
}
