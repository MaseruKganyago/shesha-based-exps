using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Domain.Domain.Helpers;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Diagnoses
{
	/// <summary>
	/// To Do: Code to be moved to CDM
	/// Implements Generic methods constraint to Encounter(As diagnosis is backbone-element to Encounter) and Condition(As Diagnosis relates to condition)
	/// </summary>
	public class DiagnosisManager: DomainService
	{
		private readonly IRepository<Diagnosis, Guid> _diagnosisRepository;
		private readonly IDynamicRepository _dynamicRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="diagnosisRepository"></param>
		/// <param name="dynamicRepository"></param>
		public DiagnosisManager(IRepository<Diagnosis, Guid> diagnosisRepository, IDynamicRepository dynamicRepository)
		{
			_diagnosisRepository = diagnosisRepository;
			_dynamicRepository = dynamicRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="encouter"></param>
		/// <param name="use"></param>
		/// <param name="rank"></param>
		/// <param name="action">Accepts an awaitable method which actions on the condition of the diagnosis.</param>
		/// <returns></returns>
		public async Task<Diagnosis> AddNewDiagnosis<T1, T2>(T1 encouter, int use, int? rank, Func<T2, Task> action) where T1: Encounter where T2: Condition
		{
			#region Condition related-functionality
			var conditionItem = (T2)Activator.CreateInstance(typeof(T2));
			await action.Invoke(conditionItem);

			await _dynamicRepository.SaveOrUpdateAsync(conditionItem);
			#endregion

			var diagnosis = new Diagnosis
			{
				OwnerId = encouter.Id.ToString(),
				OwnerType = encouter.GetTypeShortAlias(),
				Condition = conditionItem,
				Use = use,
				Rank = rank
			};
			var newAddedDiagnosis = await _diagnosisRepository.InsertAsync(diagnosis);

			return newAddedDiagnosis;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="updatedEntity"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public async Task<Diagnosis> UpdateDiagnosis<T>(Diagnosis updatedEntity, Func<T, Task> action = null) where T : Condition
		{
			#region Condition related-functionality
			var conditionItem = await HisCommonDomainUtil.GetEntityAsync<T, Guid>(updatedEntity.Condition.Id);

			if (action is not null) await action.Invoke(conditionItem);
			await _dynamicRepository.SaveOrUpdateAsync(conditionItem);
			#endregion

			updatedEntity.Condition = conditionItem;
			var updatedDiagnosis = await _diagnosisRepository.UpdateAsync(updatedEntity);

			return updatedDiagnosis;
		}
	}
}
