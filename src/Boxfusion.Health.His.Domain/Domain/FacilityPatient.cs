using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.FacilityPatient")]
    public class FacilityPatient : HisPatient
    {
        public virtual string FacilityPatientIdentifier { get; set; }
    }
}
