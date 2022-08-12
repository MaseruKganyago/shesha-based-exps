using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20210914090900)]
    public class M20210914090900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_MedicationRequests")
                 .AddColumn("MedicationName").AsString().Nullable()
                 .AddColumn("MedicationCode").AsString().Nullable()
                 .AddColumn("DosageLkp").AsInt64().Nullable()
                 .AddColumn("RouteLkp").AsInt64().Nullable()
                 .AddColumn("FrequencyLkp").AsInt64().Nullable()
                 .AddColumn("DurationLkp").AsInt64().Nullable()
                 .AddColumn("RepeatLkp").AsInt64().Nullable()
                 .AddColumn("InstructionLkp").AsInt64().Nullable();
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

