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
    [Migration(20210722231700)]
    public class M20210722231700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.PersonFhirBase
            Alter.Table("Core_Persons")
                .AddColumn("Fhir_PassportNumber").AsString().Nullable()
                .AddColumn("Fhir_PermitNumber").AsString().Nullable()
                .AddColumn("Fhir_CommunicationLanguageLkp").AsInt64().Nullable()
                 .AddForeignKeyColumn("Fhir_IDDocumentId", "Frwk_StoredFiles")
                .AddColumn("Fhir_IdentityVerificationStatusLkp").AsInt64().Nullable()
                .AddColumn("Fhir_NationalityLkp").AsInt64().Nullable()
                .AddColumn("Fhir_EthnicityLkp").AsInt64().Nullable();

            //Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir.Identifier
            Create.Table("Fhir_Identifiers")
                .WithColumn("OwnerId").AsString().Nullable()
                .WithColumn("OwnerType").AsString().Nullable()
                .WithColumn("UseLkp").AsInt64().Nullable()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("System").AsString().Nullable()
                .WithColumn("Value").AsString().Nullable()
                .WithColumn("PeriodStart").AsDateTime().Nullable()
                .WithColumn("PeriodEnd").AsDateTime().Nullable()
                .WithForeignKeyColumn("AssignerId", "Core_Organisations");
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

