using Abp.Notifications;

namespace Boxfusion.Health.His.Bookings.Domain.Notifications.Models
{
    /// <summary>
    /// Model of the <see cref="NotificationTemplateIds.CompletionOfNewBooking"/> notification
    /// </summary>
    public class CompletionOfNewBookingModel : NotificationData
    {
        /// <summary>
        /// Recipient name
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Facility name
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Appointment start date
        /// </summary>
        public string StartDate { get; set; }
    }
}
