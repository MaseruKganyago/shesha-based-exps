using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Migrations
{
    [Migration(20210803040500)]
    public class M20210803040500 : Migration
    {
        public override void Up()
        {
            Execute.Sql(
                @"insert into 
	Core_ShaRoleAppointments
	(id, RoleId, Frwk_Discriminator, PersonId, CreationTime, IsDeleted)
select
	NEWID(), r.Id, 1, p.Id, GETDATE(), 0
from
	Core_ShaRoles r
	inner join Core_Persons p on 1=1
	inner join AbpUsers usr on usr.Id = p.UserId and usr.UserName = 'admin'
where
	r.Name = 'System Administrator'
	and not exists (
		select 
			1 
		from 
			Core_ShaRoleAppointments t
		where 
			t.RoleId = r.Id
			and t.PersonId = p.Id
	)");
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
