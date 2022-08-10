using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Appointment")]
    [Table("Fhir_Appointments")]
    [Discriminator]
    public class Appointment : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// External Ids for this item
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// proposed | pending | booked | arrived | fulfilled | cancelled | noshow | entered-in-error | checked-in | waitlist
        /// </summary>
        [ReferenceList("Fhir", "AppointmentStatuses")]
        public virtual RefListAppointmentStatuses? Status { get; set; }

        /// <summary>
        /// The coded reason for the appointment being cancelled
        /// </summary>
        [ReferenceList("Fhir", "AppointmentCancellationReasons")]
        public virtual long? CancelationReason { get; set; }

        /// <summary>
        /// A broad categorization of the service that is to be performed during this appointment
        /// </summary>
        [ReferenceList("Fhir", "HealthcareServiceCategories")]
        public virtual long? ServiceCategory { get; set; }

        /// <summary>
        /// The specific service that is to be performed during this appointment
        /// </summary>
        [ReferenceList("Fhir", "ServiceTypes")]
        public virtual long? ServiceType { get; set; }

        /// <summary>
        /// The specialty of a practitioner that would be required to perform the service requested in this appointment.
        /// </summary>
        [ReferenceList("Fhir", "PracticeSettingCodeValueSets")]
        public virtual long? Speciality { get; set; }

        /// <summary>
        /// The style of appointment or patient that has been booked in the slot (not service type)
        /// </summary>
        [ReferenceList("Fhir", "AppointmentReasonCodes")]
        public virtual long? AppointmentType { get; set; }

        /// <summary>
        /// Coded reason this appointment is scheduled
        /// </summary>
        [ReferenceList("Fhir", "EncounterReasonCodes")]
        public virtual long? ReasonCode { get; set; }

        /// <summary>
        /// Reason the appointment is to take place (resource)
        /// </summary>
        public virtual string ReasonReferenceOwnerId { get; set; }

        /// <summary>
        /// Reason the appointment is to take place(resource) Turn on screen reader support
        /// </summary>
        public virtual string ReasonReferenceOwnerType { get; set; }

        /// <summary>
        /// Used to make informed decisions if needing to re-prioritize
        /// </summary>
        public virtual int? Priority { get; set; }

        /// <summary>
        /// Shown on a subject line in a meeting request, or appointment list.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Additional information to support the appointment
        /// </summary>
        public virtual string SupportingInformationOwnerId { get; set; }

        /// <summary>
        /// Additional information to support the appointment
        /// </summary>
        public virtual string SupportingInformationOwnerType { get; set; }

        /// <summary>
        /// When appointment is to take place.
        /// </summary>
        public virtual DateTime? Start { get; set; }

        /// <summary>
        /// When appointment is to conclude.
        /// </summary>
        public virtual DateTime? End { get; set; }

        /// <summary>
        /// Can be less than start/end (e.g. estimate).
        /// </summary>
        public virtual int? MinutesDuration { get; set; }

        /// <summary>
        /// The slots that this appointment is filling.
        /// </summary>
        public virtual Slot Slot { get; set; }

        /// <summary>
        /// The date that this appointment was initially created.
        /// </summary>
        public virtual DateTime? Created { get; set; }

        /// <summary>
        /// Additional comments
        /// </summary>
        public virtual string Comment { get; set; }

        /// <summary>
        /// Detailed information and instructions for the patient
        /// </summary>
        public virtual string PatientInstruction { get; set; }

        /// <summary>
        /// The service request this appointment is allocated to assess.
        /// </summary>
        public virtual ServiceRequest BasedOn { get; set; }

        /// <summary>
        /// Potential date/time interval(s) requested to allocate the appointment within
        /// </summary>
        public virtual DateTime? RequestedPeriodStart { get; set; }

        /// <summary>
        /// Potential date/time interval(s) requested to allocate the appointment within.
        /// </summary>
        public virtual DateTime? RequestedPeriodEnd { get; set; }
    }
}