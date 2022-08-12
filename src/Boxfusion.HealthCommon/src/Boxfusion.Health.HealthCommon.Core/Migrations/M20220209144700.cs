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
    [Migration(20220209144700)]
    public class M20220209144700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Column("TimingRepeatCount").OnTable("Fhir_Dosages").AsInt32().Nullable();
            Alter.Column("TimingRepeatCountMax").OnTable("Fhir_Dosages").AsInt32().Nullable();
            Alter.Column("TimingRepeatFrequency").OnTable("Fhir_Dosages").AsInt32().Nullable();
            Alter.Column("TimingRepeatFrequencyMax").OnTable("Fhir_Dosages").AsInt32().Nullable();
            Alter.Column("TimingRepeatOffSet").OnTable("Fhir_Dosages").AsInt32().Nullable();

            Alter.Column("DoseNumberPositiveInt").OnTable("Fhir_ProtocolApplications").AsInt32().Nullable();
            Alter.Column("SeriesDosesPositiveInt").OnTable("Fhir_ProtocolApplications").AsInt32().Nullable();
            Alter.Column("SeriesDosesString").OnTable("Fhir_ProtocolApplications").AsInt32().Nullable();
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

