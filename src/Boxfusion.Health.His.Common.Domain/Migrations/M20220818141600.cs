﻿using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220818141600)]
    public class M20220818141600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {  
            Alter.Table("Core_Facilities")
                .AddColumn("His_Ward").AsString(30).Nullable()
                .AddForeignKeyColumn("His_WardId", "Core_Facilities");
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
