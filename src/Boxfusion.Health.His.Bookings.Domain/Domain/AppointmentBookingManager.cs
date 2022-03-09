using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain
{
    /// <summary>
    /// Domain Service for managing Appointments specifically where they belong to schedules
    /// where Schedule.SchedulingModel is Appointment Booking.
    /// </summary>
    public class AppointmentBookingManager : DomainService
    {
        private readonly IRepository<CdmSchedule, Guid> _scheduleRepo;
        private readonly IRepository<CdmSlot, Guid> _slotRepo;
        private readonly IRepository<CdmAppointment, Guid> _appointmentRepo;
        private readonly IRepository<HisPatient, Guid> _patientRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        public AppointmentBookingManager(IRepository<CdmSchedule, Guid> schedulesRepo,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailabilityRepo,
            IRepository<CdmSlot, Guid> slotsRepo,
            IRepository<CdmAppointment, Guid> appointmentsRepo,
            IRepository<CdmSchedule, Guid> scheduleRepo,
            IRepository<HisPatient, Guid> patientRepo
            )
        {
            _slotRepo = slotsRepo;
            _appointmentRepo = appointmentsRepo;
            _scheduleRepo = scheduleRepo;
            _patientRepo = patientRepo;
        }

        /// <summary>
        /// Creates a new Appointment to book the first available Slot for the specified schedule and requestedTime.
        /// </summary>
        /// <returns>Returns the appointment created to book the requested time. Will return null if a slot at that time was not found.</returns>
        public async Task<CdmAppointment> BookAvailableSlotAsync(Guid scheduleId,
                                                                DateTime requiredTime,
                                                                long? appointmentType,
                                                                Guid? patientId,
                                                                string contactName,
                                                                string contactCellphone)
        {
            if (requiredTime < DateTime.Now.Date) throw new ArgumentOutOfRangeException("requiredTime", "Cannot request to book an appointment in the past.");

            var slot = await FindAvailableBookingSlot(scheduleId, requiredTime);

            if (slot is null)
                return null;

            var schedule = await _scheduleRepo.GetAsync(scheduleId);
            if (!schedule.Active)
                throw new InvalidOperationException("Cannot book an appointment for the specified Schedule as it is inactive.");

            HisPatient patient = null;
            if (patientId.HasValue)
                patient = await _patientRepo.GetAsync(patientId.Value);

            // Completing the booking
            var appointment = new CdmAppointment()
            {
                Status = RefListAppointmentStatuses.booked,
                ContactCellphone = contactCellphone,
                ContactName = contactName,
                Patient = patient,
                AppointmentType = appointmentType,
            };

            return await BookAvailableSlotAsync(scheduleId, appointment);

        }

        /// <summary>
        /// Creates a new Appointment to book the first available Slot for the specified schedule and requestedTime.
        /// </summary>
        public async Task<CdmAppointment> BookAvailableSlotAsync(Guid scheduleId, CdmAppointment appointment)
        {
            if (!appointment.Start.HasValue) throw new ArgumentNullException("Appointment Start Time", "Appointment Start Time must be specified.");
            if (appointment.Start < DateTime.Now.Date) throw new ArgumentOutOfRangeException("Appointment Start Time", "Cannot request to book an appointment in the past.");
            //if (appointment.Patient is null) throw new ArgumentNullException("Patient", "Patient must be specified.");
            if (!appointment.IsTransient()) throw new InvalidOperationException("Can only be performed for a new appointment, not on a pre-existing one.");

            var schedule = await _scheduleRepo.GetAsync(scheduleId);
            if (!schedule.Active)
                throw new InvalidOperationException("Cannot book an appointment for the specified Schedule as it is inactive.");

            var slot = await FindAvailableBookingSlot(scheduleId, appointment.Start.Value);

            if (slot is null)
                return null;

            //Completing the booking
            appointment.Status = RefListAppointmentStatuses.booked;
            appointment.Slot = slot;
            if (appointment.Patient is not null)
            {
                // Defaulting appointment contact details to patient contact information if it has not been populated
                if (string.IsNullOrWhiteSpace(appointment.ContactName))
                    appointment.ContactName = appointment.Patient.FullName;

                if (string.IsNullOrWhiteSpace(appointment.ContactCellphone))
                    appointment.ContactCellphone = appointment.Patient.MobileNumber;
            }
            appointment.Start = slot.StartDateTime;
            appointment.End = slot.EndDateTime;
            appointment.MinutesDuration = (slot.EndDateTime.Value - slot.StartDateTime.Value).Minutes;
            appointment.Priority = 2;
            //ReasonCode
            appointment.ServiceCategory = slot.ServiceCategory;
            appointment.ServiceType = slot.ServiceType ?? schedule.ServiceType;
            appointment.Speciality = slot.Speciality ?? schedule.Speciality;

            var res = await _appointmentRepo.InsertAsync(appointment);

            return res;
        }


        /// <summary>
        /// Returns the first Available booking slot within the specified Schedule for the specified time and SlotType
        /// </summary>
        /// <returns>Returns the first slot found, otherwise returns null.</returns>
        public async Task<CdmSlot> FindAvailableBookingSlot(Guid scheduleId,
                                                        DateTime requiredTime)
        {
            var slot = await _slotRepo.FirstOrDefaultAsync(e =>
                e.Schedule.Id == scheduleId
                && e.Schedule.Active == true
                && e.IsGeneratedFrom.Active == true
                && e.StartDateTime <= requiredTime && e.EndDateTime > requiredTime
                && e.NumValidAppointments < (e.Capacity ?? 0 + e.OverflowCapacity ?? 0));

            return slot;
        }


        /// <summary>
        /// Returns a list of all Slots with available capacity that start and end between the specified dates
        /// and for the specified Schedule.
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="slotType"></param>
        /// <param name="fromDateTime"></param>
        /// <param name="toDateTime"></param>
        /// <returns></returns>
        public async Task<List<CdmSlot>> GetAllAvailableBookingSlotsAsync(Guid scheduleId,
                                                DateTime fromDateTime,
                                                DateTime toDateTime)
        {
            var schedule = await _scheduleRepo.GetAsync(scheduleId);

            if (!schedule.Active) throw new ArgumentOutOfRangeException("schedule.Active", "Schedule must be active.");

            var slots = _slotRepo.GetAll().Where(e =>
                e.Schedule.Id == schedule.Id
                && e.IsGeneratedFrom.Active == true
                //&& e.CapacityType == slotType
                && e.StartDateTime >= fromDateTime && e.EndDateTime <= toDateTime
                && e.NumValidAppointments < (e.Capacity + e.OverflowCapacity))
                .OrderBy(e => e.StartDateTime)
                .ToList();

            // Have to do the Distinct operation here as NHibernate does not support that operator.
            var distinctSlots = slots.AsQueryable().Distinct(new AvailableSlotComparer()).ToList();

            return distinctSlots;
        }


        private class AvailableSlotComparer : IEqualityComparer<CdmSlot>
        {
            public bool Equals(CdmSlot b1, CdmSlot b2)
            {
                return (b1.StartDateTime == b2.StartDateTime
                    && b1.RemainingCapacity > 0
                    && b2.RemainingCapacity > 0) ;
            }

            public int GetHashCode([DisallowNull] CdmSlot obj)
            {
                return (obj.StartDateTime.ToString() + 
                    (obj.RemainingCapacity > 0).ToString()
                    ).GetHashCode();
            }
        }

        /// <summary>
        /// Cancels the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment to cancel.</param>
        /// <returns></returns>
        public async Task<CdmAppointment> CancelAppointment(Guid appointmentId)
        {
            var appointment = await _appointmentRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (!(appointment.Status.Value == RefListAppointmentStatuses.proposed
                || appointment.Status == RefListAppointmentStatuses.booked
                || appointment.Status == RefListAppointmentStatuses.waitlist
                || appointment.Status == RefListAppointmentStatuses.pending))
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status does not support Cancellation.");

            // Updating appointment
            appointment.Status = RefListAppointmentStatuses.cancelled;

            var res = await _appointmentRepo.UpdateAsync(appointment);

            return res;
        }

        /// <summary>
        /// RescheduleAppointment the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment to cancel.</param>
        /// <returns>If successfully rescheduled, returns the updated Appointment entity. 
        /// If could not reschedule due to unavailability of slots at the requested tiem then will return null.
        /// </returns>
        public async Task<CdmAppointment> RescheduleAppointment(Guid appointmentId, DateTime requiredTime, string contactName, string contactCellphone)
        {
            var appointment = await _appointmentRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (!(appointment.Status.Value == RefListAppointmentStatuses.proposed
                || appointment.Status == RefListAppointmentStatuses.booked
                || appointment.Status == RefListAppointmentStatuses.waitlist
                || appointment.Status == RefListAppointmentStatuses.pending))
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status does not support Rescheduling.");

            // Checking if there is an available slot at the required time
            var newSlot = await FindAvailableBookingSlot(appointment.Slot.Schedule.Id, requiredTime);

            if (newSlot is null)
                return null;

            // Updating new appointment properties
            appointment.Status = RefListAppointmentStatuses.booked;
            appointment.ContactCellphone = contactCellphone;
            appointment.ContactName = contactName;
            //appointment.AppointmentType = appointmentType;
            appointment.Slot = newSlot;
            appointment.AlternateContactCellphone = "";
            appointment.AlternateContactName = "";
            //BasedOn
            //appointment.Comment = "";
            appointment.Start = newSlot.StartDateTime;
            appointment.End = newSlot.EndDateTime;
            appointment.MinutesDuration = (newSlot.EndDateTime.Value - newSlot.StartDateTime.Value).Minutes;
            //ReasonCode
            appointment.ServiceCategory = newSlot.ServiceCategory;
            appointment.ServiceType = newSlot.ServiceType ?? newSlot.Schedule.ServiceType;
            appointment.Speciality = newSlot.Speciality ?? newSlot.Schedule.Speciality;

            var res = await _appointmentRepo.UpdateAsync(appointment);
            return res;
        }

        /// <summary>
        /// Confirms Arrival of the the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment.</param>
        /// <returns></returns>
        public async Task<CdmAppointment> ConfirmAppointmentArrival(Guid appointmentId)
        {
            var appointment = await _appointmentRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (appointment.Status != RefListAppointmentStatuses.booked)
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status must be 'Booked' in order to Confirm Arrival.");

            // Updating appointment
            appointment.Status = RefListAppointmentStatuses.checkedIn;
            appointment.ArrivalTime = DateTime.Now;

            var res = await _appointmentRepo.UpdateAsync(appointment);

            return res;
        }

    }
}
