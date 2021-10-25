using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmPatient))]
    public class CdmPatientInput : PatientInput
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsDisabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmployed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HasMedicalAid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedicalAidName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedicalAidNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePin { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public CdmAddressInput Address { get; set; }
    }
}
