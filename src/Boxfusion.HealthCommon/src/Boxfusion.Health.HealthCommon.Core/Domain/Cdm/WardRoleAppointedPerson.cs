using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    public class WardRoleAppointedPerson : ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Ward Ward { get; set; }
    }
}
