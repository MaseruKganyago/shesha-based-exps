using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.FacilityPatient")]
    public class FacilityPatient : HisPatient
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string FacilityPatientIdentifier { get; set; }
    }
}
