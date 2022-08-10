using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using Shesha.NHibernate;
using Shesha.NHibernate.Session;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// Base class for schedule availability (capacity) observing a Booking based (as opposed to Walk-in based) booking model.
    /// </summary>
    [Entity(TypeShortAlias = "Cdm.ScheduleAvailabilityForBookingBase", GenerateApplicationService = false)]
    //[Table("Fhir_ScheduleAvailabilities")]
    //[DiscriminatorValue("Cdm.ScheduleAvailForBookingBase")]
    public class ScheduleAvailabilityForBookingBase : ScheduleAvailability, IValidatableObject
    {

        /// <summary>
        /// Number of simultaneous Appointments that can be made against a slot.
        /// </summary>
        public virtual int? SlotRegularCapacity { get; set; }

        /// <summary>
        /// Number of simultaneous Overflow (i.e. Emergency) Appointments that can be made against a slot.
        /// </summary>
        public virtual int? SlotOverflowCapacity { get; set; }

        /// <summary>
        /// Number of days ahead of time that a user may be able to book an appointment.
        /// </summary>
        public virtual int? BookingHorizon { get; set; }

        /// <summary>
        /// Specifies how slots will be generated. (One slot per resource, One slot for all resources)
        /// </summary>
        public virtual RefListSlotGenerationModes? SlotGenerationMode { get; set; }


        /// <inheritdoc />
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // If user is updating an existing entity, checking to ensure that not trying to set Active = false whilst there are still pending appointments.
            if (!this.IsTransient() && !this.Active)
            {
                // Checking if Active property was changed now
                var sessionProvider = StaticContext.IocManager.Resolve<ISessionProvider>();
                var dirtyProperties = sessionProvider.Session.GetDirtyProperties(this);
                var activeProp = dirtyProperties.Find(p => p.Name == nameof(Active));

                if (activeProp != null)
                {
                    var numPendingAppointments = GetNumPendingAppointments();

                    if (numPendingAppointments > 0)
                        yield return new ValidationResult("Cannot set make a schedule availability to inactive if there are any unfulfilled appointments still pending.");
                }
            }

            yield return null;
        }

        /// <summary>
        /// Returns the number of Pending appointments (appointment which have been booked but are yet to be fullfiled including proposed and waitlisted) for this schedule.
        /// </summary>
        /// <returns></returns>
        public int GetNumPendingAppointments()
        {
            var appointsRepo = StaticContext.IocManager.Resolve<IRepository<Appointment, Guid>>();

            return appointsRepo.Count(app => ((CdmSlot)app.Slot).IsGeneratedFrom.Id == this.Id
                    && (app.Status == RefListAppointmentStatuses.booked
                    || app.Status == RefListAppointmentStatuses.pending
                    || app.Status == RefListAppointmentStatuses.arrived
                    || app.Status == RefListAppointmentStatuses.checkedIn
                    || app.Status == RefListAppointmentStatuses.proposed
                    || app.Status == RefListAppointmentStatuses.waitlist));
        }

    }
}
