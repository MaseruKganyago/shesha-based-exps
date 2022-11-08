using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108163300)]
	public class MM20221108163300 : Migration
	{
		public override void Up()
		{
			Create.Table("Epm_PerformanceReportTemplates")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString(200).Nullable()
				.WithColumn("ShortName").AsString(20).Nullable()
				.WithColumn("Description").AsString(2000).Nullable()
				.WithColumn("PeriodTypeCoveredLkp").AsInt64().Nullable()
				.WithColumn("ProgressReportingCycleLkp").AsInt64().Nullable()
				.WithColumn("AdminPermission").AsString(100).Nullable()
				.WithColumn("ProcessManagerPermission").AsString(100).Nullable();

			//Here will include refList migration
			this.Shesha().ReferenceListUpdate("Shesha.Enterprise", "PeriodType")
				.AddItem(1, "Financial Year", 1, "Financial Year")
				.AddItem(2, "MTSF", 2, "Medium Term Strategic Framework - 5 Year reporting cycle dictated centrally by National Treasury that specifies the reporting cycles for the Strategic Plans")
				.AddItem(3, "Month", 3, "Month")
				.AddItem(4, "Financial Quarter", 4, "Financial Quarter");

			Create.Table("Epm_PerformanceReportAllowedComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("PerformanceReportTemplateId", "Epm_PerformanceReportTemplates").Nullable()
				.WithForeignKeyColumn("ComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithColumn("CanBeRoot").AsBoolean();

		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
