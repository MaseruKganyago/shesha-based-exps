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
    [Migration(20220707171100)]
    public class M20220707171100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Execute.Sql(@"
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create or alter view vw_His_FlattenedPractitioner
as
select [practitioner].Id 
		, [practitioner].FirstName
		, [practitioner].LastName
		, [practitioner].MobileNumber1
		, [practitioner].EmailAddress1
		, [user].UserName
		, [user].IsActive
		, [user].LastLoginDate
        , stuff((Select ',  ' + [org].[Name]
			from Core_Organisations [org]
			inner join Core_ShaRoleAppointments [roles] on [roles].His_HospitalId = org.Id
			where [roles].PersonId = [practitioner].Id
			for xml path('')), 1, 1, '') [FacilityNames]
from Core_Persons [practitioner]
inner join AbpUsers [user] on [user].id = [practitioner].userid
where [practitioner].Frwk_Discriminator = 'His.HisPractitioner'
	and [practitioner].IsDeleted = 0
group by [practitioner].Id
		, [practitioner].FirstName
		, [practitioner].LastName
		, [practitioner].MobileNumber1
		, [practitioner].EmailAddress1
		, [user].UserName
		, [user].IsActive
		, [user].LastLoginDate
go");

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
