using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Services.HisPatients.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(HisPatient))]
    public class HisPatientInput : NonUserCdmPatientInput
    {
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

        ///// <summary>
        ///// 
        ///// </summary>
        //public string IdentityNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto PatientProvince { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public DateTime? DateOfBirth { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ReferenceListItemValueDto Gender { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string FirstName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string LastName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ReferenceListItemValueDto Nationality { get; set; }
    }
}
