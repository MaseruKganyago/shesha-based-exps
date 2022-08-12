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
    [Migration(20220811150900)]
    public class M20220811150900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("entpr_FinancialTransactions")
                .AddColumn("AccountStatusLkp").AsInt64().Nullable()
                .AddColumn("AccountTypeLkp").AsInt64().Nullable()
                .AddColumn("ServiceStartDate").AsDateTime().Nullable()
                .AddColumn("ServiceStartEnd").AsDateTime().Nullable()
                .AddForeignKeyColumn("CoverageId", "Fhir_Coverages").Nullable()
                .AddForeignKeyColumn("OwnerId", "Core_Organisations").Nullable()
                .AddForeignKeyColumn("PartOfId", "entpr_FinancialTransactions").Nullable();

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

