using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Bookings.Domain.Views;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(FlattenedAppointments))]
    public class FlattenedAppointmentDto : EntityDto<Guid>
    {
        /// <summary>
        /// A reference number issued to the patient.
        /// </summary>
        public virtual string RefNumber { get; set; }

        /// <summary>
        /// When appointment is to take place.
        /// </summary>
        public virtual DateTime? Start { get; set; }

        /// <summary>
        /// The style of appointment or patient that has been booked in the slot (not service type)
        /// </summary>
        public virtual ReferenceListItemValueDto AppointmentType { get; set; }

        /// <summary>
        /// proposed | pending | booked | arrived | fulfilled | cancelled | noshow | entered-in-error | checked-in | waitlist
        /// </summary>
        public virtual ReferenceListItemValueDto Status { get; set; }

        /// <summary>
        /// A reference number issued to the patient.
        /// </summary>
        public virtual string PatientFileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string IDNumberPassportNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ContactNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Schedule { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? TotalCount { get; set; }
    }
}
