using Abp.Extensions;
using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220908130100)]
    public class M20220908130100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_Relateds")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("ClaimId", "Fhir_Claims").Nullable()
                .WithColumn("RelationshipLkp").AsInt64().Nullable()
                .WithColumn("Reference").AsGuid().Nullable();

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

