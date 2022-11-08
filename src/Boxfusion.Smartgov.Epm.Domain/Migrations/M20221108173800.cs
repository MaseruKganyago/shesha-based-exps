using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221108173800)]
	public class M20221108173800 : Migration
	{
		public override void Up()
		{
			Create.Table("Epm_AllowableChildComponentTypes")
				.WithIdAsGuid()
				.WithFullAuditColumns()
				.WithForeignKeyColumn("ParentComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithForeignKeyColumn("ChildComponentTypeId", "Epm_ComponentTypes").Nullable()
				.WithColumn("CanBeRoot").AsBoolean(); ;


		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
