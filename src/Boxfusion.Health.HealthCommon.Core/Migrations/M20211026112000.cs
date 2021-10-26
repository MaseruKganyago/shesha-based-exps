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
    [Migration(20211026112000)]
    public class M20211026112000 : Migration
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
	                    ,org.Fhir_TypeLkp as TypeLkp
	                    ,(addr.AddressLine1 + ' ' + addr.Suburb + ' ' + addr.Town + ' ' + ' ' + addr.Fhir_State + ' ' + addr.Fhir_Country + addr.POBox) as [Address]
	                    ,addr.Latitude
	                    ,addr.Longitude
	                    ,org.Fhir_PrimaryContactTelephone as PrimaryContactTelephone
	                    ,org.Id
                    from Core_Organisations org
                    left join Core_Addresses addr on addr.Fhir_OwnerId = convert(nvarchar(50), org.Id)
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

