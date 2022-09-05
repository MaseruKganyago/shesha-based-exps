using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.BankAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Coverages
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.CashCoverage")]
    
    public class CashCoverage : Coverage
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }
}
