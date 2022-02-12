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
                                                        SELECT 
                                                         app.Id
                                                        ,app.RefNumber
                                                        ,app.[Start]
                                                        ,app.AppointmentTypeLkp AppointmentType
                                                        ,app.StatusLkp [Status]
                                                        ,(SELECT [value] FROM Fhir_Identifiers WHERE TypeLkp = 5 and CAST(OwnerId AS UNIQUEIDENTIFIER) = app.PatientId) AS PatientFileId
                                                        ,per.IdentityNumber IDNumberPassportNumber
                                                        ,per.FullName
                                                        ,per.MobileNumber1 ContactNumber
                                                        ,sch.[Name] Schedule
                                                        FROM Fhir_Appointments app
                                                        LEFT JOIN Core_Persons per ON per.Id = app.PatientId
                                                        LEFT JOIN Fhir_Slots slot ON slot.Id = app.SlotId
                                                        LEFT JOIN Fhir_Schedules sch ON sch.Id = slot.ScheduleId
                                                        WHERE ((app.[Start] >= :filterStartDate and app.[Start] < DATEADD(day,1,:filterEndDate)) OR (:filterStartDate IS NULL AND :filterEndDate IS NULL) OR (:filterEndDate IS NULL AND app.[Start] = :filterStartDate))
                                                        AND sch.Id = :scheduleId AND (CAST(sch.ActorOwnerId AS UNIQUEIDENTIFIER) = :facilityId)
                                                        ORDER BY [Status]
                                                        OFFSET (:pageNumber-1)*(:pageSize) ROWS
                                                        FETCH NEXT :pageSize ROWS ONLY";
    }
}
