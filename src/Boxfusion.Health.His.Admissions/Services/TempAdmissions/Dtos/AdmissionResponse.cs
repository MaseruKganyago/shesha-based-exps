using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission))]
    public class AdmissionResponse : HospitalisationEncounterResponse
    {
        //Ward: Ward(rather use Encounter.Location)
        /// <summary>
        /// 
        /// </summary>
        public string WardAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto HospitalAdmissionStatus { get; set; }

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

        //Patient properties
        /// <summary>
        /// 
        /// </summary>
        public string PatientMasterIndexNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalPatientNumber { get; set; }

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
        public ReferenceListItemValueDto PatientProvince { get; set; }

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
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto Nationality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Ward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EntityWithDisplayNameDto<Guid?>> SeparationCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> HisAdmission { get; set; }


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
        public ReferenceListItemValueDto Speciality { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> InternalTransferOriginalWard { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> InternalTransferDestinationWard { get; set; }

        // <summary>
        /// 
        /// </summary>
        public string AgeBreakdown { get; set; }
    }
}
