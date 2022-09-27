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
    
    [Migration(20220926182300)]
    public class M20220926182300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            #region Delete CoverageId ForeignKey
            Delete.ForeignKey("FK_entpr_Accounts_Fhir_CoverageId_Fhir_Coverages_Id").OnTable("entpr_Accounts");
            Delete.Index("IX_entpr_Accounts_Fhir_CoverageId").OnTable("entpr_Accounts");
            Delete.Column("Fhir_CoverageId").FromTable("entpr_Accounts");
            #endregion
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
