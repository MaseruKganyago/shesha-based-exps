using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmAppointment))]
    public class RescheduleInput : EntityDto<Guid>
    {
        /// <summary>
        /// When appointment is to take place.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// The name of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// The cellphone of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public string ContactCellphone { get; set; }
    }
}
