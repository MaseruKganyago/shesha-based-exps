using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.Patients.Dto
{
	/// <summary>
	/// 
	/// </summary>
	public class PatientMapProfile: ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public PatientMapProfile()
		{
            CreateMap<CdmPatientInput, CdmPatient>()
                .ForMember(a => a.CommunicationLanguage, options => options.Ignore())
                .ForMember(a => a.LinkToOtherPatient, options => options.MapFrom(b => GetEntity<Patient>(b.LinkToOtherPatient)))
                .ForMember(a => a.IDDocument, options => options.Ignore());

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
        }
	}
}
