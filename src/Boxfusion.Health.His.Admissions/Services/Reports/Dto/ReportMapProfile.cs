﻿using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
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
            //CreateMap<HospitalAdmission, ReportResponseDto>()
            //    .ForMember(c => c.Id, options => options.Ignore())
            //    .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Classifications", (long?)c.Classification)))
            //    .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "OtherCategories", (long?)c.OtherCategory)))
            //    .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
            //    .MapReferenceListValuesToDto();

            //CreateMap<HisPatient, ReportResponseDto>()
            //    .ForMember(c => c.Id, options => options.Ignore())
            //    .ForMember(c => c.FirstName, options => options.MapFrom(c => c.FirstName))
            //    .ForMember(c => c.LastName, options => options.MapFrom(c => c.LastName))
            //    .ForMember(c => c.DateOfBirth, options => options.MapFrom(c => c.DateOfBirth))
            //    .ForMember(c => c.IdentityNumber, options => options.MapFrom(c => c.IdentityNumber))
            //    .ForMember(c => c.HospitalPatientNumber, options => options.MapFrom(c => c.HospitalPatientNumber))
            //    .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (long?)c.Gender)))
            //    .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Nationality)))
            //    .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)c.PatientProvince)))
            //    .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)c.IdentificationType)))
            //    .MapReferenceListValuesToDto();

            CreateMap<WardAdmission, ReportResponseDto>()
                .ForMember(c => c.FirstName, options => options.MapFrom(c => c.Subject.FirstName))
                .ForMember(c => c.LastName, options => options.MapFrom(c => c.Subject.LastName))
                .ForMember(c => c.DateOfBirth, options => options.MapFrom(c => c.Subject.DateOfBirth))
                .ForMember(c => c.IdentityNumber, options => options.MapFrom(c => c.Subject.IdentityNumber))
                .ForMember(c => c.HospitalPatientNumber, options => options.MapFrom(c => (c.Subject as HisPatient).HospitalPatientNumber))
                .ForMember(c => c.Gender, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Shesha.Core", "Gender", (long?)c.Subject.Gender)))
                .ForMember(c => c.Nationality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "Countries", (long?)c.Subject.Nationality)))
                .ForMember(c => c.PatientProvince, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Provinces", (long?)(c.Subject as HisPatient).PatientProvince)))
                .ForMember(c => c.IdentificationType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "IdentificationTypes", (long?)(c.Subject as HisPatient).IdentificationType)))

                .ForMember(c => c.Classification, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "Classifications", (long?)(c.HisAdmission as HospitalAdmission).Classification)))
                .ForMember(c => c.OtherCategory, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("His", "OtherCategories", (long?)(c.HisAdmission as HospitalAdmission).OtherCategory)))
                .ForMember(c => c.StartDateTime, options => options.MapFrom(c => c.StartDateTime))
                .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "WardSpecialities", (long?)c.Ward.Speciality)))
                .MapReferenceListValuesToDto();

            //CreateMap<Ward, ReportResponseDto>()
            //    .ForMember(c => c.Speciality, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Fhir", "WardSpecialities", (long?)c.Speciality)))
            //    .MapReferenceListValuesToDto();
        }
    }
}