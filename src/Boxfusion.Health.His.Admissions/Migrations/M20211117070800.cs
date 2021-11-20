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
    [Migration(20211117070800)]
    public class M20211117070800 : Migration
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
                patient.His_IdentificationTypeLkp as IdentificationTypeLkp, 
                patient.identityNumber,
                patient.DateOfBirth,
                patient.GenderLkp, 
                encounter.StartDateTime,
                patient.His_HospitalPatientNumber as HospitalisationPatientNumber, 
                encounter.His_WardAdmissionNumber as WardAdmissionNumber,
                patient.FirstName,
                patient.LastName,
                encounter.His_AdmissionTypeLkp as AdmissionTypeLkp,
                ward.Fhir_SpecialityLkp as SpecialityLkp, 
                patient.His_PatientProvinceLkp as ProvinceLkp,
                encounter.His_ClassificationLkp as ClassificationLkp,
                patient.Fhir_NationalityLkp as NationalityLkp, 
                encounter.His_OtherCategoryLkp OtherCategoryLkp,
                encounter.His_AdmissionStatusLkp as AdmissionStatusLkp,
                iif(encounter.His_AdmissionStatusLkp = 1, DATEDIFF(day,encounter.StartDateTime, getdate()), DATEDIFF(day,encounter.StartDateTime, encounter.EndDateTime)) as days
                from Fhir_Encounters encounter 
                left join Core_Persons patient on encounter.SubjectId = patient.Id
                left join Core_Facilities ward on encounter.His_AdmissionDestinationWardId = ward.Id
				where encounter.Frwk_Discriminator = 'His.WardAdmission'
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

