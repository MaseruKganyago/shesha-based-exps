using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.FHIR.CodableConceptLists
{
    /// <summary>
    /// International Statistical Classification of Diseases and Related Health Problems
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.ICDCode")]
    public class ICDCode : FullAuditedEntity<Guid>
    {
        public virtual int? Number { get; set; }
        public virtual string ChapterNumber { get; set; }
        public virtual string ChapterDesc { get; set; }
        public virtual string GroupCode { get; set; }
        public virtual string GroupDesc { get; set; }
        public virtual string ICDTenThreeCode { get; set; }
        public virtual string ICDTenThreeCodeDesc { get; set; }
        public virtual string ICDTenCode { get; set; }
        public virtual string WHOFullDesc { get; set; }
        public virtual string ValidICDTenClinicalUse { get; set; }
        public virtual string ValidICDTenPrimary { get; set; }
        public virtual string ValidICDTenAsterisk { get; set; }
        public virtual string ValidICDTenDagger { get; set; }
        public virtual string ValidICDTenSequelae { get; set; }
        public virtual string AgeRange { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? WHOStartDate { get; set; }
        public virtual DateTime? WHOEndDate { get; set; }
        public virtual string WHORevisionHistory { get; set; }
        public virtual DateTime? SAStartDate { get; set; }
        public virtual DateTime? SAEndDate { get; set; }
        public virtual string SARevisionHistory { get; set; }
        public virtual string Comment { get; set; }
        public virtual string System { get; set; }
    }
}
