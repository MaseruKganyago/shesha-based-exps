using Abp.Domain.Repositories;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Shesha.Domain;
using Shesha.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports
{
	/// <summary>
	/// 
	/// </summary>
	public class OutstandingReportSpecification : ShaSpecification<ComponentProgressReport>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<ComponentProgressReport, bool>> BuildExpression()
		{
			var personRepo = IocManager.Resolve<IRepository<Person, Guid>>();
			var currentPerson = personRepo.GetAll().FirstOrDefault(a => a.User.Id == AbpSession.UserId);

			return report => report.ProgressReportStatus == (long?)RefListNodeProgressReportStatus.Outstanding
			&& report.Component.ResponsibleReporting.Id == currentPerson.Id;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class AwaitingLevelOneQAReportSpecification : ShaSpecification<ComponentProgressReport>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<ComponentProgressReport, bool>> BuildExpression()
		{
			var personRepo = IocManager.Resolve<IRepository<Person, Guid>>();
			var currentPerson = personRepo.GetAll().FirstOrDefault(a => a.User.Id == AbpSession.UserId);

			return report => report.ProgressReportStatus == (long?)RefListNodeProgressReportStatus.AwaitingLevelOneQA
			&& report.Component.ResponsibleReporting.Id == currentPerson.Id;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class AwaitingLevelTwoQAReportSpecification : ShaSpecification<ComponentProgressReport>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override Expression<Func<ComponentProgressReport, bool>> BuildExpression()
		{
			var personRepo = IocManager.Resolve<IRepository<Person, Guid>>();
			var currentPerson = personRepo.GetAll().FirstOrDefault(a => a.User.Id == AbpSession.UserId);

			return report => report.ProgressReportStatus == (long?)RefListNodeProgressReportStatus.AwaitingLevelTwoQA
			&& report.Component.ResponsibleReporting.Id == currentPerson.Id;
		}
	}
}
