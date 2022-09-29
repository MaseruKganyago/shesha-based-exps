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
    [Migration(20220927165400)]
    public class M20220927165400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"CREATE OR ALTER        view [dbo].[vw_His_FlattenedWardAdmissions]
As
select
wardAdm.Id Id, ward.Id WardId, wardAdm.ServiceProviderId HospitalId, wardAdm.His_WardAdmissionNumber WardAdmissionNumber, FirstName, 
LastName, DateOfBirth, wardAdm.StartDateTime AdmissionDate, wardAdm.His_SeparationDate SeparationDate, wardAdm.His_WardAdmissionStatusLkp StatusLkp,
iif(wardAdm.His_WardAdmissionStatusLkp = 1, DATEDIFF(day,wardAdm.StartDateTime, DATEADD(day,2,GETUTCDATE())), DATEDIFF(day,wardAdm.StartDateTime, wardAdm.His_SeparationDate)) NumOfDaysAdmitted,
wardAdm.His_AdmissionTypeLkp AdmissionTypeLkp, GenderLkp GenderLkp, Fhir_IdentificationTypeLkp IdentificationTypeLkp, IdentityNumber,
wardAdm.His_HospitalAdmissionNumber HospitalAdmissionNumber, hospAdm.His_ClassificationLkp ClassificationLkp,
His_PatientProvinceLkp PatientProvinceLkp, Fhir_NationalityLkp NationalityLkp, hospAdm.His_OtherCategoryLkp OtherCategoryLkp, Fhir_SpecialityLkp SpecialityLkp
from Fhir_Encounters wardAdm
join Core_Persons patient on patient.Id = wardAdm.SubjectId
join Core_Facilities ward on ward.Id = wardAdm.His_WardId
join Fhir_Encounters hospAdm on hospAdm.Id = wardAdm.PartOfId
where wardAdm.Frwk_Discriminator = 'His.WardAdmission'
GO");
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
