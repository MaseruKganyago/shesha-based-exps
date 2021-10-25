using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Schedule")]
    public class Schedule : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Identifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListServiceCategories ServiceCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListServiceTypes ServiceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSpeciality Speciality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ActorOwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ActorOwnerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PlanningHorizonStartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? PlanningHorizonEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Comment { get; set; }
    }
}
