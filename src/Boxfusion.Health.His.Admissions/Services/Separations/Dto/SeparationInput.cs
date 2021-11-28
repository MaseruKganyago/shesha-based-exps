using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Dto
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission), typeof(HospitalAdmission))]
    public class SeparationInput : HospitalisationEncounterInput
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? SeparationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto SeparationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> SeparationDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> TransferToHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransferToNonGautengHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto SeparationChildHealth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SeparationComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGautengGovFacility { get; set; }
        public EntityWithDisplayNameDto<Guid?> Ward { get; internal set; }
    }
}
