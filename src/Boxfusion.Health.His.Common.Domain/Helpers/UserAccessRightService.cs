using Abp.Dependency;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common;
using NHibernate.Linq;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Domain.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccessRightService : IUserAccessRightService, ITransientDependency
    {
        private readonly IRepository<HisWard, Guid> _repository;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleAppointedPersonRepository;
        private readonly IRepository<HospitalRoleAppointedPerson, Guid> _hospitalRoleAppointedPersonRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="wardRoleAppointedPersonRepository"></param>
        /// <param name="hospitalRoleAppointedPersonRepository"></param>
        public UserAccessRightService(
            IRepository<HisWard, Guid> repository, 
            IRepository<WardRoleAppointedPerson, Guid> wardRoleAppointedPersonRepository, 
            IRepository<HospitalRoleAppointedPerson, Guid> hospitalRoleAppointedPersonRepository)
        {
            _repository = repository;
            _wardRoleAppointedPersonRepository = wardRoleAppointedPersonRepository;
            _hospitalRoleAppointedPersonRepository = hospitalRoleAppointedPersonRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public async Task<bool> IsPersonAssignedToHospital(Guid wardId, Person currentPerson)
        {
            var OwnerOrganisation = await _repository.GetAsync(wardId);
            var hospital = await _hospitalRoleAppointedPersonRepository.GetAll()
                .Where(r => r.Person == currentPerson).Select(r => r.Hospital).FirstOrDefaultAsync();

            if (OwnerOrganisation?.OwnerOrganisation?.Id == hospital.Id)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardId"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public async Task<bool> IsPersonAssignedToWard(Guid wardId, Person currentPerson)
        {
            var OwnerOrganisation = await _repository.GetAsync(wardId);
            var hospital = await _wardRoleAppointedPersonRepository.GetAll()
                .Where(r => r.Person == currentPerson).Select(r => r.Ward).ToListAsync();

            if (hospital.Any(r => r.Id == OwnerOrganisation.Id))
            {
                return true;
            }

            return false;
        }


    }
}
