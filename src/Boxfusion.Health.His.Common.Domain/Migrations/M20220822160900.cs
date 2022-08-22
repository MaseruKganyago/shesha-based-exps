using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220822160900)]
    public class M20220822160900 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
Create or Alter View vw_His_FlattenedHospitalAdmissions
AS
select
patient.Id,
patient.Fhir_IdentificationTypeLkp,
IdentityNumber,
DateOfBirth,
FirstName,
LastName,
MobileNumber1,
Fhir_NationalityLkp,
GenderLkp,
His_HospitalPatientNumber,
hospAdm.Id as HospitalAdmissionId,
hospAdm.His_HospitalAdmissionNumber,
hospAdm.StartDateTime,
--hospAdm.His_AdmissionTypeLkp,
hospAdm.EndDateTime,
hospAdm.His_ClassificationLkp,
ward.Id WardAdmissionId,
ward.Name as WardName,
wardAdm.His_AdmissionStatusLkp as WardAdmissionStatus,
iif(hospAdm.His_AdmissionStatusLkp != 1, DATEDIFF(day, hospAdm.StartDateTime, hospAdm.EndDateTime), DATEDIFF(day, hospAdm.StartDateTime, DateAdd(hour, 2, GETUTCDATE()))) as LOS
from Core_Persons patient 
join Fhir_Encounters hospAdm on hospAdm.SubjectId = patient.Id and hospAdm.Frwk_Discriminator = 'His.HospitalAdmission'
left join Fhir_Encounters wardAdm on wardAdm.SubjectId = patient.Id and wardAdm.Frwk_Discriminator = 'His.WardAdmission'
left join Core_Facilities ward on ward.Id = wardAdm.His_WardId
where patient.Frwk_Discriminator = 'His.HisPatient'
go
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
