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
    [Migration(20211212163900)]
    public class M20211212163900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"

CREATE OR ALTER PROCEDURE [dbo].[GetWardCensusMonthlyStatsProc] 
	    @WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME,	 
	    @DaysLapsed INT
        AS
        BEGIN
		DECLARE @ApprovalStatus INT = 2 /*Approaved 2*/

DECLARE @TotalAdmissions INT = (
	SELECT SUM(TotalAdmittedPatients)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus 
	AND FORMAT(ReportDate, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
);
DECLARE @Separated INT = (
	SELECT SUM(TotalSeparatedPatients)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
	AND FORMAT(ReportDate, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
);
DECLARE @MidnightCount INT = (
	SELECT SUM(MidnightCount)
	FROM His_WardMidnightCensusReports
	WHERE IsDeleted = 0 AND WardId = @WardId AND ApprovalStatusLkp = @ApprovalStatus
	AND FORMAT(ReportDate, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
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
	AND FORMAT(ReportDate, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
)
DECLARE @SumOfInpatientDays INT = (	
	SELECT SUM(DATEDIFF(DAY, StartDateTime, getdate())) SumOfInpatientDays
	FROM [dbo].[Fhir_Encounters]
	WHERE His_WardId = @WardId 
	AND His_AdmissionStatusLkp = 1 
	AND IsDeleted = 0 
	AND FORMAT(StartDateTime, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
)
DECLARE @DayPatients INT = (
	SELECT count(1)
	FROM [dbo].[Fhir_Encounters]
	WHERE His_WardId = @WardId 
	AND His_AdmissionStatusLkp = 1 
	AND IsDeleted = 0
	AND DATEDIFF(DAY, StartDateTime, getdate()) = 0
	AND FORMAT(StartDateTime, 'yyyyMM') = FORMAT(@ReportDate, 'yyyyMM')
)
SELECT @TotalAdmissions AS TotalAdmissions, @Separated AS TotalSeparations, @NumBedsInWard AS NumBedsInWard, 
	   @TotalBedAvailability AS TotalBedAvailability,
	  (@TotalBedAvailability/@DaysLapsed) AS AverageBedAvailability, 
	 ((@SumOfInpatientDays + (@DayPatients *0.5))/NULLIF(@Separated, 0))  AverageLengthOfStay,
	(((@MidnightCount) + (@DayPatients * 0.5))/ (@NumBedsInWard * 30.42))*100 BedUtilisation
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

