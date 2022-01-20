using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public interface IHisAdmissionAuditTrailService
    {
        Task CreateAudit(HisAdmissionAuditTrail trail);
        Task<HisAdmissionAuditTrail> GetAudit(Guid wardAdmissionId, DateTime? StartDateTime);
    }
}
