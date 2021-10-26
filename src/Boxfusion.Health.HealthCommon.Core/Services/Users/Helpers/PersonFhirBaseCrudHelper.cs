using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Extentions;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Extensions;
using Shesha.Users.Dto;
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
    public class PersonFhirBaseCrudHelper<T, TResult> : IPersonFhirBaseCrudHelper<T, TResult>, ITransientDependency where T : PersonFhirBase where TResult : class
    {
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IRepository<T, Guid> _repository;
        private readonly IRepository<CdmAddress, Guid> _addressRepository;
        private readonly IRepository<Identifier, Guid> _identifierRepository;
        private readonly IRepository<ContactPoint, Guid> _contactPointRepository;
        private readonly IRepository<Contact, Guid> _contactRepository;
        private readonly IRepository<ShaRole, Guid> _shaRoleRepository;
        private readonly IRepository<WardRoleAppointedPerson, Guid> _wardRoleAppointedPersonRepository;
        private readonly IRepository<HospitalRoleAppointedPerson, Guid> _hospitalRoleAppointedPersonRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _shaRoleAppointedPersonRepository;
        private readonly IRepository<Hospital, Guid> _hospitalRepository;
        private readonly IRepository<Ward, Guid> _wardRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="repository"></param>
        /// <param name="addressRepository"></param>
        /// <param name="identifierRepository"></param>
        /// <param name="contactPointRepository"></param>
        /// <param name="contactRepository"></param>
        /// <param name="shaRoleRepository"></param>
        /// <param name="wardRoleAppointedPersonRepository"></param>
        /// <param name="hospitalRoleAppointedPersonRepository"></param>
        /// <param name="shaRoleAppointedPersonRepository"></param>
        /// <param name="hospitalRepository"></param>
        /// <param name="wardRepository"></param>
        /// <param name="mapper"></param>
        public PersonFhirBaseCrudHelper(
            IUnitOfWorkManager unitOfWork, 
            IRepository<T, Guid> repository, 
            IRepository<CdmAddress, Guid> addressRepository, 
            IRepository<Identifier, Guid> identifierRepository, 
            IRepository<ContactPoint, Guid> contactPointRepository, 
            IRepository<Contact, Guid> contactRepository, 
            IRepository<ShaRole, Guid> shaRoleRepository, 
            IRepository<WardRoleAppointedPerson, Guid> wardRoleAppointedPersonRepository,
            IRepository<HospitalRoleAppointedPerson, Guid> hospitalRoleAppointedPersonRepository,
            IRepository<ShaRoleAppointedPerson, Guid> shaRoleAppointedPersonRepository,
            IRepository<Hospital, Guid> hospitalRepository,
            IRepository<Ward, Guid> wardRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _addressRepository = addressRepository;
            _identifierRepository = identifierRepository;
            _contactPointRepository = contactPointRepository;
            _contactRepository = contactRepository;
            _shaRoleRepository = shaRoleRepository;
            _wardRoleAppointedPersonRepository = wardRoleAppointedPersonRepository;
            _hospitalRoleAppointedPersonRepository = hospitalRoleAppointedPersonRepository;
            _shaRoleAppointedPersonRepository = shaRoleAppointedPersonRepository;
            _hospitalRepository = hospitalRepository;
            _wardRepository = wardRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TResult>> GetAllAsync()
        {
            return _mapper.Map<List<TResult>>(await _repository.GetAllListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TResult> GetAsync(Guid id)
        {
            return _mapper.Map<TResult>(await _repository.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns></returns>
        public async Task<TResult> GetByIdNumberAsync(string identityNumber)
        {
            return _mapper.Map<TResult>(await _repository.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> CreateAsync(PersonFhirBaseInput input, T entity, Func<Task> action = null)
        {
            var personFhirBase = await _repository.InsertAsync(entity);

            List<EntityWithDisplayNameDto<Guid?>> shaRoleAppointedPersonResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            if (input?.Roles != null && input?.Roles.Count() > 0)
            {
                foreach (var ward in input?.Wards)
                {
                    var taskWardRoleAppointedPersons = new List<Task<WardRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((wardRoleAppointedInput) => taskWardRoleAppointedPersons.Add(CreateWardRoleAppointedPerson(wardRoleAppointedInput, ward, personFhirBase)));
                    var wardRoleAppointedPersons = ((IList<WardRoleAppointedPerson>)await Task.WhenAll(taskWardRoleAppointedPersons)); //save identifiers to db
                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(wardRoleAppointedPersons.ToList()));
                }

                foreach (var hospital in input?.Hospitals)
                {
                    var taskHospitalRoleAppointedPersons = new List<Task<HospitalRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((hospitalRoleAppointedInput) => taskHospitalRoleAppointedPersons.Add(CreateHospitalRoleAppointedPerson(hospitalRoleAppointedInput, hospital, personFhirBase)));
                    var hospitalRoleAppointedPersons = ((IList<HospitalRoleAppointedPerson>)await Task.WhenAll(taskHospitalRoleAppointedPersons)); //save identifiers to db


                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(hospitalRoleAppointedPersons.ToList()));
                }
            }

            //Add address
            CdmAddressResponse cdmAddressResponse = null;
            if (input?.Address != null)
            {
                var cmdAddress = _mapper.Map<CdmAddress>(input.Address);
                _mapper.Map(personFhirBase, cmdAddress);
                var insertedAddress = await _addressRepository.InsertAsync(cmdAddress);
                cdmAddressResponse = _mapper.Map<CdmAddressResponse>(insertedAddress);
            }

            //add a list of identifiers to a task
            List<IdentifierResponse> identifierResponses = null;
            if (input?.Identifiers != null && input?.Identifiers.Count() > 0)
            {
                var taskIdentifiers = new List<Task<IdentifierResponse>>(); //Tasks lists to handle batch insert into database
                input.Identifiers.ForEach((identifierInput) => taskIdentifiers.Add(CreateIdentifier(identifierInput, personFhirBase)));
                var identifiers = ((IList<IdentifierResponse>)await Task.WhenAll(taskIdentifiers)); //save identifiers to db
                identifierResponses = identifiers.ToList();
            }

            //add a list of contact points to a task
            List<ContactPointResponse> contactPointResponses = null;
            if (input?.ContactPoints != null && input?.ContactPoints.Count() > 0)
            {
                var taskContactPoints = new List<Task<ContactPointResponse>>(); //Tasks lists to handle batch insert into database
                input.ContactPoints.ForEach((v) => taskContactPoints.Add(CreateContactPoint(v, personFhirBase)));
                var contactPoints = ((IList<ContactPointResponse>)await Task.WhenAll(taskContactPoints)); //save contact points to db
                contactPointResponses = contactPoints.ToList();
            }

            //add a list of contacts to a task
            List<ContactResponse> contactResponses = null;
            if (input?.Contacts != null && input?.Contacts.Count() > 0)
            {
                var taskContacts = new List<Task<ContactResponse>>(); //Tasks lists to handle batch insert into database
                input.Contacts.ForEach((v) => taskContacts.Add(CreateContact(v, personFhirBase)));
                var contacts = ((IList<ContactResponse>)await Task.WhenAll(taskContacts)); // save contacts to db
                contactResponses = contacts.ToList();
            }

            var personFhirBaseResponse = _mapper.Map<TResult>(personFhirBase);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Address", cdmAddressResponse);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Identifiers", identifierResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "ContactPoints", contactPointResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Contacts", contactResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Roles", shaRoleAppointedPersonResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Wards", input?.Wards);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Hospitals", input?.Hospitals);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return personFhirBaseResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> UpdateAsync(PersonFhirBaseInput input, Func<Task> action = null)
        {
            var dbPersonFhirBase = await _repository.GetAsync(input.Id);
            _mapper.Map(input, dbPersonFhirBase);
            var updatedPersonFhirBase = await _repository.UpdateAsync(dbPersonFhirBase);

            List<EntityWithDisplayNameDto<Guid?>> shaRoleAppointedPersonResponses = new List<EntityWithDisplayNameDto<Guid?>>();
            if (input?.Roles != null && input?.Roles.Count() > 0)
            {
                //Delete old ShaRoleAppointmentPerson when deleting
                var dbShaRoleAppointedPersons = await _shaRoleAppointedPersonRepository.GetAllListAsync(x => x.Person == dbPersonFhirBase);
                dbShaRoleAppointedPersons.ForEach(x => x.IsDeleted = false);
                var taskDeleteShaRoleAppointedPersons = new List<Task>();
                dbShaRoleAppointedPersons.ForEach((shaRoleAppointedPerson) => taskDeleteShaRoleAppointedPersons.Add(DeleteShaRoleAppointedPerson(shaRoleAppointedPerson)));


                foreach (var ward in input?.Wards)
                {
                    var taskWardRoleAppointedPersons = new List<Task<WardRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((wardRoleAppointedInput) => taskWardRoleAppointedPersons.Add(CreateWardRoleAppointedPerson(wardRoleAppointedInput, ward, dbPersonFhirBase)));
                    var wardRoleAppointedPersons = ((IList<WardRoleAppointedPerson>)await Task.WhenAll(taskWardRoleAppointedPersons)); //save identifiers to db
                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(wardRoleAppointedPersons.ToList()));
                }

                foreach (var hospital in input?.Hospitals)
                {
                    var taskHospitalRoleAppointedPersons = new List<Task<HospitalRoleAppointedPerson>>(); //Tasks lists to handle batch insert into database
                    input.Roles.ForEach((hospitalRoleAppointedInput) => taskHospitalRoleAppointedPersons.Add(CreateHospitalRoleAppointedPerson(hospitalRoleAppointedInput, hospital, dbPersonFhirBase)));
                    var hospitalRoleAppointedPersons = ((IList<HospitalRoleAppointedPerson>)await Task.WhenAll(taskHospitalRoleAppointedPersons)); //save identifiers to db


                    shaRoleAppointedPersonResponses.AddRange(_mapper.Map< List < EntityWithDisplayNameDto<Guid?> > >(hospitalRoleAppointedPersons.ToList()));
                }
            }

            //Add address
            CdmAddressResponse cdmAddressResponse = null;
            if (input?.Address != null)
            {
                //Delete old ShaRoleAppointmentPerson when deleting
                var dbAddress = await _addressRepository.FirstOrDefaultAsync(x => x.OwnerId == dbPersonFhirBase.Id.ToString());
                await _addressRepository.DeleteAsync(dbAddress);

                //Add new address
                var cmdAddress = _mapper.Map<CdmAddress>(input.Address);
                _mapper.Map(dbPersonFhirBase, cmdAddress);
                var insertedAddress = await _addressRepository.InsertAsync(cmdAddress);
                cdmAddressResponse = _mapper.Map<CdmAddressResponse>(insertedAddress);
            }

            //add a list of identifiers to a task
            List<IdentifierResponse> identifierResponses = null;
            if (input?.Identifiers != null && input?.Identifiers.Count() > 0)
            {
                //Delete old identifiers when deleting
                var dbIdentifiers = await _identifierRepository.GetAllListAsync(x => x.OwnerId == dbPersonFhirBase.Id.ToString());
                dbIdentifiers.ForEach(x => x.IsDeleted = false);
                var taskDeleteIdentifiers = new List<Task>();
                dbIdentifiers.ForEach((identifier) => taskDeleteIdentifiers.Add(DeleteIdentifier(identifier)));

                //Add newly updated identifiers
                var taskIdentifiers = new List<Task<IdentifierResponse>>(); //Tasks lists to handle batch insert into database
                input.Identifiers.ForEach((identifierInput) => taskIdentifiers.Add(CreateIdentifier(identifierInput, dbPersonFhirBase)));
                var identifiers = ((IList<IdentifierResponse>)await Task.WhenAll(taskIdentifiers)); //save identifiers to db
                identifierResponses = identifiers.ToList();
            }

            //add a list of contact points to a task
            List<ContactPointResponse> contactPointResponses = null;
            if (input?.ContactPoints != null && input?.ContactPoints.Count() > 0)
            {
                //Delete old contact points when deleting
                var dbContactPoints = await _contactPointRepository.GetAllListAsync(x => x.OwnerId == dbPersonFhirBase.Id.ToString());
                dbContactPoints.ForEach(x => x.IsDeleted = false);
                var taskDeleteContactPoints = new List<Task>();
                dbContactPoints.ForEach((contactPoint) => taskDeleteContactPoints.Add(DeleteContactPoint(contactPoint)));

                //Add newly updated contact points
                var taskContactPoints = new List<Task<ContactPointResponse>>(); //Tasks lists to handle batch insert into database
                input.ContactPoints.ForEach((v) => taskContactPoints.Add(CreateContactPoint(v, dbPersonFhirBase)));
                var contactPoints = ((IList<ContactPointResponse>)await Task.WhenAll(taskContactPoints)); //save contact points to db
                contactPointResponses = contactPoints.ToList();
            }

            //add a list of contacts to a task
            List<ContactResponse> contactResponses = null;
            if (input?.Contacts != null && input?.Contacts.Count() > 0)
            {
                //Delete old contact points when deleting
                var dbContacts = await _contactRepository.GetAllListAsync(x => x.OwnerId == dbPersonFhirBase.Id.ToString());
                dbContacts.ForEach(x => x.IsDeleted = false);
                var taskDeleteContacts = new List<Task>();
                dbContacts.ForEach((contact) => taskDeleteContacts.Add(DeleteContact(contact)));

                var taskContacts = new List<Task<ContactResponse>>(); //Tasks lists to handle batch insert into database
                input.Contacts.ForEach((v) => taskContacts.Add(CreateContact(v, dbPersonFhirBase)));
                var contacts = ((IList<ContactResponse>)await Task.WhenAll(taskContacts)); // save contacts to db
                contactResponses = contacts.ToList();
            }

            var personFhirBaseResponse = _mapper.Map<TResult>(dbPersonFhirBase);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Address", cdmAddressResponse);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Identifiers", identifierResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "ContactPoints", contactPointResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Contacts", contactResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Roles", shaRoleAppointedPersonResponses);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Wards", input?.Wards);
            UtilityHelper.TrySetProperty(personFhirBaseResponse, "Hospitals", input?.Hospitals);

            //Additional logic from sub classes
            if (action != null) await action.Invoke();

            return personFhirBaseResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            await _repository.DeleteAsync(entity);
        }

        #region Helper Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="role"></param>
        /// <param name="ward"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
		private async Task<WardRoleAppointedPerson> CreateWardRoleAppointedPerson<T>(EntityWithDisplayNameDto<Guid> role, EntityWithDisplayNameDto<Guid> ward, T ownerEntity) where T : PersonFhirBase
        {
            var dbShaRole = await _shaRoleRepository.FirstOrDefaultAsync(r => r.Id == role.Id);
            var dbWard = await _wardRepository.GetAsync(ward.Id);
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
        private async Task<HospitalRoleAppointedPerson> CreateHospitalRoleAppointedPerson<T>(EntityWithDisplayNameDto<Guid> role, EntityWithDisplayNameDto<Guid> hospital, T ownerEntity) where T : PersonFhirBase
        {
            var dbShaRole = await _shaRoleRepository.FirstOrDefaultAsync(r => r.Id == role.Id);
            var dbHospital = await _hospitalRepository.GetAsync(hospital.Id);
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
		private async Task<ContactResponse> CreateContact<T>(ContactInput input, T ownerEntity) where T : PersonFhirBase
        {
            var entity = _mapper.Map<Contact>(input);
            using (var uow = _unitOfWork.Begin())
            {
                entity.OwnerId = ownerEntity.Id.ToString();
                entity.OwnerType = ownerEntity.GetType().GetAttributeValue((EntityAttribute dna) => dna.TypeShortAlias);
                entity = await _contactRepository.InsertAsync(entity);
                uow.Complete();
            }

            return _mapper.Map<ContactResponse>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        private async Task DeleteContact(Contact contact)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _contactRepository.DeleteAsync(contact);
                uow.Complete();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<ContactPointResponse> CreateContactPoint<T>(ContactPointInput input, T ownerEntity) where T : PersonFhirBase
        {
            var entity = _mapper.Map<ContactPoint>(input);
            using (var uow = _unitOfWork.Begin())
            {
                entity.OwnerId = ownerEntity.Id.ToString();
                entity.OwnerType = ownerEntity.GetType().GetAttributeValue((EntityAttribute dna) => dna.TypeShortAlias);
                entity = await _contactPointRepository.InsertAsync(entity);
                uow.Complete();
            }

            return _mapper.Map<ContactPointResponse>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contactPoint"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task DeleteContactPoint(ContactPoint contactPoint)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _contactPointRepository.DeleteAsync(contactPoint);
                uow.Complete();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<IdentifierResponse> CreateIdentifier<T>(IdentifierInput input, T ownerEntity) where T : PersonFhirBase
        {
            var entity = _mapper.Map<Identifier>(input);
            using (var uow = _unitOfWork.Begin())
            {
                entity.OwnerId = ownerEntity.Id.ToString();
                entity.OwnerType = ownerEntity.GetType().GetAttributeValue((EntityAttribute dna) => dna.TypeShortAlias);
                entity = await _identifierRepository.InsertAsync(entity);
                uow.Complete();
            }
            var noteResponse = _mapper.Map<IdentifierResponse>(entity);

            return noteResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        private async Task DeleteIdentifier(Identifier identifier)
        {
            using (var uow = _unitOfWork.Begin())
            {
                await _identifierRepository.DeleteAsync(identifier);
                uow.Complete();
            }
        }

        #endregion
    }
}
