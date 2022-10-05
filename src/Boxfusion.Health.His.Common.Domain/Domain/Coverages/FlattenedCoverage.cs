using Abp.Domain.Entities;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.BankAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Coverages
{
    /// <summary>
    /// 
    /// </summary>
    [Table("vw_His_FlattenedCoverages")]
    [ImMutable]
    public class FlattenedCoverage : Entity<Guid>
    {
        public virtual Guid OwnerPersonId { get; protected set; }
        public virtual string OwnerPersonFullName { get; protected set; }
        public virtual Guid OwnerOrganisationId { get; protected set; }
        public virtual Guid OwnerOrganisationName { get; protected set; }
        public virtual string AccountName { get; protected set; }
        [ReferenceList("Shesha.Enterprise", "Bank")]
        public virtual long? Bank { get; protected set; }
        public virtual string BranchName { get; protected set; }
        public virtual string BranchCode { get; protected set; }
        [ReferenceList("Shesha.Enterprise", "AccountType")]
        public virtual long? AccountType { get; protected set; }
        public virtual string AccountNumber { get; protected set; }
        [ReferenceList("Shesha.Enterprise", "Status")]
        public virtual long? Status { get; protected set; }
        public virtual decimal? CurrentBalance { get; protected set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string CurrencyFullName { get; set; }
        public virtual string CurrencySymbol { get; set; }
    }
}
