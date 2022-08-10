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
    [Migration(20220112192900)]
    public class M20220112192900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"      
ALTER   PROCEDURE [dbo].[GetWardCensusDailyStats] 
				@WardId UNIQUEIDENTIFIER,
				@ReportDate DATETIME,
				@TodaysAdmission INT,
				@MidnightCount INT,
				@DayPatients INT
			   
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
						FROM Fhir_Encounters
						WHERE isDeleted = 0
							AND His_AdmissionStatusLkp = 2
							AND His_WardId = @WardId 
							AND CAST(His_SeparationDate AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
					
					)
					DECLARE @NumberOfBeds INT = (
						SELECT Fhir_NumberOfBeds
						FROM Core_Facilities
						WHERE IsDeleted = 0 AND Id = @WardId
					)
					DECLARE @TotalAdmittedPatients INT = (
						
						SELECT  SUM(totalAdmittedPatients) totalAdmittedPatients
						FROM
							( 
							   SELECT  COUNT(*) totalAdmittedPatients
											FROM Fhir_Encounters
											WHERE isDeleted = 0
												AND  (His_AdmissionStatusLkp != 2 and His_AdmissionStatusLkp != 4)
												AND His_WardId = @WardId
												AND (convert(date, StartDateTime) <= convert(date, @ReportDate) 
												and convert(date, @ReportDate) <= dateadd(HOUR, 2, iif(His_SeparationDate is null, getdate(),His_SeparationDate)))
							
								UNION ALL
							   SELECT  COUNT(*) totalAdmittedPatients
											FROM Fhir_Encounters
											WHERE isDeleted = 0
												AND  (His_AdmissionStatusLkp = 2)
												AND His_WardId =  @WardId
												AND (convert(date, StartDateTime) <= convert(date, @ReportDate) 
												and convert(date, @ReportDate) <= dateadd(HOUR, 2, iif(His_SeparationDate is null, getdate(),His_SeparationDate)))
						   ) s
						)
					DECLARE @TempAdmittedPatients INT = (
					SELECT  COUNT(*) totalAdmittedPatients
					FROM Fhir_Encounters
					WHERE isDeleted = 0
						AND  (His_AdmissionStatusLkp != 2 and His_AdmissionStatusLkp != 4)
						AND His_WardId = @WardId
						AND (convert(date, StartDateTime) <= convert(date,  @ReportDate) 
						and convert(date,  @ReportDate) <= dateadd(HOUR, 2, iif(His_SeparationDate is null, getdate(),His_SeparationDate)))
							
					)
			
					SET  NOCOUNT ON;

					SELECT ROUND((((@MidnightCount) + (@DayPatients * 0.5))/ (@NumberOfBeds))*100,10) BedUtilisation, 
								((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@TotalSeparatedPatients, 0))  AverageLengthOfStay,
								 @MidnightCount AS MidnightCount,
								 @TotalAdmittedPatients AS TotalAdmittedPatients,
								(@NumberOfBeds -  @TempAdmittedPatients) AS TotalBedAvailability,
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

