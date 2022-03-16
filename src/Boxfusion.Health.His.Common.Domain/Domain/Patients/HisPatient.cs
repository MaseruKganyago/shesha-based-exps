using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Patients
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
        [ReferenceList("His", "IdentificationTypes")]
        public virtual long? IdentificationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "Provinces")]
        public virtual long? PatientProvince { get; set; }
    }
}
