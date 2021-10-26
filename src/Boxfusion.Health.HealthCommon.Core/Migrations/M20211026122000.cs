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
    [Migration(20211026122000)]
    public class M20211026122000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
					Create OR ALTER View vw_WardItems
					as
                    select 
                        Id
	                    ,Fhir_SpecialityLkp as SpecialityLkp
	                    ,[Name]
	                    ,[Description]
	                    ,Fhir_NumberOfBeds as NumberOfBeds
	                from Core_Facilities
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

