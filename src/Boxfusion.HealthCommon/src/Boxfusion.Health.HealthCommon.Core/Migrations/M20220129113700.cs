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
    [Migration(20220129113700)]
    public class M20220129113700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Slots")
                .AddColumn("Frwk_Discriminator").AsString(150);

            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_CdmSlots_IsGeneratedFromId_Fhir_ScheduleAvailabilities_Id").OnTable("Fhir_CdmSlots");

            //Delete Index
            Delete.Index("IX_Fhir_CdmSlots_IsGeneratedFromId").OnTable("Fhir_CdmSlots");

            //Delete AssignerId Column
            Delete.Column("IsGeneratedFromId").FromTable("Fhir_CdmSlots");

            Delete.Table("Fhir_CdmSlots");

            Alter.Table("Fhir_Slots")
                .AddForeignKeyColumn("IsGeneratedFromId", "Fhir_ScheduleAvailabilities")
                .AddColumn("CapacityTypeLkp").AsInt64().Nullable()
                .AddColumn("Capacity").AsInt32().Nullable()
                .AddColumn("RemainingCapacity").AsInt32().Nullable();
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

