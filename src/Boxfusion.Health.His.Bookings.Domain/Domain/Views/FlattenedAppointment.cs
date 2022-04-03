﻿using Abp.Application.Services.Dto;
using Shesha.AutoMapper.Dto;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Domain.Views
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Obsolete("Replaced by FlattenedFacilityAppointment. Remove as soon as able to take away the custom view/control for Appointment book")]
    public class FlattenedAppointment : EntityDto<Guid>
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
        public virtual long? AppointmentType { get; set; }

        /// <summary>
        /// proposed | pending | booked | arrived | fulfilled | cancelled | noshow | entered-in-error | checked-in | waitlist
        /// </summary>
        public virtual long? Status { get; set; }

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
        public virtual int TotalCount { get; set; }
    }
}