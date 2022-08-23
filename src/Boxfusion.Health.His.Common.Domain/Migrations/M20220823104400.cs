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
    [Migration(20220823104400)]
    public class M20220823104400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
Create or ALTER   View [dbo].[vw_His_FlattenedHospitalAdmissions]
AS
select
patient.Id,
patient.Fhir_IdentificationTypeLkp as IdentificationTypeLkp,
patient.IdentityNumber,
patient.DateOfBirth,
patient.FirstName,
patient.LastName,
patient.MobileNumber1,
patient.Fhir_NationalityLkp as NationalityLkp,
patient.GenderLkp,
patient.Fhir_PatientMasterIndexNumber as PatientMasterIndexNumber,
hospAdm.Id as HospitalAdmissionId,
hospAdm.His_HospitalAdmissionNumber as HospitalAdmissionNumber,
hospAdm.StartDateTime,
--hospAdm.His_AdmissionTypeLkp,
hospAdm.EndDateTime,
hospAdm.His_ClassificationLkp as ClassificationLkp,
hospAdm.ClassLkp,
ward.Id WardAdmissionId,
ward.Name as WardName,
wardAdm.His_AdmissionStatusLkp as WardAdmissionStatusLkp,
wardAdm.StartDateTime as WardAdmissionDate,
iif(hospAdm.His_AdmissionStatusLkp != 1, DATEDIFF(day, hospAdm.StartDateTime, hospAdm.EndDateTime), DATEDIFF(day, hospAdm.StartDateTime, DateAdd(hour, 2, GETUTCDATE()))) as LOS
from Fhir_Encounters hospAdm
	join Core_Persons patient on hospAdm.SubjectId = patient.Id and patient.Frwk_Discriminator = 'His.HisPatient'
	left join Fhir_Encounters wardAdm on wardAdm.SubjectId = patient.Id 
		and wardAdm.Frwk_Discriminator = 'His.WardAdmission'
		and wardAdm.StartDateTime = (select MAX(StartDateTime) from Fhir_Encounters where PartOfId = hospAdm.Id and wardAdm.Frwk_Discriminator = 'His.WardAdmission')

	left join Core_Facilities ward on ward.Id = wardAdm.His_WardId
where hospAdm.Frwk_Discriminator = 'His.HospitalAdmission'
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
