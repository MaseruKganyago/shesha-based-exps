using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220829160500)]
    public class M20220829160500 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
			if (!Schema.Table("entpr_PriceLists").Column("His_ClassificationTypeLkp").Exists())
				Alter.Table("entpr_PriceLists")
					.AddColumn("His_ClassificationTypeLkp").AsInt64().Nullable();
		}

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
