using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
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
    [Entity(TypeShortAlias = "His.HisAdmission")]
    [Table("Fhir_Encounters")]
    public class HisAdmission : HospitalisationEncounter
    {

    }
}
