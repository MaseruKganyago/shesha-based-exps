using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;

namespace Boxfusion.Health.His.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMapFrom(typeof(WardAdmission))]
    public class WardAdmissionResponse : HisAdmissionResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string WardAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto TransferRejectionReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransferRejectionReasonComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto SeparationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> AdmissionDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> SeparationDestinationWard { get; set; }

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
        public bool CapturedAfterApproval { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public ReferenceListItemValueDto Speciality { get; set; }

        //public virtual HisAdmission HisAdmission { get; set; }
        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual WardAdmission InternalTransferOriginalWard { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual WardAdmission InternalTransferDestinationWard { get; set; }
    }
}
