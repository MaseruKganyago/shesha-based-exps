using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220812123900)]
    public class M20220812123900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {  
            Alter.Table("Core_Facilities")
                .AddColumn("His_BedName").AsString(30).Nullable()
                .AddColumn("His_BedDescription").AsString(30).Nullable()
                .AddForeignKeyColumn("His_BedTypeId", "His_BedTypes");
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
