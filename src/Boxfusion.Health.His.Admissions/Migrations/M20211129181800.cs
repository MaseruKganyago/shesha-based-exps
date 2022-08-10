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
    [Migration(20211129181800)]
    public class M20211129181800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
CREATE or ALTER PROCEDURE [dbo].[GetWardCensusDailyStats] 
	    @WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME
			   
        AS
        BEGIN
			DECLARE @TotalNumberOfAdmissions INT ;
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
			DECLARE @DayPatients INT = (
			SELECT count(1)
			  FROM [dbo].[Fhir_Encounters]
			  WHERE His_WardId = @WardId and His_AdmissionStatusLkp = 1 and IsDeleted = 0
			  and DATEDIFF(DAY, StartDateTime, getdate()) = 0
			)

			DECLARE @TotalSeparatedPatients INT = (
				SELECT COUNT(*)  
				FROM Fhir_Encounters SubEnc 
				WHERE SubEnc.His_WardId = His_WardId 
				AND SubEnc.IsDeleted = 0
				AND CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
				AND SubEnc.His_AdmissionStatusLkp = 2 /*Separated*/
			)
	        SET  NOCOUNT ON;
;WITH CTE 
	AS
	(
		SELECT Enc.Id,Enc.His_WardId,Facility.Fhir_NumberOfBeds,(

			SELECT COUNT(*)
			FROM Fhir_Encounters SubEnc 
			WHERE SubEnc.His_WardId = Enc.His_WardId AND SubEnc.IsDeleted = 0
			and CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, -1, CAST(@ReportDate AS date))
			and SubEnc.His_AdmissionStatusLkp = 1 /*Admitted*/) AS MidnightCount,

			(SELECT COUNT(*)  FROM Fhir_Encounters SubEnc 
			WHERE SubEnc.His_WardId = Enc.His_WardId AND SubEnc.IsDeleted = 0
			and (CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)) 
			or CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, -1, CAST(@ReportDate AS date)) )
			and SubEnc.His_AdmissionStatusLkp = 1 /*Admitted*/) AS TotalAdmittedPatients,

			(SELECT COUNT(*)  FROM Fhir_Encounters SubEnc 
			WHERE SubEnc.His_WardId = Enc.His_WardId AND SubEnc.IsDeleted = 0
			and (CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)))
			and SubEnc.His_AdmissionStatusLkp = 1 /*Admitted*/) AS DayPatients
			
		FROM Fhir_Encounters Enc
			INNER JOIN Core_Facilities Facility 
			ON Facility.Id = Enc.His_WardId
		WHERE His_WardId = @WardId and
			CAST(Enc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))      
	) 
	SELECT  TOP(1) ROUND((((MidnightCount) + (DayPatients * 0.5))/ (@BedInWard))*100,10) BedUtilisation, 
			((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@TotalSeparatedPatients, 0))  AverageLengthOfStay,
			 MidnightCount,TotalAdmittedPatients,(Fhir_NumberOfBeds -  TotalAdmittedPatients) AS TotalBedAvailability,
			 @TotalSeparatedPatients TotalSeparatedPatients
		,Fhir_NumberOfBeds AS TotalBedInWard
FROM CTE
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

