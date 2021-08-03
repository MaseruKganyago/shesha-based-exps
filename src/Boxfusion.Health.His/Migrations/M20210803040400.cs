using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Migrations
{
    [Migration(20210803040400)]
    public class M20210803040400 : Migration
    {
        public override void Up()
        {
            var roles = new RoleInfos()
            {
                { "System Administrator", "His", "Can access certain administrative functions required for the general monitoring and maintenance of the system (e.g. Log audit trails, Scheduled Jobs Maintenance, Notification templates)" },
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
