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
    [Migration(20220831015100)]
    public class M20220831015100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("His_AccountCoverages")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("AccountId", "entpr_Accounts")
                .WithForeignKeyColumn("CoverageId", "Fhir_Coverages");
            ;
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
