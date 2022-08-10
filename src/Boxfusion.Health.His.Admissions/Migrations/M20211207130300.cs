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
    [Migration(20211207130300)]
    public class M20211207130300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
		        INSERT INTO Core_ShaRoles 
                    (Id,NameSpace,Name,Description,CanAssignToMultiple,CanAssignToPerson,CanAssignToOrganisationRoleLevel,CanAssignToRole,
                    CanAssignToUnit,HardLinkToApplication,IsProcessConfigurationSpecific,SortIndex,IsRegionSpecific) 
                VALUES 
                    (NEWID(),'His','Global Admin','Global Admin',1,1,0,0,0,1,0,0,0)
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

