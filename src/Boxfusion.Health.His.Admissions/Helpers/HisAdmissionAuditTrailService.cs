using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Helpers
{
    public class HisAdmissionAuditTrailService : IHisAdmissionAuditTrailService, ITransientDependency
    {
        private readonly IRepository<HisAdmissionAuditTrail, Guid> _hisAdmissionAuditTrailRepository;
        public HisAdmissionAuditTrailService(IRepository<HisAdmissionAuditTrail, Guid> hisAdmissionAuditTrailRepository)
        {
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
        }

        public async Task CreateAudit(HisAdmissionAuditTrail trail)
        {
            await _hisAdmissionAuditTrailRepository.InsertOrUpdateAsync(trail);
        }

        public async Task<HisAdmissionAuditTrail> GetAudit(Guid wardAdmissionId, DateTime? StartDateTime)
        {
            return await _hisAdmissionAuditTrailRepository
               .FirstOrDefaultAsync(r => r.Admission.Id == wardAdmissionId && r.AuditTime == StartDateTime);
        }
    }
}
