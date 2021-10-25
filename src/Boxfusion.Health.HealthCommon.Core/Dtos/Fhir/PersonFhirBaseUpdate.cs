using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.StoredFiles.Dto;
using Shesha.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
	[AutoMap(typeof(PersonFhirBase))]
    public class PersonFhirBaseUpdate : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserDto User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CdmAddressInput Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IdentifierInput> Identifiers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ContactPointInput> ContactPoints { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ContactInput> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PermitNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ReferenceListItemValueDto> CommunicationLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StoredFileDto IDDocument { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto IdentityVerificationStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Ethnicity { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public string IdentityNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsMobileVerified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SecurityPin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Supervisor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StoredFile Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> PrimaryOrganisation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? PreferredContactMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid>> Roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<HospitalInput> Hospitals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<WardInput> Wards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSupervisor { get; set; }
    }
}
