using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// Clinic facility inherits from Shesha facility
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Clinic")]
    public class Clinic : Facility
    {

    }
}
