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
    public class HospitalRoleAppointedPerson : ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Hospital Hospital { get; set; }
    }
}
