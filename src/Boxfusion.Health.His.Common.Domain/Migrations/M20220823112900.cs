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
    [Migration(20220823112900)]
    public class M20220823112900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Alter.Table("Fhir_Encounters")
                 .AddForeignKeyColumn("His_BedId", "Core_Facilities")
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
