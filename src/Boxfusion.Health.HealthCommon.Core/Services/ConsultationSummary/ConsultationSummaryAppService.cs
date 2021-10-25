using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Conditions.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary.Dtos;
using Boxfusion.Health.HealthCommon.Core.Services.Documents.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferToPractitionerServiceRequests.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.ConsultationSummary
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class ConsultationSummaryAppService: CdmAppServiceBase, IConsultationSummaryAppService
	{
		private readonly IRepository<CdmMedicationRequest, Guid> _medicationRequestRepository;
		private readonly IConditionsCrudHelper _conditionsAppServiceBase;
		private readonly IRepository<ChwVisitServiceRequest, Guid> _chwVisitServiceRequestRepository;
		private readonly IRepository<ReferralServiceRequest, Guid> _referralServiceRequestRepository;
		private readonly IRepository<AmbulanceServiceRequest, Guid> _ambulanceServiceRequestRepository;
		private readonly IReferToPractitionerHelper _referToPractitionerHelper;
		private readonly IDocumentCrudHelper _documentCrudHelper;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="medicationRequestRepository"></param>
		/// <param name="conditionsAppServiceBase"></param>
		/// <param name="chwVisitServiceRequestRepository"></param>
		/// <param name="referralServiceRequestRepository"></param>
		/// <param name="ambulanceServiceRequestRepository"></param>
		/// <param name="referToPractitionerHelper"></param>
		/// <param name="documentRepository"></param>
		public ConsultationSummaryAppService(IRepository<CdmMedicationRequest, Guid> medicationRequestRepository,
			IConditionsCrudHelper conditionsAppServiceBase,
			IRepository<ChwVisitServiceRequest, Guid> chwVisitServiceRequestRepository,
			IRepository<ReferralServiceRequest, Guid> referralServiceRequestRepository,
			IRepository<AmbulanceServiceRequest, Guid> ambulanceServiceRequestRepository,
			IReferToPractitionerHelper referToPractitionerHelper,
			IDocumentCrudHelper documentCrudHelper)
		{
			_medicationRequestRepository = medicationRequestRepository;
			_conditionsAppServiceBase = conditionsAppServiceBase;
			_chwVisitServiceRequestRepository = chwVisitServiceRequestRepository;
			_referralServiceRequestRepository = referralServiceRequestRepository;
			_ambulanceServiceRequestRepository = ambulanceServiceRequestRepository;
			_referToPractitionerHelper = referToPractitionerHelper;
			_documentCrudHelper = documentCrudHelper;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpGet, Route("")]
		public async Task<ConsultationSummaryResponse> GetConsultationSummary(ConsultationSummaryInput input)
		{
			var result = new ConsultationSummaryResponse();

			//Gets diagnosed conditions and returns a text string of diagnosis
			var diagnosisList = await _conditionsAppServiceBase.GetByPratitionerIdAsync(input.PractitionerId);
			diagnosisList?.RemoveAll(a => a.Subject?.Id != input.PatientId && a.Encounter?.Id != input.EncounterId);

			result.DiagnosisText = setDiagnosisText(diagnosisList);

			//Gets list of Medications and their Dosages as string texts
			var medicationList = await _medicationRequestRepository.GetAllListAsync(b => b.Subject.Id == input.PatientId && b.Encounter.Id == input.EncounterId
																		  && b.PerformerOwnerId == input.PractitionerId.ToString());

			result.MedicationTextList = setMedicationTexts(medicationList);

			//Gets list of ChwVisitRequest check if request exists, then sets ChwVisitRequestText accordingly 
			var chwVisitsList = await _chwVisitServiceRequestRepository.GetAllListAsync(c => c.Subject.Id == input.PatientId && c.Encounter.Id == input.EncounterId
																			  && c.RequestOwnerId == input.PractitionerId.ToString());

			if (chwVisitsList?.Count > 0) result.ChwVisitRequestText = "Requested a CHW Visit.";

			//Gets list of RefferalServiceRequest and returns Facilities reffered to as text string
			var referralList = await _referralServiceRequestRepository.GetAllListAsync(d => d.Subject.Id == input.PatientId && d.Encounter.Id == input.EncounterId
																				&& d.PerformerOwnerId == input.PractitionerId.ToString());

			result.ReferToFacilityText = setRefferalText(referralList);

			//Gets list of AmbulanceServiceRequest check if requests exists, then sets AmbulanceServiceRequest accordingly
			var ambulanceRequestsList = await _ambulanceServiceRequestRepository.GetAllListAsync(e => e.Subject.Id == input.PatientId && e.Encounter.Id == input.EncounterId
																				 && e.RequestOwnerId == input.PractitionerId.ToString());

			if (ambulanceRequestsList?.Count > 0) result.AmbulanceServiceRequestText = "Called an Ambulance.";

			//Gets list of DocumentReference with type Sicknote checks if documents exists, then sets SickNote accordingly
			var sickNoteList = await _documentCrudHelper.GetByConsultationIdAsync(input.EncounterId, input.PatientId);
			sickNoteList.RemoveAll(a => a.Type.ItemValue.Value != (long)RefListDocumentTypeValueSets.SickNote);

			if (sickNoteList?.Count > 0) result.SickNoteText = "Issued a Sick note letter.";

			//Gets list of RefereToPractitionerServiceRequest check if requests exists, then sets RefereToPractitionerServiceRequest accordingly
			var escalateToDrList = await _referToPractitionerHelper.GetByPratitionerAsync(input.PractitionerId);
			escalateToDrList?.RemoveAll(a => a.Subject?.Id != input.PatientId && a.Encounter?.Id != input.EncounterId);

			if (escalateToDrList?.Count > 0) result.EscalateToDrText = "Escalated to Dr.";

			return result;
		}

		private string setRefferalText(List<ReferralServiceRequest> referralList)
		{
			if (referralList?.Count == 0) return null;

			var result = new List<string>();
			var temp = new FacilityHolder();
			referralList.ForEach(referral =>
			{
				temp = ObjectMapper.Map<FacilityHolder>(referral);
				result.Add(temp.FacilityName);
			});

			return $"Refer to Facility ({result.Aggregate((i, j) => i + "," + j)})";
		}

		private List<MedicationTextModel> setMedicationTexts(List<CdmMedicationRequest> medicationList)
		{
			if (medicationList?.Count == 0) return null;

			var result = new List<MedicationTextModel>();
			medicationList.ForEach(medicationRequest =>
			{
				result.Add(ObjectMapper.Map<MedicationTextModel>(medicationRequest));
			});

			return result;
		}

		private string setDiagnosisText(List<ConditionResponse> diagnosisList)
		{
			if (diagnosisList?.Count == 0) return null;
			var diagnosisText = "";
			diagnosisList.ForEach(diagnosis =>
			{
				diagnosis.Code?.ForEach(code =>
				{
					diagnosisText = diagnosisText.Length > 0 ? $"{diagnosisText}, {code?.DisplayText}" : code?.DisplayText;
				});
			});

			return diagnosisText;
		}
	}
}
