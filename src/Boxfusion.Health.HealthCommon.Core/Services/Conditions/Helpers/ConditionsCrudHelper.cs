using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos;
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

namespace Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ConditionsCrudHelper: SheshaAppServiceBase, IConditionsCrudHelper, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Condition, Guid> _repository;
        private readonly IRepository<ConditionIcdTenCode, Guid> _conditionIcdTenCodeRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="repository"></param>
        /// <param name="conditionIcdTenCodeRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="icdTenCodeRepository"></param>
        public ConditionsCrudHelper(IUnitOfWorkManager unitOfWorkManager,
            IRepository<Condition, Guid> repository,
            IRepository<ConditionIcdTenCode, Guid> conditionIcdTenCodeRepository,
            IMapper mapper,
            IRepository<IcdTenCode, Guid> icdTenCodeRepository)
        {
            _repository = repository;
            _conditionIcdTenCodeRepository = conditionIcdTenCodeRepository;
            _mapper = mapper;
            _icdTenCodeRepository = icdTenCodeRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ConditionResponse>> GetAllAsync()
        {
            var conditionsResultList = _mapper.Map<List<ConditionResponse>>(await _repository.GetAllListAsync());

            //Gets all conditionIcdTenCodeAssignments for each condition and maps to result
            var tasks = new List<Task>();
			if (conditionsResultList?.Count > 0)
			{
                conditionsResultList.ForEach(condition => tasks.Add(MapIcdTenCodes(condition)));
            }
            await Task.WhenAll(tasks);

            return conditionsResultList;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<ConditionResponse> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new UserFriendlyException("id cannot be null.");

            var entity = await _repository.GetAsync(id);
            if (entity == null) throw new UserFriendlyException("Condition with specified id does not exist.");
            var conditionResult = _mapper.Map<ConditionResponse>(entity);

            //Gets all conditionIcdTenCodeAssignments for the condition and maps to result
            conditionResult.Code = ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(await _conditionIcdTenCodeRepository
                                                                                                .GetAllListAsync(a => a.Condition.Id == conditionResult.Id));

            return conditionResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<List<ConditionResponse>> GetByPatientIdAsync(Guid patientId)
        {
            if (patientId == Guid.Empty) throw new UserFriendlyException("patientId cannot be null.");
            var conditionsResultList = _mapper.Map<List<ConditionResponse>>(await _repository.GetAllListAsync(a => a.Subject.Id == patientId));

            //Gets all conditionIcdTenCodeAssignments for each condition and maps to result
            var tasks = new List<Task>();
            if (conditionsResultList?.Count > 0)
            {
                conditionsResultList.ForEach(condition => tasks.Add(MapIcdTenCodes(condition)));
            }
            await Task.WhenAll(tasks);

            return conditionsResultList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <returns></returns>
        public async Task<List<ConditionResponse>> GetByPratitionerIdAsync(Guid practitionerId)
        {
            if (practitionerId == Guid.Empty) throw new UserFriendlyException("practitionerId cannot be null.");
            var conditionsResultList = _mapper.Map<List<ConditionResponse>>(await _repository.GetAllListAsync(a => a.Asserter.Id == practitionerId || a.Recorder.Id == practitionerId));

            //Gets all conditionIcdTenCodeAssignments for each condition and maps to result
            var tasks = new List<Task>();
            if (conditionsResultList?.Count > 0)
            {
                conditionsResultList.ForEach(condition => tasks.Add(MapIcdTenCodes(condition)));
            }
            await Task.WhenAll(tasks);

            return conditionsResultList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ConditionResponse> CreateAsync(ConditionInput input)
        {
            var conditionResult = await _repository.InsertAsync(_mapper.Map<Condition>(input));

            #region Creates all conditionIcdTenCodeAssignment using newly created condition
            var tasks = new List<Task<EntityWithDisplayNameDto<Guid?>>>();
            input.Code.ForEach(code => tasks.Add(CreateConditionIcdTenCodeAssignments(code, conditionResult)));

            var result = _mapper.Map<ConditionResponse>(conditionResult);
            result.Code = (await Task.WhenAll(tasks)).ToList<EntityWithDisplayNameDto<Guid?>>();
            #endregion

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<ConditionResponse> UpdateAsync(ConditionInput input)
        {
            var conditionResult = await SaveOrUpdateEntityAsync<Condition>(input.Id, async item =>
            {
                ObjectMapper.Map(input, item);
                item.IsDeleted = false;
            });

            #region Handles the all realted assignments between Condition and IcdTenCodes
            var updateOrCreateConditionIcdTenCodeAssignmetsTasks = new List<Task<EntityWithDisplayNameDto<Guid?>>>();
            if (input.Code.Count > 0 && input.Code != null)
            {
                var localCodes = input.Code;
                var conditionIcdTenCodeAssignments = new List<ConditionIcdTenCode>();
                using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
                {
                    conditionIcdTenCodeAssignments = await _conditionIcdTenCodeRepository.GetAllListAsync(a => a.Condition.Id == conditionResult.Id);
                }

                foreach (var item in conditionIcdTenCodeAssignments)
                {
                    if (localCodes.Exists(a => a.Id == item.IcdTenCode.Id))
                    {
                        var temp = localCodes.FirstOrDefault(b => b.Id == item.IcdTenCode.Id);
                        if (!item.IsDeleted)
                        {
                            localCodes.Remove(temp);
                        }
                        else
                        {
                            updateOrCreateConditionIcdTenCodeAssignmetsTasks.Add(UpdateConditionIcdTenCodeAssignments(item, conditionResult));
                            localCodes.Remove(temp);
                        }
                    }
                    else
                    {
                        await _conditionIcdTenCodeRepository.DeleteAsync(item.Id);
                    }
                }
                localCodes.ForEach(code =>
                {
                    updateOrCreateConditionIcdTenCodeAssignmetsTasks.Add(CreateConditionIcdTenCodeAssignments(code, conditionResult));
                });
            }
            await Task.WhenAll(updateOrCreateConditionIcdTenCodeAssignmetsTasks);
            #endregion

            var result = _mapper.Map<ConditionResponse>(conditionResult);
            await MapIcdTenCodes(result);

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

        private async Task<EntityWithDisplayNameDto<Guid?>> CreateConditionIcdTenCodeAssignments(EntityWithDisplayNameDto<Guid?> code, Condition conditionResult)
        {
            var conditionIcdTenCodeAssignment = await SaveOrUpdateEntityAsync<ConditionIcdTenCode>(null, async item => {
                item.Condition = conditionResult;
                item.IcdTenCode = await _icdTenCodeRepository.GetAsync((Guid)code.Id);
            });

            return ObjectMapper.Map<EntityWithDisplayNameDto<Guid?>>(conditionIcdTenCodeAssignment);
        }

        private async Task<EntityWithDisplayNameDto<Guid?>> UpdateConditionIcdTenCodeAssignments(ConditionIcdTenCode assignment, Condition conditionEntity)
        {
            var conditionIcdTenCodeAssignment = await SaveOrUpdateEntityAsync<ConditionIcdTenCode>(assignment.Id, async item =>
            {
                item.Condition = conditionEntity;
                item.IcdTenCode = assignment.IcdTenCode;
                item.IsDeleted = false;
            });

            return ObjectMapper.Map<EntityWithDisplayNameDto<Guid?>>(conditionIcdTenCodeAssignment);
        }

        private async Task MapIcdTenCodes(ConditionResponse condition)
        {
			try
			{
                var list = await _conditionIcdTenCodeRepository.GetAllListAsync(a => a.Condition.Id == condition.Id);
                condition.Code = list?.Count > 0 ? ObjectMapper.Map<List<EntityWithDisplayNameDto<Guid?>>>(list) : null;
            }
			catch (Exception)
			{

                condition.Code = null;

            }
        }
    }
}
