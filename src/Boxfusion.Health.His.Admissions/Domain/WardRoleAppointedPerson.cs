using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain
{
    [Entity(TypeShortAlias = "His.WardRoleAppointedPerson")]
    public class WardRoleAppointedPerson : ShaRoleAppointedPerson
    {
        public virtual Ward Ward { get; set; }
    }
}
