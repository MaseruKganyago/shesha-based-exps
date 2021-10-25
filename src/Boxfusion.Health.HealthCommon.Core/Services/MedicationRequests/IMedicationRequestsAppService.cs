using Abp.Application.Services;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMedicationRequestsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AutocompleteItemDto>> GetMedicationProducts(int pageIndex = 1, int pageSize = 100, string value = "");
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetMedicationRequests();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CdmMedicationRequestResponse> GetMedicationRequest(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPatient(Guid patientId, Guid parentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPractitioner(Guid practitionerId, Guid parentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> CreateMedicationRequest(List<CdmMedicationRequestInput> input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CdmMedicationRequestResponse> UpdateMedicationRequest(CdmMedicationRequestUpdate input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteMedicationRequest(Guid id);
    }
}
