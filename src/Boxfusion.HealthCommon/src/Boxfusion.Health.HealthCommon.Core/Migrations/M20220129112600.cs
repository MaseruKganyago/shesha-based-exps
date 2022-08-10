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
    [Migration(20220129112600)]
    public class M20220129112600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Schedules")
                .AddColumn("Frwk_Discriminator").AsString(150);

            Delete.Table("Fhir_CdmSchedules");

            Alter.Table("Fhir_Schedules")
               .AddColumn("Name").AsString(150).Nullable()
               .AddColumn("PrioritisationIndex").AsInt32().Nullable()
               .AddColumn("SchedulingModelLkp").AsInt64().Nullable();
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

