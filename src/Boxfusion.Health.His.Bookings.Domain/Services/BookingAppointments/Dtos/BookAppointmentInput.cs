using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmAppointment))]
    public class BookAppointmentInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Schedule { get; set; }

        /// <summary>
        /// When appointment is to take place.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// The style of appointment or patient that has been booked in the slot (not service type)
        /// </summary>
        public ReferenceListItemValueDto AppointmentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Patient { get; set; }

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
