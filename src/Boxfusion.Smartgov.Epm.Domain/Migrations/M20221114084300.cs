
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221114084300)]
	public class M20221114084300 : Migration
	{
		public override void Up()
		{
			Rename.Column("LatestRAGValueLkp").OnTable("Epm_Components").To("FinalRAGValueLkp");
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
