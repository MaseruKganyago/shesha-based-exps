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
    [Migration(20211224033800)]
    public class M20211224033800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"               
				ALTER   PROCEDURE [dbo].[GetWardCensusMonthlyStatsProc] 
	    @WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME,
	    @DaysLapsed INT
        AS
        BEGIN
		DECLARE @ApprovalStatus INT = 2 /*Approaved 2*/

DECLARE @TotalAdmissions INT = (
	SELECT count(*)
	  FROM [dbo].[His_HisAdmissionAuditTrails] AuditT
	  INNER JOIN [Fhir_Encounters] Enc 
		ON Enc.Id = AuditT.[AdmissionId]
	  WHERE AuditT.isdeleted = 0 AND AuditT.AdmissionStatusLkp = 1 AND Enc.IsDeleted = 0
	  and Enc.His_WardId = @WardId 
	  AND month(Enc.StartDateTime) = month(@ReportDate) and year(Enc.StartDateTime) = year(@ReportDate)
);
DECLARE @Separated INT = (
	SELECT SUM(TotalSeparatedPatients)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
	AND month(ReportDate) = month(@ReportDate) and year(ReportDate) = year(@ReportDate)
);
DECLARE @MidnightCount INT = (
	SELECT SUM(MidnightCount)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
	AND month(ReportDate) = month(@ReportDate) and year(ReportDate) = year(@ReportDate)
)
DECLARE @NumBedsInWard INT = (
	SELECT TOP(1) NumBedsInWard
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
);
DECLARE @TotalBedAvailability INT = (
	SELECT SUM(TotalBedAvailability)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
	AND month(ReportDate) = month(@ReportDate) and year(ReportDate) = year(@ReportDate)
)
DECLARE @SumOfInpatientDays INT = (	
	SELECT ISNULL( SUM(IIF(His_SeparationDate is null, DATEDIFF(day, StartDateTime, dateadd(HOUR, 2, getdate())), DATEDIFF(day, StartDateTime, His_SeparationDate))),0) AS SumOfInpatientDays
	FROM [dbo].[Fhir_Encounters]
	WHERE His_WardId = @WardId 
	AND IsDeleted = 0 
	AND month(StartDateTime) = month(@ReportDate) and year(StartDateTime) = year(@ReportDate)
)
DECLARE @DayPatients INT = (
	SELECT Count(*)
		FROM(

		SELECT ISNULL(IIF(His_SeparationDate is null, DATEDIFF(day, StartDateTime, dateadd(HOUR, 2, getdate())), DATEDIFF(day, StartDateTime, His_SeparationDate)),0) AS SumOfInpatientDays
			FROM [dbo].[Fhir_Encounters]
			WHERE His_WardId = @WardId 
			AND IsDeleted = 0 
			AND month(StartDateTime) = month(@ReportDate) and year(StartDateTime) = year(@ReportDate)
		) s
		WHERE SumOfInpatientDays = 0
)
SELECT @TotalAdmissions AS TotalAdmissions, @Separated AS TotalSeparations, @NumBedsInWard AS NumBedsInWard, 
	   @TotalBedAvailability AS TotalBedAvailability,
	  (@TotalBedAvailability/@DaysLapsed) AS AverageBedAvailability, 
	 ((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@Separated, 0))  AverageLengthOfStay,
	(((@SumOfInpatientDays) + (@DayPatients * 0.5))/ (@NumBedsInWard * 30.42))*100 BedUtilisation
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

