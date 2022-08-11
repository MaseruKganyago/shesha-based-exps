using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Migrations
{
    
    [Migration(20220811151100)]
    public class M20220811151100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {       
            Alter.Table("Core_Organisations")
                .AddColumn("Hough_FacilityPracticeNumber").AsString().Nullable()
                .AddForeignKeyColumn("Hough_DistrictId", "Core_Areas");
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
