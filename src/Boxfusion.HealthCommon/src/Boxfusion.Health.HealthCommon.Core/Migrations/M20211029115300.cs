using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211029115300)]
    public class M20211029115300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_RelationshipLkp").AsInt64().Nullable()
                .AddColumn("Fhir_PeriodStart").AsDateTime().Nullable()
                .AddColumn("Fhir_PeriodEnd").AsDateTime().Nullable()
                .AddColumn("Fhir_Preferred").AsBoolean().NotNullable().WithDefaultValue(false);
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
