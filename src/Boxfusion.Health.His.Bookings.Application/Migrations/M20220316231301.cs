using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Notifications;
using FluentMigrator;
using System;

namespace Boxfusion.Health.His.Bookings.Migrations
{
    /// <summary>
    /// Adding notification templates for new notifications
    /// </summary>
    [Migration(20220316231301)]
    public class M20220316231301 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            // Booking Cancelled
            Execute.Sql($@"INSERT INTO Core_Notifications (Id,CreationTime,IsDeleted,Description,Name,Namespace)
                            VALUES('{NotificationTemplateIds.BookingCancelled}', getDate(), 0, 'Booking Cancelled', '', 'His')");

            Execute.Sql($@"
             INSERT INTO [dbo].[Core_NotificationTemplates] ([Id],[CreationTime],[IsDeleted],[Body],[Name],[NotificationId],[SendTypeLkp],[BodyFormatLkp],[IsEnabled])
                 VALUES('{NotificationTemplateIds.BookingCancelled}',getDate(),0,
                    'Dear {{{{Fullname}}}}, This is to confirm that your appointment at {{{{FacilityName}}}} for the {{{{StartDate}}}} has been cancelled.','Booking Cancelled','{NotificationTemplateIds.BookingCancelled}',2 /*sms*/, 0 /*plain text*/, 1)");


            // Booking Rescheduled
            Execute.Sql($@"INSERT INTO Core_Notifications (Id,CreationTime,IsDeleted,Description,Name,Namespace)
                            VALUES('{NotificationTemplateIds.BookingRescheduled}', getDate(), 0, 'Booking Rescheduled', '', 'His')");

            Execute.Sql($@"
             INSERT INTO [dbo].[Core_NotificationTemplates] ([Id],[CreationTime],[IsDeleted],[Body],[Name],[NotificationId],[SendTypeLkp],[BodyFormatLkp],[IsEnabled])
                 VALUES('{NotificationTemplateIds.BookingRescheduled}',getDate(),0,
                    'Dear {{{{Fullname}}}}, This is to confirm that your appointment at {{{{FacilityName}}}} has been rescheduled to {{{{StartDate}}}}.','Booking Rescheduled','{NotificationTemplateIds.BookingRescheduled}',2 /*sms*/, 0 /*plain text*/, 1)");


            // Appointment Reminder
            Execute.Sql($@"INSERT INTO Core_Notifications (Id,CreationTime,IsDeleted,Description,Name,Namespace)
                            VALUES('{NotificationTemplateIds.AppointmentReminder}', getDate(), 0, 'Appointment Reminder', '', 'His')");

            Execute.Sql($@"
             INSERT INTO [dbo].[Core_NotificationTemplates] ([Id],[CreationTime],[IsDeleted],[Body],[Name],[NotificationId],[SendTypeLkp],[BodyFormatLkp],[IsEnabled])
                 VALUES('{NotificationTemplateIds.AppointmentReminder}',getDate(),0,
                    'Dear {{{{Fullname}}}}, This is a reminder of your appointment tomorrow at {{{{FacilityName}}}}.','Appointment Reminder','{NotificationTemplateIds.AppointmentReminder}',2 /*sms*/, 0 /*plain text*/, 1)");

        }
    }
}
