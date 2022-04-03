﻿using Boxfusion.Health.Cdm.Practitioners;
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
    [Entity(TypeShortAlias = "His.HisPractitioner"
        , ApplicationServiceName = "HisPractitionerCrud")]
    [DiscriminatorValue("His.HisPractitioner")]
    [Discriminator]
    [Table("Core_Persons")]
    public class HisPractitioner : CdmPractitioner
    {

    }
}