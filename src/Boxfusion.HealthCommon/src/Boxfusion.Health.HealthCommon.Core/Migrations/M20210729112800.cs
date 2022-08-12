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
    [Migration(20210729112800)]
    public class M20210729112800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("ReasonCode").OnTable("Fhir_MedicationStatements").To("ReasonCodeLkp");
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

