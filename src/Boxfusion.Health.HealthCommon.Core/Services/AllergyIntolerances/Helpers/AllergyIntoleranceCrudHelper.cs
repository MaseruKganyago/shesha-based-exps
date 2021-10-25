using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Transform;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.AllergyIntolerances.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AllergyIntoleranceCrudHelper: SheshaAppServiceBase, IAllergyIntoleranceCrudHelper, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<AllergyIntolerance, Guid> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<AllergyIntoleranceCode, Guid> _allergyIntoleranceCodeRepository;
        private readonly IRepository<AllergyIntoleranceCodeAssignment, Guid> _allergyIntoleranceCodeAssignmentRepository;

        /// <summary>
        /// 
        /// </summary>
        public AllergyIntoleranceCrudHelper(IUnitOfWorkManager unitOfWorkManager,
            IRepository<AllergyIntolerance, Guid> repository,
            IMapper mapper,
            IRepository<AllergyIntoleranceCode, Guid> allergyIntoleranceCodeRepository,
            IRepository<AllergyIntoleranceCodeAssignment, Guid> allergyIntoleranceCodeAssignmentRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWorkManager = unitOfWorkManager;
            _allergyIntoleranceCodeRepository = allergyIntoleranceCodeRepository;
            _allergyIntoleranceCodeAssignmentRepository = allergyIntoleranceCodeAssignmentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AllergyIntoleranceResponse>> GetAllAsync()
        {
            var entityList = _mapper.Map<List<AllergyIntoleranceResponse>>(await _repository.GetAllListAsync());

            //Gets all allergyIntoleranceCodeAssignments for each allergyIntolerance and maps to result
            var tasks = new List<Task>();
            if (entityList?.Count > 0)
            {
                entityList.ForEach(entity => tasks.Add(MapAllergyCodes(entity)));
            }
            await Task.WhenAll(tasks);

            return entityList;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<AllergyIntoleranceResponse> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new UserFriendlyException("id cannot be null.");

            var entity = await _repository.GetAsync(id);
            if (entity == null) throw new UserFriendlyException("Condition with specified id does not exist.");
            var entityResult = _mapper.Map<AllergyIntoleranceResponse>(entity);

            //Gets all allergyIntoleranceCodeAssignments for the allergyIntolerance and maps to result
            entityResult.AllergyCodes = ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(await _allergyIntoleranceCodeAssignmentRepository
                                                                                            .GetAllListAsync(a => a.AllergyIntolerance.Id == entityResult.Id));

            return entityResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<AllergyIntoleranceResponse>> GetByPatientIdAsync(Guid patientId)
        {
            if (patientId == Guid.Empty) throw new UserFriendlyException("patientId cannot be null.");
            var entityList = _mapper.Map<List<AllergyIntoleranceResponse>>(await _repository.GetAllListAsync(a => a.Patient.Id == patientId));

            var tasks = new List<Task>();
            if (entityList?.Count > 0)
            {
                entityList.ForEach(entity => tasks.Add(MapAllergyCodes(entity)));
            }

            await Task.WhenAll(tasks);
            return entityList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<AllergyIntoleranceResponse>> GetByPratitionerIdAsync(Guid practitionerId)
        {
            if (practitionerId == Guid.Empty) throw new UserFriendlyException("practitionerId cannot be null.");
            var entityList = _mapper.Map<List<AllergyIntoleranceResponse>>(await _repository.GetAllListAsync(a => a.Asserter.Id == practitionerId || a.Recorder.Id == practitionerId));

            var tasks = new List<Task>();
            if (entityList?.Count > 0)
            {
                entityList.ForEach(entity => tasks.Add(MapAllergyCodes(entity)));
            }

            await Task.WhenAll(tasks);
            return entityList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AllergyIntoleranceResponse> CreateAsync(AllergyIntoleranceInput input)
        {
            var allergyIntoleranceResult = await SaveOrUpdateEntityAsync<AllergyIntolerance>(null, async item =>
            {
                ObjectMapper.Map(input, item);
            });

            #region Creates new allergyIntoleranceCodeAssignments using newly created allergyIntolerance
            var tasks = new List<Task<EntityWithDisplayNameDto<Guid?>>>();
            input.AllergyCodes.ForEach(code => tasks.Add(CreateAllergyIntoleranceCodeAssignmets(code, allergyIntoleranceResult)));

            var result = _mapper.Map<AllergyIntoleranceResponse>(allergyIntoleranceResult);
            result.AllergyCodes = (await Task.WhenAll(tasks)).ToList<EntityWithDisplayNameDto<Guid?>>();
            #endregion

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AllergyIntoleranceResponse> UpdateAsync(AllergyIntoleranceInput input)
        {
            var allergyIntoleranceResult = await SaveOrUpdateEntityAsync<AllergyIntolerance>(input.Id, async item => {
                ObjectMapper.Map(input, item);
                item.IsDeleted = false;
            });

            #region Handles all related assignments between AllergyIntolerance and AllergyIntoleranceCode
            var updateOrCreateAllergyIntoleranceCodeAssignmetsTasks = new List<Task<EntityWithDisplayNameDto<Guid?>>>();
            if (input.AllergyCodes?.Count > 0)
            {
                var localCodes = input.AllergyCodes;
                var allergyIntoleranceCodeAssignments = new List<AllergyIntoleranceCodeAssignment>();
                using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
                {
                    allergyIntoleranceCodeAssignments = await _allergyIntoleranceCodeAssignmentRepository.GetAllListAsync(a => a.AllergyIntolerance.Id == allergyIntoleranceResult.Id);
                }

                foreach (var item in allergyIntoleranceCodeAssignments)
                {
                    if (localCodes.Exists(a => a.Id == item.AllergyIntoleranceCode.Id))
                    {
                        var temp = localCodes.FirstOrDefault(b => b.Id == item.AllergyIntoleranceCode.Id);
                        if (!item.IsDeleted)
                        {
                            localCodes.Remove(temp);
                        }
                        else
                        {
                            updateOrCreateAllergyIntoleranceCodeAssignmetsTasks.Add(UpdateAllergyIntoleranceCodeAssignments(item, allergyIntoleranceResult));
                            localCodes.Remove(temp);
                        }
                    }
                    else
                    {
                        await _allergyIntoleranceCodeAssignmentRepository.DeleteAsync(item.Id);
                    }
                }
                localCodes.ForEach(code =>
                {
                    updateOrCreateAllergyIntoleranceCodeAssignmetsTasks.Add(CreateAllergyIntoleranceCodeAssignmets(code, allergyIntoleranceResult));
                });
            }
            await Task.WhenAll(updateOrCreateAllergyIntoleranceCodeAssignmetsTasks);
            #endregion

            var result = _mapper.Map<AllergyIntoleranceResponse>(allergyIntoleranceResult);
            await MapAllergyCodes(result);

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) throw new UserFriendlyException("id cannot be null.");
            var conditionEntity = await _repository.GetAsync(id);

            if (conditionEntity == null) throw new UserFriendlyException("Condition with specified id does not exist.");
            await _repository.DeleteAsync(id);
        }

        private async Task<EntityWithDisplayNameDto<Guid?>> CreateAllergyIntoleranceCodeAssignmets(EntityWithDisplayNameDto<Guid?> code, AllergyIntolerance allergyIntoleranceResult)
        {
            var allergyIntoleranceCodeAssignment = await SaveOrUpdateEntityAsync<AllergyIntoleranceCodeAssignment>(null, async item =>
            {
                item.AllergyIntolerance = allergyIntoleranceResult;
                item.AllergyIntoleranceCode = await _allergyIntoleranceCodeRepository.GetAsync((Guid)code.Id);
            });

            return ObjectMapper.Map<EntityWithDisplayNameDto<Guid?>>(allergyIntoleranceCodeAssignment);
        }

        private async Task<EntityWithDisplayNameDto<Guid?>> UpdateAllergyIntoleranceCodeAssignments(AllergyIntoleranceCodeAssignment assignment, AllergyIntolerance allergyIntoleranceEntity)
        {
            var updatedAssignment = await SaveOrUpdateEntityAsync<AllergyIntoleranceCodeAssignment>(assignment.Id, async item =>
            {
                item.AllergyIntolerance = allergyIntoleranceEntity;
                item.AllergyIntoleranceCode = assignment.AllergyIntoleranceCode;
                item.IsDeleted = false;
            });

            return ObjectMapper.Map<EntityWithDisplayNameDto<Guid?>>(updatedAssignment);
        }

        private async Task MapAllergyCodes(AllergyIntoleranceResponse entity)
        {
            entity.AllergyCodes = ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(await _allergyIntoleranceCodeAssignmentRepository
                                                                                                .GetAllListAsync(a => a.AllergyIntolerance.Id == entity.Id));
        }
    }
}
