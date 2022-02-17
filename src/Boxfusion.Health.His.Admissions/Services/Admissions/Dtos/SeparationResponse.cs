using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(WardAdmission))]
    [AutoMapTo(typeof(AdmissionResponse))]
    public class SeparationResponse : EntityDto<Guid>
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
        public EntityWithDisplayNameDto<Guid?> InternalTransferOriginalWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> InternalTransferDestinationWard { get; set; }
        

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

//using Abp.Application.Services.Dto;
//using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
//using System;

//namespace Boxfusion.Health.His.Admissions.Services.Separations.Dto
//{
///// <summary>
///// 
///// </summary>
//public class SeparationResponse : EntityDto<Guid?>
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    // public HisPatientResponse Patient { get; set; }

//    /// <summary>
//    /// 
//    /// </summary>
//    // public WardAdmissionResponse WardAdmission { get; set; }

//    // <summary>
//    /// 
//    /// </summary>
//    // public WardAdmissionResponse DestinationWardAdmission { get; set; }

//    /// <summary>
//    /// 
//    /// </summary>
//    public AdmissionResponse HospitalAdmission { get; set; }
//}
//}
