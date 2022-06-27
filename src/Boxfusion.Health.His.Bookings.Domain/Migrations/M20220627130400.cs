using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220627130400)]
    public class M20220627130400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            if (!Schema.Table("Fhir_Appointments").Column("HasReminderBeenSent").Exists())
            {
                Alter.Table("Fhir_Appointments")
                    .AddColumn("HasReminderBeenSent")
                    .AsBoolean()
                    .WithDefaultValue(false);

                Execute.Sql(@"
                    update Fhir_Appointments set HasReminderBeenSent = 0
                ");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            if (Schema.Table("Fhir_Appointments").Column("HasReminderBeenSent").Exists())
            {
                Delete.Column("HasReminderBeenSent").FromTable("Fhir_Appointments");
            }
        }

    }
}
