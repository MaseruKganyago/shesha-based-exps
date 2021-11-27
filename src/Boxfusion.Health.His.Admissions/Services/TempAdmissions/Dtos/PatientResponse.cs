using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using System.Collections.Generic;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class PatientResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public HisPatient Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IcdTenCode> IcdTenCodes { get; set; }
    }
}
