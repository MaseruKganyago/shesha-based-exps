using Boxfusion.Health.Cdm.Schedules;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.Cdm.Slots
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmSlot")]
    [Table("Fhir_Slots")]
    public class CdmSlot : Slot
    {
        /// <summary>
        /// The ScheduleAvailability from which the Slot was generated.
        /// </summary>
        public virtual ScheduleAvailability IsGeneratedFrom { get; set; }

        /// <summary>
        /// The number of Appointments allowed to be booked against this Slot.
        /// </summary>
        public virtual int? RegularCapacity { get; set; }

        /// <summary>
        /// The number of 'Overflow' Appointments allowed to be booked against this Slot.
        /// </summary>
        public virtual int? OverflowCapacity { get; set; }

        /// <summary>
        /// The total capacity available for this Slot or Day taking into account both Regular and Overflow capacity.
        /// </summary>
        [NotMapped]
        public virtual int TotalCapacity
        {
            get
            {
                return RegularCapacity ?? 0 + OverflowCapacity ?? 0;
            }
        }

        /// <summary>
        /// The total number of valid bookings which have been made against this slot. (Calculated DB Column)
        /// </summary>
        [ReadonlyProperty]
        public virtual int NumValidAppointments { get; protected set; }

        /// <summary>
        /// The Regular capacity still available to be booked i.e. excluding Overflow capacity.
        /// </summary>
        [NotMapped]
        public virtual int RemainingRegularCapacity
        {
            get
            {
                return (NumValidAppointments >= RegularCapacity) ? 0 : (RegularCapacity ?? 0) - NumValidAppointments;
            }
        }

        /// <summary>
        /// The Overflow capacity still available to be booked i.e. excluding Overflow capacity.
        /// </summary>
        [NotMapped]
        public virtual int RemainingOverflowCapacity
        {
            get
            {
                if ((OverflowCapacity ?? 0) == 0)
                    return 0;
                else if (NumValidAppointments <= RegularCapacity)
                    return OverflowCapacity ?? 0;
                else
                    return TotalCapacity - NumValidAppointments;
            }
        }

        /// <summary>
        /// Total capacity still available to be booked inclduing both Regular and Overflow
        /// </summary>
        [ReadonlyProperty]
        public virtual int RemainingCapacity { get; set; }
    }
}
