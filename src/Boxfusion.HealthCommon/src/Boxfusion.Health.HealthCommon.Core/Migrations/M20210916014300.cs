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
    [Migration(20210916014300)]
    public class M20210916014300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Alter.Column("NumberOfRepeatsAllowed").OnTable("Fhir_MedicationRequests").AsInt32().Nullable();
            Rename.Column("RequestOwnerId").OnTable("Fhir_MedicationRequests").To("RequesterOwnerId");
            Rename.Column("RequestOwnerType").OnTable("Fhir_MedicationRequests").To("RequesterOwnerType");

            Delete.Column("InitialFillDuration").FromTable("Fhir_MedicationRequests");
            Delete.Column("DispenseInterval").FromTable("Fhir_MedicationRequests");
            Delete.Column("ExpectedSupplyDuration").FromTable("Fhir_MedicationRequests");

            Alter.Table("Fhir_MedicationRequests")
                .AddColumn("InitialFillDurationTicks").AsInt64().Nullable()
                .AddColumn("DispenseIntervalTicks").AsInt64().Nullable()
                .AddColumn("ExpectedSupplyDurationTicks").AsInt64().Nullable();
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

