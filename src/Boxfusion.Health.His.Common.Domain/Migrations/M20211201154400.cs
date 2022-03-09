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
    [Migration(20211201154400)]
    public class M20211201154400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("His_WardMidnightCensusReport")
                .AddColumn("ApprovalTime2").AsDateTime().Nullable()
                .AddColumn("RejectionComments").AsString().Nullable()
                .AddForeignKeyColumn("His_ApprovedBy2Id", "Core_Persons")
                .AddForeignKeyColumn("His_RejectedById", "Core_Persons")
                ;
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
