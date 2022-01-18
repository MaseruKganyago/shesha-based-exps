using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Organisations.Helper;
using Boxfusion.Health.His.Admissions.Services.Users.Dto;
using Boxfusion.Health.His.Domain.Domain;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Users.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class HisUserCrudHelper : IHisUserCrudHelper, ITransientDependency
    {
        private readonly IPersonFhirBaseCrudHelper<HisUser, HisUserResponse> _personFhirCrudHelper;
        private readonly IRepository<HisUser, Guid> _repository;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleAppointedPersonRepository;
        private readonly IRepository<HospitalRoleAppointedPerson, Guid> _hospitalRoleAppointedPersonRepository;
        private readonly IRepository<ShaRole, Guid> _shaRoleRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _shaRoleAppointedPersonRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IRepository<HisHospital, Guid> _hospitalRepository;
        private readonly IRepository<HisWard, Guid> _wardRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personFhirCrudHelper"></param>
        /// <param name="addressRepository"></param>
        /// <param name="wardRoleAppointedPersonRepository"></param>
        /// <param name="hospitalRoleAppointedPersonRepository"></param>
        /// <param name="shaRoleRepository"></param>
        /// <param name="repository"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="hospitalRepository"></param>
        /// <param name="wardRepository"></param>
        /// <param name="shaRoleAppointedPersonRepository"></param>
        /// <param name="mapper"></param>
        public HisUserCrudHelper(
            IPersonFhirBaseCrudHelper<HisUser, HisUserResponse> personFhirCrudHelper,
            IRepository<CdmAddress, Guid> addressRepository,
            IRepository<WardRoleAppointedPerson, Guid> wardRoleAppointedPersonRepository,
            IRepository<HospitalRoleAppointedPerson, Guid> hospitalRoleAppointedPersonRepository,
            IRepository<ShaRole, Guid> shaRoleRepository,
            IRepository<HisUser, Guid> repository,
            IUnitOfWorkManager unitOfWork,
            IRepository<HisHospital, Guid> hospitalRepository,
            IRepository<HisWard, Guid> wardRepository,
            IRepository<ShaRoleAppointedPerson, Guid> shaRoleAppointedPersonRepository,
            IMapper mapper)
        {
            _personFhirCrudHelper = personFhirCrudHelper;
            _addressRepository = addressRepository;
            _wardRoleAppointedPersonRepository = wardRoleAppointedPersonRepository;
            _hospitalRoleAppointedPersonRepository = hospitalRoleAppointedPersonRepository;
            _shaRoleRepository = shaRoleRepository;
            _shaRoleAppointedPersonRepository = shaRoleAppointedPersonRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hospitalRepository = hospitalRepository;
            _wardRepository = wardRepository;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HisUserResponse>> GetAllAsync()
        {
            var HisUserResponses = await _personFhirCrudHelper.GetAllAsync();
            return HisUserResponses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HisUserResponse> GetAsync(Guid id)
        {
            var hisUserResponse = await _personFhirCrudHelper.GetAsync(id);
            var wardResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            var wards = await _wardRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id == hisUserResponse.Id).Select(x => x.Ward).Distinct().ToListAsync();
            if (wards.Any())
                wards.ForEach(x => wardResponses.Add(UtilityHelper.MapLocation(x)));

            var hospitalResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            var hospitals = await _hospitalRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id == hisUserResponse.Id).Select(x => x.Hospital).Distinct().ToListAsync();
            if (hospitals.Any())
                hospitals.ForEach(x => hospitalResponses.Add(UtilityHelper.MapLocation(x)));


            UtilityHelper.TrySetProperty(hisUserResponse, "Wards", wardResponses);
            UtilityHelper.TrySetProperty(hisUserResponse, "Hospitals", hospitalResponses);

            return hisUserResponse;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        public async Task<HisUserResponse> GetByIdNumberAsync(string identityNumber)
        {
            var hisUserResponse = await _personFhirCrudHelper.GetByIdNumberAsync(identityNumber);
            var wardResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            var wards = await _wardRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id == hisUserResponse.Id).Select(x => x.Ward).Distinct().ToListAsync();
            if (wards.Any())
                wards.ForEach(x => wardResponses.Add(UtilityHelper.MapLocation(x)));

            var hospitalResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            var hospitals = await _hospitalRoleAppointedPersonRepository.GetAll().Where(x => x.Person.Id == hisUserResponse.Id).Select(x => x.Hospital).Distinct().ToListAsync();
            if (hospitals.Any())
                hospitals.ForEach(x => hospitalResponses.Add(UtilityHelper.MapLocation(x)));


            UtilityHelper.TrySetProperty(hisUserResponse, "Wards", wardResponses);
            UtilityHelper.TrySetProperty(hisUserResponse, "Hospitals", hospitalResponses);

            return hisUserResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HisUserResponse> CreateAsync(HisUserInput input)
        {
            var hisUser = _mapper.Map<HisUser>(input);
            var hisUserResponse = await _personFhirCrudHelper.CreateAsync(input, hisUser);

            List<EntityWithDisplayNameDto<Guid?>> shaRoleAppointedPersonResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            if (input?.Roles != null && input?.Roles.Count() > 0)
            {
                if (input?.Wards != null)
                {
                    foreach (var ward in input?.Wards)
                    {
                        var taskWardRoleAppointedPersons = new List<Task<WardRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                        input.Roles.ForEach((wardRoleAppointedInput) => taskWardRoleAppointedPersons.Add(CreateWardRoleAppointedPerson(wardRoleAppointedInput, ward, hisUser)));
                        var wardRoleAppointedPersons = ((IList<WardRoleAppointedPerson>)await Task.WhenAll(taskWardRoleAppointedPersons)); //save identifiers to db
                        shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(wardRoleAppointedPersons.ToList()));
                    }
                }

                if (input?.Hospitals != null)
                {
                    foreach (var hospital in input?.Hospitals)
                    {
                        var taskHospitalRoleAppointedPersons = new List<Task<HospitalRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                        input.Roles.ForEach((hospitalRoleAppointedInput) => taskHospitalRoleAppointedPersons.Add(CreateHospitalRoleAppointedPerson(hospitalRoleAppointedInput, hospital, hisUser)));
                        var hospitalRoleAppointedPersons = ((IList<HospitalRoleAppointedPerson>)await Task.WhenAll(taskHospitalRoleAppointedPersons)); //save identifiers to db
                        shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(hospitalRoleAppointedPersons.ToList()));
                    }
                }
            }

            UtilityHelper.TrySetProperty(hisUserResponse, "Roles", shaRoleAppointedPersonResponses);

            return hisUserResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HisUserResponse> UpdateAsync(HisUserInput input)
        {
            var dbPersonFhirBase = await _repository.GetAsync(input.Id);
            var hisUserResponse = await _personFhirCrudHelper.UpdateAsync(input);

            List<EntityWithDisplayNameDto<Guid?>> shaRoleAppointedPersonResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            if ((bool)(input?.Roles.Any()))
            {
                //Delete old ShaRoleAppointmentPerson when deleting
                var dbShaRoleAppointedPersons = await _shaRoleAppointedPersonRepository.GetAllListAsync(x => x.Person.Id == hisUserResponse.Id);
                dbShaRoleAppointedPersons.ForEach(x => x.IsDeleted = false);
                var taskDeleteShaRoleAppointedPersons = new List<Task>();
                dbShaRoleAppointedPersons.ForEach((shaRoleAppointedPerson) => taskDeleteShaRoleAppointedPersons.Add(DeleteShaRoleAppointedPerson(shaRoleAppointedPerson)));

                input?.Wards?.RemoveAll(x => x.Id == null);

                foreach (var ward in input?.Wards)
                {
                    var taskWardRoleAppointedPersons = new List<Task<WardRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((wardRoleAppointedInput) => taskWardRoleAppointedPersons.Add(CreateWardRoleAppointedPerson(wardRoleAppointedInput, ward, dbPersonFhirBase)));
                    var wardRoleAppointedPersons = ((IList<WardRoleAppointedPerson>)await Task.WhenAll(taskWardRoleAppointedPersons)); //save identifiers to db
                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(wardRoleAppointedPersons.ToList()));
                }

                input?.Hospitals?.RemoveAll(x => x.Id == null);

                foreach (var hospital in input?.Hospitals)
                {
                    var taskHospitalRoleAppointedPersons = new List<Task<HospitalRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((hospitalRoleAppointedInput) => taskHospitalRoleAppointedPersons.Add(CreateHospitalRoleAppointedPerson(hospitalRoleAppointedInput, hospital, dbPersonFhirBase)));
                    var hospitalRoleAppointedPersons = ((IList<HospitalRoleAppointedPerson>)await Task.WhenAll(taskHospitalRoleAppointedPersons)); //save identifiers to db


                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(hospitalRoleAppointedPersons.ToList()));
                }
            }

            return hisUserResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            await _personFhirCrudHelper.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="role"></param>
        /// <param name="ward"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<WardRoleAppointedPerson> CreateWardRoleAppointedPerson<T>(EntityWithDisplayNameDto<Guid?> role, EntityWithDisplayNameDto<Guid?> ward, T ownerEntity) where T : HisUser
        {
            var dbShaRole = await _shaRoleRepository.FirstOrDefaultAsync(r => r.Id == role.Id);
            if (dbShaRole == null)
                throw new UserFriendlyException("The specified role does not exist");

            var dbWard = await _wardRepository.GetAsync(ward.Id.Value);
            var wardRoleAppointed = new WardRoleAppointedPerson { Person = ownerEntity, Role = dbShaRole, Ward = dbWard };
            using (var uow = _unitOfWork.Begin())
            {
                wardRoleAppointed = await _wardRoleAppointedPersonRepository.InsertAsync(wardRoleAppointed);
                uow.Complete();
            }

            return wardRoleAppointed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="role"></param>
        /// <param name="hospital"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<HospitalRoleAppointedPerson> CreateHospitalRoleAppointedPerson<T>(EntityWithDisplayNameDto<Guid?> role, EntityWithDisplayNameDto<Guid?> hospital, T ownerEntity) where T : HisUser
        {
            var dbShaRole = await _shaRoleRepository.FirstOrDefaultAsync(r => r.Id == role.Id);
            if (dbShaRole == null)
                throw new UserFriendlyException("The specified role does not exist");

            var dbHospital = await _hospitalRepository.GetAsync(hospital.Id.Value);
            var hospitalRoleAppointed = new HospitalRoleAppointedPerson { Person = ownerEntity, Role = dbShaRole, Hospital = dbHospital };
            using (var uow = _unitOfWork.Begin())
            {
                hospitalRoleAppointed = await _hospitalRoleAppointedPersonRepository.InsertAsync(hospitalRoleAppointed);
                uow.Complete();
            }

            return _mapper.Map<HospitalRoleAppointedPerson>(hospitalRoleAppointed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaRoleAppointedPerson"></param>
        /// <returns></returns>
        private async Task DeleteShaRoleAppointedPerson(ShaRoleAppointedPerson shaRoleAppointedPerson)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _shaRoleAppointedPersonRepository.DeleteAsync(shaRoleAppointedPerson);
                uow.Complete();
            }
        }
    }
}
