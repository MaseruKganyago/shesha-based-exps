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
    [Migration(20220808002400)]
    public class M20220808002400 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"Create or Alter view vw_His_FlattenedWardAdmissions
As
select
wardAdm.Id Id, ward.Id WardId, wardAdm.ServiceProviderId HospitalId, wardAdm.His_WardAdmissionNumber WardAdmissionNumber, FirstName, 
LastName, DateOfBirth, wardAdm.StartDateTime AdmissionDate, wardAdm.His_SeparationDate SeparationDate, wardAdm.His_AdmissionStatusLkp Status,
iif(wardAdm.His_AdmissionStatusLkp = 1, DATEDIFF(day,wardAdm.StartDateTime, DATEADD(day,2,GETUTCDATE())), DATEDIFF(day,wardAdm.StartDateTime, wardAdm.His_SeparationDate)) NumOfDaysAdmitted,
wardAdm.His_AdmissionTypeLkp AdmissionType, GenderLkp Gender, His_IdentificationTypeLkp IdentificationType, IdentityNumber,
wardAdm.His_HospitalAdmissionNumber HospitalAdmissionNumber, hospAdm.His_ClassificationLkp Classification,
His_PatientProvinceLkp PatientProvince, Fhir_NationalityLkp Nationality, hospAdm.His_OtherCategoryLkp OtherCategory, Fhir_SpecialityLkp Speciality
from Fhir_Encounters wardAdm
join Core_Persons patient on patient.Id = wardAdm.SubjectId
join Core_Facilities ward on ward.Id = wardAdm.His_WardId
join Fhir_Encounters hospAdm on hospAdm.Id = wardAdm.PartOfId
where wardAdm.Frwk_Discriminator = 'His.WardAdmission'
go");
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
