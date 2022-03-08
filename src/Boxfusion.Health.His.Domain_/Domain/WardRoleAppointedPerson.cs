using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class WardRoleAppointedPerson : ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual HisWard Ward { get; set; }
    }
}
