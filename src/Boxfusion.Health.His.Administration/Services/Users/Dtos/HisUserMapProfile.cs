using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Admissions.Services.Users.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.Authorization.Users;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Users.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class HisUserMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public HisUserMapProfile()
        {
            //Identifier
            CreateMap<IdentifierInput, Identifier>()
                .ForMember(e => e.Assigner, e => e.MapFrom(e => GetEntity<FhirOrganisation>(e.Assigner)))
                .MapReferenceListValuesFromDto();

            CreateMap<Identifier, IdentifierResponse>()
                .ForMember(c => c.Assigner, options => options.MapFrom(c => c.Assigner != null ? new EntityWithDisplayNameDto<Guid?>(c.Assigner.Id, c.Assigner.Name) : null))
                .MapReferenceListValuesToDto();

            //ContactPoint
            CreateMap<ContactPointInput, ContactPoint>()
                .MapReferenceListValuesFromDto();

            CreateMap<ContactPoint, ContactPointResponse>()
                .MapReferenceListValuesToDto();

            //Contacts
            CreateMap<ContactInput, Contact>()
                .ForMember(e => e.Organisation, e => e.MapFrom(e => GetEntity<FhirOrganisation>(e.Organisation)))
                .MapReferenceListValuesFromDto();

            CreateMap<Contact, ContactResponse>()
                .ForMember(c => c.Organisation, options => options.MapFrom(c => c.Organisation != null ? new EntityWithDisplayNameDto<Guid?>(c.Organisation.Id, c.Organisation.Name) : null))
                .MapReferenceListValuesToDto();

            //Returned user
            CreateMap<User, CreateUserDto>()
                .ForMember(c => c.Password, options => options.Ignore())
                .MapReferenceListValuesToDto();

            //Practitioner
            CreateMap<HisUserInput, HisUser>()
            .ForMember(a => a.CommunicationLanguage, options => options.Ignore())
            .ForMember(a => a.IDDocument, options => options.Ignore())
            .ForMember(e => e.PrimaryOrganisation, e => e.MapFrom(e => GetEntity<Organisation>(e.PrimaryOrganisation)))
            .ForMember(e => e.Supervisor, e => e.MapFrom(e => GetEntity<Person>(e.Supervisor)))
            .ForMember(u => u.User, options => options.MapFrom(e => UtilityHelper.SetUser(e.User, e.User.Password, e.Id)))
            .ForMember(u => u.FirstName, options => options.MapFrom(e => e.User.Name))
            .ForMember(u => u.LastName, options => options.MapFrom(e => e.User.Surname))
            .ForMember(u => u.EmailAddress1, options => options.MapFrom(e => e.User.EmailAddress))
            .ForMember(u => u.Initials, options => options.MapFrom(e => UtilityHelper.GetInitials(e.User.Name + " " + e.User.Surname)))
            .MapReferenceListValuesFromDto();

            CreateMap<HisUser, HisUserResponse>()
            .ForMember(u => u.Supervisor, options => options.Ignore())
            .ForMember(u => u.FirstName, options => options.MapFrom(e => e.FirstName))
            .ForMember(u => u.LastName, options => options.MapFrom(e => e.LastName))
            .ForMember(u => u.EmailAddress, options => options.MapFrom(e => e.EmailAddress1))
            .ForMember(u => u.MobileNumber, options => options.MapFrom(e => e.MobileNumber))
            .ForMember(u => u.Initials, options => options.MapFrom(e => e.Initials))
            .ForMember(c => c.PrimaryOrganisation, options => options.MapFrom(c => c.PrimaryOrganisation != null ? new EntityWithDisplayNameDto<Guid?>(c.PrimaryOrganisation.Id, c.PrimaryOrganisation.Name) : null))
            .ForMember(c => c.Supervisor, options => options.MapFrom(c => c.Supervisor != null ? new EntityWithDisplayNameDto<Guid?>(c.Supervisor.Id, c.Supervisor.FullName) : null))
            .MapReferenceListValuesToDto();

            //Address
            CreateMap<CdmAddressInput, CdmAddress>()
                .ForMember(u => u.Use, options => options.Ignore())
                .ForMember(u => u.Type, options => options.Ignore())
                .MapReferenceListValuesFromDto();

            CreateMap<CdmAddress, CdmAddressResponse>()
                .ForMember(u => u.Use, options => options.Ignore())
                .ForMember(u => u.Type, options => options.Ignore())
                .MapReferenceListValuesFromDto();

            CreateMap<HisUser, CdmAddress>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Type, options => options.Ignore())
                .ForMember(c => c.Latitude, options => options.Ignore())
                .ForMember(c => c.Longitude, options => options.Ignore())
                .ForMember(c => c.OwnerId, options => options.MapFrom(c => c.Id.ToString()))
                .ForMember(c => c.OwnerType, options => options.MapFrom(c => c.GetTypeShortAlias()))
                .MapReferenceListValuesFromDto();

            CreateMap<ShaRoleAppointedPerson, EntityWithDisplayNameDto<Guid?>>()
                .ForMember(u => u.Id, options => options.MapFrom(c => c.Id))
                .ForMember(u => u.DisplayText, options => options.MapFrom(c => c.Role.Name))
                .MapReferenceListValuesFromDto();
        }
    }
}
