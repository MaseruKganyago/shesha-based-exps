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
    [Migration(20220819113200)]
    public class M20220819113200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {  
            Alter.Table("Core_Facilities")
                .AddForeignKeyColumn("His_RoomId", "Core_Facilities");
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
