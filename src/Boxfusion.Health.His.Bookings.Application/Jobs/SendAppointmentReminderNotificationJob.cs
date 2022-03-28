//using Abp.Dependency;
//using Abp.Domain.Repositories;
//using Boxfusion.Health.Cdm.Appointments;
//using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
//using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
//using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
//using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
//using Boxfusion.Health.HealthCommon.Core.Helpers;
//using Boxfusion.Health.His.Bookings.Domain;
//using Boxfusion.Health.His.Bookings.Notifications;
//using Castle.Core.Logging;
//using NHibernate;
//using NHibernate.Linq;
//using NHibernate.Transform;
//using Shesha.Scheduler;
//using Shesha.Scheduler.Attributes;
//using Shesha.Scheduler.Domain.Enums;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Boxfusion.Health.His.Bookings.Jobs
//{
//    /// <summary>
//    /// Sends reminders of appointments the day before the appointments.
//    /// </summary>
//    [ScheduledJob("9bc54591-55fb-4e2e-91b6-199cb9c187d0",
//        StartUpMode.Automatic, "0 2 * * *",
//        description: "Sends reminders of appointments the day before the appointments.")
//        ]
//    public class SendAppointmentReminderNotificationJob : ScheduledJobBase, ITransientDependency
//    {
//        private readonly BookingSlotsGenerator _bookingSlotsGenerator;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="generateBookingSlots"></param>
//        public SendAppointmentReminderNotificationJob(BookingSlotsGenerator bookingSlotsGenerator)
//        {
//            _bookingSlotsGenerator = bookingSlotsGenerator;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="cancellationToken"></param>
//        /// <returns></returns>
//        /// 
//        //[UnitOfWork]  - Need to confirm what this does
//        public override async Task DoExecuteAsync(CancellationToken cancellationToken)
//        {
//            const int batchSize = 20;
//            var bookingNotificationSender = IocManager.Resolve<IBookingNotificationSender>();
//            var appointmentsRepo = IocManager.Resolve<IRepository<CdmAppointment, Guid>>();

//            try
//            {
//                // Batching notifications 


//                //TODO: Update job stats
//                //TOOD: Consider sending notification from DataReader
//                // TODO: Handle Infinite loops???

//                Log.Info("Started...");

//                while (true)
//                {
//                    var appointmentsToNotify = GetAppointmentsStillToNotify(DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2), NotificationTemplateIds.AppointmentReminder, batchSize);
//                    foreach (var id in appointmentsToNotify)
//                    {
//                        var app = appointmentsRepo.Get(id);

//                        try
//                        {
//                            await bookingNotificationSender.NotifyAppointmentReminderAsync(app);
//                        }
//                        catch (Exception e)
//                        {
//                            // TOOD: Log and update stats
//                        }
//                    }

//                    if (appointmentsToNotify.Count == 0)
//                    {
//                        Log.Info($"No more notifications to be sent...");
//                        break;
//                    }
//                    else if (appointmentsToNotify.Count == batchSize)
//                    {
//                        Log.Info($"Batch of {batchSize} notifications sent...");
//                    }
//                    else
//                    {
//                        Log.Info($"Last batch of {appointmentsToNotify.Count} notifications sent...");
//                        break;
//                    }
//                }

//            }
//            catch (Exception e)
//            {
//                Log.Fatal($"Error occured whilst attempting to send reminder notifications.", e);
//            }
//        }


//        private const string SQL = @"SELECT TOP @maxResults Id 
//                                        FROM 
//                                            Fhir_Appointments 
//                                        WHERE 
//                                                IsDeleted = 0
//                                            AND StatusLkp = 3 /*Booked*/
//                                            AND [Start] >= @fromDate AND [Start] < @toDate
//                                            AND 
//                                                Id NOT IN (SELECT EntityId  FROM AbpTenantNotifications 
//                                                        WHERE NotificationName = @templateId)
//                                    ";

//        /// <summary>
//        /// Returns the list of Ids for Appointments Booked between a specified dated which have yet to be notified using the specified templateId.
//        /// </summary>
//        /// <param name="appointmentsFrom"></param>
//        /// <param name="appointmentsTo"></param>
//        /// <param name="templateId">Notification template Id.</param>
//        /// <param name="maxResults">The maximum number of records to be.</param>
//        /// <returns></returns>
//        private List<Guid> GetAppointmentsStillToNotify(DateTime appointmentsFrom, DateTime appointmentsTo, Guid templateId, int maxResults)
//        {
//            var list = new List<Guid>();

//            using (var session = IocManager.Resolve<ISessionFactory>().OpenSession())
//            {
//                var connection = session.Connection;
//                var command = connection.CreateCommand();
//                command.CommandText = SQL;
//                AddParameter(command, "@fromDate", appointmentsFrom);
//                AddParameter(command, "@toDate", appointmentsTo);
//                AddParameter(command, "@templateId", templateId);
//                AddParameter(command, "@maxResults", maxResults);

//                var reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    // Reads through the full results set record by record
//                    list.Add(reader.GetGuid(0));
//                }
//            }

//            return list;
//        }

//        private static void AddParameter(DbCommand command, string paramName, object paramValue)
//        {
//            var parameter = command.CreateParameter();
//            parameter.ParameterName = paramName;
//            parameter.Value = paramValue;
//            command.Parameters.Add(parameter);
//        }

//        /// TODO:
//        /// DOCUMENTATION:
//        ///     Specify how it handles interuptions
//        ///     HangFire
//        ///     HangFire dashboard
//        ///
//        /// Need to implement OnSuccess and OnFail Abp Event notifictions - perhaps even on UpdateJobStats, OnLogUpdate
//        /// Should we not allow overriding OnSuccess and OnFail
//        /// LogFile seems to be HardCoded to AppData/ which cause issues for long-term storage and storage on Azure:
//        ///   - Should be able to specify log file location as part of the JobConfig
//        ///   - One option should be to save as StoredFile in specified folder - this would then allow allow take advantage of whatever storage options the application has and any other file management capabilities of the application (will be building these out further in the future) 
//        /// Should return and save high-level information/stats (e.g. NumNotificationsSent, NumNotificationsSkipped ) as part of the ExecutionRecord so that there is easy visibility.
//        ///   - To remain flexible should save as Json
//        ///   - Allow specifying a form to render the info on the UI
//        ///   - JobStats type can be specified as a Generic on ScheduledJobBase
//        /// Need to enhance the ScheduledJob viewer to display the JobStatus ideally in real-time. Should be able to:
//        ///   - Display job status (Running, Finished, Cancelled, Error)
//        ///   - Display job stats
//        ///   - View job log in real-time (SignalR)
//        ///   - View Log File
//        /// 
//        /// May want to implement an Admin Tasks/Alerts log where can log issues that might need to be responded to:
//        ///   1) Can then action and mark accordingly
//        ///   2) Ignore similar in future
//        ///   GUIDANCE:
//        ///     Don't wrap in Exception Handling as it is already handled
//        ///     Rather override OnSuccess and OnFail
//        ///     
//        /// Move HangfireAuthorizationFilter out of (His/Project specific and into Shesha but protected by specific Permission)
//        ///     
//        /// NOTIFICATIONS:
//        ///    - Log where attempted but no pre-requisites - 'Pre-Validation' failed (e.g. mobile number does not exist or invalid)
//        ///    - Need to add where 

//    }
//}
