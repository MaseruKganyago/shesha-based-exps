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
	[AutoMap(typeof(Patient))]
	public class PatientInput: PersonFhirBaseInput
	{
        /// <summary>
        /// 
        /// </summary>
        public string OtherIdentityNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool MultipleBirthBoolean { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? MultipleBirthInteger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool DeceasedBoolean { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeceasedDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto MaritalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralPractitioner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> LinkToOtherPatient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReferenceListItemValueDto TypeOfLinkToOtherPatient { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<ContactInput> Contacts { get; set; }
    }
}
