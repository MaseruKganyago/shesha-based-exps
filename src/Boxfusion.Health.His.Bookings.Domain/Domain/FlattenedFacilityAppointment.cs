using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.AutoMapper.Dto;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Bookings.Domain
{
    /// <summary>
    /// Flattened version of the Appointment entity joining in fields from the Patient and Schedule entities.
    /// Note: The DB view behind this entity only returns Facility based appointments i.e. where the Owner of the schedule the appointment 
    /// relates to is Health Facility
    /// </summary>
    [Entity(TypeShortAlias = "His.FlatFacilityAppointment")]
    [Table("vw_His_FlattenedFacilityAppointments")]
    [ImMutable]
    public class FlattenedFacilityAppointment : Entity<Guid>
    {
        public virtual string RefNumber { get; protected set; }
        public virtual DateTime Start { get; protected set; }
        public virtual DateTime End { get; protected set; }

        [ReferenceList("Fhir", "AppointmentReasonCodes")]
        public virtual long? AppointmentType { get; protected set; }
        public virtual RefListAppointmentStatuses? Status { get; protected set; }
        public virtual string ContactCellphone { get; protected set; }
        public virtual string ContactName { get; protected set; }
        public virtual string AlternateContactName { get; protected set; }
        public virtual string AlternateContactCellphone { get; protected set; }
        public virtual string ArrivalTime { get; protected set; }

        [ReferenceList("Fhir", "AppointmentCancellationReasons")]
        public virtual long? CancelationReason { get; protected set; }
        public virtual string Comment { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual long? CreatorUserId { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual string IssuedTicketNumber { get; protected set; }
        public virtual Single? QueuePosition { get; protected set; }
        public virtual int? QueuePriority { get; protected set; }
        public virtual DateTime DropOutTime { get; protected set; }
        public virtual DateTime FirstTimeCalled { get; protected set; }
        public virtual DateTime LastTimeCalled { get; protected set; }
        public virtual DateTime FulfilledTime { get; protected set; }
        public virtual int? NumTimesCalled { get; protected set; }
        public virtual string PatientInstruction { get; protected set; }
        public virtual Guid PractitionerId { get; protected set; }
        public virtual string Priority { get; protected set; }

        [ReferenceList("Fhir", "EncounterReasonCodes")]
        public virtual long? ReasonCode { get; protected set; }

        [ReferenceList("Fhir", "HealthcareServiceCategories")]
        public virtual long? ServiceCategory { get; protected set; }

        [ReferenceList("Fhir", "ServiceTypes")]
        public virtual long? ServiceType { get; protected set; }

        [ReferenceList("Fhir", "PracticeSettingCodeValueSets")]
        public virtual long? Speciality { get; protected set; }
        public virtual Guid SlotId { get; protected set; }
        public virtual Guid ScheduleId { get; protected set; }
        public virtual string ScheduleName { get; protected set; }

        public virtual RefListSchedulingModels? SchedulingModel { get; protected set; }
        public virtual Guid HealthFacilityId { get; protected set; }
        public virtual string HealthFacilityName { get; protected set; }
        public virtual Guid PatientId { get; protected set; }
        public virtual string FacilityPatientIdentifier { get; protected set; }
        public virtual string PatientIdentityNumber { get; protected set; }
        public virtual string PatientMasterIndexNumber { get; protected set; }

        [ReferenceList("His", "IdentificationTypes")]
        public virtual long? PatientIdentificationType { get; protected set; }

        [ReferenceList("Shesha.Core", "PersonTitles")]
        public virtual long? PatientTitle { get; protected set; }
        public virtual string PatientInitials { get; protected set; }
        public virtual string PatientFirstName { get; protected set; }
        public virtual string PatientLastName { get; protected set; }
        public virtual string PatientMobileNumber1 { get; protected set; }
        public virtual string PatientMobileNumber2 { get; protected set; }

        [ReferenceList("Shesha.Core", "Gender")]
        public virtual long? PatientGender { get; protected set; }

        [ReferenceList("Shesha.Core", "PreferredContactMethod")]
        public virtual long? PatientPreferredContactMethod { get; protected set; }
        public virtual string PatientFullName { get; protected set; }
        //public virtual string PatientFullName2 { get; protected set; }
        public virtual string PatientPassportNumber { get; protected set; }
        public virtual string PatientPermitNumber { get; protected set; }
        public virtual string PatientOtherIdentityNumber { get; protected set; }

        [ReferenceList("Shesha.Core", "CommonLanguage")]
        public virtual long? PatientCommunicationLanguage { get; protected set; }

    }
}
