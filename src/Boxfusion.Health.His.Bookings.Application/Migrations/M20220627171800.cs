using FluentMigrator;
using System;

namespace Boxfusion.Health.His.Bookings.Application.Migrations
{
    [Migration(20220627171800)]
    public class M20220627171800 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            if (Schema.Table("Fhir_Appointments").Column("HasReminderBeenSent").Exists())
            {
                Alter.Table("Fhir_Appointments")
                    .AlterColumn("HasReminderBeenSent")
                    .AsBoolean()
                    .Nullable();
            }
        }
    }
}
