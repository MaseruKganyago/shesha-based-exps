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
    [Migration(20211023131200)]
    public class M20211023131200 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            var roles = new RoleInfos()
            {
                { "Ward Clerk", "Cdm", "Responsible for a variety of clerical and administrative duties related to patient care in a clinic or hospital ward." },
                { "Nurse", "Cdm", "A person who is trained to care for sick or injured people and who usually works in a hospital." },
                { "Unit Manager", "Cdm", "Are healthcare professionals who supervise and direct nurses, staff and patients within their assigned unit, hospital wing or floor" },
                { "Matron", "Cdm", "A very senior or the chief nurse." },
                { "Nursing Manager/Clinical Services Manager", "Cdm", "Are responsible for supervising nursing staff in a hospital or clinical setting." },
                { "HIS Team Members", "Cdm", "Members of the Hospital Information Management." },
                { "HIS Manager", "Cdm", "Manager of the Hospital Information Management" },
                { "CEO", "Cdm", "primary responsibilities include making major corporate decisions, managing the overall operations and resources of a company, acting as the main point of communication between the board of directors (the board) and corporate" },
                { "Case Management", "Cdm", "Manages all cases that arise with the hospital." },
                { "System Administrator", "Cdm", "Is responsible for all system administrative functions" }
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

