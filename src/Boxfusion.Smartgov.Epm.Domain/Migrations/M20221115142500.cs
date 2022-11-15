
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221115142500)]
	public class M20221115142500 : Migration
	{
		public override void Up()
		{
			Alter.Table("Epm_Components")
				.AddColumn("KPITypeLkp").AsInt64().Nullable();
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
