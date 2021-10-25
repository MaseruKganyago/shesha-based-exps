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
    [Migration(20210803062400)]
    public class M20210803062400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            ////Delete Foreign Key
            //Delete.ForeignKey("FK_Fhir_Qualifications_AssignerId_Core_Organisations_Id").OnTable("Fhir_Qualifications");
            //Delete.ForeignKey("FK_Fhir_Qualifications_OwnerId_Core_Persons_Id").OnTable("Fhir_Qualifications");

            ////Delete Index
            //Delete.Index("IX_Fhir_Qualifications_AssignerId").OnTable("Fhir_Qualifications");
            //Delete.Index("IX_Fhir_Qualifications_OwnerId").OnTable("Fhir_Qualifications");

            ////Delete AssignerId Column
            //Delete.Column("OwnerId").FromTable("Fhir_Qualifications");
            //Delete.Column("AssignerId").FromTable("Fhir_Qualifications");

            ////Delete
            //Delete.Table("Fhir_Qualifications");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Contact
            Create.Table("Fhir_Qualifications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Identifier").AsString().Nullable()
                .WithColumn("CodeLkp").AsInt64().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithForeignKeyColumn("OwnerId", "Core_Persons")
                .WithForeignKeyColumn("IssuerId", "Core_Organisations");

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

