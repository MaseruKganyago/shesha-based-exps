
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	[Migration(20221109173400)]
	public class M20221109173400 : Migration
	{
		public override void Up()
		{
			this.Shesha().ReferenceListUpdate("Shesha.Enterprise", "PeriodType")
				.AddItem(1, "Financial Year", 1, "Financial Year")
				.AddItem(2, "MTSF", 2, "Medium Term Strategic Framework - 5 Year reporting cycle dictated centrally by National Treasury that specifies the reporting cycles for the Strategic Plans")
				.AddItem(3, "Month", 3, "Month")
				.AddItem(4, "Financial Quarter", 4, "Financial Quarter");
		}

		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
