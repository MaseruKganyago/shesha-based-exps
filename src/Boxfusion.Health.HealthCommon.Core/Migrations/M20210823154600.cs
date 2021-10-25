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
    [Migration(20210823154600)]
    public class M20210823154600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
CREATE OR ALTER FUNCTION [dbo].[GetReferralLetterInfo]
(
	@OrganisationId UNIQUEIDENTIFIER,
	@FacilityId UNIQUEIDENTIFIER,
	@PractitionerId UNIQUEIDENTIFIER
)
RETURNS TABLE
AS
RETURN
( SELECT 
(org.Fhir_PrimaryContactTelephone) AS ContactDetail,
(ISNULL(CAST(addr.AddressLine1 AS NVARCHAR(200)),'') + ', ' + ISNULL(CAST(addr.AddressLine2 AS NVARCHAR(200)),'') + ', ' + ISNULL(CAST(addr.Suburb AS NVARCHAR(100)), '') + ISNULL(CAST(addr.Suburb AS NVARCHAR(255)), '') + ', ' + ISNULL(CAST(addr.Town AS NVARCHAR(100)), '') + ', ' + ISNULL(CAST(addr.Fhir_District AS NVARCHAR(255)), '') + ', ' + ISNULL(CAST(addr.Fhir_State AS NVARCHAR(255)), '') + ', ' + ISNULL(CAST(addr.Fhir_Country AS NVARCHAR(255)), '') + ', ' + ISNULL(CAST(addr.POBox AS NVARCHAR(10)), '')) AS PhysicalAddress,
(fac.[Name]) AS EvaluationLocation,
qual.CodeLkp,
insti.[Name] AS QualificationIssuerName
FROM Core_Organisations org 
inner join Core_Facilities fac on fac.OwnerOrganisationId = @OrganisationId
left join Core_Addresses addr on addr.Fhir_OwnerId = cASt(@OrganisationId AS NVARCHAR(255))
left join Fhir_Qualifications qual on qual.OwnerId = cASt(@PractitionerId AS NVARCHAR(255))
left join Core_Organisations insti on insti.Id = qual.IssuerId 
WHERE org.Id = @OrganisationId and fac.Frwk_Discriminator = 'Fhir.Hospital'
)
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

