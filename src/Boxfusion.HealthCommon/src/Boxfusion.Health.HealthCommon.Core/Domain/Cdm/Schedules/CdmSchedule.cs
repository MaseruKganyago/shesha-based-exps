using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Slots;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Microsoft.Extensions.DependencyInjection;
using Shesha.Domain.Attributes;
using Shesha.Authorization.Users;
using Shesha.NHibernate;
using Shesha.NHibernate.Session;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.Cdm.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.CdmSchedule")]
    [Table("Fhir_Schedules")]
    public class CdmSchedule: Schedule, IValidatableObject
    {
        /// <summary>
        /// In cases where a practioner is able to pick appointments from multiple Queues/Schedules, specifies the order in which they should be given preference. Highest is best.
        /// </summary>

        public virtual int? PrioritisationIndex { get; set; }

        /// <summary>
        /// Specifies what type of schedule is followed: Walk-In or Appointment.
        /// </summary>
        [ReferenceList("Cdm", "SchedulingModels")]
        public virtual RefListSchedulingModels? SchedulingModel { get; set; }

        [NotMapped]
        public virtual string CreatedBy
        {
            get
            {
                return GetCreatedByUserName(CreatorUserId);
            }

            set
            {
                GetCreatedByUserName(CreatorUserId);
            }
        }

        public override string ToString()
        {
            return Name;
        }

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
                        yield return new ValidationResult("Cannot set make a schedule inactive if there are any unfulfilled appointments still pending.");
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
            
            return appointsRepo.Count(app => app.Slot.Schedule.Id == this.Id
                    && (app.Status == RefListAppointmentStatuses.booked
                    || app.Status == RefListAppointmentStatuses.pending
                    || app.Status == RefListAppointmentStatuses.arrived
                    || app.Status == RefListAppointmentStatuses.checkedIn
                    || app.Status == RefListAppointmentStatuses.proposed
                    || app.Status == RefListAppointmentStatuses.waitlist));
        }

        public string GetCreatedByUserName(long? id)
        {
            var usersRepo = StaticContext.IocManager.Resolve<IRepository<User, long>>();

            var user = usersRepo.Get(id.Value);

            return user.UserName;
        }

    }
}
