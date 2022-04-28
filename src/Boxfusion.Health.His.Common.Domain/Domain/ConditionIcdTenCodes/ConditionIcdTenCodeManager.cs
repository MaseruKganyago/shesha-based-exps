using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.ConditionIcdTenCodes
{
	/// <summary>
	/// TO DO: Code to be moved to CDM
	/// Implements generic methods of ConditionIcdTenCode
	/// </summary>
	public class ConditionIcdTenCodeManager: DomainService
	{
		private readonly IDynamicRepository _dynamicRepository;

		/// <summary>
		/// 
		/// </summary>
		public ConditionIcdTenCodeManager(IDynamicRepository dynamicRepository)
		{
			_dynamicRepository = dynamicRepository;
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
			var tasks = new List<Task<T>>();
			icdTenCodes.ForEach(code =>
			{
				tasks.Add(DoAssigment(code, condition, action));
			});

			return (await Task.WhenAll<T>(tasks)).ToList();
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
			var localCodes = icdTenCodes;

			var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();
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
			var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();

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
			}
		}

		private async Task<T> DoAssigment<T>(IcdTenCode code, Condition condition, Func<T, Task> action) where T : ConditionIcdTenCode
		{
			var assignment = (T)Activator.CreateInstance(typeof(T));
			if (action is not null) await action.Invoke(assignment);

			assignment.IcdTenCode = code;
			assignment.Condition = condition;

			await _dynamicRepository.SaveOrUpdateAsync(assignment);

			return assignment;
		}
	}
}
