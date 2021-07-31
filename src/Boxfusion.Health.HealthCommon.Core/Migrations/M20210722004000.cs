using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210722004000)]
    public class M20210722004000 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.ContactPoint
            Create.Table("Fhir_ContactPoints")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("SystemLkp").AsInt32().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("UseLkp").AsInt32().Nullable()
                .WithColumn("Rank").AsInt32().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.HoursOfOperation
            Create.Table("Fhir_HoursOfOperations")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("DaysOfWeekLkp").AsInt32().Nullable()
                .WithColumn("AllDay").AsBoolean()
                .WithColumn("AvailableStartTime").AsDateTime().Nullable()
                .WithColumn("AvailableEndime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.NotAvailablePeriod
            Create.Table("Fhir_NotAvailablePeriods")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirAddress
            Create.Table("Fhir_FhirAddresses")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("UseLkp").AsInt32().Nullable()
                .WithColumn("TypeLkp").AsInt32().Nullable()
                .WithColumn("AddressLine1").AsString().Nullable()
                .WithColumn("AddressLine2").AsString().Nullable()
                .WithColumn("City").AsString().Nullable()
                .WithColumn("District").AsString().Nullable()
                .WithColumn("State").AsString().Nullable()
                .WithColumn("PostalCode").AsString().Nullable()
                .WithColumn("Country").AsString().Nullable()
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.FhirOrganisation
            Alter.Table("Fhir_FhirOrganisations")
                .AddColumn("TypeLkp").AsInt32().Nullable()
                .AddColumn("Name").AsString().Nullable()
                .AddColumn("ShortAlias").AsString().Nullable()
                .AddColumn("PrimaryContactEmail").AsString().Nullable()
                .AddColumn("PrimaryContactTelephone").AsString().Nullable()
                .AddForeignKeyColumn("PrimaryAddressId", "Fhir_FhirAddresses")
                .AddForeignKeyColumn("ParentId", "Fhir_FhirOrganisations");
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}

