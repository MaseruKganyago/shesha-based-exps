using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.His.Common;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Users
{
    /// <summary>
    /// Domain Service for user related methods.
    /// </summary>
    public class HisUserManager : DomainService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulesRepo"></param>
        /// <param name="scheduleAvailabilityRepo"></param>
        /// <param name="slotsRepo"></param>
        public HisUserManager()
        {

        }


        /// <summary>
        /// Returns the list of Facilities that the specified user is associated with.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<List<HisHealthFacility>> GetFacilitiesAssociatedToUserAsync(Guid personId, string roleName = null)
        {
            //var roleRepo = Abp.Dependency.IocManager.Instance.Resolve<IRepository<ShaRole, Guid>>();
            //var role = await roleRepo.FirstOrDefaultAsync(e => e.Name == roleName);
            //if (role is null) throw new InvalidOperationException("No such role exists");

            //var roleAppointments = await _scheduleRoleAppointRepo.GetAllListAsync(e => e.Person.Id == personId && e.Role.Id == role.Id);

            //TODO:IH-NOW For the time being will just return all the Facilities

            var facilitiesRepo = Abp.Dependency.IocManager.Instance.Resolve<IRepository<HisHealthFacility, Guid>>();

            var facilities = facilitiesRepo.GetAll().Take(7).ToList();

            //var schedules = new List<CdmSchedule>();

            //foreach (var roleApp in roleAppointments)
            //{
            //    if (!schedules.Exists(e => e.Id == roleApp.Schedule.Id))
            //    {
            //        schedules.Add(_scheduleRepo.Get(roleApp.Schedule.Id));
            //    }
            //}

            return facilities;
        }


    }
}
