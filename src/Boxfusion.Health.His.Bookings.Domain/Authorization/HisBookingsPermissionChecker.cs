using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.Domain;

namespace Boxfusion.Health.His.Bookings.Authorization
{
    /// <summary>
    /// Health.His Permission checker
    /// </summary>
    public class HisBookingsPermissionChecker : ICustomPermissionChecker, IHisBookingsPermissionChecker
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;
        private readonly IRepository<ShaRoleAppointmentEntity, Guid> _appEntityRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public HisBookingsPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
        {
            _personRepository = personRepository;
            _rolePersonRepository = rolePersonRepository;
            _appEntityRepository = appEntityRepository;
        }

        /// inheritedDoc
        public async Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            var person = await _personRepository.GetAll().Where(p => p.User.Id == userId).FirstOrDefaultAsync();
            if (person == null)
                return false;

            // add custom permission checks here...
            if (permissionName == PermissionNames.DailyAppointmentBooking)
                return await this.IsScheduleManager(person) || await this.IsScheduleFulfiller(person) || await this.IsSystemAdministrator(person);

            return false;
        }

        /// inheritedDoc
        public async Task<bool> IsInAnyOfRoles(Person person, params string[] roles)
        {
            return await _rolePersonRepository.GetAll()
                .Where(e => roles.Contains(e.Role.Name) && e.Person == person).AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public bool IsGranted(long userId, string permissionName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsSystemAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.SystemAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsScheduleManager(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ScheduleManager);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsScheduleFulfiller(Person person)
        {
            return await IsInAnyOfRoles(person, RoleNames.ScheduleFulfiller);
        }
    }
}
