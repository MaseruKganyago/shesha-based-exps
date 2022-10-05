using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.Cdm.Patients;
using Boxfusion.Health.Cdm.Practitioners;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
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
    public class AccountMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountMapProfile()
        {
            CreateMap<BankAccountInput, BankAccount>()
            .ForMember(@out => @out.Bank, options => options.MapFrom(@in => UtilityHelper.GetRefListItemValue(@in.Bank)))
            .ForMember(@out => @out.AccountType, options => options.MapFrom(@in => UtilityHelper.GetRefListItemValue(@in.AccountType)))
            .IgnoreNotMapped()
            .MapReferenceListValuesToDto();
        }
    }
}
