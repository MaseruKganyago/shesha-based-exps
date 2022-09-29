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
    [Migration(20220927151700)]
    public class M20220927151700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            if (!Schema.Table("entpr_Accounts").Column("His_BillingClassificationId").Exists())
                Alter.Table("entpr_Accounts")
               .AddForeignKeyColumn("His_BillingClassificationId", "His_BillingClassifications").Nullable();
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
