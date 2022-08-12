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
    [Migration(20211007110000)]
    public class M20211007110000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Dosages")
                .AddColumn("TimingRepeatPeriod").AsDecimal().Nullable()
                .AddColumn("TimingRepeatPeriodMax").AsDecimal().Nullable()
                .AddColumn("TimingRepeatOffSet").AsInt16().Nullable();

            Rename.Column("TimingRepeatBoundsDuration").OnTable("Fhir_Dosages").To("TimingRepeatBoundsDurationTicks");
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

