using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
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
    [AutoMap(typeof(Hospital))]
    public class LocationResponse : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto FacilityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CdmAddressResponse Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> PrimaryContact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> OwnerOrganisation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Altitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> PartOf { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto OperationalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Mode { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PhysicalType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvailabilityExceptions { get; set; }
    }
}
