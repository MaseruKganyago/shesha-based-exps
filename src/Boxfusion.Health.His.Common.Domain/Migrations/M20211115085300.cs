using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211115085300)]
    public class M20211115085300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Create.Table("His_WardMidnightCensusDailyReport")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("WardId", "Core_Facilities")
                .WithColumn("ReportDate").AsDateTime().Nullable()
                .WithColumn("ApprovalStatusLkp").AsInt64().Nullable()
                .WithColumn("Description").AsString(250).Nullable()
                .WithForeignKeyColumn("ApprovedById", "Core_Persons")
                .WithColumn("ApprovalTime").AsDateTime().Nullable()
                .WithColumn("MidnightCount").AsInt32().Nullable()
                .WithColumn("TotalAdmittedPatients").AsInt32().Nullable()
                .WithColumn("TotalSeparatedPatients").AsInt32().Nullable()
                .WithColumn("TotalBedAvailability").AsInt32().Nullable()
                .WithColumn("NumBedsInWard").AsInt32().Nullable()
                .WithColumn("BedUtilisation").AsDouble().Nullable()
                .WithColumn("AverageLengthofStay").AsDouble().Nullable();

            Alter.Table("Fhir_Encounters")
                .AddColumn("His_HospitalAdmissionNumber").AsString(30).Nullable()
                .AddColumn("His_HospitalAdmissionStatusLkp").AsInt64().Nullable()
                .AddColumn("His_ClassificationLkp").AsInt64().Nullable()
                .AddColumn("His_OtherCategoryLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("TransferFroHospitalId", "Core_Organisations")
                .AddForeignKeyColumn("TransferToHospitalId", "Core_Organisations")
                .AddColumn("His_WardAdmissionNumber").AsString(30).Nullable()
                .AddColumn("His_AdmissionTypeLkp").AsInt64().Nullable()
                .AddColumn("His_AdmissionStatusLkp").AsInt64().Nullable()
                .AddColumn("His_TransferRejectionReasonLkp").AsInt64().Nullable()
                .AddColumn("His_TransferRejectionReasonComment").AsString(250).Nullable()
                .AddColumn("His_SeparationTypeLkp").AsInt64().Nullable()
                .AddForeignKeyColumn("His_SeparationDestinationWardId", "Core_Facilities")
                .AddColumn("His_SeparationChildHealthLkp").AsInt64().Nullable()
                .AddColumn("His_SeparationComment").AsString(250).Nullable()
                .AddColumn("His_CapturedAfterApproval").AsBoolean().WithDefaultValue(false);

            Alter.Table("Core_Persons")
                .AddColumn("His_PatientMasterIndexNumber").AsString(30).Nullable()
                .AddColumn("His_HospitalPatientNumber").AsString(30).Nullable()
                .AddColumn("His_IdentificationTypeLkp").AsInt64().Nullable()
                .AddColumn("His_PatientProvinceLkp").AsInt64().Nullable();
            ;
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
