
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	/// <summary>
	/// 
	/// </summary>
	[Migration(20221121183600)]
	public class M20221121183600 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			Execute.Sql(@"
CREATE or Alter   view vw_Epm_FlattenedComponentProgressReport
as
select
temp.Name as TemplateName,
period.Name as PeriodCoveredName,
comp.Name as Name,
ProgressReportStatusLkp
from Epm_ComponentProgressReports
	join Epm_Components comp on comp.Id = ComponentId
	join Epm_ProgressReports prgReport on prgReport.Id = ProgressReportId
	join entpr_Periods period on period.Id = prgReport.PeriodCoveredId
		left join Epm_PerformanceReports perfReport on perfReport.Id = prgReport.PerformanceReportId
			left join Epm_PerformanceReportTemplates temp on temp.Id = perfReport.TemplateId
			GO
");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
