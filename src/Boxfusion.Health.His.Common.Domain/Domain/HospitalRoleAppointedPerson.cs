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
    public class HospitalRoleAppointedPerson : ShaRoleAppointedPerson
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual HisHospital Hospital { get; set; }
    }
}
