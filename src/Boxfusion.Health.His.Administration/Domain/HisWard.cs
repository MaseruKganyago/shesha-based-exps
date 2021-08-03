using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Administration.Domain
{
    [Entity(TypeShortAlias = "His.HisWard")]
    public class HisWard : Ward
    {
    }
}
