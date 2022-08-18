using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220818161200)]
    public class M20220818161200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
<<<<<<<< HEAD:src/Boxfusion.HealthCommon/src/Boxfusion.Health.HealthCommon.Core/Migrations/M20220818161200.cs
            Alter.Table("Core_Organisations")
                .AddColumn("Fhir_TypeLkp").AsInt64().Nullable();
========
            //Alter.Table("Core_Organisations")
            //    .AddColumn("Fhir_FacilityTypeLkp").AsInt64().Nullable();
>>>>>>>> 4199eab2ef3b533178c4f9f5dabf6b1ccde2d7b9:src/Boxfusion.HealthCommon/src/Boxfusion.Health.HealthCommon.Core/Migrations/M20220818145600.cs
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
