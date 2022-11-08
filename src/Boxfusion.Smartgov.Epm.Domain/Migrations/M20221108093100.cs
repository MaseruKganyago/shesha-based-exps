using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108093100)]
	public class M20221108093100: Migration
	{
		public override void Up()
		{
			//Boxfusion.Smartgov.Epm.Domain.ComponentType
			Create.Table("Epm_ComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("Caption").AsString().Nullable()
				.WithColumn("Description").AsString().Nullable()
				.WithColumn("Icon").AsString().Nullable()
				.WithColumn("AdminTreeCreateForm").AsString().Nullable()
				.WithColumn("AdminTreeDetailsForm").AsString().Nullable()
				.WithColumn("AdminTreeUpdateForm").AsString().Nullable()
				.WithColumn("ViewerTreeDetailsForm").AsString().Nullable()
				.WithColumn("IsIndicator").AsBoolean()
				.WithColumn("ShowInAdminTree").AsBoolean()
				.WithColumn("ShowInViewerTree").AsBoolean()
				.WithColumn("ProgressReportingRequired").AsBoolean()
				.WithColumn("ProgressDetailsSubForm").AsString()
				.WithColumn("ProgressQA1Required").AsBoolean()
				.WithColumn("ProgressQA2Required").AsBoolean()
				.WithColumn("ProgressAuditRequired").AsBoolean();

			Create.Table("Epm_PerformanceReports")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithColumn("Name").AsString().Nullable()
				.WithColumn("ShortName").AsString().Nullable()
				.WithColumn("StatusLkp").AsInt64().Nullable()
				.WithForeignKeyColumn("TemplateId", "Epm_PerformanceReports").Nullable()
			    .WithForeignKeyColumn("PeriodCoveredId", "Core_Periods").Nullable();

		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
