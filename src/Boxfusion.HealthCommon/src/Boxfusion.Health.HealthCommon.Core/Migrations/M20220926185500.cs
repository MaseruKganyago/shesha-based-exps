using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    
    [Migration(20220926185500)]
    public class M20220926185500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Alter.Table("entpr_Accounts")
                .AddForeignKeyColumn("BillingClassificationId", "His_BillingClassifications");
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
