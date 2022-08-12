using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Practitioners;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Cdm.Appointments
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmAppointment")]
    [Table("Fhir_Appointments")]
    public class CdmAppointment : Appointment
    {

        /// <summary>
        /// Returns the schedule that the slot is booked against.
        /// A bit redundant but added as front-end found it easier to get ScheduleId immediately
        /// </summary>
        [NotMapped]
        public virtual Schedule Schedule
        {
            get
            {
                if (this.Slot is null)
                    return null;
                else
                    return Slot.Schedule;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual CdmPatient Patient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CdmPractitioner Practitioner { get; set; }

        /// <summary>
        /// The time the client registered as arrived at the facility/in the queue.
        /// </summary>
        public virtual DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// A reference number issued to the patient.
        /// </summary>
        public virtual string RefNumber { get; set; }

        /// <summary>
        /// The name of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public virtual string ContactName { get; set; }

        /// <summary>
        /// The cellphone of the contact person in case they are organising on behalf of the patient.
        /// </summary>
        public virtual string ContactCellphone { get; set; }

        /// <summary>
        /// The ticket number issued to the client upon arrival (could be linked to a physical ticket issued at the facility so they can easily be called)
        /// </summary>
        public virtual string IssuedTicketNumber { get; set; }

        /// <summary>
        /// Indicates the queue position within the Queue/slot
        /// </summary>
        public virtual double? QueuePosition { get; set; }

        /// <summary>
        /// Allows repriritising within the queue regardless of queue position. The higher the better.
        /// </summary>
        public virtual int? QueuePriority { get; set; }

        /// <summary>
        /// If the client dropped out of the queue whilst waiting to be serviced, specifies the time he did so.
        /// </summary>
        public virtual DateTime? DropOutTime { get; set; }

        /// <summary>
        /// The first time the client was called to be seen.
        /// </summary>
        public virtual DateTime? FirstTimeCalled { get; set; }

        /// <summary>
        /// The last time the client was called to be seen.
        /// </summary>
        public virtual DateTime? LastTimeCalled { get; set; }

        /// <summary>
        /// The number of times the client was called to be seen.
        /// </summary>
        public virtual int? NumTimesCalled { get; set; }

        /// <summary>
        /// The time the appointment was fulfilled i.e. appointment with practioner initiated.
        /// </summary>
        public virtual DateTime? FulfilledTime { get; set; }

        /// <summary>
        /// The duration between arrival time (or start time if later) and the FirstCalledTime
        /// </summary>
        public virtual TimeSpan? WaitingTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AlternateContactName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string AlternateContactCellphone { get; set; }

        /// <summary>
        /// This field is used as a flag for when the person has been reminded that they have a 
        /// booking set for the following day. This way, there's no duplication of notifications.
        /// </summary>
        public virtual bool? HasReminderBeenSent { get; set; }
    }
}
