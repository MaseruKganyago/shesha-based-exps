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
    [Migration(20211026135300)]
    public class M20211026135300 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
					Create OR ALTER View vw_UserItems
					as
                    select 
	                    Id
	                    ,LastName
	                    ,FirstName
	                    ,(select super.FirstName + ' ' + super.LastName from Core_Persons super where super.Id = pers.SupervisorId ) as Supervisor
                    from Core_Persons pers
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

