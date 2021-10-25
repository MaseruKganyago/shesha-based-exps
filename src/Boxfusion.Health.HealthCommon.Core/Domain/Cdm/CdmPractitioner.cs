using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
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
