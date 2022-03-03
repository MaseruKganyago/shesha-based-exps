using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
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
    public class AppointmentForBookingManager : DomainService
    {
        private readonly IRepository<CdmSlot, Guid> _slotsRepo;
        private readonly IRepository<CdmAppointment, Guid> _appointmentsRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        public AppointmentForBookingManager(IRepository<CdmSchedule, Guid> schedulesRepo,
            IRepository<ScheduleAvailabilityForBooking, Guid> scheduleAvailabilityRepo,
            IRepository<CdmSlot, Guid> slotsRepo,
            IRepository<CdmAppointment, Guid> appointmentsRepo)
        {
            _slotsRepo = slotsRepo;
            _appointmentsRepo = appointmentsRepo;
        }

        /// <summary>
        /// Creates a new Appointment to book the first available Slot for the specified schedule, slotType and requestedTime.
        /// </summary>
        /// <returns>Returns the appointment created to book the requested time. Will throw an exception if a slot at that time was not found.</returns>
        public async Task<CdmAppointment> BookAvailableSlotAsync(CdmSchedule schedule,
                                                                RefListSlotCapacityTypes slotType,
                                                                DateTime requiredTime,
                                                                int? appointmentType,
                                                                CdmPatient patient,
                                                                string contactName,
                                                                string contactCellphone)
        {
            if (schedule is null) throw new ArgumentNullException("schedule");
            if (patient is null) throw new ArgumentNullException("Patient");
            if (requiredTime < DateTime.Now.Date) throw new ArgumentOutOfRangeException("requiredTime", "Cannot request to book an appointment in the past.");
            if (!schedule.Active) throw new ArgumentOutOfRangeException("schedule.Active", "Schedule must be active.");


            var slot = await FindAvailableBookingSlot(schedule, slotType, requiredTime);

            if (slot is null)
                return null;    // No available slots so will return null

            // Completing the booking
            var appointment = new CdmAppointment()
            {
                Status = RefListAppointmentStatuses.booked,
                ContactCellphone = contactCellphone,
                ContactName = contactName,
                Patient = patient,
                //AppointmentType = appointmentType, //TOOD:IH: Need to change AppointmentType to int as it should be user configurable
                Slot = slot,
                Description = "",
                AlternateContactCellphone = "",
                AlternateContactName = "",
                //BasedOn
                Comment = "",
                Start = slot.StartDateTime,
                End = slot.EndDateTime,
                MinutesDuration = (slot.EndDateTime.Value - slot.StartDateTime.Value).Minutes,
                PatientInstruction = "",
                Priority = 2,
                //ReasonCode
                //ServiceCategory = slot.ServiceCategory, //TODO: Should be made Int as should be configuration driven
                ServiceType = slot.ServiceType ?? schedule.ServiceType, //Should be made Int as should be configuration driven
                //Speciality = slot.Speciality ?? schedule.Speciality   ??TODO: Should be made Int as should be configuration driven
            };

            var res = await _appointmentsRepo.InsertAsync(appointment);

            return res;
        }

        /// <summary>
        /// Returns the first Available booking slot within the specified Schedule for the specified time and SlotType
        /// </summary>
        /// <returns>Returns the first slot found, otherwise returns null.</returns>
        public async Task<CdmSlot> FindAvailableBookingSlot(CdmSchedule schedule,
                                                                RefListSlotCapacityTypes slotType,
                                                                DateTime requiredTime)
        {
            if (!schedule.Active) throw new ArgumentOutOfRangeException("schedule.Active", "Schedule must be active.");

            var slot = await _slotsRepo.FirstOrDefaultAsync(e =>
                e.Schedule.Id == schedule.Id
                && e.IsGeneratedFrom.Active == true
                && e.CapacityType == slotType
                && e.StartDateTime <= requiredTime && e.EndDateTime > requiredTime
                && e.RemainingCapacity > 0);

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
        public async Task<List<CdmSlot>> GetAllAvailableBookingSlotsAsync(CdmSchedule schedule,
                                                        RefListSlotCapacityTypes slotType,
                                                        DateTime fromDateTime, 
                                                        DateTime toDateTime)
        {
            if (!schedule.Active) throw new ArgumentOutOfRangeException("schedule.Active", "Schedule must be active.");

            //var slots = _slotsRepo.GetAll().Where(e =>
            //    e.Schedule.Id == schedule.Id
            //    && e.IsGeneratedFrom.Active == true
            //    && e.CapacityType == slotType
            //    && e.StartDateTime >= fromDateTime && e.EndDateTime < toDateTime
            //    && e.RemainingCapacity > 0)
            //    .Distinct(new AvailableSlotComparer())
            //    .OrderBy(e => e.StartDateTime)
            //    .ToList();

            var slots = _slotsRepo.GetAll().Where(e =>
                e.Schedule.Id == schedule.Id
                && e.IsGeneratedFrom.Active == true
                && e.CapacityType == slotType
                && e.StartDateTime >= fromDateTime && e.EndDateTime < toDateTime
                && e.RemainingCapacity > 0)
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
                    && b2.RemainingCapacity > 0
                    && b1.CapacityType == b2.CapacityType) ;
            }

            public int GetHashCode([DisallowNull] CdmSlot obj)
            {
                return (obj.StartDateTime.ToString() + 
                    (obj.RemainingCapacity > 0).ToString() + obj.
                    CapacityType.ToString()).GetHashCode();
            }
        }

        /// <summary>
        /// Cancels the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment to cancel.</param>
        /// <returns></returns>
        public async Task<CdmAppointment> CancelAppointment(Guid appointmentId)
        {
            var appointment = await _appointmentsRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (!(appointment.Status.Value == RefListAppointmentStatuses.proposed
                || appointment.Status == RefListAppointmentStatuses.booked
                || appointment.Status == RefListAppointmentStatuses.waitlist
                || appointment.Status == RefListAppointmentStatuses.pending))
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status does not support Cancellation.");

            // Updating appointment
            appointment.Status = RefListAppointmentStatuses.cancelled;

            var res = await _appointmentsRepo.UpdateAsync(appointment);

            return res;
        }

        /// <summary>
        /// RescheduleAppointment the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment to cancel.</param>
        /// <returns></returns>
        public async Task<CdmAppointment> RescheduleAppointment(Guid appointmentId, RefListSlotCapacityTypes slotType, DateTime requiredTime, string contactName, string contactCellphone)
        {
            var appointment = await _appointmentsRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (!(appointment.Status.Value == RefListAppointmentStatuses.proposed
                || appointment.Status == RefListAppointmentStatuses.booked
                || appointment.Status == RefListAppointmentStatuses.waitlist
                || appointment.Status == RefListAppointmentStatuses.pending))
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status does not support Rescheduling.");

            // Checking if there is an available slot at the required time
            var newSlot = await FindAvailableBookingSlot((CdmSchedule)appointment.Slot.Schedule, slotType, requiredTime);

            if (newSlot is null)
                return null;    // No available slots so will return null

            // Updating new appointment properties
            appointment.Status = RefListAppointmentStatuses.booked;
            appointment.ContactCellphone = contactCellphone;
            appointment.ContactName = contactName;
            //AppointmentType = appointmentType; //TOOD:IH: Need to change AppointmentType to int as it should be user configurable
            appointment.Slot = newSlot;
            appointment.AlternateContactCellphone = "";
            appointment.AlternateContactName = "";
            //BasedOn
            //appointment.Comment = "";
            appointment.Start = newSlot.StartDateTime;
            appointment.End = newSlot.EndDateTime;
            appointment.MinutesDuration = (newSlot.EndDateTime.Value - newSlot.StartDateTime.Value).Minutes;
            //ReasonCode
            //ServiceCategory = slot.ServiceCategory, //TODO: Should be made Int as should be configuration driven
            appointment.ServiceType = newSlot.ServiceType ?? newSlot.Schedule.ServiceType; //Should be made Int as should be configuration driven
                                                                                           //Speciality = slot.Speciality ?? schedule.Speciality   ??TODO: Should be made Int as should be configuration driven

            var res = await _appointmentsRepo.UpdateAsync(appointment);
            return res;
        }

        /// <summary>
        /// Confirms Arrival of the the specified Appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment.</param>
        /// <returns></returns>
        public async Task<CdmAppointment> ConfirmAppointmentArrival(Guid appointmentId)
        {
            var appointment = await _appointmentsRepo.GetAsync(appointmentId);
            if (appointment is null)
                throw new ArgumentException("appointmentId is not recognised.", "appointmentId");

            if (appointment.Status != RefListAppointmentStatuses.booked)
                throw new ArgumentOutOfRangeException("appointment.Status", "Specified appointment.Status must be 'Booked' in order to Confirm Arrival.");

            // Updating appointment
            appointment.Status = RefListAppointmentStatuses.checkedIn;
            appointment.ArrivalTime = DateTime.Now;

            var res = await _appointmentsRepo.UpdateAsync(appointment);

            return res;
        }

    }
}
