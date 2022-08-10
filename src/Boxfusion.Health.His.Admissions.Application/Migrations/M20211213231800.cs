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
    [Migration(20211213231800)]
    public class M20211213231800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"               
                CREATE OR ALTER   View [dbo].[vw_WardItems]
                AS
                SELECT 
                    Id
	                ,Fhir_SpecialityLkp AS SpecialityLkp
	                ,[Name]
	                ,[Description]
	                ,Fhir_NumberOfBeds AS NumberOfBeds
	                ,[OwnerOrganisationId] AS HospitalId
                FROM Core_Facilities
                WHERE IsDeleted = 0 AND OwnerOrganisationId is not null
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

