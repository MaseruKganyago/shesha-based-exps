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
    public class SetPaymentInput
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid BillingClassificationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? SelectedMedicalAidCoverageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid HospitalAdmissionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CashPayerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BankAccountInput BankAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? Selected3rdPartyCoverageId { get; set; }
    }
}
