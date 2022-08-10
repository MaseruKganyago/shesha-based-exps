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
    [Migration(20211213123400)]
    public class M20211213123400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
                CREATE OR ALTER   View [dbo].[vw_SpecialityItems]
                AS
	                SELECT 
		                NEWID()  Id,
		                OwnerOrganisationId AS HospitalId,
		                SUM([Fhir_NumberOfBeds]) AS NumberOfBedsInSpeciality
	                   ,[Fhir_SpecialityLkp] AS SpecialityLkp
	                FROM [dbo].[Core_Facilities]
	                WHERE IsDeleted = 0 
	                GROUP BY Fhir_SpecialityLkp, OwnerOrganisationId
                GO
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

