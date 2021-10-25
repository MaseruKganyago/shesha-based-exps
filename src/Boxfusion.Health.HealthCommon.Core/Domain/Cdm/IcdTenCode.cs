using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.IcdTenCode")]
    public class IcdTenCode : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int? Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ChapterNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ChapterDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string GroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string GroupDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ICDTenThreeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ICDTenThreeCodeDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ICDTenCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [EntityDisplayName]
        public virtual string WHOFullDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ValidICDTenClinicalUse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ValidICDTenPrimary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ValidICDTenAsterisk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ValidICDTenDagger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ValidICDTenSequelae { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string AgeRange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? WHOStartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? WHOEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string WHORevisionHistory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? SAStartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? SAEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string SARevisionHistory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Comment { get; set; }
    }
}
