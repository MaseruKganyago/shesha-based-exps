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
    [Migration(20211110194700)]
    public class M20211110194700 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
                Create OR ALTER View vw_HisAdmis_AdmittedPatientItems
                as
                select encounter.id, 
                patient.HisAdmis_IdentificationTypeLkp as IdentificationTypeLkp, 
                patient.identityNumber,
                patient.DateOfBirth,
                patient.GenderLkp, 
                encounter.StartDateTime,
                patient.HisAdmis_HospitalisationPatientNumber as HospitalisationPatientNumber, 
                encounter.PreAdmissionIdentifier,
                patient.FirstName,
                patient.LastName,
                patient.HisAdmis_AdmissionTypeLkp as AdmissionTypeLkp,
                ward.Fhir_SpecialityLkp as SpecialityLkp, 
                patient.HisAdmis_ProvinceLkp as ProvinceLkp,
                patient.HisAdmis_ClassificationLkp as ClassificationLkp,
                patient.Fhir_NationalityLkp as NationalityLkp, 
                patient.HisAdmis_OtherCategoriesLkp OtherCategoriesLkp,
                patient.HisAdmis_AdmissionStatusLkp as AdmissionStatusLkp,
                iif(patient.HisAdmis_AdmissionStatusLkp = 1, DATEDIFF(day,getdate(), encounter.StartDateTime), DATEDIFF(day,encounter.EndDateTime, encounter.StartDateTime)) as days
                from Fhir_Encounters encounter 
                left join Core_Persons patient on encounter.SubjectId = patient.Id
                left join Core_Facilities ward on encounter.DestinationOwnerId = CAST(ward.Id as nvarchar(255))
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

