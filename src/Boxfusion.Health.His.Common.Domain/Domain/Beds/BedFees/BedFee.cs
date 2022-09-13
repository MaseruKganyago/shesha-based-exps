using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.ChargeItems;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds.BedFees
{
    /// <summary>
    /// 
    /// </summary>
    public class BedFee : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual WardAdmission WardAdmission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Bed Bed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "BedFeeStatus")]
        public virtual long? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual HisChargeItem ChargeItem { get; set; }
    }
}
