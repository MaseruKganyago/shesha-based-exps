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
    [Migration(20211222233200)]
    public class M20211222233200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"               
				CREATE OR ALTER PROCEDURE [dbo].[GetWardCensusDailyStats] 
				@WardId UNIQUEIDENTIFIER,
				@ReportDate DATETIME
			   
				AS
				BEGIN
					DECLARE @TotalNumberOfAdmissions INT;
					DECLARE @NumberOfDays INT;

					DECLARE @SumOfInpatientDays INT = (
						SELECT SUM(DATEDIFF(DAY, StartDateTime, getdate())) SumOfInpatientDays
						FROM [dbo].[Fhir_Encounters]
						WHERE His_WardId = @WardId and His_AdmissionStatusLkp = 1 and IsDeleted = 0
					)
			
					DECLARE @TotalSeparatedPatients INT = (
						SELECT  COUNT(*)
						FROM His_HisAdmissionAuditTrails AuditTrail
						INNER JOIN Fhir_Encounters Enc 
							ON Enc.Id = AuditTrail.AdmissionId
						WHERE AuditTrail.isDeleted = 0
							AND Enc.His_WardId is not null
							AND Enc.IsDeleted = 0
							AND AuditTrail.AdmissionStatusLkp = 2
							AND Enc.His_WardId = @WardId 
							AND CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
					)

					DECLARE @TodaysAdmission INT = (
						SELECT  COUNT(*)
						FROM His_HisAdmissionAuditTrails AuditTrail
						INNER JOIN Fhir_Encounters Enc 
							ON Enc.Id = AuditTrail.AdmissionId
						WHERE AuditTrail.isDeleted = 0
							AND Enc.His_WardId is not null
							AND Enc.IsDeleted = 0
							AND AuditTrail.AdmissionStatusLkp = 1
							AND Enc.His_WardId =  @WardId
							AND CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
					)

					DECLARE @NumberOfBeds INT = (
						SELECT Fhir_NumberOfBeds
						FROM Core_Facilities
						WHERE IsDeleted = 0 AND Id = @WardId
					)

					DECLARE @MidnightCount INT = (
						SELECT  COUNT(*)
						FROM His_HisAdmissionAuditTrails AuditTrail
							INNER JOIN Fhir_Encounters Enc 
								ON Enc.Id = AuditTrail.AdmissionId
						WHERE AuditTrail.isDeleted = 0
							AND Enc.His_WardId is not null
							AND Enc.IsDeleted = 0
							AND  AuditTrail.AdmissionStatusLkp = 1
							AND Enc.His_WardId =  @WardId
							AND CAST(AuditTrail.AuditTime AS DATE) < CAST(@ReportDate AS date)
					)

					DECLARE @TotalAdmittedPatients INT = (
						SELECT  COUNT(*)
						FROM His_HisAdmissionAuditTrails AuditTrail
							INNER JOIN Fhir_Encounters Enc 
								ON Enc.Id = AuditTrail.AdmissionId
						WHERE AuditTrail.isDeleted = 0
							AND Enc.His_WardId is not null
							AND Enc.IsDeleted = 0
							AND  AuditTrail.AdmissionStatusLkp = 1
							AND Enc.His_WardId =  @WardId
							AND (CAST(AuditTrail.AuditTime AS DATE) < CAST(@ReportDate AS date) OR
								 CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)))

					)

					DECLARE @DayPatients INT = (
						SELECT  COUNT(*)
						FROM His_HisAdmissionAuditTrails AuditTrail
							INNER JOIN Fhir_Encounters Enc 
								ON Enc.Id = AuditTrail.AdmissionId
						WHERE AuditTrail.isDeleted = 0
							AND Enc.His_WardId is not null
							AND Enc.IsDeleted = 0
							AND  AuditTrail.AdmissionStatusLkp = 1
							AND Enc.His_WardId =  @WardId
							AND CAST(AuditTrail.AuditTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
					)
			
					SET  NOCOUNT ON;

					SELECT ROUND((((@MidnightCount) + (@DayPatients * 0.5))/ (@NumberOfBeds))*100,10) BedUtilisation, 
								((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@TotalSeparatedPatients, 0))  AverageLengthOfStay,
								 @MidnightCount AS MidnightCount,
								 @TotalAdmittedPatients AS TotalAdmittedPatients,
								(@NumberOfBeds -  @TotalAdmittedPatients) AS TotalBedAvailability,
								 @TotalSeparatedPatients TotalSeparatedPatients ,
								 @NumberOfBeds AS TotalBedInWard, 
								 @TodaysAdmission TodaysAdmission
					END
GO

            ");
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

