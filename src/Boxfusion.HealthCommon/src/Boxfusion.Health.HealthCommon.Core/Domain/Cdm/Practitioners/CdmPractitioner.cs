using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Cdm.Practitioners
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmPractitioner")]
    public class CdmPractitioner : Practitioner
    {
        /// <summary>
        /// 
        /// </summary>

        public virtual RefListPractitionerRoles? PrimaryPractitionerRole { get; set; }
    }
}
