using Abp.AutoMapper;
using Boxfusion.Health.His.Administration.Services.HisPatients.Dtos;
using Boxfusion.Health.His.Domain.Domain;
using Boxfusion.Health.His.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(FacilityPatient))]
    public class FacilityPatientsInput : HisPatientInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string FacilityPatientIdentifier { get; set; }
    }
}
