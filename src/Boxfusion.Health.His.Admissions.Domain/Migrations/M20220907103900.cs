using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907103900)]
    public class M20220907103900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Table("His_WardMidnightCensusReports").To("HisAdmis_WardMidnightCensusReports");
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
