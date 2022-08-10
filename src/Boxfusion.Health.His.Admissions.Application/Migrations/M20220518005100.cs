using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220518005100)]
    public class M20220518005100 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(@"
        
CREATE OR ALTER   PROCEDURE [dbo].[GetWardCensusDailyStats] 
		@WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME			
			   
				AS
				BEGIN	
		DECLARE @ReportDateStart DATETIME2  = cast (@ReportDate as DATE) 
		DECLARE @ReportDateEnd DATETIME2 = DATEADD(ns, -100, DATEADD(s, 86400, @ReportDateStart))

		/*Gets Total Separated Patients */
		DECLARE @TotalSeparatedPatients INT = (						
			SELECT  COUNT(*)
			FROM Fhir_Encounters
			WHERE isDeleted = 0 AND His_AdmissionStatusLkp = 2 /*Separated*/ AND His_WardId = @WardId 
				AND CAST(His_SeparationDate AS DATE) = CAST(@ReportDate AS date) AND Frwk_Discriminator = 'His.WardAdmission'
		)
		/*Gets Number Of Beds in a specific ward*/
		DECLARE @NumberOfBeds INT = (
			SELECT Fhir_NumberOfBeds
			FROM Core_Facilities
			WHERE IsDeleted = 0 AND Id = @WardId
		)  
		/*Gets total number of patients who slept in a ward.*/
		DECLARE @MidnightCount INT = (
			SELECT  COUNT(*) midnightCount
			FROM Fhir_Encounters
			WHERE  IsDeleted = 0 
				AND  His_WardId = @WardId 
				AND Frwk_Discriminator = 'His.WardAdmission'				
				AND  StartDateTime <= @ReportDateEnd 
				AND (His_SeparationDate IS NULL OR His_SeparationDate > @ReportDateEnd)
				AND  (His_AdmissionStatusLkp IN (1 /*Admitted*/, 2 /*Seperated*/,3 /*In-Transit*/))
		)
		/*Gets Total Admitted Patients a given day.*/
		DECLARE @TotalAdmittedPatients INT = (	
			CASE    
				WHEN CAST(@ReportDate AS date) = CAST(GetDate() AS date)
					THEN (
						SELECT  COUNT(*) totalAdmittedPatients FROM Fhir_Encounters
						WHERE isDeleted = 0 
							AND  (His_AdmissionStatusLkp IN (1 /*Admitted*/, 3 /*In-Transit*/))
							AND His_WardId = @WardId 
							AND Frwk_Discriminator = 'His.WardAdmission'
					)
				WHEN CAST(@ReportDate AS date) < CAST(GetDate() AS date)
					THEN(
						SELECT @MidnightCount
					)
			END			
		)	
		/*Gets total Admissions for a given day.*/
		DECLARE @TodaysAdmission INT = (
			SELECT  COUNT(*) todaysAdmission
			FROM Fhir_Encounters
			WHERE  IsDeleted = 0 AND  His_WardId = @WardId  
				AND Frwk_Discriminator = 'His.WardAdmission'
				AND ( StartDateTime >= @ReportDateStart AND StartDateTime < @ReportDateEnd)
		)
		/*Gets the total number of patients who came in and out same day of the ward*/
		DECLARE @DayPatients INT = (
			SELECT  COUNT(*) dayPatient
			FROM Fhir_Encounters
			WHERE  IsDeleted = 0 
				AND  His_WardId = @WardId 
				AND Frwk_Discriminator = 'His.WardAdmission'
				AND His_AdmissionStatusLkp = 2 /*Separated*/
				AND ( StartDateTime >= @ReportDateStart AND StartDateTime < @ReportDateEnd)
				AND (His_SeparationDate >= @ReportDateStart AND His_SeparationDate < @ReportDateEnd)
		);
	
	SELECT 
			ROUND((((@MidnightCount) + (@DayPatients * 0.5))/ (@NumberOfBeds))*100,10) BedUtilisation,
			(@MidnightCount) AS MidnightCount,
			 @TotalAdmittedPatients AS TotalAdmittedPatients,
			(@NumberOfBeds -  @TotalAdmittedPatients) AS TotalBedAvailability,
			 @TotalSeparatedPatients TotalSeparatedPatients ,
			 @NumberOfBeds AS TotalBedInWard,
			 @TodaysAdmission TodaysAdmission

		END

            ");
            Execute.Sql(@" 


CREATE OR ALTER     PROCEDURE [dbo].[GetWardCensusMonthlyStatsProc] 
	@WardId UNIQUEIDENTIFIER,
	@ReportDate DATETIME	
		AS
		BEGIN

	DECLARE	@DaysLapsed INT = DAY(@ReportDate);

	/*Gets Total Separated Patients */
	DECLARE @Separated INT = (
		SELECT COUNT(*)
		FROM [dbo].[Fhir_Encounters]
		WHERE IsDeleted = 0 AND His_WardId = @WardId
			AND (month(@ReportDate) >= month(His_SeparationDate) AND month(@ReportDate) <=   month(His_SeparationDate)) 
			AND year(@ReportDate) = year(His_SeparationDate)
	)
	/*Gets Number Of Beds in a specific ward*/
	DECLARE @NumBedsInWard INT = (
		SELECT Fhir_NumberOfBeds
		FROM Core_Facilities
		WHERE IsDeleted = 0 AND Id = @WardId
	) 
	/*Gets Total Bed Availability*/
	DECLARE @TotalBedAvailability INT = (
		SELECT SUM(TotalBedAvailability)
		FROM His_WardMidnightCensusReports
		WHERE IsDeleted = 0 AND WardId = @WardId 
		AND month(ReportDate) = month(@ReportDate) and year(ReportDate) = year(@ReportDate)
	)
	/*Gets Total Of Inpatient Days*/
	DECLARE @SumOfInpatientDays INT = (	
		SELECT ISNULL( SUM( DATEDIFF(day, StartDateTime, His_SeparationDate)),0) AS SumOfInpatientDays
		FROM [dbo].[Fhir_Encounters]
		WHERE His_WardId = @WardId 
		AND IsDeleted = 0 
		AND month(StartDateTime) = month(@ReportDate) 
		AND year(StartDateTime) = year(@ReportDate)
	)
	/*Gets the total number of patients who came in and out same day*/
	DECLARE @DayPatients INT = (
		SELECT Count(*)
		FROM(
		SELECT ISNULL(DATEDIFF(day, StartDateTime, His_SeparationDate),0) AS SumOfInpatientDays
			FROM [dbo].[Fhir_Encounters]
			WHERE His_WardId = @WardId 
			AND IsDeleted = 0 
			AND month(StartDateTime) = month(@ReportDate) 
			AND year(StartDateTime) = year(@ReportDate)
		) s
		WHERE SumOfInpatientDays = 0
	);

	SELECT 
			@Separated AS TotalSeparations, 
			@NumBedsInWard AS NumBedsInWard, 
			@TotalBedAvailability AS TotalBedAvailability,
		   (@TotalBedAvailability/@DaysLapsed) AS AverageBedAvailability, 
		  ((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@Separated, 0))  AverageLengthOfStay,
		 (((@SumOfInpatientDays) + (@DayPatients * 0.5))/ (@NumBedsInWard * 30.42))*100 BedUtilisation

	END
GO
			");
        }
    }
}
