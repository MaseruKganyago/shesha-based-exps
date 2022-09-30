using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.ChargeItems
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisChargeItem")]
    public class HisChargeItem : ChargeItem
    {
        /// <summary>
        /// 
        /// </summary>
        [ReferenceList("His", "ChargeItemStatus")]
        public virtual RefListChargeItemStatus? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastBilledDate { get; set; }
    }
}
