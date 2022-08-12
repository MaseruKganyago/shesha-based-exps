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
    [Migration(20220308074601)]
    public class M20220308074601 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
				ALTER TABLE Fhir_Slots DROP COLUMN IF EXISTS RemainingCapacity
                GO

				ALTER TABLE Fhir_Slots DROP COLUMN IF EXISTS NumValidAppointments
                GO
                
                ALTER TABLE Fhir_Slots ADD NumValidAppointments AS dbo.fn_Book_GetNumValidAppointmentsForSlot(Id);
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

