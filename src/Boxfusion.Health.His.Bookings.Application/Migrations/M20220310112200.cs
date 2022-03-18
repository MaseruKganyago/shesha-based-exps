using Boxfusion.Health.His.Bookings.Notifications;
using FluentMigrator;
using System;

namespace Boxfusion.Health.His.Bookings.Domain.Migrations
{
    [Migration(20220310112200)]
    public class M20220310112200 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql($@"INSERT INTO Core_Notifications (Id,CreationTime,IsDeleted,Description,Name,Namespace)
                            VALUES('{NotificationTemplateIds.CompletionOfNewBooking}', getDate(), 0, 'Booking Notifications', '', 'His')");

            Execute.Sql($@"
             INSERT INTO [dbo].[Core_NotificationTemplates] ([Id],[CreationTime],[IsDeleted],[Body],[Name],[NotificationId],[SendTypeLkp],[BodyFormatLkp],[IsEnabled])
                 VALUES('{NotificationTemplateIds.CompletionOfNewBooking}',getDate(),0,
                    'Dear {{{{Fullname}}}}, Your appointment at {{{{FacilityName}}}} has been confirmed for the {{{{StartDate}}}}.','Booking Notification','{NotificationTemplateIds.CompletionOfNewBooking}',2 /*sms*/, 0 /*plain text*/, 1)");
        }
    }
}
