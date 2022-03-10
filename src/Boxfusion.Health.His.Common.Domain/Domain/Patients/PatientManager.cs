using Abp;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Common;
using NHibernate;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// Domain Service for user related methods.
    /// </summary>
    public class PatientManager : DomainService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        /// <summary>
        /// 
        /// </summary>
        public PatientManager()
        {
            _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();
        }

        /// <summary>
        /// Returns the Facility specific Patient Identifier for the specified patient and current Facility Context.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public string GetContextFacilityPatientIdentifier(Guid patientId)
        {
            if (!RequestContextHelper.HasFacilityId) return "";

            string patientFacilityIdentifier;
            var abpSession = IocManager.Instance.Resolve<IAbpSession>();
            var facilityId = RequestContextHelper.FacilityId;

            // make sure that we have active session
            using (_unitOfWorkManager.Current == null ? _unitOfWorkManager.Begin() : null)
            {
                using (var session = IocManager.Instance.Resolve<ISessionFactory>().OpenSession())
                {
                    var query = session
                      .CreateSQLQuery(@"SELECT dbo.fn_His_GetFacilityPatientIdentifier(:patientId, :facilityId)")
                      .SetParameter("patientId", patientId)
                      .SetParameter("facilityId", facilityId)
                      ;

                    patientFacilityIdentifier = query.UniqueResult<string>();
                }
            }

            return patientFacilityIdentifier;
        }

    }
}
