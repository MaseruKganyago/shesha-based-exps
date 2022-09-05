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
        public Guid? SelectedMedicalAidId { get; set; }

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
        public SelfCoverageInput SelfCoverage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? Selected3rdPartyCoverageId { get; set; }
    }
}
