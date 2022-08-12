using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Schedule", GenerateApplicationService = false)]
    [Table("Fhir_Schedules")]
    [Discriminator]
    public class Schedule : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Name of the schedule.
        /// </summary>
        [EntityDisplayName]
        public virtual string Name { get; set; }

        /// <summary>
        /// External Ids for this item.
        /// </summary>
        public virtual string Identifier { get; set; }

        /// <summary>
        /// Whether this schedule is in active use
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// High-level category
        /// </summary>
        [ReferenceList("Fhir", "HealthcareServiceCategories")] 
        public virtual long? ServiceCategory { get; set; }

        /// <summary>
        /// Specific Service
        /// </summary>
        [ReferenceList("Fhir", "ServiceTypes")]
        public virtual long? ServiceType { get; set; }

        /// <summary>
        /// Type of specialty needed
        /// </summary>
        [ReferenceList("Fhir", "PracticeSettingCodeValueSets")]
        public virtual long? Speciality { get; set; }

        /// <summary>
        /// Resource(s) that availability information is being provided for
        /// </summary>
        public virtual string ActorOwnerId { get; set; }

        /// <summary>
        /// When the Schedule relates to a Facility, specifies the Facility it relates to.
        /// </summary>
        public virtual Hospital HealthFacilityOwner { get; set; }

        /// <summary>
        /// Resource(s) that availability information is being provided for
        /// </summary>
        public virtual string ActorOwnerType { get; set; }

        /// <summary>
        /// Period of time covered by schedule
        /// </summary>
        public virtual DateTime? PlanningHorizonStartDate { get; set; }

        /// <summary>
        /// Period of time covered by schedule
        /// </summary>
        public virtual DateTime? PlanningHorizonEndDate { get; set; }

        /// <summary>
        /// Comments on availability
        /// </summary>
        public virtual string Comment { get; set; }

    }
}
