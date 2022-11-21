
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
	[Migration(20221121191000)]
	public class M20221121191000 : Migration
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
cmpPrgReport.Id,
temp.Name as TemplateName,
period.Name as PeriodCoveredName,
comp.Name as Name,
cmpPrgReport.ProgressReportStatusLkp
from Epm_ComponentProgressReports cmpPrgReport
	join Epm_Components comp on comp.Id = ComponentId
	join Epm_ProgressReports prgReport on prgReport.Id = ProgressReportId
	join entpr_Periods period on period.Id = prgReport.PeriodCoveredId
		left join Epm_PerformanceReports perfReport on perfReport.Id = prgReport.PerformanceReportId
			left join Epm_PerformanceReportTemplates temp on temp.Id = perfReport.TemplateId
			GO");
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
