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
    [Migration(20211127135300)]
    public class M20211127135300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
                
CREATE OR ALTER    PROCEDURE [dbo].[GetWardCensusDailyStats] 
	    @WardId UNIQUEIDENTIFIER,
		@ReportDate DATETIME
			   
        AS
        BEGIN
	        SET  NOCOUNT ON;
	        ;WITH CTE 
			AS
			(
				SELECT Enc.Id,Enc.His_WardId,Facility.Fhir_NumberOfBeds,(

						SELECT COUNT(*)
						FROM Fhir_Encounters SubEnc 
						WHERE SubEnc.His_WardId = Enc.His_WardId 
						and CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, -1, CAST(@ReportDate AS date))
						and SubEnc.His_AdmissionStatusLkp = 1 /*Admitted*/) AS MidnightCount,

						(SELECT COUNT(*)  FROM Fhir_Encounters SubEnc 
						WHERE SubEnc.His_WardId = Enc.His_WardId 
						and (CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date)) 
						or CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, -1, CAST(@ReportDate AS date)) )
						and SubEnc.His_AdmissionStatusLkp = 1 /*Admitted*/) AS TotalAdmittedPatients

					FROM Fhir_Encounters Enc
						INNER JOIN Core_Facilities Facility 
						ON Facility.Id = Enc.His_WardId
				WHERE His_WardId = @WardId and
					CAST(Enc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))      
			) 
			SELECT  TOP(1) MidnightCount,TotalAdmittedPatients,(Fhir_NumberOfBeds -  TotalAdmittedPatients)
			AS TotalBedAvailability,
				(SELECT COUNT(*)  FROM Fhir_Encounters SubEnc 
						WHERE SubEnc.His_WardId = His_WardId 
						and CAST(SubEnc.StartDateTime AS DATE) = DATEADD(day, 0, CAST(@ReportDate AS date))
						and SubEnc.His_AdmissionStatusLkp = 2 /*Separated*/)
						AS TotalSeparatedPatients
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

