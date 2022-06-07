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
    [Migration(20220607142100)]
    public class M20220607142100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
		CREATE OR ALTER VIEW [dbo].[vw_His_FlattenedFacilityAppointments]
			AS
				SELECT 
					app.Id
					,app.RefNumber
					,app.[Start] 
					,app.[End] 
					,app.AppointmentTypeLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'AppointmentReasonCodes', app.AppointmentTypeLkp) AppointmentType
					,app.StatusLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'AppointmentStatuses', app.StatusLkp) [Status]
					,app.ContactCellphone
					,app.ContactName
					,app.AlternateContactName
					,app.AlternateContactCellphone
					,app.ArrivalTime
					,app.CancelationReasonLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'AppointmentCancellationReasons', app.CancelationReasonLkp) CancelationReason
					,app.Comment
					,app.CreationTime
					,app.CreatorUserId
					,app.Description
					,app.IssuedTicketNumber
					,app.QueuePosition
					,app.QueuePriority
					,app.FirstTimeCalled
					,app.LastTimeCalled
					,app.DropOutTime
					,app.FulfilledTime
					,app.NumTimesCalled
					,app.PatientInstruction
					,app.PractitionerId
					,app.Priority
					,app.ReasonCodeLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'EncounterReasonCodes', app.ReasonCodeLkp) ReasonCode
					,app.ServiceCategoryLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'HealthcareServiceCategories', app.ServiceCategoryLkp) ServiceCategory
					,app.ServiceTypeLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'ServiceTypes', app.ServiceTypeLkp) ServiceType
					,app.SpecialityLkp
					--, dbo.Frwk_GetRefListItem('Fhir', 'PracticeSettingCodeValueSets', app.SpecialityLkp) Speciality

					,SlotId
					,slot.ScheduleId ScheduleId
					,sch.[Name] ScheduleName
					,sch.SchedulingModelLkp
					--, dbo.Frwk_GetRefListItem('Cdm', 'SchedulingModels', sch.SchedulingModelLkp) SchedulingModel

					,app.PatientId
					, hf.Id HealthFacilityId
					, hf.[Name] HealthFacilityName
					,dbo.[fn_His_GetFacilityPatientIdentifier](per.Id, hf.Id) FacilityPatientIdentifier
					,per.[IdentityNumber] PatientIdentityNumber
					,per.[His_PatientMasterIndexNumber] PatientMasterIndexNumber
					,per.[His_IdentificationTypeLkp] PatientIdentificationTypeLkp
					--, dbo.Frwk_GetRefListItem('His', 'IdentificationTypes', per.[His_IdentificationTypeLkp]) PatientIdentificationType
					,per.[TitleLkp] PatientTitleLkp
					--, dbo.Frwk_GetRefListItem('Shesha.Core', 'PersonTitles', per.[TitleLkp]) PatientTitle
					,per.[Initials] PatientInitials
					,per.[FirstName] PatientFirstName
					,per.[LastName] PatientLastName
					,per.[MobileNumber1] PatientMobileNumber1
					,per.[MobileNumber2] PatientMobileNumber2
					,per.[GenderLkp] PatientGenderLkp
					--, dbo.Frwk_GetRefListItem('Shesha.Core', 'Gender', per.[GenderLkp]) PatientGender
					,per.[PreferredContactMethodLkp] PatientPreferredContactMethodLkp
					--, dbo.Frwk_GetRefListItem('Shesha.Core', 'PreferredContactMethod', per.[PreferredContactMethodLkp]) PatientPreferredContactMethod
					,per.[FullName] PatientFullName
					,per.[FullName2] PatientFullName2
					,per.[Fhir_PassportNumber] PatientPassportNumber
					,per.[Fhir_PermitNumber] PatientPermitNumber
					,per.[Fhir_OtherIdentityNumber] PatientOtherIdentityNumber
					,per.[Fhir_CommunicationLanguageLkp] PatientCommunicationLanguageLkp
					--, dbo.Frwk_GetRefListItem('Shesha.Core', 'CommonLanguage', per.[Fhir_CommunicationLanguageLkp]) PatientCommunicationLanguage
					,(SELECT UserName FROM AbpUserAccounts where Id = app.CreatorUserId) CreatedBy

				FROM Fhir_Appointments app
					LEFT JOIN Core_Persons per ON per.Id = app.PatientId
					LEFT JOIN Fhir_Slots slot ON slot.Id = app.SlotId
					LEFT JOIN Fhir_Schedules sch ON sch.Id = slot.ScheduleId
					LEFT JOIN Core_Organisations hf ON hf.Id = sch.HealthFacilityOwnerId
				WHERE
					per.Frwk_Discriminator = 'His.HisPatient'
					AND hf.Frwk_Discriminator IN ('His.HisHealthFacility', 'His.HisHealthFacility', 'His.HisHospital' /*Should no longer be relevant after entity has been renamed*/, 'Fhir.Hospital' /*Delete - for testing purposes only*/)
					AND per.IsDeleted = 0
					AND slot.IsDeleted = 0
					AND sch.IsDeleted = 0
					AND hf.IsDeleted = 0
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
