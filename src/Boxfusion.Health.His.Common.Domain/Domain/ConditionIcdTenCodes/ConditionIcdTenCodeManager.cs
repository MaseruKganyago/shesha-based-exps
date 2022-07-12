using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.NHibernate;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.ConditionIcdTenCodes
{
	/// <summary>
	/// TODO: Code to be moved to CDM
	/// Implements generic methods of ConditionIcdTenCode
	/// </summary>
	public class ConditionIcdTenCodeManager: DomainService
	{
		private readonly IDynamicRepository _dynamicRepository;
		private readonly IRepository<IcdTenCode, Guid> _icdTenCodeRepository;
		private readonly IRepository<Condition, Guid> _conditionRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dynamicRepository"></param>
		/// <param name="icdTenCodeRepository"></param>
		/// <param name="conditionRepository"></param>
		public ConditionIcdTenCodeManager(IDynamicRepository dynamicRepository, 
			IRepository<IcdTenCode, Guid> icdTenCodeRepository,
			IRepository<Condition, Guid> conditionRepository)
		{
			_dynamicRepository = dynamicRepository;
			_icdTenCodeRepository = icdTenCodeRepository;
			_conditionRepository = conditionRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputCodes"></param>
		/// <returns></returns>
		public async Task<List<IcdTenCode>> GetIcdTenCodes(List<Guid> inputCodes)
		{
			var codes = new List<IcdTenCode>();
			inputCodes.ForEach(async codeId =>
			{
				codes.Add(await _icdTenCodeRepository.GetAsync(codeId));
			});

			return codes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="icdTenCodes"></param>
		/// <param name="condition"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public async Task<List<T>> AssignIcdTenCodeToCondition<T>(List<IcdTenCode> icdTenCodes, Condition condition, Func<T, Task> action = null) 
			where T: ConditionIcdTenCode
		{
			var resultList = new List<T>();
			icdTenCodes.ForEach(async code =>
			{
				resultList.Add(await DoAssigment(code, condition, action));
			});

			return resultList;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="icdTenCodes"></param>
		/// <param name="condition"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public async Task<List<T>> UpdateAssignedIcdTenCodes<T>(List<IcdTenCode> icdTenCodes, Condition condition, Func<T, Task> action = null) 
			where T : ConditionIcdTenCode
		{
			try
			{
				var localCodes = icdTenCodes;

				var repo = StaticContext.IocManager.Resolve<IRepository<T, Guid>>();
				List<T> existingAssignments = null;
				using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
				{
					existingAssignments = await repo.GetAllListAsync(a => a.Condition.Id == condition.Id);
				}
				await UpdateExisistingAssignments(localCodes, existingAssignments);

				var tasks = new List<Task<T>>();
				localCodes.ForEach(code =>
				{
					tasks.Add(DoAssigment(code, condition, action));
				});

				return (await Task.WhenAll<T>(tasks)).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="condition"></param>
		/// <returns></returns>
		public async Task DeleteAssignment<T>(Condition condition) where T: ConditionIcdTenCode
		{
			var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();
			var assignments = await repo.GetAllListAsync(a => a.Condition.Id == condition.Id);

			assignments.ForEach(async asgn =>
			{
				await repo.DeleteAsync(asgn.Id);
			});

			await _conditionRepository.DeleteAsync(condition.Id);
		}

		private async Task UpdateExisistingAssignments<T>(List<IcdTenCode> codes, List<T> existingAssignments) where T : ConditionIcdTenCode
		{
			var tasks = new List<Task>();
			existingAssignments.ForEach(assignement =>
			{
				tasks.Add(ActionUpdate(codes, assignement));
			});

			await Task.WhenAll(tasks);
		}

		/// <summary>
		/// Iterates through existing assigments and current codes and update the codes accordingly.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="codes"></param>
		/// <param name="assignement"></param>
		/// <returns></returns>
		private async Task ActionUpdate<T>(List<IcdTenCode> codes, T assignement) where T : ConditionIcdTenCode
		{
			var repo = StaticContext.IocManager.Resolve<IRepository<T, Guid>>();

			if (codes.Contains(assignement.IcdTenCode))
			{
				if (assignement.IsDeleted)
				{
					assignement.IsDeleted = false;
					await repo.UpdateAsync(assignement);
				}

				codes.Remove(assignement.IcdTenCode);
			}
			else
			{
				if (!assignement.IsDeleted) await repo.DeleteAsync(assignement);
				codes.Remove(assignement.IcdTenCode);
			}
		}

		private async Task<T> DoAssigment<T>(IcdTenCode code, Condition condition, Func<T, Task> action) where T : ConditionIcdTenCode
		{
			try
			{				
				var assignment = (T)Activator.CreateInstance(typeof(T));
				if (action is not null) await action.Invoke(assignment);

				assignment.IcdTenCode = code;
				assignment.Condition = condition;

				await _dynamicRepository.SaveOrUpdateAsync(assignment);

				return assignment;
			}
			catch (Exception ex)
			{

				throw new UserFriendlyException(ex.Message, ex.InnerException);
			}
		}
	}
}
