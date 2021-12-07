using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.Separations.Helpers;
using Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/PatientSeparation")]
    public class SeparationsAppSerives : CdmAppServiceBase, ISeparationsAppService
    {
        private readonly ISeparationCrudHelper _separationCrudHelper;
        private readonly ISeparationService _separationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separationCrudHelper"></param>
        public SeparationsAppSerives(ISeparationCrudHelper separationCrudHelper, ISeparationService separationService)
        {
            _separationCrudHelper = separationCrudHelper;
            _separationService = separationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<AdmissionResponse> CreateAsync(SeparationInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            Validation.ValidateReflist(input?.SeparationType, "Separation Type");

            Validation.ValidateNullableType(input?.SeparationDate, "Separation Date");
            Validation.ValidateNullableType(input?.Code, "Icd-10 Code");


            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                Validation.ValidateNullableType(input?.SeparationDestinationWard, "Separation Destination Ward");
            }

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.externalTransfer)
            {
                if (input.IsGautengGovFacility)
                    Validation.ValidateNullableType(input?.TransferToHospital, "Gauteng Government Destination Hospital");

                if (!input.IsGautengGovFacility)
                    Validation.ValidateText(input?.TransferToNonGautengHospital, "None Gauteng Government Destination Hospital");
            }

            // var separation = await _separationCrudHelper.CreateAsync(input, person);
            var separation = await _separationService.CreateAsync(input, person);

            return separation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("undoSeparation/{id}")]
        [AbpAuthorize("Approver Level 1")]
        public async Task<AdmissionResponse> UndoSeparationAsync(Guid id)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            var separation = await _separationService.UndoSeparation(id, person);

            return separation;
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet, Route("{id}")]
        //public Task<SeparationResponse> GetAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPut, Route("")]
        //public Task<SeparationResponse> UpdateAsync(SeparationInput input)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
