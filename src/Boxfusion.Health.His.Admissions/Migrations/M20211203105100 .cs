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
    [Migration(20211203105100)]
    public class M20211203105100 : Migration
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
                    (NEWID(),'His','Manager','View Facility Reports. Views reports and stats',1,1,0,0,0,1,0,0,0),
			        (NEWID(),'His','Viewer','Views daily and monthly reports and stats',1,1,0,0,0,1,0,0,0),
			        (NEWID(),'His','Capturer','Admits and Separates patients and Submits reports/registers for Approval',1,1,0,0,0,1,0,0,0),
			        (NEWID(),'His','Facility Admin','Configures users, wards, speciality, and facility info',1,1,0,0,0,1,0,0,0)
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

