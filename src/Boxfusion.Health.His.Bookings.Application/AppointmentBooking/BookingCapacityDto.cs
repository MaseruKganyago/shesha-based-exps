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
        public virtual int? RegularCapacity { get; set; }

        /// <summary>
        /// The number of 'Overflow' Appointments allowed to be booked against this Slot.
        /// </summary>
        public virtual int? OverflowCapacity { get; set; }

        /// <summary>
        /// The total capacity for this Slot or Day taking into account both Regular and Overflow capacity.
        /// </summary>
        public virtual int TotalCapacity
        {
            get
            {
                return (RegularCapacity ?? 0) + (OverflowCapacity ?? 0);
            }
        }

        /// <summary>
        /// The total number of valid bookings which have been made against this slot. (Calculated DB Column)
        /// </summary>
        public virtual int NumAppointments { get; set; }

        /// <summary>
        /// The Regular capacity still available to be booked i.e. excluding Overflow capacity.
        /// </summary>
        public virtual int RemainingRegularCapacity
        {
            get
            {
                return (NumAppointments >= RegularCapacity) ? 0 : (RegularCapacity ?? 0) - NumAppointments;
            }
        }

        /// <summary>
        /// The Overflow capacity still available to be booked i.e. excluding Overflow capacity.
        /// </summary>
        public virtual int RemainingOverflowCapacity
        {
            get
            {
                if ((OverflowCapacity ?? 0) == 0)
                    return 0;
                else if (NumAppointments <= RegularCapacity)
                    return OverflowCapacity ?? 0;
                else
                    return TotalCapacity - NumAppointments;
            }
        }

        /// <summary>
        /// Total capacity still available to be booked inclduing both Regular and Overflow
        /// </summary>
        public virtual int RemainingCapacity
        {
            get
            {
                return (RegularCapacity ?? 0) + (OverflowCapacity ?? 0) - NumAppointments;
            }
        }
    }

}