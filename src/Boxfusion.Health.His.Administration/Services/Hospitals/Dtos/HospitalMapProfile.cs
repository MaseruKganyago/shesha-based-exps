using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Services.Wards.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.Hospitals.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class HospitalMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public HospitalMapProfile()
        {
            CreateMap<HospitalInput, HisHospital>()
                    .ForMember(c => c.PrimaryAddress, options => options.Ignore())
                    .ForMember(e => e.Parent, e => e.MapFrom(e => GetEntity<Organisation>(e.Parent)))
                    .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                    .ForMember(c => c.District, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.District)))
                    .ForMember(c => c.FacilityType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValue(c.FacilityType)))
                    .MapReferenceListValuesFromDto();

            CreateMap<HisHospitalResponse, HisHospital>()
                    .ForMember(c => c.PrimaryAddress, options => options.Ignore())
                    .ForMember(e => e.Parent, e => e.MapFrom(e => GetEntity<Organisation>(e.Parent)))
                    .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                    .MapReferenceListValuesFromDto();


            CreateMap<HisHospital, HospitalResponse>()
                    .ForMember(c => c.Parent, options => options.MapFrom(c => c.Parent != null ? new EntityWithDisplayNameDto<Guid?>(c.Parent.Id, c.Parent.Name) : null))
                    .ForMember(c => c.PrimaryContact, options => options.MapFrom(c => c.PrimaryContact != null ? new EntityWithDisplayNameDto<Guid?>(c.PrimaryContact.Id, c.PrimaryContact.FullName) : null))
                    .ForMember(c => c.District, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "FacilityDistricts", (long?)c.District)))
                    .ForMember(c => c.FacilityType, options => options.MapFrom(c => UtilityHelper.GetRefListItemValueDto("Cdm", "HospitalTypes", (long?)c.FacilityType)))
                    .MapReferenceListValuesToDto();

            CreateMap<HisHospital, CdmAddressInput>()
                    .ForMember(c => c.OwnerId, options => options.MapFrom(c => c.Id.ToString()))
                    .ForMember(c => c.OwnerType, options => options.MapFrom(c => c.GetTypeShortAlias()))
                    .ForMember(u => u.Id, options => options.Ignore())
                    .ForMember(u => u.Use, options => options.Ignore())
                    .ForMember(u => u.Type, options => options.Ignore())
                    .ForMember(u => u.FullAddress, options => options.Ignore())
                    .ForMember(u => u.District, options => options.Ignore())
                    .ForMember(u => u.State, options => options.Ignore())
                    .ForMember(u => u.Country, options => options.Ignore())
                    .ForMember(u => u.StartDateTime, options => options.Ignore())
                    .ForMember(u => u.EndDateTime, options => options.Ignore())
                    .MapReferenceListValuesFromDto();

            CreateMap<HisHospital, CdmAddress>()
                    .ForMember(c => c.Id, options => options.Ignore())
                    .ForMember(c => c.Type, options => options.Ignore())
                    .ForMember(c => c.Latitude, options => options.Ignore())
                    .ForMember(c => c.Longitude, options => options.Ignore())
                    .ForMember(c => c.OwnerId, options => options.MapFrom(c => c.Id.ToString()))
                    .ForMember(c => c.OwnerType, options => options.MapFrom(c => c.GetTypeShortAlias()))
                    .MapReferenceListValuesFromDto();
        }
    }
}
