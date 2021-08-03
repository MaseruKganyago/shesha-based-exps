﻿using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20210725002800)]
    public class M20210725002800 : Migration
    {
        public override void Up()
        {
            //Boxfusion.Health.HealthCommon.Core.Domain.Cdm.CHWWorkOrder
            Create.Table("Fhir_CHWWorkOrders")
                .WithIdAsGuid()
                .WithFullAuditColumns();

            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Encounter
            Alter.Table("Fhir_Encounters")
                .AddColumn("PreAdmissionIdentifier").AsString().Nullable()
                .AddColumn("OriginOwnerId").AsString().Nullable()
                .AddColumn("OriginOwnerType").AsString().Nullable()
                .AddColumn("AdmitSourceLkp").AsInt32().Nullable()
                .AddColumn("ReAdmissionLkp").AsInt32().Nullable()
                .AddColumn("DietPreferenceLkp").AsInt32().Nullable()
                .AddColumn("SpecialCourtesyLkp").AsInt32().Nullable()
                .AddColumn("SpecialArrangementLkp").AsInt32().Nullable()
                .AddColumn("DestinationOwnerId").AsString().Nullable()
                .AddColumn("DestinationOwnerType").AsString().Nullable()
                .AddColumn("DischargeDispositionLkp").AsInt32().Nullable();


            //Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Encounter
            Alter.Table("Fhir_Encounters")
                .AddColumn("FollowupIsFeelingBetter").AsBoolean()
                .AddColumn("FollowupNotificationStatusLkp").AsInt32().Nullable()
                .AddColumn("FollowupRequired").AsBoolean()
                .AddForeignKeyColumn("FollowupAppointmentId", "Fhir_Appointments")
                .AddColumn("FollowupSuggestion").AsString(500).Nullable()
                .AddForeignKeyColumn("CHWWorkOrderId", "Fhir_CHWWorkOrders");
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
