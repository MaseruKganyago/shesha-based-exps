
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221110101200)]
	public class M20221110101200 : Migration
	{
		public override void Up()
		{
			#region Deleting ForeignKey TemplateId from Epm_PerformanceReports
			Delete.ForeignKey("FK_Epm_PerformanceReports_TemplateId_Epm_PerformanceReports_Id").OnTable("Epm_PerformanceReports");
			Delete.Index("IX_Epm_PerformanceReports_TemplateId").OnTable("Epm_PerformanceReports");
			Delete.Column("TemplateId").FromTable("Epm_PerformanceReports");
			#endregion

			Alter.Table("Epm_PerformanceReports")
				.AddForeignKeyColumn("TemplateId", "Epm_PerformanceReportTemplates");
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
