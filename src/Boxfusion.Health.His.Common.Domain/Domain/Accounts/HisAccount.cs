using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.BillingClassifications;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisAccount")]
    public class HisAccount : FhirAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual BillingClassification BillingClassification { get; set; }
    }
}
