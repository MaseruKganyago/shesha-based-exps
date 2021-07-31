using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
namespace Boxfusion.Health.His.Admissions.Migrations
{
    [Migration(20210622102200)]
    public class M20210622102200 : Migration
    {
        public override void Up()
        {
            Create.Table("HisAdmis_Identifiers")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Use").AsInt32().Nullable()
                .WithColumn("TypeId").AsString(40).Nullable()
                .WithColumn("System").AsString().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_Addresses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Use").AsInt32().Nullable()
                .WithColumn("Type").AsInt32().Nullable()
                .WithColumn("Text").AsString().Nullable()
                .WithColumn("Line").AsString().Nullable()
                .WithColumn("City").AsString().Nullable()
                .WithColumn("District").AsString().Nullable()
                .WithColumn("State").AsString().Nullable()
                .WithColumn("PostalCode").AsString().Nullable()
                .WithColumn("Country").AsString().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_Attachments")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ContentType").AsInt32().Nullable()
                .WithColumn("Language").AsInt32().Nullable()
                .WithColumn("Data").AsBinary(int.MaxValue).Nullable()
                .WithColumn("Url").AsString().Nullable()
                .WithColumn("Size").AsInt32().Nullable()
                .WithColumn("Hash").AsBinary(int.MaxValue).Nullable()
                .WithColumn("Title").AsString().Nullable()
                .WithColumn("Creation").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_ClassHistories")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("ClassId").AsString(40).Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_Communications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Language").AsInt32().Nullable()
                .WithColumn("Preferred").AsBoolean()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_HumanNames")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Use").AsInt32().Nullable()
                .WithColumn("Text").AsString().Nullable()
                .WithColumn("Family").AsString().Nullable()
                .WithColumn("Given").AsString().Nullable()
                .WithColumn("Prefix").AsString().Nullable()
                .WithColumn("Suffix").AsString().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_ContactPoints")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("System").AsInt32().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("Use").AsInt32().Nullable()
                .WithColumn("Rank").AsInt32().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_HoursOfOperations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("DaysOfWeek").AsInt32().Nullable()
                .WithColumn("AllDay").AsBoolean()
                .WithColumn("OpeningTime").AsDateTime().Nullable()
                .WithColumn("ClosingTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_Positions")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Longitude").AsDecimal().Nullable()
                .WithColumn("Latitude").AsDecimal().Nullable()
                .WithColumn("Altitude").AsDecimal().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_StatusHistories")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Status").AsInt32().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();

            Create.Table("HisAdmis_Diagnoses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("UseId").AsString(40).Nullable()
                .WithColumn("Rank").AsInt32().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();



            Create.Table("HisAdmis_Contacts")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("AgentId", "Core_Persons")
                .WithColumn("UseId").AsString(40).Nullable()
                .WithColumn("Rank").AsInt32().Nullable()
                .WithColumn("OwnerId").AsString(40).Nullable()
                .WithColumn("OwnerType").AsString(100).Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
