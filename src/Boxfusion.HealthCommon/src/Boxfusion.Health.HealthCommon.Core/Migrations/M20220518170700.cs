using FluentMigrator;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    [Migration(20220518170700)]
    public class M20220518170700 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(@"alter table Fhir_Slots add RemainingCapacity as coalesce(RegularCapacity, 0) + coalesce(OverflowCapacity, 0) - [dbo].[fn_Book_GetNumValidAppointmentsForSlot]([Id]) ");
        }
    }
}
