using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// Updating discriminator for old records as have changed the domain model.
    /// </summary>
    [Migration(20220314182901)]
    public class M20220314182901 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
                UPDATE Fhir_ScheduleAvailabilities
                    SET  Frwk_Discriminator = 'Cdm.ScheduleAvailForDayBooking'
                    WHERE Frwk_Discriminator = 'Fhir.ScheduleAvailabilityForBooking'
                GO
        ");
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

