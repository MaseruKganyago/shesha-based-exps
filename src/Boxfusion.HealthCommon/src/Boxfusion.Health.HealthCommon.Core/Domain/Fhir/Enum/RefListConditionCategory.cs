﻿using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "ConditionCategory")]
    public enum RefListConditionCategory : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Problem List Item")]
        problemListItem = 1
    }
}