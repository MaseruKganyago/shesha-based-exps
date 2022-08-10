using FluentMigrator;
using Shesha;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211217070900)]
    public class M20211217070900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Execute.Sql(@"
               CREATE OR ALTER     View [dbo].[vw_UserItems]
                AS
                SELECT 
	                pers.Id
	                ,LastName
	                ,FirstName
	                ,(SELECT super.FirstName + ' ' + super.LastName FROM Core_Persons super WHERE super.Id = pers.SupervisorId and super.IsDeleted = 0 ) AS Supervisor
	                ,users.UserName
	                ,Appointment.His_HospitalId AS HospitalId

                FROM Core_Persons pers 
                LEFT JOIN AbpUsers users on users.Id = pers.UserId
                INNER JOIN Core_ShaRoleAppointments Appointment WITH (NOLOCK)
	                ON Appointment.PersonId = pers.Id
                WHERE pers.Frwk_Discriminator not like '%Patient%' 
                AND pers.IsDeleted = 0 AND users.IsDeleted = 0
                AND Appointment.IsDeleted = 0 AND Appointment.Frwk_Discriminator = 'His.HospitalRoleAppointedPerson'
GO

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
