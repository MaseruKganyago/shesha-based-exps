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
    [Migration(20210721053600)]
    public class M20210721053600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.IcdTenCode
            Create.Table("Fhir_IcdTenCodes")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Number").AsInt32().Nullable()
                .WithColumn("ChapterNumber").AsString().Nullable()
                .WithColumn("ChapterDesc").AsString().Nullable()
                .WithColumn("GroupCode").AsString().Nullable()
                .WithColumn("GroupDesc").AsString().Nullable()
                .WithColumn("ICDTenThreeCode").AsString().Nullable()
                .WithColumn("ICDTenThreeCodeDesc").AsString().Nullable()
                .WithColumn("ICDTenCode").AsString().Nullable()
                .WithColumn("WHOFullDesc").AsString().Nullable()
                .WithColumn("ValidICDTenClinicalUse").AsString().Nullable()
                .WithColumn("ValidICDTenPrimary").AsString().Nullable()
                .WithColumn("ValidICDTenAsterisk").AsString().Nullable()
                .WithColumn("ValidICDTenDagger").AsString().Nullable()
                .WithColumn("ValidICDTenSequelae").AsString().Nullable()
                .WithColumn("AgeRange").AsString().Nullable()
                .WithColumn("Gender").AsString().Nullable()
                .WithColumn("Status").AsString().Nullable()
                .WithColumn("WHOStartDate").AsDateTime().Nullable()
                .WithColumn("WHOEndDate").AsDateTime().Nullable()
                .WithColumn("WHORevisionHistory").AsString().Nullable()
                .WithColumn("SAStartDate").AsDateTime().Nullable()
                .WithColumn("SAEndDate").AsDateTime().Nullable()
                .WithColumn("SARevisionHistory").AsString().Nullable()
                .WithColumn("Comment").AsString().Nullable();

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

