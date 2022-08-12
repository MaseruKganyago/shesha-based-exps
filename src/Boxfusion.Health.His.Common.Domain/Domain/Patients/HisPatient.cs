using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Boxfusion.Health.Cdm.Patients;

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
        [ReferenceList("His", "Provinces")]
        public virtual long? PatientProvince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string HospitalPatientNumber { get; set; }
    }
}
