using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220112150500)]
    public class M20220112150500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("IsActive").OnTable("Fhir_Schedules").To("Active");
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
