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
    [Migration(20211201193100)]
    public class M20211201193100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Column("MidnightCount").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Column("TotalAdmittedPatients").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Column("TotalSeparatedPatients").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Column("TotalBedAvailability").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Column("NumBedsInWard").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Column("AverageLengthofStay").OnTable("His_WardMidnightCensusReport").AsFloat().Nullable();
            Alter.Table("His_WardMidnightCensusReport").AddColumn("AverageBedAvailability").AsFloat().Nullable();
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
