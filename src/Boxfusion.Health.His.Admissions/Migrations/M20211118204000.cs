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
    [Migration(20211118204000)]
    public class M20211118204000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
                Create OR ALTER View vw_HisAdmis_AdmittedPatientItems
                as
                select wardEncounter.id, 
                patient.His_IdentificationTypeLkp as IdentificationTypeLkp, 
                patient.identityNumber,
                patient.DateOfBirth,
                patient.GenderLkp, 
                wardEncounter.StartDateTime,
                patient.His_HospitalPatientNumber as HospitalisationPatientNumber, 
                wardEncounter.His_WardAdmissionNumber as WardAdmissionNumber,
                patient.FirstName,
                patient.LastName,
                wardEncounter.His_AdmissionTypeLkp as AdmissionTypeLkp,
                ward.Fhir_SpecialityLkp as SpecialityLkp, 
                patient.His_PatientProvinceLkp as ProvinceLkp,
                hospitalEncounter.His_ClassificationLkp as ClassificationLkp,
                patient.Fhir_NationalityLkp as NationalityLkp, 
                hospitalEncounter.His_OtherCategoryLkp OtherCategoryLkp,
                wardEncounter.His_AdmissionStatusLkp as AdmissionStatusLkp,
                iif(wardEncounter.His_AdmissionStatusLkp = 1, DATEDIFF(day,wardEncounter.StartDateTime, getdate()), DATEDIFF(day,wardEncounter.StartDateTime, wardEncounter.EndDateTime)) as days
                from Fhir_Encounters wardEncounter 
                left join Core_Persons patient on wardEncounter.SubjectId = patient.Id and wardEncounter.Frwk_Discriminator = 'His.WardAdmission'
				left join Fhir_Encounters hospitalEncounter on hospitalEncounter.SubjectId = patient.Id and hospitalEncounter.Frwk_Discriminator = 'His.HospitalAdmission'
                left join Core_Facilities ward on wardEncounter.His_AdmissionDestinationWardId = ward.Id
				where wardEncounter.Frwk_Discriminator = 'His.WardAdmission'
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

