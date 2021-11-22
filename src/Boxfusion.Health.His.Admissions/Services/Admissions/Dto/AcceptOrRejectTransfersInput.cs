using Boxfusion.Health.His.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    public class AcceptOrRejectTransfersInput
    {
        public Guid WardAdmissionId { get; set; }
        public RefListAcceptanceDecision? AcceptanceDecision { get; set; }
        public RefListTransferRejectionReasons? TransferRejectionReason { get; set; }
        public string TransferRejectionReasonComment { get; set; }
    }
}
