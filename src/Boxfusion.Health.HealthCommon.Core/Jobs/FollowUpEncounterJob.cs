using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Helpers;
using Shesha.Scheduler;
using Shesha.Scheduler.Attributes;
using Shesha.Scheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Jobs
{
	/// <summary>
	/// 
	/// </summary>
	[ScheduledJob("7706c9f9-f1fb-4995-9557-bc7886d1e115", StartUpMode.Automatic, "1 2 * * *")]
	public class FollowUpEncounterJob: ScheduledJobBase, ITransientDependency
	{
		/// <summary>
		/// 
		/// </summary>
		public FollowUpEncounterJob()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public override async Task DoExecuteAsync(CancellationToken cancellationToken)
		{
			await ConsultationEncounterUtilityHelper.SendFollowUpPushNotification();
		}
	}
}
