using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220425134100)]
    public class M20220425134100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            // Increase comment column length on Schedules:
            Alter.Column("Comment")
                .OnTable("Fhir_Schedules")
                .AsFixedLengthString(2000)
                .WithDefaultValue("")
                .Nullable();

            // Increase description column length on Facilities
            Alter.Column("Description")
                .OnTable("Core_Organisations")
                .AsFixedLengthString(2000)
                .WithDefaultValue("")
                .Nullable();

            // Increase description column length on Facilities
            Alter.Column("Description")
                .OnTable("Core_Facilities")
                .AsFixedLengthString(2000)
                .WithDefaultValue("")
                .Nullable();

        }

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
