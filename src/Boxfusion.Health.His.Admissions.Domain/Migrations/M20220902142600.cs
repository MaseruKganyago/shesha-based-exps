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
    [Migration(20220902142600)]
    public class M20220902142600 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
             CREATE OR ALTER   PROCEDURE [dbo].[Sp_His_AddAdmissionTestData]
@ServiceProviderId uniqueIdentifier, @WardId uniqueIdentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  declare @hospitalAdmissionId uniqueIdentifier;

  --Create hospital admission
  insert into Fhir_Encounters (Id, ServiceProviderId, His_HospitalAdmissionNumber, StartDateTime, His_HospitalAdmissionStatusLkp, Frwk_Discriminator)
  values (NEWID(), @ServiceProviderId, 'UnitTestData: 12345', DATEADD(HOUR, 2, GETUTCDATE()), 1, 'His.HospitalAdmission')
  set @hospitalAdmissionId = (select Id from Fhir_Encounters where His_HospitalAdmissionNumber = 'UnitTestData: 12345' and Frwk_Discriminator = 'His.HospitalAdmission')

  --Create ward admission
  insert into Fhir_Encounters (Id, His_WardId, ServiceProviderId, PartOfId, StartDateTime, His_AdmissionStatusLkp, His_WardAdmissionNumber, His_AdmissionTypeLkp, Frwk_Discriminator)
  values (NEWID(), @WardId, @ServiceProviderId, @hospitalAdmissionId, DATEADD(HOUR, 2, GETUTCDATE()), 1, 'UnitTestData: 12345', 1, 'His.WardAdmission')

  select Id,
  His_WardAdmissionNumber WardAdmissionNumber,
  His_AdmissionTypeLkp AdmissionType,
  His_AdmissionStatusLkp WardAdmissionStatus,
  StartDateTime,
  PartOfId from Fhir_Encounters
  where His_WardAdmissionNumber = 'UnitTestData: 12345' and Frwk_Discriminator = 'His.WardAdmission'
END
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
