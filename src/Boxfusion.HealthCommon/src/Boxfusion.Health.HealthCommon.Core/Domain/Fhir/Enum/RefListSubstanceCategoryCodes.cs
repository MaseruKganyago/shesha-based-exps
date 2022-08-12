using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "SubstanceCategoryCodes")]
    public enum RefListSubstanceCategoryCodes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Allergen")]
        allergen = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biological Substance")]
        biological = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Body Substance")]
        body = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chemical")]
        chemical = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dietary Substance")]
        food = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Drug or Medicament")]
        drug = 32,

        /// <summary>
        /// 
        /// </summary>
        [Description("Material")]
        material = 64,


    }
}
