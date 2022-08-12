using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211028174200)]
    public class M20211028174200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
                Alter.Column("Active").OnTable("Fhir_PractitionerRoles").AsBoolean().NotNullable();
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
