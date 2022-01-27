using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using Shesha.FluentMigrator;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220125225300)]
    public class M20220125225300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            var roles = new RoleInfos()
            {
                { "Schedule Manager", "Health Appointment Booking", "" },
                { "Schedule Fulfiller", "Health Appointment Booking", "" },
                { "Booking Management Administrator", "Health Appointment Booking", "" }
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

        /// <summary>
        /// 
        /// </summary>
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

