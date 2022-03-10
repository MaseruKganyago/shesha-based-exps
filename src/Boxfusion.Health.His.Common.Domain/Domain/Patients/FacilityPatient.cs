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
    [DiscriminatorValue("His.HisPatient")]
    [Discriminator]
    public class FacilityPatient : HisPatient
    {
        /// <summary>
        /// 
        /// </summary>
        [ReadonlyProperty]
        public virtual string FacilityPatientIdentifier { get; set; }
    }
}
