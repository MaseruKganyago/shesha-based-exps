using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(FhirOrganisation))]
    public class OrganisationInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShortAlias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FreeTextAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto OrganisationType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TenantId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyRegistrationNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VatRegistrationNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CdmAddressInput PrimaryAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> PrimaryContact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryContactEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryContactTelephone { get; set; }
    }
}