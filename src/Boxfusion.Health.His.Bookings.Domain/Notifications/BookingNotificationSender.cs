using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Bookings.Domain.Notifications.Models;
using Shesha.Notifications;
using Shesha.Utilities;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain.Notifications
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

        /// inheritedDoc
        public async Task NotifyCompletionOfNewBookingAsync(CdmAppointment appointment)
        {
            if (appointment == null)
                throw new Exception($"{nameof(appointment)} must not be null");

            if (appointment.Start == null)
                throw new Exception($"{nameof(appointment.Start)} must not be null");

            var mobileNo = !string.IsNullOrWhiteSpace(appointment.ContactCellphone)
                ? appointment.ContactCellphone
                : appointment.Patient.MobileNumber;
            if (string.IsNullOrWhiteSpace(mobileNo))
                return;

            var hospitalId = appointment.Slot?.Schedule?.ActorOwnerId?.ToGuid() ?? Guid.Empty;
            var hospital = hospitalId != Guid.Empty
                ? await _hospitalRepository.FirstOrDefaultAsync(hospitalId)
                : null;

            if (hospital == null)
                return;
            
            var notificationData = new CompletionOfNewBookingModel
            {
                Fullname = !string.IsNullOrWhiteSpace(appointment.ContactName)
                    ? appointment.ContactName
                    : appointment.Patient.FullName,
                StartDate = appointment.Start?.FormatDate(),
                FacilityName = hospital?.Name
            };

            await _notificationAppService.PublishSmsNotificationAsync(
                templateId: NotificationTemplateIds.CompletionOfNewBooking,
                data: notificationData,
                mobileNo: mobileNo
            );
        }
    }
}
