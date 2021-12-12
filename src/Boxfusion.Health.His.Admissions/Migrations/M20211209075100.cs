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
    [Migration(20211209075100)]
    public class M20211209075100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"

CREATE OR ALTER     PROCEDURE [dbo].[GetWardCensusDailyStats] 
	    @WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME
			   
        AS
        BEGIN
		DECLARE @TotalNumberOfAdmissions INT;
			DECLARE @NumberOfDays INT;

			DECLARE @BedInWard INT = (
			SELECT Fhir_NumberOfBeds FROM Core_Facilities
			WHERE Id = @WardId AND IsDeleted = 0
			)
			DECLARE @SumOfInpatientDays INT = (
			SELECT SUM(DATEDIFF(DAY, StartDateTime, getdate())) SumOfInpatientDays
			  FROM [dbo].[Fhir_Encounters]
			  WHERE His_WardId = @WardId and His_AdmissionStatusLkp = 1 and IsDeleted = 0
			)
			
			DECLARE @TotalSeparatedPatients INT = (
				SELECT COUNT(*)  
				FROM Fhir_Encounters 
				WHERE His_WardId = His_WardId 
				AND IsDeleted = 0
				AND CAST(StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
				AND His_AdmissionStatusLkp = 2 /*Separated*/
			)

			DECLARE @TodaysAdmission INT = (
				SELECT COUNT(*)
				FROM [dbo].[Fhir_Encounters]
				WHERE His_WardId = @WardId AND His_AdmissionStatusLkp = 1 AND IsDeleted = 0
				AND CAST(StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
			)

			DECLARE @NumberOfBeds INT = (
				SELECT Fhir_NumberOfBeds
				FROM Core_Facilities
				WHERE IsDeleted = 0 AND Id = @WardId
			)

			DECLARE @MidnightCount INT = (
			SELECT COUNT(*)
				FROM Fhir_Encounters  
				WHERE His_WardId = @WardId
				AND IsDeleted = 0
				AND CAST(StartDateTime AS DATE) < CAST(@ReportDate AS date)
				AND His_AdmissionStatusLkp = 1 /*Admitted*/
			)

			DECLARE @TotalAdmittedPatients INT = (
			SELECT COUNT(*)  FROM Fhir_Encounters  
				WHERE His_WardId = @WardId AND IsDeleted = 0
				AND (CAST(StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)) 
				OR CAST(StartDateTime AS DATE) < CAST(@ReportDate AS date) )
				AND His_AdmissionStatusLkp = 1 /*Admitted*/
			)

			DECLARE @DayPatients INT = (
			SELECT COUNT(*)  
				FROM Fhir_Encounters 
				WHERE His_WardId = @WardId AND IsDeleted = 0
				AND (CAST(StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)))
				AND His_AdmissionStatusLkp = 1 /*Admitted*/
			)
			
	        SET  NOCOUNT ON;

			SELECT ROUND((((@MidnightCount) + (@DayPatients * 0.5))/ (@BedInWard))*100,10) BedUtilisation, 
						((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@TotalSeparatedPatients, 0))  AverageLengthOfStay,
						 @MidnightCount AS MidnightCount,
						 @TotalAdmittedPatients AS TotalAdmittedPatients,
						(@NumberOfBeds -  @TotalAdmittedPatients) AS TotalBedAvailability,
						 @TotalSeparatedPatients TotalSeparatedPatients ,
						 @NumberOfBeds AS TotalBedInWard, 
						 @TodaysAdmission TodaysAdmission
			END

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

