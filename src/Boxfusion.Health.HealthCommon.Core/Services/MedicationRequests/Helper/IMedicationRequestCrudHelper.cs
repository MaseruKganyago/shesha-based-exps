using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Dtos.Fhir;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMedicationRequestCrudHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<List<AutocompleteItemDto>> GetMedpraxMedicationProductList(int pageIndex = 1, int pageSize = 100, string value = "");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CdmMedicationRequestResponse> GetId(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPatientId(Guid patientId, Guid parentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="practitionerId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> GetMedicationRequestsByPractitionerId(Guid practitionerId, Guid parentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cdmPractitioner"></param>
        /// <returns></returns>
        Task<List<CdmMedicationRequestResponse>> Create(List<CdmMedicationRequestInput> input, Person cdmPractitioner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CdmMedicationRequestResponse> Update(CdmMedicationRequestUpdate input);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
