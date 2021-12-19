using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Domain.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisConditionIcdTenCode")]
    [Table("Fhir_ConditionIcdTenCodes")]
    public class HisConditionIcdTenCode : ConditionIcdTenCode
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAdmissionStatuses? AdmissionStatus { get; set; }
    }
}
