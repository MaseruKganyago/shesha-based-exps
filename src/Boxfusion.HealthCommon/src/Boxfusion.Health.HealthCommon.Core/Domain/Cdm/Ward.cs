using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Ward")]
    public class Ward : FhirLocation
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListWardSpecialities? Speciality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? NumberOfBeds { get; set; }
    }
}
