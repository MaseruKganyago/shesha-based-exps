using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220927120700)]
    public class M20220927120700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"Create or Alter Procedure sp_His_AddRoomAndBedToWardAdmission
@admissionId uniqueIdentifier,
@roomId uniqueIdentifier,
@bedId uniqueIdentifier
As
SET NOCOUNT ON;
	Update Fhir_Encounters set His_RoomId = @roomId, His_BedId = @bedId where Id = @admissionId

  select Id,
  His_WardAdmissionNumber WardAdmissionNumber,
  His_AdmissionTypeLkp AdmissionType,
  His_AdmissionStatusLkp AdmissionStatus,
  StartDateTime,
  His_RoomId,
  His_BedId
  PartOfId from Fhir_Encounters
  where Id = @admissionId
  Go");
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
