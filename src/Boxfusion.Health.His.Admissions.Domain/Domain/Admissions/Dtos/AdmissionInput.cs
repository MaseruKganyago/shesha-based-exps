using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Common.Admissions;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission))]
    public class AdmissionInput: EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto IdentificationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public string IdentityNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public ReferenceListItemValueDto Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public ReferenceListItemValueDto Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public ReferenceListItemValueDto PatientProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public DateTime StartDateTime { get; set; }

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
        public bool CapturedAfterApproval { get; set; }

        //HospitalAdmission properties
        /// <summary>
        /// 
        /// </summary>
        public string HospitalAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Classification { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto OtherCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> TransferFroHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> TransferToHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Ward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }

        /* Separation Related properties */

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? SeparationDate { get; set; }

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
        ReferenceListItemValueDto Speciality { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual EntityWithDisplayNameDto<Guid?> InternalTransferOriginalWard { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual EntityWithDisplayNameDto<Guid?> InternalTransferDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AgeBreakdown { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGautengGovFacility { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransferToNonGautengHospital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> SeparationCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public EntityWithDisplayNameDto<Guid?> PartOf { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public EntityWithDisplayNameDto<Guid?> Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public EntityWithDisplayNameDto<Guid?> Hospital { get; set; }
	}
}
