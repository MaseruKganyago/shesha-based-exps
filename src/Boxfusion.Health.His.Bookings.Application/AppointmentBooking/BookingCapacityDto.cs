using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.AppointmentBooking
{
    public class BookingCapacityDto
    {
        public virtual Guid? ScheduleId { get; set; }

        /// <summary>
        /// Date/Time that the slot is to begin.
        /// </summary>
        public virtual DateTime? StartDateTime { get; set; }

        /// <summary>
        /// Date/Time that the slot is to conclude.
        /// </summary>
        public virtual DateTime? EndDateTime { get; set; }

        /// <summary>
        /// The number of Appointments allowed to be booked against this Slot.
        /// </summary>
        public virtual int? Capacity { get; set; }

        /// <summary>
        /// The number of 'Overflow' Appointments allowed to be booked against this Slot.
        /// </summary>
        public virtual int? OverflowCapacity { get; set; }

        /// <summary>
        /// The total number of valid bookings which have been made against this slot. (Calculated DB Column)
        /// </summary>
        public virtual int NumValidAppointments { get; set; }

        /// <summary>
        /// The Regular capacity still available to be booked i.e. excluding Overflow capacity.
        /// </summary>
        public virtual int RemainingRegularCapacity
        {
            get
            {
                return (NumValidAppointments >= Capacity) ? 0 : (Capacity ?? 0) - NumValidAppointments;
            }
        }

        /// <summary>
        /// Total capacity still available to be booked inclduing both Regular and Overflow
        /// </summary>
        public virtual int RemainingCapacity
        {
            get
            {
                return (Capacity ?? 0) + (OverflowCapacity ?? 0) - NumValidAppointments;
            }
        }
    }

}