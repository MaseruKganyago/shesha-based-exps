using Abp.Notifications;

namespace Boxfusion.Health.His.Bookings.Notifications.Models
{
    /// <summary>
    /// Model for most/all notifications relating to appointments.
    /// </summary>
    public class AppointmentNotificationModel : NotificationData
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
