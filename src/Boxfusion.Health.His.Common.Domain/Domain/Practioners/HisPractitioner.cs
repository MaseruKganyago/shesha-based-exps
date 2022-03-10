using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Common.Practitioners
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisPractitioner")]
    [Table("Core_Persons")]
    public class HisPractitioner : CdmPractitioner
    {

    }
}
