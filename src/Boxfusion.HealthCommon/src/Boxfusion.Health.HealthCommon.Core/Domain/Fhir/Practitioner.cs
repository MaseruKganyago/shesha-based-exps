using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Practitioner", GenerateApplicationService = false)]
    public class Practitioner : PersonFhirBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string PracticeSANCNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string DispensaryNumber { get; set; }
    }
}
