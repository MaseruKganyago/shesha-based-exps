using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HisAdmissionAuditTrailService : IHisAdmissionAuditTrailService, ITransientDependency
    {
        private readonly IRepository<HisAdmissionAuditTrail, Guid> _hisAdmissionAuditTrailRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hisAdmissionAuditTrailRepository"></param>
        public HisAdmissionAuditTrailService(IRepository<HisAdmissionAuditTrail, Guid> hisAdmissionAuditTrailRepository)
        {
            _hisAdmissionAuditTrailRepository = hisAdmissionAuditTrailRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trail"></param>
        /// <returns></returns>
        public async Task CreateAudit(HisAdmissionAuditTrail trail)
        {
            await _hisAdmissionAuditTrailRepository.InsertOrUpdateAsync(trail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionId"></param>
        /// <param name="StartDateTime"></param>
        /// <returns></returns>
        public async Task<HisAdmissionAuditTrail> GetAudit(Guid wardAdmissionId, DateTime? StartDateTime)
        {
            return await _hisAdmissionAuditTrailRepository
               .FirstOrDefaultAsync(r => r.Admission.Id == wardAdmissionId && r.AuditTime == StartDateTime);
        }
    }
}
