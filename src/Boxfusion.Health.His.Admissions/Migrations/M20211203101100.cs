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
    [Migration(20211203101100)]
    public class M20211203101100 : Migration
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
            (NEWID(),'His','Approver Level 1','Views and approves ward report',1,1,0,0,0,1,0,0,1),
			(NEWID(),'His','Approver Level 2','Views and approves ward report',1,1,0,0,0,1,0,0,1)
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

