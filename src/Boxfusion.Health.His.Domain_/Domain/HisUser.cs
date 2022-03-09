using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisUser")]
    public class HisUser : PersonFhirBase
    {
    }
}
