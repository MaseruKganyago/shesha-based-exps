using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters
{
	/// <summary>
	/// 
	/// </summary>
	public interface IConsultationEncounterAppService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<ConsultationEncounterResponse>> GetAllConsultationEncounters();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ConsultationEncounterResponse> GetConsultationEncounterById(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <returns></returns>
		Task<List<ConsultationEncounterResponse>> GetConsultationEncounterssByPatient(Guid patientId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="practitionerId"></param>
		/// <returns></returns>
	    Task<List<ConsultationEncounterResponse>> GetConsultationEncountersByPractitioner(Guid practitionerId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConsultationEncounterResponse> CreateConsultationEncounter(ConsultationEncounterInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConsultationEncounterResponse> UpdateConsultationEncounter(ConsultationEncounterInput input);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteConsultationEncounter(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		Task<ConsultationEncounterResponse> ConsultationFeedback(FeedBackInput input);
	}
}
