using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220913101700)]
    public class M20220913101700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("His_BedFees")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("EndDate").AsDateTime().Nullable()
                .WithForeignKeyColumn("WardAdmissionId", "Fhir_Encounters").Nullable()
                .WithForeignKeyColumn("BedId", "Core_Facilities").Nullable()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("ChargeItemId", "Fhir_ChargeItems").Nullable();
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
