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
    [Migration(20220812130600)]
    public class M20220812130600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {  
            Alter.Table("Core_Facilities")
                .AddColumn("His_RoomName").AsString(30).Nullable()
                .AddColumn("His_RoomDescription").AsString(30).Nullable()
                .AddColumn("His_NumberOfBeds").AsInt32().Nullable()
                .AddColumn("His_RoomTypeLkp").AsInt64().Nullable();
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
