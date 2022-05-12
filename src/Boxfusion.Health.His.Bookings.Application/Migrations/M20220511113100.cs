using FluentMigrator;
using System;

namespace Boxfusion.Health.His.Bookings.Application.Migrations
{
    [Migration(20220511113100)]
    public class M20220511113100 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(@"update Core_NotificationTemplates set SendTypeLkp = 2 /*sms*/ where id = '643D0631-AD92-48C0-88CB-3BDA6AED8EC4'");
        }
    }
}
