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
    [Migration(20211022151600)]
    public class M20211022151600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("Fhir_Signatures")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("TypeLkp").AsInt64().Nullable()
                .WithColumn("When").AsDateTime().Nullable()
                .WithColumn("WhoOwnerId").AsString().Nullable()
                .WithColumn("WhoOwnerType").AsString().Nullable()
                .WithColumn("OnBehalfOfOwnerId").AsString().Nullable()
                .WithColumn("OnBehalfOfOwnerType").AsString().Nullable()
                .WithColumn("TargetFormatLkp").AsInt64().Nullable()
                .WithColumn("SigFormatLkp").AsInt64().Nullable()
                .WithForeignKeyColumn("DataId", "Frwk_StoredFiles");

            Alter.Table("Fhir_Provenances")
                .AddColumn("TargetOwnerId").AsString().Nullable()
                .AddColumn("TargetOwnerType").AsString().Nullable()
                .AddColumn("OccuredPeriodStart").AsDateTime().Nullable()
                .AddColumn("OccuredPeriodEnd").AsDateTime().Nullable()
                .AddColumn("OccuredDateTime").AsDateTime().Nullable()
                .AddColumn("Recorded").AsDateTime().Nullable()
                .AddColumn("Policy").AsString().Nullable()
                .AddForeignKeyColumn("LocationId", "Core_Facilities")
                .AddColumn("ReasonLkp").AsInt64().Nullable()
                .AddColumn("ActivityLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("SignatureId", "Fhir_Signatures");

            Create.Table("Fhir_ProvenanceEntities")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithColumn("RoleLkp").AsInt64().Nullable()
               .WithColumn("WhatOwnerId").AsString().Nullable()
               .WithColumn("WhatOwnerType").AsString().Nullable()
               .WithForeignKeyColumn("ProvenanceId", "Fhir_Provenances");

            Create.Table("Fhir_Agents")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithColumn("TypeLkp").AsInt64().Nullable()
               .WithColumn("RoleLkp").AsInt64().Nullable()
               .WithColumn("WhoOwnerId").AsString().Nullable()
               .WithColumn("WhoOwnerIdType").AsString().Nullable()
               .WithColumn("OnBehalfOfOwnerId").AsString().Nullable()
               .WithColumn("OnBehalfOfOwnerIdType").AsString().Nullable()
               .WithForeignKeyColumn("ProvenanceId", "Fhir_Provenances");
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
