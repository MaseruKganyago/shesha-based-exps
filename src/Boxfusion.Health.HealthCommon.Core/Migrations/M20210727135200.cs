using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210727135200)]
    public class M20210727135200 : Migration
    {
        public override void Up()
        {
            //Delete Foreign Key
            Delete.ForeignKey("FK_Fhir_Contacts_OrganisationId_Core_Organisations_Id").OnTable("Fhir_Contacts");

            //Delete Index
            Delete.Index("IX_Fhir_Contacts_OrganisationId").OnTable("Fhir_Contacts");

            //Delete AssignerId Column
            Delete.Column("OrganisationId").FromTable("Fhir_Contacts");

            //Delete
            Delete.Table("Fhir_Contacts");

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Contact
            Create.Table("Fhir_Contacts")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("RelationshipLkp").AsInt32().Nullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("MobileNumber").AsString().Nullable()
                .WithColumn("OfficeNumber").AsString().Nullable()
                .WithColumn("FaxNumber").AsString().Nullable()
                .WithColumn("EmailAddress").AsString().Nullable()
                .WithColumn("Address").AsString(500).Nullable()
                .WithColumn("GenderLkp").AsInt32().Nullable()
                .WithForeignKeyColumn("OrganisationId", "Core_Organisations")
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

