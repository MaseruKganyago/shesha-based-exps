using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211129095000)]
    public class M20211129095000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Table("His_WardMidnightCensusDailyReport").To("His_WardMidnightCensusReport");
            Alter.Table("His_WardMidnightCensusReport").AddColumn("ReportTypeLkp").AsInt64().Nullable();
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
