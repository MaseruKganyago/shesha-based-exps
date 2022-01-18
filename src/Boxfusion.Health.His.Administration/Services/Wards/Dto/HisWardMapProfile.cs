using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Dto
{
    public class HisWardMapProfile : ShaProfile
    {
        public HisWardMapProfile()
        {
            CreateMap<HisWardInput, HisWard>()
                .ForMember(c => c.Address, options => options.Ignore())
                .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                .ForMember(e => e.OwnerOrganisation, e => e.MapFrom(e => GetEntity<Organisation>(e.OwnerOrganisation)))
                .ForMember(e => e.PartOf, e => e.MapFrom(e => GetEntity<Facility>(e.PartOf)))
               .MapReferenceListValuesFromDto();

            CreateMap<HisWardResponse, HisWard>()
                //.ForMember(e => e.Address, e => e.MapFrom(e => GetEntity<CdmAddress>(e.)))
                .ForMember(c => c.Address, options => options.Ignore())
                .ForMember(e => e.PrimaryContact, e => e.MapFrom(e => GetEntity<Person>(e.PrimaryContact)))
                .ForMember(e => e.OwnerOrganisation, e => e.MapFrom(e => GetEntity<Organisation>(e.OwnerOrganisation)))
                .ForMember(e => e.PartOf, e => e.MapFrom(e => GetEntity<Facility>(e.PartOf)))
                .MapReferenceListValuesFromDto();

            CreateMap<HisWard, HisWardResponse>()
                .ForMember(c => c.PrimaryContact, options => options.MapFrom(c => c.PrimaryContact != null ? new EntityWithDisplayNameDto<Guid?>(c.PrimaryContact.Id, c.PrimaryContact.FullName) : null))
                .ForMember(c => c.OwnerOrganisation, options => options.MapFrom(c => c.OwnerOrganisation != null ? new EntityWithDisplayNameDto<Guid?>(c.OwnerOrganisation.Id, c.OwnerOrganisation.Name) : null))
                .ForMember(c => c.PartOf, options => options.MapFrom(c => c.PartOf != null ? new EntityWithDisplayNameDto<Guid?>(c.PartOf.Id, c.PartOf.Name) : null))
                .MapReferenceListValuesToDto();
        }
    }
}
