using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisPatient")]
    public class HisPatient : CdmPatient
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string PatientMasterIndexNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string HospitalPatientNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "IdentificationTypes")]
        public virtual RefListIdentificationTypes? IdentificationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListProvinces PatientProvince { get; set; }
    }
}
