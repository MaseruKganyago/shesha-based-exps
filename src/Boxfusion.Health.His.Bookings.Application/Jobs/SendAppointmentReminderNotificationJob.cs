using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.His.Bookings.Notifications;
using NHibernate;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Jobs
{
    /// <summary>
    /// Sends reminders of appointments the day before the appointments.
    /// </summary>
    [ScheduledJob("9bc54591-55fb-4e2e-91b6-199cb9c187d0",
        startupMode: StartUpMode.Manual,
        cronString: "0 2 * * *",  // Executes everyday at 2am
        description: "Sends reminders of appointments the day before the appointments.")
        ]
    public class SendAppointmentReminderNotificationJob : ScheduledJobBase, ITransientDependency
    {
        private const string SQL_SELECT_REMINDERS_TO_SEND = @"SELECT Id
                                                                FROM 
                                                                    Fhir_Appointments 
                                                                WHERE 
                                                                        IsDeleted = 0
                                                                    AND StatusLkp = 3 /*Booked*/
	                                                                And datediff(day, getdate(), [start]) = 1
	                                                                and HasReminderBeenSent = 0";

        /// <summary>
        /// 
        /// </summary>
        public SendAppointmentReminderNotificationJob() : base()
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
                // Retrieving list of notifications to be sent as a ADO.NET DataReader for improved performance as volumes may be significant
                DbDataReader reader = GetReaderForAllAppointmentsStillToNotify(session);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Reads through the full results set record by record

                        var appointmentId = reader.GetGuid(0);

                        try
                        {
                            var appointment = appointmentsRepo.Get(appointmentId);
                            await bookingNotificationSender.NotifyAppointmentReminderAsync(appointment);
                            stats.NumSuccess++;

                            // We have already notified this person. Update the flag.
                            appointment.HasReminderBeenSent = true;
                            await appointmentsRepo.UpdateAsync(appointment);
                            await UnitOfWorkManager.Current.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"Failed to send message for appointment Id:{appointmentId}", ex);
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
                else
                {
                    Log.Info("There is no data");
                }
            }

            Log.Info($"All appointments have been processed - Sent: {stats.NumSuccess} | Failed: {stats.NumFailed} | Skipped: {stats.NumSkipped}");
        }

        private static DbDataReader GetReaderForAllAppointmentsStillToNotify(ISession session)
        {
            // Since the SQL Query doesn't need parameters anymore, there's no need to pass in the 
            // parameters.
            var connection = session.Connection;
            var command = connection.CreateCommand();
            command.CommandText = SQL_SELECT_REMINDERS_TO_SEND;
            //AddParameter(command, "@fromDate", appointmentsFrom);
            //AddParameter(command, "@toDate", appointmentsTo);
            //AddParameter(command, "@templateId", templateId);

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


    // TOOD: Should be moved to a generic class at Shesha level see: https://dev.azure.com/boxfusion/Shesha%20Web%20v3.0/_workitems/edit/35770/
    public class ScheduledJobStatistics
    {
        public int NumSuccess { get; set; }
        public int NumSkipped { get; set; }
        public int NumFailed { get; set; }
    }
}
