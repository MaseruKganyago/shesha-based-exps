using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentMigrator;
    using Shesha.FluentMigrator;

    namespace Boxfusion.Health.His.Admissions.Migrations
    {
        [Migration(20210613014500)]
        public class M20210613014500 : Migration
        {
            public override void Up()
            {
                var roles = new RoleInfos()
            {
                { "System Administrator", "HealthDomain", "Can access certain administrative functions required for the general monitoring and maintenance of the system (e.g. Log audit trails, Scheduled Jobs Maintenance, Notification templates)" },
            };
                foreach (var role in roles)
                {
                    Execute.Sql(
                        @$"insert into Core_ShaRoles 
    (Id, 
    NameSpace, 
    Name, 
    Description, 
    CanAssignToMultiple, 
    CanAssignToPerson, 
    CanAssignToOrganisationRoleLevel,
    CanAssignToRole,
    CanAssignToUnit,
    HardLinkToApplication,
    IsProcessConfigurationSpecific,
    SortIndex) 
values 
    (NEWID(), 
    '{role.Namespace}', 
    '{role.Name}', 
    '{role.Description}', 
    1, 
    1, 
    0,
    0,
    0,  
    1,
    0,
    0)");
                }

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


            private class RoleInfo
            {
                public string Name { get; set; }
                public string Namespace { get; set; }
                public string Description { get; set; }
            }

            private class RoleInfos : List<RoleInfo>
            {
                public void Add(string name, string @namespace, string description)
                {
                    Add(new RoleInfo
                    {
                        Name = name,
                        Namespace = @namespace,
                        Description = description,
                    });
                }
            }

        }
    }

}
