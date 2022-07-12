using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220704122200)]
    public class M20220704122200 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(@"
CREATE or ALTER PROCEDURE His_AddAdmissionTestData
@ServiceProviderId uniqueIdentifier, @WardId uniqueIdentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  declare @hospitalAdmissionId uniqueIdentifier;

  --Create hospital admission
  insert into Fhir_Encounters (Id, ServiceProviderId, His_HospitalAdmissionNumber, StartDateTime, His_HospitalAdmissionStatusLkp, Frwk_Discriminator)
  values (NEWID(), @ServiceProviderId, 'UnitTestData: 12345', DATEADD(HOUR, 2, GETUTCDATE()), 1, 'UnitTestData: 12345')
  set @hospitalAdmissionId = (select Id from Fhir_Encounters where His_HospitalAdmissionNumber = 'UnitTestData: 12345' and Frwk_Discriminator = 'UnitTestData: 12345')

  --Create ward admission
  insert into Fhir_Encounters (Id, His_WardId, ServiceProviderId, StartDateTime, His_AdmissionStatusLkp, His_WardAdmissionNumber, His_AdmissionTypeLkp, Frwk_Discriminator)
  values (NEWID(), @WardId, @ServiceProviderId, DATEADD(HOUR, 2, GETUTCDATE()), 1, 'UnitTestData: 12345', 1, 'His.WardAdmission')

  select * from Fhir_Encounters where His_WardAdmissionNumber = 'UnitTestData: 12345' and Frwk_Discriminator = 'His.WardAdmission'
END
GO
");
        }
    }
}
