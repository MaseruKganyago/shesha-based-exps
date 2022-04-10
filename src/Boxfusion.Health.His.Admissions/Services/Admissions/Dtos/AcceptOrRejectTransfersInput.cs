using Boxfusion.Health.His.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class AcceptOrRejectTransfersInput
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid WardAdmissionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RefListAcceptanceDecision? AcceptanceDecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RefListTransferRejectionReasons? TransferRejectionReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransferRejectionReasonComment { get; set; }
    }
}
