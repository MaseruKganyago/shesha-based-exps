using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Common;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(AdmissionInput))]
    [AutoMapTo(typeof(WardAdmission))]
    public class SeparationInput : EntityDto<Guid>
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

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> SeparationCode { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public EntityWithDisplayNameDto<Guid?> Ward { get; internal set; }
    }
}
