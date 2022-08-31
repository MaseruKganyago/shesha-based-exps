using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
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
    [Entity(TypeShortAlias = "His.AccountCoverage")]
    public class AccountCoverage : FullAuditedEntity<Guid>
    {
        public HisAccount Account { get; set; }
        public Coverage Coverage { get; set; }

    }
}
