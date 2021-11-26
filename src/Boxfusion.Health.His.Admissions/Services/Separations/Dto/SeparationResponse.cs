using Abp.Application.Services.Dto;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Dtos;
using System;

namespace Boxfusion.Health.His.Admissions.Services.Separations.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SeparationResponse : EntityDto<Guid?>
    {
        /// <summary>
        /// 
        /// </summary>
        public HisPatientResponse Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WardAdmissionResponse WardAdmission { get; set; }

        // <summary>
        /// 
        /// </summary>
        public WardAdmissionResponse DestinationWardAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AdmissionResponse HospitalAdmission { get; set; }
    }
}
