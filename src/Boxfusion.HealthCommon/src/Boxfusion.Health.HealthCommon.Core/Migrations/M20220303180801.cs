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
    [Migration(20220303180801)]
    public class M20220303180801 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
				ALTER TABLE Fhir_Slots DROP COLUMN IF EXISTS RemainingCapacity
                GO

				DROP FUNCTION IF EXISTS [dbo].[fn_Book_GetNumValidAppointmentsForSlot]
				GO

				CREATE FUNCTION [dbo].[fn_Book_GetNumValidAppointmentsForSlot] (@SlotId uniqueidentifier)  
                RETURNS int
                AS  
                BEGIN  
                    DECLARE @AppointmentCount int;

                    SELECT @AppointmentCount = COUNT(Id)
	                FROM Fhir_Appointments app 
	                WHERE app.SlotId = @SlotId 
		                AND app.StatusLkp NOT IN (6 /*cancelled*/, 8 /*enteredInerror*/)

                    RETURN @AppointmentCount;
                END;
                GO
				
                ALTER TABLE Fhir_Slots ADD RemainingCapacity AS Capacity - dbo.fn_Book_GetNumValidAppointmentsForSlot(Id);
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

