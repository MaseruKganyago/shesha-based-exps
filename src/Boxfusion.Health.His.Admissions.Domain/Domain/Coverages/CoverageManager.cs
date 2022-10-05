using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Coverages;
using Boxfusion.Health.His.Common.Domain.Domain.Coverages;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using NHibernate.Transform;
using NHibernate;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Shesha.Services;
using Shesha.Domain;
using DevExpress.Office.Utils;

namespace Boxfusion.Health.His.Admissions.Domain.Domain.Coverages
{
    /// <summary>
    /// 
    /// </summary>
    public class CoverageManager : DomainService
    {
        private readonly IRepository<FlattenedCoverage, Guid> _flattenedCoverageRepo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flattenedCoverageRepo"></param>
        public CoverageManager(
            IRepository<FlattenedCoverage, Guid> flattenedCoverageRepo)
        {
            _flattenedCoverageRepo = flattenedCoverageRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<FlattenedCoverage> GetSelfCashCoverage(Guid patientId)
        {
            FlattenedCoverage flattenedCoverage = null;
            using (var session = IocManager.Instance.Resolve<ISessionFactory>().OpenSession())
            {
                flattenedCoverage = await session
                .CreateSQLQuery(Util.GetFlattenedCoverage)
                .SetParameter<Guid>("patientId", patientId)
                .SetResultTransformer(Transformers.AliasToBean<FlattenedCoverage>())
                .UniqueResultAsync<FlattenedCoverage>();
            }

            return flattenedCoverage;
        }
    }
}
