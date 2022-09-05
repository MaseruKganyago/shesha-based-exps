using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.Cdm.Appointments;
using Shesha.AutoMapper.Dto;
using Shesha.Enterprise.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(BankAccount))]
    public class SelfCoverageInput : EntityDto<Guid>
    {
        /// <summary>
        /// The Bank Name
        /// </summary>
        public ReferenceListItemValueDto Bank { get; set; }

        /// <summary>
        /// The Bank Name
        /// </summary>
        public ReferenceListItemValueDto AccountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BranchCode { get; set; }
    }
}
