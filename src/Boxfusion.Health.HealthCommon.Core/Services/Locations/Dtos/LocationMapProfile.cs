using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Locations.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public LocationMapProfile()
        {
            CreateMap<WardInput, Ward>()
                //.ForMember(e => e.Address, e => e.MapFrom(e => GetEntity<CdmAddress>(e.)))
                .ForMember(c => c.Address, options => options.Ignore())
                .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                .ForMember(e => e.OwnerOrganisation, e => e.MapFrom(e => GetEntity<Organisation>(e.OwnerOrganisation)))
                .ForMember(e => e.PartOf, e => e.MapFrom(e => GetEntity<Facility>(e.PartOf)))
                .MapReferenceListValuesFromDto();

            CreateMap<WardResponse, Ward>()
                //.ForMember(e => e.Address, e => e.MapFrom(e => GetEntity<CdmAddress>(e.)))
                .ForMember(c => c.Address, options => options.Ignore())
                .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                .ForMember(e => e.OwnerOrganisation, e => e.MapFrom(e => GetEntity<Organisation>(e.OwnerOrganisation)))
                .ForMember(e => e.PartOf, e => e.MapFrom(e => GetEntity<Facility>(e.PartOf)))
                .MapReferenceListValuesFromDto();

            CreateMap<Ward, WardResponse>()
                //.ForMember(c => c.Address, options => options.MapFrom(c => c.Address != null ? new EntityWithDisplayNameDto<Guid?>(c.Address.Id, c.Address.POBox) : null))
                .ForMember(c => c.PrimaryContact, options => options.MapFrom(c => c.PrimaryContact != null ? new EntityWithDisplayNameDto<Guid?>(c.PrimaryContact.Id, c.PrimaryContact.FullName) : null))
                .ForMember(c => c.OwnerOrganisation, options => options.MapFrom(c => c.OwnerOrganisation != null ? new EntityWithDisplayNameDto<Guid?>(c.OwnerOrganisation.Id, c.OwnerOrganisation.Name) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Name) : null))
                .MapReferenceListValuesToDto();

            CreateMap<Ward, CdmAddressInput>()
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

            CreateMap<Ward, CdmAddress>()
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
