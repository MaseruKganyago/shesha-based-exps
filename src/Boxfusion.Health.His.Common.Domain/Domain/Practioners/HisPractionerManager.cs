using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Authorization;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Practitioners
{
    /// <summary>
    /// Domain Service for user related methods.
    /// </summary>
    public class HisPractitionerManager : DomainService
    {
        public HisPractitionerManager()
        {

        }


        /// <summary>
        /// Returns the list of Facilities that the specified user is associated with.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<List<HisHealthFacility>> GetFacilitiesAssociatedToUserAsync(Guid personId)
        {
            var facilityRoleAppointedPersonRepo = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HospitalRoleAppointedPerson, Guid>>();

            var appointedFacilities = await facilityRoleAppointedPersonRepo.GetAllListAsync(e => e.Person.Id == personId && e.Role.Name == CommonRoles.FacilityPractitioner);

            var facilities = new List<HisHealthFacility>();

            foreach (var appointedFacility in appointedFacilities)
            {
                if (!facilities.Exists(e => e.Id == appointedFacility.Hospital.Id))
                {
                    facilities.Add(appointedFacility.Hospital);
                }
            }

            return facilities;
        }

    }
}
