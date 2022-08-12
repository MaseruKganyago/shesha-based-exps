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
    [Migration(20220811095000)]
    public class M20220811095000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_Benefits")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("AllowedMoney").AsDecimal().Nullable()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable();
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

