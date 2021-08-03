using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Domain
{
    [Entity(TypeShortAlias = "His.HisWard")]
    public class WardMidnightCensusDailyReport : FullAuditedEntity<Guid>
    {
        public virtual Ward Ward { get; set; }

        public virtual DateTime? ReportDate { get; set; }

        [ReferenceList("HisAdmis", "ApprovalStatus")]
        public virtual int? ApprovalStatus { get; set; }

        public virtual string Description { get; set; }

        //public virtual HisPractitioner ApprovedBy { get; set; }
    }
}
