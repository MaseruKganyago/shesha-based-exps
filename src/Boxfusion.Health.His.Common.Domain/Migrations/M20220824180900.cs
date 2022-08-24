using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Migrations
{
    
    [Migration(20220824180900)]
    public class M20220824180900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {       
            Alter.Table("Fhir_Encounters")
                .AddColumn("His_Physician").AsString().Nullable();
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
