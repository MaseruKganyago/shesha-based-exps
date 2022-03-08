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
    [Migration(20211219213000)]
    public class M20211219213000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
					Create OR ALTER View vw_HospitalItems
					as
                    select 
	                    [Name]
	                    ,org.Fhir_FacilityTypeLkp as TypeLkp
	                    ,(addr.Fhir_FullAddress1) as [Address]
	                    ,addr.Latitude
	                    ,addr.Longitude
	                    ,org.Fhir_PrimaryContactTelephone as PrimaryContactTelephone
	                    ,org.Id
                    from Core_Organisations org
                    left join Core_Addresses addr on  cast(addr.Fhir_OwnerId as uniqueidentifier)  = org.Id 
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
