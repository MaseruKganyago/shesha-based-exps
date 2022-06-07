using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 
        /// </summary>
        public static string FlattenedAppointmentSqlQuery = @"
		
				DECLARE @scheduleId UNIQUEIDENTIFIER = :scheduleId
				DECLARE @filterEndDate DATETIME = :filterEndDate
				DECLARE @filterStartDate DATETIME = :filterStartDate
				DECLARE @pageNumber INT = :pageNumber
				DECLARE @pageSize INT = :pageSize

				SELECT app.Id
					,app.RefNumber
					,app.[Start] 
					,app.AppointmentTypeLkp AppointmentType
					,app.StatusLkp [Status]
					,(SELECT TOP 1 [value] FROM Fhir_Identifiers WHERE TypeLkp = 5 and CAST(OwnerId AS UNIQUEIDENTIFIER) = app.PatientId) AS PatientFileId
					,per.IdentityNumber IDNumberPassportNumber
					,per.FullName
					,per.MobileNumber1 ContactNumber
					,sch.[Name] Schedule
					,ISNULL(app.Comment, 'None') Comment
					,COUNT(*) OVER () as TotalCount
					,(SELECT UserName FROM AbpUserAccounts where Id = sch.CreatorUserId) CreatedBy

				FROM Fhir_Appointments app
					LEFT JOIN Core_Persons per ON per.Id = app.PatientId
					LEFT JOIN Fhir_Slots slot ON slot.Id = app.SlotId
					LEFT JOIN Fhir_Schedules sch ON sch.Id = slot.ScheduleId
				WHERE (
						(
							app.[Start] >= @filterStartDate 
							
							AND app.[Start] < DATEADD(day,1,ISNULL(@filterEndDate, GETDATE()))
						) 
						 OR (@filterStartDate IS NULL AND @filterEndDate IS NULL) 
						 OR (@filterEndDate IS NULL AND app.[Start] = @filterStartDate)
					  )
					AND sch.Id = @scheduleId 

				ORDER BY [Status]
					OFFSET (@pageNumber-1)*(@pageSize) ROWS
				FETCH NEXT @pageSize ROWS ONLY	
";
    }
}
