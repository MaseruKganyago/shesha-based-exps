using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.CdmAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmAppointment))]
    public class CancelAppointmentInput : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid> Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid> Practitioner { get; set; }

        /// <summary>
        /// The time the client registered as arrived at the facility/in the queue.
        /// </summary>
        public DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// A reference number issued to the patient.
        /// </summary>
        public string RefNumber { get; set; }

        /// <summary>
        /// The name of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// The cellphone of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public string ContactCellphone { get; set; }

        /// <summary>
        /// The ticket number issued to the client upon arrival (could be linked to a physical ticket issued at the facility so they can easily be called)
        /// </summary>
        public string IssuedTicketNumber { get; set; }

        /// <summary>
        /// Indicates the queue position within the Queue/slot
        /// </summary>
        public double? QueuePosition { get; set; }

        /// <summary>
        /// Allows repriritising within the queue regardless of queue position. The higher the better.
        /// </summary>
        public int? QueuePriority { get; set; }

        /// <summary>
        /// If the client dropped out of the queue whilst waiting to be serviced, specifies the time he did so.
        /// </summary>
        public DateTime? DropOutTime { get; set; }

        /// <summary>
        /// The first time the client was called to be seen.
        /// </summary>
        public DateTime? FirstTimeCalled { get; set; }

        /// <summary>
        /// The last time the client was called to be seen.
        /// </summary>
        public DateTime? LastTimeCalled { get; set; }

        /// <summary>
        /// The number of times the client was called to be seen.
        /// </summary>
        public int? NumTimesCalled { get; set; }

        /// <summary>
        /// The time the appointment was fulfilled i.e. appointment with practioner initiated.
        /// </summary>
        public DateTime? FulfilledTime { get; set; }

        /// <summary>
        /// The duration between arrival time (or start time if later) and the FirstCalledTime
        /// </summary>
        public TimeSpan? WaitingTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AlternateContactName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AlternateContactCellphone { get; set; }
    }
}
