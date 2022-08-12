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
    [Migration(20210724103400)]
    public class M20210724103400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Delete.Column("Fhir_PrimaryPractitionerRole").FromTable("Core_Persons");
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Patient
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_PrimaryPractitionerRoleLkp").AsInt64().Nullable()
                .AddColumn("Fhir_OtherIdentityNumber").AsString().Nullable()
                .AddColumn("Fhir_MultipleBirthBoolean").AsBoolean().WithDefaultValue(0)
                .AddColumn("Fhir_MultipleBirthInteger").AsInt32().Nullable()
                .AddColumn("Fhir_DeceasedBoolean").AsBoolean().WithDefaultValue(0)
                .AddColumn("Fhir_DeceasedDateTime").AsDateTime().Nullable()
                .AddColumn("Fhir_MaritalStatusLkp").AsInt64().Nullable()
                .AddColumn("Fhir_GeneralPractitioner").AsString().Nullable()
                .AddForeignKeyColumn("Fhir_LinkToOtherPatientId", "Core_Persons")
                .AddColumn("Fhir_TypeOfLinkToOtherPatientLkp").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Contact
            Create.Table("Fhir_Contacts")
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("RelationshipLkp").AsInt64().Nullable()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("MobileNumber").AsString().Nullable()
                .WithColumn("OfficeNumber").AsString().Nullable()
                .WithColumn("FaxNumber").AsString().Nullable()
                .WithColumn("EmailAddress").AsString().Nullable()
                .WithColumn("Address").AsString(500).Nullable()
                .WithColumn("GenderLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("OrganisationId", "Core_Organisations")
                .WithColumn("StartDateTime").AsDateTime().Nullable()
                .WithColumn("EndDateTime").AsDateTime().Nullable();
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

