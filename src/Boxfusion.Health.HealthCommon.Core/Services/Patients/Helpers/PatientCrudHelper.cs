using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Shesha;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Patients.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PatientCrudHelper<T>: SheshaAppServiceBase, ITransientDependency, IPatientCrudHelper<T> where T : CdmPatient
	{
		private readonly IRepository<T, Guid> _repository;
		private readonly IUnitOfWorkManager _unitOfWork;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="unitOfWork"></param>
		public PatientCrudHelper(IRepository<T, Guid> repository, IUnitOfWorkManager unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<List<T>> GetAllAsync()
		{
			return await _repository.GetAllListAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<T> GetByIdAsync(Guid id)
		{
			Validation.ValidateIdWithException(id, "id can not be null.");

			return await _repository.GetAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="entity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public async Task<T> CreateOrUpdateAsync(CdmPatientInput input, T entity, Func<Task> action = null)
		{
			//Validate if submitted identity number doesn't belong to another person 
			var identityNumber = input.Identifiers.Where(x => x.Type.ItemValue == (int)RefListIdentifierTypes.SAID).Select(x => x.Value).FirstOrDefault() ?? input?.IdentityNumber; //get identity number

			if (input?.Identifiers.Count() > 0)
			{
				var patientExist = await _repository.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
				if (patientExist != null)
					throw new UserFriendlyException("Patient with provided identity number already exists");
			}

			var patientEntity = input.Id == null ? await _repository.InsertAsync(entity) : await _repository.UpdateAsync(entity);

			#region
			//Add address
			CdmAddress address = null;
			if (input?.Address != null)
			{
				address = await SaveOrUpdateEntityAsync<CdmAddress>((Guid?)Validation.ValidateId(input?.Address?.Id), async item =>
				{
					ObjectMapper.Map(input.Address, item);
					item.OwnerId = patientEntity.Id.ToString();
					item.OwnerType = patientEntity.GetTypeShortAlias();
				});
			}

			//adds a list of Identifiers BackboneElements to a taskList
			if (input?.Identifiers != null && input?.Identifiers.Count() > 0)
			{
				var taskIdentifiers = new List<Task<IdentifierResponse>>(); //Tasks lists to handle batch insert into database
				input.Identifiers.ForEach((v) => taskIdentifiers.Add(CreateOrUpdateIdentifier(v, patientEntity)));
				await Task.WhenAll(taskIdentifiers); //save identifiers to db
			}

			//adds a list of ContactPoints BackboneElements to a taskList
			if (input?.ContactPoints != null && input?.ContactPoints.Count() > 0)
			{
				var taskContactPoints = new List<Task<ContactPointResponse>>(); //Tasks lists to handle batch insert into database
				input.ContactPoints.ForEach((v) => taskContactPoints.Add(CreateOrUpdateContactPoint(v, patientEntity)));
				await Task.WhenAll(taskContactPoints); //save contact points to db
			}

			//adds a list of Contacts BackboneElements to a taskList
			if (input?.Contacts != null && input?.Contacts.Count() > 0)
			{
				var taskContacts = new List<Task<ContactResponse>>(); //Tasks lists to handle batch insert into database
				input.Contacts.ForEach((v) => taskContacts.Add(CreateOrUpdateContact(v, patientEntity)));
				await Task.WhenAll(taskContacts); //save contacts to db
			}

			//additional optional logic handled by action
			if (action != null) await action.Invoke();
			#endregion

			return patientEntity;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Guid id)
		{
			Validation.ValidateIdWithException(id, $"{typeof(T).Name} Id cannot be empty");

			var entity = await _repository.GetAsync(id);
			if (entity == null) throw new UserFriendlyException($"{typeof(T).Name} with specified id does not exist.");

			await _repository.DeleteAsync(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="patient"></param>
		/// <returns></returns>
		private async Task<ContactResponse> CreateOrUpdateContact(ContactInput input, T patient)
		{
			var entity = new Contact();
			using (var uow = _unitOfWork.Begin())
			{
				entity = await SaveOrUpdateEntityAsync<Contact>(null, async item =>
				{
					ObjectMapper.Map(input, item);
					item.OwnerId = patient.Id.ToString();
					item.OwnerType = patient.GetTypeShortAlias();
				});
				uow.Complete();
			}

			return ObjectMapper.Map<ContactResponse>(entity);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="patient"></param>
		/// <returns></returns>
		private async Task<ContactPointResponse> CreateOrUpdateContactPoint<T>(ContactPointInput input, T patient) where T: CdmPatient
		{
			var entity = new ContactPoint();
			using (var uow = _unitOfWork.Begin())
			{
				entity = await SaveOrUpdateEntityAsync<ContactPoint>((Guid?)Validation.ValidateId(input?.Id), async item =>
				{
					ObjectMapper.Map(input, item);
					item.OwnerId = patient.Id.ToString();
					item.OwnerType = patient.GetTypeShortAlias();

				});
				uow.Complete();
			}

			return ObjectMapper.Map<ContactPointResponse>(entity);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="patient"></param>
		/// <returns></returns>
		private async Task<IdentifierResponse> CreateOrUpdateIdentifier<T>(IdentifierInput input, T patient) where T: CdmPatient
		{
			var entity = new Identifier();
			using (var uow = _unitOfWork.Begin())
			{
					
				entity = await SaveOrUpdateEntityAsync<Identifier>((Guid?)Validation.ValidateId(input?.Id), async item =>
				{
					ObjectMapper.Map(input, item);
					item.OwnerId = patient.Id.ToString();
					item.OwnerType = patient.GetTypeShortAlias();

				});
				await uow.CompleteAsync();

			}

			return ObjectMapper.Map<IdentifierResponse>(entity);
		}
	}
}
