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
    [Migration(20210812002300)]
    public class M20210812002300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column("VisitTime").OnTable("Fhir_ServiceRequests").To("VisitTimeTicks");
            Rename.Column("ScheduledVisitTime").OnTable("Fhir_ServiceRequests").To("ScheduledVisitTimeTicks");
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

