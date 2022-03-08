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
    [Migration(20211202140000)]
    public class M20211202140000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Rename.Column ("His_ApprovedBy2Id").OnTable("His_WardMidnightCensusReports").To("ApprovedBy2Id");
            Rename.Column ("His_RejectedById").OnTable("His_WardMidnightCensusReports").To("RejectedById");

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
