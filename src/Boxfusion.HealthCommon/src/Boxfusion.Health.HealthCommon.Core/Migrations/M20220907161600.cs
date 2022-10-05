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
    [Migration(20220907161600)]
    public class M20220907161600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("FormLkp").OnTable("entpr_Products").To("Fhir_FormLkp");
            Rename.Column("AmmountNumerator").OnTable("entpr_Products").To("Fhir_AmountNumerator");
            Rename.Column("AmountDenominator").OnTable("entpr_Products").To("Fhir_AmountDenominator");
            Rename.Column("BatchLotNumber").OnTable("entpr_Products").To("Fhir_BatchLotNumber");
            Rename.Column("BatchExpirationDate").OnTable("entpr_Products").To("Fhir_BatchExpirationDate");
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

