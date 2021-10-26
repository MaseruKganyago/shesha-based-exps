using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211026130600)]
    public class M20211026130600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
					Create OR ALTER View vw_SpecialityItems
					as
                    select 
                      Id
                      ,Fhir_SpecialityLkp as SpecialityLkp
                      ,count(*) as NumberOfBedsInSpeciality
                    from Core_Facilities group by Fhir_SpecialityLkp, Core_Facilities.Id
					");

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

