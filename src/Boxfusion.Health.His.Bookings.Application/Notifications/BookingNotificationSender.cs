using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Bookings.Notifications.Models;
using Shesha.Notifications;
using Shesha.Utilities;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Notifications
{
    /// <summary>
    /// Booking notification sender
    /// </summary>
    public class BookingNotificationSender : IBookingNotificationSender, ITransientDependency
    {
        private readonly INotificationAppService _notificationAppService;
        private readonly IRepository<Hospital, Guid> _hospitalRepository;

        public BookingNotificationSender(INotificationAppService notificationAppService, IRepository<Hospital, Guid> hospitalRepository)
        {
            _notificationAppService = notificationAppService;
            _hospitalRepository = hospitalRepository;
        }

        public async Task NotifyAppointmentReminderAsync(CdmAppointment appointment)
        {
            await SendNotificationAsync(appointment, NotificationTemplateIds.AppointmentReminder);
        }

        public async Task NotifyBookingCancelledAsync(CdmAppointment appointment)
        {
            await SendNotificationAsync(appointment, NotificationTemplateIds.BookingCancelled);
        }

        public async Task NotifyBookingRescheduledAsync(CdmAppointment appointment)
        {
            await SendNotificationAsync(appointment, NotificationTemplateIds.BookingRescheduled);
        }

        public async Task NotifyCompletionOfNewBookingAsync(CdmAppointment appointment)
        {
            await SendNotificationAsync(appointment, NotificationTemplateIds.CompletionOfNewBooking);
        }
        
        /// inheritedDoc
        private async Task SendNotificationAsync(CdmAppointment appointment, Guid notificationTemplateId)
        {
            if (appointment == null)
                throw new Exception($"{nameof(appointment)} must not be null");

            if (appointment.Start == null)
                throw new Exception($"{nameof(appointment.Start)} must not be null");

            var mobileNo = !string.IsNullOrWhiteSpace(appointment.ContactCellphone)
                ? appointment.ContactCellphone
                : appointment.Patient.MobileNumber1;
            if (string.IsNullOrWhiteSpace(mobileNo))
                return;


            var healthFacility = appointment.Slot?.Schedule?.HealthFacilityOwner;

            if (healthFacility == null)
                return;

            var notificationData = new AppointmentNotificationModel
            {
                Fullname = !string.IsNullOrWhiteSpace(appointment.ContactName)
                    ? appointment.ContactName
                    : appointment.Patient.FullName,
                StartDate = appointment.Start?.FormatDate(),
                FacilityName = healthFacility?.Name
            };

            await _notificationAppService.PublishSmsNotificationAsync(
                templateId: notificationTemplateId,
                data: notificationData,
                mobileNo: mobileNo
            );
        }
    }
}
