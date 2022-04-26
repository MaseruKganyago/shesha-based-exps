using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.His.Bookings.Domain;
using Boxfusion.Health.His.Bookings.Notifications;
using Castle.Core.Logging;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    /// <summary>
    /// Finds all appointments for which Patient has not been marked as Arrived which 
    /// are passed the cut-off (where start time is more than 8 hours passed)
    /// and updates status to 'No Show'
    /// </summary>
    [ScheduledJob("f7e435c5-a1a8-4463-b695-1b115a0d95bb",
        startupMode: StartUpMode.Manual,
        cronString: "0 3 * * *",  // Executes everyday at 3am
        description: "Updates the status of all appointments for which the Patient has not been marked as arrived to 'No Show'. This will only affect appointments whose start time is more than 8 hours past.")
        ]
    public class UpdateMissedAppointmentsJob : ScheduledJobBase, ITransientDependency
    {
        private const string SQL_SELECT_MISSED_APPOINTMENTS = @"SELECT Id 
                                    FROM 
                                        Fhir_Appointments 
                                    WHERE 
                                            IsDeleted = 0
                                        AND StatusLkp = 3 /*Booked*/
                                        AND [Start] <= @cutoffDate
                                ";

        /// <summary>
        /// 
        /// </summary>
        public UpdateMissedAppointmentsJob() : base()
        {

        }

        /// <summary>
        /// Implements the logic to be executed on specified schedule.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[UnitOfWork]  - Need to confirm what this does
        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
        {
            var bookingNotificationSender = IocManager.Resolve<IBookingNotificationSender>();
            var appointmentsRepo = IocManager.Resolve<IRepository<CdmAppointment, Guid>>();

            Log.Info("Started...");

            var stats = new ScheduledJobStatistics();
            var numProcessed = 0;
            using (var session = Shesha.Services.StaticContext.IocManager.Resolve<ISessionFactory>().OpenSession())
            {
                // Retrieving list of missed appointments. It is considered missed if the Start time is more than 8 hours from the current time and status is still 'Booked'
                DbDataReader reader = GetReaderForAllMissedAppointments(session, DateTime.Now.Date.AddHours(-8));

                while (reader.Read())
                {
                    // Reads through the full results set record by record
                    var appointmentId = reader.GetGuid(0);

                    try
                    {
                        var appointment = appointmentsRepo.Get(appointmentId);
                        appointment.Status = RefListAppointmentStatuses.noshow;
                        await appointmentsRepo.UpdateAsync(appointment);
                        session.Flush();

                        stats.NumSuccess++;
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Failed to update missed appointment to 'No Show' for appointment Id:{appointmentId}", ex);
                        stats.NumFailed++;
                    }
                    finally
                    {
                        numProcessed++;
                        if (numProcessed % 100 == 0)    // Only logging every 100 messages to reduce overhead and flooding logs
                            Log.Info($"{numProcessed} appointments have been processed.");
                    }
                }
            }

            Log.Info($"All missed appointments have been processed - Updated: {stats.NumSuccess} | Failed: {stats.NumFailed} | Skipped: {stats.NumSkipped}");
        }


        private static DbDataReader GetReaderForAllMissedAppointments(ISession session, DateTime cutoffDate)
        {
            var connection = session.Connection;
            var command = connection.CreateCommand();
            command.CommandText = SQL_SELECT_MISSED_APPOINTMENTS;
            AddParameter(command, "@cutoffDate", cutoffDate);

            var reader = command.ExecuteReader();
            return reader;
        }

        private static void AddParameter(DbCommand command, string paramName, object paramValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            command.Parameters.Add(parameter);
        }

    }

}
